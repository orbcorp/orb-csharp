using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Events;

/// <summary>
/// This endpoint returns a filtered set of events for an account in a [paginated
/// list format](/api-reference/pagination).
///
/// <para>Note that this is a `POST` endpoint rather than a `GET` endpoint because
/// it employs a JSON body for search criteria rather than query parameters, allowing
/// for a more flexible search syntax.</para>
///
/// <para>Note that a search criteria _must_ be specified. Currently, Orb supports
/// the following criteria: - `event_ids`: This is an explicit array of IDs to filter
/// by. Note that an event's ID is the `idempotency_key` that   was originally used
/// for ingestion.</para>
///
/// <para>By default, Orb will not throw a `404` if no events matched, Orb will return
/// an empty array for `data` instead.</para>
/// </summary>
public sealed record class EventSearchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// This is an explicit array of IDs to filter by. Note that an event's ID is
    /// the idempotency_key that was originally used for ingestion, and this only
    /// supports events that have not been amended. Values in this array will be
    /// treated case sensitively.
    /// </summary>
    public required IReadOnlyList<string> EventIds
    {
        get { return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>("event_ids"); }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "event_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to search events. If not specified,
    /// the current time is used.
    /// </summary>
    public DateTimeOffset? TimeframeEnd
    {
        get { return this._rawBodyData.GetNullableStruct<DateTimeOffset>("timeframe_end"); }
        init { this._rawBodyData.Set("timeframe_end", value); }
    }

    /// <summary>
    /// The start of the timeframe, inclusive, in which to search events. If not specified,
    /// the one week ago is used.
    /// </summary>
    public DateTimeOffset? TimeframeStart
    {
        get { return this._rawBodyData.GetNullableStruct<DateTimeOffset>("timeframe_start"); }
        init { this._rawBodyData.Set("timeframe_start", value); }
    }

    public EventSearchParams() { }

    public EventSearchParams(EventSearchParams eventSearchParams)
        : base(eventSearchParams)
    {
        this._rawBodyData = new(eventSearchParams._rawBodyData);
    }

    public EventSearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static EventSearchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/events/search")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
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
