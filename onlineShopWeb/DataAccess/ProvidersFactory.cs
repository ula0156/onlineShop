using onlineShop.Data;
using onlineShop.Data.Database;
using onlineShop.Data.InMemory;

namespace onlineShopWeb.DataAccess
{
    public static class ProvidersFactory
    {
        private static ICartProvider _cartProvider = new InMemoryCartProvider(
            GetProductsProvider(), 
            GetReservationsProvider(), 
            GetStocksProvider());

        public static ICartProvider GetCartProvider()
        {
            return _cartProvider;
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