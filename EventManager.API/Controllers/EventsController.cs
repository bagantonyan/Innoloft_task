using AutoMapper;
using EventManager.API.Models.Events;
using EventManager.API.Models.Invitations;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.DTOs.Invitations;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventResponseModel>> Create([FromBody] CreateEventRequestModel requestModel)
        {
            var eventResponseDTO = await eventService.CreateAsync(mapper.Map<CreateEventRequestDTO>(requestModel));

            return CreatedAtAction(nameof(GetById), new { eventId = eventResponseDTO.Id }, mapper.Map<EventResponseModel>(eventResponseDTO));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateEventRequestModel requestModel)
        {
            await eventService.UpdateAsync(mapper.Map<UpdateEventRequestDTO>(requestModel));

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventResponseModel>> GetById(int eventId)
        {
            var eventResponseDTO = await eventService.GetByIdAsync(eventId, trackChanges: false);

            return Ok(mapper.Map<EventResponseModel>(eventResponseDTO));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetAllByUserId(int userId, [FromQuery] PagingParameters pagingParameters)
        {
            var eventResponseDTOs = await eventService.GetAllByUserIdAsync(userId, pagingParameters, trackChanges: false);

            return Ok(mapper.Map<IEnumerable<EventResponseModel>>(eventResponseDTOs));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetAll([FromQuery] PagingParameters pagingParameters)
        {
            var eventResponseDTOs = await eventService.GetAllAsync(pagingParameters, trackChanges: false);

            return Ok(mapper.Map<IEnumerable<EventResponseModel>>(eventResponseDTOs));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int userId, int eventId)
        {
            await eventService.DeleteAsync(userId, eventId);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Participate([FromBody] ParticipateRequestModel requestModel)
        {
            await eventService.ParticipateAsync(requestModel.UserId, requestModel.EventId);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendInvitation([FromBody] SendInvitationRequestModel requestModel)
        {
            await eventService.SendInvitationAsync(mapper.Map<SendInvitationRequestDTO>(requestModel));

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<InvitationResponseModel>>> GetReceivedInvitations(int receiverId)
        {
            var invitations = await eventService.GetReceivedInvitationsAsync(receiverId);

            return Ok(mapper.Map<IEnumerable<InvitationResponseModel>>(invitations));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<InvitationResponseModel>>> GetSentInvitations(int senderId)
        {
            var invitations = await eventService.GetSentInvitationsAsync(senderId);

            return Ok(mapper.Map<IEnumerable<InvitationResponseModel>>(invitations));
        }
    }
}