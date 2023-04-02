using AutoMapper;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.DTOs.Invitations;
using EventManager.BLL.Services.Interfaces;
using EventManager.DAL.Entities;
using EventManager.DAL.UnitOfWork;
using EventManager.Shared.Exceptions;
using EventManager.Shared.RequestFeatures;

namespace EventManager.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public EventService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<EventResponseDTO> CreateAsync(CreateEventRequestDTO requestDTO)
        {
            var userEntity = await unitOfWork.UserRepository
                .GetByIdAsync(requestDTO.UserId, trackChanges: false);

            if (userEntity is null)
                throw new UserNotFoundException(requestDTO.UserId);

            var eventEntity = mapper.Map<Event>(requestDTO);
            unitOfWork.EventRepository.Create(eventEntity);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<EventResponseDTO>(eventEntity);
        }

        public async Task UpdateAsync(UpdateEventRequestDTO requestDTO)
        {
            var eventEntity = await unitOfWork.EventRepository
                .GetByUserIdAndEventIdAsync(requestDTO.UserId, requestDTO.Id, trackChanges: true);

            if (eventEntity is null)
                throw new EventNotFoundException(requestDTO.Id);

            mapper.Map(requestDTO, eventEntity);
            unitOfWork.EventRepository.Update(eventEntity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int eventId)
        {
            var eventEntity = await unitOfWork.EventRepository
                .GetByUserIdAndEventIdAsync(userId, eventId, trackChanges: true);

            if (eventEntity is null)
                throw new EventNotFoundException(eventId);

            unitOfWork.EventRepository.Delete(eventEntity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventResponseDTO>> GetAllByUserIdAsync(int userId, PagingParameters pagingParameters, bool trackChanges)
        {
            var userEntity = await unitOfWork.UserRepository
                .GetByIdAsync(userId, trackChanges: false);

            if (userEntity is null)
                throw new UserNotFoundException(userId);

            var eventEntities = await unitOfWork.EventRepository
                .GetAllByUserIdAsync(userId, pagingParameters, trackChanges);

            return mapper.Map<IEnumerable<EventResponseDTO>>(eventEntities);
        }

        public async Task<EventResponseDTO> GetByIdAsync(int eventId, bool trackChanges)
        {
            var eventEntity = await unitOfWork.EventRepository
                .GetByIdAsync(eventId, trackChanges);

            if (eventEntity is null)
                throw new EventNotFoundException(eventId);

            return mapper.Map<EventResponseDTO>(eventEntity);
        }

        public async Task<IEnumerable<EventResponseDTO>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges)
        {
            var eventEntities = await unitOfWork.EventRepository
                .GetAllAsync(pagingParameters, trackChanges);

            return mapper.Map<IEnumerable<EventResponseDTO>>(eventEntities);
        }

        public async Task ParticipateAsync(int userId, int eventId)
        {
            var eventEntity = await unitOfWork.EventRepository
                .GetByIdAsync(eventId, trackChanges: true);

            if (eventEntity is null)
                throw new EventNotFoundException(eventId);

            if (eventEntity.Participants.Any(p => p.UserId == userId && p.EventId == eventId))
                throw new BadRequestException("User already participates to event");

            var userEntity = await unitOfWork.UserRepository
                .GetByIdAsync(userId, trackChanges: true);

            if (userEntity is null)
                throw new UserNotFoundException(userId);

            var userEvent = await unitOfWork.EventRepository
                .GetByUserIdAndEventIdAsync(userId, eventId, trackChanges: true);

            if (userEvent is not null)
                throw new BadRequestException("User can't send participate request for it's own request");

            var invitation = await unitOfWork.InvitationRepository
                .GetByUserIdAndEventId(userId, eventId, trackChanges: true);

            if (invitation is not null)
            {
                Invitation.ApproveInvitation(invitation);
                unitOfWork.InvitationRepository.Update(invitation);
            }

            eventEntity.Participants.Add(EventParticipant.CreateParticipant(userId, eventId));

            unitOfWork.EventRepository.Update(eventEntity);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task SendInvitationAsync(SendInvitationRequestDTO requestDTO)
        {
            var userEntity = await unitOfWork.UserRepository
                .GetByIdAsync(requestDTO.SenderId, trackChanges: true);

            if (userEntity is null)
                throw new UserNotFoundException(requestDTO.SenderId);

            var eventEntity = await unitOfWork.EventRepository
                .GetByUserIdAndEventIdAsync(requestDTO.SenderId, requestDTO.EventId, trackChanges: true);

            if (eventEntity is null)
                throw new EventNotFoundException(requestDTO.EventId);

            var allUserIds = await unitOfWork.UserRepository.GetAllUserIds();

            if (requestDTO.ReceiverIds.Contains(requestDTO.SenderId))
                throw new BadRequestException("User can't send invitation to itself");

            if (allUserIds.Intersect(requestDTO.ReceiverIds).Count() != requestDTO.ReceiverIds.Count())
                throw new BadRequestException("Invalid receiver ids");

            var newInvitations = requestDTO.ReceiverIds
                .Select(id => Invitation.CreateInvitation(requestDTO.SenderId, id, requestDTO.EventId));

            await unitOfWork.InvitationRepository.AddRangeAsync(newInvitations);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<InvitationResponseDTO>> GetReceivedInvitationsAsync(int receiverId)
        {
            var invitations = await unitOfWork.InvitationRepository
                .GetReceivedInvitationsAsync(receiverId);

            return mapper.Map<IEnumerable<InvitationResponseDTO>>(invitations);
        }

        public async Task<IEnumerable<InvitationResponseDTO>> GetSentInvitationsAsync(int senderId)
        {
            var invitations = await unitOfWork.InvitationRepository
                .GetSentInvitationsAsync(senderId);

            return mapper.Map<IEnumerable<InvitationResponseDTO>>(invitations);
        }
    }
}