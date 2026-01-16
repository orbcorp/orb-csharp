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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VolumeListParams : ParamsBase
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<DateTimeOffset>("timeframe_start");
        }
        init { this._rawQueryData.Set("timeframe_start", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init { this._rawQueryData.Set("cursor", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
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
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("timeframe_end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("timeframe_end", value);
        }
    }

    public VolumeListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VolumeListParams(VolumeListParams volumeListParams)
        : base(volumeListParams) { }
#pragma warning restore CS8618

    public VolumeListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VolumeListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VolumeListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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

    public override int GetHashCode()
    {
        return 0;
    }
}
