using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
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
            AppliesToPriceIDs = ["string"],
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
        List<string> expectedAppliesToPriceIDs = ["string"];
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
            AppliesToPriceIDs = ["string"],
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
            AppliesToPriceIDs = ["string"],
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
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, AdjustmentType> expectedAdjustmentType = AdjustmentType.AmountDiscount;
        string expectedAmount = "amount";
        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIDs = ["string"];
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
            AppliesToPriceIDs = ["string"],
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustmentFilter>(json);
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
