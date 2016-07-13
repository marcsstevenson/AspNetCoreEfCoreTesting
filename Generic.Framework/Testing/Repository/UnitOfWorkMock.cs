using Generic.Framework.Helpers;
using Generic.Framework.UnitOfWork;
using System;

namespace Generic.Framework.Testing.Repository
{
    public class UnitOfWorkMock : IUnitOfWork
    {

        public CommitResult Commit(Action action)
        {
            try
            { 
                action();

                return new CommitResult();
            }
            catch (Exception e)
            {
                return new CommitResult(e);
            }
        }

        public void Dispose()
        {
            //Twiddle thumbs
        }
    }
}
