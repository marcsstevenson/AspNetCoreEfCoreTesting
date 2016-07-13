using System.Collections.Generic;

namespace Generic.Framework.Testing.Repository
{
    public interface IRepositoryMock<T>
    {
        void SetData(IList<T> dbSet);
        IList<T> GetData();
    }
}