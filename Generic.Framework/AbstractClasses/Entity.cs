using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class Entity : IEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Guid Id { get; set; }

        public bool Equals(IGuidId id)
        {
            return this.Id == id.Id;
        }

        protected Entity()
        {
            this.SetForCreated();
        }
    }
}
