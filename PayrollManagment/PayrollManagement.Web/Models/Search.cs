using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollManagement.Web.Models
{
    public class Search
    {
        public Int32? Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String ErrorMessage { get; set; }
    }
}