using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        //For example, when an order is added, I want to add the technicians related to that order and I manage this as a single transaction.
        Task<int> SaveChangesAsync();
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
    }
}
