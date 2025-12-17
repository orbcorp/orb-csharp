using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<BillableMetric>>(this.RawData, "data"); }
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

    public MetricListPageResponse() { }

    public MetricListPageResponse(MetricListPageResponse metricListPageResponse)
        : base(metricListPageResponse) { }

    public MetricListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
