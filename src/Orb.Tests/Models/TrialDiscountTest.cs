using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class TrialDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter25Field.PriceID,
                    Operator = Filter25Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
            TrialAmountDiscount = "trial_amount_discount",
            TrialPercentageDiscount = 0,
        };

        ApiEnum<string, TrialDiscountDiscountType> expectedDiscountType =
            TrialDiscountDiscountType.Trial;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<Filter25> expectedFilters =
        [
            new()
            {
                Field = Filter25Field.PriceID,
                Operator = Filter25Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";
        string expectedTrialAmountDiscount = "trial_amount_discount";
        double expectedTrialPercentageDiscount = 0;

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
        Assert.Equal(expectedTrialAmountDiscount, model.TrialAmountDiscount);
        Assert.Equal(expectedTrialPercentageDiscount, model.TrialPercentageDiscount);
    }
}

public class Filter25Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter25
        {
            Field = Filter25Field.PriceID,
            Operator = Filter25Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter25Field> expectedField = Filter25Field.PriceID;
        ApiEnum<string, Filter25Operator> expectedOperator = Filter25Operator.Includes;
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
