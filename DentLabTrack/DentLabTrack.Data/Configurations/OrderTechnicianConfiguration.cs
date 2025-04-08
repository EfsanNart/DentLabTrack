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
          
            builder.Ignore(x => x.Id); //We ignore the id coming from the base entity
            builder.HasKey("OrderId", "TechnicianId"); // Composite key for the join table 

            base.Configure(builder); 

        }
    }
}
