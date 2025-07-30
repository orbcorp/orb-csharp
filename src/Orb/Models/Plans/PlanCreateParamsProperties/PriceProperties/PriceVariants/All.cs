using System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceVariants;

[JsonConverter(typeof(VariantConverter<NewPlanUnitPriceVariant, NewPlanUnitPrice>))]
public sealed record class NewPlanUnitPriceVariant(NewPlanUnitPrice Value)
    : Price2,
        IVariant<NewPlanUnitPriceVariant, NewPlanUnitPrice>
{
    public static NewPlanUnitPriceVariant From(NewPlanUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewPlanPackagePriceVariant, NewPlanPackagePrice>))]
public sealed record class NewPlanPackagePriceVariant(NewPlanPackagePrice Value)
    : Price2,
        IVariant<NewPlanPackagePriceVariant, NewPlanPackagePrice>
{
    public static NewPlanPackagePriceVariant From(NewPlanPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewPlanMatrixPriceVariant, NewPlanMatrixPrice>))]
public sealed record class NewPlanMatrixPriceVariant(NewPlanMatrixPrice Value)
    : Price2,
        IVariant<NewPlanMatrixPriceVariant, NewPlanMatrixPrice>
{
    public static NewPlanMatrixPriceVariant From(NewPlanMatrixPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewPlanTieredPriceVariant, NewPlanTieredPrice>))]
public sealed record class NewPlanTieredPriceVariant(NewPlanTieredPrice Value)
    : Price2,
        IVariant<NewPlanTieredPriceVariant, NewPlanTieredPrice>
{
    public static NewPlanTieredPriceVariant From(NewPlanTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewPlanTieredBPSPriceVariant, NewPlanTieredBPSPrice>))]
public sealed record class NewPlanTieredBPSPriceVariant(NewPlanTieredBPSPrice Value)
    : Price2,
        IVariant<NewPlanTieredBPSPriceVariant, NewPlanTieredBPSPrice>
{
    public static NewPlanTieredBPSPriceVariant From(NewPlanTieredBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewPlanBPSPriceVariant, NewPlanBPSPrice>))]
public sealed record class NewPlanBPSPriceVariant(NewPlanBPSPrice Value)
    : Price2,
        IVariant<NewPlanBPSPriceVariant, NewPlanBPSPrice>
{
    public static NewPlanBPSPriceVariant From(NewPlanBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewPlanBulkBPSPriceVariant, NewPlanBulkBPSPrice>))]
public sealed record class NewPlanBulkBPSPriceVariant(NewPlanBulkBPSPrice Value)
    : Price2,
        IVariant<NewPlanBulkBPSPriceVariant, NewPlanBulkBPSPrice>
{
    public static NewPlanBulkBPSPriceVariant From(NewPlanBulkBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewPlanBulkPriceVariant, NewPlanBulkPrice>))]
public sealed record class NewPlanBulkPriceVariant(NewPlanBulkPrice Value)
    : Price2,
        IVariant<NewPlanBulkPriceVariant, NewPlanBulkPrice>
{
    public static NewPlanBulkPriceVariant From(NewPlanBulkPrice value)
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
        NewPlanThresholdTotalAmountPriceVariant,
        NewPlanThresholdTotalAmountPrice
    >)
)]
public sealed record class NewPlanThresholdTotalAmountPriceVariant(
    NewPlanThresholdTotalAmountPrice Value
) : Price2, IVariant<NewPlanThresholdTotalAmountPriceVariant, NewPlanThresholdTotalAmountPrice>
{
    public static NewPlanThresholdTotalAmountPriceVariant From(
        NewPlanThresholdTotalAmountPrice value
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
    typeof(VariantConverter<NewPlanTieredPackagePriceVariant, NewPlanTieredPackagePrice>)
)]
public sealed record class NewPlanTieredPackagePriceVariant(NewPlanTieredPackagePrice Value)
    : Price2,
        IVariant<NewPlanTieredPackagePriceVariant, NewPlanTieredPackagePrice>
{
    public static NewPlanTieredPackagePriceVariant From(NewPlanTieredPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewPlanTieredWithMinimumPriceVariant, NewPlanTieredWithMinimumPrice>)
)]
public sealed record class NewPlanTieredWithMinimumPriceVariant(NewPlanTieredWithMinimumPrice Value)
    : Price2,
        IVariant<NewPlanTieredWithMinimumPriceVariant, NewPlanTieredWithMinimumPrice>
{
    public static NewPlanTieredWithMinimumPriceVariant From(NewPlanTieredWithMinimumPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewPlanUnitWithPercentPriceVariant, NewPlanUnitWithPercentPrice>)
)]
public sealed record class NewPlanUnitWithPercentPriceVariant(NewPlanUnitWithPercentPrice Value)
    : Price2,
        IVariant<NewPlanUnitWithPercentPriceVariant, NewPlanUnitWithPercentPrice>
{
    public static NewPlanUnitWithPercentPriceVariant From(NewPlanUnitWithPercentPrice value)
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
        NewPlanPackageWithAllocationPriceVariant,
        NewPlanPackageWithAllocationPrice
    >)
)]
public sealed record class NewPlanPackageWithAllocationPriceVariant(
    NewPlanPackageWithAllocationPrice Value
) : Price2, IVariant<NewPlanPackageWithAllocationPriceVariant, NewPlanPackageWithAllocationPrice>
{
    public static NewPlanPackageWithAllocationPriceVariant From(
        NewPlanPackageWithAllocationPrice value
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
    typeof(VariantConverter<NewPlanTierWithProrationPriceVariant, NewPlanTierWithProrationPrice>)
)]
public sealed record class NewPlanTierWithProrationPriceVariant(NewPlanTierWithProrationPrice Value)
    : Price2,
        IVariant<NewPlanTierWithProrationPriceVariant, NewPlanTierWithProrationPrice>
{
    public static NewPlanTierWithProrationPriceVariant From(NewPlanTierWithProrationPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewPlanUnitWithProrationPriceVariant, NewPlanUnitWithProrationPrice>)
)]
public sealed record class NewPlanUnitWithProrationPriceVariant(NewPlanUnitWithProrationPrice Value)
    : Price2,
        IVariant<NewPlanUnitWithProrationPriceVariant, NewPlanUnitWithProrationPrice>
{
    public static NewPlanUnitWithProrationPriceVariant From(NewPlanUnitWithProrationPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<NewPlanGroupedAllocationPriceVariant, NewPlanGroupedAllocationPrice>)
)]
public sealed record class NewPlanGroupedAllocationPriceVariant(NewPlanGroupedAllocationPrice Value)
    : Price2,
        IVariant<NewPlanGroupedAllocationPriceVariant, NewPlanGroupedAllocationPrice>
{
    public static NewPlanGroupedAllocationPriceVariant From(NewPlanGroupedAllocationPrice value)
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
        NewPlanGroupedWithProratedMinimumPriceVariant,
        NewPlanGroupedWithProratedMinimumPrice
    >)
)]
public sealed record class NewPlanGroupedWithProratedMinimumPriceVariant(
    NewPlanGroupedWithProratedMinimumPrice Value
)
    : Price2,
        IVariant<
            NewPlanGroupedWithProratedMinimumPriceVariant,
            NewPlanGroupedWithProratedMinimumPrice
        >
{
    public static NewPlanGroupedWithProratedMinimumPriceVariant From(
        NewPlanGroupedWithProratedMinimumPrice value
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
        NewPlanGroupedWithMeteredMinimumPriceVariant,
        NewPlanGroupedWithMeteredMinimumPrice
    >)
)]
public sealed record class NewPlanGroupedWithMeteredMinimumPriceVariant(
    NewPlanGroupedWithMeteredMinimumPrice Value
)
    : Price2,
        IVariant<
            NewPlanGroupedWithMeteredMinimumPriceVariant,
            NewPlanGroupedWithMeteredMinimumPrice
        >
{
    public static NewPlanGroupedWithMeteredMinimumPriceVariant From(
        NewPlanGroupedWithMeteredMinimumPrice value
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
        NewPlanMatrixWithDisplayNamePriceVariant,
        NewPlanMatrixWithDisplayNamePrice
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePriceVariant(
    NewPlanMatrixWithDisplayNamePrice Value
) : Price2, IVariant<NewPlanMatrixWithDisplayNamePriceVariant, NewPlanMatrixWithDisplayNamePrice>
{
    public static NewPlanMatrixWithDisplayNamePriceVariant From(
        NewPlanMatrixWithDisplayNamePrice value
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
    typeof(VariantConverter<NewPlanBulkWithProrationPriceVariant, NewPlanBulkWithProrationPrice>)
)]
public sealed record class NewPlanBulkWithProrationPriceVariant(NewPlanBulkWithProrationPrice Value)
    : Price2,
        IVariant<NewPlanBulkWithProrationPriceVariant, NewPlanBulkWithProrationPrice>
{
    public static NewPlanBulkWithProrationPriceVariant From(NewPlanBulkWithProrationPrice value)
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
        NewPlanGroupedTieredPackagePriceVariant,
        NewPlanGroupedTieredPackagePrice
    >)
)]
public sealed record class NewPlanGroupedTieredPackagePriceVariant(
    NewPlanGroupedTieredPackagePrice Value
) : Price2, IVariant<NewPlanGroupedTieredPackagePriceVariant, NewPlanGroupedTieredPackagePrice>
{
    public static NewPlanGroupedTieredPackagePriceVariant From(
        NewPlanGroupedTieredPackagePrice value
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
        NewPlanMaxGroupTieredPackagePriceVariant,
        NewPlanMaxGroupTieredPackagePrice
    >)
)]
public sealed record class NewPlanMaxGroupTieredPackagePriceVariant(
    NewPlanMaxGroupTieredPackagePrice Value
) : Price2, IVariant<NewPlanMaxGroupTieredPackagePriceVariant, NewPlanMaxGroupTieredPackagePrice>
{
    public static NewPlanMaxGroupTieredPackagePriceVariant From(
        NewPlanMaxGroupTieredPackagePrice value
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
        NewPlanScalableMatrixWithUnitPricingPriceVariant,
        NewPlanScalableMatrixWithUnitPricingPrice
    >)
)]
public sealed record class NewPlanScalableMatrixWithUnitPricingPriceVariant(
    NewPlanScalableMatrixWithUnitPricingPrice Value
)
    : Price2,
        IVariant<
            NewPlanScalableMatrixWithUnitPricingPriceVariant,
            NewPlanScalableMatrixWithUnitPricingPrice
        >
{
    public static NewPlanScalableMatrixWithUnitPricingPriceVariant From(
        NewPlanScalableMatrixWithUnitPricingPrice value
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
        NewPlanScalableMatrixWithTieredPricingPriceVariant,
        NewPlanScalableMatrixWithTieredPricingPrice
    >)
)]
public sealed record class NewPlanScalableMatrixWithTieredPricingPriceVariant(
    NewPlanScalableMatrixWithTieredPricingPrice Value
)
    : Price2,
        IVariant<
            NewPlanScalableMatrixWithTieredPricingPriceVariant,
            NewPlanScalableMatrixWithTieredPricingPrice
        >
{
    public static NewPlanScalableMatrixWithTieredPricingPriceVariant From(
        NewPlanScalableMatrixWithTieredPricingPrice value
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
        NewPlanCumulativeGroupedBulkPriceVariant,
        NewPlanCumulativeGroupedBulkPrice
    >)
)]
public sealed record class NewPlanCumulativeGroupedBulkPriceVariant(
    NewPlanCumulativeGroupedBulkPrice Value
) : Price2, IVariant<NewPlanCumulativeGroupedBulkPriceVariant, NewPlanCumulativeGroupedBulkPrice>
{
    public static NewPlanCumulativeGroupedBulkPriceVariant From(
        NewPlanCumulativeGroupedBulkPrice value
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
        NewPlanTieredPackageWithMinimumPriceVariant,
        NewPlanTieredPackageWithMinimumPrice
    >)
)]
public sealed record class NewPlanTieredPackageWithMinimumPriceVariant(
    NewPlanTieredPackageWithMinimumPrice Value
)
    : Price2,
        IVariant<NewPlanTieredPackageWithMinimumPriceVariant, NewPlanTieredPackageWithMinimumPrice>
{
    public static NewPlanTieredPackageWithMinimumPriceVariant From(
        NewPlanTieredPackageWithMinimumPrice value
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
        NewPlanMatrixWithAllocationPriceVariant,
        NewPlanMatrixWithAllocationPrice
    >)
)]
public sealed record class NewPlanMatrixWithAllocationPriceVariant(
    NewPlanMatrixWithAllocationPrice Value
) : Price2, IVariant<NewPlanMatrixWithAllocationPriceVariant, NewPlanMatrixWithAllocationPrice>
{
    public static NewPlanMatrixWithAllocationPriceVariant From(
        NewPlanMatrixWithAllocationPrice value
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
    typeof(VariantConverter<NewPlanGroupedTieredPriceVariant, NewPlanGroupedTieredPrice>)
)]
public sealed record class NewPlanGroupedTieredPriceVariant(NewPlanGroupedTieredPrice Value)
    : Price2,
        IVariant<NewPlanGroupedTieredPriceVariant, NewPlanGroupedTieredPrice>
{
    public static NewPlanGroupedTieredPriceVariant From(NewPlanGroupedTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
