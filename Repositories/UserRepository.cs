using Microsoft.AspNetCore.Identity;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;

namespace smart_alert_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IEntityUserUtilities _entityUserUtilities;
        private readonly SignInManager<EntityUser> _signInManager;
        private readonly IUserStore<EntityUser> _userStore;
        private readonly IUserEmailStore<EntityUser> _emailStore;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(SignInManager<EntityUser> signInManager, IUserStore<EntityUser> userStore, IEntityUserUtilities entityUserUtilities)
        {
            _userStore = userStore;
            _signInManager = signInManager;
            _entityUserUtilities = entityUserUtilities;
            _emailStore = _entityUserUtilities.GetEmailStore();
        }

        public EntityUser? FindUserByEmail(string email)
        {
            return _signInManager.UserManager.FindByEmailAsync(email).Result;
        }

        public bool IsPasswordValid(string email, string password)
        {
            var user = FindUserByEmail(email);

            return _signInManager.UserManager.CheckPasswordAsync(user, password).Result;
        }

        public void AddUser(EntityUser user, string password)
        {
            _emailStore.SetUserNameAsync(user, user.Email, CancellationToken.None);
            _userStore.SetUserNameAsync(user, user.Email, CancellationToken.None);

            _signInManager.UserManager.CreateAsync(user, password);
        }

    }
}
