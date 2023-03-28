using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Models.Events
{
    [BindProperties]
    public class GetAllByUserIdRequestModel
    {
        public int UserId { get; set; }
    }
}