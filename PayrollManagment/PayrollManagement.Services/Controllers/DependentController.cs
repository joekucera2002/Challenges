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
    public class DependentController : ApiController
    {
        // GET api/Dependent/{id}
        public Dependent Get(Int32 id)
        {
            return GetRepository().GetDependentById(id);
        }

        // POST api/Dependent
        public Int32 Post(Dependent dependent)
        {
            return GetRepository().InsertDependent(dependent);
        }

        // PUT api/Dependent
        public Boolean Update(Dependent current)
        {
            IPayrollRepository repo = GetRepository();

            Dependent original = repo.GetDependentById(current.Id);

            if (original != null)
            {
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
