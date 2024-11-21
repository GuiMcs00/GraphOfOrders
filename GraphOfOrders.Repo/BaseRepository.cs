using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Lib.DI.Repositories;

namespace GraphOfOrders.Repo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly AccountingContext _context;

        protected BaseRepository(AccountingContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public virtual async Task<T> UpdateAsync(string id, T entity)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with Id {id} not found.");
            }
            
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            
            return existingEntity;
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new KeyNotFoundException($"Entity with Id {id} not found.");
        }
        
        public async Task<IEnumerable<T>> GetByForeignKeyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        
        public async Task<T> GetByCompositeKeyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

    }
}


