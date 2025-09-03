using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanScalableMatrixWithTieredPricingPriceProperties.ScalableMatrixWithTieredPricingConfigProperties;

/// <summary>
/// Configuration for a single matrix scaling factor
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixScalingFactor>))]
public sealed record class MatrixScalingFactor : ModelBase, IFromRaw<MatrixScalingFactor>
{
    /// <summary>
    /// First dimension value
    /// </summary>
    public required string FirstDimensionValue
    {
        get
        {
            if (!this.Properties.TryGetValue("first_dimension_value", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "first_dimension_value",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("first_dimension_value");
        }
        set
        {
            this.Properties["first_dimension_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scaling factor
    /// </summary>
    public required string ScalingFactor
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
    /// Second dimension value (optional)
    /// </summary>
    public string? SecondDimensionValue
    {
        get
        {
            if (!this.Properties.TryGetValue("second_dimension_value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["second_dimension_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FirstDimensionValue;
        _ = this.ScalingFactor;
        _ = this.SecondDimensionValue;
    }

    public MatrixScalingFactor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixScalingFactor(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixScalingFactor FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
