using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
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
            AppliesToPriceIDs = ["string"],
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
        List<string> expectedAppliesToPriceIDs = ["string"];
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
            AppliesToPriceIDs = ["string"],
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustment>(json);

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
            AppliesToPriceIDs = ["string"],
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustment>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIDs = ["string"];
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
            AppliesToPriceIDs = ["string"],
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustmentFilter>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustmentFilter>(json);
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
}
