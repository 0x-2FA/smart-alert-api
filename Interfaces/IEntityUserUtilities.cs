using Microsoft.AspNetCore.Identity;
using smart_alert_api.Models.Database;

namespace smart_alert_api.Interfaces
{
    public interface IEntityUserUtilities
    {
        EntityUser CreateUser();

        IUserEmailStore<EntityUser> GetEmailStore();
    }
}
