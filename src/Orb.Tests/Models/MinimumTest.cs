using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Minimum
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };

        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter4> expectedFilters =
        [
            new()
            {
                Field = Filter4Field.PriceID,
                Operator = Filter4Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMinimumAmount = "minimum_amount";

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
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
    }
}

public class Filter4Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter4
        {
            Field = Filter4Field.PriceID,
            Operator = Filter4Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter4Field> expectedField = Filter4Field.PriceID;
        ApiEnum<string, Filter4Operator> expectedOperator = Filter4Operator.Includes;
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
