using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book()
        {
            ViewBag.Message = "Airline Reservation System";

            return View();
        }

        public ActionResult Plan()
        {
            ViewBag.Message = "Plan Your Trip";

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}