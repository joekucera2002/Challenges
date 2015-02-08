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
        [HttpPost]
        [Route("api/Dependent/Insert")]
        public Int32 Insert(Dependent dependent)
        {
            return GetRepository().InsertDependent(dependent);
        }

        // PUT api/Dependent
        [HttpPost]
        [Route("api/Dependent/Update")]
        public Boolean Update(Dependent current)
        {
            IPayrollRepository repo = GetRepository();

            Dependent original = repo.GetDependentById(current.Id);

            if (original != null)
            {
                current.RelationshipId = original.RelationshipId;

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
