using EventManager.BLL.DTOs.Events;
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
        Task<EventResponseDTO> GetByIdAsync(int userId, int eventId, bool trackChanges);
    }
}