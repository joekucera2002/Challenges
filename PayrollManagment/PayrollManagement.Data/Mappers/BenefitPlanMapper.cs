using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PayrollManagement.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagement.Data.Mappers
{
    public class BenefitPlanMapper : EntityTypeConfiguration<BenefitPlan>
    {
        public BenefitPlanMapper()
        {
            this.ToTable("BenefitPlan");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Name).HasMaxLength(255);

            this.Property(c => c.EmployeeCost).HasColumnType("money");
            this.Property(c => c.EmployeeCost).IsRequired();

            this.Property(c => c.DependentCost).HasColumnType("money");
            this.Property(c => c.DependentCost).IsRequired();
        }
    }
}
