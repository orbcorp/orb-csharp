using EndDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.EndDateVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;

/// <summary>
/// The end date of the price interval. This is the date that the price will stop
/// billing on the subscription.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<EndDate>))]
public abstract record class EndDate
{
    internal EndDate() { }

    public static implicit operator EndDate(System::DateTime value) =>
        new EndDateVariants::DateTime(value);

    public static implicit operator EndDate(Models::BillingCycleRelativeDate value) =>
        new EndDateVariants::BillingCycleRelativeDate(value);

    public abstract void Validate();
}
