using EventManager.BLL.DTOs.Events;
using EventManager.BLL.DTOs.Invitations;
using EventManager.Shared.RequestFeatures;

namespace EventManager.BLL.Services.Interfaces
{
    public interface IEventService
    {
        Task<EventResponseDTO> CreateAsync(CreateEventRequestDTO requestDTO);
        Task UpdateAsync(UpdateEventRequestDTO requestDTO);
        Task DeleteAsync(int userId, int id);
        Task<IEnumerable<EventResponseDTO>> GetAllByUserIdAsync(int userId, PagingParameters pagingParameters, bool trackChanges);
        Task<IEnumerable<EventResponseDTO>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges);
        Task<EventResponseDTO> GetByIdAsync(int eventId, bool trackChanges);
        Task ParticipateAsync(int userId, int eventId);
        Task SendInvitationAsync(SendInvitationRequestDTO requestDTO);
        Task<IEnumerable<InvitationResponseDTO>> GetReceivedInvitationsAsync(int receiverId);
        Task<IEnumerable<InvitationResponseDTO>> GetSentInvitationsAsync(int senderId);
    }
}