namespace EventManager.DAL.Entities
{
    public class EventParticipant : BaseEntity
    {
        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }

        public static EventParticipant CreateParticipant(int userId, int eventId)
            => new EventParticipant 
            { 
                UserId = userId, 
                EventId = eventId 
            };
    }
}