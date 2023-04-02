using EventManager.DAL.Contexts;
using EventManager.DAL.Entities;
using EventManager.DAL.Repositories.Interfaces;
using EventManager.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DAL.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Event>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges)
            => await GetAll(trackChanges)
            .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
            .Take(pagingParameters.PageSize)
            .ToListAsync();

        public async Task<IEnumerable<Event>> GetAllByUserIdAsync(int userId, PagingParameters pagingParameters, bool trackChanges)
            => await GetByCondition(e => e.UserId == userId, trackChanges)
            .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
            .Take(pagingParameters.PageSize)
            .ToListAsync();

        public async Task<Event> GetByIdAsync(int eventId, bool trackChanges)
            => await GetByCondition(e => e.Id == eventId, trackChanges)
            .Include(e => e.User)
            .Include(e => e.Participants)
            .SingleOrDefaultAsync();

        public async Task<Event> GetByUserIdAndEventIdAsync(int userId, int eventId, bool trackChanges)
            => await GetByCondition(e => e.UserId == userId && e.Id == eventId, trackChanges)
            .SingleOrDefaultAsync();
    }
}