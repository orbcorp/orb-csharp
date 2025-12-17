using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedDiscountTest : TestBase
{
    [Fact]
    public void PercentageValidationWorks()
    {
        SharedDiscount value = new(
            new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void TrialValidationWorks()
    {
        SharedDiscount value = new(
            new TrialDiscount()
            {
                DiscountType = TrialDiscountDiscountType.Trial,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void UsageValidationWorks()
    {
        SharedDiscount value = new(
            new UsageDiscount()
            {
                DiscountType = UsageDiscountDiscountType.Usage,
                UsageDiscountValue = 0,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void AmountValidationWorks()
    {
        SharedDiscount value = new(
            new AmountDiscount()
            {
                AmountDiscountValue = "amount_discount",
                DiscountType = DiscountType.Amount,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void PercentageSerializationRoundtripWorks()
    {
        SharedDiscount value = new(
            new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TrialSerializationRoundtripWorks()
    {
        SharedDiscount value = new(
            new TrialDiscount()
            {
                DiscountType = TrialDiscountDiscountType.Trial,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UsageSerializationRoundtripWorks()
    {
        SharedDiscount value = new(
            new UsageDiscount()
            {
                DiscountType = UsageDiscountDiscountType.Usage,
                UsageDiscountValue = 0,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AmountSerializationRoundtripWorks()
    {
        SharedDiscount value = new(
            new AmountDiscount()
            {
                AmountDiscountValue = "amount_discount",
                DiscountType = DiscountType.Amount,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SharedDiscount>(json);

        Assert.Equal(value, deserialized);
    }
}
