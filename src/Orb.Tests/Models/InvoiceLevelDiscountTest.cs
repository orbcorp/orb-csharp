using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class InvoiceLevelDiscountTest : TestBase
{
    [Fact]
    public void PercentageValidationWorks()
    {
        InvoiceLevelDiscount value = new PercentageDiscount()
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
    public void AmountValidationWorks()
    {
        InvoiceLevelDiscount value = new AmountDiscount()
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
    public void TrialValidationWorks()
    {
        InvoiceLevelDiscount value = new TrialDiscount()
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
    public void TieredPercentageValidationWorks()
    {
        InvoiceLevelDiscount value = new InvoiceLevelDiscountTieredPercentage()
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
                    Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                    Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
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
        InvoiceLevelDiscount value = new PercentageDiscount()
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
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AmountSerializationRoundtripWorks()
    {
        InvoiceLevelDiscount value = new AmountDiscount()
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
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TrialSerializationRoundtripWorks()
    {
        InvoiceLevelDiscount value = new TrialDiscount()
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
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredPercentageSerializationRoundtripWorks()
    {
        InvoiceLevelDiscount value = new InvoiceLevelDiscountTieredPercentage()
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
                    Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                    Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceLevelDiscountTieredPercentageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentage
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
                    Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                    Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
        List<InvoiceLevelDiscountTieredPercentageTier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<InvoiceLevelDiscountTieredPercentageFilter> expectedFilters =
        [
            new()
            {
                Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
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
        var model = new InvoiceLevelDiscountTieredPercentage
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
                    Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                    Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscountTieredPercentage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentage
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
                    Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                    Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscountTieredPercentage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
        List<InvoiceLevelDiscountTieredPercentageTier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];
        List<string> expectedAppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"];
        List<InvoiceLevelDiscountTieredPercentageFilter> expectedFilters =
        [
            new()
            {
                Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
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
        var model = new InvoiceLevelDiscountTieredPercentage
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
                    Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                    Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
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
        var model = new InvoiceLevelDiscountTieredPercentage
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
        var model = new InvoiceLevelDiscountTieredPercentage
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
        var model = new InvoiceLevelDiscountTieredPercentage
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
        var model = new InvoiceLevelDiscountTieredPercentage
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
        var model = new InvoiceLevelDiscountTieredPercentage
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
                    Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
                    Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };

        InvoiceLevelDiscountTieredPercentage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceLevelDiscountTieredPercentageTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentageTier
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
        var model = new InvoiceLevelDiscountTieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscountTieredPercentageTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscountTieredPercentageTier>(
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
        var model = new InvoiceLevelDiscountTieredPercentageTier
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
        var model = new InvoiceLevelDiscountTieredPercentageTier { LowerBound = 0, Percentage = 0 };

        Assert.Null(model.UpperBound);
        Assert.False(model.RawData.ContainsKey("upper_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentageTier { LowerBound = 0, Percentage = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentageTier
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
        var model = new InvoiceLevelDiscountTieredPercentageTier
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
        var model = new InvoiceLevelDiscountTieredPercentageTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        InvoiceLevelDiscountTieredPercentageTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceLevelDiscountTieredPercentageFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentageFilter
        {
            Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
            Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField> expectedField =
            InvoiceLevelDiscountTieredPercentageFilterField.PriceID;
        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator> expectedOperator =
            InvoiceLevelDiscountTieredPercentageFilterOperator.Includes;
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
        var model = new InvoiceLevelDiscountTieredPercentageFilter
        {
            Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
            Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscountTieredPercentageFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentageFilter
        {
            Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
            Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscountTieredPercentageFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField> expectedField =
            InvoiceLevelDiscountTieredPercentageFilterField.PriceID;
        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator> expectedOperator =
            InvoiceLevelDiscountTieredPercentageFilterOperator.Includes;
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
        var model = new InvoiceLevelDiscountTieredPercentageFilter
        {
            Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
            Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceLevelDiscountTieredPercentageFilter
        {
            Field = InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
            Operator = InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
            Values = ["string"],
        };

        InvoiceLevelDiscountTieredPercentageFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceLevelDiscountTieredPercentageFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.PriceID)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.ItemID)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.PriceType)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.Currency)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.PricingUnitID)]
    public void Validation_Works(InvoiceLevelDiscountTieredPercentageFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.PriceID)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.ItemID)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.PriceType)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.Currency)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(
        InvoiceLevelDiscountTieredPercentageFilterField rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceLevelDiscountTieredPercentageFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterOperator.Includes)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterOperator.Excludes)]
    public void Validation_Works(InvoiceLevelDiscountTieredPercentageFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterOperator.Includes)]
    [InlineData(InvoiceLevelDiscountTieredPercentageFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        InvoiceLevelDiscountTieredPercentageFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
