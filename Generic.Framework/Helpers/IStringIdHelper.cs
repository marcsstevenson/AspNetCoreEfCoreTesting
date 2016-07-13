using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers
{
    public static class IStringIdHelper
    {
        public static void SeedId(this IStringId guidId)
        {
            guidId.Id = GuidComb.Generate().ToString();
        }
    }
}
