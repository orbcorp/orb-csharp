using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialDiscount>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
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
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTrialAmountDiscount, deserialized.TrialAmountDiscount);
        Assert.Equal(expectedTrialPercentageDiscount, deserialized.TrialPercentageDiscount);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TrialDiscount { DiscountType = TrialDiscountDiscountType.Trial };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.TrialAmountDiscount);
        Assert.False(model.RawData.ContainsKey("trial_amount_discount"));
        Assert.Null(model.TrialPercentageDiscount);
        Assert.False(model.RawData.ContainsKey("trial_percentage_discount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TrialDiscount { DiscountType = TrialDiscountDiscountType.Trial };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
            TrialAmountDiscount = null,
            TrialPercentageDiscount = null,
        };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.TrialAmountDiscount);
        Assert.True(model.RawData.ContainsKey("trial_amount_discount"));
        Assert.Null(model.TrialPercentageDiscount);
        Assert.True(model.RawData.ContainsKey("trial_percentage_discount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TrialDiscount
        {
            DiscountType = TrialDiscountDiscountType.Trial,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
            TrialAmountDiscount = null,
            TrialPercentageDiscount = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filter25
        {
            Field = Filter25Field.PriceID,
            Operator = Filter25Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter25>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter25
        {
            Field = Filter25Field.PriceID,
            Operator = Filter25Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter25>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter25Field> expectedField = Filter25Field.PriceID;
        ApiEnum<string, Filter25Operator> expectedOperator = Filter25Operator.Includes;
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
        var model = new Filter25
        {
            Field = Filter25Field.PriceID,
            Operator = Filter25Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
