using System;
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
                    .Include("Dependents")
                    .AsQueryable<Employee>();
        }

        public Employee GetEmployeeById(Int32 id)
        {
            return
                _context
                    .Employees
                    .Include("Dependents")
                    .Where(e => e.Id == id)
                    .SingleOrDefault();
        }

        public Employee GetEmployeeByName(String firstName, String lastName)
        {
            return
                _context
                    .Employees
                    .Include("Dependents")
                    .Where(e => e.FirstName == firstName && e.LastName == lastName)
                    .SingleOrDefault();
        }

        public Dependent GetDependentById(Int32 id)
        {
            return
                _context
                    .Dependents
                    .Where(d => d.Id == id)
                    .SingleOrDefault();
        }

        public Int32 InsertDependent(Dependent dependent)
        {
            _context.Dependents.Add(dependent);
            _context.SaveChanges();

            return dependent.Id;
        }

        public Boolean Update(Employee current, Employee original)
        {
            _context.Entry(original).CurrentValues.SetValues(current);

            return true;
        }

        public bool Update(Dependent current, Dependent original)
        {
            _context.Entry(original).CurrentValues.SetValues(current);

            return true;
        }

        #endregion
    }
}
