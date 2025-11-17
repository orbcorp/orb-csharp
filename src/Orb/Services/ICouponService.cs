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
    Task<CouponListPageResponse> List(
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

    /// <summary>
    /// This endpoint retrieves a coupon by its ID. To fetch coupons by their redemption
    /// code, use the [List coupons](list-coupons) endpoint with the redemption_code parameter.
    /// </summary>
    Task<Coupon> Fetch(CouponFetchParams parameters, CancellationToken cancellationToken = default);
}
