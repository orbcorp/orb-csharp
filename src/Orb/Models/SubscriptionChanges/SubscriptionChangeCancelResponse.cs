using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// A subscription change represents a desired new subscription / pending change to
/// an existing subscription. It is a way to first preview the effects on the subscription
/// as well as any changes/creation of invoices (see `subscription.changed_resources`).
/// </summary>
[JsonConverter(typeof(ModelConverter<SubscriptionChangeCancelResponse>))]
public sealed record class SubscriptionChangeCancelResponse
    : ModelBase,
        IFromRaw<SubscriptionChangeCancelResponse>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
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
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Subscription change will be cancelled at this time and can no longer be applied.
    /// </summary>
    public required System::DateTimeOffset ExpirationTime
    {
        get
        {
            if (!this._properties.TryGetValue("expiration_time", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'expiration_time' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "expiration_time",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["expiration_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, SubscriptionChangeCancelResponseStatus> Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, SubscriptionChangeCancelResponseStatus>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required MutatedSubscription? Subscription
    {
        get
        {
            if (!this._properties.TryGetValue("subscription", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MutatedSubscription?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["subscription"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When this change was applied.
    /// </summary>
    public System::DateTimeOffset? AppliedAt
    {
        get
        {
            if (!this._properties.TryGetValue("applied_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["applied_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When this change was cancelled.
    /// </summary>
    public System::DateTimeOffset? CancelledAt
    {
        get
        {
            if (!this._properties.TryGetValue("cancelled_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cancelled_at"] = JsonSerializer.SerializeToElement(
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

    public SubscriptionChangeCancelResponse() { }

    public SubscriptionChangeCancelResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeCancelResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SubscriptionChangeCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(SubscriptionChangeCancelResponseStatusConverter))]
public enum SubscriptionChangeCancelResponseStatus
{
    Pending,
    Applied,
    Cancelled,
}

sealed class SubscriptionChangeCancelResponseStatusConverter
    : JsonConverter<SubscriptionChangeCancelResponseStatus>
{
    public override SubscriptionChangeCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => SubscriptionChangeCancelResponseStatus.Pending,
            "applied" => SubscriptionChangeCancelResponseStatus.Applied,
            "cancelled" => SubscriptionChangeCancelResponseStatus.Cancelled,
            _ => (SubscriptionChangeCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionChangeCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionChangeCancelResponseStatus.Pending => "pending",
                SubscriptionChangeCancelResponseStatus.Applied => "applied",
                SubscriptionChangeCancelResponseStatus.Cancelled => "cancelled",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
