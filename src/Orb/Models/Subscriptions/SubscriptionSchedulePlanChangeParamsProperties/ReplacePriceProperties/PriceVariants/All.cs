using Orb.Core;
using PriceProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties.PriceProperties;
using ReplacePriceProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties.PriceVariants;

public sealed record class NewSubscriptionUnitPrice(Subscriptions::NewSubscriptionUnitPrice Value)
    : ReplacePriceProperties::Price,
        IVariant<NewSubscriptionUnitPrice, Subscriptions::NewSubscriptionUnitPrice>
{
    public static NewSubscriptionUnitPrice From(Subscriptions::NewSubscriptionUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionTieredPrice(
    Subscriptions::NewSubscriptionTieredPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewSubscriptionTieredPrice, Subscriptions::NewSubscriptionTieredPrice>
{
    public static NewSubscriptionTieredPrice From(Subscriptions::NewSubscriptionTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionBulkPrice(Subscriptions::NewSubscriptionBulkPrice Value)
    : ReplacePriceProperties::Price,
        IVariant<NewSubscriptionBulkPrice, Subscriptions::NewSubscriptionBulkPrice>
{
    public static NewSubscriptionBulkPrice From(Subscriptions::NewSubscriptionBulkPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionPackagePrice(
    Subscriptions::NewSubscriptionPackagePrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewSubscriptionPackagePrice, Subscriptions::NewSubscriptionPackagePrice>
{
    public static NewSubscriptionPackagePrice From(Subscriptions::NewSubscriptionPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionMatrixPrice(
    Subscriptions::NewSubscriptionMatrixPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<NewSubscriptionMatrixPrice, Subscriptions::NewSubscriptionMatrixPrice>
{
    public static NewSubscriptionMatrixPrice From(Subscriptions::NewSubscriptionMatrixPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionThresholdTotalAmountPrice(
    Subscriptions::NewSubscriptionThresholdTotalAmountPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionThresholdTotalAmountPrice,
            Subscriptions::NewSubscriptionThresholdTotalAmountPrice
        >
{
    public static NewSubscriptionThresholdTotalAmountPrice From(
        Subscriptions::NewSubscriptionThresholdTotalAmountPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionTieredPackagePrice(
    Subscriptions::NewSubscriptionTieredPackagePrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionTieredPackagePrice,
            Subscriptions::NewSubscriptionTieredPackagePrice
        >
{
    public static NewSubscriptionTieredPackagePrice From(
        Subscriptions::NewSubscriptionTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionTieredWithMinimumPrice(
    Subscriptions::NewSubscriptionTieredWithMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionTieredWithMinimumPrice,
            Subscriptions::NewSubscriptionTieredWithMinimumPrice
        >
{
    public static NewSubscriptionTieredWithMinimumPrice From(
        Subscriptions::NewSubscriptionTieredWithMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionGroupedTieredPrice(
    Subscriptions::NewSubscriptionGroupedTieredPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionGroupedTieredPrice,
            Subscriptions::NewSubscriptionGroupedTieredPrice
        >
{
    public static NewSubscriptionGroupedTieredPrice From(
        Subscriptions::NewSubscriptionGroupedTieredPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionTieredPackageWithMinimumPrice(
    Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionTieredPackageWithMinimumPrice,
            Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice
        >
{
    public static NewSubscriptionTieredPackageWithMinimumPrice From(
        Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionPackageWithAllocationPrice(
    Subscriptions::NewSubscriptionPackageWithAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionPackageWithAllocationPrice,
            Subscriptions::NewSubscriptionPackageWithAllocationPrice
        >
{
    public static NewSubscriptionPackageWithAllocationPrice From(
        Subscriptions::NewSubscriptionPackageWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionUnitWithPercentPrice(
    Subscriptions::NewSubscriptionUnitWithPercentPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionUnitWithPercentPrice,
            Subscriptions::NewSubscriptionUnitWithPercentPrice
        >
{
    public static NewSubscriptionUnitWithPercentPrice From(
        Subscriptions::NewSubscriptionUnitWithPercentPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionMatrixWithAllocationPrice(
    Subscriptions::NewSubscriptionMatrixWithAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionMatrixWithAllocationPrice,
            Subscriptions::NewSubscriptionMatrixWithAllocationPrice
        >
{
    public static NewSubscriptionMatrixWithAllocationPrice From(
        Subscriptions::NewSubscriptionMatrixWithAllocationPrice value
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

public sealed record class NewSubscriptionUnitWithProrationPrice(
    Subscriptions::NewSubscriptionUnitWithProrationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionUnitWithProrationPrice,
            Subscriptions::NewSubscriptionUnitWithProrationPrice
        >
{
    public static NewSubscriptionUnitWithProrationPrice From(
        Subscriptions::NewSubscriptionUnitWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionGroupedAllocationPrice(
    Subscriptions::NewSubscriptionGroupedAllocationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionGroupedAllocationPrice,
            Subscriptions::NewSubscriptionGroupedAllocationPrice
        >
{
    public static NewSubscriptionGroupedAllocationPrice From(
        Subscriptions::NewSubscriptionGroupedAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionBulkWithProrationPrice(
    Subscriptions::NewSubscriptionBulkWithProrationPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionBulkWithProrationPrice,
            Subscriptions::NewSubscriptionBulkWithProrationPrice
        >
{
    public static NewSubscriptionBulkWithProrationPrice From(
        Subscriptions::NewSubscriptionBulkWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionGroupedWithProratedMinimumPrice(
    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionGroupedWithProratedMinimumPrice,
            Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice
        >
{
    public static NewSubscriptionGroupedWithProratedMinimumPrice From(
        Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionGroupedWithMeteredMinimumPrice(
    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionGroupedWithMeteredMinimumPrice,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        >
{
    public static NewSubscriptionGroupedWithMeteredMinimumPrice From(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice value
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

public sealed record class NewSubscriptionMatrixWithDisplayNamePrice(
    Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionMatrixWithDisplayNamePrice,
            Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice
        >
{
    public static NewSubscriptionMatrixWithDisplayNamePrice From(
        Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionGroupedTieredPackagePrice(
    Subscriptions::NewSubscriptionGroupedTieredPackagePrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionGroupedTieredPackagePrice,
            Subscriptions::NewSubscriptionGroupedTieredPackagePrice
        >
{
    public static NewSubscriptionGroupedTieredPackagePrice From(
        Subscriptions::NewSubscriptionGroupedTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionMaxGroupTieredPackagePrice(
    Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionMaxGroupTieredPackagePrice,
            Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice
        >
{
    public static NewSubscriptionMaxGroupTieredPackagePrice From(
        Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionScalableMatrixWithUnitPricingPrice(
    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionScalableMatrixWithUnitPricingPrice,
            Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice
        >
{
    public static NewSubscriptionScalableMatrixWithUnitPricingPrice From(
        Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionScalableMatrixWithTieredPricingPrice(
    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionScalableMatrixWithTieredPricingPrice,
            Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice
        >
{
    public static NewSubscriptionScalableMatrixWithTieredPricingPrice From(
        Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionCumulativeGroupedBulkPrice(
    Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionCumulativeGroupedBulkPrice,
            Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice
        >
{
    public static NewSubscriptionCumulativeGroupedBulkPrice From(
        Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewSubscriptionMinimumCompositePrice(
    Subscriptions::NewSubscriptionMinimumCompositePrice Value
)
    : ReplacePriceProperties::Price,
        IVariant<
            NewSubscriptionMinimumCompositePrice,
            Subscriptions::NewSubscriptionMinimumCompositePrice
        >
{
    public static NewSubscriptionMinimumCompositePrice From(
        Subscriptions::NewSubscriptionMinimumCompositePrice value
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
    : ReplacePriceProperties::Price,
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
