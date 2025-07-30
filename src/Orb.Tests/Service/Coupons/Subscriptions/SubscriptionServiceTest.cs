using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Coupons.Subscriptions;

public class SubscriptionServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Coupons.Subscriptions.List(
            new()
            {
                CouponID = "coupon_id",
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }
}
