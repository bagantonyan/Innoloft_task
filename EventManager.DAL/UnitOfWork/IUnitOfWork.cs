using EventManager.DAL.Repositories.Interfaces;

namespace EventManager.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository EventRepository { get; }
        Task SaveChangesAsync();
    }
}