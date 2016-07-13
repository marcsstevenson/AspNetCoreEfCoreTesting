using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Returns true if the repository contains any
        /// </summary>
        bool Any();

        /// <summary>
        /// Returns true if the repository contains any for the predicate
        /// </summary>
        bool Any(Func<T, bool> predicate);

        /// <summary>
        /// Gets a IIQueryable list of entities for a certain type
        /// </summary>
        /// <returns></returns>
        IQueryable<T> AllQueryable();

        /// <summary>
        /// Gets a IIQueryable list of entities for a certain type
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> AllEnumerable();

        /// <summary>
        /// Gets a IIQueryable list of entities for a certain type
        /// </summary>
        /// <returns></returns>
        IList<T> AllList();
        
        /// <summary>
        /// Returns the count
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Returns the count for a given predicate
        /// </summary>
        /// <param name="predicate">A function predicate</param>
        /// <returns></returns>
        int Count(Func<T, bool> predicate);

        /// <summary>
        /// Gets a list of entities for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        
        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Single(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T First(Expression<Func<T, bool>> predicate);

        T FirstOrDefault();

        T First();

        T Max();

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Adds a list of new entity to the database
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// sets the state of the entity to be modified
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// deletes the entity from the database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// deletes the entity from the database
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// deletes entities from the database based on a filter
        /// </summary>
        void Delete(Expression<Func<T, Boolean>> predicate);




        /// <summary>
        /// Returns true if the repository contains any
        /// </summary>
        Task<bool> AnyAsync();

        /// <summary>
        /// Returns true if the repository contains any for the predicate
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a IIQueryable list of entities for a certain type
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> AllListAsync();

        /// <summary>
        /// Returns the count
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();

        /// <summary>
        /// Returns the count for a given predicate
        /// </summary>
        /// <param name="predicate">A function predicate</param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync();

        Task<T> FirstAsync();

        Task<T> MaxAsync();

    }
}
