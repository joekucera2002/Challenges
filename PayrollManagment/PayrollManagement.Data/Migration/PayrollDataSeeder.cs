using PayrollManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data.Migration
{
    public class PayrollDataSeeder
    {
        private PayrollContext _context;

        public PayrollDataSeeder(PayrollContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Employees.Count() > 0)
            {
                return;
            }

            SeedBenefitPlans();
            SeedPayCycles();
            SeedRelationships();
            SeedEmployees();
            
            _context.SaveChanges();
        }

        private void SeedBenefitPlans()
        {
            _context.BenefitPlans.Add(
                new BenefitPlan()
                {
                    Name = "HMO Plan A - 2015",
                    EmployeeCost = 2000,
                    DependentCost = 500
                });
            _context.SaveChanges();
        }

        private void SeedPayCycles()
        {
            _context.PayCycles.Add(
                new PayCycle()
                {
                    Name = "Bi-Weekly",
                    NumPeriods = 26
                });
            _context.SaveChanges();
        }

        private void SeedRelationships()
        {
            _context.Relationships.Add(
                new Relationship()
                {
                    Name = "Spouse"
                });

            _context.Relationships.Add(
                new Relationship()
                {
                    Name = "Child"
                });
            _context.SaveChanges();
        }

        private void SeedEmployees()
        {
            BenefitPlan plan = _context.BenefitPlans.First();
            PayCycle cycle = _context.PayCycles.First();

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "John",
                    LastName = "Smith",
                    BenefitPlan = plan, 
                    PayCycle = cycle
                });

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "Jill",
                    LastName = "Werner",
                    BenefitPlan = plan,
                    PayCycle = cycle
                });

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "Derek",
                    LastName = "Jeter",
                    BenefitPlan = plan,
                    PayCycle = cycle
                });

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "Robert",
                    LastName = "Barone",
                    BenefitPlan = plan,
                    PayCycle = cycle
                });
            _context.SaveChanges();
        }
    }
}
