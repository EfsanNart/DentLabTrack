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
    //Configürasyon sınıfları buradan türetilecek
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Soft delete filtresi: IsDeleted = false olanları getir
            builder.HasQueryFilter(x => !x.IsDeleted);

            // UpdatedAt opsiyonel olacak
            builder.Property(x => x.UpdatedAt).IsRequired(false);
        }
    }
}
