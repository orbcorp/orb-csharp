using Models = Orb.Models;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceVariants;

public sealed record class NewPlanUnitPrice(Models::NewPlanUnitPrice Value)
    : Price,
        IVariant<NewPlanUnitPrice, Models::NewPlanUnitPrice>
{
    public static NewPlanUnitPrice From(Models::NewPlanUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanPackagePrice(Models::NewPlanPackagePrice Value)
    : Price,
        IVariant<NewPlanPackagePrice, Models::NewPlanPackagePrice>
{
    public static NewPlanPackagePrice From(Models::NewPlanPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanMatrixPrice(Models::NewPlanMatrixPrice Value)
    : Price,
        IVariant<NewPlanMatrixPrice, Models::NewPlanMatrixPrice>
{
    public static NewPlanMatrixPrice From(Models::NewPlanMatrixPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanTieredPrice(Models::NewPlanTieredPrice Value)
    : Price,
        IVariant<NewPlanTieredPrice, Models::NewPlanTieredPrice>
{
    public static NewPlanTieredPrice From(Models::NewPlanTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanTieredBPSPrice(Models::NewPlanTieredBPSPrice Value)
    : Price,
        IVariant<NewPlanTieredBPSPrice, Models::NewPlanTieredBPSPrice>
{
    public static NewPlanTieredBPSPrice From(Models::NewPlanTieredBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanBPSPrice(Models::NewPlanBPSPrice Value)
    : Price,
        IVariant<NewPlanBPSPrice, Models::NewPlanBPSPrice>
{
    public static NewPlanBPSPrice From(Models::NewPlanBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanBulkBPSPrice(Models::NewPlanBulkBPSPrice Value)
    : Price,
        IVariant<NewPlanBulkBPSPrice, Models::NewPlanBulkBPSPrice>
{
    public static NewPlanBulkBPSPrice From(Models::NewPlanBulkBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanBulkPrice(Models::NewPlanBulkPrice Value)
    : Price,
        IVariant<NewPlanBulkPrice, Models::NewPlanBulkPrice>
{
    public static NewPlanBulkPrice From(Models::NewPlanBulkPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanThresholdTotalAmountPrice(
    Models::NewPlanThresholdTotalAmountPrice Value
) : Price, IVariant<NewPlanThresholdTotalAmountPrice, Models::NewPlanThresholdTotalAmountPrice>
{
    public static NewPlanThresholdTotalAmountPrice From(
        Models::NewPlanThresholdTotalAmountPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanTieredPackagePrice(Models::NewPlanTieredPackagePrice Value)
    : Price,
        IVariant<NewPlanTieredPackagePrice, Models::NewPlanTieredPackagePrice>
{
    public static NewPlanTieredPackagePrice From(Models::NewPlanTieredPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanTieredWithMinimumPrice(
    Models::NewPlanTieredWithMinimumPrice Value
) : Price, IVariant<NewPlanTieredWithMinimumPrice, Models::NewPlanTieredWithMinimumPrice>
{
    public static NewPlanTieredWithMinimumPrice From(Models::NewPlanTieredWithMinimumPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanUnitWithPercentPrice(Models::NewPlanUnitWithPercentPrice Value)
    : Price,
        IVariant<NewPlanUnitWithPercentPrice, Models::NewPlanUnitWithPercentPrice>
{
    public static NewPlanUnitWithPercentPrice From(Models::NewPlanUnitWithPercentPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanPackageWithAllocationPrice(
    Models::NewPlanPackageWithAllocationPrice Value
) : Price, IVariant<NewPlanPackageWithAllocationPrice, Models::NewPlanPackageWithAllocationPrice>
{
    public static NewPlanPackageWithAllocationPrice From(
        Models::NewPlanPackageWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanTierWithProrationPrice(
    Models::NewPlanTierWithProrationPrice Value
) : Price, IVariant<NewPlanTierWithProrationPrice, Models::NewPlanTierWithProrationPrice>
{
    public static NewPlanTierWithProrationPrice From(Models::NewPlanTierWithProrationPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanUnitWithProrationPrice(
    Models::NewPlanUnitWithProrationPrice Value
) : Price, IVariant<NewPlanUnitWithProrationPrice, Models::NewPlanUnitWithProrationPrice>
{
    public static NewPlanUnitWithProrationPrice From(Models::NewPlanUnitWithProrationPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanGroupedAllocationPrice(
    Models::NewPlanGroupedAllocationPrice Value
) : Price, IVariant<NewPlanGroupedAllocationPrice, Models::NewPlanGroupedAllocationPrice>
{
    public static NewPlanGroupedAllocationPrice From(Models::NewPlanGroupedAllocationPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanGroupedWithProratedMinimumPrice(
    Models::NewPlanGroupedWithProratedMinimumPrice Value
)
    : Price,
        IVariant<
            NewPlanGroupedWithProratedMinimumPrice,
            Models::NewPlanGroupedWithProratedMinimumPrice
        >
{
    public static NewPlanGroupedWithProratedMinimumPrice From(
        Models::NewPlanGroupedWithProratedMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanGroupedWithMeteredMinimumPrice(
    Models::NewPlanGroupedWithMeteredMinimumPrice Value
)
    : Price,
        IVariant<
            NewPlanGroupedWithMeteredMinimumPrice,
            Models::NewPlanGroupedWithMeteredMinimumPrice
        >
{
    public static NewPlanGroupedWithMeteredMinimumPrice From(
        Models::NewPlanGroupedWithMeteredMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanMatrixWithDisplayNamePrice(
    Models::NewPlanMatrixWithDisplayNamePrice Value
) : Price, IVariant<NewPlanMatrixWithDisplayNamePrice, Models::NewPlanMatrixWithDisplayNamePrice>
{
    public static NewPlanMatrixWithDisplayNamePrice From(
        Models::NewPlanMatrixWithDisplayNamePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanBulkWithProrationPrice(
    Models::NewPlanBulkWithProrationPrice Value
) : Price, IVariant<NewPlanBulkWithProrationPrice, Models::NewPlanBulkWithProrationPrice>
{
    public static NewPlanBulkWithProrationPrice From(Models::NewPlanBulkWithProrationPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanGroupedTieredPackagePrice(
    Models::NewPlanGroupedTieredPackagePrice Value
) : Price, IVariant<NewPlanGroupedTieredPackagePrice, Models::NewPlanGroupedTieredPackagePrice>
{
    public static NewPlanGroupedTieredPackagePrice From(
        Models::NewPlanGroupedTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanMaxGroupTieredPackagePrice(
    Models::NewPlanMaxGroupTieredPackagePrice Value
) : Price, IVariant<NewPlanMaxGroupTieredPackagePrice, Models::NewPlanMaxGroupTieredPackagePrice>
{
    public static NewPlanMaxGroupTieredPackagePrice From(
        Models::NewPlanMaxGroupTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanScalableMatrixWithUnitPricingPrice(
    Models::NewPlanScalableMatrixWithUnitPricingPrice Value
)
    : Price,
        IVariant<
            NewPlanScalableMatrixWithUnitPricingPrice,
            Models::NewPlanScalableMatrixWithUnitPricingPrice
        >
{
    public static NewPlanScalableMatrixWithUnitPricingPrice From(
        Models::NewPlanScalableMatrixWithUnitPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanScalableMatrixWithTieredPricingPrice(
    Models::NewPlanScalableMatrixWithTieredPricingPrice Value
)
    : Price,
        IVariant<
            NewPlanScalableMatrixWithTieredPricingPrice,
            Models::NewPlanScalableMatrixWithTieredPricingPrice
        >
{
    public static NewPlanScalableMatrixWithTieredPricingPrice From(
        Models::NewPlanScalableMatrixWithTieredPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanCumulativeGroupedBulkPrice(
    Models::NewPlanCumulativeGroupedBulkPrice Value
) : Price, IVariant<NewPlanCumulativeGroupedBulkPrice, Models::NewPlanCumulativeGroupedBulkPrice>
{
    public static NewPlanCumulativeGroupedBulkPrice From(
        Models::NewPlanCumulativeGroupedBulkPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanTieredPackageWithMinimumPrice(
    Models::NewPlanTieredPackageWithMinimumPrice Value
)
    : Price,
        IVariant<NewPlanTieredPackageWithMinimumPrice, Models::NewPlanTieredPackageWithMinimumPrice>
{
    public static NewPlanTieredPackageWithMinimumPrice From(
        Models::NewPlanTieredPackageWithMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanMatrixWithAllocationPrice(
    Models::NewPlanMatrixWithAllocationPrice Value
) : Price, IVariant<NewPlanMatrixWithAllocationPrice, Models::NewPlanMatrixWithAllocationPrice>
{
    public static NewPlanMatrixWithAllocationPrice From(
        Models::NewPlanMatrixWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewPlanGroupedTieredPrice(Models::NewPlanGroupedTieredPrice Value)
    : Price,
        IVariant<NewPlanGroupedTieredPrice, Models::NewPlanGroupedTieredPrice>
{
    public static NewPlanGroupedTieredPrice From(Models::NewPlanGroupedTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
