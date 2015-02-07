using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollManagement.Data.Entities;
using PayrollManagement.Plugins;

namespace PayrollManagement.CalculationEngine
{
    public class BenefitCalculator
    {
        private BenefitPlan _plan;
        private PayCycle _cycle;
        private IDiscount _discount;

        public BenefitCalculator(BenefitPlan plan, PayCycle cycle, IDiscount discount)
        {
            _plan = plan;
            _cycle = cycle;
            _discount = discount;
        }

        public Decimal CalculatePayPeriodCost(Person person)
        {
            Decimal cost;
            Decimal monthlyCost;

            if (person is Employee)
            {
                cost = _plan.EmployeeCost;
            }
            else
            {
                cost = _plan.DependentCost;
            }

            monthlyCost = cost / _cycle.NumPeriods;

            if (_discount != null)
            {
                return _discount.ApplyDiscount(person, monthlyCost);
            }

            return monthlyCost;
        }
    }
}
