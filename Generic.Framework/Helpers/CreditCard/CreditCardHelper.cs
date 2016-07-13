using System.Linq;

namespace Generic.Framework.Helpers.CreditCard
{
    public static class CreditCardHelper
    {
        /// <summary>
        /// Returns true if the provided string is a valid credit card number using the Luhn algorithm
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <remarks>See http://www.codeproject.com/Tips/515367/Validate-credit-card-number-with-Mod-10-algorithm</remarks>
        /// <example>A valid example: 4012888888881881</example>
        public static bool CheckIfCreditCardNumberIsValid(string creditCardNumber)
        {
            // check whether input string is null or empty
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            // 1.	Starting with the check digit double the value of every other digit 
            // 2.	If doubling of a number results in a two digits number, add up
            //      the digits to get a single digit number. This will results in eight single digit numbers                    
            // 3. Get the sum of the digits
            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);


            // If the final sum is divisible by 10, then the credit card number
            //   is valid. If it is not divisible by 10, the number is invalid.            
            return sumOfDigits % 10 == 0;
        }
    }
}