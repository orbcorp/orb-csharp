using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.DimensionalPriceGroups;

/// <summary>
/// A dimensional price group is used to partition the result of a billable metric
/// by a set of dimensions. Prices in a price group must specify the parition used
/// to derive their usage.
/// </summary>
[JsonConverter(typeof(ModelConverter<DimensionalPriceGroup, DimensionalPriceGroupFromRaw>))]
public sealed record class DimensionalPriceGroup : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'billable_metric_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "billable_metric_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'billable_metric_id' cannot be null",
                    new ArgumentNullException("billable_metric_id")
                );
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The dimensions that this dimensional price group is defined over
    /// </summary>
    public required List<string> Dimensions
    {
        get
        {
            if (!this._rawData.TryGetValue("dimensions", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimensions' cannot be null",
                    new ArgumentOutOfRangeException("dimensions", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
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
    /// An alias for the dimensional price group
    /// </summary>
    public required string? ExternalDimensionalPriceGroupID
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "external_dimensional_price_group_id",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_dimensional_price_group_id"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static DimensionalPriceGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionalPriceGroupFromRaw : IFromRaw<DimensionalPriceGroup>
{
    public DimensionalPriceGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DimensionalPriceGroup.FromRawUnchecked(rawData);
}
