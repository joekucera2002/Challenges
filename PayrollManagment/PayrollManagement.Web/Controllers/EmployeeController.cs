using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayrollManagement.Web.Helpers;
using PayrollManagement.Web.Models;

namespace PayrollManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/{id}
        public ActionResult Index(Int32 id)
        {
            Dictionary<String, String> qp = new Dictionary<string, string>()
            {
                {"id", id.ToString()}
            };

            ApiManager manager = new ApiManager();
            Employee employee = manager.Get<Employee>("Employee", qp);

            return View(employee);
        }
    }
}