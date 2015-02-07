using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class Dependent : Person
    {
        public Relationship Relationship { get; set; }
        public Employee Employee { get; set; }

        public Dependent()
        {
            Employee = new Employee();
        }
    }
}
