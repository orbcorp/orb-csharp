using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MaximumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Maximum
        {
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MaximumFilterField.PriceID,
                    Operator = MaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };

        List<string> expectedAppliesToPriceIds = ["string"];
        List<MaximumFilter> expectedFilters =
        [
            new()
            {
                Field = MaximumFilterField.PriceID,
                Operator = MaximumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMaximumAmount = "maximum_amount";

        Assert.Equal(expectedAppliesToPriceIds.Count, model.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], model.AppliesToPriceIds[i]);
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
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MaximumFilterField.PriceID,
                    Operator = MaximumFilterOperator.Includes,
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
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MaximumFilterField.PriceID,
                    Operator = MaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Maximum>(element);
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIds = ["string"];
        List<MaximumFilter> expectedFilters =
        [
            new()
            {
                Field = MaximumFilterField.PriceID,
                Operator = MaximumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMaximumAmount = "maximum_amount";

        Assert.Equal(expectedAppliesToPriceIds.Count, deserialized.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], deserialized.AppliesToPriceIds[i]);
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
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MaximumFilterField.PriceID,
                    Operator = MaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };

        model.Validate();
    }
}

public class MaximumFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaximumFilter
        {
            Field = MaximumFilterField.PriceID,
            Operator = MaximumFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MaximumFilterField> expectedField = MaximumFilterField.PriceID;
        ApiEnum<string, MaximumFilterOperator> expectedOperator = MaximumFilterOperator.Includes;
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
        var model = new MaximumFilter
        {
            Field = MaximumFilterField.PriceID,
            Operator = MaximumFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaximumFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MaximumFilter
        {
            Field = MaximumFilterField.PriceID,
            Operator = MaximumFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaximumFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, MaximumFilterField> expectedField = MaximumFilterField.PriceID;
        ApiEnum<string, MaximumFilterOperator> expectedOperator = MaximumFilterOperator.Includes;
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
        var model = new MaximumFilter
        {
            Field = MaximumFilterField.PriceID,
            Operator = MaximumFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class MaximumFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MaximumFilterField.PriceID)]
    [InlineData(MaximumFilterField.ItemID)]
    [InlineData(MaximumFilterField.PriceType)]
    [InlineData(MaximumFilterField.Currency)]
    [InlineData(MaximumFilterField.PricingUnitID)]
    public void Validation_Works(MaximumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MaximumFilterField.PriceID)]
    [InlineData(MaximumFilterField.ItemID)]
    [InlineData(MaximumFilterField.PriceType)]
    [InlineData(MaximumFilterField.Currency)]
    [InlineData(MaximumFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(MaximumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MaximumFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MaximumFilterOperator.Includes)]
    [InlineData(MaximumFilterOperator.Excludes)]
    public void Validation_Works(MaximumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MaximumFilterOperator.Includes)]
    [InlineData(MaximumFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(MaximumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MaximumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
