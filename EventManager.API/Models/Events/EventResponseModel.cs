using EventManager.API.Models.Users;

namespace EventManager.API.Models.Events
{
    public class EventResponseModel
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string TimeZone { get; private set; }
        public string Mode { get; private set; }
        public string? Location { get; private set; }
        public bool Hidden { get; private set; }
        public UserResponseModel User { get; set; }
    }
}