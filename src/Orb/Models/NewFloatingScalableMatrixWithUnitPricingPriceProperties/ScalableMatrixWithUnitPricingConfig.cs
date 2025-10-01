using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.NewFloatingScalableMatrixWithUnitPricingPriceProperties.ScalableMatrixWithUnitPricingConfigProperties;

namespace Orb.Models.NewFloatingScalableMatrixWithUnitPricingPriceProperties;

/// <summary>
/// Configuration for scalable_matrix_with_unit_pricing pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<ScalableMatrixWithUnitPricingConfig>))]
public sealed record class ScalableMatrixWithUnitPricingConfig
    : ModelBase,
        IFromRaw<ScalableMatrixWithUnitPricingConfig>
{
    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string FirstDimension
    {
        get
        {
            if (!this.Properties.TryGetValue("first_dimension", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'first_dimension' cannot be null",
                    new ArgumentOutOfRangeException("first_dimension", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'first_dimension' cannot be null",
                    new ArgumentNullException("first_dimension")
                );
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
    public required List<MatrixScalingFactor> MatrixScalingFactors
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_scaling_factors", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_scaling_factors' cannot be null",
                    new ArgumentOutOfRangeException(
                        "matrix_scaling_factors",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<MatrixScalingFactor>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'matrix_scaling_factors' cannot be null",
                    new ArgumentNullException("matrix_scaling_factors")
                );
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
    /// The final unit price to rate against the output of the matrix
    /// </summary>
    public required string UnitPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_price", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_price' cannot be null",
                    new ArgumentOutOfRangeException("unit_price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_price' cannot be null",
                    new ArgumentNullException("unit_price")
                );
        }
        set
        {
            this.Properties["unit_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, the unit price will be prorated to the billing period
    /// </summary>
    public bool? Prorate
    {
        get
        {
            if (!this.Properties.TryGetValue("prorate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["prorate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used to determine the unit rate (optional)
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
        _ = this.UnitPrice;
        _ = this.Prorate;
        _ = this.SecondDimension;
    }

    public ScalableMatrixWithUnitPricingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalableMatrixWithUnitPricingConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ScalableMatrixWithUnitPricingConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
