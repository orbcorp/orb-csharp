using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class PercentageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        ApiEnum<string, PercentageDiscountDiscountType> expectedDiscountType =
            PercentageDiscountDiscountType.Percentage;
        double expectedPercentageDiscountValue = 0.15;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<PercentageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = PercentageDiscountFilterField.PriceID,
                Operator = PercentageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedPercentageDiscountValue, model.PercentageDiscountValue);
        Assert.NotNull(model.AppliesToPriceIDs);
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, PercentageDiscountDiscountType> expectedDiscountType =
            PercentageDiscountDiscountType.Percentage;
        double expectedPercentageDiscountValue = 0.15;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<PercentageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = PercentageDiscountFilterField.PriceID,
                Operator = PercentageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedPercentageDiscountValue, deserialized.PercentageDiscountValue);
        Assert.NotNull(deserialized.AppliesToPriceIDs);
        Assert.Equal(expectedAppliesToPriceIDs.Count, deserialized.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], deserialized.AppliesToPriceIDs[i]);
        }
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
        };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
        };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PercentageDiscount
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class PercentageDiscountDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(PercentageDiscountDiscountType.Percentage)]
    public void Validation_Works(PercentageDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentageDiscountDiscountType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PercentageDiscountDiscountType.Percentage)]
    public void SerializationRoundtrip_Works(PercentageDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentageDiscountDiscountType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PercentageDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentageDiscountFilter
        {
            Field = PercentageDiscountFilterField.PriceID,
            Operator = PercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PercentageDiscountFilterField> expectedField =
            PercentageDiscountFilterField.PriceID;
        ApiEnum<string, PercentageDiscountFilterOperator> expectedOperator =
            PercentageDiscountFilterOperator.Includes;
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
        var model = new PercentageDiscountFilter
        {
            Field = PercentageDiscountFilterField.PriceID,
            Operator = PercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PercentageDiscountFilter
        {
            Field = PercentageDiscountFilterField.PriceID,
            Operator = PercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, PercentageDiscountFilterField> expectedField =
            PercentageDiscountFilterField.PriceID;
        ApiEnum<string, PercentageDiscountFilterOperator> expectedOperator =
            PercentageDiscountFilterOperator.Includes;
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
        var model = new PercentageDiscountFilter
        {
            Field = PercentageDiscountFilterField.PriceID,
            Operator = PercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class PercentageDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PercentageDiscountFilterField.PriceID)]
    [InlineData(PercentageDiscountFilterField.ItemID)]
    [InlineData(PercentageDiscountFilterField.PriceType)]
    [InlineData(PercentageDiscountFilterField.Currency)]
    [InlineData(PercentageDiscountFilterField.PricingUnitID)]
    public void Validation_Works(PercentageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentageDiscountFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PercentageDiscountFilterField.PriceID)]
    [InlineData(PercentageDiscountFilterField.ItemID)]
    [InlineData(PercentageDiscountFilterField.PriceType)]
    [InlineData(PercentageDiscountFilterField.Currency)]
    [InlineData(PercentageDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(PercentageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentageDiscountFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PercentageDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PercentageDiscountFilterOperator.Includes)]
    [InlineData(PercentageDiscountFilterOperator.Excludes)]
    public void Validation_Works(PercentageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentageDiscountFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PercentageDiscountFilterOperator.Includes)]
    [InlineData(PercentageDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(PercentageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentageDiscountFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
