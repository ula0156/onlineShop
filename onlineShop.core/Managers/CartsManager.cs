using onlineShop.core.Entities;
using onlineShop.Data;
using onlineShop.Data.Entities;
using onlineShop.Managers;
using onlineShop.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace onlineShop.core.Managers
{
    public class CartsManager
    {
        private IReservationsProvider _reservationsProvider;
        private IProductsProvider _productsProvider;
        private IStocksProvider _stocksProvider;
        private ReservationsManager _reservationsManager;
        private ICartsProvider _cartsProvider;

        public CartsManager(IStocksProvider stocksProvider, IProductsProvider productsProvider, IReservationsProvider reservationsProvider, ICartsProvider cartProvider)
        {
            _stocksProvider = stocksProvider;
            _productsProvider = productsProvider;
            _reservationsProvider = reservationsProvider;
            _reservationsManager = new ReservationsManager(_stocksProvider, _reservationsProvider);
            _cartsProvider = cartProvider;
        }

        public Cart GetCartBySessionId(string sessionId)
        {
            // look for cart in CartDb
            var cart = _cartsProvider.GetCartForSession(sessionId);

            return cart;
        }

        public bool TryAddProduct(Product product, string sessionId)
        {
            Reservation reservation;
            if (_reservationsManager.TryToReserveProduct(product, sessionId, out reservation))
            {
                var cart = _cartsProvider.GetCartForSession(sessionId);
                cart.Products.Add(product.Id);
                _cartsProvider.SaveCart(cart);

                return true;
            }

            return false;
        }

        //when user wants to remove product from the cart:
        // - calling reservationmanager to remove product from the reservationDb and update inventory
        // - removing product from the cartDB;

        public void RemoveProduct(Product product, string sessionId)
        {
            var listOdReservations = _reservationsProvider.GetReservations().Where(sId => sId.SessionId == sessionId).ToList();
            foreach (var reservation in listOdReservations)
            {
                if (reservation.ProductId == product.Id)
                {
                    _reservationsManager.CancelReservation(reservation.Id);
                    break;
                }
            }

            var cart = _cartsProvider.GetCartForSession(sessionId);
            cart.Products.Remove(product.Id);
            _cartsProvider.SaveCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            // - check if items are still reserved : Y - set expiration time for extra minutes
                                                 //  N - try to reserve again
            /**
             * Get all reservations for this sessionId existing in reservationDB
             * go over them and try to renew (through the reservationManager)
             * update cart
             * 
            */
            var listOfReservations = (List<Reservation>)_reservationsProvider.GetReservations().Where(sId => sId.SessionId == cart.SessionId);

            Dictionary<Guid, Guid> dictionaryOfReservedProducts = new Dictionary<Guid, Guid>(); // productId and reservationId
            foreach (var reservation in listOfReservations)
            {
                dictionaryOfReservedProducts.Add(reservation.ProductId, reservation.Id);
                foreach (var item in cart.Products)
                {
                    if (dictionaryOfReservedProducts.ContainsKey(item))
                    {
                        _reservationsManager.TryRenewReservation(dictionaryOfReservedProducts[item]);
                        dictionaryOfReservedProducts.Remove(item);
                    }
                    else
                    {
                        Reservation newReservation;
                        var product = _productsProvider.GetProducts().First(id => id.Id == item);
                        _reservationsManager.TryToReserveProduct(product, cart.SessionId, out newReservation);
                    }
                    break;
                }
            }
            // updating cart at the end
            listOfReservations = (List<Reservation>)_reservationsProvider.GetReservations().Where(sId => sId.SessionId == cart.SessionId);
            cart.Products = new List<Guid>();
            foreach (var reservation in listOfReservations)
            {
                cart.Products.Add(reservation.ProductId);
            }

            _cartsProvider.SaveCart(cart);
        }

        public Dictionary<Product, int> ConvertCartToDictionary(Cart cart)
        {
            Dictionary<Product, int> cartToDisplay = new Dictionary<Product, int>();

            foreach (var item in cart.Products)
            {
                var product = _productsProvider.GetProducts().First(id => id.Id == item);
                if (!cartToDisplay.ContainsKey(product))
                {
                    cartToDisplay.Add(product, 1);
                }
                else
                {
                    cartToDisplay[product]++;
                }
            }

            return cartToDisplay;
        }

        public double GetTotalPrice(Dictionary<Product, int> products)
        {
            double totalPrice = 0;
            foreach (var item in products)
            {
                totalPrice += item.Key.Price * item.Value;
            }

            return totalPrice;
        }

        public double GetTotalWeight(Dictionary<Product, int> products)
        {
            double totalWeight = 0;
            foreach (var item in products)
            {
                if (item.Key is PhysicalProduct)
                {
                    PhysicalProduct physicalItem = item.Key as PhysicalProduct;
                    totalWeight += physicalItem.Size.Weight * item.Value;
                    return totalWeight;
                }
            }

            return 0;
        }

        //public void CompletePurchase(Cart cart)
        //{
        //    // when user purchased products:
        //    //- call CompleteReservation on reservationManager to remove reservations from reservedInventory.
        //    //- remove reservation from the card
        //    foreach (var product in _reservations)
        //    {
        //        _reservationsManager.TryCompleteReservation(product.Key);
        //        _reservations.Remove(product.Key);
        //    }
        //}



    }
}
