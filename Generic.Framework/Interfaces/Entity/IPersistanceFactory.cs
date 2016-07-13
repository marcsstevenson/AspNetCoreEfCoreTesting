using System;
using Generic.Framework.UnitOfWork;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IPersistanceFactory// : IDisposable
    {
        IEntityRepository<T> BuildEntityRepository<T>() where T : class, IEntity;
        IUnitOfWork BuildUnitOfWork();
        ICacheProvider GetCacheProvider();
    }
}
