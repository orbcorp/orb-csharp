using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BulkBPSTier>))]
public sealed record class BulkBPSTier : ModelBase, IFromRaw<BulkBPSTier>
{
    /// <summary>
    /// Basis points to rate on
    /// </summary>
    public required double BPS
    {
        get
        {
            if (!this.Properties.TryGetValue("bps", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("bps", "Missing required argument");

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["bps"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Upper bound for tier
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum amount to charge for any one event
    /// </summary>
    public string? PerUnitMaximum
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_maximum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["per_unit_maximum"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.BPS;
        _ = this.MaximumAmount;
        _ = this.PerUnitMaximum;
    }

    public BulkBPSTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkBPSTier(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkBPSTier FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public BulkBPSTier(double bps)
    {
        this.BPS = bps;
    }
}
