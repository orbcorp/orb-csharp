using System.Text.Json.Serialization;

namespace Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceVariants;

[JsonConverter(typeof(VariantConverter<NewFloatingUnitPriceVariant, NewFloatingUnitPrice>))]
public sealed record class NewFloatingUnitPriceVariant(NewFloatingUnitPrice Value)
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
) : Price1, IVariant<NewFloatingTieredWithMinimumPriceVariant, NewFloatingTieredWithMinimumPrice>
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
    : Price1,
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
    : Price1,
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
) : Price1, IVariant<NewFloatingUnitWithPercentPriceVariant, NewFloatingUnitWithPercentPrice>
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
)
    : Price1,
        IVariant<NewFloatingTieredWithProrationPriceVariant, NewFloatingTieredWithProrationPrice>
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
) : Price1, IVariant<NewFloatingUnitWithProrationPriceVariant, NewFloatingUnitWithProrationPrice>
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
) : Price1, IVariant<NewFloatingGroupedAllocationPriceVariant, NewFloatingGroupedAllocationPrice>
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
) : Price1, IVariant<NewFloatingBulkWithProrationPriceVariant, NewFloatingBulkWithProrationPrice>
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
