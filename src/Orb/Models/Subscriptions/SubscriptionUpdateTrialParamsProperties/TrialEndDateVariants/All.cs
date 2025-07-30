using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubscriptionUpdateTrialParamsProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties;
using System = System;
using TrialEndDateProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<DateTime, System::DateTime>))]
public sealed record class DateTime(System::DateTime Value)
    : SubscriptionUpdateTrialParamsProperties::TrialEndDate,
        Orb::IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<UnionMember1, TrialEndDateProperties::UnionMember1>)
)]
public sealed record class UnionMember1(TrialEndDateProperties::UnionMember1 Value)
    : SubscriptionUpdateTrialParamsProperties::TrialEndDate,
        Orb::IVariant<UnionMember1, TrialEndDateProperties::UnionMember1>
{
    public static UnionMember1 From(TrialEndDateProperties::UnionMember1 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
