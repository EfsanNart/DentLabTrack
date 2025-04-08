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
    public class OrderConfiguration : BaseConfiguration<OrderEntity>
    {

        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {


            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.EstimatedDeliveryDate).IsRequired(false);


            //Order status : New, InProgress, Completed, Delivered
            builder.Property(o => o.OrderStatus)
                .HasConversion<int>() 
                .IsRequired();


        }
    }
}
