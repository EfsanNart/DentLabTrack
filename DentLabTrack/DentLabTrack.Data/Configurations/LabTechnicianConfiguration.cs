using DentLabTrack.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Configurations
{
    public class LabTechnicianConfiguration : BaseConfiguration<LabTechnicianEntity>
    {
        public override void Configure(EntityTypeBuilder<LabTechnicianEntity> builder)
        {

            // Configure the properties of the LabTechnicianEntity

            builder.Property(lt => lt.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(lt => lt.LastName).IsRequired().HasMaxLength(50);
            builder.Property(lt => lt.Email).IsRequired().HasMaxLength(100);
            builder.Property(lt => lt.PhoneNumber).HasMaxLength(20);
            base.Configure(builder);
        }
    }
}
