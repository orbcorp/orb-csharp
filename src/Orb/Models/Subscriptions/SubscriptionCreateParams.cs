using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

namespace Orb.Models.Subscriptions;

/// <summary>
/// A subscription represents the purchase of a plan by a customer. The customer
/// is identified by either the `customer_id` or the `external_customer_id`, and
/// exactly one of these fields must be provided.
///
/// By default, subscriptions begin on the day that they're created and renew automatically
/// for each billing cycle at the cadence that's configured in the plan definition.
///
/// The default configuration for subscriptions in Orb is **In-advance billing** and
/// **Beginning of month alignment** (see [Subscription](/core-concepts##subscription)
/// for more details).
///
/// In order to change the alignment behavior, Orb also supports billing subscriptions
/// on the day of the month they are created. If `align_billing_with_subscription_start_date
/// = true` is specified, subscriptions have billing cycles that are aligned with
/// their `start_date`. For example, a subscription that begins on January 15th will
/// have a billing cycle from January 15th to February 15th. Every subsequent billing
/// cycle will continue to start and invoice on the 15th.
///
/// If the "day" value is greater than the number of days in the month, the next billing
/// cycle will start at the end of the month. For example, if the start_date is January
/// 31st, the next billing cycle will start on February 28th.
///
/// If a customer was created with a currency, Orb only allows subscribing the customer
/// to a plan with a matching `invoicing_currency`. If the customer does not have
/// a currency set, on subscription creation, we set the customer's currency to be
/// the `invoicing_currency` of the plan.
///
/// ## Customize your customer's subscriptions
///
/// Prices and adjustments in a plan can be added, removed, or replaced for the subscription
/// being created. This is useful when a customer has prices that differ from the
/// default prices for a specific plan.
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
/// This is equivalent to creating a price interval with the [add/edit price intervals
/// endpoint](/api-reference/price-interval/add-or-edit-price-intervals). If unspecified,
/// the start or end date of the phase or subscription will be used.
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
/// If unspecified, the start or end date of the phase or subscription will be used.
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
/// prices. (See [Customize your customer's subscriptions](/api-reference/subscription/create-subscription)) </Note>
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
/// ### Maximums and Minimums Minimums and maximums, much like price overrides, can
/// be useful when a new customer has negotiated a new or different minimum or maximum
/// spend cap than the default for a given price. If one exists for a price and null
/// is provided for the minimum/maximum override on creation, then there will be no
/// minimum/maximum on the new subscription. If no value is provided, then the default
/// price maximum or minimum is used.
///
/// To add a minimum for a specific price, add `minimum_amount` to the specific price
/// in the `price_overrides` object.
///
/// To add a maximum for a specific price, add `maximum_amount` to the specific price
/// in the `price_overrides` object.
///
/// ### Minimum override example
///
/// Price minimum override example:
///
/// ```json {   ...   "id": "price_id",   "model_type": "unit",   "unit_config": {
///     "unit_amount": "0.50"   },   "minimum_amount": "100.00"   ... } ```
///
/// Removing an existing minimum example ```json {   ...   "id": "price_id",   "model_type":
/// "unit",   "unit_config": {     "unit_amount": "0.50"   },   "minimum_amount":
/// null   ... } ```
///
/// ### Discounts Discounts, like price overrides, can be useful when a new customer
/// has negotiated a new or different discount than the default for a price. If a
/// discount exists for a price and a null discount is provided on creation, then
/// there will be no discount on the new subscription.
///
/// To add a discount for a specific price, add `discount` to the price in the `price_overrides`
/// object. Discount should be a dictionary of the format: ```ts {   "discount_type":
/// "amount" | "percentage" | "usage",   "amount_discount": string,   "percentage_discount":
/// string,   "usage_discount": string } ``` where either `amount_discount`, `percentage_discount`,
/// or `usage_discount` is provided.
///
/// Price discount example ```json {   ...   "id": "price_id",   "model_type": "unit",
///   "unit_config": {     "unit_amount": "0.50"   },   "discount": {"discount_type":
/// "amount", "amount_discount": "175"}, } ```
///
/// Removing an existing discount example ```json {   "customer_id": "customer_id",
///   "plan_id": "plan_id",   "discount": null,   "price_overrides": [ ... ]   ...
/// } ```
///
/// ## Threshold Billing
///
/// Orb supports invoicing for a subscription when a preconfigured usage threshold
/// is hit. To enable threshold billing, pass in an `invoicing_threshold`, which is
/// specified in the subscription's invoicing currency, when creating a subscription.
/// E.g. pass in `10.00` to issue an invoice when usage amounts hit \$10.00 for a
/// subscription that invoices in USD.
/// </summary>
public sealed record class SubscriptionCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

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

    public bool? AlignBillingWithSubscriptionStartDate
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "align_billing_with_subscription_start_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["align_billing_with_subscription_start_date"] =
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

    public string? AwsRegion
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("aws_region", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["aws_region"] = JsonSerializer.SerializeToElement(
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
    /// The currency to use for the subscription. If not specified, the invoicing
    /// currency for the plan will be used.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? CustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["customer_id"] = JsonSerializer.SerializeToElement(
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

    public DateTime? EndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ExternalCustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, ExternalMarketplace>? ExternalMarketplace
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_marketplace", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ExternalMarketplace>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["external_marketplace"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ExternalMarketplaceReportingID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "external_marketplace_reporting_id",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["external_marketplace_reporting_id"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
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
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["name"] = JsonSerializer.SerializeToElement(
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
    /// Specifies which version of the plan to subscribe to. If null, the default
    /// version will be used.
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

    public DateTime? StartDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["start_date"] = JsonSerializer.SerializeToElement(
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
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/subscriptions")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
