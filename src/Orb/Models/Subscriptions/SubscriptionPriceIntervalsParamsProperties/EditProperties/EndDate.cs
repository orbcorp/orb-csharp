using System.Text.Json.Serialization;
using EndDateVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties.EndDateVariants;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;

/// <summary>
/// The updated end date of this price interval. If not specified, the end date will
/// not be updated.
/// </summary>
[JsonConverter(typeof(UnionConverter<EndDate>))]
public abstract record class EndDate
{
    internal EndDate() { }

    public static implicit operator EndDate(System::DateTime value) =>
        new EndDateVariants::DateTime(value);

    public static implicit operator EndDate(BillingCycleRelativeDate value) =>
        new EndDateVariants::BillingCycleRelativeDateVariant(value);

    public abstract void Validate();
}
