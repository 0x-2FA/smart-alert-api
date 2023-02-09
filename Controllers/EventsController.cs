using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;
using smart_alert_api.Models.Events;
using smart_alert_api.Services.Events;

namespace smart_alert_api.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IEventRepository _eventRepository;
        private readonly SignInManager<EntityUser> _signInManager;

        public EventsController(IEventService eventService, IEventRepository eventRepository, SignInManager<EntityUser> signInManager)
        {
            _eventService = eventService;
            _eventRepository = eventRepository;
            _signInManager = signInManager;
        }

        [HttpGet("{id:long}")]
        public IActionResult Get(long id)
        {
            if (_eventRepository.FindEventById(id) == null)
            {
                return BadRequest();
            }

            var eventResult = _eventService.GetEvent(id);

            var response = new EventsResponse(eventResult.evnt);

            return Ok(response.evnt);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            if(!_signInManager.IsSignedIn(User))
            {
                return Unauthorized();
            }

            if(!User.IsInRole("CivilProtection"))
            {
                return StatusCode(403);
            }

            if (_eventRepository.FindEventById(id) == null)
            {
                return BadRequest(id);
            }

            var eventResult = _eventService.DeleteEvent(id);

            var response = new EventDeletedResponse(eventResult.id);

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateEventRequest createRequest)
        {

            var eventResult = _eventService.CreateEvent(
                createRequest.type,
                createRequest.latitude,
                createRequest.longitude,
                createRequest.photo,
                createRequest.comment,
                createRequest.user_id);

            var response = new EventsResponse(eventResult.evnt);

            return Created(nameof(response.evnt), response.evnt);
        }
    }
}
