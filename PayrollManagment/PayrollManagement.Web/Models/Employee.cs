using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayrollManagement.Web.Models
{
    public class Employee
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int16 Age { get; set; }

        public String MonthlyGross { get; set; }
        public String EmployeeDeduction { get; set; }
        public String TotalCost { get; set; }

        public BenefitPlan BenefitPlan { get; set; }

        public List<Dependent> Dependents { get; set; }
    }
}