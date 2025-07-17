using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubscriptionUsageProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties;
using SubscriptionUsageVariants = Orb.Models.Subscriptions.SubscriptionUsageVariants;

namespace Orb.Models.Subscriptions;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<SubscriptionUsage>))]
public abstract record class SubscriptionUsage
{
    internal SubscriptionUsage() { }

    public static SubscriptionUsageVariants::UngroupedSubscriptionUsage Create(
        SubscriptionUsageProperties::UngroupedSubscriptionUsage value
    ) => new(value);

    public static SubscriptionUsageVariants::GroupedSubscriptionUsage Create(
        SubscriptionUsageProperties::GroupedSubscriptionUsage value
    ) => new(value);

    public abstract void Validate();
}
