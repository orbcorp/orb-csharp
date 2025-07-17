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

    public static EndDateVariants::DateTime Create(System::DateTime value) => new(value);

    public static EndDateVariants::BillingCycleRelativeDate Create(
        Models::BillingCycleRelativeDate value
    ) => new(value);

    public abstract void Validate();
}
