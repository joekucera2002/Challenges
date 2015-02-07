using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PayrollManagement.Web.Models;

namespace PayrollManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(Search options)
        {
            if (IsValid(options))
            {
                return RedirectToRoute(new {controller = "Employee", action = "Index"});
            }

            options.Id = null;
            options.FirstName = null;
            options.LastName = null;

            options.ErrorMessage = "You must enter an Employee Id OR your first name and last name.";

            return View(options);
        }

        private Boolean IsValid(Search options)
        {
            if (options.Id.HasValue)
            {
                return true;
            }

            if (!String.IsNullOrWhiteSpace(options.FirstName) && !String.IsNullOrWhiteSpace(options.FirstName))
            {
                return true;
            }

            return false;
        }
    }
}