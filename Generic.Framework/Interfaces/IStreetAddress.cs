using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Interfaces
{
    public interface IStreetAddress : IRegion
    {
        /// <summary>
        /// The name of the address. Eg: "work" or "Bob Smith"
        /// </summary>
        string FullName { get; set; }

        /// <summary>
        /// A phone number so we can that can be called if there are any problems using this address.
        /// </summary>
        string ContactPhoneNumber { get; set; }

        /// <summary>
        /// Street address, P.O. box, company name, c/o
        /// </summary>
        string AddressLine1 { get; set; }

        /// <summary>
        /// Apartment, suite, unit, building, floor, etc.
        /// </summary>
        string AddressLine2 { get; set; }

        /// <summary>
        /// Other information such as suburb
        /// </summary>
        string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the code used to identify a geographic area.
        /// </summary>
        string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
//        IGuidEntity Country { get; set; }
        
        /// <summary>
        /// Gets or sets if the code is the default postal address.
        /// </summary>
        bool IsDefault { get; set; }

        /// <summary>
        /// The type of the address, egs, billing or delivery
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Information that may be required such as "look out for dog" or "blue door up the stairs" or security access code for gated communities
        /// </summary>
        string OtherInformation { get; set; }
    }
}