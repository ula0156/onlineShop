using onlineShop.Managers;
using onlineShopWeb.DataAccess;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace onlineShopWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["init"] = 0;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StartMonitors();
        }

        private void StartMonitors()
        {
            ReservationsManager _reservationsManager = new ReservationsManager(ProvidersFactory.GetStocksProvider(), ProvidersFactory.GetReservationsProvider());
            ExpiredReservationsManager _expiredReservationsManager = new ExpiredReservationsManager(ProvidersFactory.GetReservationsProvider());
        }
    }
}
