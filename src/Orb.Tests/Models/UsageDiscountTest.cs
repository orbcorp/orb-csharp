using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class UsageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter26Field.PriceID,
                    Operator = Filter26Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        ApiEnum<string, UsageDiscountDiscountType> expectedDiscountType =
            UsageDiscountDiscountType.Usage;
        double expectedUsageDiscount1 = 0;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<Filter26> expectedFilters =
        [
            new()
            {
                Field = Filter26Field.PriceID,
                Operator = Filter26Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedUsageDiscount1, model.UsageDiscount1);
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
    }
}

public class Filter26Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter26
        {
            Field = Filter26Field.PriceID,
            Operator = Filter26Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter26Field> expectedField = Filter26Field.PriceID;
        ApiEnum<string, Filter26Operator> expectedOperator = Filter26Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}
