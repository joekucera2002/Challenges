using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using PayrollManagement.Web.Models;
using PayrollManagement.Web.Helpers;

namespace PayrollManagement.Web.Controllers
{
    public class GridController : Controller
    {
        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request, Int32 employeeId)
        {
            Employee employee = GetEmployee(employeeId);

            return Json(employee.Dependents.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, Dependent dependent, Int32 employeeId)
        {
            if (dependent != null && ModelState.IsValid)
            {
                dependent.EmployeeId = employeeId;
                dependent.RelationshipId = 1;

                AddDependent(dependent);
            }

            return Json(new[] { dependent }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, Dependent dependent, Int32 employeeId)
        {
            if (dependent != null && ModelState.IsValid)
            {
                dependent.EmployeeId = employeeId;

                UpdateDependent(dependent);
            }

            return Json(new[] { dependent }.ToDataSourceResult(request, ModelState));
        }

        private Employee GetEmployee(Int32 id)
        {
            Dictionary<String, String> parameters = new Dictionary<string, string>()
            {
                {"id", id.ToString()}
            };

            return GetEmployee(parameters);
        }

        private Employee GetEmployee(Dictionary<String, String> parameters)
        {
            ApiManager manager = new ApiManager();
            Employee employee = manager.Get<Employee>("Employee", parameters);

            return employee;
        }

        private void AddDependent(Dependent dependent)
        {
            ApiManager manager = new ApiManager();
            manager.Update<Dependent>("Dependent/Insert", dependent);
        }

        private void UpdateDependent(Dependent dependent)
        {
            ApiManager manager = new ApiManager();
            manager.Update<Dependent>("Dependent/Update", dependent);
        }
    }
}