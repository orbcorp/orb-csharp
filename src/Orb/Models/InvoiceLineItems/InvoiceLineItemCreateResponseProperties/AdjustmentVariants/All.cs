using Orb.Core;
using Models = Orb.Models;

namespace Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties.AdjustmentVariants;

public sealed record class MonetaryUsageDiscountAdjustment(
    Models::MonetaryUsageDiscountAdjustment Value
) : Adjustment, IVariant<MonetaryUsageDiscountAdjustment, Models::MonetaryUsageDiscountAdjustment>
{
    public static MonetaryUsageDiscountAdjustment From(
        Models::MonetaryUsageDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MonetaryAmountDiscountAdjustment(
    Models::MonetaryAmountDiscountAdjustment Value
) : Adjustment, IVariant<MonetaryAmountDiscountAdjustment, Models::MonetaryAmountDiscountAdjustment>
{
    public static MonetaryAmountDiscountAdjustment From(
        Models::MonetaryAmountDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MonetaryPercentageDiscountAdjustment(
    Models::MonetaryPercentageDiscountAdjustment Value
)
    : Adjustment,
        IVariant<MonetaryPercentageDiscountAdjustment, Models::MonetaryPercentageDiscountAdjustment>
{
    public static MonetaryPercentageDiscountAdjustment From(
        Models::MonetaryPercentageDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MonetaryMinimumAdjustment(Models::MonetaryMinimumAdjustment Value)
    : Adjustment,
        IVariant<MonetaryMinimumAdjustment, Models::MonetaryMinimumAdjustment>
{
    public static MonetaryMinimumAdjustment From(Models::MonetaryMinimumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MonetaryMaximumAdjustment(Models::MonetaryMaximumAdjustment Value)
    : Adjustment,
        IVariant<MonetaryMaximumAdjustment, Models::MonetaryMaximumAdjustment>
{
    public static MonetaryMaximumAdjustment From(Models::MonetaryMaximumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
