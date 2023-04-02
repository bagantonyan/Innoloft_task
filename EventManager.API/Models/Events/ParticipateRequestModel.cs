namespace EventManager.API.Models.Events
{
    public class ParticipateRequestModel
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}