using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Data
{
    public class RepositoryFactory
    {
        public static IPayrollRepository GetRepository()
        {
            return new PayrollRepository(new PayrollContext());
        }
    }
}
