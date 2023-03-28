using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Models.Events
{
    [BindProperties]
    public class GetByIdRequestModel
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}