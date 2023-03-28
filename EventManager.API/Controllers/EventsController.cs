using AutoMapper;
using EventManager.API.Models.Events;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEventService eventService;

        public EventsController(
            IMapper mapper,
            IEventService eventService)
        {
            this.mapper = mapper;
            this.eventService = eventService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<EventResponseModel>> Create([FromBody] CreateEventRequestModel requestModel)
        {
            var eventResponseDTO = await eventService.CreateAsync(mapper.Map<CreateEventRequestDTO>(requestModel));

            return CreatedAtAction(nameof(GetByUserIdAndEventId), new { id = eventResponseDTO.Id }, mapper.Map<EventResponseModel>(eventResponseDTO));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEventRequestModel requestModel)
        {
            await eventService.UpdateAsync(mapper.Map<UpdateEventRequestDTO>(requestModel));

            return NoContent();
        }

        [HttpGet("Get/{userId}/{eventId}")]
        public async Task<ActionResult<EventResponseModel>> GetByUserIdAndEventId([FromQuery] GetByIdRequestModel requestModel)
        {
            var eventResponseDTO = await eventService.GetByIdAsync(requestModel.UserId, requestModel.EventId, trackChanges: false);

            return Ok(mapper.Map<EventResponseModel>(eventResponseDTO));
        }

        [HttpGet("GetAll/{userId}")]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetAllByUserId([FromQuery] GetAllByUserIdRequestModel requestModel)
        {
            var eventResponseDTOs = await eventService.GetAllByUserIdAsync(requestModel.UserId, trackChanges: false);

            return Ok(mapper.Map<IEnumerable<EventResponseModel>>(eventResponseDTOs));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetAll()
        {
            var eventResponseDTOs = await eventService.GetAllAsync(trackChanges: false);

            return Ok(mapper.Map<IEnumerable<EventResponseModel>>(eventResponseDTOs));
        }

        [HttpDelete("Delete/{userId}/{eventId}")]
        public async Task<IActionResult> Delete([FromQuery] DeleteEventRequestModel requestModel)
        {
            await eventService.DeleteAsync(requestModel.UserId, requestModel.EventId);

            return NoContent();
        }
    }
}