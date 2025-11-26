using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to change an existing subscription's plan. It returns
/// the serialized updated subscription object.
///
/// <para>The body parameter `change_option` determines when the plan change occurs.
/// Orb supports three options: - `end_of_subscription_term`: changes the plan at
/// the end of the existing plan's term.     - Issuing this plan change request for
/// a monthly subscription will keep the existing plan active until the start
///    of the subsequent month. Issuing this plan change request for a yearly subscription
/// will keep the existing plan active for       the full year. Charges incurred in
/// the remaining period will be invoiced as normal.     - Example: The plan is billed
/// monthly on the 1st of the month, the request is made on January 15th, so the
/// plan will be       changed on February 1st, and invoice will be issued on February
/// 1st for the last month of the original plan. - `immediate`: changes the plan
/// immediately.     - Subscriptions that have their plan changed with this option
/// will move to the new plan immediately, and be invoiced       immediately.
///  - This invoice will include any usage fees incurred in the billing period up
/// to the change, along with any prorated       recurring fees for the billing period,
/// if applicable.     - Example: The plan is billed monthly on the 1st of the month,
/// the request is made on January 15th, so the plan will be       changed on January
/// 15th, and an invoice will be issued for the partial month, from January 1 to
/// January 15, on the       original plan. - `requested_date`: changes the plan on
/// the requested date (`change_date`).     - If no timezone is provided, the customer's
/// timezone is used. The `change_date` body parameter is required if this option
///       is chosen.     - Example: The plan is billed monthly on the 1st of the
/// month, the request is made on January 15th, with a requested       `change_date`
/// of February 15th, so the plan will be changed on February 15th, and invoices
/// will be issued on February 1st       and February 15th.</para>
///
/// <para>Note that one of `plan_id` or `external_plan_id` is required in the request
/// body for this operation.</para>
///
/// <para>## Customize your customer's subscriptions</para>
///
/// <para>Prices and adjustments in a plan can be added, removed, or replaced on the
/// subscription when you schedule the plan change. This is useful when a customer
/// has prices that differ from the default prices for a specific plan.</para>
///
/// <para><Note> This feature is only available for accounts that have migrated to
/// Subscription Overrides Version 2. You can find your Subscription Overrides Version
/// at the bottom of your [Plans page](https://app.withorb.com/plans) </Note></para>
///
/// <para>### Adding Prices</para>
///
/// <para>To add prices, provide a list of objects with the key `add_prices`. An object
/// in the list must specify an existing add-on price with a `price_id` or `external_price_id`
/// field, or create a new add-on price by including an object with the key `price`,
/// identical to what would be used in the request body for the [create price endpoint](/api-reference/price/create-price).
/// See the [Price resource](/product-catalog/price-configuration) for the specification
/// of different price model configurations possible in this object.</para>
///
/// <para>If the plan has phases, each object in the list must include a number with
/// `plan_phase_order` key to indicate which phase the price should be added to.</para>
///
/// <para>An object in the list can specify an optional `start_date` and optional
/// `end_date`. If `start_date` is unspecified, the start of the phase / plan change
/// time will be used. If `end_date` is unspecified, it will finish at the end of
/// the phase / have no end time.</para>
///
/// <para>An object in the list can specify an optional `minimum_amount`, `maximum_amount`,
/// or `discounts`. This will create adjustments which apply only to this price.</para>
///
/// <para>Additionally, an object in the list can specify an optional `reference_id`.
/// This ID can be used to reference this price when [adding an adjustment](#adding-adjustments)
/// in the same API call. However the ID is _transient_ and cannot be used to refer
/// to the price in future API calls.</para>
///
/// <para>### Removing Prices</para>
///
/// <para>To remove prices, provide a list of objects with the key `remove_prices`.
/// An object in the list must specify a plan price with either a `price_id` or `external_price_id` field.</para>
///
/// <para>### Replacing Prices</para>
///
/// <para>To replace prices, provide a list of objects with the key `replace_prices`.
/// An object in the list must specify a plan price to replace with the `replaces_price_id`
/// key, and it must specify a price to replace it with by either referencing an
/// existing add-on price with a `price_id` or `external_price_id` field, or by creating
/// a new add-on price by including an object with the key `price`, identical to
/// what would be used in the request body for the [create price endpoint](/api-reference/price/create-price).
/// See the [Price resource](/product-catalog/price-configuration) for the specification
/// of different price model configurations possible in this object.</para>
///
/// <para>For fixed fees, an object in the list can supply a `fixed_price_quantity`
/// instead of a `price`, `price_id`, or `external_price_id` field. This will update
/// only the quantity for the price, similar to the [Update price quantity](/api-reference/subscription/update-price-quantity) endpoint.</para>
///
/// <para>The replacement price will have the same phase, if applicable, and the
/// same start and end dates as the price it replaces.</para>
///
/// <para>An object in the list can specify an optional `minimum_amount`, `maximum_amount`,
/// or `discounts`. This will create adjustments which apply only to this price.</para>
///
/// <para>Additionally, an object in the list can specify an optional `reference_id`.
/// This ID can be used to reference the replacement price when [adding an adjustment](#adding-adjustments)
/// in the same API call. However the ID is _transient_ and cannot be used to refer
/// to the price in future API calls.</para>
///
/// <para>### Adding adjustments</para>
///
/// <para>To add adjustments, provide a list of objects with the key `add_adjustments`.
/// An object in the list must include an object with the key `adjustment`, identical
/// to the adjustment object in the [add/edit price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).</para>
///
/// <para>If the plan has phases, each object in the list must include a number with
/// `plan_phase_order` key to indicate which phase the adjustment should be added to.</para>
///
/// <para>An object in the list can specify an optional `start_date` and optional
/// `end_date`. If `start_date` is unspecified, the start of the phase / plan change
/// time will be used. If `end_date` is unspecified, it will finish at the end of
/// the phase / have no end time.</para>
///
/// <para>### Removing adjustments</para>
///
/// <para>To remove adjustments, provide a list of objects with the key `remove_adjustments`.
/// An object in the list must include a key, `adjustment_id`, with the ID of the
/// adjustment to be removed.</para>
///
/// <para>### Replacing adjustments</para>
///
/// <para>To replace adjustments, provide a list of objects with the key `replace_adjustments`.
/// An object in the list must specify a plan adjustment to replace with the `replaces_adjustment_id`
/// key, and it must specify an adjustment to replace it with by including an object
/// with the key `adjustment`, identical to the adjustment object in the [add/edit
/// price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).</para>
///
/// <para>The replacement adjustment will have the same phase, if applicable, and
/// the same start and end dates as the adjustment it replaces.</para>
///
/// <para>## Price overrides (DEPRECATED)</para>
///
/// <para><Note> Price overrides are being phased out in favor adding/removing/replacing
/// prices. (See [Customize your customer's subscriptions](/api-reference/subscription/schedule-plan-change)) </Note></para>
///
/// <para>Price overrides are used to update some or all prices in a plan for the
/// specific subscription being created. This is useful when a new customer has negotiated
/// a rate that is unique to the customer.</para>
///
/// <para>To override prices, provide a list of objects with the key `price_overrides`.
/// The price object in the list of overrides is expected to contain the existing
/// price id, the `model_type` and configuration. (See the [Price resource](/product-catalog/price-configuration)
/// for the specification of different price model configurations.) The numerical
/// values can be updated, but the billable metric, cadence, type, and name of a
/// price can not be overridden.</para>
///
/// <para>### Maximums, and minimums Price overrides are used to update some or all
/// prices in the target plan. Minimums and maximums, much like price overrides, can
/// be useful when a new customer has negotiated a new or different minimum or maximum
/// spend cap than the default for the plan. The request format for maximums and minimums
/// is the same as those in [subscription creation](create-subscription).</para>
///
/// <para>## Scheduling multiple plan changes When scheduling multiple plan changes
/// with the same date, the latest plan change on that day takes effect.</para>
///
/// <para>## Prorations for in-advance fees By default, Orb calculates the prorated
/// difference in any fixed fees when making a plan change, adjusting the customer
/// balance as needed. For details on this behavior, see [Modifying subscriptions](/product-catalog/modifying-subscriptions#prorations-for-in-advance-fees).</para>
/// </summary>
public sealed record class SubscriptionSchedulePlanChangeParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    public required ApiEnum<string, ChangeOptionModel> ChangeOption
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("change_option", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'change_option' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "change_option",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ChangeOptionModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["change_option"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional adjustments to be added to the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<AddAdjustment1>? AddAdjustments
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("add_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddAdjustment1>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["add_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional prices to be added to the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<AddPriceModel>? AddPrices
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("add_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddPriceModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["add_prices"] = JsonSerializer.SerializeToElement(
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
                !this._rawBodyData.TryGetValue(
                    "align_billing_with_plan_change_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["align_billing_with_plan_change_date"] =
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
            if (!this._rawBodyData.TryGetValue("auto_collection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["auto_collection"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("billing_cycle_alignment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, BillingCycleAlignment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["billing_cycle_alignment"] = JsonSerializer.SerializeToElement(
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
                !this._rawBodyData.TryGetValue(
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
        init
        {
            this._rawBodyData["billing_cycle_anchor_configuration"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The date that the plan change should take effect. This parameter can only
    /// be passed if the `change_option` is `requested_date`. If a date with no time
    /// is passed, the plan change will happen at midnight in the customer's timezone.
    /// </summary>
    public System::DateTimeOffset? ChangeDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("change_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["change_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("coupon_redemption_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["coupon_redemption_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    [System::Obsolete("deprecated")]
    public double? CreditsOverageRate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("credits_overage_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["credits_overage_rate"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("default_invoice_memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["default_invoice_memo"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("external_plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["external_plan_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["filter"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("initial_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["initial_phase_order"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("invoicing_threshold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["invoicing_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The net terms determines the difference between the invoice date and the
    /// issue date for the invoice. If you intend the invoice to be due on issue,
    /// set this to 0. If not provided, this defaults to the value specified in the plan.
    /// </summary>
    public long? NetTerms
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    [System::Obsolete("deprecated")]
    public double? PerCreditOverageAmount
    {
        get
        {
            if (
                !this._rawBodyData.TryGetValue("per_credit_overage_amount", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["per_credit_overage_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["plan_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("plan_version_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["plan_version_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optionally provide a list of overrides for prices on the plan
    /// </summary>
    [System::Obsolete("deprecated")]
    public IReadOnlyList<JsonElement>? PriceOverrides
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("price_overrides", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["price_overrides"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be removed from the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<RemoveAdjustmentModel>? RemoveAdjustments
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("remove_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemoveAdjustmentModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["remove_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan prices to be removed from the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<RemovePriceModel>? RemovePrices
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("remove_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemovePriceModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["remove_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be replaced with additional adjustments on the subscription.
    /// (Only available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<ReplaceAdjustmentModel>? ReplaceAdjustments
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("replace_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplaceAdjustmentModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["replace_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan prices to be replaced with additional prices on the subscription. (Only
    /// available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<ReplacePriceModel>? ReplacePrices
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("replace_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplacePriceModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["replace_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The duration of the trial period in days. If not provided, this defaults to
    /// the value specified in the plan. If `0` is provided, the trial on the plan
    /// will be skipped.
    /// </summary>
    public long? TrialDurationDays
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("trial_duration_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["trial_duration_days"] = JsonSerializer.SerializeToElement(
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
    public IReadOnlyList<string>? UsageCustomerIDs
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionSchedulePlanChangeParams() { }

    public SubscriptionSchedulePlanChangeParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static SubscriptionSchedulePlanChangeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/schedule_plan_change", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ChangeOptionModelConverter))]
public enum ChangeOptionModel
{
    RequestedDate,
    EndOfSubscriptionTerm,
    Immediate,
}

sealed class ChangeOptionModelConverter : JsonConverter<ChangeOptionModel>
{
    public override ChangeOptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requested_date" => ChangeOptionModel.RequestedDate,
            "end_of_subscription_term" => ChangeOptionModel.EndOfSubscriptionTerm,
            "immediate" => ChangeOptionModel.Immediate,
            _ => (ChangeOptionModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChangeOptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChangeOptionModel.RequestedDate => "requested_date",
                ChangeOptionModel.EndOfSubscriptionTerm => "end_of_subscription_term",
                ChangeOptionModel.Immediate => "immediate",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AddAdjustment1, AddAdjustment1FromRaw>))]
public sealed record class AddAdjustment1 : ModelBase
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required AddAdjustment1Adjustment Adjustment
    {
        get
        {
            if (!this._rawData.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddAdjustment1Adjustment>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentNullException("adjustment")
                );
        }
        init
        {
            this._rawData["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription.
    /// </summary>
    public System::DateTimeOffset? EndDate
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

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._rawData.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. If null, the adjustment will
    /// start when the phase or subscription starts.
    /// </summary>
    public System::DateTimeOffset? StartDate
    {
        get
        {
            if (!this._rawData.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
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

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.EndDate;
        _ = this.PlanPhaseOrder;
        _ = this.StartDate;
    }

    public AddAdjustment1() { }

    public AddAdjustment1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddAdjustment1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddAdjustment1(AddAdjustment1Adjustment adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}

class AddAdjustment1FromRaw : IFromRaw<AddAdjustment1>
{
    public AddAdjustment1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddAdjustment1.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(AddAdjustment1AdjustmentConverter))]
public record class AddAdjustment1Adjustment
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newPercentageDiscount: (x) => x.Currency,
                newUsageDiscount: (x) => x.Currency,
                newAmountDiscount: (x) => x.Currency,
                newMinimum: (x) => x.Currency,
                newMaximum: (x) => x.Currency
            );
        }
    }

    public bool? IsInvoiceLevel
    {
        get
        {
            return Match<bool?>(
                newPercentageDiscount: (x) => x.IsInvoiceLevel,
                newUsageDiscount: (x) => x.IsInvoiceLevel,
                newAmountDiscount: (x) => x.IsInvoiceLevel,
                newMinimum: (x) => x.IsInvoiceLevel,
                newMaximum: (x) => x.IsInvoiceLevel
            );
        }
    }

    public AddAdjustment1Adjustment(NewPercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustment1Adjustment(NewUsageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustment1Adjustment(NewAmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustment1Adjustment(NewMinimum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustment1Adjustment(NewMaximum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustment1Adjustment(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
        return value != null;
    }

    public void Switch(
        System::Action<NewPercentageDiscount> newPercentageDiscount,
        System::Action<NewUsageDiscount> newUsageDiscount,
        System::Action<NewAmountDiscount> newAmountDiscount,
        System::Action<NewMinimum> newMinimum,
        System::Action<NewMaximum> newMaximum
    )
    {
        switch (this.Value)
        {
            case NewPercentageDiscount value:
                newPercentageDiscount(value);
                break;
            case NewUsageDiscount value:
                newUsageDiscount(value);
                break;
            case NewAmountDiscount value:
                newAmountDiscount(value);
                break;
            case NewMinimum value:
                newMinimum(value);
                break;
            case NewMaximum value:
                newMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddAdjustment1Adjustment"
                );
        }
    }

    public T Match<T>(
        System::Func<NewPercentageDiscount, T> newPercentageDiscount,
        System::Func<NewUsageDiscount, T> newUsageDiscount,
        System::Func<NewAmountDiscount, T> newAmountDiscount,
        System::Func<NewMinimum, T> newMinimum,
        System::Func<NewMaximum, T> newMaximum
    )
    {
        return this.Value switch
        {
            NewPercentageDiscount value => newPercentageDiscount(value),
            NewUsageDiscount value => newUsageDiscount(value),
            NewAmountDiscount value => newAmountDiscount(value),
            NewMinimum value => newMinimum(value),
            NewMaximum value => newMaximum(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustment1Adjustment"
            ),
        };
    }

    public static implicit operator AddAdjustment1Adjustment(NewPercentageDiscount value) =>
        new(value);

    public static implicit operator AddAdjustment1Adjustment(NewUsageDiscount value) => new(value);

    public static implicit operator AddAdjustment1Adjustment(NewAmountDiscount value) => new(value);

    public static implicit operator AddAdjustment1Adjustment(NewMinimum value) => new(value);

    public static implicit operator AddAdjustment1Adjustment(NewMaximum value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustment1Adjustment"
            );
        }
    }
}

sealed class AddAdjustment1AdjustmentConverter : JsonConverter<AddAdjustment1Adjustment>
{
    public override AddAdjustment1Adjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = json.GetProperty("adjustment_type").GetString();
        }
        catch
        {
            adjustmentType = null;
        }

        switch (adjustmentType)
        {
            case "percentage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
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
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
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
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
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
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
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
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
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
                return new AddAdjustment1Adjustment(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddAdjustment1Adjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<AddPriceModel, AddPriceModelFromRaw>))]
public sealed record class AddPriceModel : ModelBase
{
    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this._rawData.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["allocation_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's discounts for
    /// this price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public IReadOnlyList<DiscountOverride>? Discounts
    {
        get
        {
            if (!this._rawData.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DiscountOverride>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that the price will stop
    /// billing on the subscription. If null, billing will end when the phase or subscription ends.
    /// </summary>
    public System::DateTimeOffset? EndDate
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

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for this price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MaximumAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for this price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MinimumAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase to add this price to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._rawData.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public AddPriceModelPrice? Price
    {
        get
        {
            if (!this._rawData.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceModelPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the price interval. This is the date that the price will
    /// start billing on the subscription. If null, billing will start when the phase
    /// or subscription starts.
    /// </summary>
    public System::DateTimeOffset? StartDate
    {
        get
        {
            if (!this._rawData.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
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

    public override void Validate()
    {
        this.AllocationPrice?.Validate();
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        _ = this.EndDate;
        _ = this.ExternalPriceID;
        _ = this.MaximumAmount;
        _ = this.MinimumAmount;
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
        _ = this.PriceID;
        _ = this.StartDate;
    }

    public AddPriceModel() { }

    public AddPriceModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelFromRaw : IFromRaw<AddPriceModel>
{
    public AddPriceModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddPriceModel.FromRawUnchecked(rawData);
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(AddPriceModelPriceConverter))]
public record class AddPriceModelPrice
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string ItemID
    {
        get
        {
            return Match(
                newSubscriptionUnit: (x) => x.ItemID,
                newSubscriptionTiered: (x) => x.ItemID,
                newSubscriptionBulk: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newSubscriptionPackage: (x) => x.ItemID,
                newSubscriptionMatrix: (x) => x.ItemID,
                newSubscriptionThresholdTotalAmount: (x) => x.ItemID,
                newSubscriptionTieredPackage: (x) => x.ItemID,
                newSubscriptionTieredWithMinimum: (x) => x.ItemID,
                newSubscriptionGroupedTiered: (x) => x.ItemID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ItemID,
                newSubscriptionPackageWithAllocation: (x) => x.ItemID,
                newSubscriptionUnitWithPercent: (x) => x.ItemID,
                newSubscriptionMatrixWithAllocation: (x) => x.ItemID,
                tieredWithProration: (x) => x.ItemID,
                newSubscriptionUnitWithProration: (x) => x.ItemID,
                newSubscriptionGroupedAllocation: (x) => x.ItemID,
                newSubscriptionBulkWithProration: (x) => x.ItemID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ItemID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newSubscriptionMatrixWithDisplayName: (x) => x.ItemID,
                newSubscriptionGroupedTieredPackage: (x) => x.ItemID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ItemID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ItemID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ItemID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ItemID,
                cumulativeGroupedAllocation: (x) => x.ItemID,
                newSubscriptionMinimumComposite: (x) => x.ItemID,
                percent: (x) => x.ItemID,
                eventOutput: (x) => x.ItemID
            );
        }
    }

    public string Name
    {
        get
        {
            return Match(
                newSubscriptionUnit: (x) => x.Name,
                newSubscriptionTiered: (x) => x.Name,
                newSubscriptionBulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newSubscriptionPackage: (x) => x.Name,
                newSubscriptionMatrix: (x) => x.Name,
                newSubscriptionThresholdTotalAmount: (x) => x.Name,
                newSubscriptionTieredPackage: (x) => x.Name,
                newSubscriptionTieredWithMinimum: (x) => x.Name,
                newSubscriptionGroupedTiered: (x) => x.Name,
                newSubscriptionTieredPackageWithMinimum: (x) => x.Name,
                newSubscriptionPackageWithAllocation: (x) => x.Name,
                newSubscriptionUnitWithPercent: (x) => x.Name,
                newSubscriptionMatrixWithAllocation: (x) => x.Name,
                tieredWithProration: (x) => x.Name,
                newSubscriptionUnitWithProration: (x) => x.Name,
                newSubscriptionGroupedAllocation: (x) => x.Name,
                newSubscriptionBulkWithProration: (x) => x.Name,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.Name,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newSubscriptionMatrixWithDisplayName: (x) => x.Name,
                newSubscriptionGroupedTieredPackage: (x) => x.Name,
                newSubscriptionMaxGroupTieredPackage: (x) => x.Name,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.Name,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.Name,
                newSubscriptionCumulativeGroupedBulk: (x) => x.Name,
                cumulativeGroupedAllocation: (x) => x.Name,
                newSubscriptionMinimumComposite: (x) => x.Name,
                percent: (x) => x.Name,
                eventOutput: (x) => x.Name
            );
        }
    }

    public string? BillableMetricID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.BillableMetricID,
                newSubscriptionTiered: (x) => x.BillableMetricID,
                newSubscriptionBulk: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newSubscriptionPackage: (x) => x.BillableMetricID,
                newSubscriptionMatrix: (x) => x.BillableMetricID,
                newSubscriptionThresholdTotalAmount: (x) => x.BillableMetricID,
                newSubscriptionTieredPackage: (x) => x.BillableMetricID,
                newSubscriptionTieredWithMinimum: (x) => x.BillableMetricID,
                newSubscriptionGroupedTiered: (x) => x.BillableMetricID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.BillableMetricID,
                newSubscriptionPackageWithAllocation: (x) => x.BillableMetricID,
                newSubscriptionUnitWithPercent: (x) => x.BillableMetricID,
                newSubscriptionMatrixWithAllocation: (x) => x.BillableMetricID,
                tieredWithProration: (x) => x.BillableMetricID,
                newSubscriptionUnitWithProration: (x) => x.BillableMetricID,
                newSubscriptionGroupedAllocation: (x) => x.BillableMetricID,
                newSubscriptionBulkWithProration: (x) => x.BillableMetricID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.BillableMetricID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newSubscriptionMatrixWithDisplayName: (x) => x.BillableMetricID,
                newSubscriptionGroupedTieredPackage: (x) => x.BillableMetricID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.BillableMetricID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.BillableMetricID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.BillableMetricID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.BillableMetricID,
                cumulativeGroupedAllocation: (x) => x.BillableMetricID,
                newSubscriptionMinimumComposite: (x) => x.BillableMetricID,
                percent: (x) => x.BillableMetricID,
                eventOutput: (x) => x.BillableMetricID
            );
        }
    }

    public bool? BilledInAdvance
    {
        get
        {
            return Match<bool?>(
                newSubscriptionUnit: (x) => x.BilledInAdvance,
                newSubscriptionTiered: (x) => x.BilledInAdvance,
                newSubscriptionBulk: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newSubscriptionPackage: (x) => x.BilledInAdvance,
                newSubscriptionMatrix: (x) => x.BilledInAdvance,
                newSubscriptionThresholdTotalAmount: (x) => x.BilledInAdvance,
                newSubscriptionTieredPackage: (x) => x.BilledInAdvance,
                newSubscriptionTieredWithMinimum: (x) => x.BilledInAdvance,
                newSubscriptionGroupedTiered: (x) => x.BilledInAdvance,
                newSubscriptionTieredPackageWithMinimum: (x) => x.BilledInAdvance,
                newSubscriptionPackageWithAllocation: (x) => x.BilledInAdvance,
                newSubscriptionUnitWithPercent: (x) => x.BilledInAdvance,
                newSubscriptionMatrixWithAllocation: (x) => x.BilledInAdvance,
                tieredWithProration: (x) => x.BilledInAdvance,
                newSubscriptionUnitWithProration: (x) => x.BilledInAdvance,
                newSubscriptionGroupedAllocation: (x) => x.BilledInAdvance,
                newSubscriptionBulkWithProration: (x) => x.BilledInAdvance,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.BilledInAdvance,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newSubscriptionMatrixWithDisplayName: (x) => x.BilledInAdvance,
                newSubscriptionGroupedTieredPackage: (x) => x.BilledInAdvance,
                newSubscriptionMaxGroupTieredPackage: (x) => x.BilledInAdvance,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.BilledInAdvance,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.BilledInAdvance,
                newSubscriptionCumulativeGroupedBulk: (x) => x.BilledInAdvance,
                cumulativeGroupedAllocation: (x) => x.BilledInAdvance,
                newSubscriptionMinimumComposite: (x) => x.BilledInAdvance,
                percent: (x) => x.BilledInAdvance,
                eventOutput: (x) => x.BilledInAdvance
            );
        }
    }

    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newSubscriptionUnit: (x) => x.BillingCycleConfiguration,
                newSubscriptionTiered: (x) => x.BillingCycleConfiguration,
                newSubscriptionBulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newSubscriptionPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionMatrix: (x) => x.BillingCycleConfiguration,
                newSubscriptionThresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                newSubscriptionTieredPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionTieredWithMinimum: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedTiered: (x) => x.BillingCycleConfiguration,
                newSubscriptionTieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                newSubscriptionPackageWithAllocation: (x) => x.BillingCycleConfiguration,
                newSubscriptionUnitWithPercent: (x) => x.BillingCycleConfiguration,
                newSubscriptionMatrixWithAllocation: (x) => x.BillingCycleConfiguration,
                tieredWithProration: (x) => x.BillingCycleConfiguration,
                newSubscriptionUnitWithProration: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newSubscriptionBulkWithProration: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newSubscriptionMatrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedTieredPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionMaxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                newSubscriptionCumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newSubscriptionMinimumComposite: (x) => x.BillingCycleConfiguration,
                percent: (x) => x.BillingCycleConfiguration,
                eventOutput: (x) => x.BillingCycleConfiguration
            );
        }
    }

    public double? ConversionRate
    {
        get
        {
            return Match<double?>(
                newSubscriptionUnit: (x) => x.ConversionRate,
                newSubscriptionTiered: (x) => x.ConversionRate,
                newSubscriptionBulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newSubscriptionPackage: (x) => x.ConversionRate,
                newSubscriptionMatrix: (x) => x.ConversionRate,
                newSubscriptionThresholdTotalAmount: (x) => x.ConversionRate,
                newSubscriptionTieredPackage: (x) => x.ConversionRate,
                newSubscriptionTieredWithMinimum: (x) => x.ConversionRate,
                newSubscriptionGroupedTiered: (x) => x.ConversionRate,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ConversionRate,
                newSubscriptionPackageWithAllocation: (x) => x.ConversionRate,
                newSubscriptionUnitWithPercent: (x) => x.ConversionRate,
                newSubscriptionMatrixWithAllocation: (x) => x.ConversionRate,
                tieredWithProration: (x) => x.ConversionRate,
                newSubscriptionUnitWithProration: (x) => x.ConversionRate,
                newSubscriptionGroupedAllocation: (x) => x.ConversionRate,
                newSubscriptionBulkWithProration: (x) => x.ConversionRate,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ConversionRate,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newSubscriptionMatrixWithDisplayName: (x) => x.ConversionRate,
                newSubscriptionGroupedTieredPackage: (x) => x.ConversionRate,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ConversionRate,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ConversionRate,
                cumulativeGroupedAllocation: (x) => x.ConversionRate,
                newSubscriptionMinimumComposite: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.Currency,
                newSubscriptionTiered: (x) => x.Currency,
                newSubscriptionBulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newSubscriptionPackage: (x) => x.Currency,
                newSubscriptionMatrix: (x) => x.Currency,
                newSubscriptionThresholdTotalAmount: (x) => x.Currency,
                newSubscriptionTieredPackage: (x) => x.Currency,
                newSubscriptionTieredWithMinimum: (x) => x.Currency,
                newSubscriptionGroupedTiered: (x) => x.Currency,
                newSubscriptionTieredPackageWithMinimum: (x) => x.Currency,
                newSubscriptionPackageWithAllocation: (x) => x.Currency,
                newSubscriptionUnitWithPercent: (x) => x.Currency,
                newSubscriptionMatrixWithAllocation: (x) => x.Currency,
                tieredWithProration: (x) => x.Currency,
                newSubscriptionUnitWithProration: (x) => x.Currency,
                newSubscriptionGroupedAllocation: (x) => x.Currency,
                newSubscriptionBulkWithProration: (x) => x.Currency,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.Currency,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newSubscriptionMatrixWithDisplayName: (x) => x.Currency,
                newSubscriptionGroupedTieredPackage: (x) => x.Currency,
                newSubscriptionMaxGroupTieredPackage: (x) => x.Currency,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.Currency,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.Currency,
                newSubscriptionCumulativeGroupedBulk: (x) => x.Currency,
                cumulativeGroupedAllocation: (x) => x.Currency,
                newSubscriptionMinimumComposite: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<NewDimensionalPriceConfiguration?>(
                newSubscriptionUnit: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTiered: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionBulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMatrix: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionThresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedTiered: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionPackageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionUnitWithPercent: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMatrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                tieredWithProration: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionUnitWithProration: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionBulkWithProration: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMatrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMaxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionScalableMatrixWithUnitPricing: (x) =>
                    x.DimensionalPriceConfiguration,
                newSubscriptionScalableMatrixWithTieredPricing: (x) =>
                    x.DimensionalPriceConfiguration,
                newSubscriptionCumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMinimumComposite: (x) => x.DimensionalPriceConfiguration,
                percent: (x) => x.DimensionalPriceConfiguration,
                eventOutput: (x) => x.DimensionalPriceConfiguration
            );
        }
    }

    public string? ExternalPriceID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.ExternalPriceID,
                newSubscriptionTiered: (x) => x.ExternalPriceID,
                newSubscriptionBulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newSubscriptionPackage: (x) => x.ExternalPriceID,
                newSubscriptionMatrix: (x) => x.ExternalPriceID,
                newSubscriptionThresholdTotalAmount: (x) => x.ExternalPriceID,
                newSubscriptionTieredPackage: (x) => x.ExternalPriceID,
                newSubscriptionTieredWithMinimum: (x) => x.ExternalPriceID,
                newSubscriptionGroupedTiered: (x) => x.ExternalPriceID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ExternalPriceID,
                newSubscriptionPackageWithAllocation: (x) => x.ExternalPriceID,
                newSubscriptionUnitWithPercent: (x) => x.ExternalPriceID,
                newSubscriptionMatrixWithAllocation: (x) => x.ExternalPriceID,
                tieredWithProration: (x) => x.ExternalPriceID,
                newSubscriptionUnitWithProration: (x) => x.ExternalPriceID,
                newSubscriptionGroupedAllocation: (x) => x.ExternalPriceID,
                newSubscriptionBulkWithProration: (x) => x.ExternalPriceID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ExternalPriceID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newSubscriptionMatrixWithDisplayName: (x) => x.ExternalPriceID,
                newSubscriptionGroupedTieredPackage: (x) => x.ExternalPriceID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ExternalPriceID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ExternalPriceID,
                cumulativeGroupedAllocation: (x) => x.ExternalPriceID,
                newSubscriptionMinimumComposite: (x) => x.ExternalPriceID,
                percent: (x) => x.ExternalPriceID,
                eventOutput: (x) => x.ExternalPriceID
            );
        }
    }

    public double? FixedPriceQuantity
    {
        get
        {
            return Match<double?>(
                newSubscriptionUnit: (x) => x.FixedPriceQuantity,
                newSubscriptionTiered: (x) => x.FixedPriceQuantity,
                newSubscriptionBulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newSubscriptionPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionMatrix: (x) => x.FixedPriceQuantity,
                newSubscriptionThresholdTotalAmount: (x) => x.FixedPriceQuantity,
                newSubscriptionTieredPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionTieredWithMinimum: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedTiered: (x) => x.FixedPriceQuantity,
                newSubscriptionTieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                newSubscriptionPackageWithAllocation: (x) => x.FixedPriceQuantity,
                newSubscriptionUnitWithPercent: (x) => x.FixedPriceQuantity,
                newSubscriptionMatrixWithAllocation: (x) => x.FixedPriceQuantity,
                tieredWithProration: (x) => x.FixedPriceQuantity,
                newSubscriptionUnitWithProration: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedAllocation: (x) => x.FixedPriceQuantity,
                newSubscriptionBulkWithProration: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newSubscriptionMatrixWithDisplayName: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedTieredPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionMaxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                newSubscriptionCumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                cumulativeGroupedAllocation: (x) => x.FixedPriceQuantity,
                newSubscriptionMinimumComposite: (x) => x.FixedPriceQuantity,
                percent: (x) => x.FixedPriceQuantity,
                eventOutput: (x) => x.FixedPriceQuantity
            );
        }
    }

    public string? InvoiceGroupingKey
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.InvoiceGroupingKey,
                newSubscriptionTiered: (x) => x.InvoiceGroupingKey,
                newSubscriptionBulk: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newSubscriptionPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionMatrix: (x) => x.InvoiceGroupingKey,
                newSubscriptionThresholdTotalAmount: (x) => x.InvoiceGroupingKey,
                newSubscriptionTieredPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionTieredWithMinimum: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedTiered: (x) => x.InvoiceGroupingKey,
                newSubscriptionTieredPackageWithMinimum: (x) => x.InvoiceGroupingKey,
                newSubscriptionPackageWithAllocation: (x) => x.InvoiceGroupingKey,
                newSubscriptionUnitWithPercent: (x) => x.InvoiceGroupingKey,
                newSubscriptionMatrixWithAllocation: (x) => x.InvoiceGroupingKey,
                tieredWithProration: (x) => x.InvoiceGroupingKey,
                newSubscriptionUnitWithProration: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newSubscriptionBulkWithProration: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newSubscriptionMatrixWithDisplayName: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedTieredPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionMaxGroupTieredPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.InvoiceGroupingKey,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.InvoiceGroupingKey,
                newSubscriptionCumulativeGroupedBulk: (x) => x.InvoiceGroupingKey,
                cumulativeGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newSubscriptionMinimumComposite: (x) => x.InvoiceGroupingKey,
                percent: (x) => x.InvoiceGroupingKey,
                eventOutput: (x) => x.InvoiceGroupingKey
            );
        }
    }

    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newSubscriptionUnit: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTiered: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionBulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMatrix: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionThresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedTiered: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionPackageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionUnitWithPercent: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMatrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                tieredWithProration: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionUnitWithProration: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionBulkWithProration: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMatrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMaxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionScalableMatrixWithTieredPricing: (x) =>
                    x.InvoicingCycleConfiguration,
                newSubscriptionCumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public string? ReferenceID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.ReferenceID,
                newSubscriptionTiered: (x) => x.ReferenceID,
                newSubscriptionBulk: (x) => x.ReferenceID,
                bulkWithFilters: (x) => x.ReferenceID,
                newSubscriptionPackage: (x) => x.ReferenceID,
                newSubscriptionMatrix: (x) => x.ReferenceID,
                newSubscriptionThresholdTotalAmount: (x) => x.ReferenceID,
                newSubscriptionTieredPackage: (x) => x.ReferenceID,
                newSubscriptionTieredWithMinimum: (x) => x.ReferenceID,
                newSubscriptionGroupedTiered: (x) => x.ReferenceID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ReferenceID,
                newSubscriptionPackageWithAllocation: (x) => x.ReferenceID,
                newSubscriptionUnitWithPercent: (x) => x.ReferenceID,
                newSubscriptionMatrixWithAllocation: (x) => x.ReferenceID,
                tieredWithProration: (x) => x.ReferenceID,
                newSubscriptionUnitWithProration: (x) => x.ReferenceID,
                newSubscriptionGroupedAllocation: (x) => x.ReferenceID,
                newSubscriptionBulkWithProration: (x) => x.ReferenceID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ReferenceID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ReferenceID,
                groupedWithMinMaxThresholds: (x) => x.ReferenceID,
                newSubscriptionMatrixWithDisplayName: (x) => x.ReferenceID,
                newSubscriptionGroupedTieredPackage: (x) => x.ReferenceID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ReferenceID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ReferenceID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ReferenceID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ReferenceID,
                cumulativeGroupedAllocation: (x) => x.ReferenceID,
                newSubscriptionMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public AddPriceModelPrice(NewSubscriptionUnitPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(AddPriceModelPriceBulkWithFilters value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionMatrixPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionThresholdTotalAmountPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionTieredWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionGroupedTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionTieredPackageWithMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionPackageWithAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionUnitWithPercentPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionMatrixWithAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(AddPriceModelPriceTieredWithProration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionUnitWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionGroupedAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionBulkWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        AddPriceModelPriceGroupedWithMinMaxThresholds value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionMatrixWithDisplayNamePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionGroupedTieredPackagePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionMaxGroupTieredPackagePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        NewSubscriptionCumulativeGroupedBulkPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(
        AddPriceModelPriceCumulativeGroupedAllocation value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(NewSubscriptionMinimumCompositePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(AddPriceModelPricePercent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(AddPriceModelPriceEventOutput value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPrice(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewSubscriptionUnit([NotNullWhen(true)] out NewSubscriptionUnitPrice? value)
    {
        value = this.Value as NewSubscriptionUnitPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTiered(
        [NotNullWhen(true)] out NewSubscriptionTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionBulk([NotNullWhen(true)] out NewSubscriptionBulkPrice? value)
    {
        value = this.Value as NewSubscriptionBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out AddPriceModelPriceBulkWithFilters? value
    )
    {
        value = this.Value as AddPriceModelPriceBulkWithFilters;
        return value != null;
    }

    public bool TryPickNewSubscriptionPackage(
        [NotNullWhen(true)] out NewSubscriptionPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrix(
        [NotNullWhen(true)] out NewSubscriptionMatrixPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionThresholdTotalAmount(
        [NotNullWhen(true)] out NewSubscriptionThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewSubscriptionThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedTiered(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionPackageWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionUnitWithPercent(
        [NotNullWhen(true)] out NewSubscriptionUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrixWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out AddPriceModelPriceTieredWithProration? value
    )
    {
        value = this.Value as AddPriceModelPriceTieredWithProration;
        return value != null;
    }

    public bool TryPickNewSubscriptionUnitWithProration(
        [NotNullWhen(true)] out NewSubscriptionUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedAllocation(
        [NotNullWhen(true)] out NewSubscriptionGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionBulkWithProration(
        [NotNullWhen(true)] out NewSubscriptionBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out AddPriceModelPriceGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as AddPriceModelPriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrixWithDisplayName(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewSubscriptionCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewSubscriptionCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out AddPriceModelPriceCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as AddPriceModelPriceCumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewSubscriptionMinimumComposite(
        [NotNullWhen(true)] out NewSubscriptionMinimumCompositePrice? value
    )
    {
        value = this.Value as NewSubscriptionMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out AddPriceModelPricePercent? value)
    {
        value = this.Value as AddPriceModelPricePercent;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out AddPriceModelPriceEventOutput? value)
    {
        value = this.Value as AddPriceModelPriceEventOutput;
        return value != null;
    }

    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<AddPriceModelPriceBulkWithFilters> bulkWithFilters,
        System::Action<NewSubscriptionPackagePrice> newSubscriptionPackage,
        System::Action<NewSubscriptionMatrixPrice> newSubscriptionMatrix,
        System::Action<NewSubscriptionThresholdTotalAmountPrice> newSubscriptionThresholdTotalAmount,
        System::Action<NewSubscriptionTieredPackagePrice> newSubscriptionTieredPackage,
        System::Action<NewSubscriptionTieredWithMinimumPrice> newSubscriptionTieredWithMinimum,
        System::Action<NewSubscriptionGroupedTieredPrice> newSubscriptionGroupedTiered,
        System::Action<NewSubscriptionTieredPackageWithMinimumPrice> newSubscriptionTieredPackageWithMinimum,
        System::Action<NewSubscriptionPackageWithAllocationPrice> newSubscriptionPackageWithAllocation,
        System::Action<NewSubscriptionUnitWithPercentPrice> newSubscriptionUnitWithPercent,
        System::Action<NewSubscriptionMatrixWithAllocationPrice> newSubscriptionMatrixWithAllocation,
        System::Action<AddPriceModelPriceTieredWithProration> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<AddPriceModelPriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<AddPriceModelPriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<AddPriceModelPricePercent> percent,
        System::Action<AddPriceModelPriceEventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewSubscriptionUnitPrice value:
                newSubscriptionUnit(value);
                break;
            case NewSubscriptionTieredPrice value:
                newSubscriptionTiered(value);
                break;
            case NewSubscriptionBulkPrice value:
                newSubscriptionBulk(value);
                break;
            case AddPriceModelPriceBulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewSubscriptionPackagePrice value:
                newSubscriptionPackage(value);
                break;
            case NewSubscriptionMatrixPrice value:
                newSubscriptionMatrix(value);
                break;
            case NewSubscriptionThresholdTotalAmountPrice value:
                newSubscriptionThresholdTotalAmount(value);
                break;
            case NewSubscriptionTieredPackagePrice value:
                newSubscriptionTieredPackage(value);
                break;
            case NewSubscriptionTieredWithMinimumPrice value:
                newSubscriptionTieredWithMinimum(value);
                break;
            case NewSubscriptionGroupedTieredPrice value:
                newSubscriptionGroupedTiered(value);
                break;
            case NewSubscriptionTieredPackageWithMinimumPrice value:
                newSubscriptionTieredPackageWithMinimum(value);
                break;
            case NewSubscriptionPackageWithAllocationPrice value:
                newSubscriptionPackageWithAllocation(value);
                break;
            case NewSubscriptionUnitWithPercentPrice value:
                newSubscriptionUnitWithPercent(value);
                break;
            case NewSubscriptionMatrixWithAllocationPrice value:
                newSubscriptionMatrixWithAllocation(value);
                break;
            case AddPriceModelPriceTieredWithProration value:
                tieredWithProration(value);
                break;
            case NewSubscriptionUnitWithProrationPrice value:
                newSubscriptionUnitWithProration(value);
                break;
            case NewSubscriptionGroupedAllocationPrice value:
                newSubscriptionGroupedAllocation(value);
                break;
            case NewSubscriptionBulkWithProrationPrice value:
                newSubscriptionBulkWithProration(value);
                break;
            case NewSubscriptionGroupedWithProratedMinimumPrice value:
                newSubscriptionGroupedWithProratedMinimum(value);
                break;
            case NewSubscriptionGroupedWithMeteredMinimumPrice value:
                newSubscriptionGroupedWithMeteredMinimum(value);
                break;
            case AddPriceModelPriceGroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewSubscriptionMatrixWithDisplayNamePrice value:
                newSubscriptionMatrixWithDisplayName(value);
                break;
            case NewSubscriptionGroupedTieredPackagePrice value:
                newSubscriptionGroupedTieredPackage(value);
                break;
            case NewSubscriptionMaxGroupTieredPackagePrice value:
                newSubscriptionMaxGroupTieredPackage(value);
                break;
            case NewSubscriptionScalableMatrixWithUnitPricingPrice value:
                newSubscriptionScalableMatrixWithUnitPricing(value);
                break;
            case NewSubscriptionScalableMatrixWithTieredPricingPrice value:
                newSubscriptionScalableMatrixWithTieredPricing(value);
                break;
            case NewSubscriptionCumulativeGroupedBulkPrice value:
                newSubscriptionCumulativeGroupedBulk(value);
                break;
            case AddPriceModelPriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case AddPriceModelPricePercent value:
                percent(value);
                break;
            case AddPriceModelPriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddPriceModelPrice"
                );
        }
    }

    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<AddPriceModelPriceBulkWithFilters, T> bulkWithFilters,
        System::Func<NewSubscriptionPackagePrice, T> newSubscriptionPackage,
        System::Func<NewSubscriptionMatrixPrice, T> newSubscriptionMatrix,
        System::Func<
            NewSubscriptionThresholdTotalAmountPrice,
            T
        > newSubscriptionThresholdTotalAmount,
        System::Func<NewSubscriptionTieredPackagePrice, T> newSubscriptionTieredPackage,
        System::Func<NewSubscriptionTieredWithMinimumPrice, T> newSubscriptionTieredWithMinimum,
        System::Func<NewSubscriptionGroupedTieredPrice, T> newSubscriptionGroupedTiered,
        System::Func<
            NewSubscriptionTieredPackageWithMinimumPrice,
            T
        > newSubscriptionTieredPackageWithMinimum,
        System::Func<
            NewSubscriptionPackageWithAllocationPrice,
            T
        > newSubscriptionPackageWithAllocation,
        System::Func<NewSubscriptionUnitWithPercentPrice, T> newSubscriptionUnitWithPercent,
        System::Func<
            NewSubscriptionMatrixWithAllocationPrice,
            T
        > newSubscriptionMatrixWithAllocation,
        System::Func<AddPriceModelPriceTieredWithProration, T> tieredWithProration,
        System::Func<NewSubscriptionUnitWithProrationPrice, T> newSubscriptionUnitWithProration,
        System::Func<NewSubscriptionGroupedAllocationPrice, T> newSubscriptionGroupedAllocation,
        System::Func<NewSubscriptionBulkWithProrationPrice, T> newSubscriptionBulkWithProration,
        System::Func<
            NewSubscriptionGroupedWithProratedMinimumPrice,
            T
        > newSubscriptionGroupedWithProratedMinimum,
        System::Func<
            NewSubscriptionGroupedWithMeteredMinimumPrice,
            T
        > newSubscriptionGroupedWithMeteredMinimum,
        System::Func<AddPriceModelPriceGroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        System::Func<
            NewSubscriptionMatrixWithDisplayNamePrice,
            T
        > newSubscriptionMatrixWithDisplayName,
        System::Func<
            NewSubscriptionGroupedTieredPackagePrice,
            T
        > newSubscriptionGroupedTieredPackage,
        System::Func<
            NewSubscriptionMaxGroupTieredPackagePrice,
            T
        > newSubscriptionMaxGroupTieredPackage,
        System::Func<
            NewSubscriptionScalableMatrixWithUnitPricingPrice,
            T
        > newSubscriptionScalableMatrixWithUnitPricing,
        System::Func<
            NewSubscriptionScalableMatrixWithTieredPricingPrice,
            T
        > newSubscriptionScalableMatrixWithTieredPricing,
        System::Func<
            NewSubscriptionCumulativeGroupedBulkPrice,
            T
        > newSubscriptionCumulativeGroupedBulk,
        System::Func<AddPriceModelPriceCumulativeGroupedAllocation, T> cumulativeGroupedAllocation,
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<AddPriceModelPricePercent, T> percent,
        System::Func<AddPriceModelPriceEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            AddPriceModelPriceBulkWithFilters value => bulkWithFilters(value),
            NewSubscriptionPackagePrice value => newSubscriptionPackage(value),
            NewSubscriptionMatrixPrice value => newSubscriptionMatrix(value),
            NewSubscriptionThresholdTotalAmountPrice value => newSubscriptionThresholdTotalAmount(
                value
            ),
            NewSubscriptionTieredPackagePrice value => newSubscriptionTieredPackage(value),
            NewSubscriptionTieredWithMinimumPrice value => newSubscriptionTieredWithMinimum(value),
            NewSubscriptionGroupedTieredPrice value => newSubscriptionGroupedTiered(value),
            NewSubscriptionTieredPackageWithMinimumPrice value =>
                newSubscriptionTieredPackageWithMinimum(value),
            NewSubscriptionPackageWithAllocationPrice value => newSubscriptionPackageWithAllocation(
                value
            ),
            NewSubscriptionUnitWithPercentPrice value => newSubscriptionUnitWithPercent(value),
            NewSubscriptionMatrixWithAllocationPrice value => newSubscriptionMatrixWithAllocation(
                value
            ),
            AddPriceModelPriceTieredWithProration value => tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            AddPriceModelPriceGroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(
                value
            ),
            NewSubscriptionMatrixWithDisplayNamePrice value => newSubscriptionMatrixWithDisplayName(
                value
            ),
            NewSubscriptionGroupedTieredPackagePrice value => newSubscriptionGroupedTieredPackage(
                value
            ),
            NewSubscriptionMaxGroupTieredPackagePrice value => newSubscriptionMaxGroupTieredPackage(
                value
            ),
            NewSubscriptionScalableMatrixWithUnitPricingPrice value =>
                newSubscriptionScalableMatrixWithUnitPricing(value),
            NewSubscriptionScalableMatrixWithTieredPricingPrice value =>
                newSubscriptionScalableMatrixWithTieredPricing(value),
            NewSubscriptionCumulativeGroupedBulkPrice value => newSubscriptionCumulativeGroupedBulk(
                value
            ),
            AddPriceModelPriceCumulativeGroupedAllocation value => cumulativeGroupedAllocation(
                value
            ),
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            AddPriceModelPricePercent value => percent(value),
            AddPriceModelPriceEventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPrice"
            ),
        };
    }

    public static implicit operator AddPriceModelPrice(NewSubscriptionUnitPrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(NewSubscriptionTieredPrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(NewSubscriptionBulkPrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(AddPriceModelPriceBulkWithFilters value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(NewSubscriptionPackagePrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(NewSubscriptionMatrixPrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(NewSubscriptionTieredPackagePrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(NewSubscriptionGroupedTieredPrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(NewSubscriptionUnitWithPercentPrice value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        AddPriceModelPriceTieredWithProration value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        AddPriceModelPriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        AddPriceModelPriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(
        NewSubscriptionMinimumCompositePrice value
    ) => new(value);

    public static implicit operator AddPriceModelPrice(AddPriceModelPricePercent value) =>
        new(value);

    public static implicit operator AddPriceModelPrice(AddPriceModelPriceEventOutput value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPrice"
            );
        }
    }
}

sealed class AddPriceModelPriceConverter : JsonConverter<AddPriceModelPrice?>
{
    public override AddPriceModelPrice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = json.GetProperty("model_type").GetString();
        }
        catch
        {
            modelType = null;
        }

        switch (modelType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionUnitPrice>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionTieredPrice>(
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
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionBulkPrice>(
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
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<AddPriceModelPriceBulkWithFilters>(
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
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionPackagePrice>(
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
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixPrice>(
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
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionThresholdTotalAmountPrice>(
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
            case "tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackagePrice>(
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
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredWithMinimumPrice>(
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
            case "grouped_tiered":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPrice>(
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
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackageWithMinimumPrice>(
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
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionPackageWithAllocationPrice>(
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
            case "unit_with_percent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithPercentPrice>(
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
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPrice>(
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
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<AddPriceModelPriceTieredWithProration>(
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
            case "unit_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithProrationPrice>(
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
            case "grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedAllocationPrice>(
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
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionBulkWithProrationPrice>(
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
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithProratedMinimumPrice>(
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
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithMeteredMinimumPrice>(
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
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<AddPriceModelPriceGroupedWithMinMaxThresholds>(
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
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithDisplayNamePrice>(
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
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPackagePrice>(
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
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMaxGroupTieredPackagePrice>(
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
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithUnitPricingPrice>(
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
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithTieredPricingPrice>(
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
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionCumulativeGroupedBulkPrice>(
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
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<AddPriceModelPriceCumulativeGroupedAllocation>(
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
            case "minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMinimumCompositePrice>(
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
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AddPriceModelPricePercent>(
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
            case "event_output":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AddPriceModelPriceEventOutput>(
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
                return new AddPriceModelPrice(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceBulkWithFilters,
        AddPriceModelPriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class AddPriceModelPriceBulkWithFilters : ModelBase
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentNullException("bulk_with_filters_config")
                );
        }
        init
        {
            this._rawData["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, AddPriceModelPriceBulkWithFiltersCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AddPriceModelPriceBulkWithFiltersCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public AddPriceModelPriceBulkWithFiltersModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceBulkWithFiltersModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public AddPriceModelPriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceModelPriceBulkWithFiltersConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public AddPriceModelPriceBulkWithFilters()
    {
        this.ModelType = new();
    }

    public AddPriceModelPriceBulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceBulkWithFiltersFromRaw : IFromRaw<AddPriceModelPriceBulkWithFilters>
{
    public AddPriceModelPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig,
        AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig : ModelBase
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Filter2> Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Filter2>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._rawData["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Tier4> Tiers
    {
        get
        {
            if (!this._rawData.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Tier4>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._rawData["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig() { }

    public AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRaw<AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig>
{
    public AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Filter2,
        global::Orb.Models.Subscriptions.Filter2FromRaw
    >)
)]
public sealed record class Filter2 : ModelBase
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._rawData.TryGetValue("property_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentNullException("property_key")
                );
        }
        init
        {
            this._rawData["property_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            if (!this._rawData.TryGetValue("property_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentNullException("property_value")
                );
        }
        init
        {
            this._rawData["property_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter2() { }

    public Filter2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Filter2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter2FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Filter2>
{
    public global::Orb.Models.Subscriptions.Filter2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Filter2.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Tier4,
        global::Orb.Models.Subscriptions.Tier4FromRaw
    >)
)]
public sealed record class Tier4 : ModelBase
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            if (!this._rawData.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier4() { }

    public Tier4(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier4(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier4 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier4(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class Tier4FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Tier4>
{
    public global::Orb.Models.Subscriptions.Tier4 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Tier4.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(AddPriceModelPriceBulkWithFiltersCadenceConverter))]
public enum AddPriceModelPriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class AddPriceModelPriceBulkWithFiltersCadenceConverter
    : JsonConverter<AddPriceModelPriceBulkWithFiltersCadence>
{
    public override AddPriceModelPriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => AddPriceModelPriceBulkWithFiltersCadence.Annual,
            "semi_annual" => AddPriceModelPriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" => AddPriceModelPriceBulkWithFiltersCadence.Monthly,
            "quarterly" => AddPriceModelPriceBulkWithFiltersCadence.Quarterly,
            "one_time" => AddPriceModelPriceBulkWithFiltersCadence.OneTime,
            "custom" => AddPriceModelPriceBulkWithFiltersCadence.Custom,
            _ => (AddPriceModelPriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddPriceModelPriceBulkWithFiltersCadence.Annual => "annual",
                AddPriceModelPriceBulkWithFiltersCadence.SemiAnnual => "semi_annual",
                AddPriceModelPriceBulkWithFiltersCadence.Monthly => "monthly",
                AddPriceModelPriceBulkWithFiltersCadence.Quarterly => "quarterly",
                AddPriceModelPriceBulkWithFiltersCadence.OneTime => "one_time",
                AddPriceModelPriceBulkWithFiltersCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class AddPriceModelPriceBulkWithFiltersModelType
{
    public JsonElement Json { get; private init; }

    public AddPriceModelPriceBulkWithFiltersModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    AddPriceModelPriceBulkWithFiltersModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(this.Json, new AddPriceModelPriceBulkWithFiltersModelType().Json)
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'AddPriceModelPriceBulkWithFiltersModelType'"
            );
        }
    }

    class Converter : JsonConverter<AddPriceModelPriceBulkWithFiltersModelType>
    {
        public override AddPriceModelPriceBulkWithFiltersModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPriceModelPriceBulkWithFiltersModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(AddPriceModelPriceBulkWithFiltersConversionRateConfigConverter))]
public record class AddPriceModelPriceBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddPriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceBulkWithFiltersConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddPriceModelPriceBulkWithFiltersConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator AddPriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator AddPriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceBulkWithFiltersConversionRateConfig"
            );
        }
    }
}

sealed class AddPriceModelPriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<AddPriceModelPriceBulkWithFiltersConversionRateConfig>
{
    public override AddPriceModelPriceBulkWithFiltersConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new AddPriceModelPriceBulkWithFiltersConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceTieredWithProration,
        AddPriceModelPriceTieredWithProrationFromRaw
    >)
)]
public sealed record class AddPriceModelPriceTieredWithProration : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, AddPriceModelPriceTieredWithProrationCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AddPriceModelPriceTieredWithProrationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public AddPriceModelPriceTieredWithProrationModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceTieredWithProrationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required AddPriceModelPriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("tiered_with_proration_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_with_proration_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceTieredWithProrationTieredWithProrationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentNullException("tiered_with_proration_config")
                );
        }
        init
        {
            this._rawData["tiered_with_proration_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public AddPriceModelPriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceModelPriceTieredWithProrationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.TieredWithProrationConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public AddPriceModelPriceTieredWithProration()
    {
        this.ModelType = new();
    }

    public AddPriceModelPriceTieredWithProration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceTieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceTieredWithProrationFromRaw : IFromRaw<AddPriceModelPriceTieredWithProration>
{
    public AddPriceModelPriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceTieredWithProration.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(AddPriceModelPriceTieredWithProrationCadenceConverter))]
public enum AddPriceModelPriceTieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class AddPriceModelPriceTieredWithProrationCadenceConverter
    : JsonConverter<AddPriceModelPriceTieredWithProrationCadence>
{
    public override AddPriceModelPriceTieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => AddPriceModelPriceTieredWithProrationCadence.Annual,
            "semi_annual" => AddPriceModelPriceTieredWithProrationCadence.SemiAnnual,
            "monthly" => AddPriceModelPriceTieredWithProrationCadence.Monthly,
            "quarterly" => AddPriceModelPriceTieredWithProrationCadence.Quarterly,
            "one_time" => AddPriceModelPriceTieredWithProrationCadence.OneTime,
            "custom" => AddPriceModelPriceTieredWithProrationCadence.Custom,
            _ => (AddPriceModelPriceTieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceTieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddPriceModelPriceTieredWithProrationCadence.Annual => "annual",
                AddPriceModelPriceTieredWithProrationCadence.SemiAnnual => "semi_annual",
                AddPriceModelPriceTieredWithProrationCadence.Monthly => "monthly",
                AddPriceModelPriceTieredWithProrationCadence.Quarterly => "quarterly",
                AddPriceModelPriceTieredWithProrationCadence.OneTime => "one_time",
                AddPriceModelPriceTieredWithProrationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class AddPriceModelPriceTieredWithProrationModelType
{
    public JsonElement Json { get; private init; }

    public AddPriceModelPriceTieredWithProrationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    AddPriceModelPriceTieredWithProrationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new AddPriceModelPriceTieredWithProrationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'AddPriceModelPriceTieredWithProrationModelType'"
            );
        }
    }

    class Converter : JsonConverter<AddPriceModelPriceTieredWithProrationModelType>
    {
        public override AddPriceModelPriceTieredWithProrationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPriceModelPriceTieredWithProrationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceTieredWithProrationTieredWithProrationConfig,
        AddPriceModelPriceTieredWithProrationTieredWithProrationConfigFromRaw
    >)
)]
public sealed record class AddPriceModelPriceTieredWithProrationTieredWithProrationConfig
    : ModelBase
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Tier5> Tiers
    {
        get
        {
            if (!this._rawData.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Tier5>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._rawData["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public AddPriceModelPriceTieredWithProrationTieredWithProrationConfig() { }

    public AddPriceModelPriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddPriceModelPriceTieredWithProrationTieredWithProrationConfig(
        List<global::Orb.Models.Subscriptions.Tier5> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class AddPriceModelPriceTieredWithProrationTieredWithProrationConfigFromRaw
    : IFromRaw<AddPriceModelPriceTieredWithProrationTieredWithProrationConfig>
{
    public AddPriceModelPriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceTieredWithProrationTieredWithProrationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Tier5,
        global::Orb.Models.Subscriptions.Tier5FromRaw
    >)
)]
public sealed record class Tier5 : ModelBase
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._rawData.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tier_lower_bound",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentNullException("tier_lower_bound")
                );
        }
        init
        {
            this._rawData["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier5() { }

    public Tier5(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier5(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier5 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Tier5FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Tier5>
{
    public global::Orb.Models.Subscriptions.Tier5 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Tier5.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddPriceModelPriceTieredWithProrationConversionRateConfigConverter))]
public record class AddPriceModelPriceTieredWithProrationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddPriceModelPriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceTieredWithProrationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddPriceModelPriceTieredWithProrationConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceTieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator AddPriceModelPriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator AddPriceModelPriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceTieredWithProrationConversionRateConfig"
            );
        }
    }
}

sealed class AddPriceModelPriceTieredWithProrationConversionRateConfigConverter
    : JsonConverter<AddPriceModelPriceTieredWithProrationConversionRateConfig>
{
    public override AddPriceModelPriceTieredWithProrationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new AddPriceModelPriceTieredWithProrationConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceTieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceGroupedWithMinMaxThresholds,
        AddPriceModelPriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class AddPriceModelPriceGroupedWithMinMaxThresholds : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, AddPriceModelPriceGroupedWithMinMaxThresholdsCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AddPriceModelPriceGroupedWithMinMaxThresholdsCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "grouped_with_min_max_thresholds_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_with_min_max_thresholds_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentNullException("grouped_with_min_max_thresholds_config")
                );
        }
        init
        {
            this._rawData["grouped_with_min_max_thresholds_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public AddPriceModelPriceGroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceGroupedWithMinMaxThresholdsModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public AddPriceModelPriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = new();
    }

    public AddPriceModelPriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRaw<AddPriceModelPriceGroupedWithMinMaxThresholds>
{
    public AddPriceModelPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceGroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(AddPriceModelPriceGroupedWithMinMaxThresholdsCadenceConverter))]
public enum AddPriceModelPriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class AddPriceModelPriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<AddPriceModelPriceGroupedWithMinMaxThresholdsCadence>
{
    public override AddPriceModelPriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ => (AddPriceModelPriceGroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Annual => "annual",
                AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual => "semi_annual",
                AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Quarterly => "quarterly",
                AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                AddPriceModelPriceGroupedWithMinMaxThresholdsCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_with_min_max_thresholds pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : ModelBase
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            if (!this._rawData.TryGetValue("maximum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentNullException("maximum_charge")
                );
        }
        init
        {
            this._rawData["maximum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            if (!this._rawData.TryGetValue("minimum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentNullException("minimum_charge")
                );
        }
        init
        {
            this._rawData["minimum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            if (!this._rawData.TryGetValue("per_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "per_unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentNullException("per_unit_rate")
                );
        }
        init
        {
            this._rawData["per_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig() { }

    public AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRaw<AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    public AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        AddPriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class AddPriceModelPriceGroupedWithMinMaxThresholdsModelType
{
    public JsonElement Json { get; private init; }

    public AddPriceModelPriceGroupedWithMinMaxThresholdsModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    AddPriceModelPriceGroupedWithMinMaxThresholdsModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new AddPriceModelPriceGroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'AddPriceModelPriceGroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter : JsonConverter<AddPriceModelPriceGroupedWithMinMaxThresholdsModelType>
    {
        public override AddPriceModelPriceGroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPriceModelPriceGroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter))]
public record class AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
    }
}

sealed class AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceCumulativeGroupedAllocation,
        AddPriceModelPriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class AddPriceModelPriceCumulativeGroupedAllocation : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, AddPriceModelPriceCumulativeGroupedAllocationCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AddPriceModelPriceCumulativeGroupedAllocationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "cumulative_grouped_allocation_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_grouped_allocation_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentNullException("cumulative_grouped_allocation_config")
                );
        }
        init
        {
            this._rawData["cumulative_grouped_allocation_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public AddPriceModelPriceCumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceCumulativeGroupedAllocationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public AddPriceModelPriceCumulativeGroupedAllocation()
    {
        this.ModelType = new();
    }

    public AddPriceModelPriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceCumulativeGroupedAllocationFromRaw
    : IFromRaw<AddPriceModelPriceCumulativeGroupedAllocation>
{
    public AddPriceModelPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceCumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(AddPriceModelPriceCumulativeGroupedAllocationCadenceConverter))]
public enum AddPriceModelPriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class AddPriceModelPriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<AddPriceModelPriceCumulativeGroupedAllocationCadence>
{
    public override AddPriceModelPriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => AddPriceModelPriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => AddPriceModelPriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => AddPriceModelPriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => AddPriceModelPriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => AddPriceModelPriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" => AddPriceModelPriceCumulativeGroupedAllocationCadence.Custom,
            _ => (AddPriceModelPriceCumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddPriceModelPriceCumulativeGroupedAllocationCadence.Annual => "annual",
                AddPriceModelPriceCumulativeGroupedAllocationCadence.SemiAnnual => "semi_annual",
                AddPriceModelPriceCumulativeGroupedAllocationCadence.Monthly => "monthly",
                AddPriceModelPriceCumulativeGroupedAllocationCadence.Quarterly => "quarterly",
                AddPriceModelPriceCumulativeGroupedAllocationCadence.OneTime => "one_time",
                AddPriceModelPriceCumulativeGroupedAllocationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for cumulative_grouped_allocation pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : ModelBase
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            if (!this._rawData.TryGetValue("cumulative_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentNullException("cumulative_allocation")
                );
        }
        init
        {
            this._rawData["cumulative_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            if (!this._rawData.TryGetValue("group_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "group_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentNullException("group_allocation")
                );
        }
        init
        {
            this._rawData["group_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig() { }

    public AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRaw<AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    public AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        AddPriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class AddPriceModelPriceCumulativeGroupedAllocationModelType
{
    public JsonElement Json { get; private init; }

    public AddPriceModelPriceCumulativeGroupedAllocationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"");
    }

    AddPriceModelPriceCumulativeGroupedAllocationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new AddPriceModelPriceCumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'AddPriceModelPriceCumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter : JsonConverter<AddPriceModelPriceCumulativeGroupedAllocationModelType>
    {
        public override AddPriceModelPriceCumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPriceModelPriceCumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfigConverter))]
public record class AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
    }
}

sealed class AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<AddPriceModelPricePercent, AddPriceModelPricePercentFromRaw>))]
public sealed record class AddPriceModelPricePercent : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, AddPriceModelPricePercentCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AddPriceModelPricePercentCadence>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public AddPriceModelPricePercentModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPricePercentModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// Configuration for percent pricing
    /// </summary>
    public required AddPriceModelPricePercentPercentConfig PercentConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPricePercentPercentConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentNullException("percent_config")
                );
        }
        init
        {
            this._rawData["percent_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public AddPriceModelPricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceModelPricePercentConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.PercentConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public AddPriceModelPricePercent()
    {
        this.ModelType = new();
    }

    public AddPriceModelPricePercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPricePercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPricePercentFromRaw : IFromRaw<AddPriceModelPricePercent>
{
    public AddPriceModelPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(AddPriceModelPricePercentCadenceConverter))]
public enum AddPriceModelPricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class AddPriceModelPricePercentCadenceConverter
    : JsonConverter<AddPriceModelPricePercentCadence>
{
    public override AddPriceModelPricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => AddPriceModelPricePercentCadence.Annual,
            "semi_annual" => AddPriceModelPricePercentCadence.SemiAnnual,
            "monthly" => AddPriceModelPricePercentCadence.Monthly,
            "quarterly" => AddPriceModelPricePercentCadence.Quarterly,
            "one_time" => AddPriceModelPricePercentCadence.OneTime,
            "custom" => AddPriceModelPricePercentCadence.Custom,
            _ => (AddPriceModelPricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddPriceModelPricePercentCadence.Annual => "annual",
                AddPriceModelPricePercentCadence.SemiAnnual => "semi_annual",
                AddPriceModelPricePercentCadence.Monthly => "monthly",
                AddPriceModelPricePercentCadence.Quarterly => "quarterly",
                AddPriceModelPricePercentCadence.OneTime => "one_time",
                AddPriceModelPricePercentCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class AddPriceModelPricePercentModelType
{
    public JsonElement Json { get; private init; }

    public AddPriceModelPricePercentModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    AddPriceModelPricePercentModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new AddPriceModelPricePercentModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'AddPriceModelPricePercentModelType'"
            );
        }
    }

    class Converter : JsonConverter<AddPriceModelPricePercentModelType>
    {
        public override AddPriceModelPricePercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPriceModelPricePercentModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPricePercentPercentConfig,
        AddPriceModelPricePercentPercentConfigFromRaw
    >)
)]
public sealed record class AddPriceModelPricePercentPercentConfig : ModelBase
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._rawData.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public AddPriceModelPricePercentPercentConfig() { }

    public AddPriceModelPricePercentPercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPricePercentPercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddPriceModelPricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class AddPriceModelPricePercentPercentConfigFromRaw
    : IFromRaw<AddPriceModelPricePercentPercentConfig>
{
    public AddPriceModelPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPricePercentPercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddPriceModelPricePercentConversionRateConfigConverter))]
public record class AddPriceModelPricePercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddPriceModelPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPricePercentConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddPriceModelPricePercentConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator AddPriceModelPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator AddPriceModelPricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPricePercentConversionRateConfig"
            );
        }
    }
}

sealed class AddPriceModelPricePercentConversionRateConfigConverter
    : JsonConverter<AddPriceModelPricePercentConversionRateConfig>
{
    public override AddPriceModelPricePercentConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new AddPriceModelPricePercentConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<AddPriceModelPriceEventOutput, AddPriceModelPriceEventOutputFromRaw>)
)]
public sealed record class AddPriceModelPriceEventOutput : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, AddPriceModelPriceEventOutputCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AddPriceModelPriceEventOutputCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required AddPriceModelPriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceEventOutputEventOutputConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentNullException("event_output_config")
                );
        }
        init
        {
            this._rawData["event_output_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public AddPriceModelPriceEventOutputModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddPriceModelPriceEventOutputModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public AddPriceModelPriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceModelPriceEventOutputConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public AddPriceModelPriceEventOutput()
    {
        this.ModelType = new();
    }

    public AddPriceModelPriceEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceModelPriceEventOutputFromRaw : IFromRaw<AddPriceModelPriceEventOutput>
{
    public AddPriceModelPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(AddPriceModelPriceEventOutputCadenceConverter))]
public enum AddPriceModelPriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class AddPriceModelPriceEventOutputCadenceConverter
    : JsonConverter<AddPriceModelPriceEventOutputCadence>
{
    public override AddPriceModelPriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => AddPriceModelPriceEventOutputCadence.Annual,
            "semi_annual" => AddPriceModelPriceEventOutputCadence.SemiAnnual,
            "monthly" => AddPriceModelPriceEventOutputCadence.Monthly,
            "quarterly" => AddPriceModelPriceEventOutputCadence.Quarterly,
            "one_time" => AddPriceModelPriceEventOutputCadence.OneTime,
            "custom" => AddPriceModelPriceEventOutputCadence.Custom,
            _ => (AddPriceModelPriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddPriceModelPriceEventOutputCadence.Annual => "annual",
                AddPriceModelPriceEventOutputCadence.SemiAnnual => "semi_annual",
                AddPriceModelPriceEventOutputCadence.Monthly => "monthly",
                AddPriceModelPriceEventOutputCadence.Quarterly => "quarterly",
                AddPriceModelPriceEventOutputCadence.OneTime => "one_time",
                AddPriceModelPriceEventOutputCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for event_output pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        AddPriceModelPriceEventOutputEventOutputConfig,
        AddPriceModelPriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class AddPriceModelPriceEventOutputEventOutputConfig : ModelBase
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_rating_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_rating_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentNullException("unit_rating_key")
                );
        }
        init
        {
            this._rawData["unit_rating_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get
        {
            if (!this._rawData.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["default_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public AddPriceModelPriceEventOutputEventOutputConfig() { }

    public AddPriceModelPriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModelPriceEventOutputEventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddPriceModelPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddPriceModelPriceEventOutputEventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class AddPriceModelPriceEventOutputEventOutputConfigFromRaw
    : IFromRaw<AddPriceModelPriceEventOutputEventOutputConfig>
{
    public AddPriceModelPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddPriceModelPriceEventOutputEventOutputConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class AddPriceModelPriceEventOutputModelType
{
    public JsonElement Json { get; private init; }

    public AddPriceModelPriceEventOutputModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    AddPriceModelPriceEventOutputModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new AddPriceModelPriceEventOutputModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'AddPriceModelPriceEventOutputModelType'"
            );
        }
    }

    class Converter : JsonConverter<AddPriceModelPriceEventOutputModelType>
    {
        public override AddPriceModelPriceEventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPriceModelPriceEventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(AddPriceModelPriceEventOutputConversionRateConfigConverter))]
public record class AddPriceModelPriceEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddPriceModelPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddPriceModelPriceEventOutputConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddPriceModelPriceEventOutputConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator AddPriceModelPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator AddPriceModelPriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddPriceModelPriceEventOutputConversionRateConfig"
            );
        }
    }
}

sealed class AddPriceModelPriceEventOutputConversionRateConfigConverter
    : JsonConverter<AddPriceModelPriceEventOutputConversionRateConfig>
{
    public override AddPriceModelPriceEventOutputConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new AddPriceModelPriceEventOutputConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddPriceModelPriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Reset billing periods to be aligned with the plan change's effective date or start
/// of the month. Defaults to `unchanged` which keeps subscription's existing billing
/// cycle alignment.
/// </summary>
[JsonConverter(typeof(BillingCycleAlignmentConverter))]
public enum BillingCycleAlignment
{
    Unchanged,
    PlanChangeDate,
    StartOfMonth,
}

sealed class BillingCycleAlignmentConverter : JsonConverter<BillingCycleAlignment>
{
    public override BillingCycleAlignment Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unchanged" => BillingCycleAlignment.Unchanged,
            "plan_change_date" => BillingCycleAlignment.PlanChangeDate,
            "start_of_month" => BillingCycleAlignment.StartOfMonth,
            _ => (BillingCycleAlignment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingCycleAlignment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingCycleAlignment.Unchanged => "unchanged",
                BillingCycleAlignment.PlanChangeDate => "plan_change_date",
                BillingCycleAlignment.StartOfMonth => "start_of_month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<RemoveAdjustmentModel, RemoveAdjustmentModelFromRaw>))]
public sealed record class RemoveAdjustmentModel : ModelBase
{
    /// <summary>
    /// The id of the adjustment to remove on the subscription.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            if (!this._rawData.TryGetValue("adjustment_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment_id' cannot be null",
                    new System::ArgumentNullException("adjustment_id")
                );
        }
        init
        {
            this._rawData["adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AdjustmentID;
    }

    public RemoveAdjustmentModel() { }

    public RemoveAdjustmentModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveAdjustmentModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static RemoveAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RemoveAdjustmentModel(string adjustmentID)
        : this()
    {
        this.AdjustmentID = adjustmentID;
    }
}

class RemoveAdjustmentModelFromRaw : IFromRaw<RemoveAdjustmentModel>
{
    public RemoveAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RemoveAdjustmentModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<RemovePriceModel, RemovePriceModelFromRaw>))]
public sealed record class RemovePriceModel : ModelBase
{
    /// <summary>
    /// The external price id of the price to remove on the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the price to remove on the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ExternalPriceID;
        _ = this.PriceID;
    }

    public RemovePriceModel() { }

    public RemovePriceModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovePriceModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static RemovePriceModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RemovePriceModelFromRaw : IFromRaw<RemovePriceModel>
{
    public RemovePriceModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RemovePriceModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ReplaceAdjustmentModel, ReplaceAdjustmentModelFromRaw>))]
public sealed record class ReplaceAdjustmentModel : ModelBase
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required ReplaceAdjustmentModelAdjustment Adjustment
    {
        get
        {
            if (!this._rawData.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplaceAdjustmentModelAdjustment>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentNullException("adjustment")
                );
        }
        init
        {
            this._rawData["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the adjustment on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get
        {
            if (!this._rawData.TryGetValue("replaces_adjustment_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'replaces_adjustment_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "replaces_adjustment_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'replaces_adjustment_id' cannot be null",
                    new System::ArgumentNullException("replaces_adjustment_id")
                );
        }
        init
        {
            this._rawData["replaces_adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.ReplacesAdjustmentID;
    }

    public ReplaceAdjustmentModel() { }

    public ReplaceAdjustmentModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplaceAdjustmentModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplaceAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplaceAdjustmentModelFromRaw : IFromRaw<ReplaceAdjustmentModel>
{
    public ReplaceAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplaceAdjustmentModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(ReplaceAdjustmentModelAdjustmentConverter))]
public record class ReplaceAdjustmentModelAdjustment
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newPercentageDiscount: (x) => x.Currency,
                newUsageDiscount: (x) => x.Currency,
                newAmountDiscount: (x) => x.Currency,
                newMinimum: (x) => x.Currency,
                newMaximum: (x) => x.Currency
            );
        }
    }

    public bool? IsInvoiceLevel
    {
        get
        {
            return Match<bool?>(
                newPercentageDiscount: (x) => x.IsInvoiceLevel,
                newUsageDiscount: (x) => x.IsInvoiceLevel,
                newAmountDiscount: (x) => x.IsInvoiceLevel,
                newMinimum: (x) => x.IsInvoiceLevel,
                newMaximum: (x) => x.IsInvoiceLevel
            );
        }
    }

    public ReplaceAdjustmentModelAdjustment(NewPercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentModelAdjustment(NewUsageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentModelAdjustment(NewAmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentModelAdjustment(NewMinimum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentModelAdjustment(NewMaximum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentModelAdjustment(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
        return value != null;
    }

    public void Switch(
        System::Action<NewPercentageDiscount> newPercentageDiscount,
        System::Action<NewUsageDiscount> newUsageDiscount,
        System::Action<NewAmountDiscount> newAmountDiscount,
        System::Action<NewMinimum> newMinimum,
        System::Action<NewMaximum> newMaximum
    )
    {
        switch (this.Value)
        {
            case NewPercentageDiscount value:
                newPercentageDiscount(value);
                break;
            case NewUsageDiscount value:
                newUsageDiscount(value);
                break;
            case NewAmountDiscount value:
                newAmountDiscount(value);
                break;
            case NewMinimum value:
                newMinimum(value);
                break;
            case NewMaximum value:
                newMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplaceAdjustmentModelAdjustment"
                );
        }
    }

    public T Match<T>(
        System::Func<NewPercentageDiscount, T> newPercentageDiscount,
        System::Func<NewUsageDiscount, T> newUsageDiscount,
        System::Func<NewAmountDiscount, T> newAmountDiscount,
        System::Func<NewMinimum, T> newMinimum,
        System::Func<NewMaximum, T> newMaximum
    )
    {
        return this.Value switch
        {
            NewPercentageDiscount value => newPercentageDiscount(value),
            NewUsageDiscount value => newUsageDiscount(value),
            NewAmountDiscount value => newAmountDiscount(value),
            NewMinimum value => newMinimum(value),
            NewMaximum value => newMaximum(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplaceAdjustmentModelAdjustment"
            ),
        };
    }

    public static implicit operator ReplaceAdjustmentModelAdjustment(NewPercentageDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentModelAdjustment(NewUsageDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentModelAdjustment(NewAmountDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentModelAdjustment(NewMinimum value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentModelAdjustment(NewMaximum value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplaceAdjustmentModelAdjustment"
            );
        }
    }
}

sealed class ReplaceAdjustmentModelAdjustmentConverter
    : JsonConverter<ReplaceAdjustmentModelAdjustment>
{
    public override ReplaceAdjustmentModelAdjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = json.GetProperty("adjustment_type").GetString();
        }
        catch
        {
            adjustmentType = null;
        }

        switch (adjustmentType)
        {
            case "percentage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
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
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
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
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
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
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
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
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
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
                return new ReplaceAdjustmentModelAdjustment(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplaceAdjustmentModelAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<ReplacePriceModel, ReplacePriceModelFromRaw>))]
public sealed record class ReplacePriceModel : ModelBase
{
    /// <summary>
    /// The id of the price on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("replaces_price_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'replaces_price_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "replaces_price_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'replaces_price_id' cannot be null",
                    new System::ArgumentNullException("replaces_price_id")
                );
        }
        init
        {
            this._rawData["replaces_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this._rawData.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["allocation_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's discounts for
    /// the replacement price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public IReadOnlyList<DiscountOverride>? Discounts
    {
        get
        {
            if (!this._rawData.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DiscountOverride>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The new quantity of the price, if the price is a fixed price.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for the replacement price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MaximumAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for the replacement price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MinimumAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public ReplacePriceModelPrice? Price
    {
        get
        {
            if (!this._rawData.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceModelPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ReplacesPriceID;
        this.AllocationPrice?.Validate();
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.MaximumAmount;
        _ = this.MinimumAmount;
        this.Price?.Validate();
        _ = this.PriceID;
    }

    public ReplacePriceModel() { }

    public ReplacePriceModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePriceModel(string replacesPriceID)
        : this()
    {
        this.ReplacesPriceID = replacesPriceID;
    }
}

class ReplacePriceModelFromRaw : IFromRaw<ReplacePriceModel>
{
    public ReplacePriceModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReplacePriceModel.FromRawUnchecked(rawData);
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(ReplacePriceModelPriceConverter))]
public record class ReplacePriceModelPrice
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string ItemID
    {
        get
        {
            return Match(
                newSubscriptionUnit: (x) => x.ItemID,
                newSubscriptionTiered: (x) => x.ItemID,
                newSubscriptionBulk: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newSubscriptionPackage: (x) => x.ItemID,
                newSubscriptionMatrix: (x) => x.ItemID,
                newSubscriptionThresholdTotalAmount: (x) => x.ItemID,
                newSubscriptionTieredPackage: (x) => x.ItemID,
                newSubscriptionTieredWithMinimum: (x) => x.ItemID,
                newSubscriptionGroupedTiered: (x) => x.ItemID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ItemID,
                newSubscriptionPackageWithAllocation: (x) => x.ItemID,
                newSubscriptionUnitWithPercent: (x) => x.ItemID,
                newSubscriptionMatrixWithAllocation: (x) => x.ItemID,
                tieredWithProration: (x) => x.ItemID,
                newSubscriptionUnitWithProration: (x) => x.ItemID,
                newSubscriptionGroupedAllocation: (x) => x.ItemID,
                newSubscriptionBulkWithProration: (x) => x.ItemID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ItemID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newSubscriptionMatrixWithDisplayName: (x) => x.ItemID,
                newSubscriptionGroupedTieredPackage: (x) => x.ItemID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ItemID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ItemID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ItemID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ItemID,
                cumulativeGroupedAllocation: (x) => x.ItemID,
                newSubscriptionMinimumComposite: (x) => x.ItemID,
                percent: (x) => x.ItemID,
                eventOutput: (x) => x.ItemID
            );
        }
    }

    public string Name
    {
        get
        {
            return Match(
                newSubscriptionUnit: (x) => x.Name,
                newSubscriptionTiered: (x) => x.Name,
                newSubscriptionBulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newSubscriptionPackage: (x) => x.Name,
                newSubscriptionMatrix: (x) => x.Name,
                newSubscriptionThresholdTotalAmount: (x) => x.Name,
                newSubscriptionTieredPackage: (x) => x.Name,
                newSubscriptionTieredWithMinimum: (x) => x.Name,
                newSubscriptionGroupedTiered: (x) => x.Name,
                newSubscriptionTieredPackageWithMinimum: (x) => x.Name,
                newSubscriptionPackageWithAllocation: (x) => x.Name,
                newSubscriptionUnitWithPercent: (x) => x.Name,
                newSubscriptionMatrixWithAllocation: (x) => x.Name,
                tieredWithProration: (x) => x.Name,
                newSubscriptionUnitWithProration: (x) => x.Name,
                newSubscriptionGroupedAllocation: (x) => x.Name,
                newSubscriptionBulkWithProration: (x) => x.Name,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.Name,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newSubscriptionMatrixWithDisplayName: (x) => x.Name,
                newSubscriptionGroupedTieredPackage: (x) => x.Name,
                newSubscriptionMaxGroupTieredPackage: (x) => x.Name,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.Name,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.Name,
                newSubscriptionCumulativeGroupedBulk: (x) => x.Name,
                cumulativeGroupedAllocation: (x) => x.Name,
                newSubscriptionMinimumComposite: (x) => x.Name,
                percent: (x) => x.Name,
                eventOutput: (x) => x.Name
            );
        }
    }

    public string? BillableMetricID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.BillableMetricID,
                newSubscriptionTiered: (x) => x.BillableMetricID,
                newSubscriptionBulk: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newSubscriptionPackage: (x) => x.BillableMetricID,
                newSubscriptionMatrix: (x) => x.BillableMetricID,
                newSubscriptionThresholdTotalAmount: (x) => x.BillableMetricID,
                newSubscriptionTieredPackage: (x) => x.BillableMetricID,
                newSubscriptionTieredWithMinimum: (x) => x.BillableMetricID,
                newSubscriptionGroupedTiered: (x) => x.BillableMetricID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.BillableMetricID,
                newSubscriptionPackageWithAllocation: (x) => x.BillableMetricID,
                newSubscriptionUnitWithPercent: (x) => x.BillableMetricID,
                newSubscriptionMatrixWithAllocation: (x) => x.BillableMetricID,
                tieredWithProration: (x) => x.BillableMetricID,
                newSubscriptionUnitWithProration: (x) => x.BillableMetricID,
                newSubscriptionGroupedAllocation: (x) => x.BillableMetricID,
                newSubscriptionBulkWithProration: (x) => x.BillableMetricID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.BillableMetricID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newSubscriptionMatrixWithDisplayName: (x) => x.BillableMetricID,
                newSubscriptionGroupedTieredPackage: (x) => x.BillableMetricID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.BillableMetricID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.BillableMetricID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.BillableMetricID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.BillableMetricID,
                cumulativeGroupedAllocation: (x) => x.BillableMetricID,
                newSubscriptionMinimumComposite: (x) => x.BillableMetricID,
                percent: (x) => x.BillableMetricID,
                eventOutput: (x) => x.BillableMetricID
            );
        }
    }

    public bool? BilledInAdvance
    {
        get
        {
            return Match<bool?>(
                newSubscriptionUnit: (x) => x.BilledInAdvance,
                newSubscriptionTiered: (x) => x.BilledInAdvance,
                newSubscriptionBulk: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newSubscriptionPackage: (x) => x.BilledInAdvance,
                newSubscriptionMatrix: (x) => x.BilledInAdvance,
                newSubscriptionThresholdTotalAmount: (x) => x.BilledInAdvance,
                newSubscriptionTieredPackage: (x) => x.BilledInAdvance,
                newSubscriptionTieredWithMinimum: (x) => x.BilledInAdvance,
                newSubscriptionGroupedTiered: (x) => x.BilledInAdvance,
                newSubscriptionTieredPackageWithMinimum: (x) => x.BilledInAdvance,
                newSubscriptionPackageWithAllocation: (x) => x.BilledInAdvance,
                newSubscriptionUnitWithPercent: (x) => x.BilledInAdvance,
                newSubscriptionMatrixWithAllocation: (x) => x.BilledInAdvance,
                tieredWithProration: (x) => x.BilledInAdvance,
                newSubscriptionUnitWithProration: (x) => x.BilledInAdvance,
                newSubscriptionGroupedAllocation: (x) => x.BilledInAdvance,
                newSubscriptionBulkWithProration: (x) => x.BilledInAdvance,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.BilledInAdvance,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newSubscriptionMatrixWithDisplayName: (x) => x.BilledInAdvance,
                newSubscriptionGroupedTieredPackage: (x) => x.BilledInAdvance,
                newSubscriptionMaxGroupTieredPackage: (x) => x.BilledInAdvance,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.BilledInAdvance,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.BilledInAdvance,
                newSubscriptionCumulativeGroupedBulk: (x) => x.BilledInAdvance,
                cumulativeGroupedAllocation: (x) => x.BilledInAdvance,
                newSubscriptionMinimumComposite: (x) => x.BilledInAdvance,
                percent: (x) => x.BilledInAdvance,
                eventOutput: (x) => x.BilledInAdvance
            );
        }
    }

    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newSubscriptionUnit: (x) => x.BillingCycleConfiguration,
                newSubscriptionTiered: (x) => x.BillingCycleConfiguration,
                newSubscriptionBulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newSubscriptionPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionMatrix: (x) => x.BillingCycleConfiguration,
                newSubscriptionThresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                newSubscriptionTieredPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionTieredWithMinimum: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedTiered: (x) => x.BillingCycleConfiguration,
                newSubscriptionTieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                newSubscriptionPackageWithAllocation: (x) => x.BillingCycleConfiguration,
                newSubscriptionUnitWithPercent: (x) => x.BillingCycleConfiguration,
                newSubscriptionMatrixWithAllocation: (x) => x.BillingCycleConfiguration,
                tieredWithProration: (x) => x.BillingCycleConfiguration,
                newSubscriptionUnitWithProration: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newSubscriptionBulkWithProration: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newSubscriptionMatrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                newSubscriptionGroupedTieredPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionMaxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                newSubscriptionCumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newSubscriptionMinimumComposite: (x) => x.BillingCycleConfiguration,
                percent: (x) => x.BillingCycleConfiguration,
                eventOutput: (x) => x.BillingCycleConfiguration
            );
        }
    }

    public double? ConversionRate
    {
        get
        {
            return Match<double?>(
                newSubscriptionUnit: (x) => x.ConversionRate,
                newSubscriptionTiered: (x) => x.ConversionRate,
                newSubscriptionBulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newSubscriptionPackage: (x) => x.ConversionRate,
                newSubscriptionMatrix: (x) => x.ConversionRate,
                newSubscriptionThresholdTotalAmount: (x) => x.ConversionRate,
                newSubscriptionTieredPackage: (x) => x.ConversionRate,
                newSubscriptionTieredWithMinimum: (x) => x.ConversionRate,
                newSubscriptionGroupedTiered: (x) => x.ConversionRate,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ConversionRate,
                newSubscriptionPackageWithAllocation: (x) => x.ConversionRate,
                newSubscriptionUnitWithPercent: (x) => x.ConversionRate,
                newSubscriptionMatrixWithAllocation: (x) => x.ConversionRate,
                tieredWithProration: (x) => x.ConversionRate,
                newSubscriptionUnitWithProration: (x) => x.ConversionRate,
                newSubscriptionGroupedAllocation: (x) => x.ConversionRate,
                newSubscriptionBulkWithProration: (x) => x.ConversionRate,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ConversionRate,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newSubscriptionMatrixWithDisplayName: (x) => x.ConversionRate,
                newSubscriptionGroupedTieredPackage: (x) => x.ConversionRate,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ConversionRate,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ConversionRate,
                cumulativeGroupedAllocation: (x) => x.ConversionRate,
                newSubscriptionMinimumComposite: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.Currency,
                newSubscriptionTiered: (x) => x.Currency,
                newSubscriptionBulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newSubscriptionPackage: (x) => x.Currency,
                newSubscriptionMatrix: (x) => x.Currency,
                newSubscriptionThresholdTotalAmount: (x) => x.Currency,
                newSubscriptionTieredPackage: (x) => x.Currency,
                newSubscriptionTieredWithMinimum: (x) => x.Currency,
                newSubscriptionGroupedTiered: (x) => x.Currency,
                newSubscriptionTieredPackageWithMinimum: (x) => x.Currency,
                newSubscriptionPackageWithAllocation: (x) => x.Currency,
                newSubscriptionUnitWithPercent: (x) => x.Currency,
                newSubscriptionMatrixWithAllocation: (x) => x.Currency,
                tieredWithProration: (x) => x.Currency,
                newSubscriptionUnitWithProration: (x) => x.Currency,
                newSubscriptionGroupedAllocation: (x) => x.Currency,
                newSubscriptionBulkWithProration: (x) => x.Currency,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.Currency,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newSubscriptionMatrixWithDisplayName: (x) => x.Currency,
                newSubscriptionGroupedTieredPackage: (x) => x.Currency,
                newSubscriptionMaxGroupTieredPackage: (x) => x.Currency,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.Currency,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.Currency,
                newSubscriptionCumulativeGroupedBulk: (x) => x.Currency,
                cumulativeGroupedAllocation: (x) => x.Currency,
                newSubscriptionMinimumComposite: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<NewDimensionalPriceConfiguration?>(
                newSubscriptionUnit: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTiered: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionBulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMatrix: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionThresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedTiered: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionTieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionPackageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionUnitWithPercent: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMatrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                tieredWithProration: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionUnitWithProration: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionBulkWithProration: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMatrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionGroupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMaxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionScalableMatrixWithUnitPricing: (x) =>
                    x.DimensionalPriceConfiguration,
                newSubscriptionScalableMatrixWithTieredPricing: (x) =>
                    x.DimensionalPriceConfiguration,
                newSubscriptionCumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newSubscriptionMinimumComposite: (x) => x.DimensionalPriceConfiguration,
                percent: (x) => x.DimensionalPriceConfiguration,
                eventOutput: (x) => x.DimensionalPriceConfiguration
            );
        }
    }

    public string? ExternalPriceID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.ExternalPriceID,
                newSubscriptionTiered: (x) => x.ExternalPriceID,
                newSubscriptionBulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newSubscriptionPackage: (x) => x.ExternalPriceID,
                newSubscriptionMatrix: (x) => x.ExternalPriceID,
                newSubscriptionThresholdTotalAmount: (x) => x.ExternalPriceID,
                newSubscriptionTieredPackage: (x) => x.ExternalPriceID,
                newSubscriptionTieredWithMinimum: (x) => x.ExternalPriceID,
                newSubscriptionGroupedTiered: (x) => x.ExternalPriceID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ExternalPriceID,
                newSubscriptionPackageWithAllocation: (x) => x.ExternalPriceID,
                newSubscriptionUnitWithPercent: (x) => x.ExternalPriceID,
                newSubscriptionMatrixWithAllocation: (x) => x.ExternalPriceID,
                tieredWithProration: (x) => x.ExternalPriceID,
                newSubscriptionUnitWithProration: (x) => x.ExternalPriceID,
                newSubscriptionGroupedAllocation: (x) => x.ExternalPriceID,
                newSubscriptionBulkWithProration: (x) => x.ExternalPriceID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ExternalPriceID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newSubscriptionMatrixWithDisplayName: (x) => x.ExternalPriceID,
                newSubscriptionGroupedTieredPackage: (x) => x.ExternalPriceID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ExternalPriceID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ExternalPriceID,
                cumulativeGroupedAllocation: (x) => x.ExternalPriceID,
                newSubscriptionMinimumComposite: (x) => x.ExternalPriceID,
                percent: (x) => x.ExternalPriceID,
                eventOutput: (x) => x.ExternalPriceID
            );
        }
    }

    public double? FixedPriceQuantity
    {
        get
        {
            return Match<double?>(
                newSubscriptionUnit: (x) => x.FixedPriceQuantity,
                newSubscriptionTiered: (x) => x.FixedPriceQuantity,
                newSubscriptionBulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newSubscriptionPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionMatrix: (x) => x.FixedPriceQuantity,
                newSubscriptionThresholdTotalAmount: (x) => x.FixedPriceQuantity,
                newSubscriptionTieredPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionTieredWithMinimum: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedTiered: (x) => x.FixedPriceQuantity,
                newSubscriptionTieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                newSubscriptionPackageWithAllocation: (x) => x.FixedPriceQuantity,
                newSubscriptionUnitWithPercent: (x) => x.FixedPriceQuantity,
                newSubscriptionMatrixWithAllocation: (x) => x.FixedPriceQuantity,
                tieredWithProration: (x) => x.FixedPriceQuantity,
                newSubscriptionUnitWithProration: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedAllocation: (x) => x.FixedPriceQuantity,
                newSubscriptionBulkWithProration: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newSubscriptionMatrixWithDisplayName: (x) => x.FixedPriceQuantity,
                newSubscriptionGroupedTieredPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionMaxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                newSubscriptionCumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                cumulativeGroupedAllocation: (x) => x.FixedPriceQuantity,
                newSubscriptionMinimumComposite: (x) => x.FixedPriceQuantity,
                percent: (x) => x.FixedPriceQuantity,
                eventOutput: (x) => x.FixedPriceQuantity
            );
        }
    }

    public string? InvoiceGroupingKey
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.InvoiceGroupingKey,
                newSubscriptionTiered: (x) => x.InvoiceGroupingKey,
                newSubscriptionBulk: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newSubscriptionPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionMatrix: (x) => x.InvoiceGroupingKey,
                newSubscriptionThresholdTotalAmount: (x) => x.InvoiceGroupingKey,
                newSubscriptionTieredPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionTieredWithMinimum: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedTiered: (x) => x.InvoiceGroupingKey,
                newSubscriptionTieredPackageWithMinimum: (x) => x.InvoiceGroupingKey,
                newSubscriptionPackageWithAllocation: (x) => x.InvoiceGroupingKey,
                newSubscriptionUnitWithPercent: (x) => x.InvoiceGroupingKey,
                newSubscriptionMatrixWithAllocation: (x) => x.InvoiceGroupingKey,
                tieredWithProration: (x) => x.InvoiceGroupingKey,
                newSubscriptionUnitWithProration: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newSubscriptionBulkWithProration: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newSubscriptionMatrixWithDisplayName: (x) => x.InvoiceGroupingKey,
                newSubscriptionGroupedTieredPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionMaxGroupTieredPackage: (x) => x.InvoiceGroupingKey,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.InvoiceGroupingKey,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.InvoiceGroupingKey,
                newSubscriptionCumulativeGroupedBulk: (x) => x.InvoiceGroupingKey,
                cumulativeGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newSubscriptionMinimumComposite: (x) => x.InvoiceGroupingKey,
                percent: (x) => x.InvoiceGroupingKey,
                eventOutput: (x) => x.InvoiceGroupingKey
            );
        }
    }

    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newSubscriptionUnit: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTiered: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionBulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMatrix: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionThresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedTiered: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionTieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionPackageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionUnitWithPercent: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMatrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                tieredWithProration: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionUnitWithProration: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionBulkWithProration: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMatrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionGroupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMaxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionScalableMatrixWithTieredPricing: (x) =>
                    x.InvoicingCycleConfiguration,
                newSubscriptionCumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public string? ReferenceID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.ReferenceID,
                newSubscriptionTiered: (x) => x.ReferenceID,
                newSubscriptionBulk: (x) => x.ReferenceID,
                bulkWithFilters: (x) => x.ReferenceID,
                newSubscriptionPackage: (x) => x.ReferenceID,
                newSubscriptionMatrix: (x) => x.ReferenceID,
                newSubscriptionThresholdTotalAmount: (x) => x.ReferenceID,
                newSubscriptionTieredPackage: (x) => x.ReferenceID,
                newSubscriptionTieredWithMinimum: (x) => x.ReferenceID,
                newSubscriptionGroupedTiered: (x) => x.ReferenceID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.ReferenceID,
                newSubscriptionPackageWithAllocation: (x) => x.ReferenceID,
                newSubscriptionUnitWithPercent: (x) => x.ReferenceID,
                newSubscriptionMatrixWithAllocation: (x) => x.ReferenceID,
                tieredWithProration: (x) => x.ReferenceID,
                newSubscriptionUnitWithProration: (x) => x.ReferenceID,
                newSubscriptionGroupedAllocation: (x) => x.ReferenceID,
                newSubscriptionBulkWithProration: (x) => x.ReferenceID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.ReferenceID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.ReferenceID,
                groupedWithMinMaxThresholds: (x) => x.ReferenceID,
                newSubscriptionMatrixWithDisplayName: (x) => x.ReferenceID,
                newSubscriptionGroupedTieredPackage: (x) => x.ReferenceID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.ReferenceID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.ReferenceID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.ReferenceID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.ReferenceID,
                cumulativeGroupedAllocation: (x) => x.ReferenceID,
                newSubscriptionMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public ReplacePriceModelPrice(NewSubscriptionUnitPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(NewSubscriptionTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(NewSubscriptionBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        ReplacePriceModelPriceBulkWithFilters value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(NewSubscriptionPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(NewSubscriptionMatrixPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionThresholdTotalAmountPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(NewSubscriptionTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionTieredWithMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(NewSubscriptionGroupedTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionTieredPackageWithMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionPackageWithAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionUnitWithPercentPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionMatrixWithAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        ReplacePriceModelPriceTieredWithProration value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionUnitWithProrationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionGroupedAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionBulkWithProrationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        ReplacePriceModelPriceGroupedWithMinMaxThresholds value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionMatrixWithDisplayNamePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionGroupedTieredPackagePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionMaxGroupTieredPackagePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionCumulativeGroupedBulkPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        ReplacePriceModelPriceCumulativeGroupedAllocation value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(
        NewSubscriptionMinimumCompositePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(ReplacePriceModelPricePercent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(ReplacePriceModelPriceEventOutput value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPrice(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewSubscriptionUnit([NotNullWhen(true)] out NewSubscriptionUnitPrice? value)
    {
        value = this.Value as NewSubscriptionUnitPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTiered(
        [NotNullWhen(true)] out NewSubscriptionTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionBulk([NotNullWhen(true)] out NewSubscriptionBulkPrice? value)
    {
        value = this.Value as NewSubscriptionBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out ReplacePriceModelPriceBulkWithFilters? value
    )
    {
        value = this.Value as ReplacePriceModelPriceBulkWithFilters;
        return value != null;
    }

    public bool TryPickNewSubscriptionPackage(
        [NotNullWhen(true)] out NewSubscriptionPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrix(
        [NotNullWhen(true)] out NewSubscriptionMatrixPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionThresholdTotalAmount(
        [NotNullWhen(true)] out NewSubscriptionThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewSubscriptionThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedTiered(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionPackageWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionUnitWithPercent(
        [NotNullWhen(true)] out NewSubscriptionUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrixWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out ReplacePriceModelPriceTieredWithProration? value
    )
    {
        value = this.Value as ReplacePriceModelPriceTieredWithProration;
        return value != null;
    }

    public bool TryPickNewSubscriptionUnitWithProration(
        [NotNullWhen(true)] out NewSubscriptionUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedAllocation(
        [NotNullWhen(true)] out NewSubscriptionGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionBulkWithProration(
        [NotNullWhen(true)] out NewSubscriptionBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out ReplacePriceModelPriceGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as ReplacePriceModelPriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrixWithDisplayName(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewSubscriptionCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewSubscriptionCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewSubscriptionCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out ReplacePriceModelPriceCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as ReplacePriceModelPriceCumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewSubscriptionMinimumComposite(
        [NotNullWhen(true)] out NewSubscriptionMinimumCompositePrice? value
    )
    {
        value = this.Value as NewSubscriptionMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out ReplacePriceModelPricePercent? value)
    {
        value = this.Value as ReplacePriceModelPricePercent;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out ReplacePriceModelPriceEventOutput? value)
    {
        value = this.Value as ReplacePriceModelPriceEventOutput;
        return value != null;
    }

    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<ReplacePriceModelPriceBulkWithFilters> bulkWithFilters,
        System::Action<NewSubscriptionPackagePrice> newSubscriptionPackage,
        System::Action<NewSubscriptionMatrixPrice> newSubscriptionMatrix,
        System::Action<NewSubscriptionThresholdTotalAmountPrice> newSubscriptionThresholdTotalAmount,
        System::Action<NewSubscriptionTieredPackagePrice> newSubscriptionTieredPackage,
        System::Action<NewSubscriptionTieredWithMinimumPrice> newSubscriptionTieredWithMinimum,
        System::Action<NewSubscriptionGroupedTieredPrice> newSubscriptionGroupedTiered,
        System::Action<NewSubscriptionTieredPackageWithMinimumPrice> newSubscriptionTieredPackageWithMinimum,
        System::Action<NewSubscriptionPackageWithAllocationPrice> newSubscriptionPackageWithAllocation,
        System::Action<NewSubscriptionUnitWithPercentPrice> newSubscriptionUnitWithPercent,
        System::Action<NewSubscriptionMatrixWithAllocationPrice> newSubscriptionMatrixWithAllocation,
        System::Action<ReplacePriceModelPriceTieredWithProration> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<ReplacePriceModelPriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<ReplacePriceModelPriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<ReplacePriceModelPricePercent> percent,
        System::Action<ReplacePriceModelPriceEventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewSubscriptionUnitPrice value:
                newSubscriptionUnit(value);
                break;
            case NewSubscriptionTieredPrice value:
                newSubscriptionTiered(value);
                break;
            case NewSubscriptionBulkPrice value:
                newSubscriptionBulk(value);
                break;
            case ReplacePriceModelPriceBulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewSubscriptionPackagePrice value:
                newSubscriptionPackage(value);
                break;
            case NewSubscriptionMatrixPrice value:
                newSubscriptionMatrix(value);
                break;
            case NewSubscriptionThresholdTotalAmountPrice value:
                newSubscriptionThresholdTotalAmount(value);
                break;
            case NewSubscriptionTieredPackagePrice value:
                newSubscriptionTieredPackage(value);
                break;
            case NewSubscriptionTieredWithMinimumPrice value:
                newSubscriptionTieredWithMinimum(value);
                break;
            case NewSubscriptionGroupedTieredPrice value:
                newSubscriptionGroupedTiered(value);
                break;
            case NewSubscriptionTieredPackageWithMinimumPrice value:
                newSubscriptionTieredPackageWithMinimum(value);
                break;
            case NewSubscriptionPackageWithAllocationPrice value:
                newSubscriptionPackageWithAllocation(value);
                break;
            case NewSubscriptionUnitWithPercentPrice value:
                newSubscriptionUnitWithPercent(value);
                break;
            case NewSubscriptionMatrixWithAllocationPrice value:
                newSubscriptionMatrixWithAllocation(value);
                break;
            case ReplacePriceModelPriceTieredWithProration value:
                tieredWithProration(value);
                break;
            case NewSubscriptionUnitWithProrationPrice value:
                newSubscriptionUnitWithProration(value);
                break;
            case NewSubscriptionGroupedAllocationPrice value:
                newSubscriptionGroupedAllocation(value);
                break;
            case NewSubscriptionBulkWithProrationPrice value:
                newSubscriptionBulkWithProration(value);
                break;
            case NewSubscriptionGroupedWithProratedMinimumPrice value:
                newSubscriptionGroupedWithProratedMinimum(value);
                break;
            case NewSubscriptionGroupedWithMeteredMinimumPrice value:
                newSubscriptionGroupedWithMeteredMinimum(value);
                break;
            case ReplacePriceModelPriceGroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewSubscriptionMatrixWithDisplayNamePrice value:
                newSubscriptionMatrixWithDisplayName(value);
                break;
            case NewSubscriptionGroupedTieredPackagePrice value:
                newSubscriptionGroupedTieredPackage(value);
                break;
            case NewSubscriptionMaxGroupTieredPackagePrice value:
                newSubscriptionMaxGroupTieredPackage(value);
                break;
            case NewSubscriptionScalableMatrixWithUnitPricingPrice value:
                newSubscriptionScalableMatrixWithUnitPricing(value);
                break;
            case NewSubscriptionScalableMatrixWithTieredPricingPrice value:
                newSubscriptionScalableMatrixWithTieredPricing(value);
                break;
            case NewSubscriptionCumulativeGroupedBulkPrice value:
                newSubscriptionCumulativeGroupedBulk(value);
                break;
            case ReplacePriceModelPriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case ReplacePriceModelPricePercent value:
                percent(value);
                break;
            case ReplacePriceModelPriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePriceModelPrice"
                );
        }
    }

    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<ReplacePriceModelPriceBulkWithFilters, T> bulkWithFilters,
        System::Func<NewSubscriptionPackagePrice, T> newSubscriptionPackage,
        System::Func<NewSubscriptionMatrixPrice, T> newSubscriptionMatrix,
        System::Func<
            NewSubscriptionThresholdTotalAmountPrice,
            T
        > newSubscriptionThresholdTotalAmount,
        System::Func<NewSubscriptionTieredPackagePrice, T> newSubscriptionTieredPackage,
        System::Func<NewSubscriptionTieredWithMinimumPrice, T> newSubscriptionTieredWithMinimum,
        System::Func<NewSubscriptionGroupedTieredPrice, T> newSubscriptionGroupedTiered,
        System::Func<
            NewSubscriptionTieredPackageWithMinimumPrice,
            T
        > newSubscriptionTieredPackageWithMinimum,
        System::Func<
            NewSubscriptionPackageWithAllocationPrice,
            T
        > newSubscriptionPackageWithAllocation,
        System::Func<NewSubscriptionUnitWithPercentPrice, T> newSubscriptionUnitWithPercent,
        System::Func<
            NewSubscriptionMatrixWithAllocationPrice,
            T
        > newSubscriptionMatrixWithAllocation,
        System::Func<ReplacePriceModelPriceTieredWithProration, T> tieredWithProration,
        System::Func<NewSubscriptionUnitWithProrationPrice, T> newSubscriptionUnitWithProration,
        System::Func<NewSubscriptionGroupedAllocationPrice, T> newSubscriptionGroupedAllocation,
        System::Func<NewSubscriptionBulkWithProrationPrice, T> newSubscriptionBulkWithProration,
        System::Func<
            NewSubscriptionGroupedWithProratedMinimumPrice,
            T
        > newSubscriptionGroupedWithProratedMinimum,
        System::Func<
            NewSubscriptionGroupedWithMeteredMinimumPrice,
            T
        > newSubscriptionGroupedWithMeteredMinimum,
        System::Func<
            ReplacePriceModelPriceGroupedWithMinMaxThresholds,
            T
        > groupedWithMinMaxThresholds,
        System::Func<
            NewSubscriptionMatrixWithDisplayNamePrice,
            T
        > newSubscriptionMatrixWithDisplayName,
        System::Func<
            NewSubscriptionGroupedTieredPackagePrice,
            T
        > newSubscriptionGroupedTieredPackage,
        System::Func<
            NewSubscriptionMaxGroupTieredPackagePrice,
            T
        > newSubscriptionMaxGroupTieredPackage,
        System::Func<
            NewSubscriptionScalableMatrixWithUnitPricingPrice,
            T
        > newSubscriptionScalableMatrixWithUnitPricing,
        System::Func<
            NewSubscriptionScalableMatrixWithTieredPricingPrice,
            T
        > newSubscriptionScalableMatrixWithTieredPricing,
        System::Func<
            NewSubscriptionCumulativeGroupedBulkPrice,
            T
        > newSubscriptionCumulativeGroupedBulk,
        System::Func<
            ReplacePriceModelPriceCumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<ReplacePriceModelPricePercent, T> percent,
        System::Func<ReplacePriceModelPriceEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            ReplacePriceModelPriceBulkWithFilters value => bulkWithFilters(value),
            NewSubscriptionPackagePrice value => newSubscriptionPackage(value),
            NewSubscriptionMatrixPrice value => newSubscriptionMatrix(value),
            NewSubscriptionThresholdTotalAmountPrice value => newSubscriptionThresholdTotalAmount(
                value
            ),
            NewSubscriptionTieredPackagePrice value => newSubscriptionTieredPackage(value),
            NewSubscriptionTieredWithMinimumPrice value => newSubscriptionTieredWithMinimum(value),
            NewSubscriptionGroupedTieredPrice value => newSubscriptionGroupedTiered(value),
            NewSubscriptionTieredPackageWithMinimumPrice value =>
                newSubscriptionTieredPackageWithMinimum(value),
            NewSubscriptionPackageWithAllocationPrice value => newSubscriptionPackageWithAllocation(
                value
            ),
            NewSubscriptionUnitWithPercentPrice value => newSubscriptionUnitWithPercent(value),
            NewSubscriptionMatrixWithAllocationPrice value => newSubscriptionMatrixWithAllocation(
                value
            ),
            ReplacePriceModelPriceTieredWithProration value => tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            ReplacePriceModelPriceGroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(
                value
            ),
            NewSubscriptionMatrixWithDisplayNamePrice value => newSubscriptionMatrixWithDisplayName(
                value
            ),
            NewSubscriptionGroupedTieredPackagePrice value => newSubscriptionGroupedTieredPackage(
                value
            ),
            NewSubscriptionMaxGroupTieredPackagePrice value => newSubscriptionMaxGroupTieredPackage(
                value
            ),
            NewSubscriptionScalableMatrixWithUnitPricingPrice value =>
                newSubscriptionScalableMatrixWithUnitPricing(value),
            NewSubscriptionScalableMatrixWithTieredPricingPrice value =>
                newSubscriptionScalableMatrixWithTieredPricing(value),
            NewSubscriptionCumulativeGroupedBulkPrice value => newSubscriptionCumulativeGroupedBulk(
                value
            ),
            ReplacePriceModelPriceCumulativeGroupedAllocation value => cumulativeGroupedAllocation(
                value
            ),
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            ReplacePriceModelPricePercent value => percent(value),
            ReplacePriceModelPriceEventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPrice"
            ),
        };
    }

    public static implicit operator ReplacePriceModelPrice(NewSubscriptionUnitPrice value) =>
        new(value);

    public static implicit operator ReplacePriceModelPrice(NewSubscriptionTieredPrice value) =>
        new(value);

    public static implicit operator ReplacePriceModelPrice(NewSubscriptionBulkPrice value) =>
        new(value);

    public static implicit operator ReplacePriceModelPrice(
        ReplacePriceModelPriceBulkWithFilters value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(NewSubscriptionPackagePrice value) =>
        new(value);

    public static implicit operator ReplacePriceModelPrice(NewSubscriptionMatrixPrice value) =>
        new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionTieredPackagePrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionGroupedTieredPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        ReplacePriceModelPriceTieredWithProration value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        ReplacePriceModelPriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        ReplacePriceModelPriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(
        NewSubscriptionMinimumCompositePrice value
    ) => new(value);

    public static implicit operator ReplacePriceModelPrice(ReplacePriceModelPricePercent value) =>
        new(value);

    public static implicit operator ReplacePriceModelPrice(
        ReplacePriceModelPriceEventOutput value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPrice"
            );
        }
    }
}

sealed class ReplacePriceModelPriceConverter : JsonConverter<ReplacePriceModelPrice?>
{
    public override ReplacePriceModelPrice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = json.GetProperty("model_type").GetString();
        }
        catch
        {
            modelType = null;
        }

        switch (modelType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionUnitPrice>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionTieredPrice>(
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
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionBulkPrice>(
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
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePriceModelPriceBulkWithFilters>(
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
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionPackagePrice>(
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
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixPrice>(
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
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionThresholdTotalAmountPrice>(
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
            case "tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackagePrice>(
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
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredWithMinimumPrice>(
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
            case "grouped_tiered":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPrice>(
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
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackageWithMinimumPrice>(
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
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionPackageWithAllocationPrice>(
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
            case "unit_with_percent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithPercentPrice>(
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
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPrice>(
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
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePriceModelPriceTieredWithProration>(
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
            case "unit_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithProrationPrice>(
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
            case "grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedAllocationPrice>(
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
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionBulkWithProrationPrice>(
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
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithProratedMinimumPrice>(
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
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithMeteredMinimumPrice>(
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
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePriceModelPriceGroupedWithMinMaxThresholds>(
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
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithDisplayNamePrice>(
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
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPackagePrice>(
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
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMaxGroupTieredPackagePrice>(
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
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithUnitPricingPrice>(
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
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithTieredPricingPrice>(
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
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionCumulativeGroupedBulkPrice>(
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
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePriceModelPriceCumulativeGroupedAllocation>(
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
            case "minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMinimumCompositePrice>(
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
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePriceModelPricePercent>(
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
            case "event_output":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePriceModelPriceEventOutput>(
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
                return new ReplacePriceModelPrice(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceBulkWithFilters,
        ReplacePriceModelPriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceBulkWithFilters : ModelBase
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentNullException("bulk_with_filters_config")
                );
        }
        init
        {
            this._rawData["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePriceModelPriceBulkWithFiltersCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePriceModelPriceBulkWithFiltersCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePriceModelPriceBulkWithFiltersModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceBulkWithFiltersModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePriceModelPriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceModelPriceBulkWithFiltersConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePriceModelPriceBulkWithFilters()
    {
        this.ModelType = new();
    }

    public ReplacePriceModelPriceBulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceBulkWithFiltersFromRaw : IFromRaw<ReplacePriceModelPriceBulkWithFilters>
{
    public ReplacePriceModelPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPriceBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig,
        ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig : ModelBase
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Filter3> Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Filter3>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._rawData["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Tier6> Tiers
    {
        get
        {
            if (!this._rawData.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Tier6>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._rawData["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig() { }

    public ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRaw<ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig>
{
    public ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Filter3,
        global::Orb.Models.Subscriptions.Filter3FromRaw
    >)
)]
public sealed record class Filter3 : ModelBase
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._rawData.TryGetValue("property_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentNullException("property_key")
                );
        }
        init
        {
            this._rawData["property_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            if (!this._rawData.TryGetValue("property_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentNullException("property_value")
                );
        }
        init
        {
            this._rawData["property_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter3() { }

    public Filter3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Filter3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter3FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Filter3>
{
    public global::Orb.Models.Subscriptions.Filter3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Filter3.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Tier6,
        global::Orb.Models.Subscriptions.Tier6FromRaw
    >)
)]
public sealed record class Tier6 : ModelBase
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            if (!this._rawData.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier6() { }

    public Tier6(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier6(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier6 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier6(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class Tier6FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Tier6>
{
    public global::Orb.Models.Subscriptions.Tier6 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Tier6.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePriceModelPriceBulkWithFiltersCadenceConverter))]
public enum ReplacePriceModelPriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePriceModelPriceBulkWithFiltersCadenceConverter
    : JsonConverter<ReplacePriceModelPriceBulkWithFiltersCadence>
{
    public override ReplacePriceModelPriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePriceModelPriceBulkWithFiltersCadence.Annual,
            "semi_annual" => ReplacePriceModelPriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" => ReplacePriceModelPriceBulkWithFiltersCadence.Monthly,
            "quarterly" => ReplacePriceModelPriceBulkWithFiltersCadence.Quarterly,
            "one_time" => ReplacePriceModelPriceBulkWithFiltersCadence.OneTime,
            "custom" => ReplacePriceModelPriceBulkWithFiltersCadence.Custom,
            _ => (ReplacePriceModelPriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePriceModelPriceBulkWithFiltersCadence.Annual => "annual",
                ReplacePriceModelPriceBulkWithFiltersCadence.SemiAnnual => "semi_annual",
                ReplacePriceModelPriceBulkWithFiltersCadence.Monthly => "monthly",
                ReplacePriceModelPriceBulkWithFiltersCadence.Quarterly => "quarterly",
                ReplacePriceModelPriceBulkWithFiltersCadence.OneTime => "one_time",
                ReplacePriceModelPriceBulkWithFiltersCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePriceModelPriceBulkWithFiltersModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePriceModelPriceBulkWithFiltersModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ReplacePriceModelPriceBulkWithFiltersModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new ReplacePriceModelPriceBulkWithFiltersModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePriceModelPriceBulkWithFiltersModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePriceModelPriceBulkWithFiltersModelType>
    {
        public override ReplacePriceModelPriceBulkWithFiltersModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePriceModelPriceBulkWithFiltersModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ReplacePriceModelPriceBulkWithFiltersConversionRateConfigConverter))]
public record class ReplacePriceModelPriceBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceBulkWithFiltersConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePriceModelPriceBulkWithFiltersConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePriceModelPriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceBulkWithFiltersConversionRateConfig"
            );
        }
    }
}

sealed class ReplacePriceModelPriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<ReplacePriceModelPriceBulkWithFiltersConversionRateConfig>
{
    public override ReplacePriceModelPriceBulkWithFiltersConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new ReplacePriceModelPriceBulkWithFiltersConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceTieredWithProration,
        ReplacePriceModelPriceTieredWithProrationFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceTieredWithProration : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePriceModelPriceTieredWithProrationCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePriceModelPriceTieredWithProrationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePriceModelPriceTieredWithProrationModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceTieredWithProrationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("tiered_with_proration_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_with_proration_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentNullException("tiered_with_proration_config")
                );
        }
        init
        {
            this._rawData["tiered_with_proration_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePriceModelPriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceModelPriceTieredWithProrationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.TieredWithProrationConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePriceModelPriceTieredWithProration()
    {
        this.ModelType = new();
    }

    public ReplacePriceModelPriceTieredWithProration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceTieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceTieredWithProrationFromRaw
    : IFromRaw<ReplacePriceModelPriceTieredWithProration>
{
    public ReplacePriceModelPriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPriceTieredWithProration.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePriceModelPriceTieredWithProrationCadenceConverter))]
public enum ReplacePriceModelPriceTieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePriceModelPriceTieredWithProrationCadenceConverter
    : JsonConverter<ReplacePriceModelPriceTieredWithProrationCadence>
{
    public override ReplacePriceModelPriceTieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePriceModelPriceTieredWithProrationCadence.Annual,
            "semi_annual" => ReplacePriceModelPriceTieredWithProrationCadence.SemiAnnual,
            "monthly" => ReplacePriceModelPriceTieredWithProrationCadence.Monthly,
            "quarterly" => ReplacePriceModelPriceTieredWithProrationCadence.Quarterly,
            "one_time" => ReplacePriceModelPriceTieredWithProrationCadence.OneTime,
            "custom" => ReplacePriceModelPriceTieredWithProrationCadence.Custom,
            _ => (ReplacePriceModelPriceTieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceTieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePriceModelPriceTieredWithProrationCadence.Annual => "annual",
                ReplacePriceModelPriceTieredWithProrationCadence.SemiAnnual => "semi_annual",
                ReplacePriceModelPriceTieredWithProrationCadence.Monthly => "monthly",
                ReplacePriceModelPriceTieredWithProrationCadence.Quarterly => "quarterly",
                ReplacePriceModelPriceTieredWithProrationCadence.OneTime => "one_time",
                ReplacePriceModelPriceTieredWithProrationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePriceModelPriceTieredWithProrationModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePriceModelPriceTieredWithProrationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    ReplacePriceModelPriceTieredWithProrationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new ReplacePriceModelPriceTieredWithProrationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePriceModelPriceTieredWithProrationModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePriceModelPriceTieredWithProrationModelType>
    {
        public override ReplacePriceModelPriceTieredWithProrationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePriceModelPriceTieredWithProrationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig,
        ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfigFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig
    : ModelBase
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Tier7> Tiers
    {
        get
        {
            if (!this._rawData.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Tier7>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._rawData["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig() { }

    public ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig(
        List<global::Orb.Models.Subscriptions.Tier7> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfigFromRaw
    : IFromRaw<ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig>
{
    public ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePriceModelPriceTieredWithProrationTieredWithProrationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Tier7,
        global::Orb.Models.Subscriptions.Tier7FromRaw
    >)
)]
public sealed record class Tier7 : ModelBase
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._rawData.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tier_lower_bound",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentNullException("tier_lower_bound")
                );
        }
        init
        {
            this._rawData["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier7() { }

    public Tier7(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier7(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier7 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Tier7FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Tier7>
{
    public global::Orb.Models.Subscriptions.Tier7 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Tier7.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePriceModelPriceTieredWithProrationConversionRateConfigConverter))]
public record class ReplacePriceModelPriceTieredWithProrationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePriceModelPriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceTieredWithProrationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePriceModelPriceTieredWithProrationConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceTieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePriceModelPriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePriceModelPriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceTieredWithProrationConversionRateConfig"
            );
        }
    }
}

sealed class ReplacePriceModelPriceTieredWithProrationConversionRateConfigConverter
    : JsonConverter<ReplacePriceModelPriceTieredWithProrationConversionRateConfig>
{
    public override ReplacePriceModelPriceTieredWithProrationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new ReplacePriceModelPriceTieredWithProrationConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceTieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceGroupedWithMinMaxThresholds,
        ReplacePriceModelPriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceGroupedWithMinMaxThresholds : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "grouped_with_min_max_thresholds_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_with_min_max_thresholds_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentNullException("grouped_with_min_max_thresholds_config")
                );
        }
        init
        {
            this._rawData["grouped_with_min_max_thresholds_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = new();
    }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRaw<ReplacePriceModelPriceGroupedWithMinMaxThresholds>
{
    public ReplacePriceModelPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPriceGroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadenceConverter))]
public enum ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence>
{
    public override ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ => (ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Annual => "annual",
                ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual =>
                    "semi_annual",
                ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Quarterly => "quarterly",
                ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_with_min_max_thresholds pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : ModelBase
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            if (!this._rawData.TryGetValue("maximum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentNullException("maximum_charge")
                );
        }
        init
        {
            this._rawData["maximum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            if (!this._rawData.TryGetValue("minimum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentNullException("minimum_charge")
                );
        }
        init
        {
            this._rawData["minimum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            if (!this._rawData.TryGetValue("per_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "per_unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentNullException("per_unit_rate")
                );
        }
        init
        {
            this._rawData["per_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig() { }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRaw<ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePriceModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType>
    {
        public override ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePriceModelPriceGroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
    }
}

sealed class ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceCumulativeGroupedAllocation,
        ReplacePriceModelPriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceCumulativeGroupedAllocation : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        ReplacePriceModelPriceCumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePriceModelPriceCumulativeGroupedAllocationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "cumulative_grouped_allocation_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_grouped_allocation_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentNullException("cumulative_grouped_allocation_config")
                );
        }
        init
        {
            this._rawData["cumulative_grouped_allocation_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePriceModelPriceCumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceCumulativeGroupedAllocationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePriceModelPriceCumulativeGroupedAllocation()
    {
        this.ModelType = new();
    }

    public ReplacePriceModelPriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceCumulativeGroupedAllocationFromRaw
    : IFromRaw<ReplacePriceModelPriceCumulativeGroupedAllocation>
{
    public ReplacePriceModelPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPriceCumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePriceModelPriceCumulativeGroupedAllocationCadenceConverter))]
public enum ReplacePriceModelPriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePriceModelPriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<ReplacePriceModelPriceCumulativeGroupedAllocationCadence>
{
    public override ReplacePriceModelPriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => ReplacePriceModelPriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => ReplacePriceModelPriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" => ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Custom,
            _ => (ReplacePriceModelPriceCumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Annual => "annual",
                ReplacePriceModelPriceCumulativeGroupedAllocationCadence.SemiAnnual =>
                    "semi_annual",
                ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Monthly => "monthly",
                ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Quarterly => "quarterly",
                ReplacePriceModelPriceCumulativeGroupedAllocationCadence.OneTime => "one_time",
                ReplacePriceModelPriceCumulativeGroupedAllocationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for cumulative_grouped_allocation pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : ModelBase
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            if (!this._rawData.TryGetValue("cumulative_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentNullException("cumulative_allocation")
                );
        }
        init
        {
            this._rawData["cumulative_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            if (!this._rawData.TryGetValue("group_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "group_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentNullException("group_allocation")
                );
        }
        init
        {
            this._rawData["group_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig() { }

    public ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRaw<ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    public ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePriceModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePriceModelPriceCumulativeGroupedAllocationModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePriceModelPriceCumulativeGroupedAllocationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"");
    }

    ReplacePriceModelPriceCumulativeGroupedAllocationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new ReplacePriceModelPriceCumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePriceModelPriceCumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePriceModelPriceCumulativeGroupedAllocationModelType>
    {
        public override ReplacePriceModelPriceCumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePriceModelPriceCumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
    }
}

sealed class ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<ReplacePriceModelPricePercent, ReplacePriceModelPricePercentFromRaw>)
)]
public sealed record class ReplacePriceModelPricePercent : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePriceModelPricePercentCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePriceModelPricePercentCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePriceModelPricePercentModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPricePercentModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// Configuration for percent pricing
    /// </summary>
    public required ReplacePriceModelPricePercentPercentConfig PercentConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPricePercentPercentConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentNullException("percent_config")
                );
        }
        init
        {
            this._rawData["percent_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePriceModelPricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceModelPricePercentConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.PercentConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePriceModelPricePercent()
    {
        this.ModelType = new();
    }

    public ReplacePriceModelPricePercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPricePercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPricePercentFromRaw : IFromRaw<ReplacePriceModelPricePercent>
{
    public ReplacePriceModelPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePriceModelPricePercentCadenceConverter))]
public enum ReplacePriceModelPricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePriceModelPricePercentCadenceConverter
    : JsonConverter<ReplacePriceModelPricePercentCadence>
{
    public override ReplacePriceModelPricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePriceModelPricePercentCadence.Annual,
            "semi_annual" => ReplacePriceModelPricePercentCadence.SemiAnnual,
            "monthly" => ReplacePriceModelPricePercentCadence.Monthly,
            "quarterly" => ReplacePriceModelPricePercentCadence.Quarterly,
            "one_time" => ReplacePriceModelPricePercentCadence.OneTime,
            "custom" => ReplacePriceModelPricePercentCadence.Custom,
            _ => (ReplacePriceModelPricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePriceModelPricePercentCadence.Annual => "annual",
                ReplacePriceModelPricePercentCadence.SemiAnnual => "semi_annual",
                ReplacePriceModelPricePercentCadence.Monthly => "monthly",
                ReplacePriceModelPricePercentCadence.Quarterly => "quarterly",
                ReplacePriceModelPricePercentCadence.OneTime => "one_time",
                ReplacePriceModelPricePercentCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePriceModelPricePercentModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePriceModelPricePercentModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ReplacePriceModelPricePercentModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new ReplacePriceModelPricePercentModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePriceModelPricePercentModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePriceModelPricePercentModelType>
    {
        public override ReplacePriceModelPricePercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePriceModelPricePercentModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPricePercentPercentConfig,
        ReplacePriceModelPricePercentPercentConfigFromRaw
    >)
)]
public sealed record class ReplacePriceModelPricePercentPercentConfig : ModelBase
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._rawData.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public ReplacePriceModelPricePercentPercentConfig() { }

    public ReplacePriceModelPricePercentPercentConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPricePercentPercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePriceModelPricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class ReplacePriceModelPricePercentPercentConfigFromRaw
    : IFromRaw<ReplacePriceModelPricePercentPercentConfig>
{
    public ReplacePriceModelPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPricePercentPercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePriceModelPricePercentConversionRateConfigConverter))]
public record class ReplacePriceModelPricePercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePriceModelPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPricePercentConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePriceModelPricePercentConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePriceModelPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePriceModelPricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPricePercentConversionRateConfig"
            );
        }
    }
}

sealed class ReplacePriceModelPricePercentConversionRateConfigConverter
    : JsonConverter<ReplacePriceModelPricePercentConversionRateConfig>
{
    public override ReplacePriceModelPricePercentConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new ReplacePriceModelPricePercentConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceEventOutput,
        ReplacePriceModelPriceEventOutputFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceEventOutput : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePriceModelPriceEventOutputCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePriceModelPriceEventOutputCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required ReplacePriceModelPriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceEventOutputEventOutputConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentNullException("event_output_config")
                );
        }
        init
        {
            this._rawData["event_output_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePriceModelPriceEventOutputModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePriceModelPriceEventOutputModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePriceModelPriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceModelPriceEventOutputConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePriceModelPriceEventOutput()
    {
        this.ModelType = new();
    }

    public ReplacePriceModelPriceEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePriceModelPriceEventOutputFromRaw : IFromRaw<ReplacePriceModelPriceEventOutput>
{
    public ReplacePriceModelPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePriceModelPriceEventOutputCadenceConverter))]
public enum ReplacePriceModelPriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePriceModelPriceEventOutputCadenceConverter
    : JsonConverter<ReplacePriceModelPriceEventOutputCadence>
{
    public override ReplacePriceModelPriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePriceModelPriceEventOutputCadence.Annual,
            "semi_annual" => ReplacePriceModelPriceEventOutputCadence.SemiAnnual,
            "monthly" => ReplacePriceModelPriceEventOutputCadence.Monthly,
            "quarterly" => ReplacePriceModelPriceEventOutputCadence.Quarterly,
            "one_time" => ReplacePriceModelPriceEventOutputCadence.OneTime,
            "custom" => ReplacePriceModelPriceEventOutputCadence.Custom,
            _ => (ReplacePriceModelPriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePriceModelPriceEventOutputCadence.Annual => "annual",
                ReplacePriceModelPriceEventOutputCadence.SemiAnnual => "semi_annual",
                ReplacePriceModelPriceEventOutputCadence.Monthly => "monthly",
                ReplacePriceModelPriceEventOutputCadence.Quarterly => "quarterly",
                ReplacePriceModelPriceEventOutputCadence.OneTime => "one_time",
                ReplacePriceModelPriceEventOutputCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for event_output pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ReplacePriceModelPriceEventOutputEventOutputConfig,
        ReplacePriceModelPriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class ReplacePriceModelPriceEventOutputEventOutputConfig : ModelBase
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_rating_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_rating_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentNullException("unit_rating_key")
                );
        }
        init
        {
            this._rawData["unit_rating_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get
        {
            if (!this._rawData.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["default_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public ReplacePriceModelPriceEventOutputEventOutputConfig() { }

    public ReplacePriceModelPriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModelPriceEventOutputEventOutputConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ReplacePriceModelPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePriceModelPriceEventOutputEventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class ReplacePriceModelPriceEventOutputEventOutputConfigFromRaw
    : IFromRaw<ReplacePriceModelPriceEventOutputEventOutputConfig>
{
    public ReplacePriceModelPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePriceModelPriceEventOutputEventOutputConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePriceModelPriceEventOutputModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePriceModelPriceEventOutputModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ReplacePriceModelPriceEventOutputModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(this.Json, new ReplacePriceModelPriceEventOutputModelType().Json)
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePriceModelPriceEventOutputModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePriceModelPriceEventOutputModelType>
    {
        public override ReplacePriceModelPriceEventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePriceModelPriceEventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ReplacePriceModelPriceEventOutputConversionRateConfigConverter))]
public record class ReplacePriceModelPriceEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePriceModelPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePriceModelPriceEventOutputConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePriceModelPriceEventOutputConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePriceModelPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePriceModelPriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePriceModelPriceEventOutputConversionRateConfig"
            );
        }
    }
}

sealed class ReplacePriceModelPriceEventOutputConversionRateConfigConverter
    : JsonConverter<ReplacePriceModelPriceEventOutputConversionRateConfig>
{
    public override ReplacePriceModelPriceEventOutputConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new ReplacePriceModelPriceEventOutputConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePriceModelPriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
