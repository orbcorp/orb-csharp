using EndDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties.EndDateVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties;

/// <summary>
/// The end date of the adjustment interval. This is the date that the adjustment
/// will stop affecting prices on the subscription. The adjustment will apply to invoice
/// dates that overlap with this `end_date`.This `end_date` is treated as exclusive
/// for in-advance prices, and inclusive for in-arrears prices.
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
