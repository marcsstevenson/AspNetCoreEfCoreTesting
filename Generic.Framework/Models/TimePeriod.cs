using System;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Models
{
    public class TimePeriod : ITimePeriod
    {
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
    }
}