using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Minimum
        {
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MinimumFilterField.PriceID,
                    Operator = MinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };

        List<string> expectedAppliesToPriceIds = ["string"];
        List<MinimumFilter> expectedFilters =
        [
            new()
            {
                Field = MinimumFilterField.PriceID,
                Operator = MinimumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMinimumAmount = "minimum_amount";

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
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Minimum
        {
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MinimumFilterField.PriceID,
                    Operator = MinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Minimum>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Minimum
        {
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MinimumFilterField.PriceID,
                    Operator = MinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Minimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIds = ["string"];
        List<MinimumFilter> expectedFilters =
        [
            new()
            {
                Field = MinimumFilterField.PriceID,
                Operator = MinimumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMinimumAmount = "minimum_amount";

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
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Minimum
        {
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MinimumFilterField.PriceID,
                    Operator = MinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Minimum
        {
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MinimumFilterField.PriceID,
                    Operator = MinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };

        Minimum copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MinimumFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MinimumFilter
        {
            Field = MinimumFilterField.PriceID,
            Operator = MinimumFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MinimumFilterField> expectedField = MinimumFilterField.PriceID;
        ApiEnum<string, MinimumFilterOperator> expectedOperator = MinimumFilterOperator.Includes;
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
        var model = new MinimumFilter
        {
            Field = MinimumFilterField.PriceID,
            Operator = MinimumFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinimumFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MinimumFilter
        {
            Field = MinimumFilterField.PriceID,
            Operator = MinimumFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinimumFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MinimumFilterField> expectedField = MinimumFilterField.PriceID;
        ApiEnum<string, MinimumFilterOperator> expectedOperator = MinimumFilterOperator.Includes;
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
        var model = new MinimumFilter
        {
            Field = MinimumFilterField.PriceID,
            Operator = MinimumFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MinimumFilter
        {
            Field = MinimumFilterField.PriceID,
            Operator = MinimumFilterOperator.Includes,
            Values = ["string"],
        };

        MinimumFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MinimumFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MinimumFilterField.PriceID)]
    [InlineData(MinimumFilterField.ItemID)]
    [InlineData(MinimumFilterField.PriceType)]
    [InlineData(MinimumFilterField.Currency)]
    [InlineData(MinimumFilterField.PricingUnitID)]
    public void Validation_Works(MinimumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MinimumFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MinimumFilterField.PriceID)]
    [InlineData(MinimumFilterField.ItemID)]
    [InlineData(MinimumFilterField.PriceType)]
    [InlineData(MinimumFilterField.Currency)]
    [InlineData(MinimumFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(MinimumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MinimumFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MinimumFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MinimumFilterOperator.Includes)]
    [InlineData(MinimumFilterOperator.Excludes)]
    public void Validation_Works(MinimumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MinimumFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MinimumFilterOperator.Includes)]
    [InlineData(MinimumFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(MinimumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MinimumFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MinimumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
