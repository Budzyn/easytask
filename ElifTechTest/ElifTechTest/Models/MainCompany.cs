using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElifTechTest.Models
{
    public class MainCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedAnnualEarnings { get; set; }
        public ICollection<SubsidiaryCompany> Subsidiaries { get; set; }
        public MainCompany()
        {
            Subsidiaries = new List<SubsidiaryCompany>();
        }
    }
}