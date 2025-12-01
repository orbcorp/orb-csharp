using System.Collections.Generic;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class EvaluatePriceGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EvaluatePriceGroup
        {
            Amount = "amount",
            GroupingValues = ["string"],
            Quantity = 0,
        };

        string expectedAmount = "amount";
        List<GroupingValue> expectedGroupingValues = ["string"];
        double expectedQuantity = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedGroupingValues.Count, model.GroupingValues.Count);
        for (int i = 0; i < expectedGroupingValues.Count; i++)
        {
            Assert.Equal(expectedGroupingValues[i], model.GroupingValues[i]);
        }
        Assert.Equal(expectedQuantity, model.Quantity);
    }
}
