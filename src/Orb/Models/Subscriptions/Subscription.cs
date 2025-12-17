using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;
using Plans = Orb.Models.Plans;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// A [subscription](/core-concepts#subscription) represents the purchase of a plan
/// by a customer.
///
/// <para>By default, subscriptions begin on the day that they're created and renew
/// automatically for each billing cycle at the cadence that's configured in the
/// plan definition.</para>
///
/// <para>Subscriptions also default to **beginning of month alignment**, which means
/// the first invoice issued for the subscription will have pro-rated charges between
/// the `start_date` and the first of the following month. Subsequent billing periods
/// will always start and end on a month boundary (e.g. subsequent month starts for
/// monthly billing).</para>
///
/// <para>Depending on the plan configuration, any _flat_ recurring fees will be billed
/// either at the beginning (in-advance) or end (in-arrears) of each billing cycle.
/// Plans default to **in-advance billing**. Usage-based fees are billed in arrears
/// as usage is accumulated. In the normal course of events, you can expect an invoice
/// to contain usage-based charges for the previous period, and a recurring fee for
/// the following period.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The current plan phase that is active, only if the subscription's plan has phases.
    /// </summary>
    public required long? ActivePlanPhaseOrder
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "active_plan_phase_order"); }
        init { JsonModel.Set(this._rawData, "active_plan_phase_order", value); }
    }

    /// <summary>
    /// The adjustment intervals for this subscription sorted by the start_date of
    /// the adjustment interval.
    /// </summary>
    public required IReadOnlyList<AdjustmentInterval> AdjustmentIntervals
    {
        get
        {
            return JsonModel.GetNotNullClass<List<AdjustmentInterval>>(
                this.RawData,
                "adjustment_intervals"
            );
        }
        init { JsonModel.Set(this._rawData, "adjustment_intervals", value); }
    }

    /// <summary>
    /// Determines whether issued invoices for this subscription will automatically
    /// be charged with the saved payment method on the due date. This property defaults
    /// to the plan's behavior. If null, defaults to the customer's setting.
    /// </summary>
    public required bool? AutoCollection
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "auto_collection"); }
        init { JsonModel.Set(this._rawData, "auto_collection", value); }
    }

    public required BillingCycleAnchorConfiguration BillingCycleAnchorConfiguration
    {
        get
        {
            return JsonModel.GetNotNullClass<BillingCycleAnchorConfiguration>(
                this.RawData,
                "billing_cycle_anchor_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_anchor_configuration", value); }
    }

    /// <summary>
    /// The day of the month on which the billing cycle is anchored. If the maximum
    /// number of days in a month is greater than this value, the last day of the
    /// month is the billing cycle day (e.g. billing_cycle_day=31 for April means
    /// the billing period begins on the 30th.
    /// </summary>
    public required long BillingCycleDay
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "billing_cycle_day"); }
        init { JsonModel.Set(this._rawData, "billing_cycle_day", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The end of the current billing period. This is an exclusive timestamp, such
    /// that the instant returned is not part of the billing period. Set to null for
    /// subscriptions that are not currently active.
    /// </summary>
    public required System::DateTimeOffset? CurrentBillingPeriodEndDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "current_billing_period_end_date"
            );
        }
        init { JsonModel.Set(this._rawData, "current_billing_period_end_date", value); }
    }

    /// <summary>
    /// The start date of the current billing period. This is an inclusive timestamp;
    /// the instant returned is exactly the beginning of the billing period. Set to
    /// null if the subscription is not currently active.
    /// </summary>
    public required System::DateTimeOffset? CurrentBillingPeriodStartDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "current_billing_period_start_date"
            );
        }
        init { JsonModel.Set(this._rawData, "current_billing_period_start_date", value); }
    }

    /// <summary>
    /// A customer is a buyer of your products, and the other party to the billing relationship.
    ///
    /// <para>In Orb, customers are assigned system generated identifiers automatically,
    /// but it's often desirable to have these match existing identifiers in your
    /// system. To avoid having to denormalize Orb ID information, you can pass in
    /// an `external_customer_id` with your own identifier. See [Customer ID Aliases](/events-and-metrics/customer-aliases)
    /// for further information about how these aliases work in Orb.</para>
    ///
    /// <para>In addition to having an identifier in your system, a customer may
    /// exist in a payment provider solution like Stripe. Use the `payment_provider_id`
    /// and the `payment_provider` enum field to express this mapping.</para>
    ///
    /// <para>A customer also has a timezone (from the standard [IANA timezone database](https://www.iana.org/time-zones)),
    /// which defaults to your account's timezone. See [Timezone localization](/essentials/timezones)
    /// for information on what this timezone parameter influences within Orb.</para>
    /// </summary>
    public required Customer Customer
    {
        get { return JsonModel.GetNotNullClass<Customer>(this.RawData, "customer"); }
        init { JsonModel.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// Determines the default memo on this subscriptions' invoices. Note that if
    /// this is not provided, it is determined by the plan configuration.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "default_invoice_memo"); }
        init { JsonModel.Set(this._rawData, "default_invoice_memo", value); }
    }

    /// <summary>
    /// The discount intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<DiscountInterval> DiscountIntervals
    {
        get
        {
            return JsonModel.GetNotNullClass<List<DiscountInterval>>(
                this.RawData,
                "discount_intervals"
            );
        }
        init { JsonModel.Set(this._rawData, "discount_intervals", value); }
    }

    /// <summary>
    /// The date Orb stops billing for this subscription.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "end_date");
        }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    public required IReadOnlyList<FixedFeeQuantityScheduleEntry> FixedFeeQuantitySchedule
    {
        get
        {
            return JsonModel.GetNotNullClass<List<FixedFeeQuantityScheduleEntry>>(
                this.RawData,
                "fixed_fee_quantity_schedule"
            );
        }
        init { JsonModel.Set(this._rawData, "fixed_fee_quantity_schedule", value); }
    }

    public required string? InvoicingThreshold
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoicing_threshold"); }
        init { JsonModel.Set(this._rawData, "invoicing_threshold", value); }
    }

    /// <summary>
    /// The maximum intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<MaximumInterval> MaximumIntervals
    {
        get
        {
            return JsonModel.GetNotNullClass<List<MaximumInterval>>(
                this.RawData,
                "maximum_intervals"
            );
        }
        init { JsonModel.Set(this._rawData, "maximum_intervals", value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// The minimum intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<MinimumInterval> MinimumIntervals
    {
        get
        {
            return JsonModel.GetNotNullClass<List<MinimumInterval>>(
                this.RawData,
                "minimum_intervals"
            );
        }
        init { JsonModel.Set(this._rawData, "minimum_intervals", value); }
    }

    /// <summary>
    /// The name of the subscription.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Determines the difference between the invoice issue date for subscription
    /// invoices as the date that they are due. A value of `0` here represents that
    /// the invoice is due on issue, whereas a value of `30` represents that the customer
    /// has a month to pay the invoice.
    /// </summary>
    public required long NetTerms
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "net_terms"); }
        init { JsonModel.Set(this._rawData, "net_terms", value); }
    }

    /// <summary>
    /// A pending subscription change if one exists on this subscription.
    /// </summary>
    public required SubscriptionChangeMinified? PendingSubscriptionChange
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionChangeMinified>(
                this.RawData,
                "pending_subscription_change"
            );
        }
        init { JsonModel.Set(this._rawData, "pending_subscription_change", value); }
    }

    /// <summary>
    /// The [Plan](/core-concepts#plan-and-price) resource represents a plan that
    /// can be subscribed to by a customer. Plans define the billing behavior of
    /// the subscription. You can see more about how to configure prices in the [Price resource](/reference/price).
    /// </summary>
    public required Plans::Plan? Plan
    {
        get { return JsonModel.GetNullableClass<Plans::Plan>(this.RawData, "plan"); }
        init { JsonModel.Set(this._rawData, "plan", value); }
    }

    /// <summary>
    /// The price intervals for this subscription.
    /// </summary>
    public required IReadOnlyList<PriceInterval> PriceIntervals
    {
        get
        {
            return JsonModel.GetNotNullClass<List<PriceInterval>>(this.RawData, "price_intervals");
        }
        init { JsonModel.Set(this._rawData, "price_intervals", value); }
    }

    public required CouponRedemption? RedeemedCoupon
    {
        get
        {
            return JsonModel.GetNullableClass<CouponRedemption>(this.RawData, "redeemed_coupon");
        }
        init { JsonModel.Set(this._rawData, "redeemed_coupon", value); }
    }

    /// <summary>
    /// The date Orb starts billing for this subscription.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, SubscriptionStatus>>(
                this.RawData,
                "status"
            );
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    public required SubscriptionTrialInfo TrialInfo
    {
        get { return JsonModel.GetNotNullClass<SubscriptionTrialInfo>(this.RawData, "trial_info"); }
        init { JsonModel.Set(this._rawData, "trial_info", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActivePlanPhaseOrder;
        foreach (var item in this.AdjustmentIntervals)
        {
            item.Validate();
        }
        _ = this.AutoCollection;
        this.BillingCycleAnchorConfiguration.Validate();
        _ = this.BillingCycleDay;
        _ = this.CreatedAt;
        _ = this.CurrentBillingPeriodEndDate;
        _ = this.CurrentBillingPeriodStartDate;
        this.Customer.Validate();
        _ = this.DefaultInvoiceMemo;
        foreach (var item in this.DiscountIntervals)
        {
            item.Validate();
        }
        _ = this.EndDate;
        foreach (var item in this.FixedFeeQuantitySchedule)
        {
            item.Validate();
        }
        _ = this.InvoicingThreshold;
        foreach (var item in this.MaximumIntervals)
        {
            item.Validate();
        }
        _ = this.Metadata;
        foreach (var item in this.MinimumIntervals)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.NetTerms;
        this.PendingSubscriptionChange?.Validate();
        this.Plan?.Validate();
        foreach (var item in this.PriceIntervals)
        {
            item.Validate();
        }
        this.RedeemedCoupon?.Validate();
        _ = this.StartDate;
        this.Status.Validate();
        this.TrialInfo.Validate();
    }

    [System::Obsolete(
        "Required properties are deprecated: discount_intervals, maximum_intervals, minimum_intervals"
    )]
    public Subscription() { }

    [System::Obsolete(
        "Required properties are deprecated: discount_intervals, maximum_intervals, minimum_intervals"
    )]
    public Subscription(Subscription subscription)
        : base(subscription) { }

    [System::Obsolete(
        "Required properties are deprecated: discount_intervals, maximum_intervals, minimum_intervals"
    )]
    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete(
        "Required properties are deprecated: discount_intervals, maximum_intervals, minimum_intervals"
    )]
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFromRaw.FromRawUnchecked"/>
    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFromRaw : IFromRawJson<Subscription>
{
    /// <inheritdoc/>
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DiscountIntervalConverter))]
public record class DiscountInterval
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public System::DateTimeOffset? EndDate
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                amount: (x) => x.EndDate,
                percentage: (x) => x.EndDate,
                usage: (x) => x.EndDate
            );
        }
    }

    public System::DateTimeOffset StartDate
    {
        get
        {
            return Match(
                amount: (x) => x.StartDate,
                percentage: (x) => x.StartDate,
                usage: (x) => x.StartDate
            );
        }
    }

    public DiscountInterval(AmountDiscountInterval value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DiscountInterval(PercentageDiscountInterval value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DiscountInterval(UsageDiscountInterval value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DiscountInterval(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AmountDiscountInterval"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAmount(out var value)) {
    ///     // `value` is of type `AmountDiscountInterval`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscountInterval? value)
    {
        value = this.Value as AmountDiscountInterval;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PercentageDiscountInterval"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercentage(out var value)) {
    ///     // `value` is of type `PercentageDiscountInterval`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscountInterval? value)
    {
        value = this.Value as PercentageDiscountInterval;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UsageDiscountInterval"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUsage(out var value)) {
    ///     // `value` is of type `UsageDiscountInterval`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscountInterval? value)
    {
        value = this.Value as UsageDiscountInterval;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AmountDiscountInterval value) => {...},
    ///     (PercentageDiscountInterval value) => {...},
    ///     (UsageDiscountInterval value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<AmountDiscountInterval> amount,
        System::Action<PercentageDiscountInterval> percentage,
        System::Action<UsageDiscountInterval> usage
    )
    {
        switch (this.Value)
        {
            case AmountDiscountInterval value:
                amount(value);
                break;
            case PercentageDiscountInterval value:
                percentage(value);
                break;
            case UsageDiscountInterval value:
                usage(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of DiscountInterval"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AmountDiscountInterval value) => {...},
    ///     (PercentageDiscountInterval value) => {...},
    ///     (UsageDiscountInterval value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<AmountDiscountInterval, T> amount,
        System::Func<PercentageDiscountInterval, T> percentage,
        System::Func<UsageDiscountInterval, T> usage
    )
    {
        return this.Value switch
        {
            AmountDiscountInterval value => amount(value),
            PercentageDiscountInterval value => percentage(value),
            UsageDiscountInterval value => usage(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of DiscountInterval"
            ),
        };
    }

    public static implicit operator DiscountInterval(AmountDiscountInterval value) => new(value);

    public static implicit operator DiscountInterval(PercentageDiscountInterval value) =>
        new(value);

    public static implicit operator DiscountInterval(UsageDiscountInterval value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DiscountInterval");
        }
        this.Switch(
            (amount) => amount.Validate(),
            (percentage) => percentage.Validate(),
            (usage) => usage.Validate()
        );
    }

    public virtual bool Equals(DiscountInterval? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class DiscountIntervalConverter : JsonConverter<DiscountInterval>
{
    public override DiscountInterval? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = element.GetProperty("discount_type").GetString();
        }
        catch
        {
            discountType = null;
        }

        switch (discountType)
        {
            case "amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscountInterval>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "usage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new DiscountInterval(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountInterval value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SubscriptionStatusConverter))]
public enum SubscriptionStatus
{
    Active,
    Ended,
    Upcoming,
}

sealed class SubscriptionStatusConverter : JsonConverter<SubscriptionStatus>
{
    public override SubscriptionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => SubscriptionStatus.Active,
            "ended" => SubscriptionStatus.Ended,
            "upcoming" => SubscriptionStatus.Upcoming,
            _ => (SubscriptionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionStatus.Active => "active",
                SubscriptionStatus.Ended => "ended",
                SubscriptionStatus.Upcoming => "upcoming",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
