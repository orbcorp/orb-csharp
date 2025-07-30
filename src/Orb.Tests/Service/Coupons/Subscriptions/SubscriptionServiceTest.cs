using System.Threading.Tasks;

namespace Orb.Tests.Service.Coupons.Subscriptions;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
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
