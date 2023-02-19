using smart_alert_api.Models.Database;

namespace smart_alert_api.Models.Events
{
    public record ImportantEventsResponse(Event? importantEarthquakeEvent, Event? importantFireEvent, Event? importantFloodEvent);
}
