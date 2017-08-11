using onlineShop.Data;
using onlineShop.Data.Database;

namespace onlineShopWeb.DataAccess
{
    public static class ReadersFactory
    {
        public static IProductsReader GetProductsReader()
        {
            return new DBProductsProvider();
        }

        public static IStocksReader GetStocksReader()
        {
            return new DBStocksProvider();
        }

        public static IReservationsProvider GetReservationsReader()
        {
            return new DBReservationsProvider();
        }
    }
}