using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;

namespace Orb.Models.Events.Volume;

/// <summary>
/// This endpoint returns the event volume for an account in a [paginated list format](/api-reference/pagination).
///
/// The event volume is aggregated by the hour and the [timestamp](/api-reference/event/ingest-events)
/// field is used to determine which hour an event is associated with. Note, this
/// means that late-arriving events increment the volume count for the hour window
/// the timestamp is in, not the latest hour window.
///
/// Each item in the response contains the count of events aggregated by the hour
/// where the start and end time are hour-aligned and in UTC. When a specific timestamp
/// is passed in for either start or end time, the response includes the hours the
/// timestamp falls in.
/// </summary>
public sealed record class VolumeListParams : Orb::ParamsBase
{
    /// <summary>
    /// The start of the timeframe, inclusive, in which to return event volume. All
    /// datetime values are converted to UTC time. If the specified time isn't hour-aligned,
    /// the response includes the event volume count for the hour the time falls in.
    /// </summary>
    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("timeframe_start", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set
        {
            this.QueryProperties["timeframe_start"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to return event volume. If not
    /// specified, the current time is used. All datetime values are converted to UTC
    /// time.If the specified time isn't hour-aligned, the response includes the event
    /// volumecount for the hour the time falls in.
    /// </summary>
    public System::DateTime? TimeframeEnd
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("timeframe_end", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["timeframe_end"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/volume")
        {
            Query = this.QueryString(client),
        }.Uri;
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
