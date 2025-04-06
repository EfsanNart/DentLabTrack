using DentLabTrack.Data.Context;
using DentLabTrack.Data.Entities;
using DentLabTrack.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DentLabTrackDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DentLabTrackDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
          

        }
        public void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            _dbSet.Add(entity);


        }



        public void Delete(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                _dbSet.Update(entity);
                
            }
         
           else
            {
                _dbSet.Remove(entity);
            }

        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                  ? _dbSet.Where(x => !x.IsDeleted) 
                  : _dbSet.Where(x => !x.IsDeleted).Where(predicate);
        }



        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<OrderEntity> GetOrdersByDoctorId(int doctorId)
        {

            return _context.Orders
                .Include(o => o.Patient) 
                .Where(o => o.DoctorId == doctorId)
                .ToList();
        }

        public void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Update(entity);

        }


    }
}

