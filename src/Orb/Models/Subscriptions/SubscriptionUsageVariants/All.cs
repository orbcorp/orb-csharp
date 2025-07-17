using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using Subscriptions = Orb.Models.Subscriptions;
using SubscriptionUsageProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties;

namespace Orb.Models.Subscriptions.SubscriptionUsageVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        UngroupedSubscriptionUsage,
        SubscriptionUsageProperties::UngroupedSubscriptionUsage
    >)
)]
public sealed record class UngroupedSubscriptionUsage(
    SubscriptionUsageProperties::UngroupedSubscriptionUsage Value
)
    : Subscriptions::SubscriptionUsage,
        Orb::IVariant<
            UngroupedSubscriptionUsage,
            SubscriptionUsageProperties::UngroupedSubscriptionUsage
        >
{
    public static UngroupedSubscriptionUsage From(
        SubscriptionUsageProperties::UngroupedSubscriptionUsage value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        GroupedSubscriptionUsage,
        SubscriptionUsageProperties::GroupedSubscriptionUsage
    >)
)]
public sealed record class GroupedSubscriptionUsage(
    SubscriptionUsageProperties::GroupedSubscriptionUsage Value
)
    : Subscriptions::SubscriptionUsage,
        Orb::IVariant<
            GroupedSubscriptionUsage,
            SubscriptionUsageProperties::GroupedSubscriptionUsage
        >
{
    public static GroupedSubscriptionUsage From(
        SubscriptionUsageProperties::GroupedSubscriptionUsage value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
