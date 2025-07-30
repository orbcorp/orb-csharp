using System.Text.Json.Serialization;
using InvoiceLevelDiscountVariants = Orb.Models.InvoiceLevelDiscountVariants;

namespace Orb.Models;

[JsonConverter(typeof(UnionConverter<InvoiceLevelDiscount>))]
public abstract record class InvoiceLevelDiscount
{
    internal InvoiceLevelDiscount() { }

    public static implicit operator InvoiceLevelDiscount(PercentageDiscount value) =>
        new InvoiceLevelDiscountVariants::PercentageDiscountVariant(value);

    public static implicit operator InvoiceLevelDiscount(AmountDiscount value) =>
        new InvoiceLevelDiscountVariants::AmountDiscountVariant(value);

    public static implicit operator InvoiceLevelDiscount(TrialDiscount value) =>
        new InvoiceLevelDiscountVariants::TrialDiscountVariant(value);

    public abstract void Validate();
}
