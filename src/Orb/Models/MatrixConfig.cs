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
[JsonConverter(typeof(ModelConverter<MatrixConfig, MatrixConfigFromRaw>))]
public sealed record class MatrixConfig : ModelBase
{
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
    public required IReadOnlyList<SharedMatrixValue> MatrixValues
    {
        get
        {
            return ModelBase.GetNotNullClass<List<SharedMatrixValue>>(
                this.RawData,
                "matrix_values"
            );
        }
        init { ModelBase.Set(this._rawData, "matrix_values", value); }
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
