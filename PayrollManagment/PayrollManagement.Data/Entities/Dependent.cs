using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class Dependent
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int16 Age { get; set; }
        public Employee Employee { get; set; }

        public Dependent()
        {
            Employee = new Employee();
        }
    }
}
