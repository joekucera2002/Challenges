using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollManagement.Web.Models
{
    public class BenefitPlan
    {
        public Int16 Id { get; set; }
        public String Name { get; set; }
        public Decimal EmployeeCost { get; set; }
        public Decimal DependentCost { get; set; }
    }
}