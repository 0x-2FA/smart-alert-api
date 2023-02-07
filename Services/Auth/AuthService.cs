namespace smart_alert_api.Services.Auth
{
    public class AuthService : IAuthService
    {
        public AuthResult Login(string email, string password)
        {
            return new AuthResult(email);
        }

        public AuthResult Register(string email, string phone, string password)
        {
            return new AuthResult(email);
        }
    }
}
