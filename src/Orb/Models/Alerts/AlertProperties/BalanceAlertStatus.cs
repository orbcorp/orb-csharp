using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts.AlertProperties;

/// <summary>
/// Alert status is used to determine if an alert is currently in-alert or not.
/// </summary>
[JsonConverter(typeof(ModelConverter<BalanceAlertStatus>))]
public sealed record class BalanceAlertStatus : ModelBase, IFromRaw<BalanceAlertStatus>
{
    /// <summary>
    /// Whether the alert is currently in-alert or not.
    /// </summary>
    public required bool InAlert
    {
        get
        {
            if (!this.Properties.TryGetValue("in_alert", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "in_alert",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["in_alert"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The value of the threshold that defines the alert status.
    /// </summary>
    public required double ThresholdValue
    {
        get
        {
            if (!this.Properties.TryGetValue("threshold_value", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "threshold_value",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["threshold_value"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.InAlert;
        _ = this.ThresholdValue;
    }

    public BalanceAlertStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceAlertStatus(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BalanceAlertStatus FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
