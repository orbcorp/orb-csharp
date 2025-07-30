using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

/// <summary>
/// Reset billing periods to be aligned with the plan change's effective date or
/// start of the month. Defaults to `unchanged` which keeps subscription's existing
/// billing cycle alignment.
/// </summary>
[JsonConverter(typeof(EnumConverter<BillingCycleAlignment, string>))]
public sealed record class BillingCycleAlignment(string value)
    : IEnum<BillingCycleAlignment, string>
{
    public static readonly BillingCycleAlignment Unchanged = new("unchanged");

    public static readonly BillingCycleAlignment PlanChangeDate = new("plan_change_date");

    public static readonly BillingCycleAlignment StartOfMonth = new("start_of_month");

    readonly string _value = value;

    public enum Value
    {
        Unchanged,
        PlanChangeDate,
        StartOfMonth,
    }

    public Value Known() =>
        _value switch
        {
            "unchanged" => Value.Unchanged,
            "plan_change_date" => Value.PlanChangeDate,
            "start_of_month" => Value.StartOfMonth,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static BillingCycleAlignment FromRaw(string value)
    {
        return new(value);
    }
}
