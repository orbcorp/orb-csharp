using PriceProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceProperties;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceVariants;

public sealed record class NewSubscriptionUnitPrice(Subscriptions::NewSubscriptionUnitPrice Value)
    : Price,
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

public sealed record class NewSubscriptionPackagePrice(
    Subscriptions::NewSubscriptionPackagePrice Value
) : Price, IVariant<NewSubscriptionPackagePrice, Subscriptions::NewSubscriptionPackagePrice>
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
) : Price, IVariant<NewSubscriptionMatrixPrice, Subscriptions::NewSubscriptionMatrixPrice>
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

public sealed record class NewSubscriptionTieredPrice(
    Subscriptions::NewSubscriptionTieredPrice Value
) : Price, IVariant<NewSubscriptionTieredPrice, Subscriptions::NewSubscriptionTieredPrice>
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
    : Price,
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

public sealed record class NewSubscriptionThresholdTotalAmountPrice(
    Subscriptions::NewSubscriptionThresholdTotalAmountPrice Value
)
    : Price,
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
    : Price,
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
    : Price,
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

public sealed record class NewSubscriptionUnitWithPercentPrice(
    Subscriptions::NewSubscriptionUnitWithPercentPrice Value
)
    : Price,
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

public sealed record class NewSubscriptionPackageWithAllocationPrice(
    Subscriptions::NewSubscriptionPackageWithAllocationPrice Value
)
    : Price,
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

public sealed record class NewSubscriptionTierWithProrationPrice(
    Subscriptions::NewSubscriptionTierWithProrationPrice Value
)
    : Price,
        IVariant<
            NewSubscriptionTierWithProrationPrice,
            Subscriptions::NewSubscriptionTierWithProrationPrice
        >
{
    public static NewSubscriptionTierWithProrationPrice From(
        Subscriptions::NewSubscriptionTierWithProrationPrice value
    )
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
    : Price,
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
    : Price,
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

public sealed record class NewSubscriptionGroupedWithProratedMinimumPrice(
    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice Value
)
    : Price,
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

public sealed record class NewSubscriptionBulkWithProrationPrice(
    Subscriptions::NewSubscriptionBulkWithProrationPrice Value
)
    : Price,
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

public sealed record class NewSubscriptionScalableMatrixWithUnitPricingPrice(
    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice Value
)
    : Price,
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
    : Price,
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
    : Price,
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

public sealed record class NewSubscriptionMaxGroupTieredPackagePrice(
    Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice Value
)
    : Price,
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

public sealed record class NewSubscriptionGroupedWithMeteredMinimumPrice(
    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice Value
)
    : Price,
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

public sealed record class NewSubscriptionMatrixWithDisplayNamePrice(
    Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice Value
)
    : Price,
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
    : Price,
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

public sealed record class NewSubscriptionMatrixWithAllocationPrice(
    Subscriptions::NewSubscriptionMatrixWithAllocationPrice Value
)
    : Price,
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

public sealed record class NewSubscriptionTieredPackageWithMinimumPrice(
    Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice Value
)
    : Price,
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

public sealed record class NewSubscriptionGroupedTieredPrice(
    Subscriptions::NewSubscriptionGroupedTieredPrice Value
)
    : Price,
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

public sealed record class GroupedWithMinMaxThresholds(
    PriceProperties::GroupedWithMinMaxThresholds Value
) : Price, IVariant<GroupedWithMinMaxThresholds, PriceProperties::GroupedWithMinMaxThresholds>
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

public sealed record class NewSubscriptionMinimumCompositePrice(
    Subscriptions::NewSubscriptionMinimumCompositePrice Value
)
    : Price,
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
