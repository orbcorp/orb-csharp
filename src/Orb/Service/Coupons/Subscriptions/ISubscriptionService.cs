using Subscriptions = Orb.Models.Subscriptions;
using Subscriptions1 = Orb.Models.Coupons.Subscriptions;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Coupons.Subscriptions;

public interface ISubscriptionService
{
    /// <summary>
    /// This endpoint returns a list of all subscriptions that have redeemed a given
    /// coupon as a [paginated](/api-reference/pagination) list, ordered starting from
    /// the most recently created subscription. For a full discussion of the subscription
    /// resource, see [Subscription](/core-concepts#subscription).
    /// </summary>
    Tasks::Task<Subscriptions::Subscriptions> List(Subscriptions1::SubscriptionListParams @params);
}
