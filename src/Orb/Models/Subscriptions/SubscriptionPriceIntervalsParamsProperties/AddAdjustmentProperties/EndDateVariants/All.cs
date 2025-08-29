using Models = Orb.Models;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties.EndDateVariants;

public sealed record class DateTime(System::DateTime Value)
    : EndDate,
        IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BillingCycleRelativeDate(
    ApiEnum<string, Models::BillingCycleRelativeDate> Value
) : EndDate, IVariant<BillingCycleRelativeDate, ApiEnum<string, Models::BillingCycleRelativeDate>>
{
    public static BillingCycleRelativeDate From(
        ApiEnum<string, Models::BillingCycleRelativeDate> value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
