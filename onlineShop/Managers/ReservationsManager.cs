using onlineShop.Data;
using onlineShop.Data.Entities;
using onlineShop.Products;
using System;
using System.Linq;

namespace onlineShop.Managers
{
    public class ReservationsManager
    {
        private IStocksProvider _stocksProvider;
        private IReservationsProvider _reservationsProvider;

        public ReservationsManager(IStocksProvider stocksProvider, IReservationsProvider reservationsProvider)
        {
            _stocksProvider = stocksProvider;
            _reservationsProvider = reservationsProvider;
        }

        public bool TryToReserveProduct(Product product, out Reservation reservation)
        {
            if (_stocksProvider.TryDecreaseStock(product.Id, 1))
            {
                reservation = new Reservation(product);
                if (!_reservationsProvider.TryAddReservation(reservation))
                {
                    // in case attempt to add reservation to the reservedInventory failed -> increase stock
                    _stocksProvider.TryIncreaseStock(product.Id, 1);
                    return false;
                }

                return true;
            }

            reservation = null;
            return false;
        }

        public bool TryReserveAgain(Guid reservationId)
        {
            if (_reservationsProvider.TryRenewReservation(reservationId, TimeSpan.FromMinutes(10)))
            {
                return true;
            }
            return false;
        }

        public void CancelReservation(Guid reservationId)
        {
            // - remove reservation from the reservedInventory
            // - update inventory
            var reservation = _reservationsProvider.GetReservations().FirstOrDefault(r => r.Id == reservationId);
            if (reservation != null)
            {
                _reservationsProvider.TryRemoveReservation(reservationId); // get the product id in order to update inventory.
                _stocksProvider.TryIncreaseStock(reservation.ProductId, 1);
            }
        }

        public bool TryCompleteReservation(Guid reservationId)
        {
            //- remove reservation from the reservedInventory
            return _reservationsProvider.TryRemoveReservation(reservationId);
        }
        
    }
}