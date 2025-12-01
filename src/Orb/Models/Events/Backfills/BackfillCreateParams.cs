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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
            return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawBodyData, "timeframe_end");
        }
        init { ModelBase.Set(this._rawBodyData, "timeframe_end", value); }
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
            return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawBodyData, "timeframe_start");
        }
        init { ModelBase.Set(this._rawBodyData, "timeframe_start", value); }
    }

    /// <summary>
    /// The time at which no more events will be accepted for this backfill. The
    /// backfill will automatically begin reflecting throughout Orb at the close
    /// time. If not specified, it will default to 1 day after the creation of the backfill.
    /// </summary>
    public DateTimeOffset? CloseTime
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawBodyData, "close_time"); }
        init { ModelBase.Set(this._rawBodyData, "close_time", value); }
    }

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. Omitting
    /// this field will scope the backfill to all customers.
    /// </summary>
    public string? CustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "customer_id"); }
        init { ModelBase.Set(this._rawBodyData, "customer_id", value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "deprecation_filter"); }
        init { ModelBase.Set(this._rawBodyData, "deprecation_filter", value); }
    }

    /// <summary>
    /// The external customer ID of the customer to which this backfill is scoped.
    /// Omitting this field will scope the backfill to all customers.
    /// </summary>
    public string? ExternalCustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "external_customer_id"); }
        init { ModelBase.Set(this._rawBodyData, "external_customer_id", value); }
    }

    /// <summary>
    /// If true, replaces all existing events in the timeframe with the newly ingested
    /// events. If false, adds the newly ingested events to the existing events.
    /// </summary>
    public bool? ReplaceExistingEvents
    {
        get
        {
            return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "replace_existing_events");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "replace_existing_events", value);
        }
    }

    public BackfillCreateParams() { }

    public BackfillCreateParams(
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
    BackfillCreateParams(
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
