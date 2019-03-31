using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Models
{
    public class IDataFlights : IMockFlights
    {
        private DbAirline db = new DbAirline();

        public IQueryable<Flight> Flights { get { return db.Flights; } }

        public void Delete(Flight flight)
        {
            db.Flights.Remove(flight);
            db.SaveChanges();
        }

        public Flight Save(Flight flight)
        {
            if (flight.FlightID == 0)
            {
                db.Flights.Add(flight);
            }
            else
            {
                db.Entry(flight).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return flight;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}