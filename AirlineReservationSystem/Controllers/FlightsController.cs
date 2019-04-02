
using System.Data.Entity;
using System.Linq;
using System.Net;

using System.Web.Mvc;

namespace AirlineReservationSystem.Models
{
    [Authorize]
    public class FlightsController : Controller
    {
        //private DbAirline db = new DbAirline();
        IMockFlights db;

        public FlightsController()
        {
            this.db = new IDataFlights();
        }

        public FlightsController(IMockFlights mockDb)
        {
            this.db = mockDb;
        }

        [AllowAnonymous]
        // GET: Flights
        public ActionResult Index()
        {
            ViewBag.Message = "Flights For Reservation";
            var flights = db.Flights.Include(f => f.Jet);
            return View("Index",flights.ToList());
        }

        // GET: Flights/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Flight flight = db.Flights.Find(id);
            Flight flight = db.Flights.SingleOrDefault(f => f.FlightID == id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            
            return View("Details",flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Book Your Flights";
            ViewBag.FlightJetID = new SelectList(db.Jets, "JetID", "JetName");
            return View("Create");
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightID,FlightDate,FlightJetID,FlightSource,FlightDestination,FlightTime")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                //db.Flights.Add(flight);
                //db.SaveChanges();
                db.Save(flight);
                return RedirectToAction("Index");
            }

            ViewBag.FlightJetID = new SelectList(db.Jets, "JetID", "JetName", flight.FlightJetID);
            return View("Create",flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Flight flight = db.Flights.Find(id);
            Flight flight = db.Flights.SingleOrDefault(f => f.FlightID == id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightJetID = new SelectList(db.Jets, "JetID", "JetName", flight.FlightJetID);
            return View("Edit",flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightID,FlightDate,FlightJetID,FlightSource,FlightDestination,FlightTime")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(flight).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(flight);
                return RedirectToAction("Index");
            }
            ViewBag.FlightJetID = new SelectList(db.Jets, "JetID", "JetName", flight.FlightJetID);
            return View("Edit",flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.SingleOrDefault(f => f.FlightID == id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View("Delete",flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.SingleOrDefault(f => f.FlightID == id);
            //db.Flights.Remove(flight);
            //db.SaveChanges();
            db.Delete(flight);
            db.Save(flight);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
