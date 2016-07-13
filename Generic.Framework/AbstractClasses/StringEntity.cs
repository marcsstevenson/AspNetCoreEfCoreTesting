using System;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class StringEntity : Entity, IStringEntity
    {
        public new string Id { get; set; }

        public new bool Equals(IId id)
        {
            return this.Id == id.Id;
        }

        protected StringEntity()
            : base()
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
