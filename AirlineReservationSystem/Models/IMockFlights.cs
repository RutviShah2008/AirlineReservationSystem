using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Models
{
    public interface IMockFlights
    {
        IQueryable<Flight> Flights { get; }
        Flight Save(Flight category);
        void Delete(Flight category);
        void Dispose();
    }
}
