using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);        
        
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();        
        
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity WhereSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> WhereSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        bool Exists(int id);
        Task<bool> ExistsAsync(int id);

        int Add(TEntity entity);
        Task<int> AddAsync(TEntity entity);

        IList<int> AddRange(IEnumerable<TEntity> entities);
        Task<IList<int>> AddRangeAsync(IEnumerable<TEntity> entities);

        T Update<T>(T updatedEntity, int key) where T : class;
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        int GetPrimaryKey(TEntity entity);
    }

}