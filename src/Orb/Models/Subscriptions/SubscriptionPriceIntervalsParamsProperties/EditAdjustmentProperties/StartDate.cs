using System.Text.Json.Serialization;
using StartDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties.StartDateVariants;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties;

/// <summary>
/// The updated start date of this adjustment interval. If not specified, the start
/// date will not be updated.
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
