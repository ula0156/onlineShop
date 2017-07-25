using onlineShop.Data;
using onlineShop.Data.Entities;
using onlineShop.Managers;
using onlineShop.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace onlineShop
{
    public class Cart
    {
        // Cart is dictionary: key - productId, value - reservation.
        // If changes happened with a product -> they gonna be reflected on the product which is in the user cart.
        // That's why we have to give a cart access to the inventory.
        // One productID might have several reservations -> list of reservations.
        private Dictionary<Guid, List<Reservation>> _reservations; // Guid - productId
        private ReservationsManager _reservationsManager;
        private IProductsReader _productsReader;

        public Cart(IProductsReader productsReader, ReservationsManager reservationsManager)
        {
            _productsReader = productsReader;
            _reservationsManager = reservationsManager;
            _reservations = new Dictionary<Guid, List<Reservation>>();
        }

        // We expose a property of type ReadOnlyDictionary which wraps the internal Dictionary _items
        public ReadOnlyDictionary<Product, int> Products
        {
            get
            {
                var items = new Dictionary<Product, int>();
                foreach (var productReservations in _reservations)
                {
                    var product = _productsReader.GetProducts().First(p => p.Id == productReservations.Key);
                    items.Add(product, _reservations[product.Id].Count);
                }

                return new ReadOnlyDictionary<Product, int>(items);
            }
        }

        public bool TryAddProduct(Product product)
        {
            Reservation reservation;
            if (_reservationsManager.TryToReserveProduct(product, out reservation))
            {
                List<Reservation> listOfReservations;
                if (_reservations.TryGetValue(product.Id, out listOfReservations))
                {
                    listOfReservations.Add(reservation);
                    return true;
                }
                else
                {
                    listOfReservations = new List<Reservation>();
                    listOfReservations.Add(reservation);
                    _reservations[product.Id] = listOfReservations;
                    return true;
                }
            }

            return false;
        }

        public void RemoveProduct(Product product)
        {
            // - looking for an item with the earliest expiration time
            // - calling reservationmanager to remove it from the reservation and update inventory
            // - removing reservation from the cart;
            List<Reservation> reservationList = _reservations[product.Id]; // list of reservations for specific product
            // add this check in order to avoid decreasing to negative number of copies, while removing from specific product
            if (reservationList.Count > 0)
            {
                var reservationToCancel = reservationList[0];
                foreach (var reservation in reservationList)
                {
                    if (reservation.ExpirationTime < reservationToCancel.ExpirationTime)
                    {
                        reservationToCancel = reservation;
                    }
                }

                _reservationsManager.CancelReservation(reservationToCancel.Id);
                reservationList.Remove(reservationToCancel);
            }
        }

        public void UpdateCart()
        {
            // - check if items are still reserved : Y - set expiration time for extra 10 minutes
            //                                       N - try to reserve again : if failed  -> display an error

            // container for reservations which were already expired;
            Dictionary<Product, int> productsToReserve = new Dictionary<Product, int>(); // product, number of items of this product

            foreach (var item in _reservations)
            {
                var productToReserveAgain = _productsReader.GetProducts().First(p => p.Id == item.Key); // maybe there is no use of storing this information
                // iterate in reverse order so it is safe to remove while iterating
                for (var i = _reservations[productToReserveAgain.Id].Count; i >= 0; i--)
                {
                    if (_reservations[productToReserveAgain.Id][i].ExpirationTime > DateTime.Now) // how to check if reservation is still valid? 
                    {
                        // The reservation manager exposes method "TryExtendReservation(reservationId)"
                        _reservationsManager.TryReserveAgain(_reservations[productToReserveAgain.Id][i].Id);
                    }
                    else
                    {
                        // If reservation was expired 
                        // Save the product to reserve again
                        // Remember how many items of this product are needed to be reserved
                        if (!productsToReserve.ContainsKey(productToReserveAgain))
                        {
                            productsToReserve.Add(productToReserveAgain, 1);
                        }
                        else
                        {
                            productsToReserve[productToReserveAgain]++;
                        }
                    }
                }
                foreach (var product in productsToReserve)
                {
                    for (var j = 0; j < product.Value; j++)
                    {
                        Reservation reservation;
                        if(!_reservationsManager.TryToReserveProduct(product.Key, out reservation))
                        {
                            _reservations.Remove(product.Key.Id);
                        }
                    }
                }
            }

        }

        public void CompletePurchase()
        {
            // when user purchased products:
            //- call CompleteReservation on reservationManager to remove reservations from reservedInventory.
            //- remove reservation from the card
            foreach (var product in _reservations)
            {
                _reservationsManager.TryCompleteReservation(product.Key);
                _reservations.Remove(product.Key);
            }
        }

        public double TotalPrice()
        {
            double totalPrice = 0;
            foreach (var item in Products) 
            {
                totalPrice += item.Key.Price * item.Value;
            }

            return totalPrice;
        }

        public double TotalWeight()
        {
            double totalWeight = 0;
            foreach (var item in Products)
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
    }
}
