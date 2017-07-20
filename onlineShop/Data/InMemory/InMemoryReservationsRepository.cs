using onlineShop.Reservations;
using System;
using System.Collections.Generic;

namespace onlineShop.Data.InMemory
{
    public class InMemoryReservationsRepository
    {
        public Dictionary<Guid, Reservation> ReservationList; // reservationId

        public InMemoryReservationsRepository()
        {
            ReservationList = new Dictionary<Guid, Reservation>();
        }

        public void Add(Reservation reservation)
        {
            ReservationList.Add(reservation.Id, reservation);
        }

        public bool TryToRemove(Guid reservationID)
        {
            if (ReservationList.ContainsKey(reservationID)) // if we remove a key -> it removes whole entity from the dictionary
            {
                ReservationList.Remove(reservationID);
                return true;
            }
            return false;
        }
    }
}
