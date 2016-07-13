using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Finance.Repository.EfCore.Context;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;
using Microsoft.EntityFrameworkCore;

//using FinanceDbContext = Finance.Repository.EfCore.Contexts.FinanceDbContext;

namespace Finance.Repository.EfCore.Repository
{
    public class EntityRepository<T> : IEntityRepository<T>//, IDisposable
        where T : class, IEntity
    {
        private FinanceDbContext _dataContext;
        private readonly DbSet<T> _dbset;

        public EntityRepository(FinanceDbContext dataContext)
        {
            _dataContext = dataContext;
            _dbset = DataContext.Set<T>();
        }

        public EntityRepository()
        {
            _dbset = DataContext.Set<T>();
        }

        protected FinanceDbContext DataContext
        {
            //get { return _dataContext ?? (_dataContext = new FinanceDbContext()); }
            get { return _dataContext; }
        }

        public void SetContext(FinanceDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public virtual bool Any()
        {
            return this._dbset.Any();
        }

        public virtual bool Any(Func<T, bool> predicate)
        {
            return this._dbset.Any(predicate);
        }

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            // ensure the dates are set correctly
            entity.SetForCreated();
            _dbset.Add(entity);
        }

        /// <summary>
        /// sets the state of the entity to be modified
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            entity.SetForModified();
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        
        /// <summary>
        /// deletes the entity from the database
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            Delete(i => i.Equals(entity));
        }

        /// <summary>
        /// deletes entities from the database based on a filter
        /// </summary>
        public void Delete(Expression<Func<T, Boolean>> predicate)
        {
            IEnumerable<T> objects = _dbset.Where<T>(predicate).AsEnumerable();

            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                this.Add(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                this.Delete(entity);
        }

        /// <summary>
        /// Gets a list of all entities for a certain type
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> AllQueryable()
        {
            return _dbset;
        }

        public IEnumerable<T> AllEnumerable()
        {
            return _dbset;
        }

        public IList<T> AllList()
        {
            return this.AllEnumerable().ToList();
        }
        
        public int Count()
        {
            return _dbset.Count();
        }

        public int Count(Func<T, bool> predicate)
        {
            //NOTE: this.Count gets all records from the database and THEN runs the predicate - less than optimal!
            return _dbset.Count(predicate);
        }

        /// <summary>
        /// Gets a list of entities for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).First<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <returns></returns>
        public virtual T FirstOrDefault()
        {
            return _dbset.FirstOrDefault<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <returns></returns>
        public virtual T First()
        {
            return _dbset.First<T>();
        }

        public virtual T Max()
        {
            return _dbset.Max<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).Single<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).SingleOrDefault<T>();
        }
        
        //public void Dispose()
        //{
        //    this.DataContext.Dispose();
        //}

        //MS: Not sure if we want to keep this here but will use them for now to streamline dev'
        public virtual void SaveChanges()
        {
            this.DataContext.SaveChanges();
        }



        public async virtual Task<bool> AnyAsync()
        {
            return await this._dbset.AnyAsync();
        }

        public async virtual Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._dbset.AnyAsync(predicate);
        }


        public async Task<IList<T>> AllListAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _dbset.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            //NOTE: this.Count gets all records from the database and THEN runs the predicate - less than optimal!
            return await _dbset.CountAsync(predicate);
        }


        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).FirstOrDefaultAsync<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async virtual Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).FirstAsync<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <returns></returns>
        public async virtual Task<T> FirstOrDefaultAsync()
        {
            return await _dbset.FirstOrDefaultAsync<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <returns></returns>
        public async virtual Task<T> FirstAsync()
        {
            return await _dbset.FirstAsync<T>();
        }

        public async virtual Task<T> MaxAsync()
        {
            return await _dbset.MaxAsync<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async virtual Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).SingleAsync<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async virtual Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).SingleOrDefaultAsync<T>();
        }
    }
}
