using System;
using System.Linq;
using System.Reflection;

namespace Generic.Framework.Helpers.Reflection
{
    public class ComparisionResult
    {
        public readonly bool AreEqual;
        public readonly string Message;

        public ComparisionResult(bool equals = true, string message = "")
        {
            this.AreEqual = equals;
            this.Message = message;
        }

        public override string ToString()
        {
            return this.Message;
        }
    }

    public static class PropertiesHelper
    {
        /// <summary>
        /// Compares all the properties of the "from" object to this object if they exist.
        /// </summary>
        /// <param name="to">The object in which the properties are copied</param>
        /// <param name="from">The object which is used as a source</param>
        /// <param name="excludedProperties">Exclude these properties from the copy</param>
        public static ComparisionResult ObjectPropertiesAreEqual(this object to, object from, params string[] excludedProperties)
        {
            Type targetType = to.GetType();
            Type sourceType = from.GetType();

            PropertyInfo[] sourceProps = sourceType.GetProperties();

            foreach (var toPropInfo in sourceProps)
            {
                //filter the properties
                if (excludedProperties != null && excludedProperties.Contains(toPropInfo.Name))
                    continue;
                PropertyInfo toProp = null;

                //Get the matching property from the target
                try
                {
                    toProp = (targetType == sourceType) ? toPropInfo : targetType.GetProperty(toPropInfo.Name);
                }
                catch (AmbiguousMatchException)
                {
                    //Nothing to see here, move along
                    continue;
                }

                //If it exists and it's writeable
                if (toProp != null)
                {
                    //Copy the value from the source to the target
                    Object toValue = toPropInfo.GetValue(to, null);
                    Object fromValue = toPropInfo.GetValue(from, null);

                    if (toValue == null && fromValue == null) //Both null
                        continue;

                    if (toValue == null || fromValue == null)
                    {
                        return new ComparisionResult(false, string.Format("Property {0} is not a match.", toProp.Name));
                    }

                    if (!toValue.Equals(fromValue))
                    {
                        return new ComparisionResult(false, string.Format("Property {0} is not a match.", toProp.Name));
                    }
                }
            }

            return new ComparisionResult();
        }

        /// <summary>
        /// Copies all the properties of the "from" object to this object if they exist.
        /// </summary>
        /// <param name="to">The object in which the properties are copied</param>
        /// <param name="from">The object which is used as a source</param>
        /// <param name="excludedProperties">Exclude these properties from the copy</param>
        public static void CopyPropertiesFrom(this object to, object from, params string[] excludedProperties)
        {
            Type targetType = to.GetType();
            Type sourceType = from.GetType();

            PropertyInfo[] sourceProps = sourceType.GetProperties();
            foreach (var propInfo in sourceProps)
            {
                //filter the properties
                if (excludedProperties != null && excludedProperties.Contains(propInfo.Name))
                    continue;

                //Get the matching property from the target
                PropertyInfo toProp = (targetType == sourceType) ? propInfo : targetType.GetProperty(propInfo.Name);

                //If it exists and it's writeable
                if (toProp != null && toProp.CanWrite)
                {
                    //Copy the value from the source to the target
                    Object value = propInfo.GetValue(from, null);
                    toProp.SetValue(to, value, null);
                }
            }
        }

        /// <summary>
        /// Copies all the properties of the "from" object to this object if they exist.
        /// </summary>
        /// <param name="to">The object in which the properties are copied</param>
        /// <param name="from">The object which is used as a source</param>
        public static void CopyPropertiesFrom(this object to, object from)
        {
            to.CopyPropertiesFrom(from, null);
        }

        /// <summary>
        /// Copies all the properties of this object to the "to" object
        /// </summary>
        /// <param name="to">The object in which the properties are copied</param>
        /// <param name="from">The object which is used as a source</param>
        public static void CopyPropertiesTo(this object from, object to)
        {
            to.CopyPropertiesFrom(from, null);
        }

        /// <summary>
        /// Copies all the properties of this object to the "to" object
        /// </summary>
        /// <param name="to">The object in which the properties are copied</param>
        /// <param name="from">The object which is used as a source</param>
        /// <param name="excludedProperties">Exclude these properties from the copy</param>
        public static void CopyPropertiesTo(this object from, object to, string[] excludedProperties)
        {
            to.CopyPropertiesFrom(from, excludedProperties);
        }
    }
}
