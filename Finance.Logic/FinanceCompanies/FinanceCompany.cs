using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;

namespace Finance.Logic.FinanceCompanies
{
    public class FinanceCompany : Entity, IName
    {
        [Required]
        public string Name { get; set; }
    }
}
