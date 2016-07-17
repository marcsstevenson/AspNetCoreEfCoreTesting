using System.ComponentModel.DataAnnotations;
using Finance.Logic.Crm;
using Finance.Logic.FinanceCompanies;
using Finance.Logic.Internal;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Deals
{
    public class Deal : Entity
    {
        /// <summary>
        /// A customer is the person who finances a vehicle
        /// </summary>
        [Required]
        public Customer Customer { get; set; }

        /// <summary>
        /// The number for a given time period (month)
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [Required]
        public int CashManagerReference { get; set; }

        /// <summary>
        /// The staff memeber who is assigned to this deal
        /// </summary>
        public StaffMember AssignedTo { get; set; }

        [Required]
        public DealStatus DealStatus { get; set; }

        /// <summary>
        /// The company that is providing finance for this deal
        /// </summary>
        public FinanceCompany FinanceCompany { get; set; }

        /// <summary>
        /// The dealership that was the source of this deal
        /// </summary>
        /// <remarks>Can be null which would indicate a direct customer sale</remarks>
        public Dealership Source { get; set; }
    }
}
