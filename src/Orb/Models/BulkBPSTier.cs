using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BulkBPSTier>))]
public sealed record class BulkBPSTier : Orb::ModelBase, Orb::IFromRaw<BulkBPSTier>
{
    /// <summary>
    /// Basis points to rate on
    /// </summary>
    public required double BPS
    {
        get
        {
            if (!this.Properties.TryGetValue("bps", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("bps", "Missing required argument");

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["bps"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Upper bound for tier
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["maximum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum amount to charge for any one event
    /// </summary>
    public string? PerUnitMaximum
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_maximum", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["per_unit_maximum"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.BPS;
        _ = this.MaximumAmount;
        _ = this.PerUnitMaximum;
    }

    public BulkBPSTier() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BulkBPSTier(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkBPSTier FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
