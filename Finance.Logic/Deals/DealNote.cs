using System.ComponentModel.DataAnnotations;
using Finance.Logic.Internal;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Deals
{
    public class DealNote : Entity
    {
        [Required]
        public string Note { get; set; }

        [Required]
        public Deal Deal { get; set; }

        /// <summary>
        /// The name of the person who entered this note
        /// </summary>
        /// <remarks>Can be a staff member, dealership or eventually a customer</remarks>
        public string EnteredBy { get; set; }
    }
}
