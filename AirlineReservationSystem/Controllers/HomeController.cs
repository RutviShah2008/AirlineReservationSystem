﻿using System;
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Plan()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}