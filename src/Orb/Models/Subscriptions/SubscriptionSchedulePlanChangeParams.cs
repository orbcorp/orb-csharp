using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to change an existing subscription's plan. It returns
/// the serialized updated subscription object.
///
/// The body parameter `change_option` determines when the plan change occurs. Orb
/// supports three options: - `end_of_subscription_term`: changes the plan at the
/// end of the existing plan's term.     - Issuing this plan change request for a
/// monthly subscription will keep the existing plan active until the start
/// of the subsequent month. Issuing this plan change request for a yearly subscription
/// will keep the existing plan active for       the full year. Charges incurred
/// in the remaining period will be invoiced as normal.     - Example: The plan is
/// billed monthly on the 1st of the month, the request is made on January 15th, so
/// the plan will be       changed on February 1st, and invoice will be issued on
/// February 1st for the last month of the original plan. - `immediate`: changes the
/// plan immediately.     - Subscriptions that have their plan changed with this option
/// will move to the new plan immediately, and be invoiced       immediately.
/// - This invoice will include any usage fees incurred in the billing period up to
/// the change, along with any prorated       recurring fees for the billing period,
/// if applicable.     - Example: The plan is billed monthly on the 1st of the month,
/// the request is made on January 15th, so the plan will be       changed on January
/// 15th, and an invoice will be issued for the partial month, from January 1 to January
/// 15, on the       original plan. - `requested_date`: changes the plan on the requested
/// date (`change_date`).     - If no timezone is provided, the customer's timezone
/// is used. The `change_date` body parameter is required if this option       is
/// chosen.     - Example: The plan is billed monthly on the 1st of the month, the
/// request is made on January 15th, with a requested       `change_date` of February
/// 15th, so the plan will be changed on February 15th, and invoices will be issued
/// on February 1st       and February 15th.
///
/// Note that one of `plan_id` or `external_plan_id` is required in the request body
/// for this operation.
///
/// ## Customize your customer's subscriptions
///
/// Prices and adjustments in a plan can be added, removed, or replaced on the subscription
/// when you schedule the plan change. This is useful when a customer has prices
/// that differ from the default prices for a specific plan.
///
/// <Note> This feature is only available for accounts that have migrated to Subscription
/// Overrides Version 2. You can find your Subscription Overrides Version at the
/// bottom of your [Plans page](https://app.withorb.com/plans) </Note>
///
/// ### Adding Prices
///
/// To add prices, provide a list of objects with the key `add_prices`. An object
/// in the list must specify an existing add-on price with a `price_id` or `external_price_id`
/// field, or create a new add-on price by including an object with the key `price`,
/// identical to what would be used in the request body for the [create price endpoint](/api-reference/price/create-price).
/// See the [Price resource](/product-catalog/price-configuration) for the specification
/// of different price model configurations possible in this object.
///
/// If the plan has phases, each object in the list must include a number with `plan_phase_order`
/// key to indicate which phase the price should be added to.
///
/// An object in the list can specify an optional `start_date` and optional `end_date`.
/// If `start_date` is unspecified, the start of the phase / plan change time will
/// be used. If `end_date` is unspecified, it will finish at the end of the phase
/// / have no end time.
///
/// An object in the list can specify an optional `minimum_amount`, `maximum_amount`,
/// or `discounts`. This will create adjustments which apply only to this price.
///
/// Additionally, an object in the list can specify an optional `reference_id`. This
/// ID can be used to reference this price when [adding an adjustment](#adding-adjustments)
/// in the same API call. However the ID is _transient_ and cannot be used to refer
/// to the price in future API calls.
///
/// ### Removing Prices
///
/// To remove prices, provide a list of objects with the key `remove_prices`. An
/// object in the list must specify a plan price with either a `price_id` or `external_price_id` field.
///
/// ### Replacing Prices
///
/// To replace prices, provide a list of objects with the key `replace_prices`. An
/// object in the list must specify a plan price to replace with the `replaces_price_id`
/// key, and it must specify a price to replace it with by either referencing an existing
/// add-on price with a `price_id` or `external_price_id` field, or by creating a
/// new add-on price by including an object with the key `price`, identical to what
/// would be used in the request body for the [create price endpoint](/api-reference/price/create-price).
/// See the [Price resource](/product-catalog/price-configuration) for the specification
/// of different price model configurations possible in this object.
///
/// For fixed fees, an object in the list can supply a `fixed_price_quantity` instead
/// of a `price`, `price_id`, or `external_price_id` field. This will update only
/// the quantity for the price, similar to the [Update price quantity](/api-reference/subscription/update-price-quantity) endpoint.
///
/// The replacement price will have the same phase, if applicable, and the same start
/// and end dates as the price it replaces.
///
/// An object in the list can specify an optional `minimum_amount`, `maximum_amount`,
/// or `discounts`. This will create adjustments which apply only to this price.
///
/// Additionally, an object in the list can specify an optional `reference_id`. This
/// ID can be used to reference the replacement price when [adding an adjustment](#adding-adjustments)
/// in the same API call. However the ID is _transient_ and cannot be used to refer
/// to the price in future API calls.
///
/// ### Adding adjustments
///
/// To add adjustments, provide a list of objects with the key `add_adjustments`.
/// An object in the list must include an object with the key `adjustment`, identical
/// to the adjustment object in the [add/edit price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).
///
/// If the plan has phases, each object in the list must include a number with `plan_phase_order`
/// key to indicate which phase the adjustment should be added to.
///
/// An object in the list can specify an optional `start_date` and optional `end_date`.
/// If `start_date` is unspecified, the start of the phase / plan change time will
/// be used. If `end_date` is unspecified, it will finish at the end of the phase
/// / have no end time.
///
/// ### Removing adjustments
///
/// To remove adjustments, provide a list of objects with the key `remove_adjustments`.
/// An object in the list must include a key, `adjustment_id`, with the ID of the
/// adjustment to be removed.
///
/// ### Replacing adjustments
///
/// To replace adjustments, provide a list of objects with the key `replace_adjustments`.
/// An object in the list must specify a plan adjustment to replace with the `replaces_adjustment_id`
/// key, and it must specify an adjustment to replace it with by including an object
/// with the key `adjustment`, identical to the adjustment object in the [add/edit
/// price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).
///
/// The replacement adjustment will have the same phase, if applicable, and the same
/// start and end dates as the adjustment it replaces.
///
/// ## Price overrides (DEPRECATED)
///
/// <Note> Price overrides are being phased out in favor adding/removing/replacing
/// prices. (See [Customize your customer's subscriptions](/api-reference/subscription/schedule-plan-change)) </Note>
///
/// Price overrides are used to update some or all prices in a plan for the specific
/// subscription being created. This is useful when a new customer has negotiated
/// a rate that is unique to the customer.
///
/// To override prices, provide a list of objects with the key `price_overrides`.
/// The price object in the list of overrides is expected to contain the existing
/// price id, the `model_type` and configuration. (See the [Price resource](/product-catalog/price-configuration)
/// for the specification of different price model configurations.) The numerical
/// values can be updated, but the billable metric, cadence, type, and name of a price
/// can not be overridden.
///
/// ### Maximums, and minimums Price overrides are used to update some or all prices
/// in the target plan. Minimums and maximums, much like price overrides, can be
/// useful when a new customer has negotiated a new or different minimum or maximum
/// spend cap than the default for the plan. The request format for maximums and
/// minimums is the same as those in [subscription creation](create-subscription).
///
/// ## Scheduling multiple plan changes When scheduling multiple plan changes with
/// the same date, the latest plan change on that day takes effect.
///
/// ## Prorations for in-advance fees By default, Orb calculates the prorated difference
/// in any fixed fees when making a plan change, adjusting the customer balance as
/// needed. For details on this behavior, see [Modifying subscriptions](/product-catalog/modifying-subscriptions#prorations-for-in-advance-fees).
/// </summary>
public sealed record class SubscriptionSchedulePlanChangeParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    public required ApiEnum<string, ChangeOption> ChangeOption
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("change_option", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'change_option' cannot be null",
                    new ArgumentOutOfRangeException("change_option", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ChangeOption>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["change_option"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional adjustments to be added to the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<AddAdjustment>? AddAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddAdjustment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["add_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional prices to be added to the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<AddPrice>? AddPrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddPrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["add_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use billing_cycle_alignment instead. Reset billing periods to
    /// be aligned with the plan change's effective date.
    /// </summary>
    public bool? AlignBillingWithPlanChangeDate
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "align_billing_with_plan_change_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["align_billing_with_plan_change_date"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// Determines whether issued invoices for this subscription will automatically
    /// be charged with the saved payment method on the due date. If not specified,
    /// this defaults to the behavior configured for this customer.
    /// </summary>
    public bool? AutoCollection
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("auto_collection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Reset billing periods to be aligned with the plan change's effective date
    /// or start of the month. Defaults to `unchanged` which keeps subscription's
    /// existing billing cycle alignment.
    /// </summary>
    public ApiEnum<string, BillingCycleAlignment>? BillingCycleAlignment
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("billing_cycle_alignment", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, BillingCycleAlignment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["billing_cycle_alignment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BillingCycleAnchorConfiguration? BillingCycleAnchorConfiguration
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "billing_cycle_anchor_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<BillingCycleAnchorConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["billing_cycle_anchor_configuration"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The date that the plan change should take effect. This parameter can only
    /// be passed if the `change_option` is `requested_date`. If a date with no time
    /// is passed, the plan change will happen at midnight in the customer's timezone.
    /// </summary>
    public DateTime? ChangeDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("change_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["change_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Redemption code to be used for this subscription. If the coupon cannot be
    /// found by its redemption code, or cannot be redeemed, an error response will
    /// be returned and the subscription creation or plan change will not be scheduled.
    /// </summary>
    public string? CouponRedemptionCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("coupon_redemption_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["coupon_redemption_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? CreditsOverageRate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("credits_overage_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["credits_overage_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines the default memo on this subscription's invoices. Note that if
    /// this is not provided, it is determined by the plan configuration.
    /// </summary>
    public string? DefaultInvoiceMemo
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("default_invoice_memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["default_invoice_memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The external_plan_id of the plan that the given subscription should be switched
    /// to. Note that either this property or `plan_id` must be specified.
    /// </summary>
    public string? ExternalPlanID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["external_plan_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase of the plan to start with
    /// </summary>
    public long? InitialPhaseOrder
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("initial_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["initial_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When this subscription's accrued usage reaches this threshold, an invoice
    /// will be issued for the subscription. If not specified, invoices will only
    /// be issued at the end of the billing period.
    /// </summary>
    public string? InvoicingThreshold
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("invoicing_threshold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["invoicing_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The net terms determines the difference between the invoice date and the issue
    /// date for the invoice. If you intend the invoice to be due on issue, set this
    /// to 0. If not provided, this defaults to the value specified in the plan.
    /// </summary>
    public long? NetTerms
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? PerCreditOverageAmount
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "per_credit_overage_amount",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["per_credit_overage_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The plan that the given subscription should be switched to. Note that either
    /// this property or `external_plan_id` must be specified.
    /// </summary>
    public string? PlanID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["plan_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies which version of the plan to change to. If null, the default version
    /// will be used.
    /// </summary>
    public long? PlanVersionNumber
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("plan_version_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["plan_version_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optionally provide a list of overrides for prices on the plan
    /// </summary>
    public List<JsonElement>? PriceOverrides
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price_overrides", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["price_overrides"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be removed from the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<RemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("remove_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemoveAdjustment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["remove_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan prices to be removed from the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<RemovePrice>? RemovePrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("remove_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemovePrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["remove_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be replaced with additional adjustments on the subscription.
    /// (Only available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<ReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("replace_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplaceAdjustment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["replace_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan prices to be replaced with additional prices on the subscription. (Only
    /// available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<ReplacePrice>? ReplacePrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("replace_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplacePrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["replace_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The duration of the trial period in days. If not provided, this defaults
    /// to the value specified in the plan. If `0` is provided, the trial on the plan
    /// will be skipped.
    /// </summary>
    public long? TrialDurationDays
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("trial_duration_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["trial_duration_days"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events
    /// associated with its attached customer's customer_id. When usage_customer_ids
    /// is provided, the subscription includes usage events from the specified customers
    /// only. Provided usage_customer_ids must be either the customer for this subscription
    /// itself, or any of that customer's children.
    /// </summary>
    public List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/schedule_plan_change", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
