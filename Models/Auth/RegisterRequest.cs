namespace smart_alert_api.Models.Auth
{
    public record RegisterRequest(string email, string phone, string password);
}
