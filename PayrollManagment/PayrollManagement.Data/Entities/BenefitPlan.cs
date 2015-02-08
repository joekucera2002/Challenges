using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column(TypeName = "Money")]
        public Decimal EmployeeCost { get; set; }

        [Column(TypeName = "Money")]
        public Decimal DependentCost { get; set; }
    }
}
