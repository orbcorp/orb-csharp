using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.DimensionalPriceGroups;

[JsonConverter(
    typeof(JsonModelConverter<
        DimensionalPriceGroupDimensionalPriceGroups,
        DimensionalPriceGroupDimensionalPriceGroupsFromRaw
    >)
)]
public sealed record class DimensionalPriceGroupDimensionalPriceGroups : JsonModel
{
    public required IReadOnlyList<DimensionalPriceGroup> Data
    {
        get { return JsonModel.GetNotNullClass<List<DimensionalPriceGroup>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return JsonModel.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public DimensionalPriceGroupDimensionalPriceGroups() { }

    public DimensionalPriceGroupDimensionalPriceGroups(
        DimensionalPriceGroupDimensionalPriceGroups dimensionalPriceGroupDimensionalPriceGroups
    )
        : base(dimensionalPriceGroupDimensionalPriceGroups) { }

    public DimensionalPriceGroupDimensionalPriceGroups(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceGroupDimensionalPriceGroups(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DimensionalPriceGroupDimensionalPriceGroupsFromRaw.FromRawUnchecked"/>
    public static DimensionalPriceGroupDimensionalPriceGroups FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionalPriceGroupDimensionalPriceGroupsFromRaw
    : IFromRawJson<DimensionalPriceGroupDimensionalPriceGroups>
{
    /// <inheritdoc/>
    public DimensionalPriceGroupDimensionalPriceGroups FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DimensionalPriceGroupDimensionalPriceGroups.FromRawUnchecked(rawData);
}
