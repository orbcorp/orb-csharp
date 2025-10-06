using Orb.Core;
using BodyProperties = Orb.Models.Prices.PriceCreateParamsProperties.BodyProperties;
using Models = Orb.Models;

namespace Orb.Models.Prices.PriceCreateParamsProperties.BodyVariants;

public sealed record class NewFloatingUnitPrice(Models::NewFloatingUnitPrice Value)
    : Body,
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
    : Body,
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
    : Body,
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
    : Body,
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
    : Body,
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
    : Body,
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
) : Body, IVariant<NewFloatingTieredPackagePrice, Models::NewFloatingTieredPackagePrice>
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
) : Body, IVariant<NewFloatingTieredWithMinimumPrice, Models::NewFloatingTieredWithMinimumPrice>
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
) : Body, IVariant<NewFloatingGroupedTieredPrice, Models::NewFloatingGroupedTieredPrice>
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
    : Body,
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
    : Body,
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
) : Body, IVariant<NewFloatingUnitWithPercentPrice, Models::NewFloatingUnitWithPercentPrice>
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
    : Body,
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
) : Body, IVariant<NewFloatingTieredWithProrationPrice, Models::NewFloatingTieredWithProrationPrice>
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
) : Body, IVariant<NewFloatingUnitWithProrationPrice, Models::NewFloatingUnitWithProrationPrice>
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
) : Body, IVariant<NewFloatingGroupedAllocationPrice, Models::NewFloatingGroupedAllocationPrice>
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
) : Body, IVariant<NewFloatingBulkWithProrationPrice, Models::NewFloatingBulkWithProrationPrice>
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
    : Body,
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
    : Body,
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
    BodyProperties::GroupedWithMinMaxThresholds Value
) : Body, IVariant<GroupedWithMinMaxThresholds, BodyProperties::GroupedWithMinMaxThresholds>
{
    public static GroupedWithMinMaxThresholds From(
        BodyProperties::GroupedWithMinMaxThresholds value
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
    : Body,
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
    : Body,
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
    : Body,
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
    : Body,
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
    : Body,
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
    : Body,
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
) : Body, IVariant<NewFloatingMinimumCompositePrice, Models::NewFloatingMinimumCompositePrice>
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

public sealed record class EventOutput(BodyProperties::EventOutput Value)
    : Body,
        IVariant<EventOutput, BodyProperties::EventOutput>
{
    public static EventOutput From(BodyProperties::EventOutput value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
