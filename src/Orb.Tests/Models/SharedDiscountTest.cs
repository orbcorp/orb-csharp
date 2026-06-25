using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedDiscountTest : TestBase
{
    [Fact]
    public void PercentageValidationWorks()
    {
        SharedDiscount value = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        value.Validate();
    }

    [Fact]
    public void TrialValidationWorks()
    {
        SharedDiscount value = new TrialDiscount()
        {
            DiscountType = TrialDiscountDiscountType.Trial,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TrialDiscountFilterField.PriceID,
                    Operator = TrialDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
            TrialAmountDiscount = "trial_amount_discount",
            TrialPercentageDiscount = 0,
        };
        value.Validate();
    }

    [Fact]
    public void UsageValidationWorks()
    {
        SharedDiscount value = new UsageDiscount()
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = UsageDiscountFilterField.PriceID,
                    Operator = UsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        value.Validate();
    }

    [Fact]
    public void AmountValidationWorks()
    {
        SharedDiscount value = new AmountDiscount()
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = AmountDiscountFilterField.PriceID,
                    Operator = AmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        value.Validate();
    }

    [Fact]
    public void TieredPercentageValidationWorks()
    {
        SharedDiscount value = new TieredPercentage()
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TieredPercentageFilterField.PriceID,
                    Operator = TieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        value.Validate();
    }

    [Fact]
    public void PercentageSerializationRoundtripWorks()
    {
        SharedDiscount value = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TrialSerializationRoundtripWorks()
    {
        SharedDiscount value = new TrialDiscount()
        {
            DiscountType = TrialDiscountDiscountType.Trial,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TrialDiscountFilterField.PriceID,
                    Operator = TrialDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
            TrialAmountDiscount = "trial_amount_discount",
            TrialPercentageDiscount = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UsageSerializationRoundtripWorks()
    {
        SharedDiscount value = new UsageDiscount()
        {
            DiscountType = UsageDiscountDiscountType.Usage,
            UsageDiscountValue = 0,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = UsageDiscountFilterField.PriceID,
                    Operator = UsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AmountSerializationRoundtripWorks()
    {
        SharedDiscount value = new AmountDiscount()
        {
            AmountDiscountValue = "amount_discount",
            DiscountType = DiscountType.Amount,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = AmountDiscountFilterField.PriceID,
                    Operator = AmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredPercentageSerializationRoundtripWorks()
    {
        SharedDiscount value = new TieredPercentage()
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TieredPercentageFilterField.PriceID,
                    Operator = TieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TieredPercentageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TieredPercentageFilterField.PriceID,
                    Operator = TieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
        List<TieredPercentageTier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<TieredPercentageFilter> expectedFilters =
        [
            new()
            {
                Field = TieredPercentageFilterField.PriceID,
                Operator = TieredPercentageFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
        Assert.NotNull(model.AppliesToPriceIds);
        Assert.Equal(expectedAppliesToPriceIds.Count, model.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], model.AppliesToPriceIds[i]);
        }
        Assert.NotNull(model.Filters);
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
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TieredPercentageFilterField.PriceID,
                    Operator = TieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TieredPercentageFilterField.PriceID,
                    Operator = TieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
        List<TieredPercentageTier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<TieredPercentageFilter> expectedFilters =
        [
            new()
            {
                Field = TieredPercentageFilterField.PriceID,
                Operator = TieredPercentageFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedReason = "reason";

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, deserialized.DiscountType));
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
        Assert.NotNull(deserialized.AppliesToPriceIds);
        Assert.Equal(expectedAppliesToPriceIds.Count, deserialized.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], deserialized.AppliesToPriceIds[i]);
        }
        Assert.NotNull(deserialized.Filters);
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
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TieredPercentageFilterField.PriceID,
                    Operator = TieredPercentageFilterOperator.Includes,
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
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        Assert.Null(model.AppliesToPriceIds);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],

            AppliesToPriceIds = null,
            Filters = null,
            Reason = null,
        };

        Assert.Null(model.AppliesToPriceIds);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],

            AppliesToPriceIds = null,
            Filters = null,
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TieredPercentage
        {
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = TieredPercentageFilterField.PriceID,
                    Operator = TieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        TieredPercentage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TieredPercentageTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        double expectedLowerBound = 0;
        double expectedPercentage = 0;
        double expectedUpperBound = 0;

        Assert.Equal(expectedLowerBound, model.LowerBound);
        Assert.Equal(expectedPercentage, model.Percentage);
        Assert.Equal(expectedUpperBound, model.UpperBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentageTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentageTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedLowerBound = 0;
        double expectedPercentage = 0;
        double expectedUpperBound = 0;

        Assert.Equal(expectedLowerBound, deserialized.LowerBound);
        Assert.Equal(expectedPercentage, deserialized.Percentage);
        Assert.Equal(expectedUpperBound, deserialized.UpperBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TieredPercentageTier { LowerBound = 0, Percentage = 0 };

        Assert.Null(model.UpperBound);
        Assert.False(model.RawData.ContainsKey("upper_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TieredPercentageTier { LowerBound = 0, Percentage = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,

            UpperBound = null,
        };

        Assert.Null(model.UpperBound);
        Assert.True(model.RawData.ContainsKey("upper_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,

            UpperBound = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        TieredPercentageTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TieredPercentageFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPercentageFilter
        {
            Field = TieredPercentageFilterField.PriceID,
            Operator = TieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, TieredPercentageFilterField> expectedField =
            TieredPercentageFilterField.PriceID;
        ApiEnum<string, TieredPercentageFilterOperator> expectedOperator =
            TieredPercentageFilterOperator.Includes;
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
        var model = new TieredPercentageFilter
        {
            Field = TieredPercentageFilterField.PriceID,
            Operator = TieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentageFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredPercentageFilter
        {
            Field = TieredPercentageFilterField.PriceID,
            Operator = TieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentageFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TieredPercentageFilterField> expectedField =
            TieredPercentageFilterField.PriceID;
        ApiEnum<string, TieredPercentageFilterOperator> expectedOperator =
            TieredPercentageFilterOperator.Includes;
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
        var model = new TieredPercentageFilter
        {
            Field = TieredPercentageFilterField.PriceID,
            Operator = TieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TieredPercentageFilter
        {
            Field = TieredPercentageFilterField.PriceID,
            Operator = TieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        TieredPercentageFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TieredPercentageFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(TieredPercentageFilterField.PriceID)]
    [InlineData(TieredPercentageFilterField.ItemID)]
    [InlineData(TieredPercentageFilterField.PriceType)]
    [InlineData(TieredPercentageFilterField.Currency)]
    [InlineData(TieredPercentageFilterField.PricingUnitID)]
    public void Validation_Works(TieredPercentageFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TieredPercentageFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TieredPercentageFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TieredPercentageFilterField.PriceID)]
    [InlineData(TieredPercentageFilterField.ItemID)]
    [InlineData(TieredPercentageFilterField.PriceType)]
    [InlineData(TieredPercentageFilterField.Currency)]
    [InlineData(TieredPercentageFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(TieredPercentageFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TieredPercentageFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TieredPercentageFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TieredPercentageFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TieredPercentageFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TieredPercentageFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(TieredPercentageFilterOperator.Includes)]
    [InlineData(TieredPercentageFilterOperator.Excludes)]
    public void Validation_Works(TieredPercentageFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TieredPercentageFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TieredPercentageFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TieredPercentageFilterOperator.Includes)]
    [InlineData(TieredPercentageFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(TieredPercentageFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TieredPercentageFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TieredPercentageFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TieredPercentageFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TieredPercentageFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
