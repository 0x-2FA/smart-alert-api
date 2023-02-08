using Microsoft.AspNetCore.Identity;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;


namespace smart_alert_api.Utilities
{
    public class EntityUserUtilities : IEntityUserUtilities
    {
        private readonly SignInManager<EntityUser> _signInManager;
        private readonly IUserStore<EntityUser> _userStore;

        public EntityUserUtilities(SignInManager<EntityUser> signInManager, IUserStore<EntityUser> userStore)
        {
            _signInManager = signInManager;
            _userStore = userStore;
        }

        public EntityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<EntityUser>();
            }
            catch
            {
                throw new InvalidOperationException("Can't create instance of Entity User");
            }
        }

        public IUserEmailStore<EntityUser> GetEmailStore()
        {
            if(!_signInManager.UserManager.SupportsUserEmail)
            {
                throw new NotSupportedException("Requires a user store with email support.");
            }

            return (IUserEmailStore<EntityUser>)_userStore;
        }
    }
}
