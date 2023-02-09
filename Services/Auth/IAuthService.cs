namespace smart_alert_api.Services.Auth
{
    public interface IAuthService
    {
        AuthResult Login(string email, string password);
        public void Logout();
        AuthResult Register(string email, string phone, string password);

    }
}
