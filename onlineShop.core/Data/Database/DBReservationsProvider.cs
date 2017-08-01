using System;
using System.Linq;
using onlineShop.Data.Entities;

namespace onlineShop.Data.Database
{
    public class DBReservationsProvider : IReservationsProvider
    {
        private ReservationsModel _reservationsModel;

        public DBReservationsProvider()
        {
            _reservationsModel = new ReservationsModel();
        }

        public IQueryable<Reservation> GetReservations()
        {
            return _reservationsModel.Reservations;
        }

        public bool TryAddReservation(Reservation reservation)
        {
            if (_reservationsModel.Reservations.Any(r => r.Id == reservation.Id))
            {
                return false;
            }
            _reservationsModel.Reservations.Add(reservation);
            _reservationsModel.SaveChanges();
            return true;
        }

        public bool TryRemoveReservation(Guid reservationId)
        {
            var reservation = _reservationsModel.Reservations.FirstOrDefault(r => r.Id == reservationId);
            if (reservation == null)
            {
                return false;
            }
            _reservationsModel.Reservations.Remove(reservation);
            _reservationsModel.SaveChanges();
            return true;
        }

        public bool TryRenewReservation(Guid reservationId, TimeSpan extraTime)
        {
            var reservation = _reservationsModel.Reservations.FirstOrDefault(r => r.Id == reservationId);
            if (reservation == null)
            {
                reservation.ExpirationTime = DateTime.Now + extraTime;
                _reservationsModel.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
