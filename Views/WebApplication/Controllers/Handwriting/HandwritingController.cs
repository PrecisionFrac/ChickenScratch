using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.Handwriting
{
    public class HandwritingController : Controller
    {
        // GET: Handwriting
        public ActionResult Index()
        {
            return View();
        }

        // GET: Handwriting/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Handwriting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Handwriting/Create
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

        // GET: Handwriting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Handwriting/Edit/5
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

        // GET: Handwriting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Handwriting/Delete/5
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
