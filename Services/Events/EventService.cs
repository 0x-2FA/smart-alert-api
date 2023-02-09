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

        public EventResult CreateEvent(string type, string? photo, string? comment, string user_id)
        {
            var evnt = new Event();

            evnt.Type = type;
            evnt.Timestamp = _dateUtilities.NowDefaultString();
            evnt.Photo = photo;
            evnt.Comment = comment;
            evnt.UserId = user_id;

            _eventRepository.CreateEvent(evnt);
            return new EventResult(evnt);
        }

        public EventResult DeleteEvent(long id)
        {
            throw new NotImplementedException();
        }
    }
}
