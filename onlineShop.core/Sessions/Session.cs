using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.core.Sessions
{
    public class Session
    {
        public string SessionId { get; set; }
        public Cart Cart { get; set; }
        public DateTime LastTimeActive { get; set; }
        public bool IsLoggedInUser { get; set; }

        public Session(string sessionId, bool isLoggedInUser)
        {
            SessionId = sessionId;
            IsLoggedInUser = isLoggedInUser;
        }
    }
}
