using EventManager.DAL.Contexts;
using EventManager.DAL.Repositories;
using EventManager.DAL.Repositories.Interfaces;

namespace EventManager.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventDbContext _dbContext;

        public UnitOfWork(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly IEventRepository _eventRepository;
        public IEventRepository EventRepository =>
            _eventRepository is not null ? _eventRepository : new EventRepository(_dbContext);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
        public void Dispose() => _dbContext.Dispose();
    }
}