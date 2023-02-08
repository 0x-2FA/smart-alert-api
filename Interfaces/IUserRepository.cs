using smart_alert_api.Models.Database;

namespace smart_alert_api.Interfaces
{
    public interface IUserRepository
    {
        EntityUser? FindUserByEmail(string email);

        Boolean IsPasswordValid(string email, string password);

        void AddUser(EntityUser user, string password);
    }
}
