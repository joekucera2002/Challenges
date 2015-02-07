using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class BenefitPlan
    {
        [Key]
        public Int16 Id { get; set; }

        [MaxLength(255)]
        public String Name { get; set; }

        [DataType("money")]
        public Decimal EmployeeCost { get; set; }

        [DataType("money")]
        public Decimal DependentCost { get; set; }
    }
}
