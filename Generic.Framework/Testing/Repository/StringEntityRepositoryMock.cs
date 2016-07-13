using System;
using System.Collections.Generic;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Testing.Repository
{
    public class StringEntityRepositoryMock<T> : EntityRepositoryMock<T>, IStringEntityRepository<T>
        where T : class, IStringEntity
    {
        public StringEntityRepositoryMock()
            : base()
        {
        }

        public StringEntityRepositoryMock(IList<T> dbSet)
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

        public void Delete(String id)
        {
            this.Delete(i => i.Id == id);
        }

        public void Delete(IStringEntity stringEntity)
        {
            this.Delete(i => i.Id == stringEntity.Id);
        }

        public virtual bool Exists(T entity)
        {
            if (entity == null)
                return false;

            return this.FirstOrDefault(i => i.Id == entity.Id) != null;
        }
    }
}
