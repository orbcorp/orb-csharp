using Models = Orb.Models;

namespace Orb.Models.Plans.PlanProperties.AdjustmentVariants;

public sealed record class PlanPhaseUsageDiscountAdjustment(
    Models::PlanPhaseUsageDiscountAdjustment Value
) : Adjustment, IVariant<PlanPhaseUsageDiscountAdjustment, Models::PlanPhaseUsageDiscountAdjustment>
{
    public static PlanPhaseUsageDiscountAdjustment From(
        Models::PlanPhaseUsageDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PlanPhaseAmountDiscountAdjustment(
    Models::PlanPhaseAmountDiscountAdjustment Value
)
    : Adjustment,
        IVariant<PlanPhaseAmountDiscountAdjustment, Models::PlanPhaseAmountDiscountAdjustment>
{
    public static PlanPhaseAmountDiscountAdjustment From(
        Models::PlanPhaseAmountDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PlanPhasePercentageDiscountAdjustment(
    Models::PlanPhasePercentageDiscountAdjustment Value
)
    : Adjustment,
        IVariant<
            PlanPhasePercentageDiscountAdjustment,
            Models::PlanPhasePercentageDiscountAdjustment
        >
{
    public static PlanPhasePercentageDiscountAdjustment From(
        Models::PlanPhasePercentageDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PlanPhaseMinimumAdjustment(Models::PlanPhaseMinimumAdjustment Value)
    : Adjustment,
        IVariant<PlanPhaseMinimumAdjustment, Models::PlanPhaseMinimumAdjustment>
{
    public static PlanPhaseMinimumAdjustment From(Models::PlanPhaseMinimumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PlanPhaseMaximumAdjustment(Models::PlanPhaseMaximumAdjustment Value)
    : Adjustment,
        IVariant<PlanPhaseMaximumAdjustment, Models::PlanPhaseMaximumAdjustment>
{
    public static PlanPhaseMaximumAdjustment From(Models::PlanPhaseMaximumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
