using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class UsageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter26Field.PriceID,
                    Operator = Filter26Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        ApiEnum<string, UsageDiscountDiscountType> expectedDiscountType =
            UsageDiscountDiscountType.Usage;
        double expectedUsageDiscount1 = 0;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<Filter26> expectedFilters =
        [
            new()
            {
                Field = Filter26Field.PriceID,
                Operator = Filter26Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedUsageDiscount1, model.UsageDiscount1);
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter26Field.PriceID,
                    Operator = Filter26Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter26Field.PriceID,
                    Operator = Filter26Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscount>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, UsageDiscountDiscountType> expectedDiscountType =
            UsageDiscountDiscountType.Usage;
        double expectedUsageDiscount1 = 0;
        List<string> expectedAppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<Filter26> expectedFilters =
        [
            new()
            {
                Field = Filter26Field.PriceID,
                Operator = Filter26Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedUsageDiscount1, deserialized.UsageDiscount1);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter26Field.PriceID,
                    Operator = Filter26Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,
        };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
        };

        Assert.Null(model.AppliesToPriceIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UsageDiscount
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscount1 = 0,

            AppliesToPriceIDs = null,
            Filters = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class Filter26Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter26
        {
            Field = Filter26Field.PriceID,
            Operator = Filter26Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter26Field> expectedField = Filter26Field.PriceID;
        ApiEnum<string, Filter26Operator> expectedOperator = Filter26Operator.Includes;
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
        var model = new Filter26
        {
            Field = Filter26Field.PriceID,
            Operator = Filter26Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter26>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter26
        {
            Field = Filter26Field.PriceID,
            Operator = Filter26Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter26>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter26Field> expectedField = Filter26Field.PriceID;
        ApiEnum<string, Filter26Operator> expectedOperator = Filter26Operator.Includes;
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
        var model = new Filter26
        {
            Field = Filter26Field.PriceID,
            Operator = Filter26Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
