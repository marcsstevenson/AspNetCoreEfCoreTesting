using System;
using System.Linq;
using System.Linq.Expressions;
using Generic.Framework.Enumerations;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IStringEntityRepository<T> : IRepository<T> where T : class, IStringEntity
    {
        bool Exists(T entity);
        CommitAction Save(T entity);
        void Delete(string id);
        void Delete(IStringEntity guidEntity);
    }
}
