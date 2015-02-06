using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class Employee
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public ICollection<Dependent> Dependents { get; set; }

        public Employee()
        {
            Dependents = new List<Dependent>();
        }
    }
}
