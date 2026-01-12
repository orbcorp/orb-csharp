using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The billable metric associated with this dimensional price group. All prices
    /// associated with this dimensional price group will be computed using this
    /// billable metric.
    /// </summary>
    public required string BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// The dimensions that this dimensional price group is defined over
    /// </summary>
    public required IReadOnlyList<string> Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("dimensions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "dimensions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An alias for the dimensional price group
    /// </summary>
    public required string? ExternalDimensionalPriceGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_dimensional_price_group_id");
        }
        init { this._rawData.Set("external_dimensional_price_group_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The name of the dimensional price group
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
