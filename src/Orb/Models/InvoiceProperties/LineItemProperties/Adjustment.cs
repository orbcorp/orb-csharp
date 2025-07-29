using AdjustmentVariants = Orb.Models.InvoiceProperties.LineItemProperties.AdjustmentVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.InvoiceProperties.LineItemProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(Models::MonetaryUsageDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryUsageDiscountAdjustment(value);

    public static implicit operator Adjustment(Models::MonetaryAmountDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryAmountDiscountAdjustment(value);

    public static implicit operator Adjustment(
        Models::MonetaryPercentageDiscountAdjustment value
    ) => new AdjustmentVariants::MonetaryPercentageDiscountAdjustment(value);

    public static implicit operator Adjustment(Models::MonetaryMinimumAdjustment value) =>
        new AdjustmentVariants::MonetaryMinimumAdjustment(value);

    public static implicit operator Adjustment(Models::MonetaryMaximumAdjustment value) =>
        new AdjustmentVariants::MonetaryMaximumAdjustment(value);

    public abstract void Validate();
}
