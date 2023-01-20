using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepositoryForEfCore.Interfaces
{
    public interface IGenericRepositoryAsync<TEntity> where TEntity : class
    {
        
        Task<TEntity> GetAsync(int id);        
                
        Task<IEnumerable<TEntity>> GetAllAsync();        
        
        Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
        
        Task<TEntity> WhereSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        
        Task<bool> ExistsAsync(int id);

        Task<int> AddAsync(TEntity entity);

        Task<IEnumerable<int>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<T> UpdateAsync<T>(T updatedEntity, int key) where T : class;
        Task<int> RemoveAsync(TEntity entity, int entityId);
        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        Task<int> GetPrimaryKeyAsync(TEntity entity);
        Task<int> NextKeyAsync(TEntity entity);
    }

}