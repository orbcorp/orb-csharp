using InvoiceLineItemCreateResponseProperties = Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties.AdjustmentVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        MonetaryUsageDiscountAdjustment,
        Models::MonetaryUsageDiscountAdjustment
    >)
)]
public sealed record class MonetaryUsageDiscountAdjustment(
    Models::MonetaryUsageDiscountAdjustment Value
)
    : InvoiceLineItemCreateResponseProperties::Adjustment,
        Orb::IVariant<MonetaryUsageDiscountAdjustment, Models::MonetaryUsageDiscountAdjustment>
{
    public static MonetaryUsageDiscountAdjustment From(
        Models::MonetaryUsageDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        MonetaryAmountDiscountAdjustment,
        Models::MonetaryAmountDiscountAdjustment
    >)
)]
public sealed record class MonetaryAmountDiscountAdjustment(
    Models::MonetaryAmountDiscountAdjustment Value
)
    : InvoiceLineItemCreateResponseProperties::Adjustment,
        Orb::IVariant<MonetaryAmountDiscountAdjustment, Models::MonetaryAmountDiscountAdjustment>
{
    public static MonetaryAmountDiscountAdjustment From(
        Models::MonetaryAmountDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        MonetaryPercentageDiscountAdjustment,
        Models::MonetaryPercentageDiscountAdjustment
    >)
)]
public sealed record class MonetaryPercentageDiscountAdjustment(
    Models::MonetaryPercentageDiscountAdjustment Value
)
    : InvoiceLineItemCreateResponseProperties::Adjustment,
        Orb::IVariant<
            MonetaryPercentageDiscountAdjustment,
            Models::MonetaryPercentageDiscountAdjustment
        >
{
    public static MonetaryPercentageDiscountAdjustment From(
        Models::MonetaryPercentageDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<MonetaryMinimumAdjustment, Models::MonetaryMinimumAdjustment>)
)]
public sealed record class MonetaryMinimumAdjustment(Models::MonetaryMinimumAdjustment Value)
    : InvoiceLineItemCreateResponseProperties::Adjustment,
        Orb::IVariant<MonetaryMinimumAdjustment, Models::MonetaryMinimumAdjustment>
{
    public static MonetaryMinimumAdjustment From(Models::MonetaryMinimumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<MonetaryMaximumAdjustment, Models::MonetaryMaximumAdjustment>)
)]
public sealed record class MonetaryMaximumAdjustment(Models::MonetaryMaximumAdjustment Value)
    : InvoiceLineItemCreateResponseProperties::Adjustment,
        Orb::IVariant<MonetaryMaximumAdjustment, Models::MonetaryMaximumAdjustment>
{
    public static MonetaryMaximumAdjustment From(Models::MonetaryMaximumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
