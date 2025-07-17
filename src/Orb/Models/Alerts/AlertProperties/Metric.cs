using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts.AlertProperties;

/// <summary>
/// The metric the alert applies to.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Metric>))]
public sealed record class Metric : Orb::ModelBase, Orb::IFromRaw<Metric>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public Metric() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Metric(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Metric FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
