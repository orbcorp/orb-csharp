using AddAdjustmentProperties = Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.AddAdjustmentProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.AddAdjustmentProperties.AdjustmentVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPercentageDiscount, Models::NewPercentageDiscount>)
)]
public sealed record class NewPercentageDiscount(Models::NewPercentageDiscount Value)
    : AddAdjustmentProperties::Adjustment,
        Orb::IVariant<NewPercentageDiscount, Models::NewPercentageDiscount>
{
    public static NewPercentageDiscount From(Models::NewPercentageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewUsageDiscount, Models::NewUsageDiscount>)
)]
public sealed record class NewUsageDiscount(Models::NewUsageDiscount Value)
    : AddAdjustmentProperties::Adjustment,
        Orb::IVariant<NewUsageDiscount, Models::NewUsageDiscount>
{
    public static NewUsageDiscount From(Models::NewUsageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewAmountDiscount, Models::NewAmountDiscount>)
)]
public sealed record class NewAmountDiscount(Models::NewAmountDiscount Value)
    : AddAdjustmentProperties::Adjustment,
        Orb::IVariant<NewAmountDiscount, Models::NewAmountDiscount>
{
    public static NewAmountDiscount From(Models::NewAmountDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<NewMinimum, Models::NewMinimum>))]
public sealed record class NewMinimum(Models::NewMinimum Value)
    : AddAdjustmentProperties::Adjustment,
        Orb::IVariant<NewMinimum, Models::NewMinimum>
{
    public static NewMinimum From(Models::NewMinimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<NewMaximum, Models::NewMaximum>))]
public sealed record class NewMaximum(Models::NewMaximum Value)
    : AddAdjustmentProperties::Adjustment,
        Orb::IVariant<NewMaximum, Models::NewMaximum>
{
    public static NewMaximum From(Models::NewMaximum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
