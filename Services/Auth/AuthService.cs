using smart_alert_api.Interfaces;

namespace smart_alert_api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEntityUserUtilities _entityUserUtilities;

        public AuthService(IUserRepository userRepository, IEntityUserUtilities entityUserUtilities)
        {
            _userRepository = userRepository;
            _entityUserUtilities = entityUserUtilities;
        }

        public AuthResult Login(string email, string password)
        {
            var user = _userRepository.FindUserByEmail(email);

            return new AuthResult(user);
        }

        public AuthResult Register(string email, string phone, string password)
        {
            var user = _entityUserUtilities.CreateUser();
            user.Email = email;
            user.PhoneNumber = phone;

            _userRepository.AddUser(user, password);

            return new AuthResult(user);
        }
    }
}
