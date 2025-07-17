using EndDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties.EndDateVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;

/// <summary>
/// The updated end date of this price interval. If not specified, the end date will
/// not be updated.
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
