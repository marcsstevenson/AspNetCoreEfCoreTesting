using System;
using System.Diagnostics;

namespace Generic.Framework.Helpers
{
    public static class Clock
    {
        private static Func<DateTime> now = () => DateTime.UtcNow;

        public static Func<DateTime> Now
        {
            [DebuggerStepThrough]
            get { return now; }

            [DebuggerStepThrough]
            set
            {
                now = value;
            }
        }

        public static void Reset()
        {
            now = () => DateTime.UtcNow;
        }
    }
}
