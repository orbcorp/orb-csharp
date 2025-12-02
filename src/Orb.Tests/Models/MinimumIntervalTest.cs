using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MinimumIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MinimumInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter5Field.PriceID,
                    Operator = Filter5Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter5> expectedFilters =
        [
            new()
            {
                Field = Filter5Field.PriceID,
                Operator = Filter5Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMinimumAmount = "minimum_amount";
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
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MinimumInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter5Field.PriceID,
                    Operator = Filter5Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MinimumInterval>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MinimumInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter5Field.PriceID,
                    Operator = Filter5Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MinimumInterval>(json);
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter5> expectedFilters =
        [
            new()
            {
                Field = Filter5Field.PriceID,
                Operator = Filter5Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMinimumAmount = "minimum_amount";
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
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MinimumInterval
        {
            AppliesToPriceIntervalIDs = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter5Field.PriceID,
                    Operator = Filter5Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class Filter5Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter5
        {
            Field = Filter5Field.PriceID,
            Operator = Filter5Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter5Field> expectedField = Filter5Field.PriceID;
        ApiEnum<string, Filter5Operator> expectedOperator = Filter5Operator.Includes;
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
        var model = new Filter5
        {
            Field = Filter5Field.PriceID,
            Operator = Filter5Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter5>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter5
        {
            Field = Filter5Field.PriceID,
            Operator = Filter5Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter5>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter5Field> expectedField = Filter5Field.PriceID;
        ApiEnum<string, Filter5Operator> expectedOperator = Filter5Operator.Includes;
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
        var model = new Filter5
        {
            Field = Filter5Field.PriceID,
            Operator = Filter5Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
