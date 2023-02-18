using Microsoft.AspNetCore.Identity;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;

namespace smart_alert_api.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IDateUtilities _dateUtilities;

        public EventService(IEventRepository eventRepository, IDateUtilities dateUtilities)
        {
            _eventRepository = eventRepository;
            _dateUtilities = dateUtilities;
        }

        public EventResult CreateEvent(string type, string latitude, string longitude, string? photo, string? comment, string user_id)
        {
            var evnt = new Event();

            evnt.Type = type;
            evnt.Latitude = latitude;
            evnt.Longitude = longitude;
            evnt.Timestamp = _dateUtilities.NowDefaultString();
            evnt.Photo = photo;
            evnt.Comment = comment;
            evnt.UserId = user_id;

            _eventRepository.CreateEvent(evnt);
            return new EventResult(evnt);
        }

        public EventDeleteResult DeleteEvent(long id)
        {
            _eventRepository.DeleteEventById(id);

            return new EventDeleteResult(id);
        }

        public ListEventResult GetAll()
        {
            var listOfEvents = _eventRepository.GetAllEvents();

            return new ListEventResult(listOfEvents);
        }

        public EventResult GetEvent(long id)
        {
            var evnt = _eventRepository.FindEventById(id);

            return new EventResult(evnt);
        }
    }
}
