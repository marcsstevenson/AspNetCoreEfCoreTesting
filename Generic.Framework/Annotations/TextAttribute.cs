using System;

namespace Generic.Framework.Annotations
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class TextAttribute : Attribute
    {
        private readonly string _text;
        /// <summary>
        /// Gets the description stored in this attribute.
        /// </summary>
        /// <value>The description stored in the attribute.</value>
        public string Text
        {
            get
            {
                return this._text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// </summary>
        /// <param name="description">The description to store in this attribute.</param>
        public TextAttribute(string description)
            : base()
        {
            this._text = description;
        }
    }
}