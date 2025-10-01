using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

/// <summary>
/// Reset billing periods to be aligned with the plan change's effective date or
/// start of the month. Defaults to `unchanged` which keeps subscription's existing
/// billing cycle alignment.
/// </summary>
[JsonConverter(typeof(BillingCycleAlignmentConverter))]
public enum BillingCycleAlignment
{
    Unchanged,
    PlanChangeDate,
    StartOfMonth,
}

sealed class BillingCycleAlignmentConverter : JsonConverter<BillingCycleAlignment>
{
    public override BillingCycleAlignment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unchanged" => BillingCycleAlignment.Unchanged,
            "plan_change_date" => BillingCycleAlignment.PlanChangeDate,
            "start_of_month" => BillingCycleAlignment.StartOfMonth,
            _ => (BillingCycleAlignment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingCycleAlignment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingCycleAlignment.Unchanged => "unchanged",
                BillingCycleAlignment.PlanChangeDate => "plan_change_date",
                BillingCycleAlignment.StartOfMonth => "start_of_month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
