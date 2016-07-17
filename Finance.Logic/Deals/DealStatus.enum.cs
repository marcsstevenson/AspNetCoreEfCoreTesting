using System.ComponentModel;

namespace Finance.Logic.Deals
{
    /// <summary>
    /// The status of a deal
    /// </summary>
    public enum DealStatus
    {
        [Description("Settled /Paid")]
        SettledPaid,

        [Description("Settled Awaiting Commission")]
        SettledAwaitingCommission,

        [Description("Pending Sign Up")]
        PendingSignUp,

        [Description("Pending Payout")]
        PendingPayout
    }
}
