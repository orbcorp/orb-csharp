using Orb.Core;
using Models = Orb.Models;
using PriceProperties = Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties;
using ReplacePriceProperties = Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceVariants;

public sealed record class NewPlanUnitPrice(Models::NewPlanUnitPrice Value)
    : ReplacePriceProperties::Price,
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

public sealed record class NewPlanTieredPrice(Models::NewPlanTieredPrice Value)
    : ReplacePriceProperties::Price,
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

public sealed record class NewPlanBulkPrice(Models::NewPlanBulkPrice Value)
    : ReplacePriceProperties::Price,
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

public sealed record class NewPlanPackagePrice(Models::NewPlanPackagePrice Value)
    : ReplacePriceProperties::Price,
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
    : ReplacePriceProperties::Price,
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

public sealed record class NewPlanThresholdTotalAmountPrice(
    Models::NewPlanThresholdTotalAmountPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanThresholdTotalAmountPrice, Models::NewPlanThresholdTotalAmountPrice>
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
    : ReplacePriceProperties::Price,
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
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanTieredWithMinimumPrice, Models::NewPlanTieredWithMinimumPrice>
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

public sealed record class NewPlanGroupedTieredPrice(Models::NewPlanGroupedTieredPrice Value)
    : ReplacePriceProperties::Price,
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

public sealed record class NewPlanTieredPackageWithMinimumPrice(
    Models::NewPlanTieredPackageWithMinimumPrice Value
)
    : ReplacePriceProperties::Price,
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

public sealed record class NewPlanPackageWithAllocationPrice(
    Models::NewPlanPackageWithAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanPackageWithAllocationPrice, Models::NewPlanPackageWithAllocationPrice>
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

public sealed record class NewPlanUnitWithPercentPrice(Models::NewPlanUnitWithPercentPrice Value)
    : ReplacePriceProperties::Price,
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

public sealed record class NewPlanMatrixWithAllocationPrice(
    Models::NewPlanMatrixWithAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanMatrixWithAllocationPrice, Models::NewPlanMatrixWithAllocationPrice>
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

public sealed record class TieredWithProration(PriceProperties::TieredWithProration Value)
    : ReplacePriceProperties::Price,
        IVariant<TieredWithProration, PriceProperties::TieredWithProration>
{
    public static TieredWithProration From(PriceProperties::TieredWithProration value)
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
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanUnitWithProrationPrice, Models::NewPlanUnitWithProrationPrice>
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
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanGroupedAllocationPrice, Models::NewPlanGroupedAllocationPrice>
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

public sealed record class NewPlanBulkWithProrationPrice(
    Models::NewPlanBulkWithProrationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanBulkWithProrationPrice, Models::NewPlanBulkWithProrationPrice>
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

public sealed record class NewPlanGroupedWithProratedMinimumPrice(
    Models::NewPlanGroupedWithProratedMinimumPrice Value
)
    : ReplacePriceProperties::Price,
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
    : ReplacePriceProperties::Price,
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

public sealed record class GroupedWithMinMaxThresholds(
    PriceProperties::GroupedWithMinMaxThresholds Value
)
    : ReplacePriceProperties::Price,
        IVariant<GroupedWithMinMaxThresholds, PriceProperties::GroupedWithMinMaxThresholds>
{
    public static GroupedWithMinMaxThresholds From(
        PriceProperties::GroupedWithMinMaxThresholds value
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
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanMatrixWithDisplayNamePrice, Models::NewPlanMatrixWithDisplayNamePrice>
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

public sealed record class NewPlanGroupedTieredPackagePrice(
    Models::NewPlanGroupedTieredPackagePrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanGroupedTieredPackagePrice, Models::NewPlanGroupedTieredPackagePrice>
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
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanMaxGroupTieredPackagePrice, Models::NewPlanMaxGroupTieredPackagePrice>
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
    : ReplacePriceProperties::Price,
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
    : ReplacePriceProperties::Price,
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
)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanCumulativeGroupedBulkPrice, Models::NewPlanCumulativeGroupedBulkPrice>
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

public sealed record class NewPlanMinimumCompositePrice(Models::NewPlanMinimumCompositePrice Value)
    : ReplacePriceProperties::Price,
        IVariant<NewPlanMinimumCompositePrice, Models::NewPlanMinimumCompositePrice>
{
    public static NewPlanMinimumCompositePrice From(Models::NewPlanMinimumCompositePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
