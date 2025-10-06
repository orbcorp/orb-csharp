using Orb.Core;
using Models = Orb.Models;
using PriceEvaluationProperties = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties;
using PriceProperties = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties.PriceProperties;

namespace Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties.PriceVariants;

public sealed record class NewFloatingUnitPrice(Models::NewFloatingUnitPrice Value)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingUnitPrice, Models::NewFloatingUnitPrice>
{
    public static NewFloatingUnitPrice From(Models::NewFloatingUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingTieredPrice(Models::NewFloatingTieredPrice Value)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingTieredPrice, Models::NewFloatingTieredPrice>
{
    public static NewFloatingTieredPrice From(Models::NewFloatingTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingBulkPrice(Models::NewFloatingBulkPrice Value)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingBulkPrice, Models::NewFloatingBulkPrice>
{
    public static NewFloatingBulkPrice From(Models::NewFloatingBulkPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingPackagePrice(Models::NewFloatingPackagePrice Value)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingPackagePrice, Models::NewFloatingPackagePrice>
{
    public static NewFloatingPackagePrice From(Models::NewFloatingPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingMatrixPrice(Models::NewFloatingMatrixPrice Value)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingMatrixPrice, Models::NewFloatingMatrixPrice>
{
    public static NewFloatingMatrixPrice From(Models::NewFloatingMatrixPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingThresholdTotalAmountPrice(
    Models::NewFloatingThresholdTotalAmountPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingThresholdTotalAmountPrice, Models::NewFloatingThresholdTotalAmountPrice>
{
    public static NewFloatingThresholdTotalAmountPrice From(
        Models::NewFloatingThresholdTotalAmountPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingTieredPackagePrice(
    Models::NewFloatingTieredPackagePrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingTieredPackagePrice, Models::NewFloatingTieredPackagePrice>
{
    public static NewFloatingTieredPackagePrice From(Models::NewFloatingTieredPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingTieredWithMinimumPrice(
    Models::NewFloatingTieredWithMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingTieredWithMinimumPrice, Models::NewFloatingTieredWithMinimumPrice>
{
    public static NewFloatingTieredWithMinimumPrice From(
        Models::NewFloatingTieredWithMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingGroupedTieredPrice(
    Models::NewFloatingGroupedTieredPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingGroupedTieredPrice, Models::NewFloatingGroupedTieredPrice>
{
    public static NewFloatingGroupedTieredPrice From(Models::NewFloatingGroupedTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingTieredPackageWithMinimumPrice(
    Models::NewFloatingTieredPackageWithMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingTieredPackageWithMinimumPrice,
            Models::NewFloatingTieredPackageWithMinimumPrice
        >
{
    public static NewFloatingTieredPackageWithMinimumPrice From(
        Models::NewFloatingTieredPackageWithMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingPackageWithAllocationPrice(
    Models::NewFloatingPackageWithAllocationPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingPackageWithAllocationPrice,
            Models::NewFloatingPackageWithAllocationPrice
        >
{
    public static NewFloatingPackageWithAllocationPrice From(
        Models::NewFloatingPackageWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingUnitWithPercentPrice(
    Models::NewFloatingUnitWithPercentPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingUnitWithPercentPrice, Models::NewFloatingUnitWithPercentPrice>
{
    public static NewFloatingUnitWithPercentPrice From(
        Models::NewFloatingUnitWithPercentPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingMatrixWithAllocationPrice(
    Models::NewFloatingMatrixWithAllocationPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingMatrixWithAllocationPrice, Models::NewFloatingMatrixWithAllocationPrice>
{
    public static NewFloatingMatrixWithAllocationPrice From(
        Models::NewFloatingMatrixWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingTieredWithProrationPrice(
    Models::NewFloatingTieredWithProrationPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingTieredWithProrationPrice, Models::NewFloatingTieredWithProrationPrice>
{
    public static NewFloatingTieredWithProrationPrice From(
        Models::NewFloatingTieredWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingUnitWithProrationPrice(
    Models::NewFloatingUnitWithProrationPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingUnitWithProrationPrice, Models::NewFloatingUnitWithProrationPrice>
{
    public static NewFloatingUnitWithProrationPrice From(
        Models::NewFloatingUnitWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingGroupedAllocationPrice(
    Models::NewFloatingGroupedAllocationPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingGroupedAllocationPrice, Models::NewFloatingGroupedAllocationPrice>
{
    public static NewFloatingGroupedAllocationPrice From(
        Models::NewFloatingGroupedAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingBulkWithProrationPrice(
    Models::NewFloatingBulkWithProrationPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingBulkWithProrationPrice, Models::NewFloatingBulkWithProrationPrice>
{
    public static NewFloatingBulkWithProrationPrice From(
        Models::NewFloatingBulkWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingGroupedWithProratedMinimumPrice(
    Models::NewFloatingGroupedWithProratedMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingGroupedWithProratedMinimumPrice,
            Models::NewFloatingGroupedWithProratedMinimumPrice
        >
{
    public static NewFloatingGroupedWithProratedMinimumPrice From(
        Models::NewFloatingGroupedWithProratedMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingGroupedWithMeteredMinimumPrice(
    Models::NewFloatingGroupedWithMeteredMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingGroupedWithMeteredMinimumPrice,
            Models::NewFloatingGroupedWithMeteredMinimumPrice
        >
{
    public static NewFloatingGroupedWithMeteredMinimumPrice From(
        Models::NewFloatingGroupedWithMeteredMinimumPrice value
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
    : PriceEvaluationProperties::Price,
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

public sealed record class NewFloatingMatrixWithDisplayNamePrice(
    Models::NewFloatingMatrixWithDisplayNamePrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingMatrixWithDisplayNamePrice,
            Models::NewFloatingMatrixWithDisplayNamePrice
        >
{
    public static NewFloatingMatrixWithDisplayNamePrice From(
        Models::NewFloatingMatrixWithDisplayNamePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingGroupedTieredPackagePrice(
    Models::NewFloatingGroupedTieredPackagePrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingGroupedTieredPackagePrice, Models::NewFloatingGroupedTieredPackagePrice>
{
    public static NewFloatingGroupedTieredPackagePrice From(
        Models::NewFloatingGroupedTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingMaxGroupTieredPackagePrice(
    Models::NewFloatingMaxGroupTieredPackagePrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingMaxGroupTieredPackagePrice,
            Models::NewFloatingMaxGroupTieredPackagePrice
        >
{
    public static NewFloatingMaxGroupTieredPackagePrice From(
        Models::NewFloatingMaxGroupTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingScalableMatrixWithUnitPricingPrice(
    Models::NewFloatingScalableMatrixWithUnitPricingPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingScalableMatrixWithUnitPricingPrice,
            Models::NewFloatingScalableMatrixWithUnitPricingPrice
        >
{
    public static NewFloatingScalableMatrixWithUnitPricingPrice From(
        Models::NewFloatingScalableMatrixWithUnitPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingScalableMatrixWithTieredPricingPrice(
    Models::NewFloatingScalableMatrixWithTieredPricingPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingScalableMatrixWithTieredPricingPrice,
            Models::NewFloatingScalableMatrixWithTieredPricingPrice
        >
{
    public static NewFloatingScalableMatrixWithTieredPricingPrice From(
        Models::NewFloatingScalableMatrixWithTieredPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingCumulativeGroupedBulkPrice(
    Models::NewFloatingCumulativeGroupedBulkPrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<
            NewFloatingCumulativeGroupedBulkPrice,
            Models::NewFloatingCumulativeGroupedBulkPrice
        >
{
    public static NewFloatingCumulativeGroupedBulkPrice From(
        Models::NewFloatingCumulativeGroupedBulkPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewFloatingMinimumCompositePrice(
    Models::NewFloatingMinimumCompositePrice Value
)
    : PriceEvaluationProperties::Price,
        IVariant<NewFloatingMinimumCompositePrice, Models::NewFloatingMinimumCompositePrice>
{
    public static NewFloatingMinimumCompositePrice From(
        Models::NewFloatingMinimumCompositePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class EventOutput(PriceProperties::EventOutput Value)
    : PriceEvaluationProperties::Price,
        IVariant<EventOutput, PriceProperties::EventOutput>
{
    public static EventOutput From(PriceProperties::EventOutput value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
