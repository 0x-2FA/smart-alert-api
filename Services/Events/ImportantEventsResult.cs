using smart_alert_api.Models.Database;

namespace smart_alert_api.Services.Events
{
    public record ImportantEventsResult(List<Event>? earthquakeEvents, List<Event>? fireEvents, List<Event>? floodEvents);
}
