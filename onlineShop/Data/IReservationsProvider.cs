using onlineShop.Reservations;
using System;
using System.Linq;

namespace onlineShop.Data
{
    public interface IReservationsProvider
    {
        bool TryAddReservation(Reservation reservation);

        bool TryRemoveReservation(Guid reservationId);

        bool TryRenewReservation(Guid reservationId, TimeSpan extraTime);

        IQueryable<Reservation> GetReservations();
    }
}
