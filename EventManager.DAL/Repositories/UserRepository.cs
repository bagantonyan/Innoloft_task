using EventManager.DAL.Contexts;
using EventManager.DAL.Entities;
using EventManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EventDbContext dbContext) : base(dbContext) { }

        public async Task<User> GetByIdAsync(int userId, bool trackChanges)
            => await GetByCondition(u => u.Id == userId, trackChanges)
            .SingleOrDefaultAsync();

        public async Task<bool> IsEmpty()
            => !await _dbSet.AnyAsync();

        public async Task<List<int>> GetAllUserIds()
            => await GetAll(trackChanges: false).Select(u => u.Id).ToListAsync();
    }
}