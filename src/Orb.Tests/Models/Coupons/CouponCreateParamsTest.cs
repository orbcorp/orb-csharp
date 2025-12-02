using System.Text.Json;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class PercentageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Percentage
        {
            DiscountType = JsonSerializer.Deserialize<JsonElement>("\"percentage\""),
            PercentageDiscount = 0,
        };

        JsonElement expectedDiscountType = JsonSerializer.Deserialize<JsonElement>(
            "\"percentage\""
        );
        double expectedPercentageDiscount = 0;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
    }
}

public class AmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Amount
        {
            AmountDiscount = "amount_discount",
            DiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\""),
        };

        string expectedAmountDiscount = "amount_discount";
        JsonElement expectedDiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");

        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
    }
}
