using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollManagement.Data.Entities;

namespace PayrollManagement.Plugins
{
    // Ideally, this would be a plug-in which could be loaded dynamically and applied without having to recompile 
    // the entire application. Just write a plug-in, drop into service bin, restart service.
    //
    // Will just be hard-referenced by service due to time constraints.
    public class NameDiscount : IDiscount
    {
        private String _discountChar;
        private Decimal _percentage;

        public NameDiscount()
        {
            _discountChar = "a";
            _percentage = 0.10M;
        }

        #region IDiscount Members

        public Decimal ApplyDiscount(Person person, Decimal cost)
        {
            if (DiscountApplies(person))
            {
                return cost - (cost * _percentage);
            }

            return cost;
        }

        #endregion

        private Boolean DiscountApplies(Person person)
        {
            if (person.FirstName.Trim().StartsWith(_discountChar, StringComparison.InvariantCultureIgnoreCase)
                ||
                person.LastName.Trim().StartsWith(_discountChar, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
