using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Events;

/// <summary>
/// This endpoint is used to amend a single usage event with a given `event_id`. `event_id`
/// refers to the `idempotency_key` passed in during ingestion. The event will maintain
/// its existing `event_id` after the amendment.
///
/// This endpoint will mark the existing event as ignored, and Orb will only use the
/// new event passed in the body of this request as the source of truth for that
/// `event_id`. Note that a single event can be amended any number of times, so the
/// same event can be overwritten in subsequent calls to this endpoint. Only a single
/// event with a given `event_id` will be considered the source of truth at any given time.
///
/// This is a powerful and audit-safe mechanism to retroactively update a single event
/// in cases where you need to: * update an event with new metadata as you iterate
/// on your pricing model * update an event based on the result of an external API
/// call (e.g. call to a payment gateway succeeded or failed)
///
/// This amendment API is always audit-safe. The process will still retain the original
/// event, though it will be ignored for billing calculations. For auditing and data
/// fidelity purposes, Orb never overwrites or permanently deletes ingested usage data.
///
/// ## Request validation * The `timestamp` of the new event must match the `timestamp`
/// of the existing event already ingested. As with   ingestion, all timestamps must
/// be sent in ISO8601 format with UTC timezone offset. * The `customer_id` or `external_customer_id`
/// of the new event must match the `customer_id` or   `external_customer_id` of
/// the existing event already ingested. Exactly one of `customer_id` and   `external_customer_id`
/// should be specified, and similar to ingestion, the ID must identify a Customer
/// resource   within Orb. Unlike ingestion, for event amendment, we strictly enforce
/// that the Customer must be in the Orb   system, even during the initial integration
/// period. We do not allow updating the `Customer` an event is   associated with.
/// * Orb does not accept an `idempotency_key` with the event in this endpoint, since
/// this request is by design   idempotent. On retryable errors, you should retry
/// the request and assume the amendment operation has not   succeeded until receipt
/// of a 2xx. * The event's `timestamp` must fall within the customer's current subscription's
/// billing period, or within the   grace period of the customer's current subscription's
/// previous billing period. * By default, no more than 100 events can be amended
/// for a single customer in a 100 day period. For higher volume   updates, consider
/// using the [event backfill](create-backfill) endpoint.
/// </summary>
public sealed record class EventUpdateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string EventID;

    /// <summary>
    /// A name to meaningfully identify the action or event type.
    /// </summary>
    public required string EventName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("event_name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "event_name",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("event_name");
        }
        set { this.BodyProperties["event_name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A dictionary of custom properties. Values in this dictionary must be numeric,
    /// boolean, or strings. Nested dictionaries are disallowed.
    /// </summary>
    public required Generic::Dictionary<string, Json::JsonElement> Properties
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("properties", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "properties",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, Json::JsonElement>>(
                    element
                ) ?? throw new System::ArgumentNullException("properties");
        }
        set { this.BodyProperties["properties"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An ISO 8601 format date with no timezone offset (i.e. UTC). This should represent
    /// the time that usage was recorded, and is particularly important to attribute
    /// usage to a given billing period.
    /// </summary>
    public required System::DateTime Timestamp
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timestamp", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timestamp",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.BodyProperties["timestamp"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The Orb Customer identifier
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
    /// An alias for the Orb customer, whose mapping is specified when creating the customer
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

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/events/{0}", this.EventID)
        )
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
