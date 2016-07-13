namespace Generic.Framework.Interfaces.Entity
{
    public interface IIntEntity : ITracksTime, IIntId, IEntity
    {
        new int Id { get; set; }
    }
}