using EditProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties.EndDateVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<DateTime, System::DateTime>))]
public sealed record class DateTime(System::DateTime Value)
    : EditProperties::EndDate,
        Orb::IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<BillingCycleRelativeDate, Models::BillingCycleRelativeDate>)
)]
public sealed record class BillingCycleRelativeDate(Models::BillingCycleRelativeDate Value)
    : EditProperties::EndDate,
        Orb::IVariant<BillingCycleRelativeDate, Models::BillingCycleRelativeDate>
{
    public static BillingCycleRelativeDate From(Models::BillingCycleRelativeDate value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
