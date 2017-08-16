using onlineShop.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Timers;

namespace onlineShop.core.Specials
{
    public class InactiveSessionsDetector
    {
        public delegate void InactiveSessionsHandler(List<string> listOfInactiveSessions);
        private InactiveSessionsHandler _inactiveSessionsHandler;
        private CartProvider _cartProvider;

        public InactiveSessionsDetector(CartProvider cartProvider, InactiveSessionsHandler inactiveSessionsHandler)
        {
            _inactiveSessionsHandler = inactiveSessionsHandler;
            _cartProvider = cartProvider;
        }

        private void StartTimer()
        {
            Timer t = new Timer();
            t.Interval = 60000;
            t.Elapsed += new ElapsedEventHandler(OnTimerEvent);
            t.Enabled = true;
            t.AutoReset = true;

        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            //List<string> listOfInactiveSessions = _cartProvider.GetCart().
        }
    }
}
