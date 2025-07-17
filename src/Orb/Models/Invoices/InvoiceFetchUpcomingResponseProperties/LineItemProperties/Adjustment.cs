using AdjustmentVariants = Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.LineItemProperties.AdjustmentVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.LineItemProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static AdjustmentVariants::MonetaryUsageDiscountAdjustment Create(
        Models::MonetaryUsageDiscountAdjustment value
    ) => new(value);

    public static AdjustmentVariants::MonetaryAmountDiscountAdjustment Create(
        Models::MonetaryAmountDiscountAdjustment value
    ) => new(value);

    public static AdjustmentVariants::MonetaryPercentageDiscountAdjustment Create(
        Models::MonetaryPercentageDiscountAdjustment value
    ) => new(value);

    public static AdjustmentVariants::MonetaryMinimumAdjustment Create(
        Models::MonetaryMinimumAdjustment value
    ) => new(value);

    public static AdjustmentVariants::MonetaryMaximumAdjustment Create(
        Models::MonetaryMaximumAdjustment value
    ) => new(value);

    public abstract void Validate();
}
