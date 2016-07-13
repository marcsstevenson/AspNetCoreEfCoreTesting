using System.ComponentModel.DataAnnotations;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class IntEntity : Entity, IIntEntity
    {
        private int _id;
        [Key]
        public new int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                base.Id = value;
            }
        }

        protected IntEntity()
            : base()
        {

        }
    }
}
