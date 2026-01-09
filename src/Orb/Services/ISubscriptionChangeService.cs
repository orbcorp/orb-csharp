using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.SubscriptionChanges;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubscriptionChangeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubscriptionChangeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionChangeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint returns a subscription change given an identifier.
    ///
    /// <para>A subscription change is created by including `Create-Pending-Subscription-Change:
    /// True` in the header of a subscription mutation API call (e.g. [create subscription
    /// endpoint](/api-reference/subscription/create-subscription), [schedule plan
    /// change endpoint](/api-reference/subscription/schedule-plan-change), ...).
    /// The subscription change will be referenced by the `pending_subscription_change`
    /// field in the response.</para>
    /// </summary>
    Task<SubscriptionChangeRetrieveResponse> Retrieve(
        SubscriptionChangeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionChangeRetrieveParams, CancellationToken)"/>
    Task<SubscriptionChangeRetrieveResponse> Retrieve(
        string subscriptionChangeID,
        SubscriptionChangeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of pending subscription changes for a customer.
    /// Use the [Fetch Subscription Change](fetch-subscription-change) endpoint to
    /// retrieve the expected subscription state after the pending change is applied.
    /// </summary>
    Task<SubscriptionChangeListPage> List(
        SubscriptionChangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Apply a subscription change to perform the intended action. If a positive
    /// amount is passed with a request to this endpoint, any eligible invoices that
    /// were created will be issued immediately if they only contain in-advance fees.
    /// </summary>
    Task<SubscriptionChangeApplyResponse> Apply(
        SubscriptionChangeApplyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Apply(SubscriptionChangeApplyParams, CancellationToken)"/>
    Task<SubscriptionChangeApplyResponse> Apply(
        string subscriptionChangeID,
        SubscriptionChangeApplyParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a subscription change. The change can no longer be applied. A subscription
    /// can only have one "pending" change at a time - use this endpoint to cancel
    /// an existing change before creating a new one.
    /// </summary>
    Task<SubscriptionChangeCancelResponse> Cancel(
        SubscriptionChangeCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SubscriptionChangeCancelParams, CancellationToken)"/>
    Task<SubscriptionChangeCancelResponse> Cancel(
        string subscriptionChangeID,
        SubscriptionChangeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubscriptionChangeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubscriptionChangeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionChangeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /subscription_changes/{subscription_change_id}`, but is otherwise the
    /// same as <see cref="ISubscriptionChangeService.Retrieve(SubscriptionChangeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionChangeRetrieveResponse>> Retrieve(
        SubscriptionChangeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionChangeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionChangeRetrieveResponse>> Retrieve(
        string subscriptionChangeID,
        SubscriptionChangeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /subscription_changes`, but is otherwise the
    /// same as <see cref="ISubscriptionChangeService.List(SubscriptionChangeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionChangeListPage>> List(
        SubscriptionChangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /subscription_changes/{subscription_change_id}/apply`, but is otherwise the
    /// same as <see cref="ISubscriptionChangeService.Apply(SubscriptionChangeApplyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionChangeApplyResponse>> Apply(
        SubscriptionChangeApplyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Apply(SubscriptionChangeApplyParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionChangeApplyResponse>> Apply(
        string subscriptionChangeID,
        SubscriptionChangeApplyParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /subscription_changes/{subscription_change_id}/cancel`, but is otherwise the
    /// same as <see cref="ISubscriptionChangeService.Cancel(SubscriptionChangeCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionChangeCancelResponse>> Cancel(
        SubscriptionChangeCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SubscriptionChangeCancelParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionChangeCancelResponse>> Cancel(
        string subscriptionChangeID,
        SubscriptionChangeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
