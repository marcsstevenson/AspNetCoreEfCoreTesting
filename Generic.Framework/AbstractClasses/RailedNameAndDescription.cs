using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.AbstractClasses
{
    public abstract class RailedNameAndDescription : RailedName, IRailedNameAndDescription
    {
        public string Description { get; set; }

        protected RailedNameAndDescription() : base()
        {
            
        }
    }
}
