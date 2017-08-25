using onlineShop;
using System.Collections.Generic;
using System.Collections.Concurrent;
using onlineShop.Managers;
using onlineShop.Data;
using System;

namespace onlineShop.Data.InMemory
{
    //public class InMemoryCartProvider : ICartProvider
    //{
    //    private ConcurrentDictionary<string, Cart> _carts;
    //    private IProductsProvider _productsProvider;
    //    private IReservationsProvider _reservationsProvider;
    //    private IStocksProvider _stocksProvider;

    //    public InMemoryCartProvider(
    //        IProductsProvider productsProvider, 
    //        IReservationsProvider reservationsProvider, 
    //        IStocksProvider stocksProvider)
    //    {
    //        _carts = new ConcurrentDictionary<string, Cart>();
    //        _productsProvider = productsProvider;
    //        _reservationsProvider = reservationsProvider;
    //        _stocksProvider = stocksProvider;
    //    }

    //    public Cart GetCart(string userIdentifier)
    //    {
    //        if (_carts.ContainsKey(userIdentifier))
    //        {
    //            return _carts[userIdentifier];
    //        }

    //        var cart = CreateNewCart();
    //        if (!_carts.TryAdd(userIdentifier, cart))
    //        {
    //            return _carts[userIdentifier];
    //        }

    //        return cart;
    //    }

    //    internal object GetCart()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void CleanUpCart(List<string> listOfSessionAndLoginIds)
    //    {
    //        foreach (string userIdentifier in listOfSessionAndLoginIds)
    //        {
    //            Cart cart;
    //            _carts.TryRemove(userIdentifier, out cart);
    //        }
    //    }

    //    public Cart CreateNewCart()
    //    {
    //        return new Cart(
    //            _productsProvider,
    //            new ReservationsManager(
    //                _stocksProvider,
    //                _reservationsProvider));
    //    }
    //}
}