using System;
using System.Linq;
using System.Linq.Expressions;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IEntityRepository<T> : IRepository<T> where T : class, IEntity
    {
    }
}
