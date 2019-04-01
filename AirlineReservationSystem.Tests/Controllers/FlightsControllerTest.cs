
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
                new Flight { FlightID = 5000, FlightDestination = "Fake Category One" , FlightSource="Fake Source"},
                new Flight { FlightID = 5001, FlightDestination = "Fake Category One" , FlightSource="Fake Source"},
                new Flight { FlightID = 5002, FlightDestination = "Fake Category One" , FlightSource="Fake Source"}
            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockFlights>();
            mock.Setup(f => f.Flights).Returns(flights.AsQueryable());

            // initialize the controller and inject the mock object
            controller = new FlightsController(mock.Object);
        }

        [TestMethod]
        public void FlightsViewLoad()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(viewresult);
            

        }
        [TestMethod]
        public void FlightsViewLoadViewName()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", viewresult.ViewName);

        }

        [TestMethod]
        public void FlightsViewLoadViewBagMessage()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Flights For Reservation", viewresult.ViewBag.Message);

        }
        [TestMethod]
        public void FlightsLoadList()
        {
            //Arrange

            //Act
            var results = (List<Flight>)((ViewResult)controller.Index()).Model;

            //Assert
            CollectionAssert.AreEqual(flights.ToList(), results);
        }
        [TestMethod]
        public void FlightsDetailsLoad()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Details(5000) as ViewResult;

            //Assert
            Assert.IsNotNull(viewresult);

        }
        [TestMethod]
        public void FlightsDetailsLoadfViewName()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Details(5001) as ViewResult;

            //Assert
            Assert.AreEqual("Details", viewresult.ViewName);
        }
        [TestMethod]
        public void FlightsDetailsLoadNullID()
        {
            //Arrange
            //Act
            HttpStatusCodeResult viewresult = controller.Details(null) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(400, viewresult.StatusCode);
        }
        [TestMethod]
        public void FlightsDetailsHttpNotFound()
        {
            //Arrange

            //Act
            HttpNotFoundResult viewresult = controller.Details(1001) as HttpNotFoundResult;

            //Assert
            Assert.AreEqual(404, viewresult.StatusCode);
            
        }

        [TestMethod]
        public void FlightsDetailsList()
        {
            //Arrange

            //Act
            var viewresult = ((ViewResult)controller.Details(5001)).Model;
            var details = flights.SingleOrDefault(f => f.FlightID == 5001);

            //Assert
            Assert.AreEqual(details, viewresult);
        }
        
        [TestMethod]
        public void FlightsDeleteLoad()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Delete(5000) as ViewResult;

            //Assert
            Assert.IsNotNull(viewresult);

        }
        [TestMethod]
        public void FlightsDeleteLoadViewName()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Delete(5001) as ViewResult;

            //Assert
            Assert.AreEqual("Delete", viewresult.ViewName);
        }
        [TestMethod]
        public void FlightsDeleteLoadNullID()
        {
            //Arrange
            //Act
            HttpStatusCodeResult viewresult = controller.Delete(null) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(400, viewresult.StatusCode);
        }
        [TestMethod]
        public void FlightsDeleteHttpNotFouond()
        {
            //Arrange

            //Act
            HttpNotFoundResult viewresult = controller.Delete(1001) as HttpNotFoundResult;

            //Assert
            Assert.AreEqual(404, viewresult.StatusCode);

        }
        [TestMethod]
        public void FlightsDeleteLoadList()
        {
            //Arrange

            //Act
            var viewresult = ((ViewResult)controller.Delete(5001)).Model;
            var details = flights.SingleOrDefault(f => f.FlightID == 5001);

            //Assert
            Assert.AreEqual(details, viewresult);
        }
        [TestMethod]
        public void FlightsCreateLoad()
        {
            //Act
            var result = controller.Create() as ViewResult;

            //Assert
            Assert.AreEqual("Create", result.ViewName);

        }
        [TestMethod]
        public void FlightsCreateLoadType()
        {
            //Act
            var result = controller.Create();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }
        [TestMethod]
        public void FlightsCreateViewBagMessag()
        {
            //Act
            var result = controller.Create() as ViewResult;

            //Assert
            Assert.AreEqual("Book Your Flights", result.ViewBag.Message);
        }
        [TestMethod]
        public void FlightsCreateNullResult()
        {
            //Act
            var result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull( result);
        }
        [TestMethod]
        public void FlightsCreateActionResult()
        {
            //Arrange 
            Flight flights = new Flight { FlightID = 1001, FlightDestination = "Fake", FlightSource = "Fake", FlightTime = "fake" };
            //Act
            var result = controller.Create(flights) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void FlightsCreateActionResultNotNull()
        {
            //Arrange 
            Flight flights = new Flight { FlightID = 1001, FlightDestination = "Fake", FlightSource = "Fake", FlightTime = "fake" };
            //Act
            var result = controller.Create(flights) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void FlightsCreate()
        {
            //Arrange 
            Flight flights = new Flight { FlightID = 1001, FlightDestination = "Fake", FlightSource = "Fake", FlightTime = "fake" };
            //Act
            var result = controller.Create(flights) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
