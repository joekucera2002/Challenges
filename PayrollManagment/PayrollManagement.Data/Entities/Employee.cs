using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class Employee : Person
    {
        public BenefitPlan BenefitPlan { get; set; }
        public PayCycle PayCycle { get; set; }

        [Required]
        [ForeignKey("BenefitPlan")]
        public Int16 BenefitPlanId { get; set; }

        [Required]
        [ForeignKey("PayCycle")]
        public Int16 PayCycleId { get; set; }

        public ICollection<Dependent> Dependents { get; set; }

        public Employee()
        {
            Dependents = new List<Dependent>();
        }
    }
}
