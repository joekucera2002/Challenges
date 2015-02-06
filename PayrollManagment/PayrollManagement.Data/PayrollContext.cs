using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PayrollManagement.Data.Entities;
using PayrollManagement.Data.Mappers;
using PayrollManagement.Data.Migration;

namespace PayrollManagement.Data
{
    public class PayrollContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        public PayrollContext()
            : base("PayrollConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PayrollContext, PayrollContextMigrationConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMapper());
            modelBuilder.Configurations.Add(new DependentMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
