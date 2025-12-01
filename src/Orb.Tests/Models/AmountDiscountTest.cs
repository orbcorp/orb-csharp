using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class AmountDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmountDiscount
        {
            AmountDiscount1 = "amount_discount",
            DiscountType = DiscountType.Amount,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = FilterModelField.PriceID,
                    Operator = FilterModelOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string expectedAmountDiscount1 = "amount_discount";
        ApiEnum<string, DiscountType> expectedDiscountType = DiscountType.Amount;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<FilterModel> expectedFilters =
        [
            new()
            {
                Field = FilterModelField.PriceID,
                Operator = FilterModelOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountDiscount1, model.AmountDiscount1);
        Assert.Equal(expectedDiscountType, model.DiscountType);
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
        Assert.Equal(expectedReason, model.Reason);
    }
}

public class FilterModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterModel
        {
            Field = FilterModelField.PriceID,
            Operator = FilterModelOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, FilterModelField> expectedField = FilterModelField.PriceID;
        ApiEnum<string, FilterModelOperator> expectedOperator = FilterModelOperator.Includes;
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
