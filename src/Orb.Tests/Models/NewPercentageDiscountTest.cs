using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewPercentageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter15Field.PriceID,
                    Operator = Filter15Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewPercentageDiscountPriceType.Usage,
        };

        ApiEnum<string, NewPercentageDiscountAdjustmentType> expectedAdjustmentType =
            NewPercentageDiscountAdjustmentType.PercentageDiscount;
        double expectedPercentageDiscount = 0;
        ApiEnum<bool, NewPercentageDiscountAppliesToAll> expectedAppliesToAll =
            NewPercentageDiscountAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<Filter15> expectedFilters =
        [
            new()
            {
                Field = Filter15Field.PriceID,
                Operator = Filter15Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewPercentageDiscountPriceType> expectedPriceType =
            NewPercentageDiscountPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedAppliesToAll, model.AppliesToAll);
        Assert.Equal(expectedAppliesToItemIDs.Count, model.AppliesToItemIDs.Count);
        for (int i = 0; i < expectedAppliesToItemIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIDs[i], model.AppliesToItemIDs[i]);
        }
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, model.IsInvoiceLevel);
        Assert.Equal(expectedPriceType, model.PriceType);
    }
}

public class Filter15Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter15
        {
            Field = Filter15Field.PriceID,
            Operator = Filter15Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter15Field> expectedField = Filter15Field.PriceID;
        ApiEnum<string, Filter15Operator> expectedOperator = Filter15Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}
