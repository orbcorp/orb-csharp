using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhaseMaximumAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseMaximumAdjustmentAdjustmentType.Maximum;
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<PlanPhaseMaximumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedMaximumAmount = "maximum_amount";
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
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
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustment>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseMaximumAdjustmentAdjustmentType.Maximum;
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<PlanPhaseMaximumAdjustmentFilter> expectedFilters =
        [
            new()
            {
                Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedMaximumAmount = "maximum_amount";
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
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
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class PlanPhaseMaximumAdjustmentAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseMaximumAdjustmentAdjustmentType.Maximum)]
    public void Validation_Works(PlanPhaseMaximumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseMaximumAdjustmentAdjustmentType.Maximum)]
    public void SerializationRoundtrip_Works(PlanPhaseMaximumAdjustmentAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseMaximumAdjustmentFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseMaximumAdjustmentFilter
        {
            Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField> expectedField =
            PlanPhaseMaximumAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator> expectedOperator =
            PlanPhaseMaximumAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseMaximumAdjustmentFilter
        {
            Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustmentFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseMaximumAdjustmentFilter
        {
            Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustmentFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField> expectedField =
            PlanPhaseMaximumAdjustmentFilterField.PriceID;
        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator> expectedOperator =
            PlanPhaseMaximumAdjustmentFilterOperator.Includes;
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
        var model = new PlanPhaseMaximumAdjustmentFilter
        {
            Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
            Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class PlanPhaseMaximumAdjustmentFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.PricingUnitID)]
    public void Validation_Works(PlanPhaseMaximumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.PriceID)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.ItemID)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.PriceType)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.Currency)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(PlanPhaseMaximumAdjustmentFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanPhaseMaximumAdjustmentFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PlanPhaseMaximumAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterOperator.Excludes)]
    public void Validation_Works(PlanPhaseMaximumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPhaseMaximumAdjustmentFilterOperator.Includes)]
    [InlineData(PlanPhaseMaximumAdjustmentFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(PlanPhaseMaximumAdjustmentFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
