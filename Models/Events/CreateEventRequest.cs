using smart_alert_api.Models.Database;

namespace smart_alert_api.Models.Events
{
    public record CreateEventRequest(string type, string latitude, string longitude, string? photo, string? comment, string user_id);
}
