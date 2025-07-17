using DiscountVariants = Orb.Models.DiscountVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static DiscountVariants::PercentageDiscount Create(PercentageDiscount value) =>
        new(value);

    public static DiscountVariants::TrialDiscount Create(TrialDiscount value) => new(value);

    public static DiscountVariants::UsageDiscount Create(UsageDiscount value) => new(value);

    public static DiscountVariants::AmountDiscount Create(AmountDiscount value) => new(value);

    public abstract void Validate();
}
