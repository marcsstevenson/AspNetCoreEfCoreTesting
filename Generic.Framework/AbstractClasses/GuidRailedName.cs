using System;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class GuidRailedName : RailedName, IGuidEntity
    {
        private Guid _id;
        public new Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                base.Id = value;
            }
        }

        //public new Guid Id { get; set; }

        protected GuidRailedName()
            : base()
        {

        }
    }
}
