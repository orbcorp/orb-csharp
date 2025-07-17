using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using StartDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.StartDateVariants;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;

/// <summary>
/// The start date of the price interval. This is the date that the price will start
/// billing on the subscription.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<StartDate>))]
public abstract record class StartDate
{
    internal StartDate() { }

    public static StartDateVariants::DateTime Create(System::DateTime value) => new(value);

    public static StartDateVariants::BillingCycleRelativeDate Create(
        Models::BillingCycleRelativeDate value
    ) => new(value);

    public abstract void Validate();
}
