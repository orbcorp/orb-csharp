using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons;
using Coupons = Orb.Services.Coupons;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICouponService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICouponServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICouponService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Coupons::ISubscriptionService Subscriptions { get; }

    /// <summary>
    /// This endpoint allows the creation of coupons, which can then be redeemed
    /// at subscription creation or plan change.
    /// </summary>
    Task<Coupon> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all coupons for an account in a list format.
    ///
    /// <para>The list of coupons is ordered starting from the most recently created
    /// coupon. The response also includes `pagination_metadata`, which lets the caller
    /// retrieve the next page of results if they exist. More information about pagination
    /// can be found in the Pagination-metadata schema.</para>
    /// </summary>
    Task<CouponListPage> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows a coupon to be archived. Archived coupons can no longer
    /// be redeemed, and will be hidden from lists of active coupons. Additionally,
    /// once a coupon is archived, its redemption code can be reused for a different coupon.
    /// </summary>
    Task<Coupon> Archive(
        CouponArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CouponArchiveParams, CancellationToken)"/>
    Task<Coupon> Archive(
        string couponID,
        CouponArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint retrieves a coupon by its ID. To fetch coupons by their redemption
    /// code, use the [List coupons](list-coupons) endpoint with the redemption_code parameter.
    /// </summary>
    Task<Coupon> Fetch(CouponFetchParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Fetch(CouponFetchParams, CancellationToken)"/>
    Task<Coupon> Fetch(
        string couponID,
        CouponFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICouponService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICouponServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICouponServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Coupons::ISubscriptionServiceWithRawResponse Subscriptions { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /coupons`, but is otherwise the
    /// same as <see cref="ICouponService.Create(CouponCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Coupon>> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /coupons`, but is otherwise the
    /// same as <see cref="ICouponService.List(CouponListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CouponListPage>> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /coupons/{coupon_id}/archive`, but is otherwise the
    /// same as <see cref="ICouponService.Archive(CouponArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Coupon>> Archive(
        CouponArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CouponArchiveParams, CancellationToken)"/>
    Task<HttpResponse<Coupon>> Archive(
        string couponID,
        CouponArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /coupons/{coupon_id}`, but is otherwise the
    /// same as <see cref="ICouponService.Fetch(CouponFetchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Coupon>> Fetch(
        CouponFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(CouponFetchParams, CancellationToken)"/>
    Task<HttpResponse<Coupon>> Fetch(
        string couponID,
        CouponFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
