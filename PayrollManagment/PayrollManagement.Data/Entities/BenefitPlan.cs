using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class BenefitPlan
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Decimal EmployeeCost { get; set; }
        public Decimal DependentCost { get; set; }
    }
}
