using Finance.Repository.EfCore.Context;
using Generic.Framework.Caching.Providers;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;
using Generic.Framework.UnitOfWork;
using Generic.Repository.EfCore.UnitOfWork;

namespace Finance.Repository.EfCore.Repository
{
    public class PersistanceFactory : IPersistanceFactory
    {
        protected FinanceDbContext _dataContext;

        public PersistanceFactory()
        {
            _dataContext = new FinanceDbContext();
        }
        
        protected FinanceDbContext DataContext => _dataContext;

        public IRepository<T> BuildRepository<T>() where T : class, IEntity
        {
            return new EntityRepository<T>(this.DataContext);
        }
        
        public IGuidEntityRepository<T> BuildGuidEntityRepository<T>() where T : class, IGuidEntity
        {
            return new GuidEntityRepository<T>(this.DataContext);
        }
        
        public IIntEntityRepository<T> BuildIntEntityRepository<T>() where T : class, IIntEntity
        {
            return new IntEntityRepository<T>(this.DataContext);
        }

        public IStringEntityRepository<T> BuildStringEntityRepository<T>() where T : class, IStringEntity
        {
            return new StringEntityRepository<T>(this.DataContext);
        }

        public IUnitOfWork BuildUnitOfWork()
        {
            return new UnitOfWork(this.DataContext);
        }

        public ICacheProvider GetCacheProvider()
        {
            return new InMemoryCacheProvider();
        }
    }
}
