using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Customers = Orb.Models.Customers;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Plans = Orb.Models.Plans;
using Serialization = System.Text.Json.Serialization;
using SubscriptionProperties = Orb.Models.Subscriptions.SubscriptionProperties;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// A [subscription](/core-concepts#subscription) represents the purchase of a plan
/// by a customer.
///
/// By default, subscriptions begin on the day that they're created and renew automatically
/// for each billing cycle at the cadence that's configured in the plan definition.
///
/// Subscriptions also default to **beginning of month alignment**, which means the
/// first invoice issued for the subscription will have pro-rated charges between
/// the `start_date` and the first of the following month. Subsequent billing periods
/// will always start and end on a month boundary (e.g. subsequent month starts for
/// monthly billing).
///
/// Depending on the plan configuration, any _flat_ recurring fees will be billed
/// either at the beginning (in-advance) or end (in-arrears) of each billing cycle.
/// Plans default to **in-advance billing**. Usage-based fees are billed in arrears
/// as usage is accumulated. In the normal course of events, you can expect an invoice
/// to contain usage-based charges for the previous period, and a recurring fee for
/// the following period.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Subscription>))]
public sealed record class Subscription : Orb::ModelBase, Orb::IFromRaw<Subscription>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The current plan phase that is active, only if the subscription's plan has phases.
    /// </summary>
    public required long? ActivePlanPhaseOrder
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "active_plan_phase_order",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "active_plan_phase_order",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["active_plan_phase_order"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The adjustment intervals for this subscription sorted by the start_date of
    /// the adjustment interval.
    /// </summary>
    public required Generic::List<Models::AdjustmentInterval> AdjustmentIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_intervals", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment_intervals",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::AdjustmentInterval>>(
                    element
                ) ?? throw new System::ArgumentNullException("adjustment_intervals");
        }
        set
        {
            this.Properties["adjustment_intervals"] = Json::JsonSerializer.SerializeToElement(
                value
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
            if (!this.Properties.TryGetValue("auto_collection", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "auto_collection",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.Properties["auto_collection"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::BillingCycleAnchorConfiguration BillingCycleAnchorConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "billing_cycle_anchor_configuration",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "billing_cycle_anchor_configuration",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::BillingCycleAnchorConfiguration>(
                    element
                ) ?? throw new System::ArgumentNullException("billing_cycle_anchor_configuration");
        }
        set
        {
            this.Properties["billing_cycle_anchor_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The day of the month on which the billing cycle is anchored. If the maximum
    /// number of days in a month is greater than this value, the last day of the month
    /// is the billing cycle day (e.g. billing_cycle_day=31 for April means the billing
    /// period begins on the 30th.
    /// </summary>
    public required long BillingCycleDay
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_cycle_day", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "billing_cycle_day",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.Properties["billing_cycle_day"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end of the current billing period. This is an exclusive timestamp, such
    /// that the instant returned is not part of the billing period. Set to null for
    /// subscriptions that are not currently active.
    /// </summary>
    public required System::DateTime? CurrentBillingPeriodEndDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "current_billing_period_end_date",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "current_billing_period_end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.Properties["current_billing_period_end_date"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The start date of the current billing period. This is an inclusive timestamp;
    /// the instant returned is exactly the beginning of the billing period. Set to
    /// null if the subscription is not currently active.
    /// </summary>
    public required System::DateTime? CurrentBillingPeriodStartDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "current_billing_period_start_date",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "current_billing_period_start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.Properties["current_billing_period_start_date"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// A customer is a buyer of your products, and the other party to the billing relationship.
    ///
    /// In Orb, customers are assigned system generated identifiers automatically,
    /// but it's often desirable to have these match existing identifiers in your system.
    /// To avoid having to denormalize Orb ID information, you can pass in an `external_customer_id`
    /// with your own identifier. See [Customer ID Aliases](/events-and-metrics/customer-aliases)
    /// for further information about how these aliases work in Orb.
    ///
    /// In addition to having an identifier in your system, a customer may exist in
    /// a payment provider solution like Stripe. Use the `payment_provider_id` and the
    /// `payment_provider` enum field to express this mapping.
    ///
    /// A customer also has a timezone (from the standard [IANA timezone database](https://www.iana.org/time-zones)),
    /// which defaults to your account's timezone. See [Timezone localization](/essentials/timezones)
    /// for information on what this timezone parameter influences within Orb.
    /// </summary>
    public required Customers::Customer Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Customers::Customer>(element)
                ?? throw new System::ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Determines the default memo on this subscriptions' invoices. Note that if this
    /// is not provided, it is determined by the plan configuration.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get
        {
            if (!this.Properties.TryGetValue("default_invoice_memo", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "default_invoice_memo",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["default_invoice_memo"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The discount intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    public required Generic::List<SubscriptionProperties::DiscountInterval> DiscountIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_intervals", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_intervals",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<SubscriptionProperties::DiscountInterval>>(
                    element
                ) ?? throw new System::ArgumentNullException("discount_intervals");
        }
        set
        {
            this.Properties["discount_intervals"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The date Orb stops billing for this subscription.
    /// </summary>
    public required System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Generic::List<Models::FixedFeeQuantityScheduleEntry> FixedFeeQuantitySchedule
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "fixed_fee_quantity_schedule",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "fixed_fee_quantity_schedule",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::FixedFeeQuantityScheduleEntry>>(
                    element
                ) ?? throw new System::ArgumentNullException("fixed_fee_quantity_schedule");
        }
        set
        {
            this.Properties["fixed_fee_quantity_schedule"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required string? InvoicingThreshold
    {
        get
        {
            if (!this.Properties.TryGetValue("invoicing_threshold", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoicing_threshold",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["invoicing_threshold"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The maximum intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    public required Generic::List<Models::MaximumInterval> MaximumIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_intervals", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "maximum_intervals",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::MaximumInterval>>(element)
                ?? throw new System::ArgumentNullException("maximum_intervals");
        }
        set
        {
            this.Properties["maximum_intervals"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Generic::Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "metadata",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string>>(element)
                ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The minimum intervals for this subscription sorted by the start_date. This
    /// field is deprecated in favor of `adjustment_intervals`.
    /// </summary>
    public required Generic::List<Models::MinimumInterval> MinimumIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_intervals", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_intervals",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::MinimumInterval>>(element)
                ?? throw new System::ArgumentNullException("minimum_intervals");
        }
        set
        {
            this.Properties["minimum_intervals"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The name of the subscription.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Determines the difference between the invoice issue date for subscription invoices
    /// as the date that they are due. A value of `0` here represents that the invoice
    /// is due on issue, whereas a value of `30` represents that the customer has a
    /// month to pay the invoice.
    /// </summary>
    public required long NetTerms
    {
        get
        {
            if (!this.Properties.TryGetValue("net_terms", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "net_terms",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["net_terms"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A pending subscription change if one exists on this subscription.
    /// </summary>
    public required Models::SubscriptionChangeMinified? PendingSubscriptionChange
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "pending_subscription_change",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "pending_subscription_change",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::SubscriptionChangeMinified?>(element);
        }
        set
        {
            this.Properties["pending_subscription_change"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The [Plan](/core-concepts#plan-and-price) resource represents a plan that can
    /// be subscribed to by a customer. Plans define the billing behavior of the subscription.
    /// You can see more about how to configure prices in the [Price resource](/reference/price).
    /// </summary>
    public required Plans::Plan? Plan
    {
        get
        {
            if (!this.Properties.TryGetValue("plan", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("plan", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Plans::Plan?>(element);
        }
        set { this.Properties["plan"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The price intervals for this subscription.
    /// </summary>
    public required Generic::List<Models::PriceInterval> PriceIntervals
    {
        get
        {
            if (!this.Properties.TryGetValue("price_intervals", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_intervals",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::PriceInterval>>(element)
                ?? throw new System::ArgumentNullException("price_intervals");
        }
        set { this.Properties["price_intervals"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::CouponRedemption? RedeemedCoupon
    {
        get
        {
            if (!this.Properties.TryGetValue("redeemed_coupon", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "redeemed_coupon",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::CouponRedemption?>(element);
        }
        set { this.Properties["redeemed_coupon"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The date Orb starts billing for this subscription.
    /// </summary>
    public required System::DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required SubscriptionProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "status",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<SubscriptionProperties::Status>(element)
                ?? throw new System::ArgumentNullException("status");
        }
        set { this.Properties["status"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::SubscriptionTrialInfo TrialInfo
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_info", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "trial_info",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::SubscriptionTrialInfo>(element)
                ?? throw new System::ArgumentNullException("trial_info");
        }
        set { this.Properties["trial_info"] = Json::JsonSerializer.SerializeToElement(value); }
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
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
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

    public Subscription() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Subscription(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Subscription FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
