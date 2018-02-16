using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityAssignment.Models;

namespace IdentityAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private IdentityDbModels db = new IdentityDbModels();

        // GET: Country
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModels countryModels = db.Countries.Find(id);
            if (countryModels == null)
            {
                return HttpNotFound();
            }
            return View(countryModels);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountryName")] CountryModels countryModels)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(countryModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryModels);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModels countryModels = db.Countries.Find(id);
            if (countryModels == null)
            {
                return HttpNotFound();
            }
            return View(countryModels);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryName")] CountryModels countryModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryModels);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModels countryModels = db.Countries.Find(id);
            if (countryModels == null)
            {
                return HttpNotFound();
            }
            return View(countryModels);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryModels countryModels = db.Countries.Find(id);
            db.Countries.Remove(countryModels);
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
