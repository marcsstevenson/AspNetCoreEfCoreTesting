using System.ComponentModel.DataAnnotations;

namespace Generic.Framework.Interfaces.Finance
{
    public interface IBankAccountDetails
    {
        [Required]
        string BankingCompany { get; set; }

        [Required]
        string BankAccountName { get; set; }

        [Required]
        string BankBranchName { get; set; }

        [Required]
        string BankAccountNumber { get; set; } 
    }
}
