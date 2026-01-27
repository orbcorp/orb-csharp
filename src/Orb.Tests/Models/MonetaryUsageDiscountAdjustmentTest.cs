using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryUsageDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string expectedID = "id";
        ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryUsageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        double expectedUsageDiscount = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedAmount, model.Amount);
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
        Assert.Equal(expectedIsInvoiceLevel, model.IsInvoiceLevel);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonetaryUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryUsageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        double expectedUsageDiscount = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedAmount, deserialized.Amount);
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
        Assert.Equal(expectedIsInvoiceLevel, deserialized.IsInvoiceLevel);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonetaryUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonetaryUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        MonetaryUsageDiscountAdjustment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonetaryUsageDiscountAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount)]
    public void Validation_Works(MonetaryUsageDiscountAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount)]
    public void SerializationRoundtrip_Works(MonetaryUsageDiscountAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryUsageDiscountAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryUsageDiscountAdjustmentFilter
        {
            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField> expectedField =
            MonetaryUsageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator> expectedOperator =
            MonetaryUsageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryUsageDiscountAdjustmentFilter
        {
            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustmentFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryUsageDiscountAdjustmentFilter
        {
            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustmentFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField> expectedField =
            MonetaryUsageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator> expectedOperator =
            MonetaryUsageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryUsageDiscountAdjustmentFilter
        {
            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonetaryUsageDiscountAdjustmentFilter
        {
            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        MonetaryUsageDiscountAdjustmentFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonetaryUsageDiscountAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.Currency)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(MonetaryUsageDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.Currency)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(MonetaryUsageDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryUsageDiscountAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(MonetaryUsageDiscountAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryUsageDiscountAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(MonetaryUsageDiscountAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
