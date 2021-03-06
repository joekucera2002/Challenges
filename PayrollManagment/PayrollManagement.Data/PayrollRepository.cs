﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollManagement.Data.Entities;

namespace PayrollManagement.Data
{
    public class PayrollRepository : IPayrollRepository
    {
        private PayrollContext _context;

        public PayrollRepository(PayrollContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        #region IPayrollRepository Members

        public IQueryable<Employee> GetAllEmployees()
        {
            return 
                _context
                    .Employees
                    .Include("BenefitPlan")
                    .Include("PayCycle")
                    .Include("Dependents")
                    .AsQueryable<Employee>();
        }

        public Employee GetEmployeeById(Int32 id)
        {
            Employee employee = _context
                    .Employees
                    .Include("BenefitPlan")
                    .Include("PayCycle")
                    .Where(e => e.Id == id)
                    .SingleOrDefault();

            if (employee != null)
            {
                employee.Dependents = _context.Dependents.Where(d => d.EmployeeId == employee.Id).ToList();
            }

            return employee;
        }

        public Employee GetEmployeeByName(String firstName, String lastName)
        {
            Employee employee = _context
                    .Employees
                    .Include("BenefitPlan")
                    .Include("PayCycle")
                    .Include("Dependents")
                    .Where(e => e.FirstName == firstName && e.LastName == lastName)
                    .SingleOrDefault();

            if (employee != null)
            {
                employee.Dependents = _context.Dependents.Where(d => d.EmployeeId == employee.Id).ToList();
            }

            return employee;
        }

        public Dependent GetDependentById(Int32 id)
        {
            return
                _context
                    .Dependents
                    .Include("Employee")
                    .Include("Relationship")
                    .Where(d => d.Id == id)
                    .SingleOrDefault();
        }

        public Int32 InsertDependent(Dependent dependent)
        {
            Employee employee = _context.Employees.Where(e => e.Id == dependent.EmployeeId).Single();

            dependent.Employee = employee;
            
            _context.Dependents.Add(dependent);
            _context.SaveChanges();

            return dependent.Id;
        }

        public Boolean Update(Employee current, Employee original)
        {
            _context.Entry(original).CurrentValues.SetValues(current);
            _context.SaveChanges();

            return true;
        }

        public bool Update(Dependent current, Dependent original)
        {
            //_context.Entry(original).CurrentValues.SetValues(current);
            //_context.SaveChanges();

            return true;
        }

        #endregion
    }
}
