namespace EventManager.DAL.Entities
{
    public class Event : BaseEntity
    {
        //public Event(
        //    int userId,
        //    string title,
        //    string description,
        //    DateTime startDate,
        //    DateTime endDate,
        //    string timeZone,
        //    string mode,
        //    bool hidden = false,
        //    string? location = null)
        //{
        //    UserId = userId;
        //    Title = title;
        //    Description = description;
        //    StartDate = startDate;
        //    EndDate = endDate;
        //    TimeZone = timeZone;
        //    Mode = mode;
        //    Hidden = hidden;
        //    Location = location;
        //}

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