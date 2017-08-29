using onlineShopWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineShopWeb.Utility
{
    public class Filter
    {
        public class SessionActivityRecorderAttribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var isLoggedIn = false;
                var sessionId = UserIdentifier.GetIdentifier(filterContext.HttpContext, out isLoggedIn);

                ProvidersFactory.GetSessionsProvider().UpdateOrAddSession(sessionId, isLoggedIn);
            }
        }
    }
}

