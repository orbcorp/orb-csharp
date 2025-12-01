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
[JsonConverter(typeof(ModelConverter<SharedMatrixValue, SharedMatrixValueFromRaw>))]
public sealed record class SharedMatrixValue : ModelBase
{
    /// <summary>
    /// One or two matrix keys to filter usage to this Matrix value by
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

    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.UnitAmount;
    }

    public SharedMatrixValue() { }

    public SharedMatrixValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedMatrixValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SharedMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedMatrixValueFromRaw : IFromRaw<SharedMatrixValue>
{
    public SharedMatrixValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SharedMatrixValue.FromRawUnchecked(rawData);
}
