using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhasePercentageDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhasePercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<
            string,
            PlanPhasePercentageDiscountAdjustmentAdjustmentType
        > expectedAdjustmentType =
            PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount;
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanPhasePercentageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        double expectedPercentageDiscount = 0;
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
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPhasePercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhasePercentageDiscountAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhasePercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhasePercentageDiscountAdjustment>(
            element
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<
            string,
            PlanPhasePercentageDiscountAdjustmentAdjustmentType
        > expectedAdjustmentType =
            PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount;
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanPhasePercentageDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        double expectedPercentageDiscount = 0;
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
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPhasePercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class PlanPhasePercentageDiscountAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount)]
    public void Validation_Works(PlanPhasePercentageDiscountAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount)]
    public void SerializationRoundtrip_Works(
        PlanPhasePercentageDiscountAdjustmentAdjustmentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhasePercentageDiscountAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhasePercentageDiscountAdjustmentFilter
        {
            Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField> expectedField =
            PlanPhasePercentageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator> expectedOperator =
            PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhasePercentageDiscountAdjustmentFilter
        {
            Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhasePercentageDiscountAdjustmentFilter>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhasePercentageDiscountAdjustmentFilter
        {
            Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhasePercentageDiscountAdjustmentFilter>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField> expectedField =
            PlanPhasePercentageDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator> expectedOperator =
            PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhasePercentageDiscountAdjustmentFilter
        {
            Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class PlanPhasePercentageDiscountAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.Currency)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(PlanPhasePercentageDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.Currency)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(
        PlanPhasePercentageDiscountAdjustmentFilterField rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhasePercentageDiscountAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(PlanPhasePercentageDiscountAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhasePercentageDiscountAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        PlanPhasePercentageDiscountAdjustmentFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
