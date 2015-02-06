using PayrollManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data
{
    public interface IPayrollRepository
    {
        IQueryable<Employee> GetAllEmployees();
        Employee GetEmployeeById(Int32 id);
        Employee GetEmployeeByName(String firstName, String lastName);
        Dependent GetDependentById(Int32 id);

        Int32 InsertDependent(Dependent dependent);

        Boolean Update(Employee current, Employee original);
        Boolean Update(Dependent current, Dependent original);
    }
}
