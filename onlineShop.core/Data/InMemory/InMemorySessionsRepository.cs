using onlineShop.core.Sessions;
using System.Collections.Generic;

namespace onlineShop.core.Data.InMemory
{
    public class InMemorySessionsRepository
    {
        public Dictionary<string, Session> Sessions;

        public InMemorySessionsRepository()
        {
            Sessions = new Dictionary<string, Session>();
        }
    }
}
