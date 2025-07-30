using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceVariants;

[JsonConverter(typeof(VariantConverter<NewSubscriptionUnitPriceVariant, NewSubscriptionUnitPrice>))]
public sealed record class NewSubscriptionUnitPriceVariant(NewSubscriptionUnitPrice Value)
    : Price1,
        IVariant<NewSubscriptionUnitPriceVariant, NewSubscriptionUnitPrice>
{
    public static NewSubscriptionUnitPriceVariant From(NewSubscriptionUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewSubscriptionPackagePriceVariant, NewSubscriptionPackagePrice>)
)]
public sealed record class NewSubscriptionPackagePriceVariant(NewSubscriptionPackagePrice Value)
    : Price1,
        IVariant<NewSubscriptionPackagePriceVariant, NewSubscriptionPackagePrice>
{
    public static NewSubscriptionPackagePriceVariant From(NewSubscriptionPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewSubscriptionMatrixPriceVariant, NewSubscriptionMatrixPrice>)
)]
public sealed record class NewSubscriptionMatrixPriceVariant(NewSubscriptionMatrixPrice Value)
    : Price1,
        IVariant<NewSubscriptionMatrixPriceVariant, NewSubscriptionMatrixPrice>
{
    public static NewSubscriptionMatrixPriceVariant From(NewSubscriptionMatrixPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewSubscriptionTieredPriceVariant, NewSubscriptionTieredPrice>)
)]
public sealed record class NewSubscriptionTieredPriceVariant(NewSubscriptionTieredPrice Value)
    : Price1,
        IVariant<NewSubscriptionTieredPriceVariant, NewSubscriptionTieredPrice>
{
    public static NewSubscriptionTieredPriceVariant From(NewSubscriptionTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewSubscriptionTieredBPSPriceVariant, NewSubscriptionTieredBPSPrice>)
)]
public sealed record class NewSubscriptionTieredBPSPriceVariant(NewSubscriptionTieredBPSPrice Value)
    : Price1,
        IVariant<NewSubscriptionTieredBPSPriceVariant, NewSubscriptionTieredBPSPrice>
{
    public static NewSubscriptionTieredBPSPriceVariant From(NewSubscriptionTieredBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewSubscriptionBPSPriceVariant, NewSubscriptionBPSPrice>))]
public sealed record class NewSubscriptionBPSPriceVariant(NewSubscriptionBPSPrice Value)
    : Price1,
        IVariant<NewSubscriptionBPSPriceVariant, NewSubscriptionBPSPrice>
{
    public static NewSubscriptionBPSPriceVariant From(NewSubscriptionBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewSubscriptionBulkBPSPriceVariant, NewSubscriptionBulkBPSPrice>)
)]
public sealed record class NewSubscriptionBulkBPSPriceVariant(NewSubscriptionBulkBPSPrice Value)
    : Price1,
        IVariant<NewSubscriptionBulkBPSPriceVariant, NewSubscriptionBulkBPSPrice>
{
    public static NewSubscriptionBulkBPSPriceVariant From(NewSubscriptionBulkBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewSubscriptionBulkPriceVariant, NewSubscriptionBulkPrice>))]
public sealed record class NewSubscriptionBulkPriceVariant(NewSubscriptionBulkPrice Value)
    : Price1,
        IVariant<NewSubscriptionBulkPriceVariant, NewSubscriptionBulkPrice>
{
    public static NewSubscriptionBulkPriceVariant From(NewSubscriptionBulkPrice value)
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
        NewSubscriptionThresholdTotalAmountPriceVariant,
        NewSubscriptionThresholdTotalAmountPrice
    >)
)]
public sealed record class NewSubscriptionThresholdTotalAmountPriceVariant(
    NewSubscriptionThresholdTotalAmountPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionThresholdTotalAmountPriceVariant,
            NewSubscriptionThresholdTotalAmountPrice
        >
{
    public static NewSubscriptionThresholdTotalAmountPriceVariant From(
        NewSubscriptionThresholdTotalAmountPrice value
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
        NewSubscriptionTieredPackagePriceVariant,
        NewSubscriptionTieredPackagePrice
    >)
)]
public sealed record class NewSubscriptionTieredPackagePriceVariant(
    NewSubscriptionTieredPackagePrice Value
) : Price1, IVariant<NewSubscriptionTieredPackagePriceVariant, NewSubscriptionTieredPackagePrice>
{
    public static NewSubscriptionTieredPackagePriceVariant From(
        NewSubscriptionTieredPackagePrice value
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
        NewSubscriptionTieredWithMinimumPriceVariant,
        NewSubscriptionTieredWithMinimumPrice
    >)
)]
public sealed record class NewSubscriptionTieredWithMinimumPriceVariant(
    NewSubscriptionTieredWithMinimumPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionTieredWithMinimumPriceVariant,
            NewSubscriptionTieredWithMinimumPrice
        >
{
    public static NewSubscriptionTieredWithMinimumPriceVariant From(
        NewSubscriptionTieredWithMinimumPrice value
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
        NewSubscriptionUnitWithPercentPriceVariant,
        NewSubscriptionUnitWithPercentPrice
    >)
)]
public sealed record class NewSubscriptionUnitWithPercentPriceVariant(
    NewSubscriptionUnitWithPercentPrice Value
)
    : Price1,
        IVariant<NewSubscriptionUnitWithPercentPriceVariant, NewSubscriptionUnitWithPercentPrice>
{
    public static NewSubscriptionUnitWithPercentPriceVariant From(
        NewSubscriptionUnitWithPercentPrice value
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
        NewSubscriptionPackageWithAllocationPriceVariant,
        NewSubscriptionPackageWithAllocationPrice
    >)
)]
public sealed record class NewSubscriptionPackageWithAllocationPriceVariant(
    NewSubscriptionPackageWithAllocationPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionPackageWithAllocationPriceVariant,
            NewSubscriptionPackageWithAllocationPrice
        >
{
    public static NewSubscriptionPackageWithAllocationPriceVariant From(
        NewSubscriptionPackageWithAllocationPrice value
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
        NewSubscriptionTierWithProrationPriceVariant,
        NewSubscriptionTierWithProrationPrice
    >)
)]
public sealed record class NewSubscriptionTierWithProrationPriceVariant(
    NewSubscriptionTierWithProrationPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionTierWithProrationPriceVariant,
            NewSubscriptionTierWithProrationPrice
        >
{
    public static NewSubscriptionTierWithProrationPriceVariant From(
        NewSubscriptionTierWithProrationPrice value
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
        NewSubscriptionUnitWithProrationPriceVariant,
        NewSubscriptionUnitWithProrationPrice
    >)
)]
public sealed record class NewSubscriptionUnitWithProrationPriceVariant(
    NewSubscriptionUnitWithProrationPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionUnitWithProrationPriceVariant,
            NewSubscriptionUnitWithProrationPrice
        >
{
    public static NewSubscriptionUnitWithProrationPriceVariant From(
        NewSubscriptionUnitWithProrationPrice value
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
        NewSubscriptionGroupedAllocationPriceVariant,
        NewSubscriptionGroupedAllocationPrice
    >)
)]
public sealed record class NewSubscriptionGroupedAllocationPriceVariant(
    NewSubscriptionGroupedAllocationPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionGroupedAllocationPriceVariant,
            NewSubscriptionGroupedAllocationPrice
        >
{
    public static NewSubscriptionGroupedAllocationPriceVariant From(
        NewSubscriptionGroupedAllocationPrice value
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
        NewSubscriptionGroupedWithProratedMinimumPriceVariant,
        NewSubscriptionGroupedWithProratedMinimumPrice
    >)
)]
public sealed record class NewSubscriptionGroupedWithProratedMinimumPriceVariant(
    NewSubscriptionGroupedWithProratedMinimumPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionGroupedWithProratedMinimumPriceVariant,
            NewSubscriptionGroupedWithProratedMinimumPrice
        >
{
    public static NewSubscriptionGroupedWithProratedMinimumPriceVariant From(
        NewSubscriptionGroupedWithProratedMinimumPrice value
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
        NewSubscriptionBulkWithProrationPriceVariant,
        NewSubscriptionBulkWithProrationPrice
    >)
)]
public sealed record class NewSubscriptionBulkWithProrationPriceVariant(
    NewSubscriptionBulkWithProrationPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionBulkWithProrationPriceVariant,
            NewSubscriptionBulkWithProrationPrice
        >
{
    public static NewSubscriptionBulkWithProrationPriceVariant From(
        NewSubscriptionBulkWithProrationPrice value
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
        NewSubscriptionScalableMatrixWithUnitPricingPriceVariant,
        NewSubscriptionScalableMatrixWithUnitPricingPrice
    >)
)]
public sealed record class NewSubscriptionScalableMatrixWithUnitPricingPriceVariant(
    NewSubscriptionScalableMatrixWithUnitPricingPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionScalableMatrixWithUnitPricingPriceVariant,
            NewSubscriptionScalableMatrixWithUnitPricingPrice
        >
{
    public static NewSubscriptionScalableMatrixWithUnitPricingPriceVariant From(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
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
        NewSubscriptionScalableMatrixWithTieredPricingPriceVariant,
        NewSubscriptionScalableMatrixWithTieredPricingPrice
    >)
)]
public sealed record class NewSubscriptionScalableMatrixWithTieredPricingPriceVariant(
    NewSubscriptionScalableMatrixWithTieredPricingPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionScalableMatrixWithTieredPricingPriceVariant,
            NewSubscriptionScalableMatrixWithTieredPricingPrice
        >
{
    public static NewSubscriptionScalableMatrixWithTieredPricingPriceVariant From(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
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
        NewSubscriptionCumulativeGroupedBulkPriceVariant,
        NewSubscriptionCumulativeGroupedBulkPrice
    >)
)]
public sealed record class NewSubscriptionCumulativeGroupedBulkPriceVariant(
    NewSubscriptionCumulativeGroupedBulkPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionCumulativeGroupedBulkPriceVariant,
            NewSubscriptionCumulativeGroupedBulkPrice
        >
{
    public static NewSubscriptionCumulativeGroupedBulkPriceVariant From(
        NewSubscriptionCumulativeGroupedBulkPrice value
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
        NewSubscriptionMaxGroupTieredPackagePriceVariant,
        NewSubscriptionMaxGroupTieredPackagePrice
    >)
)]
public sealed record class NewSubscriptionMaxGroupTieredPackagePriceVariant(
    NewSubscriptionMaxGroupTieredPackagePrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionMaxGroupTieredPackagePriceVariant,
            NewSubscriptionMaxGroupTieredPackagePrice
        >
{
    public static NewSubscriptionMaxGroupTieredPackagePriceVariant From(
        NewSubscriptionMaxGroupTieredPackagePrice value
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
        NewSubscriptionGroupedWithMeteredMinimumPriceVariant,
        NewSubscriptionGroupedWithMeteredMinimumPrice
    >)
)]
public sealed record class NewSubscriptionGroupedWithMeteredMinimumPriceVariant(
    NewSubscriptionGroupedWithMeteredMinimumPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionGroupedWithMeteredMinimumPriceVariant,
            NewSubscriptionGroupedWithMeteredMinimumPrice
        >
{
    public static NewSubscriptionGroupedWithMeteredMinimumPriceVariant From(
        NewSubscriptionGroupedWithMeteredMinimumPrice value
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
        NewSubscriptionMatrixWithDisplayNamePriceVariant,
        NewSubscriptionMatrixWithDisplayNamePrice
    >)
)]
public sealed record class NewSubscriptionMatrixWithDisplayNamePriceVariant(
    NewSubscriptionMatrixWithDisplayNamePrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionMatrixWithDisplayNamePriceVariant,
            NewSubscriptionMatrixWithDisplayNamePrice
        >
{
    public static NewSubscriptionMatrixWithDisplayNamePriceVariant From(
        NewSubscriptionMatrixWithDisplayNamePrice value
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
        NewSubscriptionGroupedTieredPackagePriceVariant,
        NewSubscriptionGroupedTieredPackagePrice
    >)
)]
public sealed record class NewSubscriptionGroupedTieredPackagePriceVariant(
    NewSubscriptionGroupedTieredPackagePrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionGroupedTieredPackagePriceVariant,
            NewSubscriptionGroupedTieredPackagePrice
        >
{
    public static NewSubscriptionGroupedTieredPackagePriceVariant From(
        NewSubscriptionGroupedTieredPackagePrice value
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
        NewSubscriptionMatrixWithAllocationPriceVariant,
        NewSubscriptionMatrixWithAllocationPrice
    >)
)]
public sealed record class NewSubscriptionMatrixWithAllocationPriceVariant(
    NewSubscriptionMatrixWithAllocationPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionMatrixWithAllocationPriceVariant,
            NewSubscriptionMatrixWithAllocationPrice
        >
{
    public static NewSubscriptionMatrixWithAllocationPriceVariant From(
        NewSubscriptionMatrixWithAllocationPrice value
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
        NewSubscriptionTieredPackageWithMinimumPriceVariant,
        NewSubscriptionTieredPackageWithMinimumPrice
    >)
)]
public sealed record class NewSubscriptionTieredPackageWithMinimumPriceVariant(
    NewSubscriptionTieredPackageWithMinimumPrice Value
)
    : Price1,
        IVariant<
            NewSubscriptionTieredPackageWithMinimumPriceVariant,
            NewSubscriptionTieredPackageWithMinimumPrice
        >
{
    public static NewSubscriptionTieredPackageWithMinimumPriceVariant From(
        NewSubscriptionTieredPackageWithMinimumPrice value
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
        NewSubscriptionGroupedTieredPriceVariant,
        NewSubscriptionGroupedTieredPrice
    >)
)]
public sealed record class NewSubscriptionGroupedTieredPriceVariant(
    NewSubscriptionGroupedTieredPrice Value
) : Price1, IVariant<NewSubscriptionGroupedTieredPriceVariant, NewSubscriptionGroupedTieredPrice>
{
    public static NewSubscriptionGroupedTieredPriceVariant From(
        NewSubscriptionGroupedTieredPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
