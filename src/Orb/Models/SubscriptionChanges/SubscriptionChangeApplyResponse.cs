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
    typeof(ModelConverter<SubscriptionChangeApplyResponse, SubscriptionChangeApplyResponseFromRaw>)
)]
public sealed record class SubscriptionChangeApplyResponse : ModelBase
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

    public required ApiEnum<string, SubscriptionChangeApplyResponseStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, SubscriptionChangeApplyResponseStatus>
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

    public SubscriptionChangeApplyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeApplyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SubscriptionChangeApplyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionChangeApplyResponseFromRaw : IFromRaw<SubscriptionChangeApplyResponse>
{
    public SubscriptionChangeApplyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangeApplyResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubscriptionChangeApplyResponseStatusConverter))]
public enum SubscriptionChangeApplyResponseStatus
{
    Pending,
    Applied,
    Cancelled,
}

sealed class SubscriptionChangeApplyResponseStatusConverter
    : JsonConverter<SubscriptionChangeApplyResponseStatus>
{
    public override SubscriptionChangeApplyResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => SubscriptionChangeApplyResponseStatus.Pending,
            "applied" => SubscriptionChangeApplyResponseStatus.Applied,
            "cancelled" => SubscriptionChangeApplyResponseStatus.Cancelled,
            _ => (SubscriptionChangeApplyResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionChangeApplyResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionChangeApplyResponseStatus.Pending => "pending",
                SubscriptionChangeApplyResponseStatus.Applied => "applied",
                SubscriptionChangeApplyResponseStatus.Cancelled => "cancelled",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
