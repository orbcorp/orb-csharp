using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// Creating the backfill enables adding or replacing past events, even those that
/// are older than the ingestion grace period. Performing a backfill in Orb involves
/// 3 steps:
///
/// 1. Create the backfill, specifying its parameters. 2. [Ingest](ingest) usage events,
/// referencing the backfill (query parameter `backfill_id`). 3. [Close](close-backfill)
/// the backfill, propagating the update in past usage throughout Orb.
///
/// Changes from a backfill are not reflected until the backfill is closed, so you
/// won’t need to worry about your customers seeing partially updated usage data.
/// Backfills are also reversible, so you’ll be able to revert a backfill if you’ve
/// made a mistake.
///
/// This endpoint will return a backfill object, which contains an `id`. That `id`
/// can then be used as the `backfill_id` query parameter to the event ingestion endpoint
/// to associate ingested events with this backfill. The effects (e.g. updated usage
/// graphs) of this backfill will not take place until the backfill is closed.
///
/// If the `replace_existing_events` is `true`, existing events in the backfill's
/// timeframe will be replaced with the newly ingested events associated with the
/// backfill. If `false`, newly ingested events will be added to the existing events.
///
/// If a `customer_id` or `external_customer_id` is specified, the backfill will only
/// affect events for that customer. If neither is specified, the backfill will affect
/// all customers.
///
/// When `replace_existing_events` is `true`, this indicates that existing events
/// in the timeframe should no longer be counted towards invoiced usage. In this scenario,
/// the parameter `deprecation_filter` can be optionally added which enables filtering
/// using [computed properties](/extensibility/advanced-metrics#computed-properties).
/// The expressiveness of computed properties allows you to deprecate existing events
/// based on both a period of time and specific property values.
/// </summary>
public sealed record class BackfillCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// The (exclusive) end of the usage timeframe affected by this backfill. By default,
    /// Orb allows backfills up to 31 days in duration at a time. Reach out to discuss
    /// extending this limit and your use case.
    /// </summary>
    public required DateTime TimeframeEnd
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("timeframe_end", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_end' cannot be null",
                    new ArgumentOutOfRangeException("timeframe_end", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
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
    /// The (inclusive) start of the usage timeframe affected by this backfill. By
    /// default, Orb allows backfills up to 31 days in duration at a time. Reach out
    /// to discuss extending this limit and your use case.
    /// </summary>
    public required DateTime TimeframeStart
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("timeframe_start", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_start' cannot be null",
                    new ArgumentOutOfRangeException("timeframe_start", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which no more events will be accepted for this backfill. The backfill
    /// will automatically begin reflecting throughout Orb at the close time. If not
    /// specified, it will default to 1 day after the creation of the backfill.
    /// </summary>
    public DateTime? CloseTime
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("close_time", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["close_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. Omitting
    /// this field will scope the backfill to all customers.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("deprecation_filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["deprecation_filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The external customer ID of the customer to which this backfill is scoped.
    /// Omitting this field will scope the backfill to all customers.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, replaces all existing events in the timeframe with the newly ingested
    /// events. If false, adds the newly ingested events to the existing events.
    /// </summary>
    public bool? ReplaceExistingEvents
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "replace_existing_events",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["replace_existing_events"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BackfillCreateParams() { }

    public BackfillCreateParams(
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
    BackfillCreateParams(
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

    public static BackfillCreateParams FromRawUnchecked(
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
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/backfills")
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
