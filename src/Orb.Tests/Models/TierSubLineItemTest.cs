using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class TierSubLineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TierSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            TierConfig = new()
            {
                FirstUnit = 1,
                LastUnit = 1000,
                UnitAmount = "3.00",
            },
            Type = TierSubLineItemType.Tier,
        };

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        TierConfig expectedTierConfig = new()
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };
        ApiEnum<string, TierSubLineItemType> expectedType = TierSubLineItemType.Tier;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedGrouping, model.Grouping);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTierConfig, model.TierConfig);
        Assert.Equal(expectedType, model.Type);
    }
}

public class TierConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TierConfig
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };

        double expectedFirstUnit = 1;
        double expectedLastUnit = 1000;
        string expectedUnitAmount = "3.00";

        Assert.Equal(expectedFirstUnit, model.FirstUnit);
        Assert.Equal(expectedLastUnit, model.LastUnit);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}
