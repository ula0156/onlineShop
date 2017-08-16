using onlineShop.core.Data;
using onlineShop.core.Data.InMemory;
using onlineShop.Data;
using onlineShop.Data.Database;
using onlineShop.Data.InMemory;

namespace onlineShopWeb.DataAccess
{
    public static class ProvidersFactory
    {
        private static ICartProvider _cartProvider = new CartProvider(
            GetProductsProvider(), 
            GetReservationsProvider(), 
            GetStocksProvider());

        private static ISessionsProvider _sessionsProvider = new InMemorySessionsProvider();

        public static ISessionsProvider GetSessionstProvider()
        {
            return _sessionsProvider;
        }

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