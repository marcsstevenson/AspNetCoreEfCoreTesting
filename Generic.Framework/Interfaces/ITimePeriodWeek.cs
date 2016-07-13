using System;

namespace Generic.Framework.Interfaces
{
    public interface ITimePeriodWeek : ITimePeriod
    {
        bool IsCurrent { get; set; }

        int WeekNumber { get; set; }
    }
}