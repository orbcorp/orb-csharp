using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ScalableMatrixWithTieredPricingConfigProperties = Orb.Models.Subscriptions.NewSubscriptionScalableMatrixWithTieredPricingPriceProperties.ScalableMatrixWithTieredPricingConfigProperties;

namespace Orb.Models.Subscriptions.NewSubscriptionScalableMatrixWithTieredPricingPriceProperties;

/// <summary>
/// Configuration for scalable_matrix_with_tiered_pricing pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<ScalableMatrixWithTieredPricingConfig>))]
public sealed record class ScalableMatrixWithTieredPricingConfig
    : ModelBase,
        IFromRaw<ScalableMatrixWithTieredPricingConfig>
{
    /// <summary>
    /// Used for the scalable matrix first dimension
    /// </summary>
    public required string FirstDimension
    {
        get
        {
            if (!this.Properties.TryGetValue("first_dimension", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "first_dimension",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("first_dimension");
        }
        set
        {
            this.Properties["first_dimension"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply a scaling factor to each dimension
    /// </summary>
    public required List<ScalableMatrixWithTieredPricingConfigProperties::MatrixScalingFactor> MatrixScalingFactors
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_scaling_factors", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "matrix_scaling_factors",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<
                    List<ScalableMatrixWithTieredPricingConfigProperties::MatrixScalingFactor>
                >(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("matrix_scaling_factors");
        }
        set
        {
            this.Properties["matrix_scaling_factors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tier pricing structure
    /// </summary>
    public required List<ScalableMatrixWithTieredPricingConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<
                    List<ScalableMatrixWithTieredPricingConfigProperties::Tier>
                >(element, ModelBase.SerializerOptions) ?? throw new ArgumentNullException("tiers");
        }
        set
        {
            this.Properties["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used for the scalable matrix second dimension (optional)
    /// </summary>
    public string? SecondDimension
    {
        get
        {
            if (!this.Properties.TryGetValue("second_dimension", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["second_dimension"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FirstDimension;
        foreach (var item in this.MatrixScalingFactors)
        {
            item.Validate();
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
        _ = this.SecondDimension;
    }

    public ScalableMatrixWithTieredPricingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalableMatrixWithTieredPricingConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ScalableMatrixWithTieredPricingConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
