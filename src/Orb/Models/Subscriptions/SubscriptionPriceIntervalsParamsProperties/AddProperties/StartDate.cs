using System.Text.Json.Serialization;
using StartDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.StartDateVariants;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;

/// <summary>
/// The start date of the price interval. This is the date that the price will start
/// billing on the subscription.
/// </summary>
[JsonConverter(typeof(UnionConverter<StartDate>))]
public abstract record class StartDate
{
    internal StartDate() { }

    public static implicit operator StartDate(System::DateTime value) =>
        new StartDateVariants::DateTime(value);

    public static implicit operator StartDate(BillingCycleRelativeDate value) =>
        new StartDateVariants::BillingCycleRelativeDateVariant(value);

    public abstract void Validate();
}
