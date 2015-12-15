using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RankenConcernSystem.Models;

namespace RankenConcernSystem.Controllers
{
    public class ConcernsController : Controller
    {
        private RankenConcernSystemContext db = new RankenConcernSystemContext();

        // GET: Concerns
        public ActionResult Index()
        {
            return View(db.Concerns.ToList());
        }

        // GET: Concerns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concerns concerns = db.Concerns.Find(id);
            if (concerns == null)
            {
                return HttpNotFound();
            }
            return View(concerns);
        }

        // GET: Concerns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Concerns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateOfMake,ConMakerName,GetRelationship,GetReportingMethod,StudentID,ConMakerPhone,ConMakerEmail,ReasonConMade,NameConRecieved,Details,ActionMade,NameOfActionMaker,ResultsOfCon,DateOfResult")] Concerns concerns)
        {
            if (ModelState.IsValid)
            {
                db.Concerns.Add(concerns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(concerns);
        }

        // GET: Concerns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concerns concerns = db.Concerns.Find(id);
            if (concerns == null)
            {
                return HttpNotFound();
            }
            return View(concerns);
        }

        // POST: Concerns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DateOfMake,ConMakerName,GetRelationship,GetReportingMethod,StudentID,ConMakerPhone,ConMakerEmail,ReasonConMade,NameConRecieved,Details,ActionMade,NameOfActionMaker,ResultsOfCon,DateOfResult")] Concerns concerns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concerns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(concerns);
        }

        // GET: Concerns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concerns concerns = db.Concerns.Find(id);
            if (concerns == null)
            {
                return HttpNotFound();
            }
            return View(concerns);
        }

        // POST: Concerns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Concerns concerns = db.Concerns.Find(id);
            db.Concerns.Remove(concerns);
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
