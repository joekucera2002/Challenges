using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace PayrollManagement.Data.Migration
{
    public class PayrollContextMigrationConfiguration : DbMigrationsConfiguration<PayrollContext>
    {
        public PayrollContextMigrationConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = false;
            this.AutomaticMigrationsEnabled = true;
        }

#if DEBUG
        protected override void Seed(PayrollContext context)
        {
            new PayrollDataSeeder(context);
        }
#endif

    }
}
