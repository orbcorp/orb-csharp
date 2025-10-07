using Orb.Core;
using Models = Orb.Models;
using PriceProperties = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceVariants;

public sealed record class NewPlanUnitPrice(Models::NewPlanUnitPrice Value)
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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

public sealed record class TieredWithProration(
    global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.TieredWithProration Value
)
    : PriceProperties::Price,
        IVariant<
            TieredWithProration,
            global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.TieredWithProration
        >
{
    public static TieredWithProration From(
        global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.TieredWithProration value
    )
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.GroupedWithMinMaxThresholds Value
)
    : PriceProperties::Price,
        IVariant<
            GroupedWithMinMaxThresholds,
            global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.GroupedWithMinMaxThresholds
        >
{
    public static GroupedWithMinMaxThresholds From(
        global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.GroupedWithMinMaxThresholds value
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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
    : PriceProperties::Price,
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

public sealed record class Percent(
    global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.Percent Value
)
    : PriceProperties::Price,
        IVariant<
            Percent,
            global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.Percent
        >
{
    public static Percent From(
        global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.Percent value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class EventOutput(
    global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.EventOutput Value
)
    : PriceProperties::Price,
        IVariant<
            EventOutput,
            global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.EventOutput
        >
{
    public static EventOutput From(
        global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.EventOutput value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
