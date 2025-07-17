using Models = Orb.Models;
using Orb = Orb;
using PlanProperties = Orb.Models.Plans.PlanProperties;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanProperties.AdjustmentVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        PlanPhaseUsageDiscountAdjustment,
        Models::PlanPhaseUsageDiscountAdjustment
    >)
)]
public sealed record class PlanPhaseUsageDiscountAdjustment(
    Models::PlanPhaseUsageDiscountAdjustment Value
)
    : PlanProperties::Adjustment,
        Orb::IVariant<PlanPhaseUsageDiscountAdjustment, Models::PlanPhaseUsageDiscountAdjustment>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        PlanPhaseAmountDiscountAdjustment,
        Models::PlanPhaseAmountDiscountAdjustment
    >)
)]
public sealed record class PlanPhaseAmountDiscountAdjustment(
    Models::PlanPhaseAmountDiscountAdjustment Value
)
    : PlanProperties::Adjustment,
        Orb::IVariant<PlanPhaseAmountDiscountAdjustment, Models::PlanPhaseAmountDiscountAdjustment>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        PlanPhasePercentageDiscountAdjustment,
        Models::PlanPhasePercentageDiscountAdjustment
    >)
)]
public sealed record class PlanPhasePercentageDiscountAdjustment(
    Models::PlanPhasePercentageDiscountAdjustment Value
)
    : PlanProperties::Adjustment,
        Orb::IVariant<
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<PlanPhaseMinimumAdjustment, Models::PlanPhaseMinimumAdjustment>)
)]
public sealed record class PlanPhaseMinimumAdjustment(Models::PlanPhaseMinimumAdjustment Value)
    : PlanProperties::Adjustment,
        Orb::IVariant<PlanPhaseMinimumAdjustment, Models::PlanPhaseMinimumAdjustment>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<PlanPhaseMaximumAdjustment, Models::PlanPhaseMaximumAdjustment>)
)]
public sealed record class PlanPhaseMaximumAdjustment(Models::PlanPhaseMaximumAdjustment Value)
    : PlanProperties::Adjustment,
        Orb::IVariant<PlanPhaseMaximumAdjustment, Models::PlanPhaseMaximumAdjustment>
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
