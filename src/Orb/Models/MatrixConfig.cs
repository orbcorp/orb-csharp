using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for matrix pricing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MatrixConfig, MatrixConfigFromRaw>))]
public sealed record class MatrixConfig : JsonModel
{
    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "default_unit_amount"); }
        init { JsonModel.Set(this._rawData, "default_unit_amount", value); }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required IReadOnlyList<string?> Dimensions
    {
        get { return JsonModel.GetNotNullClass<List<string?>>(this.RawData, "dimensions"); }
        init { JsonModel.Set(this._rawData, "dimensions", value); }
    }

    /// <summary>
    /// Matrix values configuration
    /// </summary>
    public required IReadOnlyList<MatrixValue> MatrixValues
    {
        get { return JsonModel.GetNotNullClass<List<MatrixValue>>(this.RawData, "matrix_values"); }
        init { JsonModel.Set(this._rawData, "matrix_values", value); }
    }

    /// <inheritdoc/>
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

    public MatrixConfig(MatrixConfig matrixConfig)
        : base(matrixConfig) { }

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

    /// <inheritdoc cref="MatrixConfigFromRaw.FromRawUnchecked"/>
    public static MatrixConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixConfigFromRaw : IFromRawJson<MatrixConfig>
{
    /// <inheritdoc/>
    public MatrixConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatrixConfig.FromRawUnchecked(rawData);
}
