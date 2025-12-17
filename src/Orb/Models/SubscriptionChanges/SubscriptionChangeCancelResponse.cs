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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The type of change (e.g., 'schedule_plan_change', 'create_subscription').
    /// </summary>
    public required string ChangeType
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "change_type"); }
        init { JsonModel.Set(this._rawData, "change_type", value); }
    }

    /// <summary>
    /// Subscription change will be cancelled at this time and can no longer be applied.
    /// </summary>
    public required System::DateTimeOffset ExpirationTime
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "expiration_time"
            );
        }
        init { JsonModel.Set(this._rawData, "expiration_time", value); }
    }

    public required ApiEnum<string, SubscriptionChangeCancelResponseStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, SubscriptionChangeCancelResponseStatus>
            >(this.RawData, "status");
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    public required MutatedSubscription? Subscription
    {
        get
        {
            return JsonModel.GetNullableClass<MutatedSubscription>(this.RawData, "subscription");
        }
        init { JsonModel.Set(this._rawData, "subscription", value); }
    }

    /// <summary>
    /// When this change was applied.
    /// </summary>
    public System::DateTimeOffset? AppliedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "applied_at");
        }
        init { JsonModel.Set(this._rawData, "applied_at", value); }
    }

    /// <summary>
    /// Billing cycle alignment for plan changes.
    /// </summary>
    public string? BillingCycleAlignment
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billing_cycle_alignment"); }
        init { JsonModel.Set(this._rawData, "billing_cycle_alignment", value); }
    }

    /// <summary>
    /// When this change was cancelled.
    /// </summary>
    public System::DateTimeOffset? CancelledAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "cancelled_at"
            );
        }
        init { JsonModel.Set(this._rawData, "cancelled_at", value); }
    }

    /// <summary>
    /// How the change is scheduled (e.g., 'immediate', 'end_of_subscription_term', 'requested_date').
    /// </summary>
    public string? ChangeOption
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "change_option"); }
        init { JsonModel.Set(this._rawData, "change_option", value); }
    }

    /// <summary>
    /// When this change will take effect.
    /// </summary>
    public System::DateTimeOffset? EffectiveDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { JsonModel.Set(this._rawData, "effective_date", value); }
    }

    /// <summary>
    /// The target plan ID for plan changes.
    /// </summary>
    public string? PlanID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "plan_id"); }
        init { JsonModel.Set(this._rawData, "plan_id", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
