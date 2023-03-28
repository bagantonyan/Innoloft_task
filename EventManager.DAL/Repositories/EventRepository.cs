using EventManager.DAL.Contexts;
using EventManager.DAL.Entities;
using EventManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DAL.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Event>> GetAllAsync(bool trackChanges)
            => await GetAll(trackChanges)
            .ToListAsync();

        public async Task<IEnumerable<Event>> GetAllByUserIdAsync(int userId, bool trackChanges)
            => await GetByCondition(e => e.UserId == userId, trackChanges)
            .ToListAsync();

        public async Task<Event> GetByIdAsync(int userID, int eventId, bool trackChanges)
            => await GetByCondition(e => e.UserId == userID && e.Id == eventId, trackChanges)
            .SingleOrDefaultAsync();
    }
}