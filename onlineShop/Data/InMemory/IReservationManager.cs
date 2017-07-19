using OnlineShop.Reservations;
using System;
using System.Linq;

namespace onlineShop.Data.InMemory
{
    public interface IReservationManager
    {
        bool TryAddReservation(Reservation reservation);

        bool TryRemoveReservation(Guid reservationId);

        bool TryRenewReservation(Guid reservationId, TimeSpan extraTime);

        IQueryable<Reservation> GetReservations();
    }
}
