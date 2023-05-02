using smart_alert_api.Models.Database;

namespace smart_alert_api.Services.Events
{
    public interface IEventService
    {
        EventResult GetEvent(long id);
        EventResult CreateEvent(string type, string latitude, string longitude, string? photo, string? comment, string user_id);
        EventDeleteResult DeleteEvent(long id);
        ListEventResult GetAll();
        EventUserStatisticsResult GetEventUserStatistics(string userId);
        ImportantEventsResult GetAllImportant();
    }
}
