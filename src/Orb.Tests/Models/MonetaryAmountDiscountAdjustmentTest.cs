using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryAmountDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = AdjustmentType.AmountDiscount,
            Amount = "amount",
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, AdjustmentType> expectedAdjustmentType = AdjustmentType.AmountDiscount;
        string expectedAmount = "amount";
        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryAmountDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonetaryAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = AdjustmentType.AmountDiscount,
            Amount = "amount",
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = AdjustmentType.AmountDiscount,
            Amount = "amount",
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustment>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, AdjustmentType> expectedAdjustmentType = AdjustmentType.AmountDiscount;
        string expectedAmount = "amount";
        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryAmountDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonetaryAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = AdjustmentType.AmountDiscount,
            Amount = "amount",
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class AdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(AdjustmentType.AmountDiscount)]
    public void Validation_Works(AdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AdjustmentType.AmountDiscount)]
    public void SerializationRoundtrip_Works(AdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryAmountDiscountAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryAmountDiscountAdjustmentFilter
        {
            Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField> expectedField =
            MonetaryAmountDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator> expectedOperator =
            MonetaryAmountDiscountAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryAmountDiscountAdjustmentFilter
        {
            Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustmentFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryAmountDiscountAdjustmentFilter
        {
            Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustmentFilter>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField> expectedField =
            MonetaryAmountDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator> expectedOperator =
            MonetaryAmountDiscountAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryAmountDiscountAdjustmentFilter
        {
            Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class MonetaryAmountDiscountAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.Currency)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(MonetaryAmountDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.Currency)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(MonetaryAmountDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryAmountDiscountAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(MonetaryAmountDiscountAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryAmountDiscountAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        MonetaryAmountDiscountAdjustmentFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
