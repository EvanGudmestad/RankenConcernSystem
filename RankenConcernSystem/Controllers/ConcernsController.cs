using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RankenConcernSystem.Models;
using System.Net.Mail;

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
                SendNotification(concerns, false);
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
                SendNotification(concerns, true);
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
        public void SendNotification(Concerns concern, bool exists)
        {
            if (exists == true)
            {
                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(concern.ConMakerEmail);
                mailMsg.To.Add("eagudmestad@ranken.edu");              
                mailMsg.Subject = "Updated Concern";
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                mailMsg.Body = "Date: " + concern.DateOfMake + " " + "<br />" + "Name of concern maker: " + concern.ConMakerName + " " + "<br />" + "Relationship: " + concern.GetRelationship + "<br />" + "Concern made via: " + concern.GetReportingMethod + " " + "<br />" + "Student ID: " + concern.StudentID + " " + "<br />" + "Phone: " + concern.ConMakerPhone + "<br />" + "Email adress: " + concern.ConMakerEmail + " " + "<br />" + "Reason of concern: " + concern.ReasonConMade + " " + "<br />" + "Reported to: " + concern.NameConRecieved + "<br />" + "Details: " + concern.Details + " " + "<br />" + "Action: " + concern.ActionMade + " " + "<br />" + "Action made by: " + concern.NameOfActionMaker + "<br />" + "Results: " + concern.ResultsOfCon + " " + "<br />" + "Result date: " + concern.DateOfResult;
                mailMsg.Priority = MailPriority.Normal;
                //Smtp configuration
                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new NetworkCredential("eagudmesad@ranken.edu", "Hash29Brown", "mail.ranken.edu");
                SmtpClient.Host = "mail.ranken.edu";
                SmtpClient.EnableSsl = false;
                SmtpClient.Send(mailMsg);
            }
            else
            {
                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(concern.ConMakerEmail);
                mailMsg.To.Add("eagudmestad@ranken.edu");
                mailMsg.Subject = "New Concern";
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                mailMsg.Body = "Date: " + concern.DateOfMake + " " + "<br />" + "Name of concern maker: " + concern.ConMakerName + " " + "<br />" + "Relationship: " + concern.GetRelationship + "<br />" + "Concern made via: " + concern.GetReportingMethod + " " + "<br />" + "Student ID: " + concern.StudentID + " " + "<br />" + "Phone: " + concern.ConMakerPhone + "<br />" + "Email adress: " + concern.ConMakerEmail + " " + "<br />" + "Reason of concern: " + concern.ReasonConMade + " " + "<br />" + "Reported to: " + concern.NameConRecieved + "<br />" + "Details: " + concern.Details + " " + "<br />" + "Action: " + concern.ActionMade + " " + "<br />" + "Action made by: " + concern.NameOfActionMaker + "<br />" + "Results: " + concern.ResultsOfCon + " " + "<br />" + "Result date: " + concern.DateOfResult;
                mailMsg.Priority = MailPriority.Normal;
                //Smtp configuration
                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new NetworkCredential("eagudmesad@ranken.edu", "Hash29Brown", "mail.ranken.edu");               
                SmtpClient.Host = "mail.ranken.edu";
                SmtpClient.EnableSsl = false;
                SmtpClient.Send(mailMsg);
            }
         
        }
     }
 }

