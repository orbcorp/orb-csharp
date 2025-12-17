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

    public required ApiEnum<string, SubscriptionSchedulePlanChangeParamsChangeOption> ChangeOption
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, SubscriptionSchedulePlanChangeParamsChangeOption>
            >(this.RawBodyData, "change_option");
        }
        init { JsonModel.Set(this._rawBodyData, "change_option", value); }
    }

    /// <summary>
    /// Additional adjustments to be added to the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<SubscriptionSchedulePlanChangeParamsAddAdjustment>? AddAdjustments
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<SubscriptionSchedulePlanChangeParamsAddAdjustment>
            >(this.RawBodyData, "add_adjustments");
        }
        init { JsonModel.Set(this._rawBodyData, "add_adjustments", value); }
    }

    /// <summary>
    /// Additional prices to be added to the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<SubscriptionSchedulePlanChangeParamsAddPrice>? AddPrices
    {
        get
        {
            return JsonModel.GetNullableClass<List<SubscriptionSchedulePlanChangeParamsAddPrice>>(
                this.RawBodyData,
                "add_prices"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "add_prices", value); }
    }

    /// <summary>
    /// [DEPRECATED] Use billing_cycle_alignment instead. Reset billing periods to
    /// be aligned with the plan change's effective date.
    /// </summary>
    public bool? AlignBillingWithPlanChangeDate
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(
                this.RawBodyData,
                "align_billing_with_plan_change_date"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "align_billing_with_plan_change_date", value); }
    }

    /// <summary>
    /// Determines whether issued invoices for this subscription will automatically
    /// be charged with the saved payment method on the due date. If not specified,
    /// this defaults to the behavior configured for this customer.
    /// </summary>
    public bool? AutoCollection
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "auto_collection"); }
        init { JsonModel.Set(this._rawBodyData, "auto_collection", value); }
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
            return JsonModel.GetNullableClass<ApiEnum<string, BillingCycleAlignment>>(
                this.RawBodyData,
                "billing_cycle_alignment"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "billing_cycle_alignment", value); }
    }

    public BillingCycleAnchorConfiguration? BillingCycleAnchorConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<BillingCycleAnchorConfiguration>(
                this.RawBodyData,
                "billing_cycle_anchor_configuration"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "billing_cycle_anchor_configuration", value); }
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
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawBodyData,
                "change_date"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "change_date", value); }
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
            return JsonModel.GetNullableClass<string>(this.RawBodyData, "coupon_redemption_code");
        }
        init { JsonModel.Set(this._rawBodyData, "coupon_redemption_code", value); }
    }

    [System::Obsolete("deprecated")]
    public double? CreditsOverageRate
    {
        get
        {
            return JsonModel.GetNullableStruct<double>(this.RawBodyData, "credits_overage_rate");
        }
        init { JsonModel.Set(this._rawBodyData, "credits_overage_rate", value); }
    }

    /// <summary>
    /// Determines the default memo on this subscription's invoices. Note that if
    /// this is not provided, it is determined by the plan configuration.
    /// </summary>
    public string? DefaultInvoiceMemo
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "default_invoice_memo"); }
        init { JsonModel.Set(this._rawBodyData, "default_invoice_memo", value); }
    }

    /// <summary>
    /// The external_plan_id of the plan that the given subscription should be switched
    /// to. Note that either this property or `plan_id` must be specified.
    /// </summary>
    public string? ExternalPlanID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "external_plan_id"); }
        init { JsonModel.Set(this._rawBodyData, "external_plan_id", value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "filter"); }
        init { JsonModel.Set(this._rawBodyData, "filter", value); }
    }

    /// <summary>
    /// The phase of the plan to start with
    /// </summary>
    public long? InitialPhaseOrder
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "initial_phase_order"); }
        init { JsonModel.Set(this._rawBodyData, "initial_phase_order", value); }
    }

    /// <summary>
    /// When this subscription's accrued usage reaches this threshold, an invoice
    /// will be issued for the subscription. If not specified, invoices will only
    /// be issued at the end of the billing period.
    /// </summary>
    public string? InvoicingThreshold
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "invoicing_threshold"); }
        init { JsonModel.Set(this._rawBodyData, "invoicing_threshold", value); }
    }

    /// <summary>
    /// The net terms determines the difference between the invoice date and the
    /// issue date for the invoice. If you intend the invoice to be due on issue,
    /// set this to 0. If not provided, this defaults to the value specified in the plan.
    /// </summary>
    public long? NetTerms
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "net_terms"); }
        init { JsonModel.Set(this._rawBodyData, "net_terms", value); }
    }

    [System::Obsolete("deprecated")]
    public double? PerCreditOverageAmount
    {
        get
        {
            return JsonModel.GetNullableStruct<double>(
                this.RawBodyData,
                "per_credit_overage_amount"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "per_credit_overage_amount", value); }
    }

    /// <summary>
    /// The plan that the given subscription should be switched to. Note that either
    /// this property or `external_plan_id` must be specified.
    /// </summary>
    public string? PlanID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "plan_id"); }
        init { JsonModel.Set(this._rawBodyData, "plan_id", value); }
    }

    /// <summary>
    /// Specifies which version of the plan to change to. If null, the default version
    /// will be used.
    /// </summary>
    public long? PlanVersionNumber
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "plan_version_number"); }
        init { JsonModel.Set(this._rawBodyData, "plan_version_number", value); }
    }

    /// <summary>
    /// Optionally provide a list of overrides for prices on the plan
    /// </summary>
    [System::Obsolete("deprecated")]
    public IReadOnlyList<JsonElement>? PriceOverrides
    {
        get
        {
            return JsonModel.GetNullableClass<List<JsonElement>>(
                this.RawBodyData,
                "price_overrides"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "price_overrides", value); }
    }

    /// <summary>
    /// Plan adjustments to be removed from the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<SubscriptionSchedulePlanChangeParamsRemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<SubscriptionSchedulePlanChangeParamsRemoveAdjustment>
            >(this.RawBodyData, "remove_adjustments");
        }
        init { JsonModel.Set(this._rawBodyData, "remove_adjustments", value); }
    }

    /// <summary>
    /// Plan prices to be removed from the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<SubscriptionSchedulePlanChangeParamsRemovePrice>? RemovePrices
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<SubscriptionSchedulePlanChangeParamsRemovePrice>
            >(this.RawBodyData, "remove_prices");
        }
        init { JsonModel.Set(this._rawBodyData, "remove_prices", value); }
    }

    /// <summary>
    /// Plan adjustments to be replaced with additional adjustments on the subscription.
    /// (Only available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<SubscriptionSchedulePlanChangeParamsReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<SubscriptionSchedulePlanChangeParamsReplaceAdjustment>
            >(this.RawBodyData, "replace_adjustments");
        }
        init { JsonModel.Set(this._rawBodyData, "replace_adjustments", value); }
    }

    /// <summary>
    /// Plan prices to be replaced with additional prices on the subscription. (Only
    /// available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<SubscriptionSchedulePlanChangeParamsReplacePrice>? ReplacePrices
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<SubscriptionSchedulePlanChangeParamsReplacePrice>
            >(this.RawBodyData, "replace_prices");
        }
        init { JsonModel.Set(this._rawBodyData, "replace_prices", value); }
    }

    /// <summary>
    /// The duration of the trial period in days. If not provided, this defaults to
    /// the value specified in the plan. If `0` is provided, the trial on the plan
    /// will be skipped.
    /// </summary>
    public long? TrialDurationDays
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "trial_duration_days"); }
        init { JsonModel.Set(this._rawBodyData, "trial_duration_days", value); }
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
            return JsonModel.GetNullableClass<List<string>>(this.RawBodyData, "usage_customer_ids");
        }
        init { JsonModel.Set(this._rawBodyData, "usage_customer_ids", value); }
    }

    public SubscriptionSchedulePlanChangeParams() { }

    public SubscriptionSchedulePlanChangeParams(
        SubscriptionSchedulePlanChangeParams subscriptionSchedulePlanChangeParams
    )
        : base(subscriptionSchedulePlanChangeParams)
    {
        this._rawBodyData = [.. subscriptionSchedulePlanChangeParams._rawBodyData];
    }

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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
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

[JsonConverter(typeof(SubscriptionSchedulePlanChangeParamsChangeOptionConverter))]
public enum SubscriptionSchedulePlanChangeParamsChangeOption
{
    RequestedDate,
    EndOfSubscriptionTerm,
    Immediate,
}

sealed class SubscriptionSchedulePlanChangeParamsChangeOptionConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsChangeOption>
{
    public override SubscriptionSchedulePlanChangeParamsChangeOption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requested_date" => SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate,
            "end_of_subscription_term" =>
                SubscriptionSchedulePlanChangeParamsChangeOption.EndOfSubscriptionTerm,
            "immediate" => SubscriptionSchedulePlanChangeParamsChangeOption.Immediate,
            _ => (SubscriptionSchedulePlanChangeParamsChangeOption)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsChangeOption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate => "requested_date",
                SubscriptionSchedulePlanChangeParamsChangeOption.EndOfSubscriptionTerm =>
                    "end_of_subscription_term",
                SubscriptionSchedulePlanChangeParamsChangeOption.Immediate => "immediate",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddAdjustment,
        SubscriptionSchedulePlanChangeParamsAddAdjustmentFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddAdjustment : JsonModel
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment Adjustment
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment>(
                this.RawData,
                "adjustment"
            );
        }
        init { JsonModel.Set(this._rawData, "adjustment", value); }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription.
    /// </summary>
    public System::DateTimeOffset? EndDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "end_date");
        }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { JsonModel.Set(this._rawData, "plan_phase_order", value); }
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
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.EndDate;
        _ = this.PlanPhaseOrder;
        _ = this.StartDate;
    }

    public SubscriptionSchedulePlanChangeParamsAddAdjustment() { }

    public SubscriptionSchedulePlanChangeParamsAddAdjustment(
        SubscriptionSchedulePlanChangeParamsAddAdjustment subscriptionSchedulePlanChangeParamsAddAdjustment
    )
        : base(subscriptionSchedulePlanChangeParamsAddAdjustment) { }

    public SubscriptionSchedulePlanChangeParamsAddAdjustment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddAdjustmentFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsAddAdjustment(
        SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment adjustment
    )
        : this()
    {
        this.Adjustment = adjustment;
    }
}

class SubscriptionSchedulePlanChangeParamsAddAdjustmentFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddAdjustment>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsAddAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustmentConverter))]
public record class SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewPercentageDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewUsageDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewAmountDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewMinimum value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewMaximum value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPercentageDiscount(out var value)) {
    ///     // `value` is of type `NewPercentageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewUsageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewUsageDiscount(out var value)) {
    ///     // `value` is of type `NewUsageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewAmountDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewAmountDiscount(out var value)) {
    ///     // `value` is of type `NewAmountDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMinimum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMinimum(out var value)) {
    ///     // `value` is of type `NewMinimum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMaximum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMaximum(out var value)) {
    ///     // `value` is of type `NewMaximum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment"
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewUsageDiscount value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewAmountDiscount value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewMinimum value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(
        NewMaximum value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment"
            );
        }
        this.Switch(
            (newPercentageDiscount) => newPercentageDiscount.Validate(),
            (newUsageDiscount) => newUsageDiscount.Validate(),
            (newAmountDiscount) => newAmountDiscount.Validate(),
            (newMinimum) => newMinimum.Validate(),
            (newMaximum) => newMaximum.Validate()
        );
    }

    public virtual bool Equals(SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustmentConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment>
{
    public override SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = element.GetProperty("adjustment_type").GetString();
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
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(
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
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(
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
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(element, options);
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
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(element, options);
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
                return new SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPrice,
        SubscriptionSchedulePlanChangeParamsAddPriceFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPrice : JsonModel
{
    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            return JsonModel.GetNullableClass<NewAllocationPrice>(this.RawData, "allocation_price");
        }
        init { JsonModel.Set(this._rawData, "allocation_price", value); }
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
            return JsonModel.GetNullableClass<List<DiscountOverride>>(this.RawData, "discounts");
        }
        init { JsonModel.Set(this._rawData, "discounts", value); }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that the price will stop
    /// billing on the subscription. If null, billing will end when the phase or subscription ends.
    /// </summary>
    public System::DateTimeOffset? EndDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "end_date");
        }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for this price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MaximumAmount
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "maximum_amount"); }
        init { JsonModel.Set(this._rawData, "maximum_amount", value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for this price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MinimumAmount
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "minimum_amount"); }
        init { JsonModel.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// The phase to add this price to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { JsonModel.Set(this._rawData, "plan_phase_order", value); }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsAddPricePrice? Price
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                this.RawData,
                "price"
            );
        }
        init { JsonModel.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "price_id"); }
        init { JsonModel.Set(this._rawData, "price_id", value); }
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
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <inheritdoc/>
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

    public SubscriptionSchedulePlanChangeParamsAddPrice() { }

    public SubscriptionSchedulePlanChangeParamsAddPrice(
        SubscriptionSchedulePlanChangeParamsAddPrice subscriptionSchedulePlanChangeParamsAddPrice
    )
        : base(subscriptionSchedulePlanChangeParamsAddPrice) { }

    public SubscriptionSchedulePlanChangeParamsAddPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPriceFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPrice>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsAddPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceConverter))]
public record class SubscriptionSchedulePlanChangeParamsAddPricePrice
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionUnitPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionBulkPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMatrixPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionThresholdTotalAmountPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedTieredPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredPackageWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionPackageWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionUnitWithPercentPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMatrixWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionUnitWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionBulkWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMatrixWithDisplayNamePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMaxGroupTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionCumulativeGroupedBulkPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMinimumCompositePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePricePercent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePrice(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionUnit(out var value)) {
    ///     // `value` is of type `NewSubscriptionUnitPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionUnit([NotNullWhen(true)] out NewSubscriptionUnitPrice? value)
    {
        value = this.Value as NewSubscriptionUnitPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTiered(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTiered(
        [NotNullWhen(true)] out NewSubscriptionTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionBulk(out var value)) {
    ///     // `value` is of type `NewSubscriptionBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionBulk([NotNullWhen(true)] out NewSubscriptionBulkPrice? value)
    {
        value = this.Value as NewSubscriptionBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters? value
    )
    {
        value = this.Value as SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionPackage(
        [NotNullWhen(true)] out NewSubscriptionPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMatrix(out var value)) {
    ///     // `value` is of type `NewSubscriptionMatrixPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMatrix(
        [NotNullWhen(true)] out NewSubscriptionMatrixPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionThresholdTotalAmountPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionThresholdTotalAmount(out var value)) {
    ///     // `value` is of type `NewSubscriptionThresholdTotalAmountPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionThresholdTotalAmount(
        [NotNullWhen(true)] out NewSubscriptionThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewSubscriptionThresholdTotalAmountPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTieredPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTieredWithMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTieredWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedTiered(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedTiered(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredPackageWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTieredPackageWithMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredPackageWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackageWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionPackageWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionPackageWithAllocation(out var value)) {
    ///     // `value` is of type `NewSubscriptionPackageWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionPackageWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionPackageWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitWithPercentPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionUnitWithPercent(out var value)) {
    ///     // `value` is of type `NewSubscriptionUnitWithPercentPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionUnitWithPercent(
        [NotNullWhen(true)] out NewSubscriptionUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithPercentPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMatrixWithAllocation(out var value)) {
    ///     // `value` is of type `NewSubscriptionMatrixWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMatrixWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredWithProration(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredWithProration(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration? value
    )
    {
        value = this.Value as SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionUnitWithProration(out var value)) {
    ///     // `value` is of type `NewSubscriptionUnitWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionUnitWithProration(
        [NotNullWhen(true)] out NewSubscriptionUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedAllocation(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedAllocation(
        [NotNullWhen(true)] out NewSubscriptionGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionBulkWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionBulkWithProration(out var value)) {
    ///     // `value` is of type `NewSubscriptionBulkWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionBulkWithProration(
        [NotNullWhen(true)] out NewSubscriptionBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionBulkWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedWithProratedMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedWithProratedMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedWithProratedMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithProratedMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedWithMeteredMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedWithMeteredMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedWithMeteredMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds? value
    )
    {
        value =
            this.Value
            as SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMatrixWithDisplayName(out var value)) {
    ///     // `value` is of type `NewSubscriptionMatrixWithDisplayNamePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMatrixWithDisplayName(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithDisplayNamePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedTieredPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMaxGroupTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMaxGroupTieredPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionMaxGroupTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionMaxGroupTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionScalableMatrixWithUnitPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionScalableMatrixWithUnitPricing(out var value)) {
    ///     // `value` is of type `NewSubscriptionScalableMatrixWithUnitPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionScalableMatrixWithTieredPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionScalableMatrixWithTieredPricing(out var value)) {
    ///     // `value` is of type `NewSubscriptionScalableMatrixWithTieredPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionCumulativeGroupedBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionCumulativeGroupedBulk(out var value)) {
    ///     // `value` is of type `NewSubscriptionCumulativeGroupedBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewSubscriptionCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewSubscriptionCumulativeGroupedBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation? value
    )
    {
        value =
            this.Value
            as SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMinimumComposite(out var value)) {
    ///     // `value` is of type `NewSubscriptionMinimumCompositePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMinimumComposite(
        [NotNullWhen(true)] out NewSubscriptionMinimumCompositePrice? value
    )
    {
        value = this.Value as NewSubscriptionMinimumCompositePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsAddPricePricePercent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsAddPricePricePercent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent(
        [NotNullWhen(true)] out SubscriptionSchedulePlanChangeParamsAddPricePricePercent? value
    )
    {
        value = this.Value as SubscriptionSchedulePlanChangeParamsAddPricePricePercent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput(
        [NotNullWhen(true)] out SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput? value
    )
    {
        value = this.Value as SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput;
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
    ///     (NewSubscriptionUnitPrice value) => {...},
    ///     (NewSubscriptionTieredPrice value) => {...},
    ///     (NewSubscriptionBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters value) => {...},
    ///     (NewSubscriptionPackagePrice value) => {...},
    ///     (NewSubscriptionMatrixPrice value) => {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) => {...},
    ///     (NewSubscriptionTieredPackagePrice value) => {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPrice value) => {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) => {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) => {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) => {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration value) => {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) => {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) => {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation value) => {...},
    ///     (NewSubscriptionMinimumCompositePrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePricePercent value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters> bulkWithFilters,
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
        System::Action<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<SubscriptionSchedulePlanChangeParamsAddPricePricePercent> percent,
        System::Action<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput> eventOutput
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
            case SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters value:
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
            case SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration value:
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
            case SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds value:
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
            case SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case SubscriptionSchedulePlanChangeParamsAddPricePricePercent value:
                percent(value);
                break;
            case SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePrice"
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
    ///     (NewSubscriptionUnitPrice value) => {...},
    ///     (NewSubscriptionTieredPrice value) => {...},
    ///     (NewSubscriptionBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters value) => {...},
    ///     (NewSubscriptionPackagePrice value) => {...},
    ///     (NewSubscriptionMatrixPrice value) => {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) => {...},
    ///     (NewSubscriptionTieredPackagePrice value) => {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPrice value) => {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) => {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) => {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) => {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration value) => {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) => {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) => {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation value) => {...},
    ///     (NewSubscriptionMinimumCompositePrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePricePercent value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<
            SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters,
            T
        > bulkWithFilters,
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
        System::Func<
            SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration,
            T
        > tieredWithProration,
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
            SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds,
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
            SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<SubscriptionSchedulePlanChangeParamsAddPricePricePercent, T> percent,
        System::Func<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters value =>
                bulkWithFilters(value),
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
            SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration value =>
                tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds value =>
                groupedWithMinMaxThresholds(value),
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
            SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            SubscriptionSchedulePlanChangeParamsAddPricePricePercent value => percent(value),
            SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput value => eventOutput(
                value
            ),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePrice"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionUnitPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionBulkPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMatrixPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedTieredPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        NewSubscriptionMinimumCompositePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePricePercent value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePrice(
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePrice"
            );
        }
        this.Switch(
            (newSubscriptionUnit) => newSubscriptionUnit.Validate(),
            (newSubscriptionTiered) => newSubscriptionTiered.Validate(),
            (newSubscriptionBulk) => newSubscriptionBulk.Validate(),
            (bulkWithFilters) => bulkWithFilters.Validate(),
            (newSubscriptionPackage) => newSubscriptionPackage.Validate(),
            (newSubscriptionMatrix) => newSubscriptionMatrix.Validate(),
            (newSubscriptionThresholdTotalAmount) => newSubscriptionThresholdTotalAmount.Validate(),
            (newSubscriptionTieredPackage) => newSubscriptionTieredPackage.Validate(),
            (newSubscriptionTieredWithMinimum) => newSubscriptionTieredWithMinimum.Validate(),
            (newSubscriptionGroupedTiered) => newSubscriptionGroupedTiered.Validate(),
            (newSubscriptionTieredPackageWithMinimum) =>
                newSubscriptionTieredPackageWithMinimum.Validate(),
            (newSubscriptionPackageWithAllocation) =>
                newSubscriptionPackageWithAllocation.Validate(),
            (newSubscriptionUnitWithPercent) => newSubscriptionUnitWithPercent.Validate(),
            (newSubscriptionMatrixWithAllocation) => newSubscriptionMatrixWithAllocation.Validate(),
            (tieredWithProration) => tieredWithProration.Validate(),
            (newSubscriptionUnitWithProration) => newSubscriptionUnitWithProration.Validate(),
            (newSubscriptionGroupedAllocation) => newSubscriptionGroupedAllocation.Validate(),
            (newSubscriptionBulkWithProration) => newSubscriptionBulkWithProration.Validate(),
            (newSubscriptionGroupedWithProratedMinimum) =>
                newSubscriptionGroupedWithProratedMinimum.Validate(),
            (newSubscriptionGroupedWithMeteredMinimum) =>
                newSubscriptionGroupedWithMeteredMinimum.Validate(),
            (groupedWithMinMaxThresholds) => groupedWithMinMaxThresholds.Validate(),
            (newSubscriptionMatrixWithDisplayName) =>
                newSubscriptionMatrixWithDisplayName.Validate(),
            (newSubscriptionGroupedTieredPackage) => newSubscriptionGroupedTieredPackage.Validate(),
            (newSubscriptionMaxGroupTieredPackage) =>
                newSubscriptionMaxGroupTieredPackage.Validate(),
            (newSubscriptionScalableMatrixWithUnitPricing) =>
                newSubscriptionScalableMatrixWithUnitPricing.Validate(),
            (newSubscriptionScalableMatrixWithTieredPricing) =>
                newSubscriptionScalableMatrixWithTieredPricing.Validate(),
            (newSubscriptionCumulativeGroupedBulk) =>
                newSubscriptionCumulativeGroupedBulk.Validate(),
            (cumulativeGroupedAllocation) => cumulativeGroupedAllocation.Validate(),
            (newSubscriptionMinimumComposite) => newSubscriptionMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(SubscriptionSchedulePlanChangeParamsAddPricePrice? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePrice?>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePrice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = element.GetProperty("model_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionTieredPrice>(
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
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionBulkPrice>(
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
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters>(
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
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionPackagePrice>(
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
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixPrice>(
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
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionThresholdTotalAmountPrice>(
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
            case "tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackagePrice>(
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
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredWithMinimumPrice>(
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
            case "grouped_tiered":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPrice>(
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
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackageWithMinimumPrice>(
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
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionPackageWithAllocationPrice>(
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
            case "unit_with_percent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithPercentPrice>(
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
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPrice>(
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
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration>(
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
            case "unit_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithProrationPrice>(
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
            case "grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedAllocationPrice>(
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
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionBulkWithProrationPrice>(
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
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithProratedMinimumPrice>(
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
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithMeteredMinimumPrice>(
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
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds>(
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
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithDisplayNamePrice>(
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
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPackagePrice>(
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
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMaxGroupTieredPackagePrice>(
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
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithUnitPricingPrice>(
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
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithTieredPricingPrice>(
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
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionCumulativeGroupedBulkPrice>(
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
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation>(
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
            case "minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMinimumCompositePrice>(
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
            case "percent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsAddPricePricePercent>(
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
            case "event_output":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput>(
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
                return new SubscriptionSchedulePlanChangeParamsAddPricePrice(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters,
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
    : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { JsonModel.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters(
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig,
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig
    : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
            >(this.RawData, "filters");
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier> Tiers
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier>
            >(this.RawData, "tiers");
        }
        init { JsonModel.Set(this._rawData, "tiers", value); }
    }

    /// <inheritdoc/>
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

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig(
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter,
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter
    : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { JsonModel.Set(this._rawData, "property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { JsonModel.Set(this._rawData, "property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter()
    { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter
    )
        : base(
            subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        ) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier,
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
    : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "tier_lower_bound"); }
        init { JsonModel.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier()
    { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
    )
        : base(
            subscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
        ) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        string unitAmount
    )
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Custom =>
                    "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration,
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig>(
                this.RawData,
                "tiered_with_proration_config"
            );
        }
        init { JsonModel.Set(this._rawData, "tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration(
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration subscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Custom =>
                    "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig,
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig
    : JsonModel
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier> Tiers
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier>
            >(this.RawData, "tiers");
        }
        init { JsonModel.Set(this._rawData, "tiers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig(
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig subscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig(
        List<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier,
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier
    : JsonModel
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tier_lower_bound"); }
        init { JsonModel.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier()
    { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier(
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier subscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier
    )
        : base(
            subscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier
        ) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds,
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                this.RawData,
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { JsonModel.Set(this._rawData, "grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds(
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds subscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ =>
                (SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Custom =>
                    "custom",
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
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "maximum_charge"); }
        init { JsonModel.Set(this._rawData, "maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "minimum_charge"); }
        init { JsonModel.Set(this._rawData, "minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "per_unit_rate"); }
        init { JsonModel.Set(this._rawData, "per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig subscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation,
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { JsonModel.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation(
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation subscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Custom,
            _ =>
                (SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Custom =>
                    "custom",
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
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "cumulative_allocation"); }
        init { JsonModel.Set(this._rawData, "cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "group_allocation"); }
        init { JsonModel.Set(this._rawData, "group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig subscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePricePercent,
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePricePercent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence>
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig PercentConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig>(
                this.RawData,
                "percent_config"
            );
        }
        init { JsonModel.Set(this._rawData, "percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"percent\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercent()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercent(
        SubscriptionSchedulePlanChangeParamsAddPricePricePercent subscriptionSchedulePlanChangeParamsAddPricePricePercent
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePricePercent) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePricePercent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePricePercentFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePricePercentFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePricePercent>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsAddPricePricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadenceConverter))]
public enum SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.SemiAnnual,
            "monthly" => SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Quarterly,
            "one_time" => SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.OneTime,
            "custom" => SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual => "annual",
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig,
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig
    : JsonModel
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "percent"); }
        init { JsonModel.Set(this._rawData, "percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig() { }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig(
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig subscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput,
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence>
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig>(
                this.RawData,
                "event_output_config"
            );
        }
        init { JsonModel.Set(this._rawData, "event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"event_output\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput(
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput subscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePriceEventOutput) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.OneTime,
            "custom" => SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Custom =>
                    "custom",
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
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig,
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
    : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_rating_key"); }
        init { JsonModel.Set(this._rawData, "unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "default_unit_rate"); }
        init { JsonModel.Set(this._rawData, "default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig() { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig(
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig subscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
    )
        : base(subscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig) { }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig(
        string unitRatingKey
    )
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig value,
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

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsRemoveAdjustment,
        SubscriptionSchedulePlanChangeParamsRemoveAdjustmentFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsRemoveAdjustment : JsonModel
{
    /// <summary>
    /// The id of the adjustment to remove on the subscription.
    /// </summary>
    public required string AdjustmentID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "adjustment_id"); }
        init { JsonModel.Set(this._rawData, "adjustment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdjustmentID;
    }

    public SubscriptionSchedulePlanChangeParamsRemoveAdjustment() { }

    public SubscriptionSchedulePlanChangeParamsRemoveAdjustment(
        SubscriptionSchedulePlanChangeParamsRemoveAdjustment subscriptionSchedulePlanChangeParamsRemoveAdjustment
    )
        : base(subscriptionSchedulePlanChangeParamsRemoveAdjustment) { }

    public SubscriptionSchedulePlanChangeParamsRemoveAdjustment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsRemoveAdjustment(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsRemoveAdjustmentFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsRemoveAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsRemoveAdjustment(string adjustmentID)
        : this()
    {
        this.AdjustmentID = adjustmentID;
    }
}

class SubscriptionSchedulePlanChangeParamsRemoveAdjustmentFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsRemoveAdjustment>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsRemoveAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsRemoveAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsRemovePrice,
        SubscriptionSchedulePlanChangeParamsRemovePriceFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsRemovePrice : JsonModel
{
    /// <summary>
    /// The external price id of the price to remove on the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// The id of the price to remove on the subscription.
    /// </summary>
    public string? PriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "price_id"); }
        init { JsonModel.Set(this._rawData, "price_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalPriceID;
        _ = this.PriceID;
    }

    public SubscriptionSchedulePlanChangeParamsRemovePrice() { }

    public SubscriptionSchedulePlanChangeParamsRemovePrice(
        SubscriptionSchedulePlanChangeParamsRemovePrice subscriptionSchedulePlanChangeParamsRemovePrice
    )
        : base(subscriptionSchedulePlanChangeParamsRemovePrice) { }

    public SubscriptionSchedulePlanChangeParamsRemovePrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsRemovePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsRemovePriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsRemovePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsRemovePriceFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsRemovePrice>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsRemovePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsRemovePrice.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplaceAdjustment,
        SubscriptionSchedulePlanChangeParamsReplaceAdjustmentFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplaceAdjustment : JsonModel
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment Adjustment
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment>(
                this.RawData,
                "adjustment"
            );
        }
        init { JsonModel.Set(this._rawData, "adjustment", value); }
    }

    /// <summary>
    /// The id of the adjustment on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "replaces_adjustment_id"); }
        init { JsonModel.Set(this._rawData, "replaces_adjustment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.ReplacesAdjustmentID;
    }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustment() { }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustment(
        SubscriptionSchedulePlanChangeParamsReplaceAdjustment subscriptionSchedulePlanChangeParamsReplaceAdjustment
    )
        : base(subscriptionSchedulePlanChangeParamsReplaceAdjustment) { }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplaceAdjustment(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplaceAdjustmentFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplaceAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplaceAdjustmentFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplaceAdjustment>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplaceAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsReplaceAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustmentConverter))]
public record class SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewPercentageDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewUsageDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewAmountDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewMinimum value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewMaximum value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPercentageDiscount(out var value)) {
    ///     // `value` is of type `NewPercentageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewUsageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewUsageDiscount(out var value)) {
    ///     // `value` is of type `NewUsageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewAmountDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewAmountDiscount(out var value)) {
    ///     // `value` is of type `NewAmountDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMinimum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMinimum(out var value)) {
    ///     // `value` is of type `NewMinimum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMaximum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMaximum(out var value)) {
    ///     // `value` is of type `NewMaximum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment"
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewUsageDiscount value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewAmountDiscount value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewMinimum value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(
        NewMaximum value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment"
            );
        }
        this.Switch(
            (newPercentageDiscount) => newPercentageDiscount.Validate(),
            (newUsageDiscount) => newUsageDiscount.Validate(),
            (newAmountDiscount) => newAmountDiscount.Validate(),
            (newMinimum) => newMinimum.Validate(),
            (newMaximum) => newMaximum.Validate()
        );
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustmentConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment>
{
    public override SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = element.GetProperty("adjustment_type").GetString();
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
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(
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
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(
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
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(element, options);
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
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(element, options);
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
                return new SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePrice,
        SubscriptionSchedulePlanChangeParamsReplacePriceFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePrice : JsonModel
{
    /// <summary>
    /// The id of the price on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesPriceID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "replaces_price_id"); }
        init { JsonModel.Set(this._rawData, "replaces_price_id", value); }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            return JsonModel.GetNullableClass<NewAllocationPrice>(this.RawData, "allocation_price");
        }
        init { JsonModel.Set(this._rawData, "allocation_price", value); }
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
            return JsonModel.GetNullableClass<List<DiscountOverride>>(this.RawData, "discounts");
        }
        init { JsonModel.Set(this._rawData, "discounts", value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// The new quantity of the price, if the price is a fixed price.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for the replacement price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MaximumAmount
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "maximum_amount"); }
        init { JsonModel.Set(this._rawData, "maximum_amount", value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for the replacement price.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? MinimumAmount
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "minimum_amount"); }
        init { JsonModel.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsReplacePricePrice? Price
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                this.RawData,
                "price"
            );
        }
        init { JsonModel.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "price_id"); }
        init { JsonModel.Set(this._rawData, "price_id", value); }
    }

    /// <inheritdoc/>
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

    public SubscriptionSchedulePlanChangeParamsReplacePrice() { }

    public SubscriptionSchedulePlanChangeParamsReplacePrice(
        SubscriptionSchedulePlanChangeParamsReplacePrice subscriptionSchedulePlanChangeParamsReplacePrice
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePrice) { }

    public SubscriptionSchedulePlanChangeParamsReplacePrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsReplacePrice(string replacesPriceID)
        : this()
    {
        this.ReplacesPriceID = replacesPriceID;
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePriceFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePrice>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsReplacePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceConverter))]
public record class SubscriptionSchedulePlanChangeParamsReplacePricePrice
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionUnitPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionBulkPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMatrixPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionThresholdTotalAmountPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedTieredPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredPackageWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionPackageWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionUnitWithPercentPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMatrixWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionUnitWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionBulkWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMatrixWithDisplayNamePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMaxGroupTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionCumulativeGroupedBulkPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMinimumCompositePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePrice(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionUnit(out var value)) {
    ///     // `value` is of type `NewSubscriptionUnitPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionUnit([NotNullWhen(true)] out NewSubscriptionUnitPrice? value)
    {
        value = this.Value as NewSubscriptionUnitPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTiered(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTiered(
        [NotNullWhen(true)] out NewSubscriptionTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionBulk(out var value)) {
    ///     // `value` is of type `NewSubscriptionBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionBulk([NotNullWhen(true)] out NewSubscriptionBulkPrice? value)
    {
        value = this.Value as NewSubscriptionBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters? value
    )
    {
        value = this.Value as SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionPackage(
        [NotNullWhen(true)] out NewSubscriptionPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMatrix(out var value)) {
    ///     // `value` is of type `NewSubscriptionMatrixPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMatrix(
        [NotNullWhen(true)] out NewSubscriptionMatrixPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionThresholdTotalAmountPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionThresholdTotalAmount(out var value)) {
    ///     // `value` is of type `NewSubscriptionThresholdTotalAmountPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionThresholdTotalAmount(
        [NotNullWhen(true)] out NewSubscriptionThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewSubscriptionThresholdTotalAmountPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTieredPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTieredWithMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTieredWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedTiered(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedTiered(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionTieredPackageWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionTieredPackageWithMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionTieredPackageWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionTieredPackageWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionPackageWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionPackageWithAllocation(out var value)) {
    ///     // `value` is of type `NewSubscriptionPackageWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionPackageWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionPackageWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitWithPercentPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionUnitWithPercent(out var value)) {
    ///     // `value` is of type `NewSubscriptionUnitWithPercentPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionUnitWithPercent(
        [NotNullWhen(true)] out NewSubscriptionUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithPercentPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMatrixWithAllocation(out var value)) {
    ///     // `value` is of type `NewSubscriptionMatrixWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMatrixWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredWithProration(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredWithProration(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration? value
    )
    {
        value =
            this.Value as SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionUnitWithProration(out var value)) {
    ///     // `value` is of type `NewSubscriptionUnitWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionUnitWithProration(
        [NotNullWhen(true)] out NewSubscriptionUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionUnitWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedAllocation(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedAllocation(
        [NotNullWhen(true)] out NewSubscriptionGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionBulkWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionBulkWithProration(out var value)) {
    ///     // `value` is of type `NewSubscriptionBulkWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionBulkWithProration(
        [NotNullWhen(true)] out NewSubscriptionBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewSubscriptionBulkWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedWithProratedMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedWithProratedMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedWithProratedMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithProratedMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedWithMeteredMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedWithMeteredMinimum(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedWithMeteredMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds? value
    )
    {
        value =
            this.Value
            as SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMatrixWithDisplayName(out var value)) {
    ///     // `value` is of type `NewSubscriptionMatrixWithDisplayNamePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMatrixWithDisplayName(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewSubscriptionMatrixWithDisplayNamePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionGroupedTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionGroupedTieredPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionGroupedTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionGroupedTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionGroupedTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMaxGroupTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMaxGroupTieredPackage(out var value)) {
    ///     // `value` is of type `NewSubscriptionMaxGroupTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewSubscriptionMaxGroupTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionScalableMatrixWithUnitPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionScalableMatrixWithUnitPricing(out var value)) {
    ///     // `value` is of type `NewSubscriptionScalableMatrixWithUnitPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionScalableMatrixWithTieredPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionScalableMatrixWithTieredPricing(out var value)) {
    ///     // `value` is of type `NewSubscriptionScalableMatrixWithTieredPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewSubscriptionScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionCumulativeGroupedBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionCumulativeGroupedBulk(out var value)) {
    ///     // `value` is of type `NewSubscriptionCumulativeGroupedBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewSubscriptionCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewSubscriptionCumulativeGroupedBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation? value
    )
    {
        value =
            this.Value
            as SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSubscriptionMinimumComposite(out var value)) {
    ///     // `value` is of type `NewSubscriptionMinimumCompositePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSubscriptionMinimumComposite(
        [NotNullWhen(true)] out NewSubscriptionMinimumCompositePrice? value
    )
    {
        value = this.Value as NewSubscriptionMinimumCompositePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsReplacePricePricePercent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsReplacePricePricePercent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent(
        [NotNullWhen(true)] out SubscriptionSchedulePlanChangeParamsReplacePricePricePercent? value
    )
    {
        value = this.Value as SubscriptionSchedulePlanChangeParamsReplacePricePricePercent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput(
        [NotNullWhen(true)]
            out SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput? value
    )
    {
        value = this.Value as SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput;
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
    ///     (NewSubscriptionUnitPrice value) => {...},
    ///     (NewSubscriptionTieredPrice value) => {...},
    ///     (NewSubscriptionBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters value) => {...},
    ///     (NewSubscriptionPackagePrice value) => {...},
    ///     (NewSubscriptionMatrixPrice value) => {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) => {...},
    ///     (NewSubscriptionTieredPackagePrice value) => {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPrice value) => {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) => {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) => {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) => {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration value) => {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) => {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) => {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation value) => {...},
    ///     (NewSubscriptionMinimumCompositePrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePricePercent value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters> bulkWithFilters,
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
        System::Action<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<SubscriptionSchedulePlanChangeParamsReplacePricePricePercent> percent,
        System::Action<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput> eventOutput
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
            case SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters value:
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
            case SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration value:
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
            case SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds value:
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
            case SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case SubscriptionSchedulePlanChangeParamsReplacePricePricePercent value:
                percent(value);
                break;
            case SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePrice"
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
    ///     (NewSubscriptionUnitPrice value) => {...},
    ///     (NewSubscriptionTieredPrice value) => {...},
    ///     (NewSubscriptionBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters value) => {...},
    ///     (NewSubscriptionPackagePrice value) => {...},
    ///     (NewSubscriptionMatrixPrice value) => {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) => {...},
    ///     (NewSubscriptionTieredPackagePrice value) => {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPrice value) => {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) => {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) => {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) => {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration value) => {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) => {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) => {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) => {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) => {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation value) => {...},
    ///     (NewSubscriptionMinimumCompositePrice value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePricePercent value) => {...},
    ///     (SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<
            SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters,
            T
        > bulkWithFilters,
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
        System::Func<
            SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration,
            T
        > tieredWithProration,
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
            SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds,
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
            SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<SubscriptionSchedulePlanChangeParamsReplacePricePricePercent, T> percent,
        System::Func<
            SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput,
            T
        > eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters value =>
                bulkWithFilters(value),
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
            SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration value =>
                tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds value =>
                groupedWithMinMaxThresholds(value),
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
            SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            SubscriptionSchedulePlanChangeParamsReplacePricePricePercent value => percent(value),
            SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput value => eventOutput(
                value
            ),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePrice"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionUnitPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionBulkPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMatrixPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedTieredPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        NewSubscriptionMinimumCompositePrice value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercent value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePrice(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePrice"
            );
        }
        this.Switch(
            (newSubscriptionUnit) => newSubscriptionUnit.Validate(),
            (newSubscriptionTiered) => newSubscriptionTiered.Validate(),
            (newSubscriptionBulk) => newSubscriptionBulk.Validate(),
            (bulkWithFilters) => bulkWithFilters.Validate(),
            (newSubscriptionPackage) => newSubscriptionPackage.Validate(),
            (newSubscriptionMatrix) => newSubscriptionMatrix.Validate(),
            (newSubscriptionThresholdTotalAmount) => newSubscriptionThresholdTotalAmount.Validate(),
            (newSubscriptionTieredPackage) => newSubscriptionTieredPackage.Validate(),
            (newSubscriptionTieredWithMinimum) => newSubscriptionTieredWithMinimum.Validate(),
            (newSubscriptionGroupedTiered) => newSubscriptionGroupedTiered.Validate(),
            (newSubscriptionTieredPackageWithMinimum) =>
                newSubscriptionTieredPackageWithMinimum.Validate(),
            (newSubscriptionPackageWithAllocation) =>
                newSubscriptionPackageWithAllocation.Validate(),
            (newSubscriptionUnitWithPercent) => newSubscriptionUnitWithPercent.Validate(),
            (newSubscriptionMatrixWithAllocation) => newSubscriptionMatrixWithAllocation.Validate(),
            (tieredWithProration) => tieredWithProration.Validate(),
            (newSubscriptionUnitWithProration) => newSubscriptionUnitWithProration.Validate(),
            (newSubscriptionGroupedAllocation) => newSubscriptionGroupedAllocation.Validate(),
            (newSubscriptionBulkWithProration) => newSubscriptionBulkWithProration.Validate(),
            (newSubscriptionGroupedWithProratedMinimum) =>
                newSubscriptionGroupedWithProratedMinimum.Validate(),
            (newSubscriptionGroupedWithMeteredMinimum) =>
                newSubscriptionGroupedWithMeteredMinimum.Validate(),
            (groupedWithMinMaxThresholds) => groupedWithMinMaxThresholds.Validate(),
            (newSubscriptionMatrixWithDisplayName) =>
                newSubscriptionMatrixWithDisplayName.Validate(),
            (newSubscriptionGroupedTieredPackage) => newSubscriptionGroupedTieredPackage.Validate(),
            (newSubscriptionMaxGroupTieredPackage) =>
                newSubscriptionMaxGroupTieredPackage.Validate(),
            (newSubscriptionScalableMatrixWithUnitPricing) =>
                newSubscriptionScalableMatrixWithUnitPricing.Validate(),
            (newSubscriptionScalableMatrixWithTieredPricing) =>
                newSubscriptionScalableMatrixWithTieredPricing.Validate(),
            (newSubscriptionCumulativeGroupedBulk) =>
                newSubscriptionCumulativeGroupedBulk.Validate(),
            (cumulativeGroupedAllocation) => cumulativeGroupedAllocation.Validate(),
            (newSubscriptionMinimumComposite) => newSubscriptionMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(SubscriptionSchedulePlanChangeParamsReplacePricePrice? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePrice?>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePrice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = element.GetProperty("model_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionTieredPrice>(
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
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionBulkPrice>(
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
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters>(
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
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionPackagePrice>(
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
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixPrice>(
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
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionThresholdTotalAmountPrice>(
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
            case "tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackagePrice>(
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
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredWithMinimumPrice>(
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
            case "grouped_tiered":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPrice>(
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
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackageWithMinimumPrice>(
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
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionPackageWithAllocationPrice>(
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
            case "unit_with_percent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithPercentPrice>(
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
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPrice>(
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
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration>(
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
            case "unit_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithProrationPrice>(
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
            case "grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedAllocationPrice>(
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
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionBulkWithProrationPrice>(
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
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithProratedMinimumPrice>(
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
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithMeteredMinimumPrice>(
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
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds>(
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
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithDisplayNamePrice>(
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
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPackagePrice>(
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
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMaxGroupTieredPackagePrice>(
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
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithUnitPricingPrice>(
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
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithTieredPricingPrice>(
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
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionCumulativeGroupedBulkPrice>(
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
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation>(
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
            case "minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMinimumCompositePrice>(
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
            case "percent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsReplacePricePricePercent>(
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
            case "event_output":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput>(
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
                return new SubscriptionSchedulePlanChangeParamsReplacePricePrice(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
    : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { JsonModel.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
    : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
            >(this.RawData, "filters");
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> Tiers
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
            >(this.RawData, "tiers");
        }
        init { JsonModel.Set(this._rawData, "tiers", value); }
    }

    /// <inheritdoc/>
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
    : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { JsonModel.Set(this._rawData, "property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { JsonModel.Set(this._rawData, "property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter()
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
    )
        : base(
            subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        ) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
    : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "tier_lower_bound"); }
        init { JsonModel.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier()
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
    )
        : base(
            subscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        ) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        string unitAmount
    )
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Custom =>
                    "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                this.RawData,
                "tiered_with_proration_config"
            );
        }
        init { JsonModel.Set(this._rawData, "tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration subscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Custom =>
                    "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig
    : JsonModel
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> Tiers
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
            >(this.RawData, "tiers");
        }
        init { JsonModel.Set(this._rawData, "tiers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig subscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        List<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
    : JsonModel
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tier_lower_bound"); }
        init { JsonModel.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier()
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier subscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
    )
        : base(
            subscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
        ) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                this.RawData,
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { JsonModel.Set(this._rawData, "grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds subscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ =>
                (SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom =>
                    "custom",
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
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "maximum_charge"); }
        init { JsonModel.Set(this._rawData, "maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "minimum_charge"); }
        init { JsonModel.Set(this._rawData, "minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "per_unit_rate"); }
        init { JsonModel.Set(this._rawData, "per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig subscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { JsonModel.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation subscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Custom,
            _ =>
                (SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Custom =>
                    "custom",
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
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "cumulative_allocation"); }
        init { JsonModel.Set(this._rawData, "cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "group_allocation"); }
        init { JsonModel.Set(this._rawData, "group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig()
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig subscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    )
        : base(
            subscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        ) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercent,
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePricePercent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence>
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig PercentConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig>(
                this.RawData,
                "percent_config"
            );
        }
        init { JsonModel.Set(this._rawData, "percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"percent\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercent()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercent(
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercent subscriptionSchedulePlanChangeParamsReplacePricePricePercent
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePricePercent) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePricePercent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePricePercentFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePricePercent>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsReplacePricePricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.OneTime,
            "custom" => SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Custom =>
                    "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig,
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig
    : JsonModel
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "percent"); }
        init { JsonModel.Set(this._rawData, "percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig() { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig(
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig subscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig>(
                this.RawData,
                "event_output_config"
            );
        }
        init { JsonModel.Set(this._rawData, "event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { JsonModel.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"event_output\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput subscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput) { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadenceConverter)
)]
public enum SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadenceConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
            "semi_annual" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.SemiAnnual,
            "monthly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Monthly,
            "quarterly" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Quarterly,
            "one_time" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.OneTime,
            "custom" =>
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Custom,
            _ => (SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual =>
                    "annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.SemiAnnual =>
                    "semi_annual",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Monthly =>
                    "monthly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Quarterly =>
                    "quarterly",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.OneTime =>
                    "one_time",
                SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Custom =>
                    "custom",
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
    typeof(JsonModelConverter<
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
    : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_rating_key"); }
        init { JsonModel.Set(this._rawData, "unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "default_unit_rate"); }
        init { JsonModel.Set(this._rawData, "default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig() { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig subscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
    )
        : base(subscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig)
    { }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfigFromRaw.FromRawUnchecked"/>
    public static SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig(
        string unitRatingKey
    )
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfigFromRaw
    : IFromRawJson<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig>
{
    /// <inheritdoc/>
    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfigConverter)
)]
public record class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig"
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfigConverter
    : JsonConverter<SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig>
{
    public override SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
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
                return new SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
