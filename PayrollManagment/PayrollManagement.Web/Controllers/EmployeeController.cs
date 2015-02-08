using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayrollManagement.Web.Helpers;
using PayrollManagement.Web.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace PayrollManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee?id={id}
        public ActionResult Edit(Int32? id, String firstName, String lastName)
        {
            Employee employee;

            if (id.HasValue)
            {
                employee = GetEmployee(id.Value);
            }
            else
            {
                employee = GetEmployee(firstName, lastName);
            }

            if (employee == null)
            {
                return View("Error", new Error() { Message = "Could not load employee data. Please try again." });
            }

            employee.EmployeeDeduction = GetEmployeeCost(employee.Id).ToString("C");

            return View(employee);
        }

        public ActionResult Update(Employee employee)
        {
            ApiManager manager = new ApiManager();
            Boolean result = manager.Update<Employee>("Employee/Update", employee);

            return Json(true);
        }

        public Decimal GetEmployeeCost(Int32 id)
        {
            ApiManager manager = new ApiManager();
            Decimal cost = manager.Get<Decimal>("Benefit/Employee/" + id, null);

            return cost;
        }

        public Decimal GetTotalCost(Int32 id)
        {
            ApiManager manager = new ApiManager();
            Decimal cost = manager.Get<Decimal>("Benefit/Total/" + id, null);

            return cost;
        }

        private Employee GetEmployee(Dictionary<String, String> parameters)
        {
            ApiManager manager = new ApiManager();
            Employee employee = manager.Get<Employee>("Employee", parameters);

            return employee;
        }

        private Employee GetEmployee(Int32 id)
        {
            Dictionary<String, String> parameters = new Dictionary<string, string>()
            {
                {"id", id.ToString()}
            };

            return GetEmployee(parameters);
        }

        private Employee GetEmployee(String firstName, String lastName)
        {
            Dictionary<String, String> parameters = new Dictionary<string, string>()
            {
                {"firstName", firstName},
                {"lastName", lastName}
            };

            return GetEmployee(parameters);
        }
    }
}