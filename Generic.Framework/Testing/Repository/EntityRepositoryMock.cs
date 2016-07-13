using System;
using System.Collections.Generic;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Testing.Repository
{
    public class EntityRepositoryMock<T> : RepositoryMock<T>, IEntityRepository<T> //IDisposable
        where T : class, IEntity
    {
        public EntityRepositoryMock()
            : base()
        {
        }

        public EntityRepositoryMock(IList<T> dbSet)
            : base()
        {
            this._dbSet = dbSet;
        }

        /// <summary>
        /// Saves the the state of the entity to be modified or created
        /// </summary>
        /// <param name="entity"></param>
        public virtual CommitAction Save(T entity)
        {
            if (entity.Id != Guid.Empty && this.Exists(entity))
            {
                this.Update(entity);
                return CommitAction.Update;
            }
            else
            {
                if (entity.Id == Guid.Empty)
                    entity.Id = GuidComb.Generate();

                this.Add(entity);
                return CommitAction.Add;
            }
        }

        public void Delete(Guid id)
        {
            this.Delete(i => i.Id == id);
        }

        public void Delete(IEntity guidEntity)
        {
            this.Delete(i => i.Id == guidEntity.Id);
        }

        public virtual bool Exists(T entity)
        {
            if (entity == null)
                return false;

            return this.FirstOrDefault(i => i.Id == entity.Id) != null;
        }
    }
}
