using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PayrollManagement.Data;
using PayrollManagement.Data.Entities;

namespace PayrollManagement.Services.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/Employee/
        public List<Employee> Get()
        {
            return GetRepository().GetAllEmployees().ToList();
        }

        // GET api/Employee/{id}
        public Employee Get(Int32 id)
        {
            return GetRepository().GetEmployeeById(id);
        }

        // GET api/Employee?firstName={firstName}&lastName={lastName}
        public Employee Get(String firstName, String lastName)
        {
            return GetRepository().GetEmployeeByName(firstName, lastName);
        }

        // PUT api/Employee
        public Boolean Update(Employee current)
        {
            IPayrollRepository repo = GetRepository();

            Employee original = repo.GetEmployeeById(current.Id);

            if (original != null)
            {
                current.BenefitPlanId = original.BenefitPlanId;
                current.MonthlyGross = original.MonthlyGross;
                current.PayCycleId = original.PayCycleId;

                return repo.Update(current, original);
            }

            return false;
        }

        private IPayrollRepository GetRepository()
        {
            return RepositoryFactory.GetRepository();
        }
    }
}
