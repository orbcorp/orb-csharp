using System.Threading.Tasks;
using Orb.Models.Subscriptions;

namespace Orb.Services.Coupons.Subscriptions;

public interface ISubscriptionService
{
    /// <summary>
    /// This endpoint returns a list of all subscriptions that have redeemed a given
    /// coupon as a [paginated](/api-reference/pagination) list, ordered starting
    /// from the most recently created subscription. For a full discussion of the
    /// subscription resource, see [Subscription](/core-concepts#subscription).
    /// </summary>
    Task<Subscriptions> List(
        global::Orb.Models.Coupons.Subscriptions.SubscriptionListParams @params
    );
}
