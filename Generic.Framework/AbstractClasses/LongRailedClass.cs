using System;
using System.ComponentModel.DataAnnotations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class LongRailedClass : RailedNameAndDescription, ILongId
    {
        private long _id;
        [Key]
        public new long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                base.Id = value;
            }
        }
        protected LongRailedClass()
            : base()
        {

        }
    }
}
