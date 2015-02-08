using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollManagement.Web.Models
{
    public class Dependent
    {
        [HiddenInput(DisplayValue = false)]
        public Int32 Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Int32 EmployeeId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Int16 RelationshipId { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int16 Age { get; set; }
    }
}