﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollManagement.Data.Entities;

namespace PayrollManagement.Data.Mappers
{
    public class PayCycleMapper : EntityTypeConfiguration<PayCycle>
    {
        public PayCycleMapper()
        {
            this.ToTable("PayCycle");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Name).HasMaxLength(255);
        }
    }
}
