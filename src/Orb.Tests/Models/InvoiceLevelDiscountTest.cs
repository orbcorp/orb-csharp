using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class InvoiceLevelDiscountTest : TestBase
{
    [Fact]
    public void percentageValidation_Works()
    {
        InvoiceLevelDiscount value = new(
            new()
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
    public void amountValidation_Works()
    {
        InvoiceLevelDiscount value = new(
            new()
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
    public void trialValidation_Works()
    {
        InvoiceLevelDiscount value = new(
            new()
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
    public void percentageSerializationRoundtrip_Works()
    {
        InvoiceLevelDiscount value = new(
            new()
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
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void amountSerializationRoundtrip_Works()
    {
        InvoiceLevelDiscount value = new(
            new()
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
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void trialSerializationRoundtrip_Works()
    {
        InvoiceLevelDiscount value = new(
            new()
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
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(json);

        Assert.Equal(value, deserialized);
    }
}
