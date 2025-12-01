using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MaximumIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaximumInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter3Field.PriceID,
                    Operator = Filter3Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter3> expectedFilters =
        [
            new()
            {
                Field = Filter3Field.PriceID,
                Operator = Filter3Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMaximumAmount = "maximum_amount";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(
            expectedAppliesToPriceIntervalIDs.Count,
            model.AppliesToPriceIntervalIDs.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIntervalIDs[i], model.AppliesToPriceIntervalIDs[i]);
        }
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedStartDate, model.StartDate);
    }
}

public class Filter3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter3
        {
            Field = Filter3Field.PriceID,
            Operator = Filter3Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter3Field> expectedField = Filter3Field.PriceID;
        ApiEnum<string, Filter3Operator> expectedOperator = Filter3Operator.Includes;
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
