using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.SubscriptionChanges;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionChangeListResponse,
        SubscriptionChangeListResponseFromRaw
    >)
)]
public sealed record class SubscriptionChangeListResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Subscription change will be cancelled at this time and can no longer be applied.
    /// </summary>
    public required System::DateTimeOffset ExpirationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expiration_time");
        }
        init { this._rawData.Set("expiration_time", value); }
    }

    public required ApiEnum<string, SubscriptionChangeListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionChangeListResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// When this change was applied.
    /// </summary>
    public System::DateTimeOffset? AppliedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("applied_at");
        }
        init { this._rawData.Set("applied_at", value); }
    }

    /// <summary>
    /// When this change was cancelled.
    /// </summary>
    public System::DateTimeOffset? CancelledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("cancelled_at");
        }
        init { this._rawData.Set("cancelled_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpirationTime;
        this.Status.Validate();
        _ = this.SubscriptionID;
        _ = this.AppliedAt;
        _ = this.CancelledAt;
    }

    public SubscriptionChangeListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionChangeListResponse(
        SubscriptionChangeListResponse subscriptionChangeListResponse
    )
        : base(subscriptionChangeListResponse) { }
#pragma warning restore CS8618

    public SubscriptionChangeListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionChangeListResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionChangeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionChangeListResponseFromRaw : IFromRawJson<SubscriptionChangeListResponse>
{
    /// <inheritdoc/>
    public SubscriptionChangeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangeListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubscriptionChangeListResponseStatusConverter))]
public enum SubscriptionChangeListResponseStatus
{
    Pending,
    Applied,
    Cancelled,
}

sealed class SubscriptionChangeListResponseStatusConverter
    : JsonConverter<SubscriptionChangeListResponseStatus>
{
    public override SubscriptionChangeListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => SubscriptionChangeListResponseStatus.Pending,
            "applied" => SubscriptionChangeListResponseStatus.Applied,
            "cancelled" => SubscriptionChangeListResponseStatus.Cancelled,
            _ => (SubscriptionChangeListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionChangeListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionChangeListResponseStatus.Pending => "pending",
                SubscriptionChangeListResponseStatus.Applied => "applied",
                SubscriptionChangeListResponseStatus.Cancelled => "cancelled",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
