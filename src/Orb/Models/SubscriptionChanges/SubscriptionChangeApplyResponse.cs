using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// A subscription change represents a desired new subscription / pending change
/// to an existing subscription. It is a way to first preview the effects on the subscription
/// as well as any changes/creation of invoices (see `subscription.changed_resources`).
/// </summary>
[JsonConverter(typeof(ModelConverter<SubscriptionChangeApplyResponse>))]
public sealed record class SubscriptionChangeApplyResponse
    : ModelBase,
        IFromRaw<SubscriptionChangeApplyResponse>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Subscription change will be cancelled at this time and can no longer be applied.
    /// </summary>
    public required System::DateTime ExpirationTime
    {
        get
        {
            if (!this.Properties.TryGetValue("expiration_time", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'expiration_time' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "expiration_time",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["expiration_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Status1> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required MutatedSubscription? Subscription
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MutatedSubscription?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["subscription"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When this change was applied.
    /// </summary>
    public System::DateTime? AppliedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("applied_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["applied_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When this change was cancelled.
    /// </summary>
    public System::DateTime? CancelledAt
    {
        get
        {
            if (!this.Properties.TryGetValue("cancelled_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cancelled_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public SubscriptionChangeApplyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeApplyResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionChangeApplyResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(Status1Converter))]
public enum Status1
{
    Pending,
    Applied,
    Cancelled,
}

sealed class Status1Converter : JsonConverter<Status1>
{
    public override Status1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status1.Pending,
            "applied" => Status1.Applied,
            "cancelled" => Status1.Cancelled,
            _ => (Status1)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status1 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status1.Pending => "pending",
                Status1.Applied => "applied",
                Status1.Cancelled => "cancelled",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
