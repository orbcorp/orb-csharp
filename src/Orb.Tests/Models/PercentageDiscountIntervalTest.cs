using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class PercentageDiscountIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        ApiEnum<string, PercentageDiscountIntervalDiscountType> expectedDiscountType =
            PercentageDiscountIntervalDiscountType.Percentage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PercentageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = PercentageDiscountIntervalFilterField.PriceID,
                Operator = PercentageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedPercentageDiscount = 0.15;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(
            expectedAppliesToPriceIntervalIDs.Count,
            model.AppliesToPriceIntervalIDs.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIntervalIDs[i], model.AppliesToPriceIntervalIDs[i]);
        }
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(json);
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        ApiEnum<string, PercentageDiscountIntervalDiscountType> expectedDiscountType =
            PercentageDiscountIntervalDiscountType.Percentage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PercentageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = PercentageDiscountIntervalFilterField.PriceID,
                Operator = PercentageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedPercentageDiscount = 0.15;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(
            expectedAppliesToPriceIntervalIDs.Count,
            deserialized.AppliesToPriceIntervalIDs.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIDs.Count; i++)
        {
            Assert.Equal(
                expectedAppliesToPriceIntervalIDs[i],
                deserialized.AppliesToPriceIntervalIDs[i]
            );
        }
        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class PercentageDiscountIntervalFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PercentageDiscountIntervalFilterField> expectedField =
            PercentageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, PercentageDiscountIntervalFilterOperator> expectedOperator =
            PercentageDiscountIntervalFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountIntervalFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountIntervalFilter>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, PercentageDiscountIntervalFilterField> expectedField =
            PercentageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, PercentageDiscountIntervalFilterOperator> expectedOperator =
            PercentageDiscountIntervalFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
