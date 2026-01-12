using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class AmountDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = AmountDiscountFilterField.PriceID,
                    Operator = AmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string expectedAmountDiscountValue = "amount_discount";
        ApiEnum<string, DiscountType> expectedDiscountType = DiscountType.Amount;
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<AmountDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = AmountDiscountFilterField.PriceID,
                Operator = AmountDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountDiscountValue, model.AmountDiscountValue);
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.NotNull(model.AppliesToPriceIds);
        Assert.Equal(expectedAppliesToPriceIds.Count, model.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], model.AppliesToPriceIds[i]);
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
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = AmountDiscountFilterField.PriceID,
                    Operator = AmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = AmountDiscountFilterField.PriceID,
                    Operator = AmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscount>(element);
        Assert.NotNull(deserialized);

        string expectedAmountDiscountValue = "amount_discount";
        ApiEnum<string, DiscountType> expectedDiscountType = DiscountType.Amount;
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<AmountDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = AmountDiscountFilterField.PriceID,
                Operator = AmountDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountDiscountValue, deserialized.AmountDiscountValue);
        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.NotNull(deserialized.AppliesToPriceIds);
        Assert.Equal(expectedAppliesToPriceIds.Count, deserialized.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], deserialized.AppliesToPriceIds[i]);
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
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = AmountDiscountFilterField.PriceID,
                    Operator = AmountDiscountFilterOperator.Includes,
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
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
        };

        Assert.Null(model.AppliesToPriceIds);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,

            AppliesToPriceIds = null,
            Filters = null,
            Reason = null,
        };

        Assert.Null(model.AppliesToPriceIds);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AmountDiscount
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,

            AppliesToPriceIds = null,
            Filters = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class DiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(DiscountType.Amount)]
    public void Validation_Works(DiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DiscountType.Amount)]
    public void SerializationRoundtrip_Works(DiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AmountDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmountDiscountFilter
        {
            Field = AmountDiscountFilterField.PriceID,
            Operator = AmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, AmountDiscountFilterField> expectedField =
            AmountDiscountFilterField.PriceID;
        ApiEnum<string, AmountDiscountFilterOperator> expectedOperator =
            AmountDiscountFilterOperator.Includes;
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
        var model = new AmountDiscountFilter
        {
            Field = AmountDiscountFilterField.PriceID,
            Operator = AmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscountFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AmountDiscountFilter
        {
            Field = AmountDiscountFilterField.PriceID,
            Operator = AmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscountFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, AmountDiscountFilterField> expectedField =
            AmountDiscountFilterField.PriceID;
        ApiEnum<string, AmountDiscountFilterOperator> expectedOperator =
            AmountDiscountFilterOperator.Includes;
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
        var model = new AmountDiscountFilter
        {
            Field = AmountDiscountFilterField.PriceID,
            Operator = AmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class AmountDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(AmountDiscountFilterField.PriceID)]
    [InlineData(AmountDiscountFilterField.ItemID)]
    [InlineData(AmountDiscountFilterField.PriceType)]
    [InlineData(AmountDiscountFilterField.Currency)]
    [InlineData(AmountDiscountFilterField.PricingUnitID)]
    public void Validation_Works(AmountDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AmountDiscountFilterField.PriceID)]
    [InlineData(AmountDiscountFilterField.ItemID)]
    [InlineData(AmountDiscountFilterField.PriceType)]
    [InlineData(AmountDiscountFilterField.Currency)]
    [InlineData(AmountDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(AmountDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AmountDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(AmountDiscountFilterOperator.Includes)]
    [InlineData(AmountDiscountFilterOperator.Excludes)]
    public void Validation_Works(AmountDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AmountDiscountFilterOperator.Includes)]
    [InlineData(AmountDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(AmountDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
