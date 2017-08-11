using onlineShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineShopWeb.Utility
{
    public static class IdentifierLoginUsers
    {
        public static string GetIdentifier(HttpContextBase context)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return context.User.Identity.Name;
            }
            else
            {
                return context.Session.SessionID;
            }
        }        
    }
}