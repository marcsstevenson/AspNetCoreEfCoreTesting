using System;

namespace Generic.Framework.Interfaces.Entity
{
    public interface IStringEntity : ITracksTime, IStringId, IEntity
    {
        new String Id { get; set; }
    }
}