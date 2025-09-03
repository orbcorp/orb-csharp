using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingGroupedWithMeteredMinimumPriceProperties.GroupedWithMeteredMinimumConfigProperties;

/// <summary>
/// Configuration for a scaling factor
/// </summary>
[JsonConverter(typeof(ModelConverter<ScalingFactor>))]
public sealed record class ScalingFactor : ModelBase, IFromRaw<ScalingFactor>
{
    /// <summary>
    /// Scaling factor
    /// </summary>
    public required string ScalingFactor1
    {
        get
        {
            if (!this.Properties.TryGetValue("scaling_factor", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "scaling_factor",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("scaling_factor");
        }
        set
        {
            this.Properties["scaling_factor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scaling value
    /// </summary>
    public required string ScalingValue
    {
        get
        {
            if (!this.Properties.TryGetValue("scaling_value", out JsonElement element))
                throw new ArgumentOutOfRangeException("scaling_value", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("scaling_value");
        }
        set
        {
            this.Properties["scaling_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ScalingFactor1;
        _ = this.ScalingValue;
    }

    public ScalingFactor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalingFactor(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ScalingFactor FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
