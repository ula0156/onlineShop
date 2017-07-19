using OnlineShop.Reservations;
using System;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    public class ReservedInventory
    {
        public Dictionary<Guid, Reservation> ReservationList; // reservationId

        public ReservedInventory()
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
