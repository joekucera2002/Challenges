using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Entities
{
    public class PayCycle
    {
        public Int16 Id { get; set; }
        public String Name { get; set; }
        public Int16 NumPeriods { get; set; }
    }
}
