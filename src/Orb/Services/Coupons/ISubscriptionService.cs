using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons.Subscriptions;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Services.Coupons;

public interface ISubscriptionService
{
    global::Orb.Services.Coupons.ISubscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// This endpoint returns a list of all subscriptions that have redeemed a given
    /// coupon as a [paginated](/api-reference/pagination) list, ordered starting
    /// from the most recently created subscription. For a full discussion of the
    /// subscription resource, see [Subscription](/core-concepts#subscription).
    /// </summary>
    Task<Subscriptions::SubscriptionsModel> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    );
}
