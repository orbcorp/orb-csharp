using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhaseAmountDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount;
        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<PlanPhaseAmountDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
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
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPhaseAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustment>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount;
        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<PlanPhaseAmountDiscountAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
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
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPhaseAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class PlanPhaseAmountDiscountAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount)]
    public void Validation_Works(PlanPhaseAmountDiscountAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount)]
    public void SerializationRoundtrip_Works(
        PlanPhaseAmountDiscountAdjustmentAdjustmentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseAmountDiscountAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseAmountDiscountAdjustmentFilter
        {
            Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField> expectedField =
            PlanPhaseAmountDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator> expectedOperator =
            PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseAmountDiscountAdjustmentFilter
        {
            Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustmentFilter>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseAmountDiscountAdjustmentFilter
        {
            Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustmentFilter>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField> expectedField =
            PlanPhaseAmountDiscountAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator> expectedOperator =
            PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseAmountDiscountAdjustmentFilter
        {
            Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
            Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class PlanPhaseAmountDiscountAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(PlanPhaseAmountDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(PlanPhaseAmountDiscountAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseAmountDiscountAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(PlanPhaseAmountDiscountAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseAmountDiscountAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        PlanPhaseAmountDiscountAdjustmentFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
