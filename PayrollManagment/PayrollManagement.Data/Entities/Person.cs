using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public abstract class Person
    {
        [Key]
        public Int32 Id { get; set; }

        [MaxLength(255)]
        public String FirstName { get; set; }

        [MaxLength(255)]
        public String LastName { get; set; }
        
        public Int16 Age { get; set; }
    }
}
