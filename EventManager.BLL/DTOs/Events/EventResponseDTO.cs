using EventManager.BLL.DTOs.Users;

namespace EventManager.BLL.DTOs.Events
{
    public class EventResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeZone { get; set; }
        public string Mode { get; set; }
        public string? Location { get; set; }
        public bool Hidden { get; set; }
        public UserResponseDTO User { get; set; }
    }
}