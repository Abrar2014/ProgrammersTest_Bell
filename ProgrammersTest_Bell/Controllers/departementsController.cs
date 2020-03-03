using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgrammersTest_Bell.Models;

namespace ProgrammersTest_Bell.Controllers
{
    public class departementsController : Controller
    {
        private bellTestEntities db = new bellTestEntities();

        // GET: departements
        public ActionResult Index()
        {
            return View(db.departement.ToList());
        }

        // GET: departements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departement departement = db.departement.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // GET: departements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: departements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDepartement,nomDepartement")] departement departement)
        {
            if (ModelState.IsValid)
            {
                db.departement.Add(departement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departement);
        }

        // GET: departements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departement departement = db.departement.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // POST: departements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDepartement,nomDepartement")] departement departement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departement);
        }

        // GET: departements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departement departement = db.departement.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // POST: departements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            departement departement = db.departement.Find(id);
            db.departement.Remove(departement);
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
