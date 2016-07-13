using System;
using System.Collections.Generic;
using ER.Fyndit.Repository.Testing.Mocking;
using Generic.Framework.Caching.Providers;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;
using Generic.Framework.UnitOfWork;

namespace Generic.Framework.Testing.Repository
{
    public class PersistanceFactoryMock : IPersistanceFactory
    {
        public Dictionary<Type, object> RepositoryCache = new Dictionary<Type, object>();
        public Dictionary<Type, object> RepositoryCacheAsync = new Dictionary<Type, object>();

        private object GetFromCacheForType(Type type)
        {
            return RepositoryCache.ContainsKey(type) ? RepositoryCache[type] : null;
        }

        private object GetFromCacheForTypeAsync(Type type)
        {
            return RepositoryCacheAsync.ContainsKey(type) ? RepositoryCache[type] : null;
        }

        public IRepository<T> BuildRepository<T>() where T : class, IEntity
        {
            var typeOfT = typeof(T);

            //Return from the cache if we already have this type
            object cachedValue = GetFromCacheForType(typeOfT);

            if (cachedValue != null)
                return cachedValue as RepositoryMock<T>;

            if (RepositoryCache.ContainsKey(typeOfT))
                return RepositoryCache[typeOfT] as RepositoryMock<T>;

            //Create new
            var genericRepository = new RepositoryMock<T>();
            //Add to the cache for next time
            RepositoryCache.Add(typeOfT, genericRepository);

            return genericRepository;
        }
        
        public IGuidEntityRepository<T> BuildGuidEntityRepository<T>() where T : class, IGuidEntity
        {
            return GetEntityRepositoryMock<T, GuidEntityRepositoryMock<T>>();
        }
        
        public IIntEntityRepository<T> BuildIntEntityRepository<T>() where T : class, IIntEntity
        {
            return GetEntityRepositoryMock<T, IntEntityRepositoryMock<T>>();
        }

        public IStringEntityRepository<T> BuildStringEntityRepository<T>() where T : class, IStringEntity
        {
            return GetEntityRepositoryMock<T, StringEntityRepositoryMock<T>>();
        }

        public R GetEntityRepositoryMock<T, R>()
            where T : class, IEntity
            where R : class, IRepositoryMock<T>, IEntityRepository<T>, new()
        {
            var typeOfT = typeof(T);

            //Return from the cache if we already have this type
            object cachedValue = GetFromCacheForType(typeOfT);

            if (cachedValue != null)
            {
                var poly = cachedValue as R;

                //Return the repository if it casted to GuidEntityRepositoryMock
                if (poly != null)
                    return poly;

                var casted = cachedValue as RepositoryMock<T>;

                //Surely the cached value must be of type RepositoryMock
                if (casted == null)
                    throw new Exception("Cached repository is not of an understood type");

                //We are going to swap the cached RepositoryMock for a new RepositoryMock of the type that we need
                poly = new R();
                poly.SetData(casted.GetData());

                this.RepositoryCache.Remove(typeOfT);
                this.RepositoryCache.Add(typeOfT, poly);

                return poly;
            }

            //Create new
            var genericRepository = new R();
            //Add to the cache for next time
            RepositoryCache.Add(typeOfT, genericRepository);

            return genericRepository;
        }
        
        public IUnitOfWork BuildUnitOfWork()
        {
            return new UnitOfWorkMock();
        }

        /// <summary>
        /// This allows test classes to customise what cache provider to use
        /// </summary>
        public Func<ICacheProvider> CacheProviderSeeder { get; set; }


        public ICacheProvider GetCacheProvider()
        {
            return this.CacheProviderSeeder == null ? new NoCacheProvider() : this.CacheProviderSeeder();
        }

        public void Dispose()
        {
            //Twiddle thumbs
        }
    }
}
