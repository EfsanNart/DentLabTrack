using DentLabTrack.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly DentLabTrackDbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(DentLabTrackDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async  Task CommitTransaction()
        {
            await _transaction.CommitAsync();

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollbackTransaction()
        {
            await _transaction.RollbackAsync();

        }

        public async Task<int> SaveChangesAsync()
        {

            return await _context.SaveChangesAsync();
        }
    }
}
