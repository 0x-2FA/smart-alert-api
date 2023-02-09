using Microsoft.AspNetCore.Http;
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

        public EventsController(IEventService eventService, IEventRepository eventRepository)
        {
            _eventService = eventService;
            _eventRepository = eventRepository;
        }


        [HttpPost("create")]
        public IActionResult Create(CreateEventRequest createRequest)
        {
            
            var eventResult = _eventService.CreateEvent(
                createRequest.type,
                createRequest.photo,
                createRequest.comment,
                createRequest.user_id);

            var response = new EventsResponse(eventResult.evnt);

            return Created(nameof(response.evnt), response.evnt);
        }
    }
}
