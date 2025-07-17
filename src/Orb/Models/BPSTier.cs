using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BPSTier>))]
public sealed record class BPSTier : Orb::ModelBase, Orb::IFromRaw<BPSTier>
{
    /// <summary>
    /// Per-event basis point rate
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
    /// Exclusive tier starting value
    /// </summary>
    public required string MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("minimum_amount");
        }
        set { this.Properties["minimum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Inclusive tier ending value
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
    /// Per unit maximum to charge
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
        _ = this.MinimumAmount;
        _ = this.MaximumAmount;
        _ = this.PerUnitMaximum;
    }

    public BPSTier() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BPSTier(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BPSTier FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
