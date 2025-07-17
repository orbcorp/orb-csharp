using Orb = Orb;
using ReplacePriceProperties = Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties;
using Serialization = System.Text.Json.Serialization;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewSubscriptionUnitPrice, Subscriptions::NewSubscriptionUnitPrice>)
)]
public sealed record class NewSubscriptionUnitPrice(Subscriptions::NewSubscriptionUnitPrice Value)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionUnitPrice, Subscriptions::NewSubscriptionUnitPrice>
{
    public static NewSubscriptionUnitPrice From(Subscriptions::NewSubscriptionUnitPrice value)
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
        NewSubscriptionPackagePrice,
        Subscriptions::NewSubscriptionPackagePrice
    >)
)]
public sealed record class NewSubscriptionPackagePrice(
    Subscriptions::NewSubscriptionPackagePrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionPackagePrice, Subscriptions::NewSubscriptionPackagePrice>
{
    public static NewSubscriptionPackagePrice From(Subscriptions::NewSubscriptionPackagePrice value)
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
        NewSubscriptionMatrixPrice,
        Subscriptions::NewSubscriptionMatrixPrice
    >)
)]
public sealed record class NewSubscriptionMatrixPrice(
    Subscriptions::NewSubscriptionMatrixPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionMatrixPrice, Subscriptions::NewSubscriptionMatrixPrice>
{
    public static NewSubscriptionMatrixPrice From(Subscriptions::NewSubscriptionMatrixPrice value)
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
        NewSubscriptionTieredPrice,
        Subscriptions::NewSubscriptionTieredPrice
    >)
)]
public sealed record class NewSubscriptionTieredPrice(
    Subscriptions::NewSubscriptionTieredPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionTieredPrice, Subscriptions::NewSubscriptionTieredPrice>
{
    public static NewSubscriptionTieredPrice From(Subscriptions::NewSubscriptionTieredPrice value)
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
        NewSubscriptionTieredBPSPrice,
        Subscriptions::NewSubscriptionTieredBPSPrice
    >)
)]
public sealed record class NewSubscriptionTieredBPSPrice(
    Subscriptions::NewSubscriptionTieredBPSPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionTieredBPSPrice, Subscriptions::NewSubscriptionTieredBPSPrice>
{
    public static NewSubscriptionTieredBPSPrice From(
        Subscriptions::NewSubscriptionTieredBPSPrice value
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
    typeof(Orb::VariantConverter<NewSubscriptionBPSPrice, Subscriptions::NewSubscriptionBPSPrice>)
)]
public sealed record class NewSubscriptionBPSPrice(Subscriptions::NewSubscriptionBPSPrice Value)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionBPSPrice, Subscriptions::NewSubscriptionBPSPrice>
{
    public static NewSubscriptionBPSPrice From(Subscriptions::NewSubscriptionBPSPrice value)
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
        NewSubscriptionBulkBPSPrice,
        Subscriptions::NewSubscriptionBulkBPSPrice
    >)
)]
public sealed record class NewSubscriptionBulkBPSPrice(
    Subscriptions::NewSubscriptionBulkBPSPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionBulkBPSPrice, Subscriptions::NewSubscriptionBulkBPSPrice>
{
    public static NewSubscriptionBulkBPSPrice From(Subscriptions::NewSubscriptionBulkBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewSubscriptionBulkPrice, Subscriptions::NewSubscriptionBulkPrice>)
)]
public sealed record class NewSubscriptionBulkPrice(Subscriptions::NewSubscriptionBulkPrice Value)
    : ReplacePriceProperties::Price,
        Orb::IVariant<NewSubscriptionBulkPrice, Subscriptions::NewSubscriptionBulkPrice>
{
    public static NewSubscriptionBulkPrice From(Subscriptions::NewSubscriptionBulkPrice value)
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
        NewSubscriptionThresholdTotalAmountPrice,
        Subscriptions::NewSubscriptionThresholdTotalAmountPrice
    >)
)]
public sealed record class NewSubscriptionThresholdTotalAmountPrice(
    Subscriptions::NewSubscriptionThresholdTotalAmountPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionThresholdTotalAmountPrice,
            Subscriptions::NewSubscriptionThresholdTotalAmountPrice
        >
{
    public static NewSubscriptionThresholdTotalAmountPrice From(
        Subscriptions::NewSubscriptionThresholdTotalAmountPrice value
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
        NewSubscriptionTieredPackagePrice,
        Subscriptions::NewSubscriptionTieredPackagePrice
    >)
)]
public sealed record class NewSubscriptionTieredPackagePrice(
    Subscriptions::NewSubscriptionTieredPackagePrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionTieredPackagePrice,
            Subscriptions::NewSubscriptionTieredPackagePrice
        >
{
    public static NewSubscriptionTieredPackagePrice From(
        Subscriptions::NewSubscriptionTieredPackagePrice value
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
        NewSubscriptionTieredWithMinimumPrice,
        Subscriptions::NewSubscriptionTieredWithMinimumPrice
    >)
)]
public sealed record class NewSubscriptionTieredWithMinimumPrice(
    Subscriptions::NewSubscriptionTieredWithMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionTieredWithMinimumPrice,
            Subscriptions::NewSubscriptionTieredWithMinimumPrice
        >
{
    public static NewSubscriptionTieredWithMinimumPrice From(
        Subscriptions::NewSubscriptionTieredWithMinimumPrice value
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
        NewSubscriptionUnitWithPercentPrice,
        Subscriptions::NewSubscriptionUnitWithPercentPrice
    >)
)]
public sealed record class NewSubscriptionUnitWithPercentPrice(
    Subscriptions::NewSubscriptionUnitWithPercentPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionUnitWithPercentPrice,
            Subscriptions::NewSubscriptionUnitWithPercentPrice
        >
{
    public static NewSubscriptionUnitWithPercentPrice From(
        Subscriptions::NewSubscriptionUnitWithPercentPrice value
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
        NewSubscriptionPackageWithAllocationPrice,
        Subscriptions::NewSubscriptionPackageWithAllocationPrice
    >)
)]
public sealed record class NewSubscriptionPackageWithAllocationPrice(
    Subscriptions::NewSubscriptionPackageWithAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionPackageWithAllocationPrice,
            Subscriptions::NewSubscriptionPackageWithAllocationPrice
        >
{
    public static NewSubscriptionPackageWithAllocationPrice From(
        Subscriptions::NewSubscriptionPackageWithAllocationPrice value
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
        NewSubscriptionTierWithProrationPrice,
        Subscriptions::NewSubscriptionTierWithProrationPrice
    >)
)]
public sealed record class NewSubscriptionTierWithProrationPrice(
    Subscriptions::NewSubscriptionTierWithProrationPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionTierWithProrationPrice,
            Subscriptions::NewSubscriptionTierWithProrationPrice
        >
{
    public static NewSubscriptionTierWithProrationPrice From(
        Subscriptions::NewSubscriptionTierWithProrationPrice value
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
        NewSubscriptionUnitWithProrationPrice,
        Subscriptions::NewSubscriptionUnitWithProrationPrice
    >)
)]
public sealed record class NewSubscriptionUnitWithProrationPrice(
    Subscriptions::NewSubscriptionUnitWithProrationPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionUnitWithProrationPrice,
            Subscriptions::NewSubscriptionUnitWithProrationPrice
        >
{
    public static NewSubscriptionUnitWithProrationPrice From(
        Subscriptions::NewSubscriptionUnitWithProrationPrice value
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
        NewSubscriptionGroupedAllocationPrice,
        Subscriptions::NewSubscriptionGroupedAllocationPrice
    >)
)]
public sealed record class NewSubscriptionGroupedAllocationPrice(
    Subscriptions::NewSubscriptionGroupedAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionGroupedAllocationPrice,
            Subscriptions::NewSubscriptionGroupedAllocationPrice
        >
{
    public static NewSubscriptionGroupedAllocationPrice From(
        Subscriptions::NewSubscriptionGroupedAllocationPrice value
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
        NewSubscriptionGroupedWithProratedMinimumPrice,
        Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice
    >)
)]
public sealed record class NewSubscriptionGroupedWithProratedMinimumPrice(
    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionGroupedWithProratedMinimumPrice,
            Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice
        >
{
    public static NewSubscriptionGroupedWithProratedMinimumPrice From(
        Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice value
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
        NewSubscriptionBulkWithProrationPrice,
        Subscriptions::NewSubscriptionBulkWithProrationPrice
    >)
)]
public sealed record class NewSubscriptionBulkWithProrationPrice(
    Subscriptions::NewSubscriptionBulkWithProrationPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionBulkWithProrationPrice,
            Subscriptions::NewSubscriptionBulkWithProrationPrice
        >
{
    public static NewSubscriptionBulkWithProrationPrice From(
        Subscriptions::NewSubscriptionBulkWithProrationPrice value
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
        NewSubscriptionScalableMatrixWithUnitPricingPrice,
        Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice
    >)
)]
public sealed record class NewSubscriptionScalableMatrixWithUnitPricingPrice(
    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionScalableMatrixWithUnitPricingPrice,
            Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice
        >
{
    public static NewSubscriptionScalableMatrixWithUnitPricingPrice From(
        Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice value
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
        NewSubscriptionScalableMatrixWithTieredPricingPrice,
        Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice
    >)
)]
public sealed record class NewSubscriptionScalableMatrixWithTieredPricingPrice(
    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionScalableMatrixWithTieredPricingPrice,
            Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice
        >
{
    public static NewSubscriptionScalableMatrixWithTieredPricingPrice From(
        Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice value
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
        NewSubscriptionCumulativeGroupedBulkPrice,
        Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice
    >)
)]
public sealed record class NewSubscriptionCumulativeGroupedBulkPrice(
    Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionCumulativeGroupedBulkPrice,
            Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice
        >
{
    public static NewSubscriptionCumulativeGroupedBulkPrice From(
        Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice value
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
        NewSubscriptionMaxGroupTieredPackagePrice,
        Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice
    >)
)]
public sealed record class NewSubscriptionMaxGroupTieredPackagePrice(
    Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionMaxGroupTieredPackagePrice,
            Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice
        >
{
    public static NewSubscriptionMaxGroupTieredPackagePrice From(
        Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice value
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
        NewSubscriptionGroupedWithMeteredMinimumPrice,
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
    >)
)]
public sealed record class NewSubscriptionGroupedWithMeteredMinimumPrice(
    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionGroupedWithMeteredMinimumPrice,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        >
{
    public static NewSubscriptionGroupedWithMeteredMinimumPrice From(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice value
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
        NewSubscriptionMatrixWithDisplayNamePrice,
        Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice
    >)
)]
public sealed record class NewSubscriptionMatrixWithDisplayNamePrice(
    Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionMatrixWithDisplayNamePrice,
            Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice
        >
{
    public static NewSubscriptionMatrixWithDisplayNamePrice From(
        Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice value
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
        NewSubscriptionGroupedTieredPackagePrice,
        Subscriptions::NewSubscriptionGroupedTieredPackagePrice
    >)
)]
public sealed record class NewSubscriptionGroupedTieredPackagePrice(
    Subscriptions::NewSubscriptionGroupedTieredPackagePrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionGroupedTieredPackagePrice,
            Subscriptions::NewSubscriptionGroupedTieredPackagePrice
        >
{
    public static NewSubscriptionGroupedTieredPackagePrice From(
        Subscriptions::NewSubscriptionGroupedTieredPackagePrice value
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
        NewSubscriptionMatrixWithAllocationPrice,
        Subscriptions::NewSubscriptionMatrixWithAllocationPrice
    >)
)]
public sealed record class NewSubscriptionMatrixWithAllocationPrice(
    Subscriptions::NewSubscriptionMatrixWithAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionMatrixWithAllocationPrice,
            Subscriptions::NewSubscriptionMatrixWithAllocationPrice
        >
{
    public static NewSubscriptionMatrixWithAllocationPrice From(
        Subscriptions::NewSubscriptionMatrixWithAllocationPrice value
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
        NewSubscriptionTieredPackageWithMinimumPrice,
        Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice
    >)
)]
public sealed record class NewSubscriptionTieredPackageWithMinimumPrice(
    Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionTieredPackageWithMinimumPrice,
            Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice
        >
{
    public static NewSubscriptionTieredPackageWithMinimumPrice From(
        Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice value
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
        NewSubscriptionGroupedTieredPrice,
        Subscriptions::NewSubscriptionGroupedTieredPrice
    >)
)]
public sealed record class NewSubscriptionGroupedTieredPrice(
    Subscriptions::NewSubscriptionGroupedTieredPrice Value
)
    : ReplacePriceProperties::Price,
        Orb::IVariant<
            NewSubscriptionGroupedTieredPrice,
            Subscriptions::NewSubscriptionGroupedTieredPrice
        >
{
    public static NewSubscriptionGroupedTieredPrice From(
        Subscriptions::NewSubscriptionGroupedTieredPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
