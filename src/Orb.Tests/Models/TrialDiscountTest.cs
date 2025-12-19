using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class TrialDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TrialDiscountFilterField.PriceID,
                    Operator = TrialDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
            TrialAmountDiscount = "trial_amount_discount",
            TrialPercentageDiscount = 0,
        };

        ApiEnum<string, TrialDiscountDiscountType> expectedDiscountType =
            TrialDiscountDiscountType.Trial;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<TrialDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = TrialDiscountFilterField.PriceID,
                Operator = TrialDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";
        string expectedTrialAmountDiscount = "trial_amount_discount";
        double expectedTrialPercentageDiscount = 0;

        Assert.Equal(expectedDiscountType, model.DiscountType);
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
        Assert.Equal(expectedTrialAmountDiscount, model.TrialAmountDiscount);
        Assert.Equal(expectedTrialPercentageDiscount, model.TrialPercentageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TrialDiscountFilterField.PriceID,
                    Operator = TrialDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
            TrialAmountDiscount = "trial_amount_discount",
            TrialPercentageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TrialDiscountFilterField.PriceID,
                    Operator = TrialDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
            TrialAmountDiscount = "trial_amount_discount",
            TrialPercentageDiscount = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialDiscount>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, TrialDiscountDiscountType> expectedDiscountType =
            TrialDiscountDiscountType.Trial;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<TrialDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = TrialDiscountFilterField.PriceID,
                Operator = TrialDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";
        string expectedTrialAmountDiscount = "trial_amount_discount";
        double expectedTrialPercentageDiscount = 0;

        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
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
        Assert.Equal(expectedTrialAmountDiscount, deserialized.TrialAmountDiscount);
        Assert.Equal(expectedTrialPercentageDiscount, deserialized.TrialPercentageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TrialDiscountFilterField.PriceID,
                    Operator = TrialDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
            TrialAmountDiscount = "trial_amount_discount",
            TrialPercentageDiscount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TrialDiscount { DiscountType = TrialDiscountDiscountType.Trial };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.TrialAmountDiscount);
        Assert.False(model.RawData.ContainsKey("trial_amount_discount"));
        Assert.Null(model.TrialPercentageDiscount);
        Assert.False(model.RawData.ContainsKey("trial_percentage_discount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TrialDiscount { DiscountType = TrialDiscountDiscountType.Trial };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
            TrialAmountDiscount = null,
            TrialPercentageDiscount = null,
        };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.TrialAmountDiscount);
        Assert.True(model.RawData.ContainsKey("trial_amount_discount"));
        Assert.Null(model.TrialPercentageDiscount);
        Assert.True(model.RawData.ContainsKey("trial_percentage_discount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
            TrialAmountDiscount = null,
            TrialPercentageDiscount = null,
        };

        model.Validate();
    }
}

public class TrialDiscountDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(TrialDiscountDiscountType.Trial)]
    public void Validation_Works(TrialDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialDiscountDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountDiscountType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrialDiscountDiscountType.Trial)]
    public void SerializationRoundtrip_Works(TrialDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialDiscountDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountDiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountDiscountType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountDiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrialDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrialDiscountFilter
        {
            Field = TrialDiscountFilterField.PriceID,
            Operator = TrialDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, TrialDiscountFilterField> expectedField = TrialDiscountFilterField.PriceID;
        ApiEnum<string, TrialDiscountFilterOperator> expectedOperator =
            TrialDiscountFilterOperator.Includes;
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
        var model = new TrialDiscountFilter
        {
            Field = TrialDiscountFilterField.PriceID,
            Operator = TrialDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialDiscountFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrialDiscountFilter
        {
            Field = TrialDiscountFilterField.PriceID,
            Operator = TrialDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialDiscountFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, TrialDiscountFilterField> expectedField = TrialDiscountFilterField.PriceID;
        ApiEnum<string, TrialDiscountFilterOperator> expectedOperator =
            TrialDiscountFilterOperator.Includes;
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
        var model = new TrialDiscountFilter
        {
            Field = TrialDiscountFilterField.PriceID,
            Operator = TrialDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class TrialDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(TrialDiscountFilterField.PriceID)]
    [InlineData(TrialDiscountFilterField.ItemID)]
    [InlineData(TrialDiscountFilterField.PriceType)]
    [InlineData(TrialDiscountFilterField.Currency)]
    [InlineData(TrialDiscountFilterField.PricingUnitID)]
    public void Validation_Works(TrialDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrialDiscountFilterField.PriceID)]
    [InlineData(TrialDiscountFilterField.ItemID)]
    [InlineData(TrialDiscountFilterField.PriceType)]
    [InlineData(TrialDiscountFilterField.Currency)]
    [InlineData(TrialDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(TrialDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrialDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(TrialDiscountFilterOperator.Includes)]
    [InlineData(TrialDiscountFilterOperator.Excludes)]
    public void Validation_Works(TrialDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialDiscountFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrialDiscountFilterOperator.Includes)]
    [InlineData(TrialDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(TrialDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialDiscountFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialDiscountFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
