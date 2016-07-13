using System;
using Generic.Framework.Helpers;
using Generic.Framework.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Generic.Repository.EfCore.UnitOfWork
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            dbContext.ChangeTracker.AcceptAllChanges();
        }
        
        protected ChangeTracker ChangeTracker => _dbContext.ChangeTracker;

        public CommitResult Commit(Action action)
        {
            try
            {
                action();

                this._dbContext.SaveChanges(true);
                //ChangeTracker.AcceptAllChanges();

                return new CommitResult();
            }
            catch (Exception e)
            {
                return new CommitResult(e);
            }
        }

        public new void Dispose()
        {
            _dbContext.Dispose();
            base.Dispose();
        }
    }
}
