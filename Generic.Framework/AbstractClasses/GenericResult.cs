using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers.ExceptionHanlding;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class GenericResult
    {
        protected GenericResult()
        {
        }

        protected GenericResult(Exception e)
            : this()
        {
            this.Error = e;
        }

        [XmlIgnore]
        public Exception Error { get; set; }
        public bool HasError { get{return this.Error != null;} }
        public string ErrorMessage { get { return this.Error != null ? this.Error.GetInnerMostException().Message : string.Empty; } }
    }
}
