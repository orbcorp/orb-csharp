using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhaseUsageDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string expectedID = "id";
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount;
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanPhaseUsageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        double expectedUsageDiscount = 0;

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
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount;
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanPhaseUsageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        double expectedUsageDiscount = 0;

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
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        model.Validate();
    }
}

public class PlanPhaseUsageDiscountAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount)]
    public void Validation_Works(PlanPhaseUsageDiscountAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount)]
    public void SerializationRoundtrip_Works(
        PlanPhaseUsageDiscountAdjustmentAdjustmentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseUsageDiscountAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustmentFilter
        {
            Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField> expectedField =
            PlanPhaseUsageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator> expectedOperator =
            PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseUsageDiscountAdjustmentFilter
        {
            Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustmentFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustmentFilter
        {
            Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustmentFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField> expectedField =
            PlanPhaseUsageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator> expectedOperator =
            PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseUsageDiscountAdjustmentFilter
        {
            Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class PlanPhaseUsageDiscountAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(PlanPhaseUsageDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(PlanPhaseUsageDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseUsageDiscountAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(PlanPhaseUsageDiscountAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseUsageDiscountAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        PlanPhaseUsageDiscountAdjustmentFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
