using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CS201_WebApi.Infra.Http.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CS201_WebApi.Infra.Database
{
    public class AbstractRepository<TEntity> where TEntity : Entity
    {
        public DbSet<TEntity> Entities { get => _context.Set<TEntity>(); }
        private readonly DbContext _context;

        protected AbstractRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() => await Entities
            .OrderBy(t => t.CreateDate)
            .ToListAsync();

        public async Task<TEntity> GetById(int id) => await GetOne(t => t.Id == id);

        public async Task<TEntity> GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Entities.SingleAsync(predicate);
            }
            catch (System.InvalidOperationException e)
            {
                throw new NotFoundException("Item not found", e);
            }
        }

        public async Task<TEntity> Insert(TEntity instance)
        {
            instance.CreateDate = DateTime.Now;
            Entities.Add(instance);
            await _context.SaveChangesAsync();

            return instance;
        }

        public async Task<TEntity> Update(TEntity instance)
        {
            instance.UpdateDate = DateTime.Now;
            Entities.Update(instance);
            await _context.SaveChangesAsync();

            return instance;
        }

        public async Task Delete(TEntity instance)
        {
            _context.Remove(instance);
            await _context.SaveChangesAsync();
        }
    }
}