using EventManager.DAL.Entities;

namespace EventManager.DAL.Repositories.Interfaces
{
    public interface IInvitationRepository : IBaseRepository<Invitation>
    {
        Task<IEnumerable<Invitation>> GetReceivedInvitationsAsync(int receiverId);
        Task<IEnumerable<Invitation>> GetSentInvitationsAsync(int senderId);
    }
}