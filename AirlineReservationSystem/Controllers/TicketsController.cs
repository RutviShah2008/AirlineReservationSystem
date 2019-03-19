using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineReservationSystem.Models;

namespace AirlineReservationSystem.Controllers
{
    [Authorize ]
    public class TicketsController : Controller
    {
        private DbAirline db = new DbAirline();

        // GET: Tickets
        [AllowAnonymous]
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Flight).Include(t => t.Passenger);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.FlightType = new SelectList(db.Flights, "FlightID", "FlightSource");
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,TicketType,PassengerID,FlightType")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightType = new SelectList(db.Flights, "FlightID", "FlightSource", ticket.FlightType);
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerName", ticket.PassengerID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightType = new SelectList(db.Flights, "FlightID", "FlightSource", ticket.FlightType);
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerName", ticket.PassengerID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,TicketType,PassengerID,FlightType")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightType = new SelectList(db.Flights, "FlightID", "FlightSource", ticket.FlightType);
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerName", ticket.PassengerID);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
