using EventManager.DAL.Repositories.Interfaces;

namespace EventManager.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository EventRepository { get; }
        IUserRepository UserRepository { get; }
        IInvitationRepository InvitationRepository { get; }
        Task SaveChangesAsync();
    }
}