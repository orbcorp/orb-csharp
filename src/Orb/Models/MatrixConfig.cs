using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

/// <summary>
/// Configuration for matrix pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixConfig>))]
public sealed record class MatrixConfig : ModelBase, IFromRaw<MatrixConfig>
{
    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("default_unit_amount", out JsonElement element))
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
        init
        {
            this._properties["default_unit_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("dimensions", out JsonElement element))
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
        init
        {
            this._properties["dimensions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Matrix values configuration
    /// </summary>
    public required List<MatrixValue> MatrixValues
    {
        get
        {
            if (!this._properties.TryGetValue("matrix_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_values' cannot be null",
                    new ArgumentOutOfRangeException("matrix_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<MatrixValue>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'matrix_values' cannot be null",
                    new ArgumentNullException("matrix_values")
                );
        }
        init
        {
            this._properties["matrix_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.DefaultUnitAmount;
        _ = this.Dimensions;
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
    }

    public MatrixConfig() { }

    public MatrixConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MatrixConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
