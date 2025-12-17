using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for a single matrix value
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MatrixValue, MatrixValueFromRaw>))]
public sealed record class MatrixValue : JsonModel
{
    /// <summary>
    /// One or two matrix keys to filter usage to this Matrix value by
    /// </summary>
    public required IReadOnlyList<string?> DimensionValues
    {
        get { return JsonModel.GetNotNullClass<List<string?>>(this.RawData, "dimension_values"); }
        init { JsonModel.Set(this._rawData, "dimension_values", value); }
    }

    /// <summary>
    /// Unit price for the specified dimension_values
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.UnitAmount;
    }

    public MatrixValue() { }

    public MatrixValue(MatrixValue matrixValue)
        : base(matrixValue) { }

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

    /// <inheritdoc cref="MatrixValueFromRaw.FromRawUnchecked"/>
    public static MatrixValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixValueFromRaw : IFromRawJson<MatrixValue>
{
    /// <inheritdoc/>
    public MatrixValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatrixValue.FromRawUnchecked(rawData);
}
