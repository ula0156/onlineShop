using onlineShop.core.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.core.Data.InMemory
{
    public class InMemorySessionsProvider : ISessionsProvider
    {
        private InMemorySessionsRepository _inMemorySessionsRepository;

        public InMemorySessionsProvider()
        {
            _inMemorySessionsRepository = new InMemorySessionsRepository();
        }

        public Session UpdateOrAddSession(string sessionId, bool isLoggedInUser)
        {
            
            if (_inMemorySessionsRepository.Sessions.ContainsKey(sessionId))
            {
                return UpdateLastActiveTime(sessionId);

            } 
            else
            {
                return AddSession(sessionId, isLoggedInUser);
                
            }
        }

        public Session GetSession(string sessionId)
        {
            if (_inMemorySessionsRepository.Sessions.ContainsKey(sessionId))
            {
                return _inMemorySessionsRepository.Sessions[sessionId];
            }

            return null;
        }

        private Session UpdateLastActiveTime(string sessionId)
        {
            var session = _inMemorySessionsRepository.Sessions[sessionId];
            session.LastTimeActive = DateTime.Now;
            return session;
        }

        private Session AddSession(string sessionId, bool isLoggedInUser)
        {
            var session = new Session(sessionId, isLoggedInUser);
            _inMemorySessionsRepository.Sessions.Add(sessionId, session);
            return session;
        }
        
    }
}
