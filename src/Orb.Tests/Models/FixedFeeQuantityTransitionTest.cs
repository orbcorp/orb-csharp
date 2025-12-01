using System;
using Orb.Models;

namespace Orb.Tests.Models;

public class FixedFeeQuantityTransitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
        };

        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPriceID = "price_id";
        long expectedQuantity = 0;

        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedPriceID, model.PriceID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }
}
