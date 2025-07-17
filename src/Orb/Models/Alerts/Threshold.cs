using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// Thresholds are used to define the conditions under which an alert will be triggered.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Threshold>))]
public sealed record class Threshold : Orb::ModelBase, Orb::IFromRaw<Threshold>
{
    /// <summary>
    /// The value at which an alert will fire. For credit balance alerts, the alert
    /// will fire at or below this value. For usage and cost alerts, the alert will
    /// fire at or above this value.
    /// </summary>
    public required double Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("value", "Missing required argument");

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["value"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Value;
    }

    public Threshold() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Threshold(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Threshold FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
