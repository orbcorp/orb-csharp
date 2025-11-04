using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using MatrixWithAllocationConfigProperties = Orb.Models.MatrixWithAllocationConfigProperties;

namespace Orb.Models;

/// <summary>
/// Configuration for matrix pricing with usage allocation
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixWithAllocationConfig>))]
public sealed record class MatrixWithAllocationConfig
    : ModelBase,
        IFromRaw<MatrixWithAllocationConfig>
{
    /// <summary>
    /// Usage allocation
    /// </summary>
    public required string Allocation
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new ArgumentOutOfRangeException("allocation", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new ArgumentNullException("allocation")
                );
        }
        set
        {
            this.Properties["allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("default_unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'default_unit_amount' cannot be null",
                    new ArgumentOutOfRangeException(
                        "default_unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'default_unit_amount' cannot be null",
                    new ArgumentNullException("default_unit_amount")
                );
        }
        set
        {
            this.Properties["default_unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required List<string?> Dimensions
    {
        get
        {
            if (!this.Properties.TryGetValue("dimensions", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimensions' cannot be null",
                    new ArgumentOutOfRangeException("dimensions", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string?>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimensions' cannot be null",
                    new ArgumentNullException("dimensions")
                );
        }
        set
        {
            this.Properties["dimensions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Matrix values configuration
    /// </summary>
    public required List<MatrixWithAllocationConfigProperties::MatrixValue> MatrixValues
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_values' cannot be null",
                    new ArgumentOutOfRangeException("matrix_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    List<MatrixWithAllocationConfigProperties::MatrixValue>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'matrix_values' cannot be null",
                    new ArgumentNullException("matrix_values")
                );
        }
        set
        {
            this.Properties["matrix_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Allocation;
        _ = this.DefaultUnitAmount;
        _ = this.Dimensions;
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
    }

    public MatrixWithAllocationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithAllocationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixWithAllocationConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
