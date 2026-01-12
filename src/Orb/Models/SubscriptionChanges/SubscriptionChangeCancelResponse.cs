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
    typeof(JsonModelConverter<
        SubscriptionChangeCancelResponse,
        SubscriptionChangeCancelResponseFromRaw
    >)
)]
public sealed record class SubscriptionChangeCancelResponse : JsonModel
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
    /// The type of change (e.g., 'schedule_plan_change', 'create_subscription').
    /// </summary>
    public required string ChangeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("change_type");
        }
        init { this._rawData.Set("change_type", value); }
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

    public required ApiEnum<string, SubscriptionChangeCancelResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionChangeCancelResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required MutatedSubscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MutatedSubscription>("subscription");
        }
        init { this._rawData.Set("subscription", value); }
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
    /// Billing cycle alignment for plan changes.
    /// </summary>
    public string? BillingCycleAlignment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_cycle_alignment");
        }
        init { this._rawData.Set("billing_cycle_alignment", value); }
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

    /// <summary>
    /// How the change is scheduled (e.g., 'immediate', 'end_of_subscription_term', 'requested_date').
    /// </summary>
    public string? ChangeOption
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("change_option");
        }
        init { this._rawData.Set("change_option", value); }
    }

    /// <summary>
    /// When this change will take effect.
    /// </summary>
    public System::DateTimeOffset? EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
    }

    /// <summary>
    /// The target plan ID for plan changes.
    /// </summary>
    public string? PlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("plan_id");
        }
        init { this._rawData.Set("plan_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChangeType;
        _ = this.ExpirationTime;
        this.Status.Validate();
        this.Subscription?.Validate();
        _ = this.AppliedAt;
        _ = this.BillingCycleAlignment;
        _ = this.CancelledAt;
        _ = this.ChangeOption;
        _ = this.EffectiveDate;
        _ = this.PlanID;
    }

    public SubscriptionChangeCancelResponse() { }

    public SubscriptionChangeCancelResponse(
        SubscriptionChangeCancelResponse subscriptionChangeCancelResponse
    )
        : base(subscriptionChangeCancelResponse) { }

    public SubscriptionChangeCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionChangeCancelResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionChangeCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionChangeCancelResponseFromRaw : IFromRawJson<SubscriptionChangeCancelResponse>
{
    /// <inheritdoc/>
    public SubscriptionChangeCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangeCancelResponse.FromRawUnchecked(rawData);
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
