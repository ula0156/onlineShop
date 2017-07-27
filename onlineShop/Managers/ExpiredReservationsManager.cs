using onlineShop.Data;
using onlineShop.Data.Entities;
using onlineShop.Specials;
using System.Linq;

namespace onlineShop.Managers
{
    public class ExpiredReservationsManager
    {
        private IReservationsProvider _reservationsProvider;
        private ExpiredReservationsDetector _expiredReservationsDetector;

        public ExpiredReservationsManager(IReservationsProvider reservationsProvider, ExpiredReservationsDetector expiredReservationsDetector)
        {
            expiredReservationsDetector = new ExpiredReservationsDetector(
                reservationsProvider, 
                new ExpiredReservationsDetector.ExpirationReservationsHandler(UponExpiredReservations));
            _reservationsProvider = reservationsProvider;
        }

        public void UponExpiredReservations(IQueryable<Reservation> reservations)
        {
            foreach (var reservation in reservations)
            {
                _reservationsProvider.TryRemoveReservation(reservation.Id);
            }
        }
    }
}
