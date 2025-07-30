using System.Text.Json.Serialization;

namespace Orb.Models.Prices.PriceCreateParamsProperties.BodyVariants;

[JsonConverter(typeof(VariantConverter<NewFloatingUnitPriceVariant, NewFloatingUnitPrice>))]
public sealed record class NewFloatingUnitPriceVariant(NewFloatingUnitPrice Value)
    : Body,
        IVariant<NewFloatingUnitPriceVariant, NewFloatingUnitPrice>
{
    public static NewFloatingUnitPriceVariant From(NewFloatingUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewFloatingPackagePriceVariant, NewFloatingPackagePrice>))]
public sealed record class NewFloatingPackagePriceVariant(NewFloatingPackagePrice Value)
    : Body,
        IVariant<NewFloatingPackagePriceVariant, NewFloatingPackagePrice>
{
    public static NewFloatingPackagePriceVariant From(NewFloatingPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewFloatingMatrixPriceVariant, NewFloatingMatrixPrice>))]
public sealed record class NewFloatingMatrixPriceVariant(NewFloatingMatrixPrice Value)
    : Body,
        IVariant<NewFloatingMatrixPriceVariant, NewFloatingMatrixPrice>
{
    public static NewFloatingMatrixPriceVariant From(NewFloatingMatrixPrice value)
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
        NewFloatingMatrixWithAllocationPriceVariant,
        NewFloatingMatrixWithAllocationPrice
    >)
)]
public sealed record class NewFloatingMatrixWithAllocationPriceVariant(
    NewFloatingMatrixWithAllocationPrice Value
)
    : Body,
        IVariant<NewFloatingMatrixWithAllocationPriceVariant, NewFloatingMatrixWithAllocationPrice>
{
    public static NewFloatingMatrixWithAllocationPriceVariant From(
        NewFloatingMatrixWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewFloatingTieredPriceVariant, NewFloatingTieredPrice>))]
public sealed record class NewFloatingTieredPriceVariant(NewFloatingTieredPrice Value)
    : Body,
        IVariant<NewFloatingTieredPriceVariant, NewFloatingTieredPrice>
{
    public static NewFloatingTieredPriceVariant From(NewFloatingTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewFloatingTieredBPSPriceVariant, NewFloatingTieredBPSPrice>)
)]
public sealed record class NewFloatingTieredBPSPriceVariant(NewFloatingTieredBPSPrice Value)
    : Body,
        IVariant<NewFloatingTieredBPSPriceVariant, NewFloatingTieredBPSPrice>
{
    public static NewFloatingTieredBPSPriceVariant From(NewFloatingTieredBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewFloatingBPSPriceVariant, NewFloatingBPSPrice>))]
public sealed record class NewFloatingBPSPriceVariant(NewFloatingBPSPrice Value)
    : Body,
        IVariant<NewFloatingBPSPriceVariant, NewFloatingBPSPrice>
{
    public static NewFloatingBPSPriceVariant From(NewFloatingBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewFloatingBulkBPSPriceVariant, NewFloatingBulkBPSPrice>))]
public sealed record class NewFloatingBulkBPSPriceVariant(NewFloatingBulkBPSPrice Value)
    : Body,
        IVariant<NewFloatingBulkBPSPriceVariant, NewFloatingBulkBPSPrice>
{
    public static NewFloatingBulkBPSPriceVariant From(NewFloatingBulkBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewFloatingBulkPriceVariant, NewFloatingBulkPrice>))]
public sealed record class NewFloatingBulkPriceVariant(NewFloatingBulkPrice Value)
    : Body,
        IVariant<NewFloatingBulkPriceVariant, NewFloatingBulkPrice>
{
    public static NewFloatingBulkPriceVariant From(NewFloatingBulkPrice value)
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
        NewFloatingThresholdTotalAmountPriceVariant,
        NewFloatingThresholdTotalAmountPrice
    >)
)]
public sealed record class NewFloatingThresholdTotalAmountPriceVariant(
    NewFloatingThresholdTotalAmountPrice Value
)
    : Body,
        IVariant<NewFloatingThresholdTotalAmountPriceVariant, NewFloatingThresholdTotalAmountPrice>
{
    public static NewFloatingThresholdTotalAmountPriceVariant From(
        NewFloatingThresholdTotalAmountPrice value
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
    typeof(VariantConverter<NewFloatingTieredPackagePriceVariant, NewFloatingTieredPackagePrice>)
)]
public sealed record class NewFloatingTieredPackagePriceVariant(NewFloatingTieredPackagePrice Value)
    : Body,
        IVariant<NewFloatingTieredPackagePriceVariant, NewFloatingTieredPackagePrice>
{
    public static NewFloatingTieredPackagePriceVariant From(NewFloatingTieredPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewFloatingGroupedTieredPriceVariant, NewFloatingGroupedTieredPrice>)
)]
public sealed record class NewFloatingGroupedTieredPriceVariant(NewFloatingGroupedTieredPrice Value)
    : Body,
        IVariant<NewFloatingGroupedTieredPriceVariant, NewFloatingGroupedTieredPrice>
{
    public static NewFloatingGroupedTieredPriceVariant From(NewFloatingGroupedTieredPrice value)
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
        NewFloatingMaxGroupTieredPackagePriceVariant,
        NewFloatingMaxGroupTieredPackagePrice
    >)
)]
public sealed record class NewFloatingMaxGroupTieredPackagePriceVariant(
    NewFloatingMaxGroupTieredPackagePrice Value
)
    : Body,
        IVariant<
            NewFloatingMaxGroupTieredPackagePriceVariant,
            NewFloatingMaxGroupTieredPackagePrice
        >
{
    public static NewFloatingMaxGroupTieredPackagePriceVariant From(
        NewFloatingMaxGroupTieredPackagePrice value
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
        NewFloatingTieredWithMinimumPriceVariant,
        NewFloatingTieredWithMinimumPrice
    >)
)]
public sealed record class NewFloatingTieredWithMinimumPriceVariant(
    NewFloatingTieredWithMinimumPrice Value
) : Body, IVariant<NewFloatingTieredWithMinimumPriceVariant, NewFloatingTieredWithMinimumPrice>
{
    public static NewFloatingTieredWithMinimumPriceVariant From(
        NewFloatingTieredWithMinimumPrice value
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
        NewFloatingPackageWithAllocationPriceVariant,
        NewFloatingPackageWithAllocationPrice
    >)
)]
public sealed record class NewFloatingPackageWithAllocationPriceVariant(
    NewFloatingPackageWithAllocationPrice Value
)
    : Body,
        IVariant<
            NewFloatingPackageWithAllocationPriceVariant,
            NewFloatingPackageWithAllocationPrice
        >
{
    public static NewFloatingPackageWithAllocationPriceVariant From(
        NewFloatingPackageWithAllocationPrice value
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
        NewFloatingTieredPackageWithMinimumPriceVariant,
        NewFloatingTieredPackageWithMinimumPrice
    >)
)]
public sealed record class NewFloatingTieredPackageWithMinimumPriceVariant(
    NewFloatingTieredPackageWithMinimumPrice Value
)
    : Body,
        IVariant<
            NewFloatingTieredPackageWithMinimumPriceVariant,
            NewFloatingTieredPackageWithMinimumPrice
        >
{
    public static NewFloatingTieredPackageWithMinimumPriceVariant From(
        NewFloatingTieredPackageWithMinimumPrice value
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
        NewFloatingUnitWithPercentPriceVariant,
        NewFloatingUnitWithPercentPrice
    >)
)]
public sealed record class NewFloatingUnitWithPercentPriceVariant(
    NewFloatingUnitWithPercentPrice Value
) : Body, IVariant<NewFloatingUnitWithPercentPriceVariant, NewFloatingUnitWithPercentPrice>
{
    public static NewFloatingUnitWithPercentPriceVariant From(NewFloatingUnitWithPercentPrice value)
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
        NewFloatingTieredWithProrationPriceVariant,
        NewFloatingTieredWithProrationPrice
    >)
)]
public sealed record class NewFloatingTieredWithProrationPriceVariant(
    NewFloatingTieredWithProrationPrice Value
) : Body, IVariant<NewFloatingTieredWithProrationPriceVariant, NewFloatingTieredWithProrationPrice>
{
    public static NewFloatingTieredWithProrationPriceVariant From(
        NewFloatingTieredWithProrationPrice value
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
        NewFloatingUnitWithProrationPriceVariant,
        NewFloatingUnitWithProrationPrice
    >)
)]
public sealed record class NewFloatingUnitWithProrationPriceVariant(
    NewFloatingUnitWithProrationPrice Value
) : Body, IVariant<NewFloatingUnitWithProrationPriceVariant, NewFloatingUnitWithProrationPrice>
{
    public static NewFloatingUnitWithProrationPriceVariant From(
        NewFloatingUnitWithProrationPrice value
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
        NewFloatingGroupedAllocationPriceVariant,
        NewFloatingGroupedAllocationPrice
    >)
)]
public sealed record class NewFloatingGroupedAllocationPriceVariant(
    NewFloatingGroupedAllocationPrice Value
) : Body, IVariant<NewFloatingGroupedAllocationPriceVariant, NewFloatingGroupedAllocationPrice>
{
    public static NewFloatingGroupedAllocationPriceVariant From(
        NewFloatingGroupedAllocationPrice value
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
        NewFloatingGroupedWithProratedMinimumPriceVariant,
        NewFloatingGroupedWithProratedMinimumPrice
    >)
)]
public sealed record class NewFloatingGroupedWithProratedMinimumPriceVariant(
    NewFloatingGroupedWithProratedMinimumPrice Value
)
    : Body,
        IVariant<
            NewFloatingGroupedWithProratedMinimumPriceVariant,
            NewFloatingGroupedWithProratedMinimumPrice
        >
{
    public static NewFloatingGroupedWithProratedMinimumPriceVariant From(
        NewFloatingGroupedWithProratedMinimumPrice value
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
        NewFloatingGroupedWithMeteredMinimumPriceVariant,
        NewFloatingGroupedWithMeteredMinimumPrice
    >)
)]
public sealed record class NewFloatingGroupedWithMeteredMinimumPriceVariant(
    NewFloatingGroupedWithMeteredMinimumPrice Value
)
    : Body,
        IVariant<
            NewFloatingGroupedWithMeteredMinimumPriceVariant,
            NewFloatingGroupedWithMeteredMinimumPrice
        >
{
    public static NewFloatingGroupedWithMeteredMinimumPriceVariant From(
        NewFloatingGroupedWithMeteredMinimumPrice value
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
        NewFloatingMatrixWithDisplayNamePriceVariant,
        NewFloatingMatrixWithDisplayNamePrice
    >)
)]
public sealed record class NewFloatingMatrixWithDisplayNamePriceVariant(
    NewFloatingMatrixWithDisplayNamePrice Value
)
    : Body,
        IVariant<
            NewFloatingMatrixWithDisplayNamePriceVariant,
            NewFloatingMatrixWithDisplayNamePrice
        >
{
    public static NewFloatingMatrixWithDisplayNamePriceVariant From(
        NewFloatingMatrixWithDisplayNamePrice value
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
        NewFloatingBulkWithProrationPriceVariant,
        NewFloatingBulkWithProrationPrice
    >)
)]
public sealed record class NewFloatingBulkWithProrationPriceVariant(
    NewFloatingBulkWithProrationPrice Value
) : Body, IVariant<NewFloatingBulkWithProrationPriceVariant, NewFloatingBulkWithProrationPrice>
{
    public static NewFloatingBulkWithProrationPriceVariant From(
        NewFloatingBulkWithProrationPrice value
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
        NewFloatingGroupedTieredPackagePriceVariant,
        NewFloatingGroupedTieredPackagePrice
    >)
)]
public sealed record class NewFloatingGroupedTieredPackagePriceVariant(
    NewFloatingGroupedTieredPackagePrice Value
)
    : Body,
        IVariant<NewFloatingGroupedTieredPackagePriceVariant, NewFloatingGroupedTieredPackagePrice>
{
    public static NewFloatingGroupedTieredPackagePriceVariant From(
        NewFloatingGroupedTieredPackagePrice value
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
        NewFloatingScalableMatrixWithUnitPricingPriceVariant,
        NewFloatingScalableMatrixWithUnitPricingPrice
    >)
)]
public sealed record class NewFloatingScalableMatrixWithUnitPricingPriceVariant(
    NewFloatingScalableMatrixWithUnitPricingPrice Value
)
    : Body,
        IVariant<
            NewFloatingScalableMatrixWithUnitPricingPriceVariant,
            NewFloatingScalableMatrixWithUnitPricingPrice
        >
{
    public static NewFloatingScalableMatrixWithUnitPricingPriceVariant From(
        NewFloatingScalableMatrixWithUnitPricingPrice value
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
        NewFloatingScalableMatrixWithTieredPricingPriceVariant,
        NewFloatingScalableMatrixWithTieredPricingPrice
    >)
)]
public sealed record class NewFloatingScalableMatrixWithTieredPricingPriceVariant(
    NewFloatingScalableMatrixWithTieredPricingPrice Value
)
    : Body,
        IVariant<
            NewFloatingScalableMatrixWithTieredPricingPriceVariant,
            NewFloatingScalableMatrixWithTieredPricingPrice
        >
{
    public static NewFloatingScalableMatrixWithTieredPricingPriceVariant From(
        NewFloatingScalableMatrixWithTieredPricingPrice value
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
        NewFloatingCumulativeGroupedBulkPriceVariant,
        NewFloatingCumulativeGroupedBulkPrice
    >)
)]
public sealed record class NewFloatingCumulativeGroupedBulkPriceVariant(
    NewFloatingCumulativeGroupedBulkPrice Value
)
    : Body,
        IVariant<
            NewFloatingCumulativeGroupedBulkPriceVariant,
            NewFloatingCumulativeGroupedBulkPrice
        >
{
    public static NewFloatingCumulativeGroupedBulkPriceVariant From(
        NewFloatingCumulativeGroupedBulkPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
