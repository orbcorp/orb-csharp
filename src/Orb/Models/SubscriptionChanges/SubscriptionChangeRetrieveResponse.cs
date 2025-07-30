using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SubscriptionChangeRetrieveResponseProperties = Orb.Models.SubscriptionChanges.SubscriptionChangeRetrieveResponseProperties;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// A subscription change represents a desired new subscription / pending change
/// to an existing subscription. It is a way to first preview the effects on the subscription
/// as well as any changes/creation of invoices (see `subscription.changed_resources`).
/// </summary>
[JsonConverter(typeof(ModelConverter<SubscriptionChangeRetrieveResponse>))]
public sealed record class SubscriptionChangeRetrieveResponse
    : ModelBase,
        IFromRaw<SubscriptionChangeRetrieveResponse>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Subscription change will be cancelled at this time and can no longer be applied.
    /// </summary>
    public required DateTime ExpirationTime
    {
        get
        {
            if (!this.Properties.TryGetValue("expiration_time", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "expiration_time",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime>(element);
        }
        set { this.Properties["expiration_time"] = JsonSerializer.SerializeToElement(value); }
    }

    public required SubscriptionChangeRetrieveResponseProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<SubscriptionChangeRetrieveResponseProperties::Status>(
                    element
                ) ?? throw new ArgumentNullException("status");
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MutatedSubscription? Subscription
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription", out JsonElement element))
                throw new ArgumentOutOfRangeException("subscription", "Missing required argument");

            return JsonSerializer.Deserialize<MutatedSubscription?>(element);
        }
        set { this.Properties["subscription"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// When this change was applied.
    /// </summary>
    public DateTime? AppliedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("applied_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element);
        }
        set { this.Properties["applied_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// When this change was cancelled.
    /// </summary>
    public DateTime? CancelledAt
    {
        get
        {
            if (!this.Properties.TryGetValue("cancelled_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element);
        }
        set { this.Properties["cancelled_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpirationTime;
        this.Status.Validate();
        this.Subscription?.Validate();
        _ = this.AppliedAt;
        _ = this.CancelledAt;
    }

    public SubscriptionChangeRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeRetrieveResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionChangeRetrieveResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
