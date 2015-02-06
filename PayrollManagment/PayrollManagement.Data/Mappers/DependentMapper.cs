using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PayrollManagement.Data.Entities;

namespace PayrollManagement.Data.Mappers
{
    public class DependentMapper : EntityTypeConfiguration<Dependent>
    {
        public DependentMapper()
        {
            this.ToTable("Dependent");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.FirstName).HasMaxLength(255);
            this.Property(c => c.LastName).HasMaxLength(255);

            this.HasOptional(c => c.Employee)
                .WithMany(c => c.Dependents)
                .Map(c => c.MapKey("EmployeeId"));
        }
    }
}
