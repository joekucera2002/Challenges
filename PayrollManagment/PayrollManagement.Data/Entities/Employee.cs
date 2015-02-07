using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class Employee : Person
    {
        public BenefitPlan BenefitPlan { get; set; }
        public PayCycle PayCycle { get; set; }

        public ICollection<Dependent> Dependents { get; set; }

        public Employee()
        {
            Dependents = new List<Dependent>();
        }
    }
}
