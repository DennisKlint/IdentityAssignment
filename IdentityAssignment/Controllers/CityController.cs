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
    public class CityController : Controller
    {
        private IdentityDbModels db = new IdentityDbModels();

        // GET: City
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.Country);
            return View(cities.ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModels cityModels = db.Cities.Find(id);
            if (cityModels == null)
            {
                return HttpNotFound();
            }
            return View(cityModels);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            ViewBag.CountryModelsID = new SelectList(db.Countries, "ID", "CountryName");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountryModelsID,CityName")] CityModels cityModels)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(cityModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryModelsID = new SelectList(db.Countries, "ID", "CountryName", cityModels.CountryModelsID);
            return View(cityModels);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModels cityModels = db.Cities.Find(id);
            if (cityModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryModelsID = new SelectList(db.Countries, "ID", "CountryName", cityModels.CountryModelsID);
            return View(cityModels);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryModelsID,CityName")] CityModels cityModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryModelsID = new SelectList(db.Countries, "ID", "CountryName", cityModels.CountryModelsID);
            return View(cityModels);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModels cityModels = db.Cities.Find(id);
            if (cityModels == null)
            {
                return HttpNotFound();
            }
            return View(cityModels);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityModels cityModels = db.Cities.Find(id);
            db.Cities.Remove(cityModels);
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
