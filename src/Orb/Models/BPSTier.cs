using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BPSTier>))]
public sealed record class BPSTier : ModelBase, IFromRaw<BPSTier>
{
    /// <summary>
    /// Per-event basis point rate
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
    /// Exclusive tier starting value
    /// </summary>
    public required string MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("minimum_amount");
        }
        set { this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Inclusive tier ending value
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
    /// Per unit maximum to charge
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
        _ = this.MinimumAmount;
        _ = this.MaximumAmount;
        _ = this.PerUnitMaximum;
    }

    public BPSTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BPSTier(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BPSTier FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
