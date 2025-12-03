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
[JsonConverter(
    typeof(ModelConverter<
        SubscriptionChangeRetrieveResponse,
        SubscriptionChangeRetrieveResponseFromRaw
    >)
)]
public sealed record class SubscriptionChangeRetrieveResponse : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Subscription change will be cancelled at this time and can no longer be applied.
    /// </summary>
    public required System::DateTimeOffset ExpirationTime
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "expiration_time"
            );
        }
        init { ModelBase.Set(this._rawData, "expiration_time", value); }
    }

    public required ApiEnum<string, SubscriptionChangeRetrieveResponseStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, SubscriptionChangeRetrieveResponseStatus>
            >(this.RawData, "status");
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public required MutatedSubscription? Subscription
    {
        get
        {
            return ModelBase.GetNullableClass<MutatedSubscription>(this.RawData, "subscription");
        }
        init { ModelBase.Set(this._rawData, "subscription", value); }
    }

    /// <summary>
    /// When this change was applied.
    /// </summary>
    public System::DateTimeOffset? AppliedAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "applied_at");
        }
        init { ModelBase.Set(this._rawData, "applied_at", value); }
    }

    /// <summary>
    /// When this change was cancelled.
    /// </summary>
    public System::DateTimeOffset? CancelledAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "cancelled_at"
            );
        }
        init { ModelBase.Set(this._rawData, "cancelled_at", value); }
    }

    /// <inheritdoc/>
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

    public SubscriptionChangeRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionChangeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionChangeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionChangeRetrieveResponseFromRaw : IFromRaw<SubscriptionChangeRetrieveResponse>
{
    /// <inheritdoc/>
    public SubscriptionChangeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangeRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubscriptionChangeRetrieveResponseStatusConverter))]
public enum SubscriptionChangeRetrieveResponseStatus
{
    Pending,
    Applied,
    Cancelled,
}

sealed class SubscriptionChangeRetrieveResponseStatusConverter
    : JsonConverter<SubscriptionChangeRetrieveResponseStatus>
{
    public override SubscriptionChangeRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => SubscriptionChangeRetrieveResponseStatus.Pending,
            "applied" => SubscriptionChangeRetrieveResponseStatus.Applied,
            "cancelled" => SubscriptionChangeRetrieveResponseStatus.Cancelled,
            _ => (SubscriptionChangeRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionChangeRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionChangeRetrieveResponseStatus.Pending => "pending",
                SubscriptionChangeRetrieveResponseStatus.Applied => "applied",
                SubscriptionChangeRetrieveResponseStatus.Cancelled => "cancelled",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
