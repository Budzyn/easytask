using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElifTechTest.Models
{
    public class CompanyContext:DbContext
    {
        public DbSet<MainCompany> MainCompanies { get; set; }
        public DbSet<SubsidiaryCompany> Subsidiaries { get; set; }
    }
}