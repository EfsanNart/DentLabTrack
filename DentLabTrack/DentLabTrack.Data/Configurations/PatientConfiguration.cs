using DentLabTrack.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Configurations
{
    public class PatientConfiguration : BaseConfiguration<PatientEntity>
    {
        public override void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            // Configure the properties of the PatientEntity

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Email).HasMaxLength(100);
            base.Configure(builder);
        }
    }
}
