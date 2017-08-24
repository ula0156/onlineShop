using onlineShop.core.Entities;

namespace onlineShop.core.Data
{
     public interface ISessionsProvider
    {
        void UpdateOrAddSession(string sessionId, bool isLoggedInUser);
    }
}
