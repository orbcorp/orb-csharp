using System.Text.Json.Serialization;
using SubscriptionUsageProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties;
using SubscriptionUsageVariants = Orb.Models.Subscriptions.SubscriptionUsageVariants;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(UnionConverter<SubscriptionUsage>))]
public abstract record class SubscriptionUsage
{
    internal SubscriptionUsage() { }

    public static implicit operator SubscriptionUsage(
        SubscriptionUsageProperties::UngroupedSubscriptionUsage value
    ) => new SubscriptionUsageVariants::UngroupedSubscriptionUsage(value);

    public static implicit operator SubscriptionUsage(
        SubscriptionUsageProperties::GroupedSubscriptionUsage value
    ) => new SubscriptionUsageVariants::GroupedSubscriptionUsage(value);

    public abstract void Validate();
}
