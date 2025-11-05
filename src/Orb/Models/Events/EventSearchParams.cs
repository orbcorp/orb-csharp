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
/// Note that this is a `POST` endpoint rather than a `GET` endpoint because it employs
/// a JSON body for search criteria rather than query parameters, allowing for a more
/// flexible search syntax.
///
/// Note that a search criteria _must_ be specified. Currently, Orb supports the following
/// criteria: - `event_ids`: This is an explicit array of IDs to filter by. Note
/// that an event's ID is the `idempotency_key` that   was originally used for ingestion.
///
/// By default, Orb will not throw a `404` if no events matched, Orb will return
/// an empty array for `data` instead.
/// </summary>
public sealed record class EventSearchParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// This is an explicit array of IDs to filter by. Note that an event's ID is
    /// the idempotency_key that was originally used for ingestion, and this only
    /// supports events that have not been amended. Values in this array will be treated
    /// case sensitively.
    /// </summary>
    public required List<string> EventIDs
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("event_ids", out JsonElement element))
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
            this._bodyProperties["event_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to search events. If not specified,
    /// the current time is used.
    /// </summary>
    public DateTime? TimeframeEnd
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("timeframe_end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start of the timeframe, inclusive, in which to search events. If not
    /// specified, the one week ago is used.
    /// </summary>
    public DateTime? TimeframeStart
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("timeframe_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EventSearchParams() { }

    public EventSearchParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSearchParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static EventSearchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/search")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
