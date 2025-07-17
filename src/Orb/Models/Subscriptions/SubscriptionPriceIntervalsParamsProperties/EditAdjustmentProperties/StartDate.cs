using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using StartDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties.StartDateVariants;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties;

/// <summary>
/// The updated start date of this adjustment interval. If not specified, the start
/// date will not be updated.
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
