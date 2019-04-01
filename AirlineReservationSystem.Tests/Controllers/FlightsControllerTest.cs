
using System;
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
        List<Jet> jets;
        Mock<IMockFlights> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            flights = new List<Flight>
            {
                new Flight { FlightID = 5000, FlightDestination = "Fake Category One" , FlightSource="Fake Source",FlightJetID=3001},
                new Flight { FlightID = 5001, FlightDestination = "Fake Category One" , FlightSource="Fake Source",FlightJetID=3002},
                new Flight { FlightID = 5002, FlightDestination = "Fake Category One" , FlightSource="Fake Source",FlightJetID=3003}
            };

            // create some mock data
            jets = new List<Jet>
            {
                new Jet { JetID = 2001, JetName = "Fake Category One" , JetType="Fake Source"},
                new Jet { JetID = 2002, JetName = "Fake Category One" , JetType="Fake Source"},
                new Jet { JetID = 2003, JetName = "Fake Category One" , JetType="Fake Source"}

            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockFlights>();
            mock.Setup(f => f.Flights).Returns(flights.AsQueryable());
            mock.Setup(j => j.Jets).Returns(jets.AsQueryable());

            // initialize the controller and inject the mock object
            controller = new FlightsController();
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
            Assert.IsNotNull(result);
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
        public void FlightsCreateViewBag()
        {
            //Arrange 
            controller.ModelState.AddModelError("Description", "error");
            //Act
            SelectList result = (controller.Create(flights[0]) as ViewResult).ViewBag.FlightJetID;

            //Assert
            Assert.AreEqual(3001, result.SelectedValue);
        }

        [TestMethod]
        public void FlightsEditeLoad()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Edit(5000) as ViewResult;

            //Assert
            Assert.IsNotNull(viewresult);

        }
        [TestMethod]
        public void FlightsEditLoadViewName()
        {
            //Arrange
            //Act
            ViewResult viewresult = controller.Edit(5001) as ViewResult;

            //Assert
            Assert.AreEqual("Edit", viewresult.ViewName);
        }
        [TestMethod]
        public void FlightsEditLoadNullID()
        {
            //Arrange
            //Act
            HttpStatusCodeResult viewresult = controller.Edit((int?)null) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(400, viewresult.StatusCode);
        }
        [TestMethod]
        public void FlightsEditHttpNotFouond()
        {
            //Arrange

            //Act
            HttpNotFoundResult viewresult = controller.Edit(1001) as HttpNotFoundResult;

            //Assert
            Assert.AreEqual(404, viewresult.StatusCode);

        }

        [TestMethod]
        public void FlightsEditViewBag()
        {
            //Arrange 
            controller.ModelState.AddModelError("Description", "error");
            //Act
            SelectList result = (controller.Edit(flights[0]) as ViewResult).ViewBag.FlightJetID;


            //Assert
            Assert.AreEqual(3001, result.SelectedValue);
        }

        [TestMethod]
        public void FlightEditPostViewLoads()
        {
            //act
            RedirectToRouteResult viewresult = controller.Edit(flights[0]) as RedirectToRouteResult;
            //arrange
            Assert.IsNotNull(viewresult);
        }

        [TestMethod]
        public void FlightEditPostViewName()
        {
            //act
            RedirectToRouteResult viewresult = controller.Edit(flights[0]) as RedirectToRouteResult;
            //arrange
            Assert.AreEqual("Index", viewresult.RouteValues["action"]);
        }


        [TestMethod]
        public void FLightsEditPostInvalidModel()
        {
            controller.ModelState.AddModelError("Description", "Error");

            //act
            ViewResult viewresult = controller.Edit(flights[0]) as ViewResult;

            //Assert
            Assert.AreEqual("Edit", viewresult.ViewName);
        }

        [TestMethod]
        public void FlightEditPostViewBeg()
        {
            controller.ModelState.AddModelError("Description", "error");
            //Act
            SelectList viewresult = (controller.Edit(flights[0]) as ViewResult).ViewBag.FlightJetID;

            //Assert
            Assert.AreEqual(3001, viewresult.SelectedValue);
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
        public void FlightsDeleteConfirmed()
        {
            //var viewresult = ((ViewResult)controller.DeleteConfirmed(5001)).Model;

            var details = flights.SingleOrDefault(f => f.FlightID == 5001);

            //Assert
            Assert.IsNotNull(details);
        }

        [TestMethod]
        public void FlightsDeleteConfirmedValidRedirect()
        {
            RedirectToRouteResult details = controller.DeleteConfirmed(5001) as RedirectToRouteResult;

            var list = details.RouteValues.ToArray();
            //Assert
            Assert.AreEqual("Index", list[0].Value);
        }
    }
}
