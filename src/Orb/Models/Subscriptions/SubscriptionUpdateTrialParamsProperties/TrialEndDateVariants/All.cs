using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubscriptionUpdateTrialParamsProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties;
using System = System;
using TrialEndDateProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<UnionMember0, System::DateTime>))]
public sealed record class UnionMember0(System::DateTime Value)
    : SubscriptionUpdateTrialParamsProperties::TrialEndDate,
        Orb::IVariant<UnionMember0, System::DateTime>
{
    public static UnionMember0 From(System::DateTime value)
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
