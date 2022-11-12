using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepositoryForEfCore.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);        
        
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();        
        
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity WhereSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> WhereSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        bool Exists(int id);
        Task<bool> ExistsAsync(int id);

        int Add(TEntity entity);
        Task<int> AddAsync(TEntity entity);

        IEnumerable<int> AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<int>> AddRangeAsync(IEnumerable<TEntity> entities);

        T Update<T>(T updatedEntity, int key) where T : class;
        int Remove(TEntity entity, int entityId);
        int RemoveRange(IEnumerable<TEntity> entities);

        int GetPrimaryKey(TEntity entity);
    }

}