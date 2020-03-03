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
    public class billetsController : Controller
    {
        private bellTestEntities db = new bellTestEntities();

        // GET: billets
        //index Francais
        public ActionResult Index(String nomProjet, String nomDptm, String nomEmp, String descrBillet)
        {
            List<departement> departementList = db.departement.ToList();

            ViewBag.departementList = new SelectList(departementList, "idDepartement", "nomDepartement");
            var billet = db.billet.Include(b => b.departement).Include(b => b.employe);
            if (!String.IsNullOrEmpty(nomProjet))
            {
                billet = billet.Where(b => b.nomProjet.Contains(nomProjet));
            }

            if (!String.IsNullOrEmpty(nomDptm))
            {
                billet = billet.Where(b => b.departement.nomDepartement.Contains(nomDptm));
            }

            if (!String.IsNullOrEmpty(nomEmp))
            {
                billet = billet.Where(b => b.employe.nom.Contains(nomEmp));
            }

            if (!String.IsNullOrEmpty(descrBillet))
            {
                billet = billet.Where(b => b.description.Contains(descrBillet));
            }
            return View(billet.ToList());
        }
        //index Englais
        public ActionResult Index1(String nomProjet, String nomDptm, String nomEmp, String descrBillet)
        {
            List<departement> departementList = db.departement.ToList();
            ViewBag.departementList = new SelectList(departementList, "idDepartement", "nomDepartement");
            var billet = db.billet.Include(b => b.departement).Include(b => b.employe);
            if (!String.IsNullOrEmpty(nomProjet))
            {
                billet = billet.Where(b => b.nomProjet.Contains(nomProjet));
            }

            if (!String.IsNullOrEmpty(nomDptm))
            {
                billet = billet.Where(b => b.departement.nomDepartement.Contains(nomDptm));
            }

            if (!String.IsNullOrEmpty(nomEmp))
            {
                billet = billet.Where(b => b.employe.nom.Contains(nomEmp));
            }

            if (!String.IsNullOrEmpty(descrBillet))
            {
                billet = billet.Where(b => b.description.Contains(descrBillet));
            }
            return View(billet.ToList());
        }

        

        // GET: billets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billet billet = db.billet.Find(id);
            if (billet == null)
            {
                return HttpNotFound();
            }
            return View(billet);
        }

        // GET: billets/Create/Fr
        public ActionResult Create()
        {
            List<departement> departementList = db.departement.ToList();
            ViewBag.departementList = new SelectList(departementList, "idDepartement", "nomDepartement");
            return View();
        }

        // POST: billets/Create/Fr
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBillet,nomProjet,description,idDepartement,idEmploye")] billet billet)
        {
            if (ModelState.IsValid)
            {
                db.billet.Add(billet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement", billet.idDepartement);
            ViewBag.idEmploye = new SelectList(db.employe, "idEmploye", "nom", billet.idEmploye);
            return View(billet);
        }
        // GET: billets/Create/En
        public ActionResult Create1()
        {
            List<departement> departementList = db.departement.ToList();
            ViewBag.departementList = new SelectList(departementList, "idDepartement", "nomDepartement");
            return View();
        }

        // POST: billets/Create/Eng
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1([Bind(Include = "idBillet,nomProjet,description,idDepartement,idEmploye")] billet billet)
        {
            if (ModelState.IsValid)
            {
                db.billet.Add(billet);
                db.SaveChanges();
                return RedirectToAction("Index1");
            }

            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement", billet.idDepartement);
            ViewBag.idEmploye = new SelectList(db.employe, "idEmploye", "nom", billet.idEmploye);
            return View(billet);
        }
        public JsonResult GetEmployeList(int idDepartement)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<employe> StateList = db.employe.Where(x => x.idDepartement == idDepartement).ToList();
            return Json(StateList, JsonRequestBehavior.AllowGet);


        }




        // GET: billets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billet billet = db.billet.Find(id);
            if (billet == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement", billet.idDepartement);
            ViewBag.idEmploye = new SelectList(db.employe, "idEmploye", "nom", billet.idEmploye);
            return View(billet);
        }

        // POST: billets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBillet,nomProjet,description,idDepartement,idEmploye")] billet billet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement", billet.idDepartement);
            ViewBag.idEmploye = new SelectList(db.employe, "idEmploye", "nom", billet.idEmploye);
            return View(billet);
        }

        // GET: billets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billet billet = db.billet.Find(id);
            if (billet == null)
            {
                return HttpNotFound();
            }
            return View(billet);
        }

        // POST: billets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            billet billet = db.billet.Find(id);
            db.billet.Remove(billet);
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
