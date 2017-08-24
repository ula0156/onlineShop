using onlineShop.core.Entities;
using onlineShop.Data.Database;
using System;
using System.Linq;

namespace onlineShop.core.Data.Database
{
    public class DBSessionsProvider : ISessionsProvider
    {
        private ReservationsModel _sessionsModel;

        public DBSessionsProvider()
        {
            _sessionsModel = new ReservationsModel();
        }

        public void UpdateOrAddSession(string sessionId, bool isLoggedInUser)
        {

            Session session = _sessionsModel.Sessions.FirstOrDefault(id => id.SessionId == sessionId);
            if (session == null)
            {
                session = new Session(sessionId, isLoggedInUser);
            }
            else
            {
                session.LastTimeActive = DateTime.Now;
                
            }

            _sessionsModel.SaveChanges();
        }
    }
}
