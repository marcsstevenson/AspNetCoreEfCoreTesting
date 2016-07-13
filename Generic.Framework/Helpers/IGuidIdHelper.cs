using System;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers
{
    public static class IGuidIdHelper
    {
        public static void SeedId(this IGuidId guidId)
        {
            guidId.Id = GuidComb.Generate();
        }

        public static bool IsSameId(this IGuidId guidId, Guid? id)
        {
            if (guidId == null)
            {
                return !id.HasValue;
            }
            else
            {
                return guidId.Id == id;
            }
        }
    }
}
