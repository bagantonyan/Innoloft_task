using EventManager.DAL.Entities;

namespace EventManager.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByIdAsync(int userId, bool trackChanges);
        Task<bool> IsEmpty();
        Task<List<int>> GetAllUserIds();
    }
}
