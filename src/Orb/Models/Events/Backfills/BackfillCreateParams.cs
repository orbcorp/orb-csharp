using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// Creating the backfill enables adding or replacing past events, even those that
/// are older than the ingestion grace period. Performing a backfill in Orb involves
/// 3 steps:
///
/// <para>1. Create the backfill, specifying its parameters. 2. [Ingest](ingest) usage
/// events, referencing the backfill (query parameter `backfill_id`). 3. [Close](close-backfill)
/// the backfill, propagating the update in past usage throughout Orb.</para>
///
/// <para>Changes from a backfill are not reflected until the backfill is closed,
/// so you won’t need to worry about your customers seeing partially updated usage
/// data. Backfills are also reversible, so you’ll be able to revert a backfill if
/// you’ve made a mistake.</para>
///
/// <para>This endpoint will return a backfill object, which contains an `id`. That
/// `id` can then be used as the `backfill_id` query parameter to the event ingestion
/// endpoint to associate ingested events with this backfill. The effects (e.g. updated
/// usage graphs) of this backfill will not take place until the backfill is closed.</para>
///
/// <para>If the `replace_existing_events` is `true`, existing events in the backfill's
/// timeframe will be replaced with the newly ingested events associated with the
/// backfill. If `false`, newly ingested events will be added to the existing events.</para>
///
/// <para>If a `customer_id` or `external_customer_id` is specified, the backfill
/// will only affect events for that customer. If neither is specified, the backfill
/// will affect all customers.</para>
///
/// <para>When `replace_existing_events` is `true`, this indicates that existing
/// events in the timeframe should no longer be counted towards invoiced usage. In
/// this scenario, the parameter `deprecation_filter` can be optionally added which
/// enables filtering using [computed properties](/extensibility/advanced-metrics#computed-properties).
/// The expressiveness of computed properties allows you to deprecate existing events
/// based on both a period of time and specific property values.</para>
///
/// <para>You may not have multiple backfills in a pending or pending_revert state
/// with overlapping timeframes.</para>
/// </summary>
public sealed record class BackfillCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The (exclusive) end of the usage timeframe affected by this backfill. By
    /// default, Orb allows backfills up to 31 days in duration at a time. Reach
    /// out to discuss extending this limit and your use case.
    /// </summary>
    public required DateTimeOffset TimeframeEnd
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>("timeframe_end");
        }
        init { this._rawBodyData.Set("timeframe_end", value); }
    }

    /// <summary>
    /// The (inclusive) start of the usage timeframe affected by this backfill. By
    /// default, Orb allows backfills up to 31 days in duration at a time. Reach
    /// out to discuss extending this limit and your use case.
    /// </summary>
    public required DateTimeOffset TimeframeStart
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>("timeframe_start");
        }
        init { this._rawBodyData.Set("timeframe_start", value); }
    }

    /// <summary>
    /// The time at which no more events will be accepted for this backfill. The
    /// backfill will automatically begin reflecting throughout Orb at the close
    /// time. If not specified, it will default to 1 day after the creation of the backfill.
    /// </summary>
    public DateTimeOffset? CloseTime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("close_time");
        }
        init { this._rawBodyData.Set("close_time", value); }
    }

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. Omitting
    /// this field will scope the backfill to all customers.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customer_id");
        }
        init { this._rawBodyData.Set("customer_id", value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("deprecation_filter");
        }
        init { this._rawBodyData.Set("deprecation_filter", value); }
    }

    /// <summary>
    /// The external customer ID of the customer to which this backfill is scoped.
    /// Omitting this field will scope the backfill to all customers.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_customer_id");
        }
        init { this._rawBodyData.Set("external_customer_id", value); }
    }

    /// <summary>
    /// If true, replaces all existing events in the timeframe with the newly ingested
    /// events. If false, adds the newly ingested events to the existing events.
    /// </summary>
    public bool? ReplaceExistingEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("replace_existing_events");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("replace_existing_events", value);
        }
    }

    public BackfillCreateParams() { }

    public BackfillCreateParams(BackfillCreateParams backfillCreateParams)
        : base(backfillCreateParams)
    {
        this._rawBodyData = new(backfillCreateParams._rawBodyData);
    }

    public BackfillCreateParams(
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
    BackfillCreateParams(
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
    public static BackfillCreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/events/backfills")
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
