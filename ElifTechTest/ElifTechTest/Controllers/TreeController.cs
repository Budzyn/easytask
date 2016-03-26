using ElifTechTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElifTechTest.Controllers
{
    public class TreeController : Controller
    {
        private CompanyContext db = new CompanyContext();

        public ActionResult Index()
        {
            var CompanyModels = new CompanyModels();
            CompanyModels.MainCompany = new MainCompany();
            CompanyModels.SubsidiaryCompany = new SubsidiaryCompany();
            return View(CompanyModels);
        }
    }
}