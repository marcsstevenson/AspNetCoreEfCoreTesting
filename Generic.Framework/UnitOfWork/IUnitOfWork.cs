using System;
using Generic.Framework.Helpers;

namespace Generic.Framework.UnitOfWork
{
    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
     
        #region Methods

        /// <summary>
        /// Saves the changes inside the unit of work, optionally using a transaction
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        CommitResult Commit(Action action);

        #endregion
    }
}
