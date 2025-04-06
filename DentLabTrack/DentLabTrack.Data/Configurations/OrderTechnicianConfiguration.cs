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
            
            builder.Ignore(x => x.Id);// Burada Base'den gelen Id'yi ignore ediyoruz çünkü composite key kullanıyoruz.
            builder.HasKey("OrderId", "TechnicianId"); //Burada composite key tanımlıyoruz yani OrderId ve TechnicianId'yi birleştirerek tek bir anahtar oluşturuyoruz.

            base.Configure(builder); // ← Query filter ve tarih ayarları gibi şeyleri uygular

        }
    }
}
