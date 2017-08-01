using System;
using System.Linq;
using onlineShop.Data.InMemory;
using onlineShop.Data.Entities;

namespace onlineShop.Data.InMemory
{
    public class InMemoryReservationProvider: IReservationsProvider
    {
        private InMemoryReservationsRepository _reservedInventory;

        public InMemoryReservationProvider(InMemoryReservationsRepository reservedInventory)
        {
            _reservedInventory = reservedInventory;
        }

        public IQueryable<Reservation> GetReservations()
        {
            return _reservedInventory.ReservationList.Values.AsQueryable();
        }

        public bool TryAddReservation(Reservation reservation)
        {
            if (!_reservedInventory.ReservationList.ContainsKey(reservation.Id))
            {
                _reservedInventory.ReservationList.Add(reservation.Id, reservation);
                return true;
            }

            return false;
        }

        public bool TryRemoveReservation(Guid reservationId)
        {
            if (_reservedInventory.ReservationList.ContainsKey(reservationId))
            {
                _reservedInventory.ReservationList.Remove(reservationId);
                return true;
            }

            return false;
        }

        public bool TryRenewReservation(Guid reservationId, TimeSpan time)
        {
            Reservation reservation;
            if (_reservedInventory.ReservationList.TryGetValue(reservationId, out reservation))
            {
                reservation.ExpirationTime = DateTime.Now + time;
                return true;
            }

            return false;
        }
    }
}
