using AutoMapper;
using EventManager.API.Models.Events;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.Services.Interfaces;
using EventManager.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpPost]
        public async Task<ActionResult<EventResponseModel>> Create([FromBody] CreateEventRequestModel requestModel)
        {
            var eventResponseDTO = await eventService.CreateAsync(mapper.Map<CreateEventRequestDTO>(requestModel));

            return CreatedAtAction(nameof(GetByUserIdAndEventId), new { userId = requestModel.UserId, eventId = eventResponseDTO.Id }, mapper.Map<EventResponseModel>(eventResponseDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEventRequestModel requestModel)
        {
            await eventService.UpdateAsync(mapper.Map<UpdateEventRequestDTO>(requestModel));

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<EventResponseModel>> GetByUserIdAndEventId(int userId, int eventId)
        {
            var eventResponseDTO = await eventService.GetByIdAsync(userId, eventId, trackChanges: false);

            return Ok(mapper.Map<EventResponseModel>(eventResponseDTO));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetAllByUserId(int userId, [FromQuery] PagingParameters pagingParameters)
        {
            var eventResponseDTOs = await eventService.GetAllByUserIdAsync(userId, pagingParameters, trackChanges: false);

            return Ok(mapper.Map<IEnumerable<EventResponseModel>>(eventResponseDTOs));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetAll([FromQuery] PagingParameters pagingParameters)
        {
            var eventResponseDTOs = await eventService.GetAllAsync(pagingParameters, trackChanges: false);

            return Ok(mapper.Map<IEnumerable<EventResponseModel>>(eventResponseDTOs));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId, int eventId)
        {
            await eventService.DeleteAsync(userId, eventId);

            return NoContent();
        }
    }
}