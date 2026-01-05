using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class InvoiceLevelDiscountTest : TestBase
{
    [Fact]
    public void PercentageValidationWorks()
    {
        InvoiceLevelDiscount value = new(
            new PercentageDiscount()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void AmountValidationWorks()
    {
        InvoiceLevelDiscount value = new(
            new AmountDiscount()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void TrialValidationWorks()
    {
        InvoiceLevelDiscount value = new(
            new TrialDiscount()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void PercentageSerializationRoundtripWorks()
    {
        InvoiceLevelDiscount value = new(
            new PercentageDiscount()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AmountSerializationRoundtripWorks()
    {
        InvoiceLevelDiscount value = new(
            new AmountDiscount()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TrialSerializationRoundtripWorks()
    {
        InvoiceLevelDiscount value = new(
            new TrialDiscount()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<InvoiceLevelDiscount>(element);

        Assert.Equal(value, deserialized);
    }
}
