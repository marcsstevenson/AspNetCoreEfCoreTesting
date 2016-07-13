using System.Collections.Generic;
using System.Linq;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers
{
    public static class IsDefaultHelper
    {
        /// <summary>
        /// Sets the new default item in a list of IIsDefault items
        /// </summary>
        /// <typeparam name="T">The IIsDefault item</typeparam>
        /// <param name="list">The list of IIsDefault items</param>
        /// <param name="newDefault">The new default</param>
        /// <returns>A list of items that has been modified</returns>
        public static List<T> SetDefault<T>(this IEnumerable<T> list, T newDefault) where T : class, IIsDefault
        {
            var modified = new List<T>();

            if (newDefault == null)
                return modified;

            foreach (var isDefaultItem in list.Where(isDefaultItem => isDefaultItem.IsDefault && !isDefaultItem.Equals(newDefault)))
            {
                modified.Add(isDefaultItem);
                isDefaultItem.IsDefault = false;
            }

            if (!newDefault.IsDefault)
            {
                modified.Add(newDefault);
                newDefault.IsDefault = true;
            }

            return modified;
        }

        /// <summary>
        /// Returns true if the list has one and only one IsDefault item
        /// </summary>
        /// <typeparam name="T">The IIsDefault item</typeparam>
        /// <param name="list">The list of IIsDefault items</param>
        /// <returns>Returns true if the list has one and only one IsDefault item</returns>
        public static bool IsValidDefaultList<T>(this IEnumerable<T> list) where T : class, IIsDefault
        {
            list = list.ToList(); //ToList to prevent any multiple enumeration problems
            return list.Any(i => i.IsDefault) && list.Count(i => i.IsDefault) == 1;
        }
    }
}
