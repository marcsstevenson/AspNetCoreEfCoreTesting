using System;
using System.Collections.Generic;

namespace Generic.Framework.Helpers.Randomness
{
    public static class RandomCollectionHelper
    {
        private static Random _random;
        private static Random Random
        {
            get { return _random ?? (_random = new Random()); }
        }

        public static T GetRandomItem<T>(this IList<T> collection, Random random = null)
        {
            return collection[(random ?? Random).Next(0, collection.Count - 1)];
        }
    }
}