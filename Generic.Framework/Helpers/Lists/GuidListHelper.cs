using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic.Framework.Helpers.Lists
{
    public static class GuidListHelper
    {
        public static bool HasEqualItems(this List<Guid> list, List<Guid> toCompare)
        {
            if (list.Count != toCompare.Count) return false;

            if(!list.All(toCompare.Contains)) return false;

            if (!toCompare.All(list.Contains)) return false;

            //We got this far
            return true;
        }
    }
}