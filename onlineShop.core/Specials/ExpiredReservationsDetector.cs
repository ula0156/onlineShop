﻿using onlineShop.Data;
using onlineShop.Data.Entities;
using System;
using System.Linq;
using System.Timers;

namespace onlineShop.Specials
{
    public class ExpiredReservationsDetector
    {
        public  delegate void ExpirationReservationsHandler(IQueryable<Reservation> reservations);

        private ExpirationReservationsHandler _expirationReservationsHandler;
        private IReservationsProvider _reservationsProvider;

        public ExpiredReservationsDetector(IReservationsProvider reservationsProvider, ExpirationReservationsHandler expirationReservationsHandler)
        {
            _reservationsProvider = reservationsProvider;
            _expirationReservationsHandler = expirationReservationsHandler;
            StartTimer();
        }

        private void StartTimer()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(GetExpiredReservations);

            aTimer.Interval = 600000;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void GetExpiredReservations(object sender, ElapsedEventArgs e)
        {
            var listOfReservations = _reservationsProvider.GetReservations().Where(ext => ext.ExpirationTime <= DateTime.Now);
            _expirationReservationsHandler(listOfReservations);
        }
    }
}
