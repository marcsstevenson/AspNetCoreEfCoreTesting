using System;

namespace Generic.Framework.Interfaces
{
    public interface ITimePeriod
    {
        DateTime FirstDay { get; set; }

        DateTime LastDay { get; set; } 
    }
}