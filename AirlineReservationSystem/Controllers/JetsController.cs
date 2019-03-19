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
    [Authorize(Roles = "Administrator")]

    public class JetsController : Controller
    {
        private DbAirline db = new DbAirline();

        // GET: Jets
        public ActionResult Index()
        {
            return View(db.Jets.ToList());
        }

        // GET: Jets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jet jet = db.Jets.Find(id);
            if (jet == null)
            {
                return HttpNotFound();
            }
            return View(jet);
        }

        // GET: Jets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JetID,JetName,JetType")] Jet jet)
        {
            if (ModelState.IsValid)
            {
                db.Jets.Add(jet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jet);
        }

        // GET: Jets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jet jet = db.Jets.Find(id);
            if (jet == null)
            {
                return HttpNotFound();
            }
            return View(jet);
        }

        // POST: Jets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JetID,JetName,JetType")] Jet jet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jet);
        }

        // GET: Jets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jet jet = db.Jets.Find(id);
            if (jet == null)
            {
                return HttpNotFound();
            }
            return View(jet);
        }

        // POST: Jets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jet jet = db.Jets.Find(id);
            db.Jets.Remove(jet);
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
