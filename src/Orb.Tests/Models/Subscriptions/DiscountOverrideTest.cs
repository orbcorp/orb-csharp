using Orb.Core;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class DiscountOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscountOverride
        {
            DiscountType = DiscountType.Percentage,
            AmountDiscount = "amount_discount",
            PercentageDiscount = 0.15,
            UsageDiscount = 0,
        };

        ApiEnum<string, DiscountType> expectedDiscountType = DiscountType.Percentage;
        string expectedAmountDiscount = "amount_discount";
        double expectedPercentageDiscount = 0.15;
        double expectedUsageDiscount = 0;

        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }
}
