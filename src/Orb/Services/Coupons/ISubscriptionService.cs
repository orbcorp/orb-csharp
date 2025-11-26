using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons.Subscriptions;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Services.Coupons;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Orb.Services.Coupons.ISubscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// This endpoint returns a list of all subscriptions that have redeemed a given
    /// coupon as a [paginated](/api-reference/pagination) list, ordered starting
    /// from the most recently created subscription. For a full discussion of the
    /// subscription resource, see [Subscription](/core-concepts#subscription).
    /// </summary>
    Task<Subscriptions::SubscriptionSubscriptions> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SubscriptionListParams, CancellationToken)"/>
    Task<Subscriptions::SubscriptionSubscriptions> List(
        string couponID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
