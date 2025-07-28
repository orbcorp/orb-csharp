using CouponCreateParamsProperties = Orb.Models.Coupons.CouponCreateParamsProperties;
using Coupons = Orb.Models.Coupons;
using DiscountProperties = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Coupons;

public class CouponServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var coupon = await this.client.Coupons.Create(
            new Coupons::CouponCreateParams()
            {
                Discount = CouponCreateParamsProperties::Discount.Create(
                    new DiscountProperties::Percentage() { PercentageDiscount = 0 }
                ),
                RedemptionCode = "HALFOFF",
                DurationInMonths = 12,
                MaxRedemptions = 1,
            }
        );
        coupon.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Coupons.List(
            new Coupons::CouponListParams()
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
    public async Tasks::Task Archive_Works()
    {
        var coupon = await this.client.Coupons.Archive(
            new Coupons::CouponArchiveParams() { CouponID = "coupon_id" }
        );
        coupon.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var coupon = await this.client.Coupons.Fetch(
            new Coupons::CouponFetchParams() { CouponID = "coupon_id" }
        );
        coupon.Validate();
    }
}
