using System;

namespace Generic.Framework.Annotations
{
    /// <summary>
    /// Provides an associated class name for an enumerated type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class AssociatedClassNameAttribute : Attribute
    {
        private readonly string _className;

        /// <summary>
        /// Gets the description stored in this attribute.
        /// </summary>
        /// <value>The description stored in the attribute.</value>
        public string ClassName
        {
            get
            {
                return this._className;
            }
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// </summary>
        /// <param name="className">The description to store in this attribute.</param>
        public AssociatedClassNameAttribute(string className)
            : base()
        {
            this._className = className;
        }
    }
}