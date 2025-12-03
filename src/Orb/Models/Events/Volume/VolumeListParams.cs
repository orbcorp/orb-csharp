using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Events.Volume;

/// <summary>
/// This endpoint returns the event volume for an account in a [paginated list format](/api-reference/pagination).
///
/// <para>The event volume is aggregated by the hour and the [timestamp](/api-reference/event/ingest-events)
/// field is used to determine which hour an event is associated with. Note, this
/// means that late-arriving events increment the volume count for the hour window
/// the timestamp is in, not the latest hour window.</para>
///
/// <para>Each item in the response contains the count of events aggregated by the
/// hour where the start and end time are hour-aligned and in UTC. When a specific
/// timestamp is passed in for either start or end time, the response includes the
/// hours the timestamp falls in.</para>
/// </summary>
public sealed record class VolumeListParams : ParamsBase
{
    /// <summary>
    /// The start of the timeframe, inclusive, in which to return event volume. All
    /// datetime values are converted to UTC time. If the specified time isn't hour-aligned,
    /// the response includes the event volume count for the hour the time falls in.
    /// </summary>
    public required DateTimeOffset TimeframeStart
    {
        get
        {
            return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawQueryData, "timeframe_start");
        }
        init { ModelBase.Set(this._rawQueryData, "timeframe_start", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { ModelBase.Set(this._rawQueryData, "cursor", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    /// <summary>
    /// The end of the timeframe, exclusive, in which to return event volume. If not
    /// specified, the current time is used. All datetime values are converted to
    /// UTC time.If the specified time isn't hour-aligned, the response includes
    /// the event volumecount for the hour the time falls in.
    /// </summary>
    public DateTimeOffset? TimeframeEnd
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "timeframe_end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "timeframe_end", value);
        }
    }

    public VolumeListParams() { }

    public VolumeListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VolumeListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static VolumeListParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/events/volume")
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
