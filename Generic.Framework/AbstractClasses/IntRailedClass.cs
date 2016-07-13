using System;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class IntRailedClass : RailedNameAndDescription, IIntId
    {
        public new int Id { get; set; }

        protected IntRailedClass()
            : base()
        {

        }
    }
}
