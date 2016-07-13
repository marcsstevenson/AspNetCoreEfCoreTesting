using System;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class GuidEntity : Entity, IGuidEntity
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

        public new bool Equals(IId id)
        {
            return this.Id == id.Id;
        }

        protected GuidEntity() : base()
        {
            this.SeedId();
        }

        dynamic IId.Id
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
