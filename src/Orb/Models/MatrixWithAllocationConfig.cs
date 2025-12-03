using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

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
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "allocation"); }
        init { ModelBase.Set(this._rawData, "allocation", value); }
    }

    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "default_unit_amount"); }
        init { ModelBase.Set(this._rawData, "default_unit_amount", value); }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required IReadOnlyList<string?> Dimensions
    {
        get { return ModelBase.GetNotNullClass<List<string?>>(this.RawData, "dimensions"); }
        init { ModelBase.Set(this._rawData, "dimensions", value); }
    }

    /// <summary>
    /// Matrix values configuration
    /// </summary>
    public required IReadOnlyList<MatrixWithAllocationConfigMatrixValue> MatrixValues
    {
        get
        {
            return ModelBase.GetNotNullClass<List<MatrixWithAllocationConfigMatrixValue>>(
                this.RawData,
                "matrix_values"
            );
        }
        init { ModelBase.Set(this._rawData, "matrix_values", value); }
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

    public MatrixWithAllocationConfig(MatrixWithAllocationConfig matrixWithAllocationConfig)
        : base(matrixWithAllocationConfig) { }

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

    /// <inheritdoc cref="MatrixWithAllocationConfigFromRaw.FromRawUnchecked"/>
    public static MatrixWithAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixWithAllocationConfigFromRaw : IFromRaw<MatrixWithAllocationConfig>
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
    typeof(ModelConverter<
        MatrixWithAllocationConfigMatrixValue,
        MatrixWithAllocationConfigMatrixValueFromRaw
    >)
)]
public sealed record class MatrixWithAllocationConfigMatrixValue : ModelBase
{
    /// <summary>
    /// One or two matrix keys to filter usage to this Matrix value by. For example,
    /// ["region", "tier"] could be used to filter cloud usage by a cloud region
    /// and an instance tier.
    /// </summary>
    public required IReadOnlyList<string?> DimensionValues
    {
        get { return ModelBase.GetNotNullClass<List<string?>>(this.RawData, "dimension_values"); }
        init { ModelBase.Set(this._rawData, "dimension_values", value); }
    }

    /// <summary>
    /// Unit price for the specified dimension_values
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.UnitAmount;
    }

    public MatrixWithAllocationConfigMatrixValue() { }

    public MatrixWithAllocationConfigMatrixValue(
        MatrixWithAllocationConfigMatrixValue matrixWithAllocationConfigMatrixValue
    )
        : base(matrixWithAllocationConfigMatrixValue) { }

    public MatrixWithAllocationConfigMatrixValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithAllocationConfigMatrixValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class MatrixWithAllocationConfigMatrixValueFromRaw : IFromRaw<MatrixWithAllocationConfigMatrixValue>
{
    /// <inheritdoc/>
    public MatrixWithAllocationConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatrixWithAllocationConfigMatrixValue.FromRawUnchecked(rawData);
}
