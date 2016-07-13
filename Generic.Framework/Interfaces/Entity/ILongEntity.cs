namespace Generic.Framework.Interfaces.Entity
{
    public interface ILongEntity : ITracksTime, ILongId, IEntity
    {
        new long Id { get; set; }
    }
}