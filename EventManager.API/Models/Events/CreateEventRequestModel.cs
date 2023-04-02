using EventManager.Shared.Enums;

namespace EventManager.API.Models.Events
{
    public class CreateEventRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeZone { get; set; }
        public EventMode Mode { get; set; }
        public string? Location { get; set; }
        public bool Hidden { get; set; }
        public int UserId { get; set; }
    }
}