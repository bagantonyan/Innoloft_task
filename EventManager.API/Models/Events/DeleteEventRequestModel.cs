using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Models.Events
{
    public class DeleteEventRequestModel
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
