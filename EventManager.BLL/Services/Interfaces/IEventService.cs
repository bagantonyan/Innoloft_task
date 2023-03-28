using EventManager.BLL.DTOs.Events;

namespace EventManager.BLL.Services.Interfaces
{
    public interface IEventService
    {
        Task<EventResponseDTO> CreateAsync(CreateEventRequestDTO requestDTO);
        Task UpdateAsync(UpdateEventRequestDTO requestDTO);
        Task DeleteAsync(int userId, int id);
        Task<IEnumerable<EventResponseDTO>> GetAllByUserIdAsync(int userId, bool trackChanges);
        Task<IEnumerable<EventResponseDTO>> GetAllAsync(bool trackChanges);
        Task<EventResponseDTO> GetByIdAsync(int userId, int eventId, bool trackChanges);
    }
}