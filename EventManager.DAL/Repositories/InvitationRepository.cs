using EventManager.DAL.Contexts;
using EventManager.DAL.Entities;
using EventManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DAL.Repositories
{
    public class InvitationRepository : BaseRepository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(EventDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Invitation>> GetReceivedInvitationsAsync(int receiverId)
            => await GetByCondition(i => i.ReceiverId == receiverId && !i.Approved, trackChanges: false)
                    .Include(i => i.Sender)
                    .Include(i => i.Receiver)
                    .Include(i => i.Event)
                    .ToListAsync();

        public async Task<IEnumerable<Invitation>> GetSentInvitationsAsync(int senderId)
            => await GetByCondition(i => i.SenderId == senderId && !i.Approved, trackChanges: false)
                    .Include(i => i.Sender)
                    .Include(i => i.Receiver)
                    .Include(i => i.Event)
                    .ToListAsync();

        public async Task<Invitation> GetByUserIdAndEventId(int userId, int eventId, bool trackChanges)
            => await GetByCondition(i => i.ReceiverId == userId && i.EventId == eventId, trackChanges)
                    .SingleOrDefaultAsync();
    }
}