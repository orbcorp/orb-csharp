using System;
using System.Net.Http;
using System.Text.Json;

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
public sealed record class VolumeListParams : ParamsBase
{
    /// <summary>
    /// The start of the timeframe, inclusive, in which to return event volume. All
    /// datetime values are converted to UTC time. If the specified time isn't hour-aligned,
    /// the response includes the event volume count for the hour the time falls in.
    /// </summary>
    public required DateTime TimeframeStart
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("timeframe_start", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime>(element);
        }
        set { this.QueryProperties["timeframe_start"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to return event volume. If not
    /// specified, the current time is used. All datetime values are converted to UTC
    /// time.If the specified time isn't hour-aligned, the response includes the event
    /// volumecount for the hour the time falls in.
    /// </summary>
    public DateTime? TimeframeEnd
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("timeframe_end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element);
        }
        set { this.QueryProperties["timeframe_end"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/volume")
        {
            Query = this.QueryString(client),
        }.Uri;
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
