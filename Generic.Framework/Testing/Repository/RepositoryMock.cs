using System.Threading.Tasks;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;
using Generic.Framework.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Generic.Framework.Testing.Repository
{
    public class RepositoryMock<T> : IRepositoryMock<T>, IRepository<T> where T : class, IEntity
    {
        public bool Any()
        {
            return this._dbSet.Any();
        }

        public bool Any(Func<T, bool> predicate)
        {
            return this._dbSet.Any(predicate);
        }

        public IList<T> _dbSet = new List<T>();

        public IList<T> DbSet { get { return this._dbSet; } }

        public List<T> DeletionTrail { get; private set; }

        public RepositoryMock()
        {
            this.DeletionTrail = new List<T>();
        }

        public void SetData(IList<T> dbSet)
        {
            this._dbSet = dbSet;
        }

        public IList<T> GetData()
        {
            return this._dbSet;
        }

        public void Initalise(IUnitOfWork unitOfWork) { }

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            // ensure the dates are set correctly
            entity.DateCreated = Clock.Now();
            entity.DateModified = Clock.Now();

            entity.SeedId();
            
            _dbSet.Add(entity);
        }


        /// <summary>
        /// sets the state of the entity to be modified
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            entity.DateModified = Clock.Now();
        }

        /// <summary>
        /// deletes the entity from the database
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);

            this.DeletionTrail.Add(entity);
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
        /// deletes entities from the database based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        public void Delete(Expression<Func<T, Boolean>> predicate)
        {
            IEnumerable<T> objects = _dbSet.AsQueryable().Where<T>(predicate).ToList();

            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }
        
        /// <summary>
        /// Gets a list of all entities for a certain type
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> AllQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IEnumerable<T> AllEnumerable()
        {
            return _dbSet.AsQueryable();
        }

        public IList<T> AllList()
        {
            return _dbSet.AsQueryable().ToList();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public virtual T Max()
        {
            return _dbSet.Max<T>();
        }
        
        /// <summary>
        /// Gets a list of entities for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate);
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).FirstOrDefault<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).First<T>();
        }


        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <returns></returns>
        public virtual T FirstOrDefault()
        {
            return _dbSet.AsQueryable().FirstOrDefault<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <returns></returns>
        public virtual T First()
        {
            return _dbSet.AsQueryable().First<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).Single<T>();
        }

        /// <summary>
        /// Gets a single entity for a certain type based on a filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).SingleOrDefault<T>();
        }

        public void SaveChanges()
        {
            //Twiddle thumbs because the in memory list will have already been updated (Me: we could batch the modifications up until this point...)

            return;
        }


        public Task<T> MaxAsync()
        {
            return Task.Run(() => _dbSet.Max<T>());
        }

        public Task<bool> AnyAsync()
        {
            return Task.Run(() => _dbSet.Any());
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.Run(() => _dbSet.AsQueryable().Where(predicate).First<T>() != null);
        }

        public Task<IList<T>> AllListAsync()
        {
            return Task.Run(() => _dbSet.AsQueryable().ToList() as IList<T>);
        }

        public Task<int> CountAsync()
        {
            return Task.Run(() => _dbSet.AsQueryable().Count());
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.Run(() => _dbSet.AsQueryable().Count(predicate));
        }

        public Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.Run(() => _dbSet.AsQueryable().Where(predicate).Single<T>());
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.Run(() => _dbSet.AsQueryable().Where(predicate).SingleOrDefault<T>());
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.Run(() => _dbSet.AsQueryable().Where(predicate).FirstOrDefault<T>());
        }

        public Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.Run(() => _dbSet.AsQueryable().Where(predicate).First<T>());
        }

        public Task<T> FirstOrDefaultAsync()
        {
            return Task.Run(() => _dbSet.AsQueryable().FirstOrDefault<T>());
        }

        public Task<T> FirstAsync()
        {
            return Task.Run(() => _dbSet.AsQueryable().First<T>());
        }
    }
}