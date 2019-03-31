using System;
using System.Collections.Generic;
using System.Linq;
using AirlineReservationSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AirlineReservationSystem.Tests.Controllers
{
    [TestClass]
    public class FlightsControllerTest
    {
        // moq data
        FlightsController controller;
        List<Flight> flights;
        Mock<IMockFlights> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            flights = new List<Flight>
            {
                new Flight { FlightID = 500, FlightDestination = "Fake Category One" , FlightSource="Fake Source"},
                new Flight { FlightID = 501, FlightDestination = "Fake Category One" , FlightSource="Fake Source"},
                new Flight { FlightID = 502, FlightDestination = "Fake Category One" , FlightSource="Fake Source"}
            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockFlights>();
            mock.Setup(f => f.Flights).Returns(flights.AsQueryable());

            // initialize the controller and inject the mock object
            controller = new FlightsController(mock.Object);
        }


    }
}
