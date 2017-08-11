using onlineShop;
using System.Collections.Generic;
using System.Collections.Concurrent;
using onlineShop.Managers;
using onlineShop.Data;

namespace onlineShop.Data.InMemory
{
    public class InMemoryCartProvider : ICartProvider
    {
        private ConcurrentDictionary<string, Cart> _carts;
        private IProductsProvider _productsProvider;
        private IReservationsProvider _reservationsProvider;
        private IStocksProvider _stocksProvider;

        public InMemoryCartProvider(
            IProductsProvider productsProvider, 
            IReservationsProvider reservationsProvider, 
            IStocksProvider stocksProvider)
        {
            _carts = new ConcurrentDictionary<string, Cart>();
            _productsProvider = productsProvider;
            _reservationsProvider = reservationsProvider;
            _stocksProvider = stocksProvider;
        }

        public Cart GetCart(string userIdentifier)
        {
            if (_carts.ContainsKey(userIdentifier))
            {
                return _carts[userIdentifier];
            }

            var cart = CreateNewCart();
            if (!_carts.TryAdd(userIdentifier, cart))
            {
                return _carts[userIdentifier];
            }

            return cart;
        }

        public void CleanUpCart(List<string> listOfSessionAndLoginIds)
        {
            foreach (string sessionOrLoginId in listOfSessionAndLoginIds)
            {
                // didn't understand how to remove from this dictionary
            }
        }

        private Cart CreateNewCart()
        {
            return new Cart(
                _productsProvider,
                new ReservationsManager(
                    _stocksProvider,
                    _reservationsProvider));
        }
    }
}