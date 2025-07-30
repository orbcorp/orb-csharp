using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

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
/// the parameter `filter` can be optionally added which enables filtering using [computed
/// properties](/extensibility/advanced-metrics#computed-properties). The expressiveness
/// of computed properties allows you to deprecate existing events based on both a
/// period of time and specific property values.
/// </summary>
public sealed record class BackfillCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The (exclusive) end of the usage timeframe affected by this backfill. By default,
    /// Orb allows backfills up to 31 days in duration at a time. Reach out to discuss
    /// extending this limit and your use case.
    /// </summary>
    public required System::DateTime TimeframeEnd
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_end", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_end",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set
        {
            this.BodyProperties["timeframe_end"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The (inclusive) start of the usage timeframe affected by this backfill. By default,
    /// Orb allows backfills up to 31 days in duration at a time. Reach out to discuss
    /// extending this limit and your use case.
    /// </summary>
    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_start", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set
        {
            this.BodyProperties["timeframe_start"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The time at which no more events will be accepted for this backfill. The backfill
    /// will automatically begin reflecting throughout Orb at the close time. If not
    /// specified, it will default to 1 day after the creation of the backfill.
    /// </summary>
    public System::DateTime? CloseTime
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("close_time", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.BodyProperties["close_time"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. Omitting
    /// this field will scope the backfill to all customers.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["customer_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "deprecation_filter",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["deprecation_filter"] = Json::JsonSerializer.SerializeToElement(
                value
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
            if (
                !this.BodyProperties.TryGetValue(
                    "external_customer_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = Json::JsonSerializer.SerializeToElement(
                value
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
                !this.BodyProperties.TryGetValue(
                    "replace_existing_events",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["replace_existing_events"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/backfills")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
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
