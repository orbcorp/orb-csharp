using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Events;

/// <summary>
/// This endpoint is used to deprecate a single usage event with a given `event_id`.
/// `event_id` refers to the `idempotency_key` passed in during ingestion.
///
/// <para>This endpoint will mark the existing event as ignored. Note that if you
/// attempt to re-ingest an event with the same `event_id` as a deprecated event,
/// Orb will return an error.</para>
///
/// <para>This is a powerful and audit-safe mechanism to retroactively deprecate
/// a single event in cases where you need to: * no longer bill for an event that
/// was improperly reported * no longer bill for an event based on the result of
/// an external API call (e.g. call to a payment gateway failed and   the user should
/// not be billed)</para>
///
/// <para>If you want to only change specific properties of an event, but keep the
/// event as part of the billing calculation, use the [Amend event](amend-event) endpoint instead.</para>
///
/// <para>This API is always audit-safe. The process will still retain the deprecated
/// event, though it will be ignored for billing calculations. For auditing and data
/// fidelity purposes, Orb never overwrites or permanently deletes ingested usage data.</para>
///
/// <para>## Request validation * Orb does not accept an `idempotency_key` with the
/// event in this endpoint, since this request is by design   idempotent. On retryable
/// errors, you should retry the request and assume the deprecation operation has
/// not   succeeded until receipt of a 2xx. * The event's `timestamp` must fall within
/// the customer's current subscription's billing period, or within the   grace period
/// of the customer's current subscription's previous billing period. Orb does not
/// allow deprecating   events for billing periods that have already invoiced customers.
/// * The `customer_id` or the `external_customer_id` of the original event ingestion
/// request must identify a Customer   resource within Orb, even if this event was
/// ingested during the initial integration period. We do not allow   deprecating
/// events for customers not in the Orb system. * By default, no more than 100 events
/// can be deprecated for a single customer in a 100 day period. For higher volume
///   updates, consider using the [event backfill](create-backfill) endpoint.</para>
/// </summary>
public sealed record class EventDeprecateParams : ParamsBase
{
    public string? EventID { get; init; }

    public EventDeprecateParams() { }

    public EventDeprecateParams(EventDeprecateParams eventDeprecateParams)
        : base(eventDeprecateParams)
    {
        this.EventID = eventDeprecateParams.EventID;
    }

    public EventDeprecateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventDeprecateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static EventDeprecateParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/{0}/deprecate", this.EventID)
        )
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
