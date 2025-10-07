using Orb.Core;
using AddProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;
using Models = Orb.Models;
using PriceProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.PriceProperties;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.PriceVariants;

public sealed record class NewFloatingUnitPrice(Models::NewFloatingUnitPrice Value)
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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
    : AddProperties::Price,
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

public sealed record class Percent(PriceProperties::Percent Value)
    : AddProperties::Price,
        IVariant<Percent, PriceProperties::Percent>
{
    public static Percent From(PriceProperties::Percent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class EventOutput(PriceProperties::EventOutput Value)
    : AddProperties::Price,
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
