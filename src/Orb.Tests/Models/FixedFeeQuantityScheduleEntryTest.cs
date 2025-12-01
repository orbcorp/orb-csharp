using System;
using Orb.Models;

namespace Orb.Tests.Models;

public class FixedFeeQuantityScheduleEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FixedFeeQuantityScheduleEntry
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPriceID = "price_id";
        double expectedQuantity = 0;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedPriceID, model.PriceID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedStartDate, model.StartDate);
    }
}
