using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
/// A subscription represents the purchase of a plan by a customer. The customer is
/// identified by either the `customer_id` or the `external_customer_id`, and exactly
/// one of these fields must be provided.
///
/// <para>By default, subscriptions begin on the day that they're created and renew
/// automatically for each billing cycle at the cadence that's configured in the
/// plan definition.</para>
///
/// <para>The default configuration for subscriptions in Orb is **In-advance billing**
/// and **Beginning of month alignment** (see [Subscription](/core-concepts##subscription)
/// for more details).</para>
///
/// <para>In order to change the alignment behavior, Orb also supports billing subscriptions
/// on the day of the month they are created. If `align_billing_with_subscription_start_date
/// = true` is specified, subscriptions have billing cycles that are aligned with
/// their `start_date`. For example, a subscription that begins on January 15th will
/// have a billing cycle from January 15th to February 15th. Every subsequent billing
/// cycle will continue to start and invoice on the 15th.</para>
///
/// <para>If the "day" value is greater than the number of days in the month, the
/// next billing cycle will start at the end of the month. For example, if the start_date
/// is January 31st, the next billing cycle will start on February 28th.</para>
///
/// <para>If a customer was created with a currency, Orb only allows subscribing
/// the customer to a plan with a matching `invoicing_currency`. If the customer
/// does not have a currency set, on subscription creation, we set the customer's
/// currency to be the `invoicing_currency` of the plan.</para>
///
/// <para>## Customize your customer's subscriptions</para>
///
/// <para>Prices and adjustments in a plan can be added, removed, or replaced for
/// the subscription being created. This is useful when a customer has prices that
/// differ from the default prices for a specific plan.</para>
///
/// <para>&lt;Note&gt; This feature is only available for accounts that have migrated
/// to Subscription Overrides Version 2. You can find your Subscription Overrides
/// Version at the bottom of your [Plans page](https://app.withorb.com/plans) &lt;/Note&gt;</para>
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
/// `end_date`. This is equivalent to creating a price interval with the [add/edit
/// price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).
/// If unspecified, the start or end date of the phase or subscription will be used.</para>
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
/// `end_date`. If unspecified, the start or end date of the phase or subscription
/// will be used.</para>
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
/// <para>&lt;Note&gt; Price overrides are being phased out in favor adding/removing/replacing
/// prices. (See [Customize your customer's subscriptions](/api-reference/subscription/create-subscription)) &lt;/Note&gt;</para>
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
/// <para>### Maximums and Minimums Minimums and maximums, much like price overrides,
/// can be useful when a new customer has negotiated a new or different minimum or
/// maximum spend cap than the default for a given price. If one exists for a price
/// and null is provided for the minimum/maximum override on creation, then there
/// will be no minimum/maximum on the new subscription. If no value is provided, then
/// the default price maximum or minimum is used.</para>
///
/// <para>To add a minimum for a specific price, add `minimum_amount` to the specific
/// price in the `price_overrides` object.</para>
///
/// <para>To add a maximum for a specific price, add `maximum_amount` to the specific
/// price in the `price_overrides` object.</para>
///
/// <para>### Minimum override example</para>
///
/// <para>Price minimum override example:</para>
///
/// <para>```json {   ...   "id": "price_id",   "model_type": "unit",   "unit_config":
/// {     "unit_amount": "0.50"   },   "minimum_amount": "100.00"   ... } ```</para>
///
/// <para>Removing an existing minimum example ```json {   ...   "id": "price_id",
///   "model_type": "unit",   "unit_config": {     "unit_amount": "0.50"   },   "minimum_amount":
/// null   ... } ```</para>
///
/// <para>### Discounts Discounts, like price overrides, can be useful when a new
/// customer has negotiated a new or different discount than the default for a price.
/// If a discount exists for a price and a null discount is provided on creation,
/// then there will be no discount on the new subscription.</para>
///
/// <para>To add a discount for a specific price, add `discount` to the price in
/// the `price_overrides` object. Discount should be a dictionary of the format: ```ts
/// {   "discount_type": "amount" | "percentage" | "usage",   "amount_discount":
/// string,   "percentage_discount": string,   "usage_discount": string } ``` where
/// either `amount_discount`, `percentage_discount`, or `usage_discount` is provided.</para>
///
/// <para>Price discount example ```json {   ...   "id": "price_id",   "model_type":
/// "unit",   "unit_config": {     "unit_amount": "0.50"   },   "discount": {"discount_type":
/// "amount", "amount_discount": "175"}, } ```</para>
///
/// <para>Removing an existing discount example ```json {   "customer_id": "customer_id",
///   "plan_id": "plan_id",   "discount": null,   "price_overrides": [ ... ]   ...
/// } ```</para>
///
/// <para>## Threshold Billing</para>
///
/// <para>Orb supports invoicing for a subscription when a preconfigured usage threshold
/// is hit. To enable threshold billing, pass in an `invoicing_threshold`, which
/// is specified in the subscription's invoicing currency, when creating a subscription.
/// E.g. pass in `10.00` to issue an invoice when usage amounts hit \$10.00 for a
/// subscription that invoices in USD.</para>
///
/// <para>## Limits By default, Orb limits the number of subscriptions per customer
/// to 100.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Additional adjustments to be added to the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<AddAdjustment>? AddAdjustments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AddAdjustment>>(
                "add_adjustments"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AddAdjustment>?>(
                "add_adjustments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Additional prices to be added to the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<AddPrice>? AddPrices
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AddPrice>>("add_prices");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AddPrice>?>(
                "add_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? AlignBillingWithSubscriptionStartDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "align_billing_with_subscription_start_date"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("align_billing_with_subscription_start_date", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("auto_collection");
        }
        init { this._rawBodyData.Set("auto_collection", value); }
    }

    [System::Obsolete("deprecated")]
    public string? AwsRegion
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("aws_region");
        }
        init { this._rawBodyData.Set("aws_region", value); }
    }

    public BillingCycleAnchorConfiguration? BillingCycleAnchorConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingCycleAnchorConfiguration>(
                "billing_cycle_anchor_configuration"
            );
        }
        init { this._rawBodyData.Set("billing_cycle_anchor_configuration", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("coupon_redemption_code");
        }
        init { this._rawBodyData.Set("coupon_redemption_code", value); }
    }

    [System::Obsolete("deprecated")]
    public double? CreditsOverageRate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("credits_overage_rate");
        }
        init { this._rawBodyData.Set("credits_overage_rate", value); }
    }

    /// <summary>
    /// The currency to use for the subscription. If not specified, the invoicing
    /// currency for the plan will be used.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    public string? CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customer_id");
        }
        init { this._rawBodyData.Set("customer_id", value); }
    }

    /// <summary>
    /// Determines the default memo on this subscription's invoices. Note that if
    /// this is not provided, it is determined by the plan configuration.
    /// </summary>
    public string? DefaultInvoiceMemo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("default_invoice_memo");
        }
        init { this._rawBodyData.Set("default_invoice_memo", value); }
    }

    public System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("end_date");
        }
        init { this._rawBodyData.Set("end_date", value); }
    }

    public string? ExternalCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_customer_id");
        }
        init { this._rawBodyData.Set("external_customer_id", value); }
    }

    [System::Obsolete("deprecated")]
    public ApiEnum<string, ExternalMarketplace>? ExternalMarketplace
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExternalMarketplace>>(
                "external_marketplace"
            );
        }
        init { this._rawBodyData.Set("external_marketplace", value); }
    }

    [System::Obsolete("deprecated")]
    public string? ExternalMarketplaceReportingID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_marketplace_reporting_id");
        }
        init { this._rawBodyData.Set("external_marketplace_reporting_id", value); }
    }

    /// <summary>
    /// The external_plan_id of the plan that the given subscription should be switched
    /// to. Note that either this property or `plan_id` must be specified.
    /// </summary>
    public string? ExternalPlanID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_plan_id");
        }
        init { this._rawBodyData.Set("external_plan_id", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("filter");
        }
        init { this._rawBodyData.Set("filter", value); }
    }

    /// <summary>
    /// The phase of the plan to start with
    /// </summary>
    public long? InitialPhaseOrder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("initial_phase_order");
        }
        init { this._rawBodyData.Set("initial_phase_order", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("invoicing_threshold");
        }
        init { this._rawBodyData.Set("invoicing_threshold", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string?>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The name to use for the subscription. If not specified, the plan name will
    /// be used.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("net_terms");
        }
        init { this._rawBodyData.Set("net_terms", value); }
    }

    [System::Obsolete("deprecated")]
    public double? PerCreditOverageAmount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("per_credit_overage_amount");
        }
        init { this._rawBodyData.Set("per_credit_overage_amount", value); }
    }

    /// <summary>
    /// The plan that the given subscription should be switched to. Note that either
    /// this property or `external_plan_id` must be specified.
    /// </summary>
    public string? PlanID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("plan_id");
        }
        init { this._rawBodyData.Set("plan_id", value); }
    }

    /// <summary>
    /// Specifies which version of the plan to subscribe to. If null, the default
    /// version will be used.
    /// </summary>
    public long? PlanVersionNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("plan_version_number");
        }
        init { this._rawBodyData.Set("plan_version_number", value); }
    }

    /// <summary>
    /// Optionally provide a list of overrides for prices on the plan
    /// </summary>
    [System::Obsolete("deprecated")]
    public IReadOnlyList<JsonElement>? PriceOverrides
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<JsonElement>>(
                "price_overrides"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<JsonElement>?>(
                "price_overrides",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be removed from the subscription. (Only available for
    /// accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<RemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<RemoveAdjustment>>(
                "remove_adjustments"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<RemoveAdjustment>?>(
                "remove_adjustments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Plan prices to be removed from the subscription. (Only available for accounts
    /// that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<RemovePrice>? RemovePrices
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<RemovePrice>>(
                "remove_prices"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<RemovePrice>?>(
                "remove_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Plan adjustments to be replaced with additional adjustments on the subscription.
    /// (Only available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<ReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ReplaceAdjustment>>(
                "replace_adjustments"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ReplaceAdjustment>?>(
                "replace_adjustments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Plan prices to be replaced with additional prices on the subscription. (Only
    /// available for accounts that have migrated off of legacy subscription overrides)
    /// </summary>
    public IReadOnlyList<ReplacePrice>? ReplacePrices
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ReplacePrice>>(
                "replace_prices"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ReplacePrice>?>(
                "replace_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public System::DateTimeOffset? StartDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("start_date");
        }
        init { this._rawBodyData.Set("start_date", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("trial_duration_days");
        }
        init { this._rawBodyData.Set("trial_duration_days", value); }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events
    /// associated with its attached customer's customer_id. When usage_customer_ids
    /// is provided, the subscription includes usage events from the specified customers
    /// only. Provided usage_customer_ids must be either the customer for this subscription
    /// itself, or any of that customer's children.
    /// </summary>
    public IReadOnlyList<string>? UsageCustomerIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "usage_customer_ids"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "usage_customer_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public SubscriptionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCreateParams(SubscriptionCreateParams subscriptionCreateParams)
        : base(subscriptionCreateParams)
    {
        this._rawBodyData = new(subscriptionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubscriptionCreateParams FromRawUnchecked(
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/subscriptions")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<AddAdjustment, AddAdjustmentFromRaw>))]
public sealed record class AddAdjustment : JsonModel
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required Adjustment Adjustment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Adjustment>("adjustment");
        }
        init { this._rawData.Set("adjustment", value); }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription.
    /// </summary>
    public System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.EndDate;
        _ = this.PlanPhaseOrder;
        _ = this.StartDate;
    }

    public AddAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddAdjustment(AddAdjustment addAdjustment)
        : base(addAdjustment) { }
#pragma warning restore CS8618

    public AddAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddAdjustmentFromRaw.FromRawUnchecked"/>
    public static AddAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddAdjustment(Adjustment adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}

class AddAdjustmentFromRaw : IFromRawJson<AddAdjustment>
{
    /// <inheritdoc/>
    public AddAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(AdjustmentConverter))]
public record class Adjustment : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
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

    public Adjustment(NewPercentageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewUsageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewAmountDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewMinimum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewMaximum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (NewPercentageDiscount value) =&gt; {...},
    ///     (NewUsageDiscount value) =&gt; {...},
    ///     (NewAmountDiscount value) =&gt; {...},
    ///     (NewMinimum value) =&gt; {...},
    ///     (NewMaximum value) =&gt; {...}
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
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (NewPercentageDiscount value) =&gt; {...},
    ///     (NewUsageDiscount value) =&gt; {...},
    ///     (NewAmountDiscount value) =&gt; {...},
    ///     (NewMinimum value) =&gt; {...},
    ///     (NewMaximum value) =&gt; {...}
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
    }

    public static implicit operator Adjustment(NewPercentageDiscount value) => new(value);

    public static implicit operator Adjustment(NewUsageDiscount value) => new(value);

    public static implicit operator Adjustment(NewAmountDiscount value) => new(value);

    public static implicit operator Adjustment(NewMinimum value) => new(value);

    public static implicit operator Adjustment(NewMaximum value) => new(value);

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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
        this.Switch(
            (newPercentageDiscount) => newPercentageDiscount.Validate(),
            (newUsageDiscount) => newUsageDiscount.Validate(),
            (newAmountDiscount) => newAmountDiscount.Validate(),
            (newMinimum) => newMinimum.Validate(),
            (newMaximum) => newMaximum.Validate()
        );
    }

    public virtual bool Equals(Adjustment? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            NewPercentageDiscount _ => 0,
            NewUsageDiscount _ => 1,
            NewAmountDiscount _ => 2,
            NewMinimum _ => 3,
            NewMaximum _ => 4,
            _ => -1,
        };
    }
}

sealed class AdjustmentConverter : JsonConverter<Adjustment>
{
    public override Adjustment? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Adjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Adjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<AddPrice, AddPriceFromRaw>))]
public sealed record class AddPrice : JsonModel
{
    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewAllocationPrice>("allocation_price");
        }
        init { this._rawData.Set("allocation_price", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DiscountOverride>>("discounts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DiscountOverride>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
    }

    /// <summary>
    /// Override values for parameterized billable metric variables. Keys are parameter
    /// names, values are the override values.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? MetricParameterOverrides
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metric_parameter_overrides"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metric_parameter_overrides",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    /// <summary>
    /// The phase to add this price to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public Price? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Price>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price_id");
        }
        init { this._rawData.Set("price_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
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
        _ = this.MetricParameterOverrides;
        _ = this.MinimumAmount;
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
        _ = this.PriceID;
        _ = this.StartDate;
    }

    public AddPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddPrice(AddPrice addPrice)
        : base(addPrice) { }
#pragma warning restore CS8618

    public AddPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddPriceFromRaw.FromRawUnchecked"/>
    public static AddPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceFromRaw : IFromRawJson<AddPrice>
{
    /// <inheritdoc/>
    public AddPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public record class Price : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
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
                matrixWithThresholdDiscounts: (x) => x.ItemID,
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
                dailyCreditAllowance: (x) => x.ItemID,
                meteredAllowance: (x) => x.ItemID,
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
                matrixWithThresholdDiscounts: (x) => x.Name,
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
                dailyCreditAllowance: (x) => x.Name,
                meteredAllowance: (x) => x.Name,
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
                matrixWithThresholdDiscounts: (x) => x.BillableMetricID,
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
                dailyCreditAllowance: (x) => x.BillableMetricID,
                meteredAllowance: (x) => x.BillableMetricID,
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
                matrixWithThresholdDiscounts: (x) => x.BilledInAdvance,
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
                dailyCreditAllowance: (x) => x.BilledInAdvance,
                meteredAllowance: (x) => x.BilledInAdvance,
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
                matrixWithThresholdDiscounts: (x) => x.BillingCycleConfiguration,
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
                dailyCreditAllowance: (x) => x.BillingCycleConfiguration,
                meteredAllowance: (x) => x.BillingCycleConfiguration,
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
                matrixWithThresholdDiscounts: (x) => x.ConversionRate,
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
                dailyCreditAllowance: (x) => x.ConversionRate,
                meteredAllowance: (x) => x.ConversionRate,
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
                matrixWithThresholdDiscounts: (x) => x.Currency,
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
                dailyCreditAllowance: (x) => x.Currency,
                meteredAllowance: (x) => x.Currency,
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
                matrixWithThresholdDiscounts: (x) => x.DimensionalPriceConfiguration,
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
                dailyCreditAllowance: (x) => x.DimensionalPriceConfiguration,
                meteredAllowance: (x) => x.DimensionalPriceConfiguration,
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
                matrixWithThresholdDiscounts: (x) => x.ExternalPriceID,
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
                dailyCreditAllowance: (x) => x.ExternalPriceID,
                meteredAllowance: (x) => x.ExternalPriceID,
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
                matrixWithThresholdDiscounts: (x) => x.FixedPriceQuantity,
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
                dailyCreditAllowance: (x) => x.FixedPriceQuantity,
                meteredAllowance: (x) => x.FixedPriceQuantity,
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
                matrixWithThresholdDiscounts: (x) => x.InvoiceGroupingKey,
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
                dailyCreditAllowance: (x) => x.InvoiceGroupingKey,
                meteredAllowance: (x) => x.InvoiceGroupingKey,
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
                matrixWithThresholdDiscounts: (x) => x.InvoicingCycleConfiguration,
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
                dailyCreditAllowance: (x) => x.InvoicingCycleConfiguration,
                meteredAllowance: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public string? LicenseTypeID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.LicenseTypeID,
                newSubscriptionTiered: (x) => x.LicenseTypeID,
                newSubscriptionBulk: (x) => x.LicenseTypeID,
                bulkWithFilters: (x) => x.LicenseTypeID,
                newSubscriptionPackage: (x) => x.LicenseTypeID,
                newSubscriptionMatrix: (x) => x.LicenseTypeID,
                newSubscriptionThresholdTotalAmount: (x) => x.LicenseTypeID,
                newSubscriptionTieredPackage: (x) => x.LicenseTypeID,
                newSubscriptionTieredWithMinimum: (x) => x.LicenseTypeID,
                newSubscriptionGroupedTiered: (x) => x.LicenseTypeID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.LicenseTypeID,
                newSubscriptionPackageWithAllocation: (x) => x.LicenseTypeID,
                newSubscriptionUnitWithPercent: (x) => x.LicenseTypeID,
                newSubscriptionMatrixWithAllocation: (x) => x.LicenseTypeID,
                matrixWithThresholdDiscounts: (x) => x.LicenseTypeID,
                tieredWithProration: (x) => x.LicenseTypeID,
                newSubscriptionUnitWithProration: (x) => x.LicenseTypeID,
                newSubscriptionGroupedAllocation: (x) => x.LicenseTypeID,
                newSubscriptionBulkWithProration: (x) => x.LicenseTypeID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.LicenseTypeID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.LicenseTypeID,
                groupedWithMinMaxThresholds: (x) => x.LicenseTypeID,
                newSubscriptionMatrixWithDisplayName: (x) => x.LicenseTypeID,
                newSubscriptionGroupedTieredPackage: (x) => x.LicenseTypeID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.LicenseTypeID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.LicenseTypeID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.LicenseTypeID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.LicenseTypeID,
                cumulativeGroupedAllocation: (x) => x.LicenseTypeID,
                dailyCreditAllowance: (x) => x.LicenseTypeID,
                meteredAllowance: (x) => x.LicenseTypeID,
                newSubscriptionMinimumComposite: (x) => x.LicenseTypeID,
                percent: (x) => x.LicenseTypeID,
                eventOutput: (x) => x.LicenseTypeID
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
                matrixWithThresholdDiscounts: (x) => x.ReferenceID,
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
                dailyCreditAllowance: (x) => x.ReferenceID,
                meteredAllowance: (x) => x.ReferenceID,
                newSubscriptionMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public Price(NewSubscriptionUnitPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(BulkWithFilters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionMatrixPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionThresholdTotalAmountPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionTieredWithMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionGroupedTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionTieredPackageWithMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionPackageWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionUnitWithPercentPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionMatrixWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(MatrixWithThresholdDiscounts value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(TieredWithProration value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionUnitWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionGroupedAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionBulkWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionGroupedWithProratedMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionGroupedWithMeteredMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(GroupedWithMinMaxThresholds value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionMatrixWithDisplayNamePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionGroupedTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionMaxGroupTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Price(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionCumulativeGroupedBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(CumulativeGroupedAllocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(DailyCreditAllowance value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(MeteredAllowance value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewSubscriptionMinimumCompositePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(Percent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(EventOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="BulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `BulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters([NotNullWhen(true)] out BulkWithFilters? value)
    {
        value = this.Value as BulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="MatrixWithThresholdDiscounts"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMatrixWithThresholdDiscounts(out var value)) {
    ///     // `value` is of type `MatrixWithThresholdDiscounts`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMatrixWithThresholdDiscounts(
        [NotNullWhen(true)] out MatrixWithThresholdDiscounts? value
    )
    {
        value = this.Value as MatrixWithThresholdDiscounts;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TieredWithProration"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredWithProration(out var value)) {
    ///     // `value` is of type `TieredWithProration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProration? value)
    {
        value = this.Value as TieredWithProration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="GroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `GroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as GroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="CumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `CumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out CumulativeGroupedAllocation? value
    )
    {
        value = this.Value as CumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DailyCreditAllowance"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDailyCreditAllowance(out var value)) {
    ///     // `value` is of type `DailyCreditAllowance`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDailyCreditAllowance([NotNullWhen(true)] out DailyCreditAllowance? value)
    {
        value = this.Value as DailyCreditAllowance;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MeteredAllowance"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMeteredAllowance(out var value)) {
    ///     // `value` is of type `MeteredAllowance`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMeteredAllowance([NotNullWhen(true)] out MeteredAllowance? value)
    {
        value = this.Value as MeteredAllowance;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="Percent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `Percent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent([NotNullWhen(true)] out Percent? value)
    {
        value = this.Value as Percent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `EventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutput? value)
    {
        value = this.Value as EventOutput;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (NewSubscriptionUnitPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkPrice value) =&gt; {...},
    ///     (BulkWithFilters value) =&gt; {...},
    ///     (NewSubscriptionPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixPrice value) =&gt; {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) =&gt; {...},
    ///     (MatrixWithThresholdDiscounts value) =&gt; {...},
    ///     (TieredWithProration value) =&gt; {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) =&gt; {...},
    ///     (GroupedWithMinMaxThresholds value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) =&gt; {...},
    ///     (CumulativeGroupedAllocation value) =&gt; {...},
    ///     (DailyCreditAllowance value) =&gt; {...},
    ///     (MeteredAllowance value) =&gt; {...},
    ///     (NewSubscriptionMinimumCompositePrice value) =&gt; {...},
    ///     (Percent value) =&gt; {...},
    ///     (EventOutput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<BulkWithFilters> bulkWithFilters,
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
        System::Action<MatrixWithThresholdDiscounts> matrixWithThresholdDiscounts,
        System::Action<TieredWithProration> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<CumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<DailyCreditAllowance> dailyCreditAllowance,
        System::Action<MeteredAllowance> meteredAllowance,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<Percent> percent,
        System::Action<EventOutput> eventOutput
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
            case BulkWithFilters value:
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
            case MatrixWithThresholdDiscounts value:
                matrixWithThresholdDiscounts(value);
                break;
            case TieredWithProration value:
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
            case GroupedWithMinMaxThresholds value:
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
            case CumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case DailyCreditAllowance value:
                dailyCreditAllowance(value);
                break;
            case MeteredAllowance value:
                meteredAllowance(value);
                break;
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case Percent value:
                percent(value);
                break;
            case EventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (NewSubscriptionUnitPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkPrice value) =&gt; {...},
    ///     (BulkWithFilters value) =&gt; {...},
    ///     (NewSubscriptionPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixPrice value) =&gt; {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) =&gt; {...},
    ///     (MatrixWithThresholdDiscounts value) =&gt; {...},
    ///     (TieredWithProration value) =&gt; {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) =&gt; {...},
    ///     (GroupedWithMinMaxThresholds value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) =&gt; {...},
    ///     (CumulativeGroupedAllocation value) =&gt; {...},
    ///     (DailyCreditAllowance value) =&gt; {...},
    ///     (MeteredAllowance value) =&gt; {...},
    ///     (NewSubscriptionMinimumCompositePrice value) =&gt; {...},
    ///     (Percent value) =&gt; {...},
    ///     (EventOutput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<BulkWithFilters, T> bulkWithFilters,
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
        System::Func<MatrixWithThresholdDiscounts, T> matrixWithThresholdDiscounts,
        System::Func<TieredWithProration, T> tieredWithProration,
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
        System::Func<GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
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
        System::Func<CumulativeGroupedAllocation, T> cumulativeGroupedAllocation,
        System::Func<DailyCreditAllowance, T> dailyCreditAllowance,
        System::Func<MeteredAllowance, T> meteredAllowance,
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<Percent, T> percent,
        System::Func<EventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            BulkWithFilters value => bulkWithFilters(value),
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
            MatrixWithThresholdDiscounts value => matrixWithThresholdDiscounts(value),
            TieredWithProration value => tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            GroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(value),
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
            CumulativeGroupedAllocation value => cumulativeGroupedAllocation(value),
            DailyCreditAllowance value => dailyCreditAllowance(value),
            MeteredAllowance value => meteredAllowance(value),
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            Percent value => percent(value),
            EventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price"),
        };
    }

    public static implicit operator Price(NewSubscriptionUnitPrice value) => new(value);

    public static implicit operator Price(NewSubscriptionTieredPrice value) => new(value);

    public static implicit operator Price(NewSubscriptionBulkPrice value) => new(value);

    public static implicit operator Price(BulkWithFilters value) => new(value);

    public static implicit operator Price(NewSubscriptionPackagePrice value) => new(value);

    public static implicit operator Price(NewSubscriptionMatrixPrice value) => new(value);

    public static implicit operator Price(NewSubscriptionThresholdTotalAmountPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionTieredPackagePrice value) => new(value);

    public static implicit operator Price(NewSubscriptionTieredWithMinimumPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionGroupedTieredPrice value) => new(value);

    public static implicit operator Price(NewSubscriptionTieredPackageWithMinimumPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionPackageWithAllocationPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionUnitWithPercentPrice value) => new(value);

    public static implicit operator Price(NewSubscriptionMatrixWithAllocationPrice value) =>
        new(value);

    public static implicit operator Price(MatrixWithThresholdDiscounts value) => new(value);

    public static implicit operator Price(TieredWithProration value) => new(value);

    public static implicit operator Price(NewSubscriptionUnitWithProrationPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionGroupedAllocationPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionBulkWithProrationPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionGroupedWithProratedMinimumPrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionGroupedWithMeteredMinimumPrice value) =>
        new(value);

    public static implicit operator Price(GroupedWithMinMaxThresholds value) => new(value);

    public static implicit operator Price(NewSubscriptionMatrixWithDisplayNamePrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionGroupedTieredPackagePrice value) =>
        new(value);

    public static implicit operator Price(NewSubscriptionMaxGroupTieredPackagePrice value) =>
        new(value);

    public static implicit operator Price(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator Price(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator Price(NewSubscriptionCumulativeGroupedBulkPrice value) =>
        new(value);

    public static implicit operator Price(CumulativeGroupedAllocation value) => new(value);

    public static implicit operator Price(DailyCreditAllowance value) => new(value);

    public static implicit operator Price(MeteredAllowance value) => new(value);

    public static implicit operator Price(NewSubscriptionMinimumCompositePrice value) => new(value);

    public static implicit operator Price(Percent value) => new(value);

    public static implicit operator Price(EventOutput value) => new(value);

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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price");
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
            (matrixWithThresholdDiscounts) => matrixWithThresholdDiscounts.Validate(),
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
            (dailyCreditAllowance) => dailyCreditAllowance.Validate(),
            (meteredAllowance) => meteredAllowance.Validate(),
            (newSubscriptionMinimumComposite) => newSubscriptionMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(Price? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice _ => 0,
            NewSubscriptionTieredPrice _ => 1,
            NewSubscriptionBulkPrice _ => 2,
            BulkWithFilters _ => 3,
            NewSubscriptionPackagePrice _ => 4,
            NewSubscriptionMatrixPrice _ => 5,
            NewSubscriptionThresholdTotalAmountPrice _ => 6,
            NewSubscriptionTieredPackagePrice _ => 7,
            NewSubscriptionTieredWithMinimumPrice _ => 8,
            NewSubscriptionGroupedTieredPrice _ => 9,
            NewSubscriptionTieredPackageWithMinimumPrice _ => 10,
            NewSubscriptionPackageWithAllocationPrice _ => 11,
            NewSubscriptionUnitWithPercentPrice _ => 12,
            NewSubscriptionMatrixWithAllocationPrice _ => 13,
            MatrixWithThresholdDiscounts _ => 14,
            TieredWithProration _ => 15,
            NewSubscriptionUnitWithProrationPrice _ => 16,
            NewSubscriptionGroupedAllocationPrice _ => 17,
            NewSubscriptionBulkWithProrationPrice _ => 18,
            NewSubscriptionGroupedWithProratedMinimumPrice _ => 19,
            NewSubscriptionGroupedWithMeteredMinimumPrice _ => 20,
            GroupedWithMinMaxThresholds _ => 21,
            NewSubscriptionMatrixWithDisplayNamePrice _ => 22,
            NewSubscriptionGroupedTieredPackagePrice _ => 23,
            NewSubscriptionMaxGroupTieredPackagePrice _ => 24,
            NewSubscriptionScalableMatrixWithUnitPricingPrice _ => 25,
            NewSubscriptionScalableMatrixWithTieredPricingPrice _ => 26,
            NewSubscriptionCumulativeGroupedBulkPrice _ => 27,
            CumulativeGroupedAllocation _ => 28,
            DailyCreditAllowance _ => 29,
            MeteredAllowance _ => 30,
            NewSubscriptionMinimumCompositePrice _ => 31,
            Percent _ => 32,
            EventOutput _ => 33,
            _ => -1,
        };
    }
}

sealed class PriceConverter : JsonConverter<Price?>
{
    public override Price? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BulkWithFilters>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix_with_threshold_discounts":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatrixWithThresholdDiscounts>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredWithProration>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CumulativeGroupedAllocation>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "daily_credit_allowance":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DailyCreditAllowance>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "metered_allowance":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MeteredAllowance>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum_composite":
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Percent>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "event_output":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EventOutput>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Price(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Price? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<BulkWithFilters, BulkWithFiltersFromRaw>))]
public sealed record class BulkWithFilters : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required BulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BulkWithFiltersConfig>("bulk_with_filters_config");
        }
        init { this._rawData.Set("bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, Cadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Cadence>>("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversionRateConfig>("conversion_rate_config");
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("bulk_with_filters")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public BulkWithFilters()
    {
        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkWithFilters(BulkWithFilters bulkWithFilters)
        : base(bulkWithFilters) { }
#pragma warning restore CS8618

    public BulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static BulkWithFilters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersFromRaw : IFromRawJson<BulkWithFilters>
{
    /// <inheritdoc/>
    public BulkWithFilters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BulkWithFiltersConfig, BulkWithFiltersConfigFromRaw>))]
public sealed record class BulkWithFiltersConfig : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<Filter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Filter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Filter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<Tier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Tier>>("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Tier>>(
                "tiers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public BulkWithFiltersConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkWithFiltersConfig(BulkWithFiltersConfig bulkWithFiltersConfig)
        : base(bulkWithFiltersConfig) { }
#pragma warning restore CS8618

    public BulkWithFiltersConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersConfigFromRaw : IFromRawJson<BulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_key");
        }
        init { this._rawData.Set("property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_value");
        }
        init { this._rawData.Set("property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter(Filter filter)
        : base(filter) { }
#pragma warning restore CS8618

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tier, TierFromRaw>))]
public sealed record class Tier : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tier(Tier tier)
        : base(tier) { }
#pragma warning restore CS8618

    public Tier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierFromRaw.FromRawUnchecked"/>
    public static Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class TierFromRaw : IFromRawJson<Tier>
{
    /// <inheritdoc/>
    public Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tier.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CadenceConverter : JsonConverter<Cadence>
{
    public override Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => Cadence.Annual,
            "semi_annual" => Cadence.SemiAnnual,
            "monthly" => Cadence.Monthly,
            "quarterly" => Cadence.Quarterly,
            "one_time" => Cadence.OneTime,
            "custom" => Cadence.Custom,
            _ => (Cadence)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cadence value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence.Annual => "annual",
                Cadence.SemiAnnual => "semi_annual",
                Cadence.Monthly => "monthly",
                Cadence.Quarterly => "quarterly",
                Cadence.OneTime => "one_time",
                Cadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ConversionRateConfigConverter))]
public record class ConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ConversionRateConfig(SharedUnitConversionRateConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConversionRateConfig(SharedTieredConversionRateConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ConversionRateConfig"
            ),
        };
    }

    public static implicit operator ConversionRateConfig(SharedUnitConversionRateConfig value) =>
        new(value);

    public static implicit operator ConversionRateConfig(SharedTieredConversionRateConfig value) =>
        new(value);

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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ConversionRateConfigConverter : JsonConverter<ConversionRateConfig>
{
    public override ConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<MatrixWithThresholdDiscounts, MatrixWithThresholdDiscountsFromRaw>)
)]
public sealed record class MatrixWithThresholdDiscounts : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, MatrixWithThresholdDiscountsCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MatrixWithThresholdDiscountsCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// Configuration for matrix_with_threshold_discounts pricing
    /// </summary>
    public required MatrixWithThresholdDiscountsConfig MatrixWithThresholdDiscountsConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MatrixWithThresholdDiscountsConfig>(
                "matrix_with_threshold_discounts_config"
            );
        }
        init { this._rawData.Set("matrix_with_threshold_discounts_config", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public MatrixWithThresholdDiscountsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MatrixWithThresholdDiscountsConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.MatrixWithThresholdDiscountsConfig.Validate();
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("matrix_with_threshold_discounts")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public MatrixWithThresholdDiscounts()
    {
        this.ModelType = JsonSerializer.SerializeToElement("matrix_with_threshold_discounts");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatrixWithThresholdDiscounts(MatrixWithThresholdDiscounts matrixWithThresholdDiscounts)
        : base(matrixWithThresholdDiscounts) { }
#pragma warning restore CS8618

    public MatrixWithThresholdDiscounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("matrix_with_threshold_discounts");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithThresholdDiscounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatrixWithThresholdDiscountsFromRaw.FromRawUnchecked"/>
    public static MatrixWithThresholdDiscounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixWithThresholdDiscountsFromRaw : IFromRawJson<MatrixWithThresholdDiscounts>
{
    /// <inheritdoc/>
    public MatrixWithThresholdDiscounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatrixWithThresholdDiscounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(MatrixWithThresholdDiscountsCadenceConverter))]
public enum MatrixWithThresholdDiscountsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class MatrixWithThresholdDiscountsCadenceConverter
    : JsonConverter<MatrixWithThresholdDiscountsCadence>
{
    public override MatrixWithThresholdDiscountsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => MatrixWithThresholdDiscountsCadence.Annual,
            "semi_annual" => MatrixWithThresholdDiscountsCadence.SemiAnnual,
            "monthly" => MatrixWithThresholdDiscountsCadence.Monthly,
            "quarterly" => MatrixWithThresholdDiscountsCadence.Quarterly,
            "one_time" => MatrixWithThresholdDiscountsCadence.OneTime,
            "custom" => MatrixWithThresholdDiscountsCadence.Custom,
            _ => (MatrixWithThresholdDiscountsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatrixWithThresholdDiscountsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatrixWithThresholdDiscountsCadence.Annual => "annual",
                MatrixWithThresholdDiscountsCadence.SemiAnnual => "semi_annual",
                MatrixWithThresholdDiscountsCadence.Monthly => "monthly",
                MatrixWithThresholdDiscountsCadence.Quarterly => "quarterly",
                MatrixWithThresholdDiscountsCadence.OneTime => "one_time",
                MatrixWithThresholdDiscountsCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for matrix_with_threshold_discounts pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MatrixWithThresholdDiscountsConfig,
        MatrixWithThresholdDiscountsConfigFromRaw
    >)
)]
public sealed record class MatrixWithThresholdDiscountsConfig : JsonModel
{
    /// <summary>
    /// Unit price used for usage that does not match any defined matrix cell.
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("default_unit_amount");
        }
        init { this._rawData.Set("default_unit_amount", value); }
    }

    /// <summary>
    /// First matrix dimension key.
    /// </summary>
    public required string FirstDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_dimension");
        }
        init { this._rawData.Set("first_dimension", value); }
    }

    /// <summary>
    /// Per-cell unit prices.
    /// </summary>
    public required IReadOnlyList<MatrixValue> MatrixValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MatrixValue>>("matrix_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MatrixValue>>(
                "matrix_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional second matrix dimension key.
    /// </summary>
    public string? SecondDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("second_dimension");
        }
        init { this._rawData.Set("second_dimension", value); }
    }

    public IReadOnlyList<ThresholdDiscountGroup>? ThresholdDiscountGroups
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ThresholdDiscountGroup>>(
                "threshold_discount_groups"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ThresholdDiscountGroup>?>(
                "threshold_discount_groups",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DefaultUnitAmount;
        _ = this.FirstDimension;
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
        _ = this.SecondDimension;
        foreach (var item in this.ThresholdDiscountGroups ?? [])
        {
            item.Validate();
        }
    }

    public MatrixWithThresholdDiscountsConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatrixWithThresholdDiscountsConfig(
        MatrixWithThresholdDiscountsConfig matrixWithThresholdDiscountsConfig
    )
        : base(matrixWithThresholdDiscountsConfig) { }
#pragma warning restore CS8618

    public MatrixWithThresholdDiscountsConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithThresholdDiscountsConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatrixWithThresholdDiscountsConfigFromRaw.FromRawUnchecked"/>
    public static MatrixWithThresholdDiscountsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixWithThresholdDiscountsConfigFromRaw : IFromRawJson<MatrixWithThresholdDiscountsConfig>
{
    /// <inheritdoc/>
    public MatrixWithThresholdDiscountsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatrixWithThresholdDiscountsConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MatrixValue, MatrixValueFromRaw>))]
public sealed record class MatrixValue : JsonModel
{
    public required string FirstDimensionValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_dimension_value");
        }
        init { this._rawData.Set("first_dimension_value", value); }
    }

    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    public string? SecondDimensionValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("second_dimension_value");
        }
        init { this._rawData.Set("second_dimension_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstDimensionValue;
        _ = this.UnitAmount;
        _ = this.SecondDimensionValue;
    }

    public MatrixValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatrixValue(MatrixValue matrixValue)
        : base(matrixValue) { }
#pragma warning restore CS8618

    public MatrixValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatrixValueFromRaw.FromRawUnchecked"/>
    public static MatrixValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixValueFromRaw : IFromRawJson<MatrixValue>
{
    /// <inheritdoc/>
    public MatrixValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatrixValue.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ThresholdDiscountGroup, ThresholdDiscountGroupFromRaw>))]
public sealed record class ThresholdDiscountGroup : JsonModel
{
    /// <summary>
    /// Discount rate applied to spend above the threshold.
    /// </summary>
    public required string AboveThresholdDiscountPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("above_threshold_discount_percentage");
        }
        init { this._rawData.Set("above_threshold_discount_percentage", value); }
    }

    /// <summary>
    /// Discount rate applied to spend at or below the threshold. Set to 0 for no
    /// baseline discount.
    /// </summary>
    public required string BelowThresholdDiscountPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("below_threshold_discount_percentage");
        }
        init { this._rawData.Set("below_threshold_discount_percentage", value); }
    }

    /// <summary>
    /// Semicolon-separated list of matrix cell coordinates targeted by this group.
    /// Each coordinate is `first,second` when the matrix has two dimensions, or just
    /// `first` for a single-dimension matrix. Example: `blue,circle;green,triangle`.
    /// </summary>
    public required string CellCoordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cell_coordinates");
        }
        init { this._rawData.Set("cell_coordinates", value); }
    }

    public required string ThresholdAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("threshold_amount");
        }
        init { this._rawData.Set("threshold_amount", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AboveThresholdDiscountPercentage;
        _ = this.BelowThresholdDiscountPercentage;
        _ = this.CellCoordinates;
        _ = this.ThresholdAmount;
        _ = this.Description;
    }

    public ThresholdDiscountGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThresholdDiscountGroup(ThresholdDiscountGroup thresholdDiscountGroup)
        : base(thresholdDiscountGroup) { }
#pragma warning restore CS8618

    public ThresholdDiscountGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdDiscountGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThresholdDiscountGroupFromRaw.FromRawUnchecked"/>
    public static ThresholdDiscountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThresholdDiscountGroupFromRaw : IFromRawJson<ThresholdDiscountGroup>
{
    /// <inheritdoc/>
    public ThresholdDiscountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThresholdDiscountGroup.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MatrixWithThresholdDiscountsConversionRateConfigConverter))]
public record class MatrixWithThresholdDiscountsConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MatrixWithThresholdDiscountsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public MatrixWithThresholdDiscountsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public MatrixWithThresholdDiscountsConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of MatrixWithThresholdDiscountsConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of MatrixWithThresholdDiscountsConversionRateConfig"
            ),
        };
    }

    public static implicit operator MatrixWithThresholdDiscountsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator MatrixWithThresholdDiscountsConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of MatrixWithThresholdDiscountsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(MatrixWithThresholdDiscountsConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class MatrixWithThresholdDiscountsConversionRateConfigConverter
    : JsonConverter<MatrixWithThresholdDiscountsConversionRateConfig>
{
    public override MatrixWithThresholdDiscountsConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new MatrixWithThresholdDiscountsConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatrixWithThresholdDiscountsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<TieredWithProration, TieredWithProrationFromRaw>))]
public sealed record class TieredWithProration : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, TieredWithProrationCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TieredWithProrationCadence>>(
                "cadence"
            );
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required TieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TieredWithProrationConfig>(
                "tiered_with_proration_config"
            );
        }
        init { this._rawData.Set("tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public TieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TieredWithProrationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("tiered_with_proration")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public TieredWithProration()
    {
        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TieredWithProration(TieredWithProration tieredWithProration)
        : base(tieredWithProration) { }
#pragma warning restore CS8618

    public TieredWithProration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TieredWithProrationFromRaw.FromRawUnchecked"/>
    public static TieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredWithProrationFromRaw : IFromRawJson<TieredWithProration>
{
    /// <inheritdoc/>
    public TieredWithProration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TieredWithProration.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(TieredWithProrationCadenceConverter))]
public enum TieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class TieredWithProrationCadenceConverter : JsonConverter<TieredWithProrationCadence>
{
    public override TieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => TieredWithProrationCadence.Annual,
            "semi_annual" => TieredWithProrationCadence.SemiAnnual,
            "monthly" => TieredWithProrationCadence.Monthly,
            "quarterly" => TieredWithProrationCadence.Quarterly,
            "one_time" => TieredWithProrationCadence.OneTime,
            "custom" => TieredWithProrationCadence.Custom,
            _ => (TieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TieredWithProrationCadence.Annual => "annual",
                TieredWithProrationCadence.SemiAnnual => "semi_annual",
                TieredWithProrationCadence.Monthly => "monthly",
                TieredWithProrationCadence.Quarterly => "quarterly",
                TieredWithProrationCadence.OneTime => "one_time",
                TieredWithProrationCadence.Custom => "custom",
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
    typeof(JsonModelConverter<TieredWithProrationConfig, TieredWithProrationConfigFromRaw>)
)]
public sealed record class TieredWithProrationConfig : JsonModel
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<TieredWithProrationConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TieredWithProrationConfigTier>>(
                "tiers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TieredWithProrationConfigTier>>(
                "tiers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public TieredWithProrationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TieredWithProrationConfig(TieredWithProrationConfig tieredWithProrationConfig)
        : base(tieredWithProrationConfig) { }
#pragma warning restore CS8618

    public TieredWithProrationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TieredWithProrationConfigFromRaw.FromRawUnchecked"/>
    public static TieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfig(IReadOnlyList<TieredWithProrationConfigTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class TieredWithProrationConfigFromRaw : IFromRawJson<TieredWithProrationConfig>
{
    /// <inheritdoc/>
    public TieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TieredWithProrationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TieredWithProrationConfigTier, TieredWithProrationConfigTierFromRaw>)
)]
public sealed record class TieredWithProrationConfigTier : JsonModel
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public TieredWithProrationConfigTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TieredWithProrationConfigTier(
        TieredWithProrationConfigTier tieredWithProrationConfigTier
    )
        : base(tieredWithProrationConfigTier) { }
#pragma warning restore CS8618

    public TieredWithProrationConfigTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfigTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TieredWithProrationConfigTierFromRaw.FromRawUnchecked"/>
    public static TieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredWithProrationConfigTierFromRaw : IFromRawJson<TieredWithProrationConfigTier>
{
    /// <inheritdoc/>
    public TieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TieredWithProrationConfigTier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TieredWithProrationConversionRateConfigConverter))]
public record class TieredWithProrationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TieredWithProrationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of TieredWithProrationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of TieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator TieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator TieredWithProrationConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of TieredWithProrationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(TieredWithProrationConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class TieredWithProrationConversionRateConfigConverter
    : JsonConverter<TieredWithProrationConversionRateConfig>
{
    public override TieredWithProrationConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new TieredWithProrationConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<GroupedWithMinMaxThresholds, GroupedWithMinMaxThresholdsFromRaw>)
)]
public sealed record class GroupedWithMinMaxThresholds : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, GroupedWithMinMaxThresholdsCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, GroupedWithMinMaxThresholdsCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required GroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GroupedWithMinMaxThresholdsConfig>(
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { this._rawData.Set("grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public GroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GroupedWithMinMaxThresholdsConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public GroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupedWithMinMaxThresholds(GroupedWithMinMaxThresholds groupedWithMinMaxThresholds)
        : base(groupedWithMinMaxThresholds) { }
#pragma warning restore CS8618

    public GroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsFromRaw : IFromRawJson<GroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(GroupedWithMinMaxThresholdsCadenceConverter))]
public enum GroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class GroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<GroupedWithMinMaxThresholdsCadence>
{
    public override GroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => GroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => GroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => GroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => GroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => GroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => GroupedWithMinMaxThresholdsCadence.Custom,
            _ => (GroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GroupedWithMinMaxThresholdsCadence.Annual => "annual",
                GroupedWithMinMaxThresholdsCadence.SemiAnnual => "semi_annual",
                GroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                GroupedWithMinMaxThresholdsCadence.Quarterly => "quarterly",
                GroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                GroupedWithMinMaxThresholdsCadence.Custom => "custom",
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
        GroupedWithMinMaxThresholdsConfig,
        GroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class GroupedWithMinMaxThresholdsConfig : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("maximum_charge");
        }
        init { this._rawData.Set("maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum_charge");
        }
        init { this._rawData.Set("minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("per_unit_rate");
        }
        init { this._rawData.Set("per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public GroupedWithMinMaxThresholdsConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupedWithMinMaxThresholdsConfig(
        GroupedWithMinMaxThresholdsConfig groupedWithMinMaxThresholdsConfig
    )
        : base(groupedWithMinMaxThresholdsConfig) { }
#pragma warning restore CS8618

    public GroupedWithMinMaxThresholdsConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsConfigFromRaw : IFromRawJson<GroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedWithMinMaxThresholdsConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(GroupedWithMinMaxThresholdsConversionRateConfigConverter))]
public record class GroupedWithMinMaxThresholdsConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator GroupedWithMinMaxThresholdsConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(GroupedWithMinMaxThresholdsConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class GroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<GroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override GroupedWithMinMaxThresholdsConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new GroupedWithMinMaxThresholdsConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        GroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<CumulativeGroupedAllocation, CumulativeGroupedAllocationFromRaw>)
)]
public sealed record class CumulativeGroupedAllocation : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, CumulativeGroupedAllocationCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CumulativeGroupedAllocationCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required CumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CumulativeGroupedAllocationConfig>(
                "cumulative_grouped_allocation_config"
            );
        }
        init { this._rawData.Set("cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public CumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CumulativeGroupedAllocationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("cumulative_grouped_allocation")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public CumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CumulativeGroupedAllocation(CumulativeGroupedAllocation cumulativeGroupedAllocation)
        : base(cumulativeGroupedAllocation) { }
#pragma warning restore CS8618

    public CumulativeGroupedAllocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationFromRaw : IFromRawJson<CumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(CumulativeGroupedAllocationCadenceConverter))]
public enum CumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CumulativeGroupedAllocationCadenceConverter
    : JsonConverter<CumulativeGroupedAllocationCadence>
{
    public override CumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => CumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => CumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => CumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => CumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => CumulativeGroupedAllocationCadence.OneTime,
            "custom" => CumulativeGroupedAllocationCadence.Custom,
            _ => (CumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CumulativeGroupedAllocationCadence.Annual => "annual",
                CumulativeGroupedAllocationCadence.SemiAnnual => "semi_annual",
                CumulativeGroupedAllocationCadence.Monthly => "monthly",
                CumulativeGroupedAllocationCadence.Quarterly => "quarterly",
                CumulativeGroupedAllocationCadence.OneTime => "one_time",
                CumulativeGroupedAllocationCadence.Custom => "custom",
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
        CumulativeGroupedAllocationConfig,
        CumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class CumulativeGroupedAllocationConfig : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cumulative_allocation");
        }
        init { this._rawData.Set("cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_allocation");
        }
        init { this._rawData.Set("group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public CumulativeGroupedAllocationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CumulativeGroupedAllocationConfig(
        CumulativeGroupedAllocationConfig cumulativeGroupedAllocationConfig
    )
        : base(cumulativeGroupedAllocationConfig) { }
#pragma warning restore CS8618

    public CumulativeGroupedAllocationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationConfigFromRaw : IFromRawJson<CumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CumulativeGroupedAllocationConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CumulativeGroupedAllocationConversionRateConfigConverter))]
public record class CumulativeGroupedAllocationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CumulativeGroupedAllocationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator CumulativeGroupedAllocationConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(CumulativeGroupedAllocationConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class CumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<CumulativeGroupedAllocationConversionRateConfig>
{
    public override CumulativeGroupedAllocationConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new CumulativeGroupedAllocationConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<DailyCreditAllowance, DailyCreditAllowanceFromRaw>))]
public sealed record class DailyCreditAllowance : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, DailyCreditAllowanceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DailyCreditAllowanceCadence>>(
                "cadence"
            );
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for daily_credit_allowance pricing
    /// </summary>
    public required DailyCreditAllowanceConfig DailyCreditAllowanceConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DailyCreditAllowanceConfig>(
                "daily_credit_allowance_config"
            );
        }
        init { this._rawData.Set("daily_credit_allowance_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public DailyCreditAllowanceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DailyCreditAllowanceConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.DailyCreditAllowanceConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("daily_credit_allowance")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public DailyCreditAllowance()
    {
        this.ModelType = JsonSerializer.SerializeToElement("daily_credit_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DailyCreditAllowance(DailyCreditAllowance dailyCreditAllowance)
        : base(dailyCreditAllowance) { }
#pragma warning restore CS8618

    public DailyCreditAllowance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("daily_credit_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DailyCreditAllowance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DailyCreditAllowanceFromRaw.FromRawUnchecked"/>
    public static DailyCreditAllowance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DailyCreditAllowanceFromRaw : IFromRawJson<DailyCreditAllowance>
{
    /// <inheritdoc/>
    public DailyCreditAllowance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DailyCreditAllowance.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(DailyCreditAllowanceCadenceConverter))]
public enum DailyCreditAllowanceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class DailyCreditAllowanceCadenceConverter : JsonConverter<DailyCreditAllowanceCadence>
{
    public override DailyCreditAllowanceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => DailyCreditAllowanceCadence.Annual,
            "semi_annual" => DailyCreditAllowanceCadence.SemiAnnual,
            "monthly" => DailyCreditAllowanceCadence.Monthly,
            "quarterly" => DailyCreditAllowanceCadence.Quarterly,
            "one_time" => DailyCreditAllowanceCadence.OneTime,
            "custom" => DailyCreditAllowanceCadence.Custom,
            _ => (DailyCreditAllowanceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DailyCreditAllowanceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DailyCreditAllowanceCadence.Annual => "annual",
                DailyCreditAllowanceCadence.SemiAnnual => "semi_annual",
                DailyCreditAllowanceCadence.Monthly => "monthly",
                DailyCreditAllowanceCadence.Quarterly => "quarterly",
                DailyCreditAllowanceCadence.OneTime => "one_time",
                DailyCreditAllowanceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for daily_credit_allowance pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DailyCreditAllowanceConfig, DailyCreditAllowanceConfigFromRaw>)
)]
public sealed record class DailyCreditAllowanceConfig : JsonModel
{
    /// <summary>
    /// Credits granted per day. Lose-it-or-use-it; does not roll over.
    /// </summary>
    public required string DailyAllowance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("daily_allowance");
        }
        init { this._rawData.Set("daily_allowance", value); }
    }

    /// <summary>
    /// Default per-unit credit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("default_unit_amount");
        }
        init { this._rawData.Set("default_unit_amount", value); }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required IReadOnlyList<string?> Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("dimensions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "dimensions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Event property whose value identifies the day bucket the event belongs to
    /// (e.g. 'event_day' set to an ISO date string in the customer's timezone).
    /// The allowance resets per distinct value of this property.
    /// </summary>
    public required string EventDayProperty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_day_property");
        }
        init { this._rawData.Set("event_day_property", value); }
    }

    /// <summary>
    /// Per-dimension credit rates
    /// </summary>
    public required IReadOnlyList<DailyCreditAllowanceConfigMatrixValue> MatrixValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<DailyCreditAllowanceConfigMatrixValue>
            >("matrix_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DailyCreditAllowanceConfigMatrixValue>>(
                "matrix_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DailyAllowance;
        _ = this.DefaultUnitAmount;
        _ = this.Dimensions;
        _ = this.EventDayProperty;
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
    }

    public DailyCreditAllowanceConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DailyCreditAllowanceConfig(DailyCreditAllowanceConfig dailyCreditAllowanceConfig)
        : base(dailyCreditAllowanceConfig) { }
#pragma warning restore CS8618

    public DailyCreditAllowanceConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DailyCreditAllowanceConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DailyCreditAllowanceConfigFromRaw.FromRawUnchecked"/>
    public static DailyCreditAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DailyCreditAllowanceConfigFromRaw : IFromRawJson<DailyCreditAllowanceConfig>
{
    /// <inheritdoc/>
    public DailyCreditAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DailyCreditAllowanceConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-dimension credit price for the daily credit allowance model.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DailyCreditAllowanceConfigMatrixValue,
        DailyCreditAllowanceConfigMatrixValueFromRaw
    >)
)]
public sealed record class DailyCreditAllowanceConfigMatrixValue : JsonModel
{
    /// <summary>
    /// One or two matrix keys to filter usage to this value by. For example, ["model"]
    /// could be used to apply a different credit rate to each AI model.
    /// </summary>
    public required IReadOnlyList<string?> DimensionValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("dimension_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "dimension_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Credits charged per unit of usage matching the specified dimension_values
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.UnitAmount;
    }

    public DailyCreditAllowanceConfigMatrixValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DailyCreditAllowanceConfigMatrixValue(
        DailyCreditAllowanceConfigMatrixValue dailyCreditAllowanceConfigMatrixValue
    )
        : base(dailyCreditAllowanceConfigMatrixValue) { }
#pragma warning restore CS8618

    public DailyCreditAllowanceConfigMatrixValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DailyCreditAllowanceConfigMatrixValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DailyCreditAllowanceConfigMatrixValueFromRaw.FromRawUnchecked"/>
    public static DailyCreditAllowanceConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DailyCreditAllowanceConfigMatrixValueFromRaw
    : IFromRawJson<DailyCreditAllowanceConfigMatrixValue>
{
    /// <inheritdoc/>
    public DailyCreditAllowanceConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DailyCreditAllowanceConfigMatrixValue.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DailyCreditAllowanceConversionRateConfigConverter))]
public record class DailyCreditAllowanceConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DailyCreditAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DailyCreditAllowanceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DailyCreditAllowanceConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of DailyCreditAllowanceConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of DailyCreditAllowanceConversionRateConfig"
            ),
        };
    }

    public static implicit operator DailyCreditAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator DailyCreditAllowanceConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of DailyCreditAllowanceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(DailyCreditAllowanceConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class DailyCreditAllowanceConversionRateConfigConverter
    : JsonConverter<DailyCreditAllowanceConversionRateConfig>
{
    public override DailyCreditAllowanceConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new DailyCreditAllowanceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        DailyCreditAllowanceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<MeteredAllowance, MeteredAllowanceFromRaw>))]
public sealed record class MeteredAllowance : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, MeteredAllowanceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MeteredAllowanceCadence>>(
                "cadence"
            );
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// Configuration for metered_allowance pricing
    /// </summary>
    public required MeteredAllowanceConfig MeteredAllowanceConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MeteredAllowanceConfig>(
                "metered_allowance_config"
            );
        }
        init { this._rawData.Set("metered_allowance_config", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public MeteredAllowanceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MeteredAllowanceConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.MeteredAllowanceConfig.Validate();
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("metered_allowance")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public MeteredAllowance()
    {
        this.ModelType = JsonSerializer.SerializeToElement("metered_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeteredAllowance(MeteredAllowance meteredAllowance)
        : base(meteredAllowance) { }
#pragma warning restore CS8618

    public MeteredAllowance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("metered_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeteredAllowance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeteredAllowanceFromRaw.FromRawUnchecked"/>
    public static MeteredAllowance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeteredAllowanceFromRaw : IFromRawJson<MeteredAllowance>
{
    /// <inheritdoc/>
    public MeteredAllowance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeteredAllowance.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(MeteredAllowanceCadenceConverter))]
public enum MeteredAllowanceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class MeteredAllowanceCadenceConverter : JsonConverter<MeteredAllowanceCadence>
{
    public override MeteredAllowanceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => MeteredAllowanceCadence.Annual,
            "semi_annual" => MeteredAllowanceCadence.SemiAnnual,
            "monthly" => MeteredAllowanceCadence.Monthly,
            "quarterly" => MeteredAllowanceCadence.Quarterly,
            "one_time" => MeteredAllowanceCadence.OneTime,
            "custom" => MeteredAllowanceCadence.Custom,
            _ => (MeteredAllowanceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeteredAllowanceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeteredAllowanceCadence.Annual => "annual",
                MeteredAllowanceCadence.SemiAnnual => "semi_annual",
                MeteredAllowanceCadence.Monthly => "monthly",
                MeteredAllowanceCadence.Quarterly => "quarterly",
                MeteredAllowanceCadence.OneTime => "one_time",
                MeteredAllowanceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for metered_allowance pricing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeteredAllowanceConfig, MeteredAllowanceConfigFromRaw>))]
public sealed record class MeteredAllowanceConfig : JsonModel
{
    /// <summary>
    /// The grouping_key value whose summed quantity represents the allowance for
    /// this period (e.g. 'storage_snapshot' emitting 3 × avg storage). Capped at
    /// consumption — credit can never exceed actual usage.
    /// </summary>
    public required string AllowanceGroupingValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("allowance_grouping_value");
        }
        init { this._rawData.Set("allowance_grouping_value", value); }
    }

    /// <summary>
    /// The grouping_key value whose summed quantity represents consumption (e.g.
    /// 'download'). Charged at unit_amount.
    /// </summary>
    public required string ConsumptionGroupingValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("consumption_grouping_value");
        }
        init { this._rawData.Set("consumption_grouping_value", value); }
    }

    /// <summary>
    /// Event property used to partition the metric into consumption and allowance
    /// quantities (e.g. 'event_name'). The metric is queried with this key and the
    /// two values below select which partition is which.
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// Per-unit price applied to gross consumption and to the allowance credit.
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// Sub-line label for the credit row (e.g. 'Up to 3x free egress').
    /// </summary>
    public string? AllowanceDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("allowance_display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowance_display_name", value);
        }
    }

    /// <summary>
    /// Sub-line label for the gross consumption row (e.g. 'bytes gotten').
    /// </summary>
    public string? ConsumptionDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("consumption_display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumption_display_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowanceGroupingValue;
        _ = this.ConsumptionGroupingValue;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
        _ = this.AllowanceDisplayName;
        _ = this.ConsumptionDisplayName;
    }

    public MeteredAllowanceConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeteredAllowanceConfig(MeteredAllowanceConfig meteredAllowanceConfig)
        : base(meteredAllowanceConfig) { }
#pragma warning restore CS8618

    public MeteredAllowanceConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeteredAllowanceConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeteredAllowanceConfigFromRaw.FromRawUnchecked"/>
    public static MeteredAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeteredAllowanceConfigFromRaw : IFromRawJson<MeteredAllowanceConfig>
{
    /// <inheritdoc/>
    public MeteredAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MeteredAllowanceConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MeteredAllowanceConversionRateConfigConverter))]
public record class MeteredAllowanceConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MeteredAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public MeteredAllowanceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public MeteredAllowanceConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of MeteredAllowanceConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of MeteredAllowanceConversionRateConfig"
            ),
        };
    }

    public static implicit operator MeteredAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator MeteredAllowanceConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of MeteredAllowanceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(MeteredAllowanceConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class MeteredAllowanceConversionRateConfigConverter
    : JsonConverter<MeteredAllowanceConversionRateConfig>
{
    public override MeteredAllowanceConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new MeteredAllowanceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeteredAllowanceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Percent, PercentFromRaw>))]
public sealed record class Percent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PercentCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PercentCadence>>("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required PercentConfig PercentConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PercentConfig>("percent_config");
        }
        init { this._rawData.Set("percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PercentConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (!JsonElement.DeepEquals(this.ModelType, JsonSerializer.SerializeToElement("percent")))
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public Percent()
    {
        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Percent(Percent percent)
        : base(percent) { }
#pragma warning restore CS8618

    public Percent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentFromRaw.FromRawUnchecked"/>
    public static Percent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentFromRaw : IFromRawJson<Percent>
{
    /// <inheritdoc/>
    public Percent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Percent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PercentCadenceConverter))]
public enum PercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PercentCadenceConverter : JsonConverter<PercentCadence>
{
    public override PercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PercentCadence.Annual,
            "semi_annual" => PercentCadence.SemiAnnual,
            "monthly" => PercentCadence.Monthly,
            "quarterly" => PercentCadence.Quarterly,
            "one_time" => PercentCadence.OneTime,
            "custom" => PercentCadence.Custom,
            _ => (PercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentCadence.Annual => "annual",
                PercentCadence.SemiAnnual => "semi_annual",
                PercentCadence.Monthly => "monthly",
                PercentCadence.Quarterly => "quarterly",
                PercentCadence.OneTime => "one_time",
                PercentCadence.Custom => "custom",
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
[JsonConverter(typeof(JsonModelConverter<PercentConfig, PercentConfigFromRaw>))]
public sealed record class PercentConfig : JsonModel
{
    /// <summary>
    /// Fraction of the component subtotals to charge (0 &lt; percent &lt;= 1).
    /// </summary>
    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    /// <summary>
    /// Maximum amount to charge. If unset, the fee has no upper bound.
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
    }

    /// <summary>
    /// Minimum amount to charge. If unset, the fee is bounded below by 0.
    /// </summary>
    public string? MinimumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    /// <summary>
    /// If true, the minimum_amount is prorated based on the service period. The
    /// maximum_amount is an absolute cap (never prorated), and the percent applied
    /// to upstream subtotals is never prorated either.
    /// </summary>
    public bool? Prorated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prorated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prorated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
        _ = this.MaximumAmount;
        _ = this.MinimumAmount;
        _ = this.Prorated;
    }

    public PercentConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PercentConfig(PercentConfig percentConfig)
        : base(percentConfig) { }
#pragma warning restore CS8618

    public PercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentConfigFromRaw.FromRawUnchecked"/>
    public static PercentConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class PercentConfigFromRaw : IFromRawJson<PercentConfig>
{
    /// <inheritdoc/>
    public PercentConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PercentConversionRateConfigConverter))]
public record class PercentConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public PercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PercentConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of PercentConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of PercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator PercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PercentConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(PercentConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class PercentConversionRateConfigConverter : JsonConverter<PercentConversionRateConfig>
{
    public override PercentConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PercentConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<EventOutput, EventOutputFromRaw>))]
public sealed record class EventOutput : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, EventOutputCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventOutputCadence>>("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required EventOutputConfig EventOutputConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EventOutputConfig>("event_output_config");
        }
        init { this._rawData.Set("event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public EventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EventOutputConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("event_output")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public EventOutput()
    {
        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventOutput(EventOutput eventOutput)
        : base(eventOutput) { }
#pragma warning restore CS8618

    public EventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventOutputFromRaw.FromRawUnchecked"/>
    public static EventOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventOutputFromRaw : IFromRawJson<EventOutput>
{
    /// <inheritdoc/>
    public EventOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(EventOutputCadenceConverter))]
public enum EventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class EventOutputCadenceConverter : JsonConverter<EventOutputCadence>
{
    public override EventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => EventOutputCadence.Annual,
            "semi_annual" => EventOutputCadence.SemiAnnual,
            "monthly" => EventOutputCadence.Monthly,
            "quarterly" => EventOutputCadence.Quarterly,
            "one_time" => EventOutputCadence.OneTime,
            "custom" => EventOutputCadence.Custom,
            _ => (EventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventOutputCadence.Annual => "annual",
                EventOutputCadence.SemiAnnual => "semi_annual",
                EventOutputCadence.Monthly => "monthly",
                EventOutputCadence.Quarterly => "quarterly",
                EventOutputCadence.OneTime => "one_time",
                EventOutputCadence.Custom => "custom",
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
[JsonConverter(typeof(JsonModelConverter<EventOutputConfig, EventOutputConfigFromRaw>))]
public sealed record class EventOutputConfig : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_rating_key");
        }
        init { this._rawData.Set("unit_rating_key", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_unit_rate");
        }
        init { this._rawData.Set("default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public EventOutputConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventOutputConfig(EventOutputConfig eventOutputConfig)
        : base(eventOutputConfig) { }
#pragma warning restore CS8618

    public EventOutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventOutputConfigFromRaw.FromRawUnchecked"/>
    public static EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class EventOutputConfigFromRaw : IFromRawJson<EventOutputConfig>
{
    /// <inheritdoc/>
    public EventOutputConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventOutputConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EventOutputConversionRateConfigConverter))]
public record class EventOutputConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EventOutputConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of EventOutputConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of EventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator EventOutputConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of EventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(EventOutputConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class EventOutputConversionRateConfigConverter
    : JsonConverter<EventOutputConversionRateConfig>
{
    public override EventOutputConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new EventOutputConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[System::Obsolete("deprecated")]
[JsonConverter(typeof(ExternalMarketplaceConverter))]
public enum ExternalMarketplace
{
    Google,
    Aws,
    Azure,
}

sealed class ExternalMarketplaceConverter : JsonConverter<ExternalMarketplace>
{
    public override ExternalMarketplace Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "google" => ExternalMarketplace.Google,
            "aws" => ExternalMarketplace.Aws,
            "azure" => ExternalMarketplace.Azure,
            _ => (ExternalMarketplace)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalMarketplace value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalMarketplace.Google => "google",
                ExternalMarketplace.Aws => "aws",
                ExternalMarketplace.Azure => "azure",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<RemoveAdjustment, RemoveAdjustmentFromRaw>))]
public sealed record class RemoveAdjustment : JsonModel
{
    /// <summary>
    /// The id of the adjustment to remove on the subscription.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("adjustment_id");
        }
        init { this._rawData.Set("adjustment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdjustmentID;
    }

    public RemoveAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemoveAdjustment(RemoveAdjustment removeAdjustment)
        : base(removeAdjustment) { }
#pragma warning restore CS8618

    public RemoveAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemoveAdjustmentFromRaw.FromRawUnchecked"/>
    public static RemoveAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RemoveAdjustment(string adjustmentID)
        : this()
    {
        this.AdjustmentID = adjustmentID;
    }
}

class RemoveAdjustmentFromRaw : IFromRawJson<RemoveAdjustment>
{
    /// <inheritdoc/>
    public RemoveAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RemoveAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RemovePrice, RemovePriceFromRaw>))]
public sealed record class RemovePrice : JsonModel
{
    /// <summary>
    /// The external price id of the price to remove on the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// The id of the price to remove on the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price_id");
        }
        init { this._rawData.Set("price_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalPriceID;
        _ = this.PriceID;
    }

    public RemovePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemovePrice(RemovePrice removePrice)
        : base(removePrice) { }
#pragma warning restore CS8618

    public RemovePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemovePriceFromRaw.FromRawUnchecked"/>
    public static RemovePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RemovePriceFromRaw : IFromRawJson<RemovePrice>
{
    /// <inheritdoc/>
    public RemovePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RemovePrice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ReplaceAdjustment, ReplaceAdjustmentFromRaw>))]
public sealed record class ReplaceAdjustment : JsonModel
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required ReplaceAdjustmentAdjustment Adjustment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplaceAdjustmentAdjustment>("adjustment");
        }
        init { this._rawData.Set("adjustment", value); }
    }

    /// <summary>
    /// The id of the adjustment on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("replaces_adjustment_id");
        }
        init { this._rawData.Set("replaces_adjustment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.ReplacesAdjustmentID;
    }

    public ReplaceAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplaceAdjustment(ReplaceAdjustment replaceAdjustment)
        : base(replaceAdjustment) { }
#pragma warning restore CS8618

    public ReplaceAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplaceAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplaceAdjustmentFromRaw.FromRawUnchecked"/>
    public static ReplaceAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplaceAdjustmentFromRaw : IFromRawJson<ReplaceAdjustment>
{
    /// <inheritdoc/>
    public ReplaceAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReplaceAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(ReplaceAdjustmentAdjustmentConverter))]
public record class ReplaceAdjustmentAdjustment : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
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

    public ReplaceAdjustmentAdjustment(NewPercentageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewUsageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewAmountDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewMinimum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewMaximum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (NewPercentageDiscount value) =&gt; {...},
    ///     (NewUsageDiscount value) =&gt; {...},
    ///     (NewAmountDiscount value) =&gt; {...},
    ///     (NewMinimum value) =&gt; {...},
    ///     (NewMaximum value) =&gt; {...}
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
                    "Data did not match any variant of ReplaceAdjustmentAdjustment"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (NewPercentageDiscount value) =&gt; {...},
    ///     (NewUsageDiscount value) =&gt; {...},
    ///     (NewAmountDiscount value) =&gt; {...},
    ///     (NewMinimum value) =&gt; {...},
    ///     (NewMaximum value) =&gt; {...}
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
                "Data did not match any variant of ReplaceAdjustmentAdjustment"
            ),
        };
    }

    public static implicit operator ReplaceAdjustmentAdjustment(NewPercentageDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewUsageDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewAmountDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewMinimum value) => new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewMaximum value) => new(value);

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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplaceAdjustmentAdjustment"
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

    public virtual bool Equals(ReplaceAdjustmentAdjustment? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            NewPercentageDiscount _ => 0,
            NewUsageDiscount _ => 1,
            NewAmountDiscount _ => 2,
            NewMinimum _ => 3,
            NewMaximum _ => 4,
            _ => -1,
        };
    }
}

sealed class ReplaceAdjustmentAdjustmentConverter : JsonConverter<ReplaceAdjustmentAdjustment>
{
    public override ReplaceAdjustmentAdjustment? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplaceAdjustmentAdjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplaceAdjustmentAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ReplacePrice, ReplacePriceFromRaw>))]
public sealed record class ReplacePrice : JsonModel
{
    /// <summary>
    /// The id of the price on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("replaces_price_id");
        }
        init { this._rawData.Set("replaces_price_id", value); }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewAllocationPrice>("allocation_price");
        }
        init { this._rawData.Set("allocation_price", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DiscountOverride>>("discounts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DiscountOverride>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// The new quantity of the price, if the price is a fixed price.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
    }

    /// <summary>
    /// Override values for parameterized billable metric variables. Keys are parameter
    /// names, values are the override values.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? MetricParameterOverrides
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metric_parameter_overrides"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metric_parameter_overrides",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    /// <summary>
    /// New subscription price request body params.
    /// </summary>
    public ReplacePricePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePrice>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price_id");
        }
        init { this._rawData.Set("price_id", value); }
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
        _ = this.MetricParameterOverrides;
        _ = this.MinimumAmount;
        this.Price?.Validate();
        _ = this.PriceID;
    }

    public ReplacePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePrice(ReplacePrice replacePrice)
        : base(replacePrice) { }
#pragma warning restore CS8618

    public ReplacePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePriceFromRaw.FromRawUnchecked"/>
    public static ReplacePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePrice(string replacesPriceID)
        : this()
    {
        this.ReplacesPriceID = replacesPriceID;
    }
}

class ReplacePriceFromRaw : IFromRawJson<ReplacePrice>
{
    /// <inheritdoc/>
    public ReplacePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReplacePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceConverter))]
public record class ReplacePricePrice : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
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
                matrixWithThresholdDiscounts: (x) => x.ItemID,
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
                dailyCreditAllowance: (x) => x.ItemID,
                meteredAllowance: (x) => x.ItemID,
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
                matrixWithThresholdDiscounts: (x) => x.Name,
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
                dailyCreditAllowance: (x) => x.Name,
                meteredAllowance: (x) => x.Name,
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
                matrixWithThresholdDiscounts: (x) => x.BillableMetricID,
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
                dailyCreditAllowance: (x) => x.BillableMetricID,
                meteredAllowance: (x) => x.BillableMetricID,
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
                matrixWithThresholdDiscounts: (x) => x.BilledInAdvance,
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
                dailyCreditAllowance: (x) => x.BilledInAdvance,
                meteredAllowance: (x) => x.BilledInAdvance,
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
                matrixWithThresholdDiscounts: (x) => x.BillingCycleConfiguration,
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
                dailyCreditAllowance: (x) => x.BillingCycleConfiguration,
                meteredAllowance: (x) => x.BillingCycleConfiguration,
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
                matrixWithThresholdDiscounts: (x) => x.ConversionRate,
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
                dailyCreditAllowance: (x) => x.ConversionRate,
                meteredAllowance: (x) => x.ConversionRate,
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
                matrixWithThresholdDiscounts: (x) => x.Currency,
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
                dailyCreditAllowance: (x) => x.Currency,
                meteredAllowance: (x) => x.Currency,
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
                matrixWithThresholdDiscounts: (x) => x.DimensionalPriceConfiguration,
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
                dailyCreditAllowance: (x) => x.DimensionalPriceConfiguration,
                meteredAllowance: (x) => x.DimensionalPriceConfiguration,
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
                matrixWithThresholdDiscounts: (x) => x.ExternalPriceID,
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
                dailyCreditAllowance: (x) => x.ExternalPriceID,
                meteredAllowance: (x) => x.ExternalPriceID,
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
                matrixWithThresholdDiscounts: (x) => x.FixedPriceQuantity,
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
                dailyCreditAllowance: (x) => x.FixedPriceQuantity,
                meteredAllowance: (x) => x.FixedPriceQuantity,
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
                matrixWithThresholdDiscounts: (x) => x.InvoiceGroupingKey,
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
                dailyCreditAllowance: (x) => x.InvoiceGroupingKey,
                meteredAllowance: (x) => x.InvoiceGroupingKey,
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
                matrixWithThresholdDiscounts: (x) => x.InvoicingCycleConfiguration,
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
                dailyCreditAllowance: (x) => x.InvoicingCycleConfiguration,
                meteredAllowance: (x) => x.InvoicingCycleConfiguration,
                newSubscriptionMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public string? LicenseTypeID
    {
        get
        {
            return Match<string?>(
                newSubscriptionUnit: (x) => x.LicenseTypeID,
                newSubscriptionTiered: (x) => x.LicenseTypeID,
                newSubscriptionBulk: (x) => x.LicenseTypeID,
                bulkWithFilters: (x) => x.LicenseTypeID,
                newSubscriptionPackage: (x) => x.LicenseTypeID,
                newSubscriptionMatrix: (x) => x.LicenseTypeID,
                newSubscriptionThresholdTotalAmount: (x) => x.LicenseTypeID,
                newSubscriptionTieredPackage: (x) => x.LicenseTypeID,
                newSubscriptionTieredWithMinimum: (x) => x.LicenseTypeID,
                newSubscriptionGroupedTiered: (x) => x.LicenseTypeID,
                newSubscriptionTieredPackageWithMinimum: (x) => x.LicenseTypeID,
                newSubscriptionPackageWithAllocation: (x) => x.LicenseTypeID,
                newSubscriptionUnitWithPercent: (x) => x.LicenseTypeID,
                newSubscriptionMatrixWithAllocation: (x) => x.LicenseTypeID,
                matrixWithThresholdDiscounts: (x) => x.LicenseTypeID,
                tieredWithProration: (x) => x.LicenseTypeID,
                newSubscriptionUnitWithProration: (x) => x.LicenseTypeID,
                newSubscriptionGroupedAllocation: (x) => x.LicenseTypeID,
                newSubscriptionBulkWithProration: (x) => x.LicenseTypeID,
                newSubscriptionGroupedWithProratedMinimum: (x) => x.LicenseTypeID,
                newSubscriptionGroupedWithMeteredMinimum: (x) => x.LicenseTypeID,
                groupedWithMinMaxThresholds: (x) => x.LicenseTypeID,
                newSubscriptionMatrixWithDisplayName: (x) => x.LicenseTypeID,
                newSubscriptionGroupedTieredPackage: (x) => x.LicenseTypeID,
                newSubscriptionMaxGroupTieredPackage: (x) => x.LicenseTypeID,
                newSubscriptionScalableMatrixWithUnitPricing: (x) => x.LicenseTypeID,
                newSubscriptionScalableMatrixWithTieredPricing: (x) => x.LicenseTypeID,
                newSubscriptionCumulativeGroupedBulk: (x) => x.LicenseTypeID,
                cumulativeGroupedAllocation: (x) => x.LicenseTypeID,
                dailyCreditAllowance: (x) => x.LicenseTypeID,
                meteredAllowance: (x) => x.LicenseTypeID,
                newSubscriptionMinimumComposite: (x) => x.LicenseTypeID,
                percent: (x) => x.LicenseTypeID,
                eventOutput: (x) => x.LicenseTypeID
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
                matrixWithThresholdDiscounts: (x) => x.ReferenceID,
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
                dailyCreditAllowance: (x) => x.ReferenceID,
                meteredAllowance: (x) => x.ReferenceID,
                newSubscriptionMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public ReplacePricePrice(NewSubscriptionUnitPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewSubscriptionTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewSubscriptionBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(ReplacePricePriceBulkWithFilters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewSubscriptionPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewSubscriptionMatrixPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionThresholdTotalAmountPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewSubscriptionTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionTieredWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewSubscriptionGroupedTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionTieredPackageWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionPackageWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewSubscriptionUnitWithPercentPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionMatrixWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceMatrixWithThresholdDiscounts value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceTieredWithProration value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionUnitWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionGroupedAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionBulkWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceGroupedWithMinMaxThresholds value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionMatrixWithDisplayNamePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionGroupedTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionMaxGroupTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionCumulativeGroupedBulkPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceCumulativeGroupedAllocation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceDailyCreditAllowance value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(ReplacePricePriceMeteredAllowance value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewSubscriptionMinimumCompositePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(ReplacePricePricePercent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(ReplacePricePriceEventOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="ReplacePricePriceBulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `ReplacePricePriceBulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out ReplacePricePriceBulkWithFilters? value
    )
    {
        value = this.Value as ReplacePricePriceBulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="ReplacePricePriceMatrixWithThresholdDiscounts"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMatrixWithThresholdDiscounts(out var value)) {
    ///     // `value` is of type `ReplacePricePriceMatrixWithThresholdDiscounts`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMatrixWithThresholdDiscounts(
        [NotNullWhen(true)] out ReplacePricePriceMatrixWithThresholdDiscounts? value
    )
    {
        value = this.Value as ReplacePricePriceMatrixWithThresholdDiscounts;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceTieredWithProration"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredWithProration(out var value)) {
    ///     // `value` is of type `ReplacePricePriceTieredWithProration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out ReplacePricePriceTieredWithProration? value
    )
    {
        value = this.Value as ReplacePricePriceTieredWithProration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="ReplacePricePriceGroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `ReplacePricePriceGroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out ReplacePricePriceGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as ReplacePricePriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="ReplacePricePriceCumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `ReplacePricePriceCumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out ReplacePricePriceCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as ReplacePricePriceCumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceDailyCreditAllowance"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDailyCreditAllowance(out var value)) {
    ///     // `value` is of type `ReplacePricePriceDailyCreditAllowance`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDailyCreditAllowance(
        [NotNullWhen(true)] out ReplacePricePriceDailyCreditAllowance? value
    )
    {
        value = this.Value as ReplacePricePriceDailyCreditAllowance;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceMeteredAllowance"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMeteredAllowance(out var value)) {
    ///     // `value` is of type `ReplacePricePriceMeteredAllowance`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMeteredAllowance(
        [NotNullWhen(true)] out ReplacePricePriceMeteredAllowance? value
    )
    {
        value = this.Value as ReplacePricePriceMeteredAllowance;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSubscriptionMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="ReplacePricePricePercent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `ReplacePricePricePercent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent([NotNullWhen(true)] out ReplacePricePricePercent? value)
    {
        value = this.Value as ReplacePricePricePercent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceEventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `ReplacePricePriceEventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput([NotNullWhen(true)] out ReplacePricePriceEventOutput? value)
    {
        value = this.Value as ReplacePricePriceEventOutput;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (NewSubscriptionUnitPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkPrice value) =&gt; {...},
    ///     (ReplacePricePriceBulkWithFilters value) =&gt; {...},
    ///     (NewSubscriptionPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixPrice value) =&gt; {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) =&gt; {...},
    ///     (ReplacePricePriceMatrixWithThresholdDiscounts value) =&gt; {...},
    ///     (ReplacePricePriceTieredWithProration value) =&gt; {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) =&gt; {...},
    ///     (ReplacePricePriceGroupedWithMinMaxThresholds value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) =&gt; {...},
    ///     (ReplacePricePriceCumulativeGroupedAllocation value) =&gt; {...},
    ///     (ReplacePricePriceDailyCreditAllowance value) =&gt; {...},
    ///     (ReplacePricePriceMeteredAllowance value) =&gt; {...},
    ///     (NewSubscriptionMinimumCompositePrice value) =&gt; {...},
    ///     (ReplacePricePricePercent value) =&gt; {...},
    ///     (ReplacePricePriceEventOutput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewSubscriptionUnitPrice> newSubscriptionUnit,
        System::Action<NewSubscriptionTieredPrice> newSubscriptionTiered,
        System::Action<NewSubscriptionBulkPrice> newSubscriptionBulk,
        System::Action<ReplacePricePriceBulkWithFilters> bulkWithFilters,
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
        System::Action<ReplacePricePriceMatrixWithThresholdDiscounts> matrixWithThresholdDiscounts,
        System::Action<ReplacePricePriceTieredWithProration> tieredWithProration,
        System::Action<NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        System::Action<NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        System::Action<NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        System::Action<NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        System::Action<NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        System::Action<ReplacePricePriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        System::Action<NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        System::Action<NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        System::Action<NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        System::Action<NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        System::Action<NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        System::Action<ReplacePricePriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<ReplacePricePriceDailyCreditAllowance> dailyCreditAllowance,
        System::Action<ReplacePricePriceMeteredAllowance> meteredAllowance,
        System::Action<NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite,
        System::Action<ReplacePricePricePercent> percent,
        System::Action<ReplacePricePriceEventOutput> eventOutput
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
            case ReplacePricePriceBulkWithFilters value:
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
            case ReplacePricePriceMatrixWithThresholdDiscounts value:
                matrixWithThresholdDiscounts(value);
                break;
            case ReplacePricePriceTieredWithProration value:
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
            case ReplacePricePriceGroupedWithMinMaxThresholds value:
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
            case ReplacePricePriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case ReplacePricePriceDailyCreditAllowance value:
                dailyCreditAllowance(value);
                break;
            case ReplacePricePriceMeteredAllowance value:
                meteredAllowance(value);
                break;
            case NewSubscriptionMinimumCompositePrice value:
                newSubscriptionMinimumComposite(value);
                break;
            case ReplacePricePricePercent value:
                percent(value);
                break;
            case ReplacePricePriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePrice"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (NewSubscriptionUnitPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkPrice value) =&gt; {...},
    ///     (ReplacePricePriceBulkWithFilters value) =&gt; {...},
    ///     (NewSubscriptionPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixPrice value) =&gt; {...},
    ///     (NewSubscriptionThresholdTotalAmountPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionTieredWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPrice value) =&gt; {...},
    ///     (NewSubscriptionTieredPackageWithMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionPackageWithAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionUnitWithPercentPrice value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithAllocationPrice value) =&gt; {...},
    ///     (ReplacePricePriceMatrixWithThresholdDiscounts value) =&gt; {...},
    ///     (ReplacePricePriceTieredWithProration value) =&gt; {...},
    ///     (NewSubscriptionUnitWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedAllocationPrice value) =&gt; {...},
    ///     (NewSubscriptionBulkWithProrationPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithProratedMinimumPrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedWithMeteredMinimumPrice value) =&gt; {...},
    ///     (ReplacePricePriceGroupedWithMinMaxThresholds value) =&gt; {...},
    ///     (NewSubscriptionMatrixWithDisplayNamePrice value) =&gt; {...},
    ///     (NewSubscriptionGroupedTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionMaxGroupTieredPackagePrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithUnitPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionScalableMatrixWithTieredPricingPrice value) =&gt; {...},
    ///     (NewSubscriptionCumulativeGroupedBulkPrice value) =&gt; {...},
    ///     (ReplacePricePriceCumulativeGroupedAllocation value) =&gt; {...},
    ///     (ReplacePricePriceDailyCreditAllowance value) =&gt; {...},
    ///     (ReplacePricePriceMeteredAllowance value) =&gt; {...},
    ///     (NewSubscriptionMinimumCompositePrice value) =&gt; {...},
    ///     (ReplacePricePricePercent value) =&gt; {...},
    ///     (ReplacePricePriceEventOutput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        System::Func<NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        System::Func<NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        System::Func<ReplacePricePriceBulkWithFilters, T> bulkWithFilters,
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
        System::Func<ReplacePricePriceMatrixWithThresholdDiscounts, T> matrixWithThresholdDiscounts,
        System::Func<ReplacePricePriceTieredWithProration, T> tieredWithProration,
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
        System::Func<ReplacePricePriceGroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
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
        System::Func<ReplacePricePriceCumulativeGroupedAllocation, T> cumulativeGroupedAllocation,
        System::Func<ReplacePricePriceDailyCreditAllowance, T> dailyCreditAllowance,
        System::Func<ReplacePricePriceMeteredAllowance, T> meteredAllowance,
        System::Func<NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite,
        System::Func<ReplacePricePricePercent, T> percent,
        System::Func<ReplacePricePriceEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice value => newSubscriptionUnit(value),
            NewSubscriptionTieredPrice value => newSubscriptionTiered(value),
            NewSubscriptionBulkPrice value => newSubscriptionBulk(value),
            ReplacePricePriceBulkWithFilters value => bulkWithFilters(value),
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
            ReplacePricePriceMatrixWithThresholdDiscounts value => matrixWithThresholdDiscounts(
                value
            ),
            ReplacePricePriceTieredWithProration value => tieredWithProration(value),
            NewSubscriptionUnitWithProrationPrice value => newSubscriptionUnitWithProration(value),
            NewSubscriptionGroupedAllocationPrice value => newSubscriptionGroupedAllocation(value),
            NewSubscriptionBulkWithProrationPrice value => newSubscriptionBulkWithProration(value),
            NewSubscriptionGroupedWithProratedMinimumPrice value =>
                newSubscriptionGroupedWithProratedMinimum(value),
            NewSubscriptionGroupedWithMeteredMinimumPrice value =>
                newSubscriptionGroupedWithMeteredMinimum(value),
            ReplacePricePriceGroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(
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
            ReplacePricePriceCumulativeGroupedAllocation value => cumulativeGroupedAllocation(
                value
            ),
            ReplacePricePriceDailyCreditAllowance value => dailyCreditAllowance(value),
            ReplacePricePriceMeteredAllowance value => meteredAllowance(value),
            NewSubscriptionMinimumCompositePrice value => newSubscriptionMinimumComposite(value),
            ReplacePricePricePercent value => percent(value),
            ReplacePricePriceEventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePrice"
            ),
        };
    }

    public static implicit operator ReplacePricePrice(NewSubscriptionUnitPrice value) => new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionTieredPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionBulkPrice value) => new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePriceBulkWithFilters value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionPackagePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionMatrixPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionTieredPackagePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionGroupedTieredPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionUnitWithPercentPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        ReplacePricePriceMatrixWithThresholdDiscounts value
    ) => new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePriceTieredWithProration value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        ReplacePricePriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewSubscriptionCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        ReplacePricePriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        ReplacePricePriceDailyCreditAllowance value
    ) => new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePriceMeteredAllowance value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewSubscriptionMinimumCompositePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePricePercent value) => new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePriceEventOutput value) =>
        new(value);

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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePrice"
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
            (matrixWithThresholdDiscounts) => matrixWithThresholdDiscounts.Validate(),
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
            (dailyCreditAllowance) => dailyCreditAllowance.Validate(),
            (meteredAllowance) => meteredAllowance.Validate(),
            (newSubscriptionMinimumComposite) => newSubscriptionMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(ReplacePricePrice? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            NewSubscriptionUnitPrice _ => 0,
            NewSubscriptionTieredPrice _ => 1,
            NewSubscriptionBulkPrice _ => 2,
            ReplacePricePriceBulkWithFilters _ => 3,
            NewSubscriptionPackagePrice _ => 4,
            NewSubscriptionMatrixPrice _ => 5,
            NewSubscriptionThresholdTotalAmountPrice _ => 6,
            NewSubscriptionTieredPackagePrice _ => 7,
            NewSubscriptionTieredWithMinimumPrice _ => 8,
            NewSubscriptionGroupedTieredPrice _ => 9,
            NewSubscriptionTieredPackageWithMinimumPrice _ => 10,
            NewSubscriptionPackageWithAllocationPrice _ => 11,
            NewSubscriptionUnitWithPercentPrice _ => 12,
            NewSubscriptionMatrixWithAllocationPrice _ => 13,
            ReplacePricePriceMatrixWithThresholdDiscounts _ => 14,
            ReplacePricePriceTieredWithProration _ => 15,
            NewSubscriptionUnitWithProrationPrice _ => 16,
            NewSubscriptionGroupedAllocationPrice _ => 17,
            NewSubscriptionBulkWithProrationPrice _ => 18,
            NewSubscriptionGroupedWithProratedMinimumPrice _ => 19,
            NewSubscriptionGroupedWithMeteredMinimumPrice _ => 20,
            ReplacePricePriceGroupedWithMinMaxThresholds _ => 21,
            NewSubscriptionMatrixWithDisplayNamePrice _ => 22,
            NewSubscriptionGroupedTieredPackagePrice _ => 23,
            NewSubscriptionMaxGroupTieredPackagePrice _ => 24,
            NewSubscriptionScalableMatrixWithUnitPricingPrice _ => 25,
            NewSubscriptionScalableMatrixWithTieredPricingPrice _ => 26,
            NewSubscriptionCumulativeGroupedBulkPrice _ => 27,
            ReplacePricePriceCumulativeGroupedAllocation _ => 28,
            ReplacePricePriceDailyCreditAllowance _ => 29,
            ReplacePricePriceMeteredAllowance _ => 30,
            NewSubscriptionMinimumCompositePrice _ => 31,
            ReplacePricePricePercent _ => 32,
            ReplacePricePriceEventOutput _ => 33,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceConverter : JsonConverter<ReplacePricePrice?>
{
    public override ReplacePricePrice? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePriceBulkWithFilters>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix_with_threshold_discounts":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceMatrixWithThresholdDiscounts>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        JsonSerializer.Deserialize<ReplacePricePriceTieredWithProration>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholds>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocation>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "daily_credit_allowance":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceDailyCreditAllowance>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "metered_allowance":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceMeteredAllowance>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum_composite":
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "event_output":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePriceEventOutput>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePrice(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFilters,
        ReplacePricePriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFilters : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                "bulk_with_filters_config"
            );
        }
        init { this._rawData.Set("bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceBulkWithFiltersConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("bulk_with_filters")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceBulkWithFilters()
    {
        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceBulkWithFilters(
        ReplacePricePriceBulkWithFilters replacePricePriceBulkWithFilters
    )
        : base(replacePricePriceBulkWithFilters) { }
#pragma warning restore CS8618

    public ReplacePricePriceBulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersFromRaw : IFromRawJson<ReplacePricePriceBulkWithFilters>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig,
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
            >("filters", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
            >("tiers", ImmutableArray.ToImmutableArray(value));
        }
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

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig replacePricePriceBulkWithFiltersBulkWithFiltersConfig
    )
        : base(replacePricePriceBulkWithFiltersBulkWithFiltersConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRawJson<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter,
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_key");
        }
        init { this._rawData.Set("property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_value");
        }
        init { this._rawData.Set("property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter replacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
    )
        : base(replacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter) { }
#pragma warning restore CS8618

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    : IFromRawJson<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier,
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier replacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
    )
        : base(replacePricePriceBulkWithFiltersBulkWithFiltersConfigTier) { }
#pragma warning restore CS8618

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    : IFromRawJson<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceBulkWithFiltersCadenceConverter))]
public enum ReplacePricePriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceBulkWithFiltersCadenceConverter
    : JsonConverter<ReplacePricePriceBulkWithFiltersCadence>
{
    public override ReplacePricePriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceBulkWithFiltersCadence.Annual,
            "semi_annual" => ReplacePricePriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" => ReplacePricePriceBulkWithFiltersCadence.Monthly,
            "quarterly" => ReplacePricePriceBulkWithFiltersCadence.Quarterly,
            "one_time" => ReplacePricePriceBulkWithFiltersCadence.OneTime,
            "custom" => ReplacePricePriceBulkWithFiltersCadence.Custom,
            _ => (ReplacePricePriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceBulkWithFiltersCadence.Annual => "annual",
                ReplacePricePriceBulkWithFiltersCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceBulkWithFiltersCadence.Monthly => "monthly",
                ReplacePricePriceBulkWithFiltersCadence.Quarterly => "quarterly",
                ReplacePricePriceBulkWithFiltersCadence.OneTime => "one_time",
                ReplacePricePriceBulkWithFiltersCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ReplacePricePriceBulkWithFiltersConversionRateConfigConverter))]
public record class ReplacePricePriceBulkWithFiltersConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceBulkWithFiltersConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceBulkWithFiltersConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceBulkWithFiltersConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceBulkWithFiltersConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceBulkWithFiltersConversionRateConfig>
{
    public override ReplacePricePriceBulkWithFiltersConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceBulkWithFiltersConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceMatrixWithThresholdDiscounts,
        ReplacePricePriceMatrixWithThresholdDiscountsFromRaw
    >)
)]
public sealed record class ReplacePricePriceMatrixWithThresholdDiscounts : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceMatrixWithThresholdDiscountsCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceMatrixWithThresholdDiscountsCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// Configuration for matrix_with_threshold_discounts pricing
    /// </summary>
    public required ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig MatrixWithThresholdDiscountsConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig>(
                "matrix_with_threshold_discounts_config"
            );
        }
        init { this._rawData.Set("matrix_with_threshold_discounts_config", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.MatrixWithThresholdDiscountsConfig.Validate();
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("matrix_with_threshold_discounts")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceMatrixWithThresholdDiscounts()
    {
        this.ModelType = JsonSerializer.SerializeToElement("matrix_with_threshold_discounts");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceMatrixWithThresholdDiscounts(
        ReplacePricePriceMatrixWithThresholdDiscounts replacePricePriceMatrixWithThresholdDiscounts
    )
        : base(replacePricePriceMatrixWithThresholdDiscounts) { }
#pragma warning restore CS8618

    public ReplacePricePriceMatrixWithThresholdDiscounts(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("matrix_with_threshold_discounts");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceMatrixWithThresholdDiscounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceMatrixWithThresholdDiscountsFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceMatrixWithThresholdDiscounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceMatrixWithThresholdDiscountsFromRaw
    : IFromRawJson<ReplacePricePriceMatrixWithThresholdDiscounts>
{
    /// <inheritdoc/>
    public ReplacePricePriceMatrixWithThresholdDiscounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceMatrixWithThresholdDiscounts.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceMatrixWithThresholdDiscountsCadenceConverter))]
public enum ReplacePricePriceMatrixWithThresholdDiscountsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceMatrixWithThresholdDiscountsCadenceConverter
    : JsonConverter<ReplacePricePriceMatrixWithThresholdDiscountsCadence>
{
    public override ReplacePricePriceMatrixWithThresholdDiscountsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceMatrixWithThresholdDiscountsCadence.Annual,
            "semi_annual" => ReplacePricePriceMatrixWithThresholdDiscountsCadence.SemiAnnual,
            "monthly" => ReplacePricePriceMatrixWithThresholdDiscountsCadence.Monthly,
            "quarterly" => ReplacePricePriceMatrixWithThresholdDiscountsCadence.Quarterly,
            "one_time" => ReplacePricePriceMatrixWithThresholdDiscountsCadence.OneTime,
            "custom" => ReplacePricePriceMatrixWithThresholdDiscountsCadence.Custom,
            _ => (ReplacePricePriceMatrixWithThresholdDiscountsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceMatrixWithThresholdDiscountsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceMatrixWithThresholdDiscountsCadence.Annual => "annual",
                ReplacePricePriceMatrixWithThresholdDiscountsCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceMatrixWithThresholdDiscountsCadence.Monthly => "monthly",
                ReplacePricePriceMatrixWithThresholdDiscountsCadence.Quarterly => "quarterly",
                ReplacePricePriceMatrixWithThresholdDiscountsCadence.OneTime => "one_time",
                ReplacePricePriceMatrixWithThresholdDiscountsCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for matrix_with_threshold_discounts pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig,
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig
    : JsonModel
{
    /// <summary>
    /// Unit price used for usage that does not match any defined matrix cell.
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("default_unit_amount");
        }
        init { this._rawData.Set("default_unit_amount", value); }
    }

    /// <summary>
    /// First matrix dimension key.
    /// </summary>
    public required string FirstDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_dimension");
        }
        init { this._rawData.Set("first_dimension", value); }
    }

    /// <summary>
    /// Per-cell unit prices.
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue> MatrixValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue>
            >("matrix_values");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue>
            >("matrix_values", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Optional second matrix dimension key.
    /// </summary>
    public string? SecondDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("second_dimension");
        }
        init { this._rawData.Set("second_dimension", value); }
    }

    public IReadOnlyList<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup>? ThresholdDiscountGroups
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup>
            >("threshold_discount_groups");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup>?>(
                "threshold_discount_groups",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DefaultUnitAmount;
        _ = this.FirstDimension;
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
        _ = this.SecondDimension;
        foreach (var item in this.ThresholdDiscountGroups ?? [])
        {
            item.Validate();
        }
    }

    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig(
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig replacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig
    )
        : base(replacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigFromRaw
    : IFromRawJson<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue,
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValueFromRaw
    >)
)]
public sealed record class ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue
    : JsonModel
{
    public required string FirstDimensionValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_dimension_value");
        }
        init { this._rawData.Set("first_dimension_value", value); }
    }

    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    public string? SecondDimensionValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("second_dimension_value");
        }
        init { this._rawData.Set("second_dimension_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstDimensionValue;
        _ = this.UnitAmount;
        _ = this.SecondDimensionValue;
    }

    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue(
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue replacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue
    )
        : base(
            replacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue
        ) { }
#pragma warning restore CS8618

    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValueFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValueFromRaw
    : IFromRawJson<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue>
{
    /// <inheritdoc/>
    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigMatrixValue.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup,
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroupFromRaw
    >)
)]
public sealed record class ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup
    : JsonModel
{
    /// <summary>
    /// Discount rate applied to spend above the threshold.
    /// </summary>
    public required string AboveThresholdDiscountPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("above_threshold_discount_percentage");
        }
        init { this._rawData.Set("above_threshold_discount_percentage", value); }
    }

    /// <summary>
    /// Discount rate applied to spend at or below the threshold. Set to 0 for no
    /// baseline discount.
    /// </summary>
    public required string BelowThresholdDiscountPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("below_threshold_discount_percentage");
        }
        init { this._rawData.Set("below_threshold_discount_percentage", value); }
    }

    /// <summary>
    /// Semicolon-separated list of matrix cell coordinates targeted by this group.
    /// Each coordinate is `first,second` when the matrix has two dimensions, or just
    /// `first` for a single-dimension matrix. Example: `blue,circle;green,triangle`.
    /// </summary>
    public required string CellCoordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cell_coordinates");
        }
        init { this._rawData.Set("cell_coordinates", value); }
    }

    public required string ThresholdAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("threshold_amount");
        }
        init { this._rawData.Set("threshold_amount", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AboveThresholdDiscountPercentage;
        _ = this.BelowThresholdDiscountPercentage;
        _ = this.CellCoordinates;
        _ = this.ThresholdAmount;
        _ = this.Description;
    }

    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup(
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup replacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup
    )
        : base(
            replacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup
        ) { }
#pragma warning restore CS8618

    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroupFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroupFromRaw
    : IFromRawJson<ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup>
{
    /// <inheritdoc/>
    public ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceMatrixWithThresholdDiscountsMatrixWithThresholdDiscountsConfigThresholdDiscountGroup.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfigConverter))]
public record class ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig>
{
    public override ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceMatrixWithThresholdDiscountsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceTieredWithProration,
        ReplacePricePriceTieredWithProrationFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProration : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceTieredWithProrationCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceTieredWithProrationCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required ReplacePricePriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                "tiered_with_proration_config"
            );
        }
        init { this._rawData.Set("tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceTieredWithProrationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("tiered_with_proration")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceTieredWithProration()
    {
        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceTieredWithProration(
        ReplacePricePriceTieredWithProration replacePricePriceTieredWithProration
    )
        : base(replacePricePriceTieredWithProration) { }
#pragma warning restore CS8618

    public ReplacePricePriceTieredWithProration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceTieredWithProrationFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceTieredWithProrationFromRaw
    : IFromRawJson<ReplacePricePriceTieredWithProration>
{
    /// <inheritdoc/>
    public ReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceTieredWithProration.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceTieredWithProrationCadenceConverter))]
public enum ReplacePricePriceTieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceTieredWithProrationCadenceConverter
    : JsonConverter<ReplacePricePriceTieredWithProrationCadence>
{
    public override ReplacePricePriceTieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceTieredWithProrationCadence.Annual,
            "semi_annual" => ReplacePricePriceTieredWithProrationCadence.SemiAnnual,
            "monthly" => ReplacePricePriceTieredWithProrationCadence.Monthly,
            "quarterly" => ReplacePricePriceTieredWithProrationCadence.Quarterly,
            "one_time" => ReplacePricePriceTieredWithProrationCadence.OneTime,
            "custom" => ReplacePricePriceTieredWithProrationCadence.Custom,
            _ => (ReplacePricePriceTieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceTieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceTieredWithProrationCadence.Annual => "annual",
                ReplacePricePriceTieredWithProrationCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceTieredWithProrationCadence.Monthly => "monthly",
                ReplacePricePriceTieredWithProrationCadence.Quarterly => "quarterly",
                ReplacePricePriceTieredWithProrationCadence.OneTime => "one_time",
                ReplacePricePriceTieredWithProrationCadence.Custom => "custom",
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
        ReplacePricePriceTieredWithProrationTieredWithProrationConfig,
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProrationTieredWithProrationConfig : JsonModel
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
            >("tiers", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        ReplacePricePriceTieredWithProrationTieredWithProrationConfig replacePricePriceTieredWithProrationTieredWithProrationConfig
    )
        : base(replacePricePriceTieredWithProrationTieredWithProrationConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyList<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    : IFromRawJson<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceTieredWithProrationTieredWithProrationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier,
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
    : JsonModel
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier replacePricePriceTieredWithProrationTieredWithProrationConfigTier
    )
        : base(replacePricePriceTieredWithProrationTieredWithProrationConfigTier) { }
#pragma warning restore CS8618

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    : IFromRawJson<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
{
    /// <inheritdoc/>
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePricePriceTieredWithProrationConversionRateConfigConverter))]
public record class ReplacePricePriceTieredWithProrationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceTieredWithProrationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceTieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceTieredWithProrationConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceTieredWithProrationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceTieredWithProrationConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceTieredWithProrationConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceTieredWithProrationConversionRateConfig>
{
    public override ReplacePricePriceTieredWithProrationConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceTieredWithProrationConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceTieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceGroupedWithMinMaxThresholds,
        ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholds : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { this._rawData.Set("grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceGroupedWithMinMaxThresholds(
        ReplacePricePriceGroupedWithMinMaxThresholds replacePricePriceGroupedWithMinMaxThresholds
    )
        : base(replacePricePriceGroupedWithMinMaxThresholds) { }
#pragma warning restore CS8618

    public ReplacePricePriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRawJson<ReplacePricePriceGroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public ReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceGroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceGroupedWithMinMaxThresholdsCadenceConverter))]
public enum ReplacePricePriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
{
    public override ReplacePricePriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ => (ReplacePricePriceGroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual => "annual",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly => "quarterly",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom => "custom",
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
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("maximum_charge");
        }
        init { this._rawData.Set("maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum_charge");
        }
        init { this._rawData.Set("minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("per_unit_rate");
        }
        init { this._rawData.Set("per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig replacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    )
        : base(replacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRawJson<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter))]
public record class ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceCumulativeGroupedAllocation,
        ReplacePricePriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class ReplacePricePriceCumulativeGroupedAllocation : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                "cumulative_grouped_allocation_config"
            );
        }
        init { this._rawData.Set("cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("cumulative_grouped_allocation")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceCumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceCumulativeGroupedAllocation(
        ReplacePricePriceCumulativeGroupedAllocation replacePricePriceCumulativeGroupedAllocation
    )
        : base(replacePricePriceCumulativeGroupedAllocation) { }
#pragma warning restore CS8618

    public ReplacePricePriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceCumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceCumulativeGroupedAllocationFromRaw
    : IFromRawJson<ReplacePricePriceCumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public ReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceCumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceCumulativeGroupedAllocationCadenceConverter))]
public enum ReplacePricePriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<ReplacePricePriceCumulativeGroupedAllocationCadence>
{
    public override ReplacePricePriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" => ReplacePricePriceCumulativeGroupedAllocationCadence.Custom,
            _ => (ReplacePricePriceCumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceCumulativeGroupedAllocationCadence.Annual => "annual",
                ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly => "monthly",
                ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly => "quarterly",
                ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime => "one_time",
                ReplacePricePriceCumulativeGroupedAllocationCadence.Custom => "custom",
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
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cumulative_allocation");
        }
        init { this._rawData.Set("cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_allocation");
        }
        init { this._rawData.Set("group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig replacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    )
        : base(replacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRawJson<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter))]
public record class ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceDailyCreditAllowance,
        ReplacePricePriceDailyCreditAllowanceFromRaw
    >)
)]
public sealed record class ReplacePricePriceDailyCreditAllowance : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceDailyCreditAllowanceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceDailyCreditAllowanceCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for daily_credit_allowance pricing
    /// </summary>
    public required ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig DailyCreditAllowanceConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig>(
                "daily_credit_allowance_config"
            );
        }
        init { this._rawData.Set("daily_credit_allowance_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceDailyCreditAllowanceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceDailyCreditAllowanceConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.DailyCreditAllowanceConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("daily_credit_allowance")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceDailyCreditAllowance()
    {
        this.ModelType = JsonSerializer.SerializeToElement("daily_credit_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceDailyCreditAllowance(
        ReplacePricePriceDailyCreditAllowance replacePricePriceDailyCreditAllowance
    )
        : base(replacePricePriceDailyCreditAllowance) { }
#pragma warning restore CS8618

    public ReplacePricePriceDailyCreditAllowance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("daily_credit_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceDailyCreditAllowance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceDailyCreditAllowanceFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceDailyCreditAllowance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceDailyCreditAllowanceFromRaw
    : IFromRawJson<ReplacePricePriceDailyCreditAllowance>
{
    /// <inheritdoc/>
    public ReplacePricePriceDailyCreditAllowance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceDailyCreditAllowance.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceDailyCreditAllowanceCadenceConverter))]
public enum ReplacePricePriceDailyCreditAllowanceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceDailyCreditAllowanceCadenceConverter
    : JsonConverter<ReplacePricePriceDailyCreditAllowanceCadence>
{
    public override ReplacePricePriceDailyCreditAllowanceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceDailyCreditAllowanceCadence.Annual,
            "semi_annual" => ReplacePricePriceDailyCreditAllowanceCadence.SemiAnnual,
            "monthly" => ReplacePricePriceDailyCreditAllowanceCadence.Monthly,
            "quarterly" => ReplacePricePriceDailyCreditAllowanceCadence.Quarterly,
            "one_time" => ReplacePricePriceDailyCreditAllowanceCadence.OneTime,
            "custom" => ReplacePricePriceDailyCreditAllowanceCadence.Custom,
            _ => (ReplacePricePriceDailyCreditAllowanceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceDailyCreditAllowanceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceDailyCreditAllowanceCadence.Annual => "annual",
                ReplacePricePriceDailyCreditAllowanceCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceDailyCreditAllowanceCadence.Monthly => "monthly",
                ReplacePricePriceDailyCreditAllowanceCadence.Quarterly => "quarterly",
                ReplacePricePriceDailyCreditAllowanceCadence.OneTime => "one_time",
                ReplacePricePriceDailyCreditAllowanceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for daily_credit_allowance pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig,
        ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig
    : JsonModel
{
    /// <summary>
    /// Credits granted per day. Lose-it-or-use-it; does not roll over.
    /// </summary>
    public required string DailyAllowance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("daily_allowance");
        }
        init { this._rawData.Set("daily_allowance", value); }
    }

    /// <summary>
    /// Default per-unit credit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("default_unit_amount");
        }
        init { this._rawData.Set("default_unit_amount", value); }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required IReadOnlyList<string?> Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("dimensions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "dimensions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Event property whose value identifies the day bucket the event belongs to
    /// (e.g. 'event_day' set to an ISO date string in the customer's timezone).
    /// The allowance resets per distinct value of this property.
    /// </summary>
    public required string EventDayProperty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_day_property");
        }
        init { this._rawData.Set("event_day_property", value); }
    }

    /// <summary>
    /// Per-dimension credit rates
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue> MatrixValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue>
            >("matrix_values");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue>
            >("matrix_values", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DailyAllowance;
        _ = this.DefaultUnitAmount;
        _ = this.Dimensions;
        _ = this.EventDayProperty;
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
    }

    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig(
        ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig replacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig
    )
        : base(replacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigFromRaw
    : IFromRawJson<ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-dimension credit price for the daily credit allowance model.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue,
        ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValueFromRaw
    >)
)]
public sealed record class ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue
    : JsonModel
{
    /// <summary>
    /// One or two matrix keys to filter usage to this value by. For example, ["model"]
    /// could be used to apply a different credit rate to each AI model.
    /// </summary>
    public required IReadOnlyList<string?> DimensionValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("dimension_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "dimension_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Credits charged per unit of usage matching the specified dimension_values
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.UnitAmount;
    }

    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue(
        ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue replacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue
    )
        : base(replacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue) { }
#pragma warning restore CS8618

    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValueFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValueFromRaw
    : IFromRawJson<ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue>
{
    /// <inheritdoc/>
    public ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceDailyCreditAllowanceDailyCreditAllowanceConfigMatrixValue.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(ReplacePricePriceDailyCreditAllowanceConversionRateConfigConverter))]
public record class ReplacePricePriceDailyCreditAllowanceConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceDailyCreditAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceDailyCreditAllowanceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceDailyCreditAllowanceConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceDailyCreditAllowanceConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceDailyCreditAllowanceConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceDailyCreditAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceDailyCreditAllowanceConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceDailyCreditAllowanceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceDailyCreditAllowanceConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceDailyCreditAllowanceConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceDailyCreditAllowanceConversionRateConfig>
{
    public override ReplacePricePriceDailyCreditAllowanceConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceDailyCreditAllowanceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceDailyCreditAllowanceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceMeteredAllowance,
        ReplacePricePriceMeteredAllowanceFromRaw
    >)
)]
public sealed record class ReplacePricePriceMeteredAllowance : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceMeteredAllowanceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceMeteredAllowanceCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// Configuration for metered_allowance pricing
    /// </summary>
    public required ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig MeteredAllowanceConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig>(
                "metered_allowance_config"
            );
        }
        init { this._rawData.Set("metered_allowance_config", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceMeteredAllowanceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceMeteredAllowanceConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.MeteredAllowanceConfig.Validate();
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("metered_allowance")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceMeteredAllowance()
    {
        this.ModelType = JsonSerializer.SerializeToElement("metered_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceMeteredAllowance(
        ReplacePricePriceMeteredAllowance replacePricePriceMeteredAllowance
    )
        : base(replacePricePriceMeteredAllowance) { }
#pragma warning restore CS8618

    public ReplacePricePriceMeteredAllowance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("metered_allowance");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceMeteredAllowance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceMeteredAllowanceFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceMeteredAllowance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceMeteredAllowanceFromRaw : IFromRawJson<ReplacePricePriceMeteredAllowance>
{
    /// <inheritdoc/>
    public ReplacePricePriceMeteredAllowance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceMeteredAllowance.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceMeteredAllowanceCadenceConverter))]
public enum ReplacePricePriceMeteredAllowanceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceMeteredAllowanceCadenceConverter
    : JsonConverter<ReplacePricePriceMeteredAllowanceCadence>
{
    public override ReplacePricePriceMeteredAllowanceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceMeteredAllowanceCadence.Annual,
            "semi_annual" => ReplacePricePriceMeteredAllowanceCadence.SemiAnnual,
            "monthly" => ReplacePricePriceMeteredAllowanceCadence.Monthly,
            "quarterly" => ReplacePricePriceMeteredAllowanceCadence.Quarterly,
            "one_time" => ReplacePricePriceMeteredAllowanceCadence.OneTime,
            "custom" => ReplacePricePriceMeteredAllowanceCadence.Custom,
            _ => (ReplacePricePriceMeteredAllowanceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceMeteredAllowanceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceMeteredAllowanceCadence.Annual => "annual",
                ReplacePricePriceMeteredAllowanceCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceMeteredAllowanceCadence.Monthly => "monthly",
                ReplacePricePriceMeteredAllowanceCadence.Quarterly => "quarterly",
                ReplacePricePriceMeteredAllowanceCadence.OneTime => "one_time",
                ReplacePricePriceMeteredAllowanceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for metered_allowance pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig,
        ReplacePricePriceMeteredAllowanceMeteredAllowanceConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig : JsonModel
{
    /// <summary>
    /// The grouping_key value whose summed quantity represents the allowance for
    /// this period (e.g. 'storage_snapshot' emitting 3 × avg storage). Capped at
    /// consumption — credit can never exceed actual usage.
    /// </summary>
    public required string AllowanceGroupingValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("allowance_grouping_value");
        }
        init { this._rawData.Set("allowance_grouping_value", value); }
    }

    /// <summary>
    /// The grouping_key value whose summed quantity represents consumption (e.g.
    /// 'download'). Charged at unit_amount.
    /// </summary>
    public required string ConsumptionGroupingValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("consumption_grouping_value");
        }
        init { this._rawData.Set("consumption_grouping_value", value); }
    }

    /// <summary>
    /// Event property used to partition the metric into consumption and allowance
    /// quantities (e.g. 'event_name'). The metric is queried with this key and the
    /// two values below select which partition is which.
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// Per-unit price applied to gross consumption and to the allowance credit.
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// Sub-line label for the credit row (e.g. 'Up to 3x free egress').
    /// </summary>
    public string? AllowanceDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("allowance_display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowance_display_name", value);
        }
    }

    /// <summary>
    /// Sub-line label for the gross consumption row (e.g. 'bytes gotten').
    /// </summary>
    public string? ConsumptionDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("consumption_display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumption_display_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowanceGroupingValue;
        _ = this.ConsumptionGroupingValue;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
        _ = this.AllowanceDisplayName;
        _ = this.ConsumptionDisplayName;
    }

    public ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig(
        ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig replacePricePriceMeteredAllowanceMeteredAllowanceConfig
    )
        : base(replacePricePriceMeteredAllowanceMeteredAllowanceConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceMeteredAllowanceMeteredAllowanceConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceMeteredAllowanceMeteredAllowanceConfigFromRaw
    : IFromRawJson<ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceMeteredAllowanceMeteredAllowanceConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePricePriceMeteredAllowanceConversionRateConfigConverter))]
public record class ReplacePricePriceMeteredAllowanceConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceMeteredAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceMeteredAllowanceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceMeteredAllowanceConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceMeteredAllowanceConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceMeteredAllowanceConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceMeteredAllowanceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceMeteredAllowanceConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceMeteredAllowanceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceMeteredAllowanceConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceMeteredAllowanceConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceMeteredAllowanceConversionRateConfig>
{
    public override ReplacePricePriceMeteredAllowanceConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceMeteredAllowanceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceMeteredAllowanceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ReplacePricePricePercent, ReplacePricePricePercentFromRaw>)
)]
public sealed record class ReplacePricePricePercent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePricePercentCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReplacePricePricePercentCadence>>(
                "cadence"
            );
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required ReplacePricePricePercentPercentConfig PercentConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePricePercentPercentConfig>(
                "percent_config"
            );
        }
        init { this._rawData.Set("percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePricePercentConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (!JsonElement.DeepEquals(this.ModelType, JsonSerializer.SerializeToElement("percent")))
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePricePercent()
    {
        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePricePercent(ReplacePricePricePercent replacePricePricePercent)
        : base(replacePricePricePercent) { }
#pragma warning restore CS8618

    public ReplacePricePricePercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePricePercentFromRaw.FromRawUnchecked"/>
    public static ReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePricePercentFromRaw : IFromRawJson<ReplacePricePricePercent>
{
    /// <inheritdoc/>
    public ReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePricePercentCadenceConverter))]
public enum ReplacePricePricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePricePercentCadenceConverter
    : JsonConverter<ReplacePricePricePercentCadence>
{
    public override ReplacePricePricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePricePercentCadence.Annual,
            "semi_annual" => ReplacePricePricePercentCadence.SemiAnnual,
            "monthly" => ReplacePricePricePercentCadence.Monthly,
            "quarterly" => ReplacePricePricePercentCadence.Quarterly,
            "one_time" => ReplacePricePricePercentCadence.OneTime,
            "custom" => ReplacePricePricePercentCadence.Custom,
            _ => (ReplacePricePricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePricePercentCadence.Annual => "annual",
                ReplacePricePricePercentCadence.SemiAnnual => "semi_annual",
                ReplacePricePricePercentCadence.Monthly => "monthly",
                ReplacePricePricePercentCadence.Quarterly => "quarterly",
                ReplacePricePricePercentCadence.OneTime => "one_time",
                ReplacePricePricePercentCadence.Custom => "custom",
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
        ReplacePricePricePercentPercentConfig,
        ReplacePricePricePercentPercentConfigFromRaw
    >)
)]
public sealed record class ReplacePricePricePercentPercentConfig : JsonModel
{
    /// <summary>
    /// Fraction of the component subtotals to charge (0 &lt; percent &lt;= 1).
    /// </summary>
    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    /// <summary>
    /// Maximum amount to charge. If unset, the fee has no upper bound.
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
    }

    /// <summary>
    /// Minimum amount to charge. If unset, the fee is bounded below by 0.
    /// </summary>
    public string? MinimumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    /// <summary>
    /// If true, the minimum_amount is prorated based on the service period. The
    /// maximum_amount is an absolute cap (never prorated), and the percent applied
    /// to upstream subtotals is never prorated either.
    /// </summary>
    public bool? Prorated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prorated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prorated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
        _ = this.MaximumAmount;
        _ = this.MinimumAmount;
        _ = this.Prorated;
    }

    public ReplacePricePricePercentPercentConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePricePercentPercentConfig(
        ReplacePricePricePercentPercentConfig replacePricePricePercentPercentConfig
    )
        : base(replacePricePricePercentPercentConfig) { }
#pragma warning restore CS8618

    public ReplacePricePricePercentPercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercentPercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePricePercentPercentConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class ReplacePricePricePercentPercentConfigFromRaw
    : IFromRawJson<ReplacePricePricePercentPercentConfig>
{
    /// <inheritdoc/>
    public ReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePricePercentPercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePricePricePercentConversionRateConfigConverter))]
public record class ReplacePricePricePercentConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePricePercentConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePricePercentConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePricePercentConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePricePercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePricePercentConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePricePercentConversionRateConfigConverter
    : JsonConverter<ReplacePricePricePercentConversionRateConfig>
{
    public override ReplacePricePricePercentConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePricePercentConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ReplacePricePriceEventOutput, ReplacePricePriceEventOutputFromRaw>)
)]
public sealed record class ReplacePricePriceEventOutput : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceEventOutputCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceEventOutputCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required ReplacePricePriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceEventOutputEventOutputConfig>(
                "event_output_config"
            );
        }
        init { this._rawData.Set("event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceEventOutputConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// The ID of the license type to associate with this price.
    /// </summary>
    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
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
                JsonSerializer.SerializeToElement("event_output")
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
        _ = this.LicenseTypeID;
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceEventOutput()
    {
        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceEventOutput(ReplacePricePriceEventOutput replacePricePriceEventOutput)
        : base(replacePricePriceEventOutput) { }
#pragma warning restore CS8618

    public ReplacePricePriceEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceEventOutputFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceEventOutputFromRaw : IFromRawJson<ReplacePricePriceEventOutput>
{
    /// <inheritdoc/>
    public ReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceEventOutputCadenceConverter))]
public enum ReplacePricePriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceEventOutputCadenceConverter
    : JsonConverter<ReplacePricePriceEventOutputCadence>
{
    public override ReplacePricePriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceEventOutputCadence.Annual,
            "semi_annual" => ReplacePricePriceEventOutputCadence.SemiAnnual,
            "monthly" => ReplacePricePriceEventOutputCadence.Monthly,
            "quarterly" => ReplacePricePriceEventOutputCadence.Quarterly,
            "one_time" => ReplacePricePriceEventOutputCadence.OneTime,
            "custom" => ReplacePricePriceEventOutputCadence.Custom,
            _ => (ReplacePricePriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceEventOutputCadence.Annual => "annual",
                ReplacePricePriceEventOutputCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceEventOutputCadence.Monthly => "monthly",
                ReplacePricePriceEventOutputCadence.Quarterly => "quarterly",
                ReplacePricePriceEventOutputCadence.OneTime => "one_time",
                ReplacePricePriceEventOutputCadence.Custom => "custom",
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
        ReplacePricePriceEventOutputEventOutputConfig,
        ReplacePricePriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceEventOutputEventOutputConfig : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_rating_key");
        }
        init { this._rawData.Set("unit_rating_key", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_unit_rate");
        }
        init { this._rawData.Set("default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public ReplacePricePriceEventOutputEventOutputConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacePricePriceEventOutputEventOutputConfig(
        ReplacePricePriceEventOutputEventOutputConfig replacePricePriceEventOutputEventOutputConfig
    )
        : base(replacePricePriceEventOutputEventOutputConfig) { }
#pragma warning restore CS8618

    public ReplacePricePriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutputEventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceEventOutputEventOutputConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceEventOutputEventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class ReplacePricePriceEventOutputEventOutputConfigFromRaw
    : IFromRawJson<ReplacePricePriceEventOutputEventOutputConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceEventOutputEventOutputConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePricePriceEventOutputConversionRateConfigConverter))]
public record class ReplacePricePriceEventOutputConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceEventOutputConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                    "Data did not match any variant of ReplacePricePriceEventOutputConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (SharedUnitConversionRateConfig value) =&gt; {...},
    ///     (SharedTieredConversionRateConfig value) =&gt; {...}
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
                "Data did not match any variant of ReplacePricePriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceEventOutputConversionRateConfig(
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceEventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceEventOutputConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ReplacePricePriceEventOutputConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceEventOutputConversionRateConfig>
{
    public override ReplacePricePriceEventOutputConversionRateConfig? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceEventOutputConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
