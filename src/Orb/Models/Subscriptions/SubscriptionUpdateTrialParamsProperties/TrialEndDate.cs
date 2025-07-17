using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using TrialEndDateProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;
using TrialEndDateVariants = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateVariants;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties;

/// <summary>
/// The new date that the trial should end, or the literal string `immediate` to end
/// the trial immediately.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<TrialEndDate>))]
public abstract record class TrialEndDate
{
    internal TrialEndDate() { }

    public static TrialEndDateVariants::UnionMember0 Create(System::DateTime value) => new(value);

    public static TrialEndDateVariants::UnionMember1 Create(
        TrialEndDateProperties::UnionMember1 value
    ) => new(value);

    public abstract void Validate();
}
