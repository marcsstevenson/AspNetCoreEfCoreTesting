using System;

namespace Generic.Framework.Interfaces
{
    public interface ITimePeriodNullable
    {
        DateTime? FirstDay { get; set; }

        DateTime? LastDay { get; set; }
    }
}