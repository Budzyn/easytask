using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElifTechTestAssignment.Entities
{
    public class CompanyContext:DbContext
    {
        public CompanyContext():base("Companies")
        {
        }
        public DbSet<MainCompany> MainCompany { get; set; }
        public DbSet<SubsidiaryCompany> SubsidiaryCompanies { get; set; }
    }
}