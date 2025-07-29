using DiscountVariants = Orb.Models.DiscountVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(PercentageDiscount value) =>
        new DiscountVariants::PercentageDiscount(value);

    public static implicit operator Discount(TrialDiscount value) =>
        new DiscountVariants::TrialDiscount(value);

    public static implicit operator Discount(UsageDiscount value) =>
        new DiscountVariants::UsageDiscount(value);

    public static implicit operator Discount(AmountDiscount value) =>
        new DiscountVariants::AmountDiscount(value);

    public abstract void Validate();
}
