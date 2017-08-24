using onlineShop.Data;
using onlineShop.Data.Entities;
using onlineShop.Specials;
using System.Collections.Generic;
using System.Linq;

namespace onlineShop.core.Managers
{
    public class ExpiredReservationsManager
    {
        private IReservationsProvider _reservationsProvider;
        private ExpiredReservationsDetector expiredReservationsDetector;

        public ExpiredReservationsManager(IReservationsProvider reservationsProvider)
        {
            expiredReservationsDetector = new ExpiredReservationsDetector(
                reservationsProvider, 
                new ExpiredReservationsDetector.ExpirationReservationsHandler(UponExpiredReservations));
            _reservationsProvider = reservationsProvider;
        }

        public void UponExpiredReservations(List<Reservation> reservations)
        {
            foreach (var reservation in reservations)
            {
                _reservationsProvider.TryRemoveReservation(reservation.Id);
            }
        }
    }
}
