using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;
using Orb.Models.Plans;
using Orb.Models.SubscriptionChanges.MutatedSubscriptionProperties;

namespace Orb.Models.SubscriptionChanges;

[JsonConverter(typeof(ModelConverter<MutatedSubscription>))]
public sealed record class MutatedSubscription : ModelBase, IFromRaw<MutatedSubscription>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
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
    /// The current plan phase that is active, only if the subscription's plan has phases.
    /// </summary>
    public required long? ActivePlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("active_plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["active_plan_phase_order"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("adjustment_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_intervals' cannot be null",
                    new ArgumentOutOfRangeException(
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
                    new ArgumentNullException("adjustment_intervals")
                );
        }
        set
        {
            this.Properties["adjustment_intervals"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("auto_collection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["auto_collection"] = JsonSerializer.SerializeToElement(
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
                !this.Properties.TryGetValue(
                    "billing_cycle_anchor_configuration",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'billing_cycle_anchor_configuration' cannot be null",
                    new ArgumentOutOfRangeException(
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
                    new ArgumentNullException("billing_cycle_anchor_configuration")
                );
        }
        set
        {
            this.Properties["billing_cycle_anchor_configuration"] =
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
            if (!this.Properties.TryGetValue("billing_cycle_day", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'billing_cycle_day' cannot be null",
                    new ArgumentOutOfRangeException(
                        "billing_cycle_day",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["billing_cycle_day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end of the current billing period. This is an exclusive timestamp, such
    /// that the instant returned is not part of the billing period. Set to null
    /// for subscriptions that are not currently active.
    /// </summary>
    public required DateTime? CurrentBillingPeriodEndDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "current_billing_period_end_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["current_billing_period_end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the current billing period. This is an inclusive timestamp;
    /// the instant returned is exactly the beginning of the billing period. Set
    /// to null if the subscription is not currently active.
    /// </summary>
    public required DateTime? CurrentBillingPeriodStartDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "current_billing_period_start_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["current_billing_period_start_date"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// A customer is a buyer of your products, and the other party to the billing relationship.
    ///
    /// In Orb, customers are assigned system generated identifiers automatically,
    /// but it's often desirable to have these match existing identifiers in your
    /// system. To avoid having to denormalize Orb ID information, you can pass in
    /// an `external_customer_id` with your own identifier. See [Customer ID Aliases](/events-and-metrics/customer-aliases)
    /// for further information about how these aliases work in Orb.
    ///
    /// In addition to having an identifier in your system, a customer may exist
    /// in a payment provider solution like Stripe. Use the `payment_provider_id`
    /// and the `payment_provider` enum field to express this mapping.
    ///
    /// A customer also has a timezone (from the standard [IANA timezone database](https://www.iana.org/time-zones)),
    /// which defaults to your account's timezone. See [Timezone localization](/essentials/timezones)
    /// for information on what this timezone parameter influences within Orb.
    /// </summary>
    public required Customer Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Customer>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentNullException("customer")
                );
        }
        set
        {
            this.Properties["customer"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("default_invoice_memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["default_invoice_memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The discount intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    public required List<DiscountInterval> DiscountIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_intervals' cannot be null",
                    new ArgumentOutOfRangeException(
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
                    new ArgumentNullException("discount_intervals")
                );
        }
        set
        {
            this.Properties["discount_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The date Orb stops billing for this subscription.
    /// </summary>
    public required DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
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
                !this.Properties.TryGetValue("fixed_fee_quantity_schedule", out JsonElement element)
            )
                throw new OrbInvalidDataException(
                    "'fixed_fee_quantity_schedule' cannot be null",
                    new ArgumentOutOfRangeException(
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
                    new ArgumentNullException("fixed_fee_quantity_schedule")
                );
        }
        set
        {
            this.Properties["fixed_fee_quantity_schedule"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? InvoicingThreshold
    {
        get
        {
            if (!this.Properties.TryGetValue("invoicing_threshold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["invoicing_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    public required List<MaximumInterval> MaximumIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_intervals' cannot be null",
                    new ArgumentOutOfRangeException(
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
                    new ArgumentNullException("maximum_intervals")
                );
        }
        set
        {
            this.Properties["maximum_intervals"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    public required List<MinimumInterval> MinimumIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_intervals' cannot be null",
                    new ArgumentOutOfRangeException(
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
                    new ArgumentNullException("minimum_intervals")
                );
        }
        set
        {
            this.Properties["minimum_intervals"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines the difference between the invoice issue date for subscription
    /// invoices as the date that they are due. A value of `0` here represents that
    /// the invoice is due on issue, whereas a value of `30` represents that the
    /// customer has a month to pay the invoice.
    /// </summary>
    public required long NetTerms
    {
        get
        {
            if (!this.Properties.TryGetValue("net_terms", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'net_terms' cannot be null",
                    new ArgumentOutOfRangeException("net_terms", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["net_terms"] = JsonSerializer.SerializeToElement(
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
                !this.Properties.TryGetValue("pending_subscription_change", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<SubscriptionChangeMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["pending_subscription_change"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The [Plan](/core-concepts#plan-and-price) resource represents a plan that
    /// can be subscribed to by a customer. Plans define the billing behavior of the
    /// subscription. You can see more about how to configure prices in the [Price resource](/reference/price).
    /// </summary>
    public required Plan? Plan
    {
        get
        {
            if (!this.Properties.TryGetValue("plan", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Plan?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["plan"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("price_intervals", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_intervals' cannot be null",
                    new ArgumentOutOfRangeException("price_intervals", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<PriceInterval>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'price_intervals' cannot be null",
                    new ArgumentNullException("price_intervals")
                );
        }
        set
        {
            this.Properties["price_intervals"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CouponRedemption? RedeemedCoupon
    {
        get
        {
            if (!this.Properties.TryGetValue("redeemed_coupon", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CouponRedemption?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["redeemed_coupon"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The date Orb starts billing for this subscription.
    /// </summary>
    public required DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
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

    public required SubscriptionTrialInfo TrialInfo
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_info", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'trial_info' cannot be null",
                    new ArgumentOutOfRangeException("trial_info", "Missing required argument")
                );

            return JsonSerializer.Deserialize<SubscriptionTrialInfo>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'trial_info' cannot be null",
                    new ArgumentNullException("trial_info")
                );
        }
        set
        {
            this.Properties["trial_info"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("changed_resources", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ChangedSubscriptionResources?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["changed_resources"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MutatedSubscription(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MutatedSubscription FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
