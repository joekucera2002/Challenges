using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PayrollManagement.CalculationEngine;
using PayrollManagement.Data;
using PayrollManagement.Data.Entities;
using PayrollManagement.Plugins;

namespace PayrollManagement.Services.Controllers
{
    public class BenefitController : ApiController
    {
        [Route("api/Benefit/Employee/{id}")]
        public Decimal GetEmployeeCost(Int32 id)
        {
            IPayrollRepository repo = GetRepository();
            Decimal cost = 0;

            Employee employee = repo.GetEmployeeById(id);

            if (employee != null)
            {
                BenefitCalculator calc = new BenefitCalculator(employee.BenefitPlan, employee.PayCycle, new NameDiscount());
                cost = calc.CalculatePayPeriodCost(employee);
            }

            return cost;
        }

        [Route("api/Benefit/Dependent/{id}")]
        public Decimal GetDependentCost(Int32 id)
        {
            IPayrollRepository repo = GetRepository();
            Decimal cost = 0;

            Dependent dependent = repo.GetDependentById(id);

            if (dependent != null)
            {
                BenefitCalculator calc = new BenefitCalculator(dependent.Employee.BenefitPlan, dependent.Employee.PayCycle, new NameDiscount());
                cost = calc.CalculatePayPeriodCost(dependent);
            }

            return cost;
        }

        [Route("api/Benefit/Total/{id}")]
        public Decimal GetTotalCost(Int32 id)
        {
            IPayrollRepository repo = GetRepository();
            Decimal cost = 0;

            Employee employee = repo.GetEmployeeById(id);

            if (employee != null)
            {
                BenefitCalculator calc = new BenefitCalculator(employee.BenefitPlan, employee.PayCycle, new NameDiscount());
                cost = calc.CalculatePayPeriodCost(employee);

                foreach (Dependent dependent in employee.Dependents)
                {
                    cost += calc.CalculatePayPeriodCost(dependent);
                }
            }

            return cost;
        }

        private IPayrollRepository GetRepository()
        {
            return RepositoryFactory.GetRepository();
        }
    }
}
