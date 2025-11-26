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
[JsonConverter(typeof(ModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
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
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The current plan phase that is active, only if the subscription's plan has phases.
    /// </summary>
    public required long? ActivePlanPhaseOrder
    {
        get
        {
            if (!this._rawData.TryGetValue("active_plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["active_plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The adjustment intervals for this subscription sorted by the start_date of
    /// the adjustment interval.
    /// </summary>
    public required IReadOnlyList<AdjustmentInterval> AdjustmentIntervals
    {
        get
        {
            if (!this._rawData.TryGetValue("adjustment_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_intervals' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_intervals",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<AdjustmentInterval>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustment_intervals' cannot be null",
                    new System::ArgumentNullException("adjustment_intervals")
                );
        }
        init
        {
            this._rawData["adjustment_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines whether issued invoices for this subscription will automatically
    /// be charged with the saved payment method on the due date. This property defaults
    /// to the plan's behavior. If null, defaults to the customer's setting.
    /// </summary>
    public required bool? AutoCollection
    {
        get
        {
            if (!this._rawData.TryGetValue("auto_collection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BillingCycleAnchorConfiguration BillingCycleAnchorConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "billing_cycle_anchor_configuration",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'billing_cycle_anchor_configuration' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "billing_cycle_anchor_configuration",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<BillingCycleAnchorConfiguration>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'billing_cycle_anchor_configuration' cannot be null",
                    new System::ArgumentNullException("billing_cycle_anchor_configuration")
                );
        }
        init
        {
            this._rawData["billing_cycle_anchor_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The day of the month on which the billing cycle is anchored. If the maximum
    /// number of days in a month is greater than this value, the last day of the
    /// month is the billing cycle day (e.g. billing_cycle_day=31 for April means
    /// the billing period begins on the 30th.
    /// </summary>
    public required long BillingCycleDay
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_day", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'billing_cycle_day' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "billing_cycle_day",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billing_cycle_day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
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
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (
                !this._rawData.TryGetValue(
                    "current_billing_period_end_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["current_billing_period_end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (
                !this._rawData.TryGetValue(
                    "current_billing_period_start_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["current_billing_period_start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        get
        {
            if (!this._rawData.TryGetValue("customer", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Customer>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentNullException("customer")
                );
        }
        init
        {
            this._rawData["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines the default memo on this subscriptions' invoices. Note that if
    /// this is not provided, it is determined by the plan configuration.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get
        {
            if (!this._rawData.TryGetValue("default_invoice_memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["default_invoice_memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._rawData.TryGetValue("discount_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_intervals' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_intervals",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<DiscountInterval>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discount_intervals' cannot be null",
                    new System::ArgumentNullException("discount_intervals")
                );
        }
        init
        {
            this._rawData["discount_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The date Orb stops billing for this subscription.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            if (!this._rawData.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required IReadOnlyList<FixedFeeQuantityScheduleEntry> FixedFeeQuantitySchedule
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_fee_quantity_schedule", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'fixed_fee_quantity_schedule' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "fixed_fee_quantity_schedule",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<FixedFeeQuantityScheduleEntry>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'fixed_fee_quantity_schedule' cannot be null",
                    new System::ArgumentNullException("fixed_fee_quantity_schedule")
                );
        }
        init
        {
            this._rawData["fixed_fee_quantity_schedule"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? InvoicingThreshold
    {
        get
        {
            if (!this._rawData.TryGetValue("invoicing_threshold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoicing_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._rawData.TryGetValue("maximum_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_intervals' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_intervals",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<MaximumInterval>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'maximum_intervals' cannot be null",
                    new System::ArgumentNullException("maximum_intervals")
                );
        }
        init
        {
            this._rawData["maximum_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._rawData.TryGetValue("minimum_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_intervals' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_intervals",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<MinimumInterval>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'minimum_intervals' cannot be null",
                    new System::ArgumentNullException("minimum_intervals")
                );
        }
        init
        {
            this._rawData["minimum_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the subscription.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines the difference between the invoice issue date for subscription
    /// invoices as the date that they are due. A value of `0` here represents that
    /// the invoice is due on issue, whereas a value of `30` represents that the customer
    /// has a month to pay the invoice.
    /// </summary>
    public required long NetTerms
    {
        get
        {
            if (!this._rawData.TryGetValue("net_terms", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'net_terms' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "net_terms",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A pending subscription change if one exists on this subscription.
    /// </summary>
    public required SubscriptionChangeMinified? PendingSubscriptionChange
    {
        get
        {
            if (!this._rawData.TryGetValue("pending_subscription_change", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionChangeMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["pending_subscription_change"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The [Plan](/core-concepts#plan-and-price) resource represents a plan that
    /// can be subscribed to by a customer. Plans define the billing behavior of
    /// the subscription. You can see more about how to configure prices in the [Price resource](/reference/price).
    /// </summary>
    public required Plans::Plan? Plan
    {
        get
        {
            if (!this._rawData.TryGetValue("plan", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Plans::Plan?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["plan"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price intervals for this subscription.
    /// </summary>
    public required IReadOnlyList<PriceInterval> PriceIntervals
    {
        get
        {
            if (!this._rawData.TryGetValue("price_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_intervals' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "price_intervals",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<PriceInterval>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'price_intervals' cannot be null",
                    new System::ArgumentNullException("price_intervals")
                );
        }
        init
        {
            this._rawData["price_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CouponRedemption? RedeemedCoupon
    {
        get
        {
            if (!this._rawData.TryGetValue("redeemed_coupon", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CouponRedemption?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["redeemed_coupon"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The date Orb starts billing for this subscription.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            if (!this._rawData.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
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
            this._rawData["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required SubscriptionTrialInfo TrialInfo
    {
        get
        {
            if (!this._rawData.TryGetValue("trial_info", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'trial_info' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "trial_info",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<SubscriptionTrialInfo>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'trial_info' cannot be null",
                    new System::ArgumentNullException("trial_info")
                );
        }
        init
        {
            this._rawData["trial_info"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete(
            "Required properties are deprecated: discount_intervals, maximum_intervals, minimum_intervals"
        ),
        SetsRequiredMembers
    ]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFromRaw : IFromRaw<Subscription>
{
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DiscountIntervalConverter))]
public record class DiscountInterval
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public DiscountInterval(AmountDiscountInterval value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public DiscountInterval(PercentageDiscountInterval value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public DiscountInterval(UsageDiscountInterval value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public DiscountInterval(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscountInterval? value)
    {
        value = this.Value as AmountDiscountInterval;
        return value != null;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscountInterval? value)
    {
        value = this.Value as PercentageDiscountInterval;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscountInterval? value)
    {
        value = this.Value as UsageDiscountInterval;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DiscountInterval");
        }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = json.GetProperty("discount_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "usage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new DiscountInterval(json);
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
