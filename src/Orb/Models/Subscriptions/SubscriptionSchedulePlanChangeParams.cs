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
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string SubscriptionID { get; init; }

    public required ApiEnum<string, ChangeOptionModel> ChangeOption
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("change_option", out JsonElement element))
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
            this._bodyProperties["change_option"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional adjustments to be added to the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<AddAdjustment1>? AddAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("add_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddAdjustment1>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["add_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional prices to be added to the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<AddPriceModel>? AddPrices
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("add_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddPriceModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["add_prices"] = JsonSerializer.SerializeToElement(
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
                !this._bodyProperties.TryGetValue(
                    "align_billing_with_plan_change_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["align_billing_with_plan_change_date"] =
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
            if (!this._bodyProperties.TryGetValue("auto_collection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["auto_collection"] = JsonSerializer.SerializeToElement(
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
                !this._bodyProperties.TryGetValue(
                    "billing_cycle_alignment",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, BillingCycleAlignment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["billing_cycle_alignment"] = JsonSerializer.SerializeToElement(
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
                !this._bodyProperties.TryGetValue(
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
            this._bodyProperties["billing_cycle_anchor_configuration"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The date that the plan change should take effect. This parameter can only
    /// be passed if the `change_option` is `requested_date`. If a date with no time
    /// is passed, the plan change will happen at midnight in the customer's timezone.
    /// </summary>
    public System::DateTime? ChangeDate
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("change_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["change_date"] = JsonSerializer.SerializeToElement(
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
            if (
                !this._bodyProperties.TryGetValue("coupon_redemption_code", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["coupon_redemption_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? CreditsOverageRate
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("credits_overage_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["credits_overage_rate"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("default_invoice_memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["default_invoice_memo"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("external_plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["external_plan_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["filter"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("initial_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["initial_phase_order"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("invoicing_threshold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["invoicing_threshold"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["net_terms"] = JsonSerializer.SerializeToElement(
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
                !this._bodyProperties.TryGetValue(
                    "per_credit_overage_amount",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["per_credit_overage_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["plan_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("plan_version_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["plan_version_number"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("price_overrides", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["price_overrides"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be removed from the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<RemoveAdjustmentModel>? RemoveAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("remove_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemoveAdjustmentModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["remove_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan prices to be removed from the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<RemovePriceModel>? RemovePrices
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("remove_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemovePriceModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["remove_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be replaced with additional adjustments on the subscription.
    /// (Only available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<ReplaceAdjustmentModel>? ReplaceAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("replace_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplaceAdjustmentModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["replace_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Plan prices to be replaced with additional prices on the subscription. (Only
    /// available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public List<ReplacePriceModel>? ReplacePrices
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("replace_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplacePriceModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["replace_prices"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("trial_duration_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["trial_duration_days"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionSchedulePlanChangeParams() { }

    public SubscriptionSchedulePlanChangeParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSchedulePlanChangeParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static SubscriptionSchedulePlanChangeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
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

[JsonConverter(typeof(ModelConverter<AddAdjustment1>))]
public sealed record class AddAdjustment1 : ModelBase, IFromRaw<AddAdjustment1>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required Adjustment2 Adjustment
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<Adjustment2>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentNullException("adjustment")
                );
        }
        init
        {
            this._properties["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription.
    /// </summary>
    public System::DateTime? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
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

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. If null, the adjustment
    /// will start when the phase or subscription starts.
    /// </summary>
    public System::DateTime? StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
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

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.EndDate;
        _ = this.PlanPhaseOrder;
        _ = this.StartDate;
    }

    public AddAdjustment1() { }

    public AddAdjustment1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AddAdjustment1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public AddAdjustment1(Adjustment2 adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(Adjustment2Converter))]
public record class Adjustment2
{
    public object Value { get; private init; }

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

    public Adjustment2(NewPercentageDiscount value)
    {
        Value = value;
    }

    public Adjustment2(NewUsageDiscount value)
    {
        Value = value;
    }

    public Adjustment2(NewAmountDiscount value)
    {
        Value = value;
    }

    public Adjustment2(NewMinimum value)
    {
        Value = value;
    }

    public Adjustment2(NewMaximum value)
    {
        Value = value;
    }

    Adjustment2(UnknownVariant value)
    {
        Value = value;
    }

    public static Adjustment2 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment2");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment2"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment2");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Adjustment2Converter : JsonConverter<Adjustment2>
{
    public override Adjustment2? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPercentageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewUsageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amount_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewAmountDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMinimum'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "maximum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMaximum'",
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
        Adjustment2 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<AddPriceModel>))]
public sealed record class AddPriceModel : ModelBase, IFromRaw<AddPriceModel>
{
    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this._properties.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["allocation_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's discounts for
    /// this price.
    /// </summary>
    public List<DiscountOverride>? Discounts
    {
        get
        {
            if (!this._properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DiscountOverride>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that the price will
    /// stop billing on the subscription. If null, billing will end when the phase
    /// or subscription ends.
    /// </summary>
    public System::DateTime? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
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

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for this price.
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for this price.
    /// </summary>
    public string? MinimumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["minimum_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public Price2? Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Price2?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["price"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["price_id"] = JsonSerializer.SerializeToElement(
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
    public System::DateTime? StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
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

    public AddPriceModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPriceModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AddPriceModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(Price2Converter))]
public record class Price2
{
    public object Value { get; private init; }

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
                newSubscriptionMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public Price2(NewSubscriptionUnitPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionTieredPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionBulkPrice value)
    {
        Value = value;
    }

    public Price2(BulkWithFilters2 value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionPackagePrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionMatrixPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionThresholdTotalAmountPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionTieredPackagePrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionTieredWithMinimumPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionGroupedTieredPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionTieredPackageWithMinimumPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionPackageWithAllocationPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionUnitWithPercentPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionMatrixWithAllocationPrice value)
    {
        Value = value;
    }

    public Price2(TieredWithProration1 value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionUnitWithProrationPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionGroupedAllocationPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionBulkWithProrationPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionGroupedWithProratedMinimumPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionGroupedWithMeteredMinimumPrice value)
    {
        Value = value;
    }

    public Price2(GroupedWithMinMaxThresholds2 value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionMatrixWithDisplayNamePrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionGroupedTieredPackagePrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionMaxGroupTieredPackagePrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionScalableMatrixWithUnitPricingPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionScalableMatrixWithTieredPricingPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionCumulativeGroupedBulkPrice value)
    {
        Value = value;
    }

    public Price2(NewSubscriptionMinimumCompositePrice value)
    {
        Value = value;
    }

    public Price2(Percent2 value)
    {
        Value = value;
    }

    public Price2(EventOutput2 value)
    {
        Value = value;
    }

    Price2(UnknownVariant value)
    {
        Value = value;
    }

    public static Price2 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public bool TryPickBulkWithFilters([NotNullWhen(true)] out BulkWithFilters2? value)
    {
        value = this.Value as BulkWithFilters2;
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

    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProration1? value)
    {
        value = this.Value as TieredWithProration1;
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
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds2? value
    )
    {
        value = this.Value as GroupedWithMinMaxThresholds2;
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

    public bool TryPickNewSubscriptionMinimumComposite(
        [NotNullWhen(true)] out NewSubscriptionMinimumCompositePrice? value
    )
    {
        value = this.Value as NewSubscriptionMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out Percent2? value)
    {
        value = this.Value as Percent2;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutput2? value)
    {
        value = this.Value as EventOutput2;
        return value != null;
    }

    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<BulkWithFilters2> bulkWithFilters,
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
        System::Action<TieredWithProration1> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<GroupedWithMinMaxThresholds2> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<Percent2> percent,
        System::Action<EventOutput2> eventOutput
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
            case BulkWithFilters2 value:
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
            case TieredWithProration1 value:
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
            case GroupedWithMinMaxThresholds2 value:
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
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case Percent2 value:
                percent(value);
                break;
            case EventOutput2 value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price2");
        }
    }

    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<BulkWithFilters2, T> bulkWithFilters,
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
        System::Func<TieredWithProration1, T> tieredWithProration,
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
        System::Func<GroupedWithMinMaxThresholds2, T> groupedWithMinMaxThresholds,
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
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<Percent2, T> percent,
        System::Func<EventOutput2, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            BulkWithFilters2 value => bulkWithFilters(value),
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
            TieredWithProration1 value => tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            GroupedWithMinMaxThresholds2 value => groupedWithMinMaxThresholds(value),
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
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            Percent2 value => percent(value),
            EventOutput2 value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price2"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price2");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Price2Converter : JsonConverter<Price2?>
{
    public override Price2? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionUnitPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_filters":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BulkWithFilters2>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BulkWithFilters2'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMatrixPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "threshold_total_amount":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionThresholdTotalAmountPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredPackageWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionPackageWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_percent":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionUnitWithPercentPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMatrixWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredWithProration1>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredWithProration1'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionUnitWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionBulkWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_prorated_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedWithProratedMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_metered_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedWithMeteredMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds2>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'GroupedWithMinMaxThresholds2'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_display_name":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMatrixWithDisplayNamePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "max_group_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMaxGroupTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionScalableMatrixWithUnitPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionScalableMatrixWithTieredPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "cumulative_grouped_bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionCumulativeGroupedBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMinimumCompositePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Percent2>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Percent2'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "event_output":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<EventOutput2>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'EventOutput2'",
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

    public override void Write(Utf8JsonWriter writer, Price2? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<BulkWithFilters2>))]
public sealed record class BulkWithFilters2 : ModelBase, IFromRaw<BulkWithFilters2>
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required BulkWithFiltersConfig2 BulkWithFiltersConfig
    {
        get
        {
            if (!this._properties.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<BulkWithFiltersConfig2>(
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
            this._properties["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence13> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence13>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType13 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType13>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig13? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig13?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public BulkWithFilters2()
    {
        this.ModelType = new();
    }

    public BulkWithFilters2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFilters2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<BulkWithFiltersConfig2>))]
public sealed record class BulkWithFiltersConfig2 : ModelBase, IFromRaw<BulkWithFiltersConfig2>
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Filter2> Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
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
            this._properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Tier4> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
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
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
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

    public BulkWithFiltersConfig2() { }

    public BulkWithFiltersConfig2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFiltersConfig2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Filter2>))]
public sealed record class Filter2 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Filter2>
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._properties.TryGetValue("property_key", out JsonElement element))
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
            this._properties["property_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("property_value", out JsonElement element))
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
            this._properties["property_value"] = JsonSerializer.SerializeToElement(
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

    public Filter2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Filter2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Tier4>))]
public sealed record class Tier4 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Tier4>
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
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
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
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

    public Tier4(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier4(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier4 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Tier4(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence13Converter))]
public enum Cadence13
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence13Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence13>
{
    public override global::Orb.Models.Subscriptions.Cadence13 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence13.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence13.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence13.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence13.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence13.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence13.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence13)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence13 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence13.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence13.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence13.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence13.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence13.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence13.Custom => "custom",
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
public class ModelType13
{
    public JsonElement Json { get; private init; }

    public ModelType13()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ModelType13(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType13().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType13'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType13>
    {
        public override global::Orb.Models.Subscriptions.ModelType13? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType13 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig13Converter))]
public record class ConversionRateConfig13
{
    public object Value { get; private init; }

    public ConversionRateConfig13(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig13(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig13(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig13 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig13"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig13"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig13"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig13Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig13>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig13? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig13(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig13(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig13 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<TieredWithProration1>))]
public sealed record class TieredWithProration1 : ModelBase, IFromRaw<TieredWithProration1>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence14> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence14>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType14 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType14>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required TieredWithProrationConfig1 TieredWithProrationConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "tiered_with_proration_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_with_proration_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TieredWithProrationConfig1>(
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
            this._properties["tiered_with_proration_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig14? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig14?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public TieredWithProration1()
    {
        this.ModelType = new();
    }

    public TieredWithProration1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProration1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TieredWithProration1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence14Converter))]
public enum Cadence14
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence14Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence14>
{
    public override global::Orb.Models.Subscriptions.Cadence14 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence14.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence14.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence14.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence14.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence14.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence14.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence14)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence14 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence14.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence14.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence14.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence14.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence14.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence14.Custom => "custom",
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
public class ModelType14
{
    public JsonElement Json { get; private init; }

    public ModelType14()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    ModelType14(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType14().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType14'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType14>
    {
        public override global::Orb.Models.Subscriptions.ModelType14? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType14 value,
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
[JsonConverter(typeof(ModelConverter<TieredWithProrationConfig1>))]
public sealed record class TieredWithProrationConfig1
    : ModelBase,
        IFromRaw<TieredWithProrationConfig1>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier with proration
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Tier5> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
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
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
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

    public TieredWithProrationConfig1() { }

    public TieredWithProrationConfig1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfig1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TieredWithProrationConfig1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfig1(List<global::Orb.Models.Subscriptions.Tier5> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Tier5>))]
public sealed record class Tier5 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Tier5>
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
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
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
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
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
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

    public Tier5(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier5(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier5 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig14Converter))]
public record class ConversionRateConfig14
{
    public object Value { get; private init; }

    public ConversionRateConfig14(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig14(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig14(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig14 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig14"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig14"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig14"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig14Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig14>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig14? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig14(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig14(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig14 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholds2>))]
public sealed record class GroupedWithMinMaxThresholds2
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholds2>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence15> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence15>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required GroupedWithMinMaxThresholdsConfig2 GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
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

            return JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConfig2>(
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
            this._properties["grouped_with_min_max_thresholds_config"] =
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType15 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType15>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig15? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig15?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public GroupedWithMinMaxThresholds2()
    {
        this.ModelType = new();
    }

    public GroupedWithMinMaxThresholds2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholds2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence15Converter))]
public enum Cadence15
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence15Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence15>
{
    public override global::Orb.Models.Subscriptions.Cadence15 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence15.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence15.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence15.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence15.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence15.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence15.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence15)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence15 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence15.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence15.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence15.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence15.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence15.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence15.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholdsConfig2>))]
public sealed record class GroupedWithMinMaxThresholdsConfig2
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholdsConfig2>
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
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
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("maximum_charge", out JsonElement element))
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
            this._properties["maximum_charge"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("minimum_charge", out JsonElement element))
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
            this._properties["minimum_charge"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("per_unit_rate", out JsonElement element))
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
            this._properties["per_unit_rate"] = JsonSerializer.SerializeToElement(
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

    public GroupedWithMinMaxThresholdsConfig2() { }

    public GroupedWithMinMaxThresholdsConfig2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholdsConfig2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType15
{
    public JsonElement Json { get; private init; }

    public ModelType15()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ModelType15(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType15().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType15'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType15>
    {
        public override global::Orb.Models.Subscriptions.ModelType15? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType15 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig15Converter))]
public record class ConversionRateConfig15
{
    public object Value { get; private init; }

    public ConversionRateConfig15(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig15(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig15(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig15 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig15"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig15"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig15"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig15Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig15>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig15? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig15(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig15(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig15 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<Percent2>))]
public sealed record class Percent2 : ModelBase, IFromRaw<Percent2>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence16> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence16>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType16 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType16>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// Configuration for percent pricing
    /// </summary>
    public required PercentConfig2 PercentConfig
    {
        get
        {
            if (!this._properties.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PercentConfig2>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentNullException("percent_config")
                );
        }
        init
        {
            this._properties["percent_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig16? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig16?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public Percent2()
    {
        this.ModelType = new();
    }

    public Percent2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Percent2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence16Converter))]
public enum Cadence16
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence16Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence16>
{
    public override global::Orb.Models.Subscriptions.Cadence16 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence16.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence16.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence16.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence16.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence16.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence16.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence16)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence16 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence16.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence16.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence16.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence16.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence16.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence16.Custom => "custom",
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
public class ModelType16
{
    public JsonElement Json { get; private init; }

    public ModelType16()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ModelType16(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType16().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType16'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType16>
    {
        public override global::Orb.Models.Subscriptions.ModelType16? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType16 value,
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
[JsonConverter(typeof(ModelConverter<PercentConfig2>))]
public sealed record class PercentConfig2 : ModelBase, IFromRaw<PercentConfig2>
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._properties.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public PercentConfig2() { }

    public PercentConfig2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PercentConfig2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PercentConfig2(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig16Converter))]
public record class ConversionRateConfig16
{
    public object Value { get; private init; }

    public ConversionRateConfig16(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig16(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig16(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig16 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig16"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig16"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig16"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig16Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig16>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig16? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig16(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig16(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig16 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<EventOutput2>))]
public sealed record class EventOutput2 : ModelBase, IFromRaw<EventOutput2>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence17> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence17>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required EventOutputConfig2 EventOutputConfig
    {
        get
        {
            if (!this._properties.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<EventOutputConfig2>(
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
            this._properties["event_output_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType17 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType17>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig17? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig17?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public EventOutput2()
    {
        this.ModelType = new();
    }

    public EventOutput2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutput2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence17Converter))]
public enum Cadence17
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence17Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence17>
{
    public override global::Orb.Models.Subscriptions.Cadence17 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence17.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence17.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence17.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence17.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence17.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence17.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence17)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence17 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence17.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence17.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence17.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence17.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence17.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence17.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<EventOutputConfig2>))]
public sealed record class EventOutputConfig2 : ModelBase, IFromRaw<EventOutputConfig2>
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._properties.TryGetValue("unit_rating_key", out JsonElement element))
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
            this._properties["unit_rating_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["default_unit_rate"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
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

    public EventOutputConfig2() { }

    public EventOutputConfig2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutputConfig2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EventOutputConfig2(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType17
{
    public JsonElement Json { get; private init; }

    public ModelType17()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ModelType17(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType17().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType17'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType17>
    {
        public override global::Orb.Models.Subscriptions.ModelType17? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType17 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig17Converter))]
public record class ConversionRateConfig17
{
    public object Value { get; private init; }

    public ConversionRateConfig17(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig17(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig17(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig17 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig17"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig17"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig17"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig17Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig17>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig17? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig17(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig17(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig17 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Reset billing periods to be aligned with the plan change's effective date or
/// start of the month. Defaults to `unchanged` which keeps subscription's existing
/// billing cycle alignment.
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

[JsonConverter(typeof(ModelConverter<RemoveAdjustmentModel>))]
public sealed record class RemoveAdjustmentModel : ModelBase, IFromRaw<RemoveAdjustmentModel>
{
    /// <summary>
    /// The id of the adjustment to remove on the subscription.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment_id", out JsonElement element))
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
            this._properties["adjustment_id"] = JsonSerializer.SerializeToElement(
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

    public RemoveAdjustmentModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveAdjustmentModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RemoveAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public RemoveAdjustmentModel(string adjustmentID)
        : this()
    {
        this.AdjustmentID = adjustmentID;
    }
}

[JsonConverter(typeof(ModelConverter<RemovePriceModel>))]
public sealed record class RemovePriceModel : ModelBase, IFromRaw<RemovePriceModel>
{
    /// <summary>
    /// The external price id of the price to remove on the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["price_id"] = JsonSerializer.SerializeToElement(
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

    public RemovePriceModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovePriceModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RemovePriceModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<ReplaceAdjustmentModel>))]
public sealed record class ReplaceAdjustmentModel : ModelBase, IFromRaw<ReplaceAdjustmentModel>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required Adjustment3 Adjustment
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<Adjustment3>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentNullException("adjustment")
                );
        }
        init
        {
            this._properties["adjustment"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("replaces_adjustment_id", out JsonElement element))
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
            this._properties["replaces_adjustment_id"] = JsonSerializer.SerializeToElement(
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

    public ReplaceAdjustmentModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplaceAdjustmentModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplaceAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(Adjustment3Converter))]
public record class Adjustment3
{
    public object Value { get; private init; }

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

    public Adjustment3(NewPercentageDiscount value)
    {
        Value = value;
    }

    public Adjustment3(NewUsageDiscount value)
    {
        Value = value;
    }

    public Adjustment3(NewAmountDiscount value)
    {
        Value = value;
    }

    public Adjustment3(NewMinimum value)
    {
        Value = value;
    }

    public Adjustment3(NewMaximum value)
    {
        Value = value;
    }

    Adjustment3(UnknownVariant value)
    {
        Value = value;
    }

    public static Adjustment3 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment3");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment3"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment3");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Adjustment3Converter : JsonConverter<Adjustment3>
{
    public override Adjustment3? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPercentageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewUsageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amount_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewAmountDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMinimum'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "maximum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMaximum'",
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
        Adjustment3 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<ReplacePriceModel>))]
public sealed record class ReplacePriceModel : ModelBase, IFromRaw<ReplacePriceModel>
{
    /// <summary>
    /// The id of the price on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("replaces_price_id", out JsonElement element))
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
            this._properties["replaces_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["allocation_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's discounts for
    /// the replacement price.
    /// </summary>
    public List<DiscountOverride>? Discounts
    {
        get
        {
            if (!this._properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DiscountOverride>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["discounts"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for the replacement price.
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for the replacement price.
    /// </summary>
    public string? MinimumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public Price3? Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Price3?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["price"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["price_id"] = JsonSerializer.SerializeToElement(
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

    public ReplacePriceModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePriceModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePriceModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ReplacePriceModel(string replacesPriceID)
        : this()
    {
        this.ReplacesPriceID = replacesPriceID;
    }
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(Price3Converter))]
public record class Price3
{
    public object Value { get; private init; }

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
                newSubscriptionMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public Price3(NewSubscriptionUnitPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionTieredPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionBulkPrice value)
    {
        Value = value;
    }

    public Price3(BulkWithFilters3 value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionPackagePrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionMatrixPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionThresholdTotalAmountPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionTieredPackagePrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionTieredWithMinimumPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionGroupedTieredPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionTieredPackageWithMinimumPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionPackageWithAllocationPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionUnitWithPercentPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionMatrixWithAllocationPrice value)
    {
        Value = value;
    }

    public Price3(TieredWithProration2 value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionUnitWithProrationPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionGroupedAllocationPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionBulkWithProrationPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionGroupedWithProratedMinimumPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionGroupedWithMeteredMinimumPrice value)
    {
        Value = value;
    }

    public Price3(GroupedWithMinMaxThresholds3 value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionMatrixWithDisplayNamePrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionGroupedTieredPackagePrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionMaxGroupTieredPackagePrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionScalableMatrixWithUnitPricingPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionScalableMatrixWithTieredPricingPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionCumulativeGroupedBulkPrice value)
    {
        Value = value;
    }

    public Price3(NewSubscriptionMinimumCompositePrice value)
    {
        Value = value;
    }

    public Price3(Percent3 value)
    {
        Value = value;
    }

    public Price3(EventOutput3 value)
    {
        Value = value;
    }

    Price3(UnknownVariant value)
    {
        Value = value;
    }

    public static Price3 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public bool TryPickBulkWithFilters([NotNullWhen(true)] out BulkWithFilters3? value)
    {
        value = this.Value as BulkWithFilters3;
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

    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProration2? value)
    {
        value = this.Value as TieredWithProration2;
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
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds3? value
    )
    {
        value = this.Value as GroupedWithMinMaxThresholds3;
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

    public bool TryPickNewSubscriptionMinimumComposite(
        [NotNullWhen(true)] out NewSubscriptionMinimumCompositePrice? value
    )
    {
        value = this.Value as NewSubscriptionMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out Percent3? value)
    {
        value = this.Value as Percent3;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutput3? value)
    {
        value = this.Value as EventOutput3;
        return value != null;
    }

    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<BulkWithFilters3> bulkWithFilters,
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
        System::Action<TieredWithProration2> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<GroupedWithMinMaxThresholds3> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<Percent3> percent,
        System::Action<EventOutput3> eventOutput
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
            case BulkWithFilters3 value:
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
            case TieredWithProration2 value:
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
            case GroupedWithMinMaxThresholds3 value:
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
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case Percent3 value:
                percent(value);
                break;
            case EventOutput3 value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price3");
        }
    }

    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<BulkWithFilters3, T> bulkWithFilters,
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
        System::Func<TieredWithProration2, T> tieredWithProration,
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
        System::Func<GroupedWithMinMaxThresholds3, T> groupedWithMinMaxThresholds,
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
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<Percent3, T> percent,
        System::Func<EventOutput3, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            BulkWithFilters3 value => bulkWithFilters(value),
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
            TieredWithProration2 value => tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            GroupedWithMinMaxThresholds3 value => groupedWithMinMaxThresholds(value),
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
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            Percent3 value => percent(value),
            EventOutput3 value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price3"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price3");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Price3Converter : JsonConverter<Price3?>
{
    public override Price3? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionUnitPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_filters":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BulkWithFilters3>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BulkWithFilters3'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMatrixPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "threshold_total_amount":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionThresholdTotalAmountPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionTieredPackageWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionPackageWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_percent":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionUnitWithPercentPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMatrixWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredWithProration2>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredWithProration2'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionUnitWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionBulkWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_prorated_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedWithProratedMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_metered_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedWithMeteredMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds3>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'GroupedWithMinMaxThresholds3'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_display_name":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMatrixWithDisplayNamePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionGroupedTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "max_group_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMaxGroupTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionScalableMatrixWithUnitPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionScalableMatrixWithTieredPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "cumulative_grouped_bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionCumulativeGroupedBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSubscriptionMinimumCompositePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Percent3>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Percent3'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "event_output":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<EventOutput3>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'EventOutput3'",
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

    public override void Write(Utf8JsonWriter writer, Price3? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<BulkWithFilters3>))]
public sealed record class BulkWithFilters3 : ModelBase, IFromRaw<BulkWithFilters3>
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required BulkWithFiltersConfig3 BulkWithFiltersConfig
    {
        get
        {
            if (!this._properties.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<BulkWithFiltersConfig3>(
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
            this._properties["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence18> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence18>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType18 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType18>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig18? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig18?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public BulkWithFilters3()
    {
        this.ModelType = new();
    }

    public BulkWithFilters3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFilters3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<BulkWithFiltersConfig3>))]
public sealed record class BulkWithFiltersConfig3 : ModelBase, IFromRaw<BulkWithFiltersConfig3>
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Filter3> Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
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
            this._properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Tier6> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
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
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
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

    public BulkWithFiltersConfig3() { }

    public BulkWithFiltersConfig3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFiltersConfig3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Filter3>))]
public sealed record class Filter3 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Filter3>
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._properties.TryGetValue("property_key", out JsonElement element))
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
            this._properties["property_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("property_value", out JsonElement element))
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
            this._properties["property_value"] = JsonSerializer.SerializeToElement(
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

    public Filter3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Filter3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Tier6>))]
public sealed record class Tier6 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Tier6>
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
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
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
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

    public Tier6(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier6(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier6 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Tier6(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence18Converter))]
public enum Cadence18
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence18Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence18>
{
    public override global::Orb.Models.Subscriptions.Cadence18 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence18.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence18.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence18.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence18.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence18.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence18.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence18)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence18 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence18.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence18.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence18.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence18.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence18.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence18.Custom => "custom",
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
public class ModelType18
{
    public JsonElement Json { get; private init; }

    public ModelType18()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ModelType18(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType18().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType18'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType18>
    {
        public override global::Orb.Models.Subscriptions.ModelType18? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType18 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig18Converter))]
public record class ConversionRateConfig18
{
    public object Value { get; private init; }

    public ConversionRateConfig18(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig18(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig18(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig18 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig18"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig18"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig18"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig18Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig18>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig18? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig18(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig18(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig18 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<TieredWithProration2>))]
public sealed record class TieredWithProration2 : ModelBase, IFromRaw<TieredWithProration2>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence19> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence19>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType19 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType19>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required TieredWithProrationConfig2 TieredWithProrationConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "tiered_with_proration_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_with_proration_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TieredWithProrationConfig2>(
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
            this._properties["tiered_with_proration_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig19? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig19?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public TieredWithProration2()
    {
        this.ModelType = new();
    }

    public TieredWithProration2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProration2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TieredWithProration2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence19Converter))]
public enum Cadence19
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence19Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence19>
{
    public override global::Orb.Models.Subscriptions.Cadence19 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence19.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence19.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence19.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence19.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence19.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence19.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence19)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence19 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence19.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence19.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence19.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence19.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence19.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence19.Custom => "custom",
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
public class ModelType19
{
    public JsonElement Json { get; private init; }

    public ModelType19()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    ModelType19(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType19().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType19'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType19>
    {
        public override global::Orb.Models.Subscriptions.ModelType19? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType19 value,
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
[JsonConverter(typeof(ModelConverter<TieredWithProrationConfig2>))]
public sealed record class TieredWithProrationConfig2
    : ModelBase,
        IFromRaw<TieredWithProrationConfig2>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier with proration
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Tier7> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
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
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
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

    public TieredWithProrationConfig2() { }

    public TieredWithProrationConfig2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfig2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TieredWithProrationConfig2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfig2(List<global::Orb.Models.Subscriptions.Tier7> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Tier7>))]
public sealed record class Tier7 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Tier7>
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
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
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
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
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
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

    public Tier7(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier7(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier7 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig19Converter))]
public record class ConversionRateConfig19
{
    public object Value { get; private init; }

    public ConversionRateConfig19(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig19(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig19(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig19 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig19"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig19"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig19"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig19Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig19>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig19? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig19(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig19(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig19 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholds3>))]
public sealed record class GroupedWithMinMaxThresholds3
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholds3>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence20> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence20>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required GroupedWithMinMaxThresholdsConfig3 GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
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

            return JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConfig3>(
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
            this._properties["grouped_with_min_max_thresholds_config"] =
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType20 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType20>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig20? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig20?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public GroupedWithMinMaxThresholds3()
    {
        this.ModelType = new();
    }

    public GroupedWithMinMaxThresholds3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholds3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence20Converter))]
public enum Cadence20
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence20Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence20>
{
    public override global::Orb.Models.Subscriptions.Cadence20 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence20.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence20.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence20.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence20.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence20.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence20.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence20)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence20 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence20.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence20.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence20.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence20.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence20.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence20.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholdsConfig3>))]
public sealed record class GroupedWithMinMaxThresholdsConfig3
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholdsConfig3>
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
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
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("maximum_charge", out JsonElement element))
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
            this._properties["maximum_charge"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("minimum_charge", out JsonElement element))
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
            this._properties["minimum_charge"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("per_unit_rate", out JsonElement element))
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
            this._properties["per_unit_rate"] = JsonSerializer.SerializeToElement(
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

    public GroupedWithMinMaxThresholdsConfig3() { }

    public GroupedWithMinMaxThresholdsConfig3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholdsConfig3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType20
{
    public JsonElement Json { get; private init; }

    public ModelType20()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ModelType20(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType20().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType20'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType20>
    {
        public override global::Orb.Models.Subscriptions.ModelType20? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType20 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig20Converter))]
public record class ConversionRateConfig20
{
    public object Value { get; private init; }

    public ConversionRateConfig20(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig20(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig20(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig20 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig20"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig20"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig20"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig20Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig20>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig20? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig20(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig20(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig20 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<Percent3>))]
public sealed record class Percent3 : ModelBase, IFromRaw<Percent3>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence21> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence21>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType21 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType21>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// Configuration for percent pricing
    /// </summary>
    public required PercentConfig3 PercentConfig
    {
        get
        {
            if (!this._properties.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PercentConfig3>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentNullException("percent_config")
                );
        }
        init
        {
            this._properties["percent_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig21? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig21?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public Percent3()
    {
        this.ModelType = new();
    }

    public Percent3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Percent3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence21Converter))]
public enum Cadence21
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence21Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence21>
{
    public override global::Orb.Models.Subscriptions.Cadence21 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence21.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence21.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence21.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence21.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence21.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence21.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence21)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence21 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence21.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence21.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence21.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence21.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence21.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence21.Custom => "custom",
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
public class ModelType21
{
    public JsonElement Json { get; private init; }

    public ModelType21()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ModelType21(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType21().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType21'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType21>
    {
        public override global::Orb.Models.Subscriptions.ModelType21? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType21 value,
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
[JsonConverter(typeof(ModelConverter<PercentConfig3>))]
public sealed record class PercentConfig3 : ModelBase, IFromRaw<PercentConfig3>
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._properties.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public PercentConfig3() { }

    public PercentConfig3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PercentConfig3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PercentConfig3(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig21Converter))]
public record class ConversionRateConfig21
{
    public object Value { get; private init; }

    public ConversionRateConfig21(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig21(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig21(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig21 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig21"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig21"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig21"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig21Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig21>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig21? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig21(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig21(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig21 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<EventOutput3>))]
public sealed record class EventOutput3 : ModelBase, IFromRaw<EventOutput3>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence22> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence22>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required EventOutputConfig3 EventOutputConfig
    {
        get
        {
            if (!this._properties.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<EventOutputConfig3>(
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
            this._properties["event_output_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Subscriptions.ModelType22 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType22>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Subscriptions.ConversionRateConfig22? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig22?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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

    public EventOutput3()
    {
        this.ModelType = new();
    }

    public EventOutput3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutput3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence22Converter))]
public enum Cadence22
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence22Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence22>
{
    public override global::Orb.Models.Subscriptions.Cadence22 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence22.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence22.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence22.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence22.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence22.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence22.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence22)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence22 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence22.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence22.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence22.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence22.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence22.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence22.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<EventOutputConfig3>))]
public sealed record class EventOutputConfig3 : ModelBase, IFromRaw<EventOutputConfig3>
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._properties.TryGetValue("unit_rating_key", out JsonElement element))
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
            this._properties["unit_rating_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["default_unit_rate"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
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

    public EventOutputConfig3() { }

    public EventOutputConfig3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutputConfig3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EventOutputConfig3(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType22
{
    public JsonElement Json { get; private init; }

    public ModelType22()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ModelType22(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType22().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Subscriptions.ModelType22'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType22>
    {
        public override global::Orb.Models.Subscriptions.ModelType22? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType22 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig22Converter))]
public record class ConversionRateConfig22
{
    public object Value { get; private init; }

    public ConversionRateConfig22(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig22(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig22(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig22 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig22"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig22"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig22"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig22Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig22>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig22? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig22(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig22(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
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
        global::Orb.Models.Subscriptions.ConversionRateConfig22 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
