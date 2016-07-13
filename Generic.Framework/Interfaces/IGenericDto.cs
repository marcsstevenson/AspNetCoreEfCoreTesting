using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Interfaces
{
    public interface IGenericDto<E> where E : IEntity
    {
        E ToEntity();
        void UpdateEntity(E entity);
    }
}