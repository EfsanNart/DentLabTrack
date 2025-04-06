using DentLabTrack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Configurations
{
    public class OrderTechnicianConfiguration : BaseConfiguration<OrderTechnician>
    {
        public override void Configure(EntityTypeBuilder<OrderTechnician> builder)
        {
            
            builder.Ignore(x => x.Id);
            builder.HasKey("OrderId", "TechnicianId");

            base.Configure(builder); 

        }
    }
}
