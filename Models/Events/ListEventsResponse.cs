using smart_alert_api.Models.Database;

namespace smart_alert_api.Models.Events
{
    public record ListEventsResponse(List<Event> listOfEvents);
}
