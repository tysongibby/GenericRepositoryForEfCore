using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GenericRepositoryForEfCore.Interfaces;

namespace GenericRepositoryForEfCore
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds an entity of TEntity type with the given primary key value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The entity found or null.</returns>
        public virtual TEntity Get(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: {e.Message}");
            }
        }
        /// <summary>
        /// Finds an entity of TEntity type with the given primary key value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The entity found or null.</returns>
        public virtual async Task<TEntity> GetAsync(int id)
        {
            try
            {                
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: {e.Message}");
            }
        }

        /// <summary>
        /// Finds all entities of TEnitity type.
        /// </summary>
        /// <returns>An IEnumberable<TEntity> collection of the entities found of TEntity type</returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entities: {e.Message}");
            }
        }
        /// <summary>
        /// Asynchronously finds all entities of TEnitity type.
        /// </summary>
        /// <returns>A Task<IEnumerable<TEntity>> collection of the entities found of TEntity type</returns>  
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {                
                return await _context.Set<TEntity>().ToArrayAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entities: {e.Message}");
            }
        }

        //TODO: make this method async
        /// <summary>
        /// Filters a sequence of values of TEntity type based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>An IQueryable<TEntity> that contains elements of TEntity type from the input sequence that satisfy the condition specified by the predicate.</returns>   
        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    throw new ArgumentNullException($"{nameof(TEntity)} predicate must not be null");
                }
                return _context.Set<TEntity>().Where(predicate);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: { e.Message}");
            }
        }

        /// <summary>
        /// Filters a value of TEntity type based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>An entity of TEntity type from the input sequence that satisfy the condition specified by the predicate.</returns>   
        public virtual TEntity WhereSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
            }
            try
            {
                return _context.Set<TEntity>().SingleOrDefault(predicate);
            }
            catch (Exception e)
            {
                throw new Exception($"could not be find entity: {e.Message}");
            }
        }
        /// <summary>
        /// Asynchronously filters a value of TEntity type based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>An entity of TEntity type from the input sequence that satisfy the condition specified by the predicate.</returns>   
        public virtual async Task<TEntity> WhereSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
            }
            try
            {
                return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
            }
            catch (Exception e)
            {
                throw new Exception($"could not be find entity: {e.Message}");
            }
        }

        /// <summary>
        /// Determines if entity with the given primary key value exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean; true if the entity exists or false if the entity does not exist. </returns>
        public virtual bool Exists(int id)
        {
            try
            {
                var response = _context.Set<TEntity>().Find(id);
                if (response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: {e.Message}");
            }
        }
        /// <summary>
        /// Asynchronously determines if entity with the given primary key value exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean; true if the entity exists or false if the entity does not exist. </returns>
        public virtual async Task<bool> ExistsAsync(int id)
        {
            try
            {
                var response = await _context.Set<TEntity>().FindAsync(id);
                if (response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: {e.Message}");
            }
        }

        /// <summary>
        /// Adds an entity to the dbcontext.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An integer that is the primary key of the added entity.</returns>
        public virtual int Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
                }
                var result = _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                int pk = GetPrimaryKey(entity);
                return pk;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(TEntity)} could not be added: {e.Message}", e);
            }
        }
        /// <summary>
        /// Asynchronously adds an entity to the dbcontext.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An integer that is the primary key of the added entity.</returns>
        public virtual async Task<int> AddAsync(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
                }                                
                var result = await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                int pk = GetPrimaryKey(entity);
                return pk;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(TEntity)} could not be added: {e.Message}", e);
            }
        }

        /// <summary>
        /// Adds multiple entities to the dbcontext.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An IEnumerable<int> collection that are the primary keys of the added entities.</int></returns>
        public virtual IEnumerable<int> AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                List<int> pks = new List<int>();

                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
                }
                _context.Set<TEntity>().AddRange(entities);
                _context.SaveChanges();
                foreach (TEntity e in entities)
                {
                    pks.Add(GetPrimaryKey(e));
                }
                return pks;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(IEnumerable<TEntity>)} could not be added: {e.Message}", e);
            }
        }
        /// <summary>
        /// Asynchronously adds multiple entities to the dbcontext.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An IEnumerable<int> collection that are the primary keys of the added entities.</int></returns>
        public virtual async Task<IEnumerable<int>> AddRangeAsync(IEnumerable<TEntity> entities)
        {            
            try
            {
                List<int> pks = new List<int>();

                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
                }
                await _context.Set<TEntity>().AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                foreach (TEntity e in entities)
                {
                    pks.Add(GetPrimaryKey(e));
                }
                return pks;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(IEnumerable<TEntity>)} could not be added: {e.Message}", e);
            }
        }

        //TODO: add an async counterpart for Update?
        /// <summary>
        /// Updates the existing given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The entity that has been updated.</returns>
        public T Update<T>(T updatedEntity, int key) where T : class
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException($"{nameof(T)} entity must not be null");
            }
            try
            {
                T existingEntity = _context.Set<T>().Find(key);

                if (existingEntity != null)
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                    _context.SaveChanges();
                }
                return existingEntity;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(T)} could not be updated: {e.Message}", e);
            }
 
        }

        //TODO: add an async counterpart for Remove? 
        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
                }
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(TEntity)} could not be removed: {e.Message}");
            }
        }

        //TODO: add an async counterpart for RemoveRange?
        /// <summary>
        /// Deletes multilple given entities.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
                }
                _context.Set<TEntity>().RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(IEnumerable<TEntity>)} could not be added: {e.Message}");
            }
        }

        /// <summary>
        /// Saves changes to dbcontext for an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An integer representing the number of entites changed during the save</returns>
        public virtual int SaveChanges(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                return _context.SaveChanges(); 
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(TEntity)} could not be updated: {e.Message}");
            }
        }
        /// <summary>
        /// Asynchronously saves changes to dbcontext for an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An integer representing the number of entites changed during the save</returns>
        public virtual async Task<int> SaveChangesAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
            }

            try
            {                               
                int entitiesChanged = await _context.SaveChangesAsync();
                return entitiesChanged;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(TEntity)} could not be updated: {e.Message}");
            }
        }

        //TODO: add an async counterpart for GetPrimaryKey?       
        /// <summary>
        /// Finds the primary key of the given entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>An integer that is the primary key for the given entity.</returns>
        public virtual int GetPrimaryKey(TEntity entity)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            return (int)entity.GetType().GetProperty(keyName).GetValue(entity, null);
        }

        public virtual int NextPrimaryKey()
        {            
            int nextPrimaryKey = 0;
            var maxKey = _context.Model.FindEntityType(typeof(TEntity)).GetKeys().Max();
            //nextPrimarykey = ;
            return nextPrimaryKey;
        }

    }
}
