using System.ComponentModel.DataAnnotations;

namespace Generic.Framework.Interfaces.Finance
{
    public interface ICreditCardDetails
    {
        [Required]
        string NameOnCard { get; set; }

        [Required]
        string CardNumber { get; set; }

        [Required]
        int ExpiryYear { get; set; }

        [Required]
        int ExpiryMonth { get; set; }

        //[Required]
        //int CardVerificationNumber { get; set; }
    }
}
