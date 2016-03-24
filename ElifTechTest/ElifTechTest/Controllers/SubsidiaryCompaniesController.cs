using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElifTechTest.Models;

namespace ElifTechTest.Controllers
{
    public class SubsidiaryCompaniesController : Controller
    {
        private CompanyContext db = new CompanyContext();

        public ActionResult Index()
        {
            return View(db.Subsidiaries.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EstimatedAnnualEarnings")] SubsidiaryCompany subsidiaryCompany)
        {
            if (ModelState.IsValid)
            {
                db.Subsidiaries.Add(subsidiaryCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subsidiaryCompany);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubsidiaryCompany subsidiaryCompany = db.Subsidiaries.Find(id);
            if (subsidiaryCompany == null)
            {
                return HttpNotFound();
            }
            return View(subsidiaryCompany);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EstimatedAnnualEarnings")] SubsidiaryCompany subsidiaryCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subsidiaryCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subsidiaryCompany);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubsidiaryCompany subsidiaryCompany = db.Subsidiaries.Find(id);
            if (subsidiaryCompany == null)
            {
                return HttpNotFound();
            }
            return View(subsidiaryCompany);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubsidiaryCompany subsidiaryCompany = db.Subsidiaries.Find(id);
            db.Subsidiaries.Remove(subsidiaryCompany);
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
