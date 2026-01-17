using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons.Subscriptions;

namespace Orb.Services.Coupons;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint returns a list of all subscriptions that have redeemed a given
    /// coupon as a [paginated](/api-reference/pagination) list, ordered starting
    /// from the most recently created subscription. For a full discussion of the
    /// subscription resource, see [Subscription](/core-concepts#subscription).
    /// </summary>
    Task<SubscriptionListPage> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SubscriptionListParams, CancellationToken)"/>
    Task<SubscriptionListPage> List(
        string couponID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /coupons/{coupon_id}/subscriptions`, but is otherwise the
    /// same as <see cref="ISubscriptionService.List(SubscriptionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionListPage>> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SubscriptionListParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionListPage>> List(
        string couponID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
