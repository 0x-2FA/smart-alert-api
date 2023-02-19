using Geolocation;
using Microsoft.AspNetCore.Identity;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;
using System.Globalization;

namespace smart_alert_api.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IDateUtilities _dateUtilities;
        private readonly IGeoLocation _geoLocation;

        public EventService(IEventRepository eventRepository, IDateUtilities dateUtilities, IGeoLocation geoLocation)
        {
            _eventRepository = eventRepository;
            _dateUtilities = dateUtilities;
            _geoLocation = geoLocation;
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

        public ImportantEventsResult GetAllImportant()
        {

            var importantEarthquakeEvent = this.ImportantEarthquakeEvents();

            var importantFireEvent = this.ImportantFireEvents();


            return new ImportantEventsResult(earthquakeEvents, importantFireEvent, null);
        }

        public EventResult GetEvent(long id)
        {
            var evnt = _eventRepository.FindEventById(id);

            return new EventResult(evnt);
        }

        private Event ImportantEarthquakeEvents()
        {
            var earthquakeEvents = _eventRepository.GetEventsByType("Earthquake");

            var today = _dateUtilities.GetDateOnlyString(_dateUtilities.NowDefaultString());

            // filter by date
            var filteredListByDate = earthquakeEvents.Where(evnt =>
                                      _dateUtilities.GetDateOnlyString(evnt.Timestamp)
                                      .Equals(today)
                                      || _dateUtilities.GetDateOnlyString(evnt.Timestamp)
                                      .Equals(_dateUtilities.DatePreviousDayString(today))).ToList();

            var now = _dateUtilities.TimeNowDefaultString();

            // filter by time
            var filteredListByTime = filteredListByDate.Where(evnt => 
            _dateUtilities.TimeOnlyString(evnt.Timestamp)
            .Equals(now) 
            || _dateUtilities.BetweenHoursFromNow(evnt.Timestamp, 2)).ToList();

            if (filteredListByDate.Count <= 5)
            {
                return null;
            }

            // filter by distance (lat, long)
            List<Event> filteredListByDistance = new List<Event>();

            foreach (var evnt in filteredListByTime)
            {
                var listSmall = filteredListByTime.Where(x =>
                        x != evnt &&
                        _geoLocation.GetDistanceInKm(double.Parse(x.Latitude, CultureInfo.InvariantCulture), double.Parse(x.Longitude, CultureInfo.InvariantCulture), double.Parse(evnt.Latitude, CultureInfo.InvariantCulture), double.Parse(evnt.Longitude, CultureInfo.InvariantCulture)) <= 5)
                    .ToList();

                if (listSmall.Count != 0)
                {
                    filteredListByDistance = listSmall;
                }
            }

            // remove duplicates
            var filteredListWithoutDups = filteredListByDistance.Distinct().ToList();

            return filteredListWithoutDups[0];
        }

        private Event ImportantFireEvents()
        {
            var fireEvents = _eventRepository.GetEventsByType("Fire");

            var today = _dateUtilities.GetDateOnlyString(_dateUtilities.NowDefaultString());

            // filter by date
            var filteredListByDate = fireEvents.Where(evnt =>
                                      _dateUtilities.GetDateOnlyString(evnt.Timestamp)
                                      .Equals(today)
                                      || _dateUtilities.GetDateOnlyString(evnt.Timestamp)
                                      .Equals(_dateUtilities.DatePreviousDayString(today))).ToList();

            // filter by time (Maybe skip)


            if(filteredListByDate.Count <= 10)
            {
                return null;
            }

            // filter by distance (lat, long)
            List<Event> filteredListByDistance = new List<Event>();

            foreach (var evnt in filteredListByDate)
            {
                var listSmall = filteredListByDate.Where(x =>
                        x != evnt &&
                        _geoLocation.GetDistanceInKm(double.Parse(x.Latitude, CultureInfo.InvariantCulture), double.Parse(x.Longitude, CultureInfo.InvariantCulture), double.Parse(evnt.Latitude, CultureInfo.InvariantCulture), double.Parse(evnt.Longitude, CultureInfo.InvariantCulture)) <= 10)
                    .ToList();

                if (listSmall.Count != 0)
                {
                    filteredListByDistance = listSmall;
                }
            }

            // remove duplicates
            var filteredListWithoutDups = filteredListByDistance.Distinct().ToList();

            return filteredListWithoutDups[0];
        }
    }
}
