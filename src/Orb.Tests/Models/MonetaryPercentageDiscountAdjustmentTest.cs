using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryPercentageDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryPercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            Amount = "amount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<MonetaryPercentageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        double expectedPercentageDiscount = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedAmount, model.Amount);
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
        Assert.Equal(expectedIsInvoiceLevel, model.IsInvoiceLevel);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonetaryPercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            Amount = "amount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryPercentageDiscountAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryPercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            Amount = "amount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryPercentageDiscountAdjustment>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<MonetaryPercentageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        double expectedPercentageDiscount = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedAmount, deserialized.Amount);
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
        Assert.Equal(expectedIsInvoiceLevel, deserialized.IsInvoiceLevel);
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonetaryPercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            Amount = "amount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class MonetaryPercentageDiscountAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount)]
    public void Validation_Works(MonetaryPercentageDiscountAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount)]
    public void SerializationRoundtrip_Works(
        MonetaryPercentageDiscountAdjustmentAdjustmentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryPercentageDiscountAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryPercentageDiscountAdjustmentFilter
        {
            Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField> expectedField =
            MonetaryPercentageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator> expectedOperator =
            MonetaryPercentageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryPercentageDiscountAdjustmentFilter
        {
            Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryPercentageDiscountAdjustmentFilter>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryPercentageDiscountAdjustmentFilter
        {
            Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryPercentageDiscountAdjustmentFilter>(
            json
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField> expectedField =
            MonetaryPercentageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator> expectedOperator =
            MonetaryPercentageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryPercentageDiscountAdjustmentFilter
        {
            Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
            Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class MonetaryPercentageDiscountAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.Currency)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(MonetaryPercentageDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.Currency)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(
        MonetaryPercentageDiscountAdjustmentFilterField rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryPercentageDiscountAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(MonetaryPercentageDiscountAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryPercentageDiscountAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        MonetaryPercentageDiscountAdjustmentFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
