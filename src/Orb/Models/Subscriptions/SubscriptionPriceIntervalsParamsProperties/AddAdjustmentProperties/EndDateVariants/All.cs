using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties.EndDateVariants;

[JsonConverter(typeof(VariantConverter<DateTime, System::DateTime>))]
public sealed record class DateTime(System::DateTime Value)
    : EndDate,
        IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<BillingCycleRelativeDateVariant, BillingCycleRelativeDate>))]
public sealed record class BillingCycleRelativeDateVariant(BillingCycleRelativeDate Value)
    : EndDate,
        IVariant<BillingCycleRelativeDateVariant, BillingCycleRelativeDate>
{
    public static BillingCycleRelativeDateVariant From(BillingCycleRelativeDate value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
