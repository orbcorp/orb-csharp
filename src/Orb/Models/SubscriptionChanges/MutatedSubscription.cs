using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;
using Orb.Models.Plans;
using System = System;

namespace Orb.Models.SubscriptionChanges;

[JsonConverter(typeof(ModelConverter<MutatedSubscription>))]
public sealed record class MutatedSubscription : ModelBase, IFromRaw<MutatedSubscription>
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
    /// The current plan phase that is active, only if the subscription's plan has phases.
    /// </summary>
    public required long? ActivePlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("active_plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["active_plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The adjustment intervals for this subscription sorted by the start_date of
    /// the adjustment interval.
    /// </summary>
    public required List<AdjustmentInterval> AdjustmentIntervals
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment_intervals", out JsonElement element))
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
            this._properties["adjustment_intervals"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("auto_collection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["auto_collection"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["billing_cycle_anchor_configuration"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
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
            if (!this._properties.TryGetValue("billing_cycle_day", out JsonElement element))
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
            this._properties["billing_cycle_day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
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
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["current_billing_period_end_date"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["current_billing_period_start_date"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
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
            if (!this._properties.TryGetValue("customer", out JsonElement element))
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
            this._properties["customer"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("default_invoice_memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["default_invoice_memo"] = JsonSerializer.SerializeToElement(
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
    public required List<DiscountInterval> DiscountIntervals
    {
        get
        {
            if (!this._properties.TryGetValue("discount_intervals", out JsonElement element))
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
            this._properties["discount_intervals"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<FixedFeeQuantityScheduleEntry> FixedFeeQuantitySchedule
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "fixed_fee_quantity_schedule",
                    out JsonElement element
                )
            )
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
            this._properties["fixed_fee_quantity_schedule"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? InvoicingThreshold
    {
        get
        {
            if (!this._properties.TryGetValue("invoicing_threshold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoicing_threshold"] = JsonSerializer.SerializeToElement(
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
    public required List<MaximumInterval> MaximumIntervals
    {
        get
        {
            if (!this._properties.TryGetValue("maximum_intervals", out JsonElement element))
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
            this._properties["maximum_intervals"] = JsonSerializer.SerializeToElement(
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
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
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
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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
    public required List<MinimumInterval> MinimumIntervals
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_intervals", out JsonElement element))
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
            this._properties["minimum_intervals"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("net_terms", out JsonElement element))
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
            this._properties["net_terms"] = JsonSerializer.SerializeToElement(
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
            if (
                !this._properties.TryGetValue(
                    "pending_subscription_change",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<SubscriptionChangeMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["pending_subscription_change"] = JsonSerializer.SerializeToElement(
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
    public required Plan? Plan
    {
        get
        {
            if (!this._properties.TryGetValue("plan", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Plan?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price intervals for this subscription.
    /// </summary>
    public required List<PriceInterval> PriceIntervals
    {
        get
        {
            if (!this._properties.TryGetValue("price_intervals", out JsonElement element))
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
            this._properties["price_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CouponRedemption? RedeemedCoupon
    {
        get
        {
            if (!this._properties.TryGetValue("redeemed_coupon", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CouponRedemption?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["redeemed_coupon"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
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
            this._properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.SubscriptionChanges.Status> Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.SubscriptionChanges.Status>
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

    public required SubscriptionTrialInfo TrialInfo
    {
        get
        {
            if (!this._properties.TryGetValue("trial_info", out JsonElement element))
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
            this._properties["trial_info"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The resources that were changed as part of this operation. Only present when
    /// fetched through the subscription changes API or if the `include_changed_resources`
    /// parameter was passed in the request.
    /// </summary>
    public ChangedSubscriptionResources? ChangedResources
    {
        get
        {
            if (!this._properties.TryGetValue("changed_resources", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ChangedSubscriptionResources?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["changed_resources"] = JsonSerializer.SerializeToElement(
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
        this.ChangedResources?.Validate();
    }

    public MutatedSubscription() { }

    public MutatedSubscription(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MutatedSubscription(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MutatedSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(DiscountIntervalConverter))]
public record class DiscountInterval
{
    public object Value { get; private init; }

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

    public DiscountInterval(AmountDiscountInterval value)
    {
        Value = value;
    }

    public DiscountInterval(PercentageDiscountInterval value)
    {
        Value = value;
    }

    public DiscountInterval(UsageDiscountInterval value)
    {
        Value = value;
    }

    DiscountInterval(UnknownVariant value)
    {
        Value = value;
    }

    public static DiscountInterval CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DiscountInterval");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new DiscountInterval(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'AmountDiscountInterval'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percentage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new DiscountInterval(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PercentageDiscountInterval'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "usage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new DiscountInterval(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UsageDiscountInterval'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountInterval value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(global::Orb.Models.SubscriptionChanges.StatusConverter))]
public enum Status
{
    Active,
    Ended,
    Upcoming,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.SubscriptionChanges.Status>
{
    public override global::Orb.Models.SubscriptionChanges.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => global::Orb.Models.SubscriptionChanges.Status.Active,
            "ended" => global::Orb.Models.SubscriptionChanges.Status.Ended,
            "upcoming" => global::Orb.Models.SubscriptionChanges.Status.Upcoming,
            _ => (global::Orb.Models.SubscriptionChanges.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.SubscriptionChanges.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.SubscriptionChanges.Status.Active => "active",
                global::Orb.Models.SubscriptionChanges.Status.Ended => "ended",
                global::Orb.Models.SubscriptionChanges.Status.Upcoming => "upcoming",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
