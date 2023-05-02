using smart_alert_api.Models.Database;

namespace smart_alert_api.Services.Events
{
    public record ImportantEventsResult(Event? importantEarthquakeEvent, Event? importantFireEvent, Event? importantFloodEvent);
}
