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
    [Authorize]
    public class PersonController : Controller
    {
        private IdentityDbModels db = new IdentityDbModels();

        // GET: Person
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.Cities);
            return View(people.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModels personModels = db.People.Find(id);
            if (personModels == null)
            {
                return HttpNotFound();
            }
            return View(personModels);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.CityModelsID = new SelectList(db.Cities, "ID", "CityName");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CityModelsID,Name")] PersonModels personModels)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(personModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityModelsID = new SelectList(db.Cities, "ID", "CityName", personModels.CityModelsID);
            return View(personModels);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModels personModels = db.People.Find(id);
            if (personModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityModelsID = new SelectList(db.Cities, "ID", "CityName", personModels.CityModelsID);
            return View(personModels);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CityModelsID,Name")] PersonModels personModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityModelsID = new SelectList(db.Cities, "ID", "CityName", personModels.CityModelsID);
            return View(personModels);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModels personModels = db.People.Find(id);
            if (personModels == null)
            {
                return HttpNotFound();
            }
            return View(personModels);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonModels personModels = db.People.Find(id);
            db.People.Remove(personModels);
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
