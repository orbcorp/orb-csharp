using Orb.Core;
using System = System;
using TrialEndDateProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateVariants;

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

public sealed record class UnionMember1(ApiEnum<string, TrialEndDateProperties::UnionMember1> Value)
    : TrialEndDate,
        IVariant<UnionMember1, ApiEnum<string, TrialEndDateProperties::UnionMember1>>
{
    public static UnionMember1 From(ApiEnum<string, TrialEndDateProperties::UnionMember1> value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
