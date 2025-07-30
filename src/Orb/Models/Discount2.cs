using System.Text.Json.Serialization;
using DiscountVariants = Orb.Models.DiscountVariants;

namespace Orb.Models;

[JsonConverter(typeof(UnionConverter<Discount2>))]
public abstract record class Discount2
{
    internal Discount2() { }

    public static implicit operator Discount2(PercentageDiscount value) =>
        new DiscountVariants::PercentageDiscountVariant(value);

    public static implicit operator Discount2(TrialDiscount value) =>
        new DiscountVariants::TrialDiscountVariant(value);

    public static implicit operator Discount2(UsageDiscount value) =>
        new DiscountVariants::UsageDiscountVariant(value);

    public static implicit operator Discount2(AmountDiscount value) =>
        new DiscountVariants::AmountDiscountVariant(value);

    public abstract void Validate();
}
