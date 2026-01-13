using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhaseMinimumAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseMinimumAdjustmentAdjustmentType.Minimum;
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanPhaseMinimumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedItemID = "item_id";
        string expectedMinimumAmount = "minimum_amount";
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
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
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPhaseMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMinimumAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMinimumAdjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseMinimumAdjustmentAdjustmentType.Minimum;
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanPhaseMinimumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedItemID = "item_id";
        string expectedMinimumAmount = "minimum_amount";
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
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
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPhaseMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class PlanPhaseMinimumAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseMinimumAdjustmentAdjustmentType.Minimum)]
    public void Validation_Works(PlanPhaseMinimumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseMinimumAdjustmentAdjustmentType.Minimum)]
    public void SerializationRoundtrip_Works(PlanPhaseMinimumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseMinimumAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseMinimumAdjustmentFilter
        {
            Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField> expectedField =
            PlanPhaseMinimumAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator> expectedOperator =
            PlanPhaseMinimumAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseMinimumAdjustmentFilter
        {
            Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMinimumAdjustmentFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseMinimumAdjustmentFilter
        {
            Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMinimumAdjustmentFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField> expectedField =
            PlanPhaseMinimumAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator> expectedOperator =
            PlanPhaseMinimumAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseMinimumAdjustmentFilter
        {
            Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class PlanPhaseMinimumAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(PlanPhaseMinimumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(PlanPhaseMinimumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseMinimumAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseMinimumAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(PlanPhaseMinimumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseMinimumAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseMinimumAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(PlanPhaseMinimumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMinimumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
