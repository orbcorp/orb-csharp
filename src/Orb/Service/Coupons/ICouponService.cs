using Coupons = Orb.Models.Coupons;
using Subscriptions = Orb.Service.Coupons.Subscriptions;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Coupons;

public interface ICouponService
{
    Subscriptions::ISubscriptionService Subscriptions { get; }

    /// <summary>
    /// This endpoint allows the creation of coupons, which can then be redeemed at
    /// subscription creation or plan change.
    /// </summary>
    Tasks::Task<Coupons::Coupon> Create(Coupons::CouponCreateParams @params);

    /// <summary>
    /// This endpoint returns a list of all coupons for an account in a list format.
    ///
    /// The list of coupons is ordered starting from the most recently created coupon.
    /// The response also includes `pagination_metadata`, which lets the caller retrieve
    /// the next page of results if they exist. More information about pagination can
    /// be found in the Pagination-metadata schema.
    /// </summary>
    Tasks::Task<Coupons::CouponListPageResponse> List(Coupons::CouponListParams @params);

    /// <summary>
    /// This endpoint allows a coupon to be archived. Archived coupons can no longer
    /// be redeemed, and will be hidden from lists of active coupons. Additionally,
    /// once a coupon is archived, its redemption code can be reused for a different coupon.
    /// </summary>
    Tasks::Task<Coupons::Coupon> Archive(Coupons::CouponArchiveParams @params);

    /// <summary>
    /// This endpoint retrieves a coupon by its ID. To fetch coupons by their redemption
    /// code, use the [List coupons](list-coupons) endpoint with the redemption_code parameter.
    /// </summary>
    Tasks::Task<Coupons::Coupon> Fetch(Coupons::CouponFetchParams @params);
}
