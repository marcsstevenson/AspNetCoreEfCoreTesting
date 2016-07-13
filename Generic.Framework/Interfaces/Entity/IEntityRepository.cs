using System;
using System.Linq;
using System.Linq.Expressions;
using Generic.Framework.Enumerations;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IEntityRepository<T> : IRepository<T> where T : class, IEntity
    {
        bool Exists(T entity);
        CommitAction Save(T entity);
        void Delete(Guid id);
        void Delete(IEntity guidEntity);
    }
}
