using onlineShop.core.Sessions;

namespace onlineShop.core.Data
{
     public interface ISessionsProvider
    {
        Session UpdateOrAddSession(string sessionId, bool isLoggedInUser);
        Session GetSession(string sessionId);
    }
}
