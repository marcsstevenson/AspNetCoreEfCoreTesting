using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Crm
{
    public class CustomerNote : Entity
    {
        [Required]
        public string Note { get; set; }

        [Required]
        public Customer Deal { get; set; }

        /// <summary>
        /// The name of the person who entered this note
        /// </summary>
        /// <remarks>Can be a staff member, dealership or eventually a customer</remarks>
        public string EnteredBy { get; set; }
    }
}
