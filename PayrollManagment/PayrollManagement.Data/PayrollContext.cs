using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PayrollManagement.Data.Entities;
using PayrollManagement.Data.Migration;

namespace PayrollManagement.Data
{
    public class PayrollContext : DbContext
    {
        public DbSet<BenefitPlan> BenefitPlans { get; set; }
        public DbSet<PayCycle> PayCycles { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        public PayrollContext()
            : base("PayrollManagement")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PayrollContext, PayrollContextMigrationConfiguration>(true));
        }
    }
}
