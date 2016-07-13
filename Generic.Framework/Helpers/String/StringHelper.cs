using System;

namespace Generic.Framework.Helpers.String
{
    public static class StringHelper
    {
        public static bool EqualIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string str, string strToFind)
        {
            return str.StartsWith(strToFind, StringComparison.OrdinalIgnoreCase);
        }
    }
}