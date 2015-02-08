using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using PayrollManagement.Web.Reporting.Models;
using PayrollManagement.Web.Reporting.Helpers;

namespace PayrollManagement.Web.Reporting.Controllers
{
    public class GridController : Controller
    {
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Employee> employees = GetEmployees();

            foreach (Employee emp in employees)
            {
                emp.TotalCost = GetTotalCost(emp.Id).ToString("C");
            }

            return Json(employees.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private List<Employee> GetEmployees()
        {
            ApiManager manager = new ApiManager();
            List<Employee> employees = manager.Get<List<Employee>>("Employee", null);

            return employees;
        }

        public Decimal GetTotalCost(Int32 id)
        {
            ApiManager manager = new ApiManager();
            Decimal cost = manager.Get<Decimal>("Benefit/Total/" + id, null);

            return cost;
        }

    }
}