using System.Text.Json;
using Orb.Core;
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
}
