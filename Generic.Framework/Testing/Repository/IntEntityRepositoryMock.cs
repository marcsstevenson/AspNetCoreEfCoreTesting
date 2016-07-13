using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Entity;
using Generic.Framework.Testing.Repository;

namespace ER.Fyndit.Repository.Testing.Mocking
{
    public class IntEntityRepositoryMock<T> : EntityRepositoryMock<T>, IIntEntityRepository<T>
        where T : class, IIntEntity
    {
        public IntEntityRepositoryMock() : base()
        {
        }

        public IntEntityRepositoryMock(RepositoryMock<T> repositoryMock)
            : base()
        {
            this._dbSet = repositoryMock.DbSet;
        }

        /// <summary>
        /// Saves the the state of the entity to be modified or created
        /// </summary>
        /// <param name="entity"></param>
        public virtual CommitAction Save(T entity)
        {
            if (this.Exists(entity))
            {
                this.Update(entity);
                return CommitAction.Update;
            }
            else
            {
                this.Add(entity);
                return CommitAction.Add;
            }
        }

        public virtual bool Exists(T entity)
        {
            if (entity == null)
                return false;

            return this.FirstOrDefault(i => i.Id == entity.Id) != null;
        }
    }
}
