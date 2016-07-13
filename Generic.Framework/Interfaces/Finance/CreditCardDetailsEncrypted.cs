using System.ComponentModel.DataAnnotations;

namespace Generic.Framework.Interfaces.Finance
{
    public interface ICreditCardDetailsEncrypted
    {
        [Required]
        string NameOnCardEncrypted { get; set; }

        [Required]
        string CardNumberEncrypted { get; set; }

        [Required]
        int ExpiryYear { get; set; }

        [Required]
        int ExpiryMonth { get; set; }

        //[Required]
        //int CardVerificationNumber { get; set; }
    }
}
