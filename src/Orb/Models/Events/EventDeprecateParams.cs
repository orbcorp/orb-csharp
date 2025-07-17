using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Events;

/// <summary>
/// This endpoint is used to deprecate a single usage event with a given `event_id`.
/// `event_id` refers to the `idempotency_key` passed in during ingestion.
///
/// This endpoint will mark the existing event as ignored. Note that if you attempt
/// to re-ingest an event with the same `event_id` as a deprecated event, Orb will
/// return an error.
///
/// This is a powerful and audit-safe mechanism to retroactively deprecate a single
/// event in cases where you need to: * no longer bill for an event that was improperly
/// reported * no longer bill for an event based on the result of an external API
/// call (e.g. call to a payment gateway failed and   the user should not be billed)
///
/// If you want to only change specific properties of an event, but keep the event
/// as part of the billing calculation, use the [Amend event](amend-event) endpoint instead.
///
/// This API is always audit-safe. The process will still retain the deprecated event,
/// though it will be ignored for billing calculations. For auditing and data fidelity
/// purposes, Orb never overwrites or permanently deletes ingested usage data.
///
/// ## Request validation * Orb does not accept an `idempotency_key` with the event
/// in this endpoint, since this request is by design   idempotent. On retryable
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
///   updates, consider using the [event backfill](create-backfill) endpoint.
/// </summary>
public sealed record class EventDeprecateParams : Orb::ParamsBase
{
    public required string EventID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/{0}/deprecate", this.EventID)
        )
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
