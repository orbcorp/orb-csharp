using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Metrics;

[JsonConverter(typeof(JsonModelConverter<MetricListPageResponse, MetricListPageResponseFromRaw>))]
public sealed record class MetricListPageResponse : JsonModel
{
    public required IReadOnlyList<BillableMetric> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BillableMetric>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BillableMetric>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMetadata>("pagination_metadata");
        }
        init { this._rawData.Set("pagination_metadata", value); }
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

    public MetricListPageResponse() { }

    public MetricListPageResponse(MetricListPageResponse metricListPageResponse)
        : base(metricListPageResponse) { }

    public MetricListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricListPageResponseFromRaw.FromRawUnchecked"/>
    public static MetricListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricListPageResponseFromRaw : IFromRawJson<MetricListPageResponse>
{
    /// <inheritdoc/>
    public MetricListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MetricListPageResponse.FromRawUnchecked(rawData);
}
