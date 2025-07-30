using System.Text.Json.Serialization;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceVariants;

[JsonConverter(typeof(VariantConverter<NewPlanUnitPriceVariant, NewPlanUnitPrice>))]
public sealed record class NewPlanUnitPriceVariant(NewPlanUnitPrice Value)
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
) : Price1, IVariant<NewPlanThresholdTotalAmountPriceVariant, NewPlanThresholdTotalAmountPrice>
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
) : Price1, IVariant<NewPlanPackageWithAllocationPriceVariant, NewPlanPackageWithAllocationPrice>
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
    : Price1,
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
) : Price1, IVariant<NewPlanMatrixWithDisplayNamePriceVariant, NewPlanMatrixWithDisplayNamePrice>
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
    : Price1,
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
) : Price1, IVariant<NewPlanGroupedTieredPackagePriceVariant, NewPlanGroupedTieredPackagePrice>
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
) : Price1, IVariant<NewPlanMaxGroupTieredPackagePriceVariant, NewPlanMaxGroupTieredPackagePrice>
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
    : Price1,
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
    : Price1,
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
) : Price1, IVariant<NewPlanCumulativeGroupedBulkPriceVariant, NewPlanCumulativeGroupedBulkPrice>
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
    : Price1,
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
) : Price1, IVariant<NewPlanMatrixWithAllocationPriceVariant, NewPlanMatrixWithAllocationPrice>
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
    : Price1,
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
