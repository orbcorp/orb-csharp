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
/// Configuration for matrix pricing with usage allocation
/// </summary>
[JsonConverter(
    typeof(ModelConverter<MatrixWithAllocationConfig, MatrixWithAllocationConfigFromRaw>)
)]
public sealed record class MatrixWithAllocationConfig : ModelBase
{
    /// <summary>
    /// Usage allocation
    /// </summary>
    public required string Allocation
    {
        get
        {
            if (!this._rawData.TryGetValue("allocation", out JsonElement element))
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
        init
        {
            this._rawData["allocation"] = JsonSerializer.SerializeToElement(
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
    public required IReadOnlyList<MatrixValue> MatrixValues
    {
        get
        {
            if (!this._rawData.TryGetValue("matrix_values", out JsonElement element))
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
            this._rawData["matrix_values"] = JsonSerializer.SerializeToElement(
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

    public MatrixWithAllocationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithAllocationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MatrixWithAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixWithAllocationConfigFromRaw : IFromRaw<MatrixWithAllocationConfig>
{
    public MatrixWithAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatrixWithAllocationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single matrix value
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixValue, MatrixValueFromRaw>))]
public sealed record class MatrixValue : ModelBase
{
    /// <summary>
    /// One or two matrix keys to filter usage to this Matrix value by. For example,
    /// ["region", "tier"] could be used to filter cloud usage by a cloud region
    /// and an instance tier.
    /// </summary>
    public required IReadOnlyList<string?> DimensionValues
    {
        get
        {
            if (!this._rawData.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new ArgumentOutOfRangeException("dimension_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string?>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new ArgumentNullException("dimension_values")
                );
        }
        init
        {
            this._rawData["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unit price for the specified dimension_values
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentOutOfRangeException("unit_amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.UnitAmount;
    }

    public MatrixValue() { }

    public MatrixValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MatrixValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixValueFromRaw : IFromRaw<MatrixValue>
{
    public MatrixValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatrixValue.FromRawUnchecked(rawData);
}
