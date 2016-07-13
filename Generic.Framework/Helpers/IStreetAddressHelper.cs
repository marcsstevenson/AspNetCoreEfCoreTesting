using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers
{
    public static class IStreetAddressHelper
    {
        public static bool HaveSameValues(this IStreetAddress from, IStreetAddress to)
        {
            if (from.FullName != to.FullName) return false;
            if (from.ContactPhoneNumber != to.ContactPhoneNumber) return false;
            if (from.AddressLine1 != to.AddressLine1) return false;
            if (from.AddressLine2 != to.AddressLine2) return false;
            if (from.AddressLine3 != to.AddressLine3) return false;
            if (from.Postcode != to.Postcode) return false;
            if (from.City != to.City) return false;
            if (from.IsDefault != to.IsDefault) return false;
            if (from.Type != to.Type) return false;
            if (from.OtherInformation != to.OtherInformation) return false;

            return true;
        }
    }
}