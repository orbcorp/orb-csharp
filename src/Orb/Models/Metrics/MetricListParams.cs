using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Metrics;

/// <summary>
/// This endpoint is used to fetch [metric](/core-concepts##metric) details given
/// a metric identifier. It returns information about the metrics including its name,
/// description, and item.
/// </summary>
public sealed record class MetricListParams : ParamsBase
{
    public DateTimeOffset? CreatedAtGt
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[gt]"); }
        init { this._rawQueryData.Set("created_at[gt]", value); }
    }

    public DateTimeOffset? CreatedAtGte
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[gte]"); }
        init { this._rawQueryData.Set("created_at[gte]", value); }
    }

    public DateTimeOffset? CreatedAtLt
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[lt]"); }
        init { this._rawQueryData.Set("created_at[lt]", value); }
    }

    public DateTimeOffset? CreatedAtLte
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[lte]"); }
        init { this._rawQueryData.Set("created_at[lte]", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return this._rawQueryData.GetNullableClass<string>("cursor"); }
        init { this._rawQueryData.Set("cursor", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return this._rawQueryData.GetNullableStruct<long>("limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public MetricListParams() { }

    public MetricListParams(MetricListParams metricListParams)
        : base(metricListParams) { }

    public MetricListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static MetricListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/metrics")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
