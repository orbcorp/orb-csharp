using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.NewFloatingMatrixWithDisplayNamePriceProperties.MatrixWithDisplayNameConfigProperties;

namespace Orb.Models.NewFloatingMatrixWithDisplayNamePriceProperties;

/// <summary>
/// Configuration for matrix_with_display_name pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixWithDisplayNameConfig>))]
public sealed record class MatrixWithDisplayNameConfig
    : ModelBase,
        IFromRaw<MatrixWithDisplayNameConfig>
{
    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string Dimension
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension' cannot be null",
                    new ArgumentOutOfRangeException("dimension", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension' cannot be null",
                    new ArgumentNullException("dimension")
                );
        }
        set
        {
            this.Properties["dimension"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply per unit pricing to each dimension value
    /// </summary>
    public required List<UnitAmount> UnitAmounts
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amounts' cannot be null",
                    new ArgumentOutOfRangeException("unit_amounts", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<UnitAmount>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'unit_amounts' cannot be null",
                    new ArgumentNullException("unit_amounts")
                );
        }
        set
        {
            this.Properties["unit_amounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Dimension;
        foreach (var item in this.UnitAmounts)
        {
            item.Validate();
        }
    }

    public MatrixWithDisplayNameConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithDisplayNameConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixWithDisplayNameConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
