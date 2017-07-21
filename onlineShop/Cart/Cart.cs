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
                    items.Add(product, _reservations.Values.Count);
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
                }
                else
                {
                    listOfReservations = new List<Reservation>();
                    listOfReservations.Add(reservation);
                    _reservations[product.Id] = listOfReservations;
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

        public void UpdateCart()
        {
            // - check if items are still reserved : Y - set expiration time for extra 10 minutes
            //                                       N - try to reserve again : if failed  -> display an error
            //ReservationManager.CompletePurchase(_products);
            foreach (var item in _reservations)
            {
                var productToReserveAgain = _productsReader.GetProducts().First(p => p.Id == item.Key); // maybe there is no use of storing this information

                // TODO - iterate in reverse order so it is safe to remove while iterating
                foreach (var reservation in item.Value)
                {
                    if (reservation.ExpirationTime > DateTime.Now) // how to check if reservation is still valid? 
                    {
                        // TODO The reservation manager should expose a method named "TryExtendReservation(reservationId)"
                        reservation.ExpirationTime.Add(TimeSpan.FromMinutes(10)); //?????
                    }
                    else
                    {
                        // Save the product to reserve again
                        // TODO Try to remember how many items of this product you need to reserve and add them after the foreach
                        TryAddProduct(productToReserveAgain);

                        // Remove invalid reservation from the cart
                        item.Value.Remove(reservation);
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
