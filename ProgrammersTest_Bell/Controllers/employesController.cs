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
    public class employesController : Controller
    {
        private bellTestEntities db = new bellTestEntities();

        // GET: employes
        public ActionResult Index()
        {
            var employe = db.employe.Include(e => e.departement);
            return View(employe.ToList());
        }

        // GET: employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employe.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: employes/Create
        public ActionResult Create()
        {
            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement");
            return View();
        }

        // POST: employes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmploye,idDepartement,nom")] employe employe)
        {
            if (ModelState.IsValid)
            {
                db.employe.Add(employe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement", employe.idDepartement);
            return View(employe);
        }

        // GET: employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employe.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement", employe.idDepartement);
            return View(employe);
        }

        // POST: employes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmploye,idDepartement,nom")] employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement", employe.idDepartement);
            return View(employe);
        }

        // GET: employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employe.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employe employe = db.employe.Find(id);
            db.employe.Remove(employe);
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
