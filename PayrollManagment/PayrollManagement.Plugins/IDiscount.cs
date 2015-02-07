using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollManagement.Data.Entities;

namespace PayrollManagement.Plugins
{
    public interface IDiscount
    {
        Decimal ApplyDiscount(Person person, Decimal cost);
    }
}
