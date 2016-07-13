using System;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class GuidRailedNameAndDescription : RailedNameAndDescription, IGuidEntity
    {
        public new Guid Id { get; set; }

        protected GuidRailedNameAndDescription()
            : base()
        {

        }
    }
}
