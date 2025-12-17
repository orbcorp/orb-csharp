using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.DimensionalPriceGroups;

/// <summary>
/// A dimensional price group is used to partition the result of a billable metric
/// by a set of dimensions. Prices in a price group must specify the parition used
/// to derive their usage.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DimensionalPriceGroup, DimensionalPriceGroupFromRaw>))]
public sealed record class DimensionalPriceGroup : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The billable metric associated with this dimensional price group. All prices
    /// associated with this dimensional price group will be computed using this
    /// billable metric.
    /// </summary>
    public required string BillableMetricID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// The dimensions that this dimensional price group is defined over
    /// </summary>
    public required IReadOnlyList<string> Dimensions
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "dimensions"); }
        init { JsonModel.Set(this._rawData, "dimensions", value); }
    }

    /// <summary>
    /// An alias for the dimensional price group
    /// </summary>
    public required string? ExternalDimensionalPriceGroupID
    {
        get
        {
            return JsonModel.GetNullableClass<string>(
                this.RawData,
                "external_dimensional_price_group_id"
            );
        }
        init { JsonModel.Set(this._rawData, "external_dimensional_price_group_id", value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// The name of the dimensional price group
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BillableMetricID;
        _ = this.Dimensions;
        _ = this.ExternalDimensionalPriceGroupID;
        _ = this.Metadata;
        _ = this.Name;
    }

    public DimensionalPriceGroup() { }

    public DimensionalPriceGroup(DimensionalPriceGroup dimensionalPriceGroup)
        : base(dimensionalPriceGroup) { }

    public DimensionalPriceGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DimensionalPriceGroupFromRaw.FromRawUnchecked"/>
    public static DimensionalPriceGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionalPriceGroupFromRaw : IFromRawJson<DimensionalPriceGroup>
{
    /// <inheritdoc/>
    public DimensionalPriceGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DimensionalPriceGroup.FromRawUnchecked(rawData);
}
