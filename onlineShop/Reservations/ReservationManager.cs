using OnlineShop.Data;
using OnlineShop.Products;
using System;

namespace OnlineShop.Reservations
{
    public class ReservationManager
    {
        private ProductsStocks _stocks;
        private ReservedInventory _reservedInventory;
        public ReservationManager(ProductsStocks stocks, ReservedInventory reservedInventory)
        {
            _stocks = stocks;
            _reservedInventory = reservedInventory;
        }

        public bool TryToReserveProduct(Product product, out Reservation reservation)
        {
            if (_stocks.Stocks[product.Id] > 0)
            {
                reservation = new Reservation(product);

                _stocks.Stocks[product.Id]--;
                _reservedInventory.ReservationList.Add(reservation.Id, reservation);

                return true;
            }

            reservation = null;
            return false;
        }

        public void CancelReservation(Guid reservationId)
        {
            // - remove reservation from the reservedInventory
            // - update inventory
            Guid productId = _reservedInventory.ReservationList[reservationId].ProductId; // get the product id in order to update inventory.
            _reservedInventory.ReservationList.Remove(reservationId);

            _stocks.Stocks[productId]++;
        }

        public bool TryCompleteReservation(Guid reservationId)
        {
            //- remove reservation from the reservedInventory
            return _reservedInventory.TryToRemove(reservationId);
        }
    }
}