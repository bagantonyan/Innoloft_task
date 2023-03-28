using EventManager.DAL.Entities;

namespace EventManager.DAL.Repositories.Interfaces
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<Event> GetByIdAsync(int userID, int eventId, bool trackChanges);
        Task<IEnumerable<Event>> GetAllByUserIdAsync(int userId, bool trackChanges);
        Task<IEnumerable<Event>> GetAllAsync(bool trackChanges);
    }
}