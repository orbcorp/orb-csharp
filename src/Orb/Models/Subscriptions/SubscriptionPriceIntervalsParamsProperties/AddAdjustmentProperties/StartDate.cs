using System.Text.Json.Serialization;
using StartDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties.StartDateVariants;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties;

/// <summary>
/// The start date of the adjustment interval. This is the date that the adjustment
/// will start affecting prices on the subscription. The adjustment will apply to
/// invoice dates that overlap with this `start_date`. This `start_date` is treated
/// as inclusive for in-advance prices, and exclusive for in-arrears prices.
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
