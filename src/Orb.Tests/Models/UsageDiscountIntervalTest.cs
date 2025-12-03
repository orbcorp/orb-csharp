using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class UsageDiscountIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        ApiEnum<string, UsageDiscountIntervalDiscountType> expectedDiscountType =
            UsageDiscountIntervalDiscountType.Usage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<UsageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = UsageDiscountIntervalFilterField.PriceID,
                Operator = UsageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageDiscount = 0;

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
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(json);
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        ApiEnum<string, UsageDiscountIntervalDiscountType> expectedDiscountType =
            UsageDiscountIntervalDiscountType.Usage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<UsageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = UsageDiscountIntervalFilterField.PriceID,
                Operator = UsageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageDiscount = 0;

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
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        model.Validate();
    }
}

public class UsageDiscountIntervalFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, UsageDiscountIntervalFilterField> expectedField =
            UsageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, UsageDiscountIntervalFilterOperator> expectedOperator =
            UsageDiscountIntervalFilterOperator.Includes;
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
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountIntervalFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountIntervalFilter>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, UsageDiscountIntervalFilterField> expectedField =
            UsageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, UsageDiscountIntervalFilterOperator> expectedOperator =
            UsageDiscountIntervalFilterOperator.Includes;
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
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
