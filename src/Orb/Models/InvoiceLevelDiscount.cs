using InvoiceLevelDiscountVariants = Orb.Models.InvoiceLevelDiscountVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<InvoiceLevelDiscount>))]
public abstract record class InvoiceLevelDiscount
{
    internal InvoiceLevelDiscount() { }

    public static InvoiceLevelDiscountVariants::PercentageDiscount Create(
        PercentageDiscount value
    ) => new(value);

    public static InvoiceLevelDiscountVariants::AmountDiscount Create(AmountDiscount value) =>
        new(value);

    public static InvoiceLevelDiscountVariants::TrialDiscount Create(TrialDiscount value) =>
        new(value);

    public abstract void Validate();
}
