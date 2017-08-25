using onlineShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineShopWeb.Utility
{
    public static class UserIdentifier
    {
        public static string GetIdentifier(HttpContextBase context, out bool isLoggedIn)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                return context.User.Identity.Name;
            }

            isLoggedIn = false;
            return context.Session.SessionID;
        }        
    }
}