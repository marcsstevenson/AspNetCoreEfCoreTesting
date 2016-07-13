using Finance.Repository.EfCore.Context;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Repository.EfCore.Repository
{
    public class IntEntityRepository<T> : EntityRepository<T>, IIntEntityRepository<T>
        where T : class, IIntEntity
    {
        public IntEntityRepository(FinanceDbContext dataContext)
            : base(dataContext)
        {
        }

        public IntEntityRepository() : base()
        {
        }
        
        public virtual void Delete(int id)
        {
            Delete(i => i.Id == id);
        }
        
        public virtual T FirstOrDefault(int id)
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

            return this.FirstOrDefault(i => i.Id == entity.Id) != null;
        }
    }
}
