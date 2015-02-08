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

        public Decimal MonthlyGross { get; set; }
        public Decimal EmployeeDeduction { get; set; }
        public Decimal TotalCost { get; set; }

        public BenefitPlan BenefitPlan { get; set; }

        public ICollection<Dependent> Dependents { get; set; }
    }
}