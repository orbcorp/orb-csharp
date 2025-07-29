using InvoiceLevelDiscountVariants = Orb.Models.InvoiceLevelDiscountVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<InvoiceLevelDiscount>))]
public abstract record class InvoiceLevelDiscount
{
    internal InvoiceLevelDiscount() { }

    public static implicit operator InvoiceLevelDiscount(PercentageDiscount value) =>
        new InvoiceLevelDiscountVariants::PercentageDiscount(value);

    public static implicit operator InvoiceLevelDiscount(AmountDiscount value) =>
        new InvoiceLevelDiscountVariants::AmountDiscount(value);

    public static implicit operator InvoiceLevelDiscount(TrialDiscount value) =>
        new InvoiceLevelDiscountVariants::TrialDiscount(value);

    public abstract void Validate();
}
