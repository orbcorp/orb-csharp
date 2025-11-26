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
[JsonConverter(typeof(ModelConverter<MatrixConfig, MatrixConfigFromRaw>))]
public sealed record class MatrixConfig : ModelBase
{
    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("default_unit_amount", out JsonElement element))
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
            this._rawData["default_unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required IReadOnlyList<string?> Dimensions
    {
        get
        {
            if (!this._rawData.TryGetValue("dimensions", out JsonElement element))
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
            this._rawData["dimensions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Matrix values configuration
    /// </summary>
    public required IReadOnlyList<SharedMatrixValue> MatrixValues
    {
        get
        {
            if (!this._rawData.TryGetValue("matrix_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_values' cannot be null",
                    new ArgumentOutOfRangeException("matrix_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<SharedMatrixValue>>(
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
            this._rawData["matrix_values"] = JsonSerializer.SerializeToElement(
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

    public MatrixConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MatrixConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixConfigFromRaw : IFromRaw<MatrixConfig>
{
    public MatrixConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatrixConfig.FromRawUnchecked(rawData);
}
