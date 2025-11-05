using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

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
            if (!this._properties.TryGetValue("allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new System::ArgumentNullException("allocation")
                );
        }
        init
        {
            this._properties["allocation"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("default_unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'default_unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "default_unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'default_unit_amount' cannot be null",
                    new System::ArgumentNullException("default_unit_amount")
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
                    new System::ArgumentOutOfRangeException(
                        "dimensions",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string?>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimensions' cannot be null",
                    new System::ArgumentNullException("dimensions")
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
    public required List<MatrixValueModel> MatrixValues
    {
        get
        {
            if (!this._properties.TryGetValue("matrix_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_values' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "matrix_values",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<MatrixValueModel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'matrix_values' cannot be null",
                    new System::ArgumentNullException("matrix_values")
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
        _ = this.Allocation;
        _ = this.DefaultUnitAmount;
        _ = this.Dimensions;
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
    }

    public MatrixWithAllocationConfig() { }

    public MatrixWithAllocationConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithAllocationConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MatrixWithAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single matrix value
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixValueModel>))]
public sealed record class MatrixValueModel : ModelBase, IFromRaw<MatrixValueModel>
{
    /// <summary>
    /// One or two matrix keys to filter usage to this Matrix value by. For example,
    /// ["region", "tier"] could be used to filter cloud usage by a cloud region and
    /// an instance tier.
    /// </summary>
    public required List<string?> DimensionValues
    {
        get
        {
            if (!this._properties.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dimension_values",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string?>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentNullException("dimension_values")
                );
        }
        init
        {
            this._properties["dimension_values"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
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

    public MatrixValueModel() { }

    public MatrixValueModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixValueModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MatrixValueModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
