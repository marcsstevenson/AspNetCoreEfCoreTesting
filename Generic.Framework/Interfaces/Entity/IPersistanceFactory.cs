using System;
using Generic.Framework.UnitOfWork;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IPersistanceFactory// : IDisposable
    {
        IRepository<T> BuildRepository<T>() where T : class, IEntity;
        //IRepositoryAsync<T> BuildRepositoryAsync<T>() where T : class, IEntity;
        IGuidEntityRepository<T> BuildGuidEntityRepository<T>() where T : class, IGuidEntity;
        //IGuidEntityRepositoryAsync<T> BuildGuidEntityRepositoryAsync<T>() where T : class, IGuidEntity;
        IIntEntityRepository<T> BuildIntEntityRepository<T>() where T : class, IIntEntity;
        IStringEntityRepository<T> BuildStringEntityRepository<T>() where T : class, IStringEntity;
        IUnitOfWork BuildUnitOfWork();
        ICacheProvider GetCacheProvider();
    }
}
