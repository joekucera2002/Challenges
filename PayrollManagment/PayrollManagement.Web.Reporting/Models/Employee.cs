using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayrollManagement.Web.Reporting.Models
{
    public class Employee
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int16 Age { get; set; }

        public Decimal MonthlyGross { get; set; }
        public Decimal EmployeeDeduction { get; set; }
        public String TotalCost { get; set; }
    }
}