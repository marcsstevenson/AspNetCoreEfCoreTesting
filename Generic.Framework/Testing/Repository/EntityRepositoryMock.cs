using System;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Testing.Repository
{
    public class EntityRepositoryMock<T> : RepositoryMock<T>, IEntityRepository<T> //IDisposable
        where T : class, IEntity
    {
    }
}
