using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElifTechTestAssignment.Entities
{
    public class MainCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedAnnualEarnings { get; set; }
        public ICollection<SubsidiaryCompany> SubsidiaryCompanies { get; set; }
        public MainCompany()
        {
            SubsidiaryCompanies = new List<SubsidiaryCompany>();
        }
    }
}