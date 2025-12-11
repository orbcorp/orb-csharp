using System.Threading.Tasks;

namespace Orb.Tests.Services.Coupons;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Coupons.Subscriptions.List(
            "coupon_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
