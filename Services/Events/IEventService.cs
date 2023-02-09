using smart_alert_api.Models.Database;

namespace smart_alert_api.Services.Events
{
    public interface IEventService
    {
        EventResult CreateEvent(string type, string? photo, string? comment, string user_id);
        EventResult DeleteEvent(long id);
    }
}
