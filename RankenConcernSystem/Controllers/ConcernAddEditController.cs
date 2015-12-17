using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RankenConcernSystem.Controllers
{
    public class ConcernAddEditController : Controller
    {
        // GET: ConcernAddEdit
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConcernAddEdit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConcernAddEdit/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ConcernAddEdit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ConcernAddEdit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConcernAddEdit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ConcernAddEdit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConcernAddEdit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
