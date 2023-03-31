using AutoMapper;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.Exceptions;
using EventManager.BLL.Services.Interfaces;
using EventManager.DAL.Entities;
using EventManager.DAL.UnitOfWork;
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
            var eventEntity = mapper.Map<Event>(requestDTO);

            unitOfWork.EventRepository.Create(eventEntity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<EventResponseDTO>(eventEntity);
        }

        public async Task UpdateAsync(UpdateEventRequestDTO requestDTO)
        {
            var eventEntity = await unitOfWork.EventRepository.GetByIdAsync(requestDTO.UserId, requestDTO.Id, trackChanges: true);

            if (eventEntity == null)
                throw new EventNotFoundException(requestDTO.Id);

            mapper.Map(requestDTO, eventEntity);

            unitOfWork.EventRepository.Update(eventEntity);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int eventId)
        {
            var eventEntity = await unitOfWork.EventRepository.GetByIdAsync(userId, eventId, trackChanges: true);

            if (eventEntity == null)
                throw new EventNotFoundException(eventId);

            unitOfWork.EventRepository.Delete(eventEntity);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventResponseDTO>> GetAllByUserIdAsync(int userId, PagingParameters pagingParameters, bool trackChanges)
        {
            var eventEntities = await unitOfWork.EventRepository.GetAllByUserIdAsync(userId, pagingParameters, trackChanges);

            return mapper.Map<IEnumerable<EventResponseDTO>>(eventEntities);
        }

        public async Task<EventResponseDTO> GetByIdAsync(int userId, int eventId, bool trackChanges)
        {
            var eventEntity = await unitOfWork.EventRepository.GetByIdAsync(userId, eventId, trackChanges);

            if (eventEntity == null)
                throw new EventNotFoundException(eventId);

            return mapper.Map<EventResponseDTO>(eventEntity);
        }

        public async Task<IEnumerable<EventResponseDTO>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges)
        {
            var eventEntities = await unitOfWork.EventRepository.GetAllAsync(pagingParameters, trackChanges);

            return mapper.Map<IEnumerable<EventResponseDTO>>(eventEntities);
        }
    }
} 