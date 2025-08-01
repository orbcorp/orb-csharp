using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BPSConfig>))]
public sealed record class BPSConfig : ModelBase, IFromRaw<BPSConfig>
{
    /// <summary>
    /// Basis point take rate per event
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
    /// Optional currency amount maximum to cap spend per event
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
        _ = this.PerUnitMaximum;
    }

    public BPSConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BPSConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BPSConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public BPSConfig(double bps)
    {
        this.BPS = bps;
    }
}
