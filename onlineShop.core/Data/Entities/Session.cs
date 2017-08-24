using System;

namespace onlineShop.core.Entities
{
    public class Session
    {
        public string SessionId { get; set; }
        public DateTime LastTimeActive { get; set; }
        public bool IsLoggedInUser { get; set; }

        public Session(string sessionId, bool isLoggedInUser)
        {
            SessionId = sessionId;
            IsLoggedInUser = isLoggedInUser;
        }

        private Session()
        {
        }
    }
}
