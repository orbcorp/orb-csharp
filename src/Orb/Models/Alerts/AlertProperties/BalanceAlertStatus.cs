using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts.AlertProperties;

/// <summary>
/// Alert status is used to determine if an alert is currently in-alert or not.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<BalanceAlertStatus>))]
public sealed record class BalanceAlertStatus : Orb::ModelBase, Orb::IFromRaw<BalanceAlertStatus>
{
    /// <summary>
    /// Whether the alert is currently in-alert or not.
    /// </summary>
    public required bool InAlert
    {
        get
        {
            if (!this.Properties.TryGetValue("in_alert", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "in_alert",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["in_alert"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The value of the threshold that defines the alert status.
    /// </summary>
    public required double ThresholdValue
    {
        get
        {
            if (!this.Properties.TryGetValue("threshold_value", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "threshold_value",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["threshold_value"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.InAlert;
        _ = this.ThresholdValue;
    }

    public BalanceAlertStatus() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BalanceAlertStatus(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BalanceAlertStatus FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
