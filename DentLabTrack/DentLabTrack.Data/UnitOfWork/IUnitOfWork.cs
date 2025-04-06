using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        //Unit of Work, birden fazla veritabanı işlemini tek bir işlem gibi yöneterek hepsini birlikte kaydetmeyi veya geri almayı sağlar
        //Örneğin bir sipariş eklerken, aynı zamanda o siparişe ait teknisyenleri de eklemek istiyorum, bu işlemleri tek bir işlem olarak yönetmek için Unit of Work kullanıyorum

        Task<int> SaveChangesAsync();
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
    }
}
