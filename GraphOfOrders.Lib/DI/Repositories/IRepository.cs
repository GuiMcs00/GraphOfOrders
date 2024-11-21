using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphOfOrders.Lib.DI.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetByForeignKeyAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByCompositeKeyAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(string id, T entity);
    Task<T> DeleteAsync(string id);
    
}
