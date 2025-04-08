using DentLabTrack.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Configurations
{
    public class DoctorConfiguration : BaseConfiguration<DoctorEntity>
    {
        public override void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {

            //Doctor properties

            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.ClinicName).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}
