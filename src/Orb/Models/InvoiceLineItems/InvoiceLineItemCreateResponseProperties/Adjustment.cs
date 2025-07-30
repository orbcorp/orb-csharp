using System.Text.Json.Serialization;
using AdjustmentVariants = Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties.AdjustmentVariants;

namespace Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties;

[JsonConverter(typeof(UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(MonetaryUsageDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryUsageDiscountAdjustmentVariant(value);

    public static implicit operator Adjustment(MonetaryAmountDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryAmountDiscountAdjustmentVariant(value);

    public static implicit operator Adjustment(MonetaryPercentageDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryPercentageDiscountAdjustmentVariant(value);

    public static implicit operator Adjustment(MonetaryMinimumAdjustment value) =>
        new AdjustmentVariants::MonetaryMinimumAdjustmentVariant(value);

    public static implicit operator Adjustment(MonetaryMaximumAdjustment value) =>
        new AdjustmentVariants::MonetaryMaximumAdjustmentVariant(value);

    public abstract void Validate();
}
