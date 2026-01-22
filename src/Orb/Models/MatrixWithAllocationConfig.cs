using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for matrix pricing with usage allocation
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MatrixWithAllocationConfig, MatrixWithAllocationConfigFromRaw>)
)]
public sealed record class MatrixWithAllocationConfig : JsonModel
{
    /// <summary>
    /// Usage allocation
    /// </summary>
    public required string Allocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("allocation");
        }
        init { this._rawData.Set("allocation", value); }
    }

    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("default_unit_amount");
        }
        init { this._rawData.Set("default_unit_amount", value); }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required IReadOnlyList<string?> Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("dimensions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "dimensions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Matrix values configuration
    /// </summary>
    public required IReadOnlyList<MatrixWithAllocationConfigMatrixValue> MatrixValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<MatrixWithAllocationConfigMatrixValue>
            >("matrix_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MatrixWithAllocationConfigMatrixValue>>(
                "matrix_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
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
    public MatrixWithAllocationConfig(MatrixWithAllocationConfig matrixWithAllocationConfig)
        : base(matrixWithAllocationConfig) { }
#pragma warning restore CS8618

    public MatrixWithAllocationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithAllocationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatrixWithAllocationConfigFromRaw.FromRawUnchecked"/>
    public static MatrixWithAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixWithAllocationConfigFromRaw : IFromRawJson<MatrixWithAllocationConfig>
{
    /// <inheritdoc/>
    public MatrixWithAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatrixWithAllocationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single matrix value
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MatrixWithAllocationConfigMatrixValue,
        MatrixWithAllocationConfigMatrixValueFromRaw
    >)
)]
public sealed record class MatrixWithAllocationConfigMatrixValue : JsonModel
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("dimension_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "dimension_values",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.UnitAmount;
    }

    public MatrixWithAllocationConfigMatrixValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatrixWithAllocationConfigMatrixValue(
        MatrixWithAllocationConfigMatrixValue matrixWithAllocationConfigMatrixValue
    )
        : base(matrixWithAllocationConfigMatrixValue) { }
#pragma warning restore CS8618

    public MatrixWithAllocationConfigMatrixValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithAllocationConfigMatrixValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatrixWithAllocationConfigMatrixValueFromRaw.FromRawUnchecked"/>
    public static MatrixWithAllocationConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixWithAllocationConfigMatrixValueFromRaw
    : IFromRawJson<MatrixWithAllocationConfigMatrixValue>
{
    /// <inheritdoc/>
    public MatrixWithAllocationConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatrixWithAllocationConfigMatrixValue.FromRawUnchecked(rawData);
}
