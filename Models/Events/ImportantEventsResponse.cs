using smart_alert_api.Models.Database;

namespace smart_alert_api.Models.Events
{
    public record ImportantEventsResponse(List<Event>? listEarthquake, List<Event>? fireEvents, List<Event>? floodEvents);
}
