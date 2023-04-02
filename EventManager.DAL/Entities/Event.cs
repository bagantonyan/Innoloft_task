namespace EventManager.DAL.Entities
{
    public class Event : BaseEntity
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string TimeZone { get; private set; }
        public string Mode { get; private set; }
        public string? Location { get; private set; }
        public bool Hidden { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<EventParticipant> Participants { get; private set;}
    }
}