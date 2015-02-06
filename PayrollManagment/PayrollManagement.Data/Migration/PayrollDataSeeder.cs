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

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "John",
                    LastName = "Smith",
                });

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "Jill",
                    LastName = "Werner",
                });

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "Derek",
                    LastName = "Jeter",
                });

            _context.Employees.Add(
                new Employee
                {
                    FirstName = "Robert",
                    LastName = "Barone",
                });

            _context.SaveChanges();
        }
    }
}
