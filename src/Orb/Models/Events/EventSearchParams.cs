using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

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
public sealed record class EventSearchParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// This is an explicit array of IDs to filter by. Note that an event's ID is the
    /// idempotency_key that was originally used for ingestion, and this only supports
    /// events that have not been amended. Values in this array will be treated case sensitively.
    /// </summary>
    public required Generic::List<string> EventIDs
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("event_ids", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "event_ids",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("event_ids");
        }
        set { this.BodyProperties["event_ids"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to search events. If not specified,
    /// the current time is used.
    /// </summary>
    public System::DateTime? TimeframeEnd
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_end", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.BodyProperties["timeframe_end"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The start of the timeframe, inclusive, in which to search events. If not specified,
    /// the one week ago is used.
    /// </summary>
    public System::DateTime? TimeframeStart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_start", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.BodyProperties["timeframe_start"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/search")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new Http::StringContent(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
