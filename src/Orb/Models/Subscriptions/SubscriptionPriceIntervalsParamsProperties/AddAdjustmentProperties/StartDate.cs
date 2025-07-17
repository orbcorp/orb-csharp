using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using StartDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties.StartDateVariants;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties;

/// <summary>
/// The start date of the adjustment interval. This is the date that the adjustment
/// will start affecting prices on the subscription. The adjustment will apply to
/// invoice dates that overlap with this `start_date`. This `start_date` is treated
/// as inclusive for in-advance prices, and exclusive for in-arrears prices.
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
