using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [ForeignKey("Relationship")]
        public Int16 RelationshipId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public Int32 EmployeeId { get; set; }

        public Dependent()
        {
            Employee = new Employee();
        }
    }
}
