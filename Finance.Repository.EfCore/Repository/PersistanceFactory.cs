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

        //public PersistanceFactory()
        //{
        //    _dataContext = new FinanceDbContext();
        //}

        public PersistanceFactory(FinanceDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        protected FinanceDbContext DataContext => _dataContext;

        public IEntityRepository<T> BuildEntityRepository<T>() where T : class, IEntity
        {
            return new EntityRepository<T>(this.DataContext);
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
