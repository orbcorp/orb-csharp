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

    public static implicit operator TrialEndDate(System::DateTime value) =>
        new TrialEndDateVariants::UnionMember0(value);

    public static implicit operator TrialEndDate(TrialEndDateProperties::UnionMember1 value) =>
        new TrialEndDateVariants::UnionMember1(value);

    public abstract void Validate();
}
