using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubscriptionChangeRetrieveResponseProperties = Orb.Models.SubscriptionChanges.SubscriptionChangeRetrieveResponseProperties;
using System = System;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// A subscription change represents a desired new subscription / pending change
/// to an existing subscription. It is a way to first preview the effects on the subscription
/// as well as any changes/creation of invoices (see `subscription.changed_resources`).
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<SubscriptionChangeRetrieveResponse>))]
public sealed record class SubscriptionChangeRetrieveResponse
    : Orb::ModelBase,
        Orb::IFromRaw<SubscriptionChangeRetrieveResponse>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Subscription change will be cancelled at this time and can no longer be applied.
    /// </summary>
    public required System::DateTime ExpirationTime
    {
        get
        {
            if (!this.Properties.TryGetValue("expiration_time", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "expiration_time",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["expiration_time"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required SubscriptionChangeRetrieveResponseProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "status",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<SubscriptionChangeRetrieveResponseProperties::Status>(
                    element
                ) ?? throw new System::ArgumentNullException("status");
        }
        set { this.Properties["status"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required MutatedSubscription? Subscription
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subscription",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<MutatedSubscription?>(element);
        }
        set { this.Properties["subscription"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// When this change was applied.
    /// </summary>
    public System::DateTime? AppliedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("applied_at", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["applied_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// When this change was cancelled.
    /// </summary>
    public System::DateTime? CancelledAt
    {
        get
        {
            if (!this.Properties.TryGetValue("cancelled_at", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["cancelled_at"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    SubscriptionChangeRetrieveResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionChangeRetrieveResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
