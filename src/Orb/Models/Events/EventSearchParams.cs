using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;

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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
    public required List<string> EventIDs
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("event_ids", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_ids' cannot be null",
                    new ArgumentOutOfRangeException("event_ids", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'event_ids' cannot be null",
                    new ArgumentNullException("event_ids")
                );
        }
        init
        {
            this._rawBodyData["event_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to search events. If not specified,
    /// the current time is used.
    /// </summary>
    public DateTimeOffset? TimeframeEnd
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("timeframe_end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start of the timeframe, inclusive, in which to search events. If not specified,
    /// the one week ago is used.
    /// </summary>
    public DateTimeOffset? TimeframeStart
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("timeframe_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EventSearchParams() { }

    public EventSearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
