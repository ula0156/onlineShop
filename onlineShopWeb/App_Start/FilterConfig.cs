using System.Web;
using System.Web.Mvc;
using static onlineShopWeb.Utility.Filter;

namespace onlineShopWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SessionActivityRecorderAttribute());
        }
    }
}


