using ProgrammersTest_Bell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammersTest_Bell.Controllers
{
    public class HomeController : Controller
    {
        private bellTestEntities db = new bellTestEntities();
        public ActionResult Index()
        {
            List<departement> departementList = db.departement.ToList();
            ViewBag.departementList = new SelectList(departementList, "idDepartement", "nomDepartement");

            return View();
        }
        public ActionResult Eng()
        {
            
            return View();
        }



        public JsonResult GetEmployeList(int idDepartement)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<employe> StateList = db.employe.Where(x => x.idDepartement == idDepartement).ToList();
            return Json(StateList, JsonRequestBehavior.AllowGet);


        }
        public ActionResult Create()
        {
            ViewBag.idDepartement = new SelectList(db.departement, "idDepartement", "nomDepartement");
            ViewBag.idEmploye = new SelectList(db.employe, "idEmploye", "nom");
            return View();
        }

    }
}
