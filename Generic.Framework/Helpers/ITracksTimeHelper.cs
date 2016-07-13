using System.Collections.Generic;
using System.Linq;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers
{
    public static class ITracksTimeHelper
    {
        public static void SetForCreated(this ITracksTime tracksTime)
        {
            tracksTime.DateCreated = Clock.Now();
            tracksTime.DateModified = Clock.Now();
        }

        public static void SetForModified(this ITracksTime tracksTime)
        {
            tracksTime.DateModified = Clock.Now();
        }
    }
}
