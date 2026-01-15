using System.Threading.Tasks;
using Orb.Models.Coupons;

namespace Orb.Tests.Services;

public class CouponServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var coupon = await this.client.Coupons.Create(
            new() { Discount = new Percentage(0), RedemptionCode = "HALFOFF" },
            TestContext.Current.CancellationToken
        );
        coupon.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Coupons.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var coupon = await this.client.Coupons.Archive(
            "coupon_id",
            new(),
            TestContext.Current.CancellationToken
        );
        coupon.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var coupon = await this.client.Coupons.Fetch(
            "coupon_id",
            new(),
            TestContext.Current.CancellationToken
        );
        coupon.Validate();
    }
}
