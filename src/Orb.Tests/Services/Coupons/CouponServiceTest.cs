using System.Threading.Tasks;
using Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

namespace Orb.Tests.Services.Coupons;

public class CouponServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var coupon = await this.client.Coupons.Create(
            new() { Discount = new(new Percentage(0)), RedemptionCode = "HALFOFF" }
        );
        coupon.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Coupons.List();
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var coupon = await this.client.Coupons.Archive(new() { CouponID = "coupon_id" });
        coupon.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var coupon = await this.client.Coupons.Fetch(new() { CouponID = "coupon_id" });
        coupon.Validate();
    }
}
