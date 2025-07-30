using System.Text.Json.Serialization;
using System = System;
using TrialEndDateProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateVariants;

[JsonConverter(typeof(VariantConverter<DateTime, System::DateTime>))]
public sealed record class DateTime(System::DateTime Value)
    : TrialEndDate,
        IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<UnionMember1, TrialEndDateProperties::UnionMember1>))]
public sealed record class UnionMember1(TrialEndDateProperties::UnionMember1 Value)
    : TrialEndDate,
        IVariant<UnionMember1, TrialEndDateProperties::UnionMember1>
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
