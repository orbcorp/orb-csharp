using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewMaximumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter13Field.PriceID,
                    Operator = Filter13Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMaximumPriceType.Usage,
        };

        ApiEnum<string, NewMaximumAdjustmentType> expectedAdjustmentType =
            NewMaximumAdjustmentType.Maximum;
        string expectedMaximumAmount = "maximum_amount";
        ApiEnum<bool, NewMaximumAppliesToAll> expectedAppliesToAll = NewMaximumAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<Filter13> expectedFilters =
        [
            new()
            {
                Field = Filter13Field.PriceID,
                Operator = Filter13Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewMaximumPriceType> expectedPriceType = NewMaximumPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
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

public class Filter13Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter13
        {
            Field = Filter13Field.PriceID,
            Operator = Filter13Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter13Field> expectedField = Filter13Field.PriceID;
        ApiEnum<string, Filter13Operator> expectedOperator = Filter13Operator.Includes;
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
