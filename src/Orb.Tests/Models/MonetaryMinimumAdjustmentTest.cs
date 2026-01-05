using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryMinimumAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryMinimumAdjustmentAdjustmentType.Minimum;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryMinimumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedItemID = "item_id";
        string expectedMinimumAmount = "minimum_amount";
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

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
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonetaryMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMinimumAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMinimumAdjustment>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryMinimumAdjustmentAdjustmentType.Minimum;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryMinimumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedItemID = "item_id";
        string expectedMinimumAmount = "minimum_amount";
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

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
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonetaryMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class MonetaryMinimumAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(MonetaryMinimumAdjustmentAdjustmentType.Minimum)]
    public void Validation_Works(MonetaryMinimumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryMinimumAdjustmentAdjustmentType.Minimum)]
    public void SerializationRoundtrip_Works(MonetaryMinimumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryMinimumAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryMinimumAdjustmentFilter
        {
            Field = MonetaryMinimumAdjustmentFilterField.PriceID,
            Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MonetaryMinimumAdjustmentFilterField> expectedField =
            MonetaryMinimumAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator> expectedOperator =
            MonetaryMinimumAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryMinimumAdjustmentFilter
        {
            Field = MonetaryMinimumAdjustmentFilterField.PriceID,
            Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMinimumAdjustmentFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryMinimumAdjustmentFilter
        {
            Field = MonetaryMinimumAdjustmentFilterField.PriceID,
            Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMinimumAdjustmentFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, MonetaryMinimumAdjustmentFilterField> expectedField =
            MonetaryMinimumAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator> expectedOperator =
            MonetaryMinimumAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryMinimumAdjustmentFilter
        {
            Field = MonetaryMinimumAdjustmentFilterField.PriceID,
            Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class MonetaryMinimumAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MonetaryMinimumAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.Currency)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(MonetaryMinimumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMinimumAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryMinimumAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.Currency)]
    [InlineData(MonetaryMinimumAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(MonetaryMinimumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMinimumAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryMinimumAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MonetaryMinimumAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryMinimumAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(MonetaryMinimumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryMinimumAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryMinimumAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(MonetaryMinimumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
