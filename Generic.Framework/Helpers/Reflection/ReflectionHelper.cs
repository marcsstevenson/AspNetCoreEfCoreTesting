using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Generic.Framework.Helpers.Reflection
{
    public static class ReflectionHelper
    { /// <summary>
        /// Returns that name of a class property as a string using Linq
        /// </summary>
        /// <param name="expression">The property to return the name of via a delegate</param>
        /// <returns>The name of a class property as a string</returns>
        /// <example>
        /// string name = ReflectionHelper.GetPropertyName(() => new PromoCode().Foo);
        /// </example>
        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            return GetPropertyName(expression, 1);
        }

        // <summary>
        /// Returns that name of a class property and optionally it's parent property(s) as a string using Linq
        /// </summary>
        /// <param name="expression">The property to return the name of via a delegate</param>
        /// <param name="levels">The number of levels up the object tree to print out.</param>
        /// <remarks>Usage: </remarks>
        /// <returns>The name of a class property as a string</returns>
        /// <example>
        /// string name = ReflectionHelper.GetPropertyName(() => new PromoCode().Foo);
        /// </example>
        public static string GetPropertyName<T>(Expression<Func<T>> expression, int levels)
        {
            return GetPropertyName(expression, levels, '.');
        }

        public static string GetPropertyName<T>(Expression<Func<T>> expression, int levels, char separator)
        {
            var body = (MemberExpression)expression.Body;
            string propertyName = body.Member.Name;

            MemberExpression exp = body;
            while (levels > 1)
            {
                if (exp.Expression is MemberExpression)
                    exp = (MemberExpression)exp.Expression;
                else
                    throw new ArgumentException("Too many levels defined.", "levels");

                propertyName = exp.Member.Name + separator + propertyName;
                levels--;
            }

            return propertyName;
        }

        //public static string GetPropertyNamesDelimited<T>(List<Expression<Func<T>>> expressions, string deliminator)
        //{
        //    string names = string.Empty;

        //    foreach (var expression in expressions)
        //    {
        //        names += GetPropertyName(expression);

        //        //Delimit if we're not on the last item
        //        if(expression != expressions.Last())
        //            names += deliminator;
        //    }

        //    return names;
        //}

        public static T GetAttribute<T>(this MemberInfo member, bool isRequired) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The {0} attribute must be defined on member {1}",
                        typeof(T).Name,
                        member.Name));
            }

            return (T)attribute;
        }

        public static string GetPropertyDisplayName<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression.Body);
            if (memberInfo == null)
            {
                throw new ArgumentException(
                    "No property reference expression was found.",
                    "propertyExpression");
            }

            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);
            if (attr == null)
            {
                return memberInfo.Name;
            }

            return attr.DisplayName;
        }

        public static MemberInfo GetPropertyInformation(Expression propertyExpression)
        {
            Debug.Assert(propertyExpression != null, "propertyExpression != null");
            MemberExpression memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member;
            }

            return null;
        }

        public static Type[] GetImplements<T>()
        {
            return typeof (T).GetInterfaces();
        }

        /// <summary>
        /// If class T implements class or interface I
        /// </summary>
        /// <typeparam name="T">The class to test</typeparam>
        /// <typeparam name="I">The class or interface to test the implementation of</typeparam>
        /// <returns>Returns true if T : I</returns>
        public static bool DoesImplement<T, I>()
        {
            return typeof(T).GetInterfaces().Contains(typeof(I));
        }
    }

}
