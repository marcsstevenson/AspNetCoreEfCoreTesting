using Generic.Framework.Enumerations;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IIntEntityRepository<T> : IRepository<T> where T : class, IIntEntity
    {
        bool Exists(T entity);
        CommitAction Save(T entity);
    }
}
