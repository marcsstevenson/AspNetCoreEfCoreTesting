using System;
using System.Linq;
using Finance.Repository.EfCore.Context;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Repository.EfCore.Repository
{
    public class GuidEntityRepository<T> : EntityRepository<T>, IGuidEntityRepository<T>
        where T : class, IGuidEntity
    {
        public GuidEntityRepository(FinanceDbContext dataContext)
            : base(dataContext)
        {
        }

        public GuidEntityRepository()
            : base()
        {
        }

        public override void Add(T entity)
        {
            //Set the Id if empty
            if (entity.Id == Guid.Empty)
                entity.SeedId();

            base.Add(entity);
        }

        public virtual void Delete(Guid id)
        {
            Delete(i => i.Id == id);
        }

        public virtual void Delete(IGuidEntity guidEntity)
        {
            Delete(i => i.Id == guidEntity.Id);
        }

        public virtual T FirstOrDefault(Guid id)
        {
            return base.FirstOrDefault(i => i.Id == id);
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

            var count = this.Where(i => i.Id == entity.Id).Select(i => i.Id).Count();
            return count > 0;
        }
    }
}
