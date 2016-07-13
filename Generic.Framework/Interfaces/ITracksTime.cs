using System;

namespace Generic.Framework.Interfaces
{
    public interface ITracksTime
    {
        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }
    }
}