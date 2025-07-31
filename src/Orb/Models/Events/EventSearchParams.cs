using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// This is an explicit array of IDs to filter by. Note that an event's ID is the
    /// idempotency_key that was originally used for ingestion, and this only supports
    /// events that have not been amended. Values in this array will be treated case sensitively.
    /// </summary>
    public required List<string> EventIDs
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("event_ids", out JsonElement element))
                throw new ArgumentOutOfRangeException("event_ids", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("event_ids");
        }
        set { this.BodyProperties["event_ids"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to search events. If not specified,
    /// the current time is used.
    /// </summary>
    public DateTime? TimeframeEnd
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["timeframe_end"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The start of the timeframe, inclusive, in which to search events. If not specified,
    /// the one week ago is used.
    /// </summary>
    public DateTime? TimeframeStart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["timeframe_start"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/search")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
