using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryMaximumAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMaximumAdjustmentAdjustmentType.Maximum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryMaximumAdjustmentAdjustmentType.Maximum;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryMaximumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedMaximumAmount = "maximum_amount";
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
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonetaryMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMaximumAdjustmentAdjustmentType.Maximum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMaximumAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMaximumAdjustmentAdjustmentType.Maximum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMaximumAdjustment>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryMaximumAdjustmentAdjustmentType.Maximum;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIds = ["string"];
        List<MonetaryMaximumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedMaximumAmount = "maximum_amount";
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
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonetaryMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMaximumAdjustmentAdjustmentType.Maximum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class MonetaryMaximumAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(MonetaryMaximumAdjustmentAdjustmentType.Maximum)]
    public void Validation_Works(MonetaryMaximumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryMaximumAdjustmentAdjustmentType.Maximum)]
    public void SerializationRoundtrip_Works(MonetaryMaximumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryMaximumAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryMaximumAdjustmentFilter
        {
            Field = MonetaryMaximumAdjustmentFilterField.PriceID,
            Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MonetaryMaximumAdjustmentFilterField> expectedField =
            MonetaryMaximumAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator> expectedOperator =
            MonetaryMaximumAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryMaximumAdjustmentFilter
        {
            Field = MonetaryMaximumAdjustmentFilterField.PriceID,
            Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMaximumAdjustmentFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonetaryMaximumAdjustmentFilter
        {
            Field = MonetaryMaximumAdjustmentFilterField.PriceID,
            Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryMaximumAdjustmentFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, MonetaryMaximumAdjustmentFilterField> expectedField =
            MonetaryMaximumAdjustmentFilterField.PriceID;
        ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator> expectedOperator =
            MonetaryMaximumAdjustmentFilterOperator.Includes;
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
        var model = new MonetaryMaximumAdjustmentFilter
        {
            Field = MonetaryMaximumAdjustmentFilterField.PriceID,
            Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class MonetaryMaximumAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MonetaryMaximumAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.Currency)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(MonetaryMaximumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMaximumAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryMaximumAdjustmentFilterField.PriceID)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.ItemID)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.PriceType)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.Currency)]
    [InlineData(MonetaryMaximumAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(MonetaryMaximumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMaximumAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonetaryMaximumAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MonetaryMaximumAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryMaximumAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(MonetaryMaximumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonetaryMaximumAdjustmentFilterOperator.Includes)]
    [InlineData(MonetaryMaximumAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(MonetaryMaximumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
