using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<SubLineItemGrouping>))]
public sealed record class SubLineItemGrouping : Orb::ModelBase, Orb::IFromRaw<SubLineItemGrouping>
{
    public required string Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("key", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("key");
        }
        set { this.Properties["key"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// No value indicates the default group
    /// </summary>
    public required string? Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("value", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["value"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Key;
        _ = this.Value;
    }

    public SubLineItemGrouping() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    SubLineItemGrouping(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubLineItemGrouping FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
