using Microsoft.AspNetCore.Identity;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;

namespace smart_alert_api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEntityUserUtilities _entityUserUtilities;
        private readonly SignInManager<EntityUser> _signInManager;


        public AuthService(IUserRepository userRepository, IEntityUserUtilities entityUserUtilities, SignInManager<EntityUser> signInManager)
        {
            _userRepository = userRepository;
            _entityUserUtilities = entityUserUtilities;
            _signInManager = signInManager;
        }

        public AuthResult Login(string email, string password)
        {
            var user = _userRepository.FindUserByEmail(email);

            _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false); ;

            return new AuthResult(user);
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();
        }

        public AuthResult Register(string email, string phone, string password)
        {
            var user = _entityUserUtilities.CreateUser();
            user.Email = email;
            user.PhoneNumber = phone;

            _userRepository.AddUser(user, password, "Civilian");

            return new AuthResult(user);
        }
    }
}
