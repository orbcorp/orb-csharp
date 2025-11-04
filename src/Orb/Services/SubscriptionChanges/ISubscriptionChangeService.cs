using System;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.SubscriptionChanges;

namespace Orb.Services.SubscriptionChanges;

public interface ISubscriptionChangeService
{
    ISubscriptionChangeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint returns a subscription change given an identifier.
    ///
    /// A subscription change is created by including `Create-Pending-Subscription-Change:
    /// True` in the header of a subscription mutation API call (e.g. [create subscription
    /// endpoint](/api-reference/subscription/create-subscription), [schedule plan
    /// change endpoint](/api-reference/subscription/schedule-plan-change), ...).
    /// The subscription change will be referenced by the `pending_subscription_change`
    /// field in the response.
    /// </summary>
    Task<SubscriptionChangeRetrieveResponse> Retrieve(SubscriptionChangeRetrieveParams parameters);

    /// <summary>
    /// Apply a subscription change to perform the intended action. If a positive
    /// amount is passed with a request to this endpoint, any eligible invoices that
    /// were created will be issued immediately if they only contain in-advance fees.
    /// </summary>
    Task<SubscriptionChangeApplyResponse> Apply(SubscriptionChangeApplyParams parameters);

    /// <summary>
    /// Cancel a subscription change. The change can no longer be applied. A subscription
    /// can only have one "pending" change at a time - use this endpoint to cancel
    /// an existing change before creating a new one.
    /// </summary>
    Task<SubscriptionChangeCancelResponse> Cancel(SubscriptionChangeCancelParams parameters);
}
