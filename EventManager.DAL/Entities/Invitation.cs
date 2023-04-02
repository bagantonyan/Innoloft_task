namespace EventManager.DAL.Entities
{
    public class Invitation : BaseEntity
    {
        public int Id { get; private set; }
        public int SenderId { get; private set; }
        public User Sender { get; private set; }
        public int ReceiverId { get; private set; }
        public User Receiver { get; private set; }
        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public bool Approved { get; private set; }

        public static Invitation CreateInvitation(int senderId, int receiverId, int eventId)
            => new Invitation
               {
                   SenderId = senderId,
                   ReceiverId = receiverId,
                   EventId = eventId
               };
    }
}