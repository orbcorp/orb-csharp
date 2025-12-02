using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MaximumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Maximum
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };

        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter2> expectedFilters =
        [
            new()
            {
                Field = Filter2Field.PriceID,
                Operator = Filter2Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMaximumAmount = "maximum_amount";

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
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Maximum
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Maximum>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Maximum
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Maximum>(json);
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter2> expectedFilters =
        [
            new()
            {
                Field = Filter2Field.PriceID,
                Operator = Filter2Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMaximumAmount = "maximum_amount";

        Assert.Equal(expectedAppliesToPriceIDs.Count, deserialized.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], deserialized.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Maximum
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };

        model.Validate();
    }
}

public class Filter2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter2
        {
            Field = Filter2Field.PriceID,
            Operator = Filter2Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter2Field> expectedField = Filter2Field.PriceID;
        ApiEnum<string, Filter2Operator> expectedOperator = Filter2Operator.Includes;
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
        var model = new Filter2
        {
            Field = Filter2Field.PriceID,
            Operator = Filter2Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter2>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter2
        {
            Field = Filter2Field.PriceID,
            Operator = Filter2Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter2>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter2Field> expectedField = Filter2Field.PriceID;
        ApiEnum<string, Filter2Operator> expectedOperator = Filter2Operator.Includes;
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
        var model = new Filter2
        {
            Field = Filter2Field.PriceID,
            Operator = Filter2Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
