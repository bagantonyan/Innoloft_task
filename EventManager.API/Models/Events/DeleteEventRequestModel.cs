using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Models.Events
{
    [BindProperties]
    public class DeleteEventRequestModel
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
