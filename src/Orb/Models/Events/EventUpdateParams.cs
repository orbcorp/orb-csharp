using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Events;

/// <summary>
/// This endpoint is used to amend a single usage event with a given `event_id`.
/// `event_id` refers to the `idempotency_key` passed in during ingestion. The event
/// will maintain its existing `event_id` after the amendment.
///
/// <para>This endpoint will mark the existing event as ignored, and Orb will only
/// use the new event passed in the body of this request as the source of truth for
/// that `event_id`. Note that a single event can be amended any number of times,
/// so the same event can be overwritten in subsequent calls to this endpoint. Only
/// a single event with a given `event_id` will be considered the source of truth
/// at any given time.</para>
///
/// <para>This is a powerful and audit-safe mechanism to retroactively update a single
/// event in cases where you need to: * update an event with new metadata as you
/// iterate on your pricing model * update an event based on the result of an external
/// API call (e.g. call to a payment gateway succeeded or failed)</para>
///
/// <para>This amendment API is always audit-safe. The process will still retain the
/// original event, though it will be ignored for billing calculations. For auditing
/// and data fidelity purposes, Orb never overwrites or permanently deletes ingested
/// usage data.</para>
///
/// <para>## Request validation * The `timestamp` of the new event must match the
/// `timestamp` of the existing event already ingested. As with   ingestion, all
/// timestamps must be sent in ISO8601 format with UTC timezone offset. * The `customer_id`
/// or `external_customer_id` of the new event must match the `customer_id` or   `external_customer_id`
/// of the existing event already ingested. Exactly one of `customer_id` and   `external_customer_id`
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
/// using the [event backfill](create-backfill) endpoint.</para>
/// </summary>
public sealed record class EventUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string EventID { get; init; }

    /// <summary>
    /// A name to meaningfully identify the action or event type.
    /// </summary>
    public required string EventName
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("event_name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_name' cannot be null",
                    new ArgumentOutOfRangeException("event_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'event_name' cannot be null",
                    new ArgumentNullException("event_name")
                );
        }
        init
        {
            this._bodyProperties["event_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A dictionary of custom properties. Values in this dictionary must be numeric,
    /// boolean, or strings. Nested dictionaries are disallowed.
    /// </summary>
    public required Dictionary<string, JsonElement> Properties
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("properties", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'properties' cannot be null",
                    new ArgumentOutOfRangeException("properties", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'properties' cannot be null",
                    new ArgumentNullException("properties")
                );
        }
        init
        {
            this._bodyProperties["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 8601 format date with no timezone offset (i.e. UTC). This should represent
    /// the time that usage was recorded, and is particularly important to attribute
    /// usage to a given billing period.
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("timestamp", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timestamp' cannot be null",
                    new ArgumentOutOfRangeException("timestamp", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Orb Customer identifier
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
    /// An alias for the Orb customer, whose mapping is specified when creating the customer
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

    public EventUpdateParams() { }

    public EventUpdateParams(
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
    EventUpdateParams(
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

    public static EventUpdateParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/events/{0}", this.EventID)
        )
        {
            Query = this.QueryString(options),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
