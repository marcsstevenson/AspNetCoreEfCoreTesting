using Finance.Repository.EfCore.Context;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Repository.EfCore.Repository
{
    public class StringEntityRepository<T> : EntityRepository<T>, IStringEntityRepository<T>
        where T : class, IStringEntity
    {
        public StringEntityRepository(FinanceDbContext dataContext)
            : base(dataContext)
        {
        }

        public StringEntityRepository()
            : base()
        {
        }

        public override void Add(T entity)
        {
            //Set the Id if empty
            if(string.IsNullOrEmpty(entity.Id))
                entity.SeedId();

            base.Add(entity);
        }

        public virtual void Delete(string id)
        {
            Delete(i => i.Id == id);
        }

        public virtual void Delete(IStringEntity stringEntity)
        {
            Delete(i => i.Id == stringEntity.Id);
        }

        public virtual T FirstOrDefault(string id)
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

            return this.Count(i => i.Id == entity.Id) > 0;
        }
    }
}
