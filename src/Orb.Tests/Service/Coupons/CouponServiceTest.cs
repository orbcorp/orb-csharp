using System.Threading.Tasks;
using Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

namespace Orb.Tests.Service.Coupons;

public class CouponServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var coupon = await this.client.Coupons.Create(
            new()
            {
                Discount = new Percentage() { PercentageDiscount = 0 },
                RedemptionCode = "HALFOFF",
                DurationInMonths = 12,
                MaxRedemptions = 1,
            }
        );
        coupon.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Coupons.List(
            new()
            {
                Cursor = "cursor",
                Limit = 1,
                RedemptionCode = "redemption_code",
                ShowArchived = true,
            }
        );
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
