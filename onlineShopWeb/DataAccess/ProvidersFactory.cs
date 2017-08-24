using System;
using onlineShop.core.Data;
using onlineShop.Data;
using onlineShop.Data.Database;
using onlineShop.core.Data.Database;

namespace onlineShopWeb.DataAccess
{
    public static class ProvidersFactory
    {
        public static ISessionsProvider GetSessionsProvider()
        {
            return new DBSessionsProvider();
        }

        public static ICartsProvider GetCartsProvider()
        {
            return new DBCartsProvider();
        }

        public static IProductsProvider GetProductsProvider()
        {
            return new DBProductsProvider();
        }

        public static IStocksProvider GetStocksProvider()
        {
            return new DBStocksProvider();
        }

        public static IReservationsProvider GetReservationsProvider()
        {
            return new DBReservationsProvider();
        }
    }
}