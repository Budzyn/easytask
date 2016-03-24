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
    public class MainCompaniesController : Controller
    {
        private CompanyContext db = new CompanyContext();

        public ActionResult Index()
        {
            return View(db.MainCompanies.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EstimatedAnnualEarnings")] MainCompany mainCompany)
        {
            if (ModelState.IsValid)
            {
                db.MainCompanies.Add(mainCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mainCompany);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCompany mainCompany = db.MainCompanies.Find(id);
            if (mainCompany == null)
            {
                return HttpNotFound();
            }
            return View(mainCompany);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EstimatedAnnualEarnings")] MainCompany mainCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainCompany);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCompany mainCompany = db.MainCompanies.Find(id);
            if (mainCompany == null)
            {
                return HttpNotFound();
            }
            return View(mainCompany);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainCompany mainCompany = db.MainCompanies.Find(id);
            db.MainCompanies.Remove(mainCompany);
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
