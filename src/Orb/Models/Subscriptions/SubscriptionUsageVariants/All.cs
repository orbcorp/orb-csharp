using System.Text.Json.Serialization;
using SubscriptionUsageProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties;

namespace Orb.Models.Subscriptions.SubscriptionUsageVariants;

[JsonConverter(
    typeof(VariantConverter<
        UngroupedSubscriptionUsage,
        SubscriptionUsageProperties::UngroupedSubscriptionUsage
    >)
)]
public sealed record class UngroupedSubscriptionUsage(
    SubscriptionUsageProperties::UngroupedSubscriptionUsage Value
)
    : SubscriptionUsage,
        IVariant<
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

[JsonConverter(
    typeof(VariantConverter<
        GroupedSubscriptionUsage,
        SubscriptionUsageProperties::GroupedSubscriptionUsage
    >)
)]
public sealed record class GroupedSubscriptionUsage(
    SubscriptionUsageProperties::GroupedSubscriptionUsage Value
)
    : SubscriptionUsage,
        IVariant<GroupedSubscriptionUsage, SubscriptionUsageProperties::GroupedSubscriptionUsage>
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
