using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class UsageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = UsageDiscountFilterField.PriceID,
                    Operator = UsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        ApiEnum<string, UsageDiscountDiscountType> expectedDiscountType =
            UsageDiscountDiscountType.Usage;
        double expectedUsageDiscountValue = 0;
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<UsageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = UsageDiscountFilterField.PriceID,
                Operator = UsageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedUsageDiscountValue, model.UsageDiscountValue);
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
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = UsageDiscountFilterField.PriceID,
                    Operator = UsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageDiscount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = UsageDiscountFilterField.PriceID,
                    Operator = UsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageDiscount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UsageDiscountDiscountType> expectedDiscountType =
            UsageDiscountDiscountType.Usage;
        double expectedUsageDiscountValue = 0;
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<UsageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = UsageDiscountFilterField.PriceID,
                Operator = UsageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedUsageDiscountValue, deserialized.UsageDiscountValue);
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
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = UsageDiscountFilterField.PriceID,
                    Operator = UsageDiscountFilterOperator.Includes,
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
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
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
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,

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
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,

            AppliesToPriceIds = null,
            Filters = null,
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = UsageDiscountFilterField.PriceID,
                    Operator = UsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        UsageDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageDiscountDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(UsageDiscountDiscountType.Usage)]
    public void Validation_Works(UsageDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountDiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UsageDiscountDiscountType.Usage)]
    public void SerializationRoundtrip_Works(UsageDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountDiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountDiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountDiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UsageDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscountFilter
        {
            Field = UsageDiscountFilterField.PriceID,
            Operator = UsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, UsageDiscountFilterField> expectedField = UsageDiscountFilterField.PriceID;
        ApiEnum<string, UsageDiscountFilterOperator> expectedOperator =
            UsageDiscountFilterOperator.Includes;
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
        var model = new UsageDiscountFilter
        {
            Field = UsageDiscountFilterField.PriceID,
            Operator = UsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageDiscountFilter
        {
            Field = UsageDiscountFilterField.PriceID,
            Operator = UsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UsageDiscountFilterField> expectedField = UsageDiscountFilterField.PriceID;
        ApiEnum<string, UsageDiscountFilterOperator> expectedOperator =
            UsageDiscountFilterOperator.Includes;
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
        var model = new UsageDiscountFilter
        {
            Field = UsageDiscountFilterField.PriceID,
            Operator = UsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageDiscountFilter
        {
            Field = UsageDiscountFilterField.PriceID,
            Operator = UsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        UsageDiscountFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(UsageDiscountFilterField.PriceID)]
    [InlineData(UsageDiscountFilterField.ItemID)]
    [InlineData(UsageDiscountFilterField.PriceType)]
    [InlineData(UsageDiscountFilterField.Currency)]
    [InlineData(UsageDiscountFilterField.PricingUnitID)]
    public void Validation_Works(UsageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UsageDiscountFilterField.PriceID)]
    [InlineData(UsageDiscountFilterField.ItemID)]
    [InlineData(UsageDiscountFilterField.PriceType)]
    [InlineData(UsageDiscountFilterField.Currency)]
    [InlineData(UsageDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(UsageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UsageDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(UsageDiscountFilterOperator.Includes)]
    [InlineData(UsageDiscountFilterOperator.Excludes)]
    public void Validation_Works(UsageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UsageDiscountFilterOperator.Includes)]
    [InlineData(UsageDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(UsageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
