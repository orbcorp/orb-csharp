using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.SubscriptionChanges;
using Orb.Models.Subscriptions;

namespace Orb.Services;

public interface ISubscriptionService
{
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// A subscription represents the purchase of a plan by a customer. The customer
    /// is identified by either the `customer_id` or the `external_customer_id`,
    /// and exactly one of these fields must be provided.
    ///
    /// <para>By default, subscriptions begin on the day that they're created and
    /// renew automatically for each billing cycle at the cadence that's configured
    /// in the plan definition.</para>
    ///
    /// <para>The default configuration for subscriptions in Orb is **In-advance billing**
    /// and **Beginning of month alignment** (see [Subscription](/core-concepts##subscription)
    /// for more details).</para>
    ///
    /// <para>In order to change the alignment behavior, Orb also supports billing
    /// subscriptions on the day of the month they are created. If `align_billing_with_subscription_start_date
    /// = true` is specified, subscriptions have billing cycles that are aligned
    /// with their `start_date`. For example, a subscription that begins on January
    /// 15th will have a billing cycle from January 15th to February 15th. Every
    /// subsequent billing cycle will continue to start and invoice on the 15th.</para>
    ///
    /// <para>If the "day" value is greater than the number of days in the month,
    /// the next billing cycle will start at the end of the month. For example, if
    /// the start_date is January 31st, the next billing cycle will start on February 28th.</para>
    ///
    /// <para>If a customer was created with a currency, Orb only allows subscribing
    /// the customer to a plan with a matching `invoicing_currency`. If the customer
    /// does not have a currency set, on subscription creation, we set the customer's
    /// currency to be the `invoicing_currency` of the plan.</para>
    ///
    /// <para>## Customize your customer's subscriptions</para>
    ///
    /// <para>Prices and adjustments in a plan can be added, removed, or replaced
    /// for the subscription being created. This is useful when a customer has prices
    /// that differ from the default prices for a specific plan.</para>
    ///
    /// <para><Note> This feature is only available for accounts that have migrated
    /// to Subscription Overrides Version 2. You can find your Subscription Overrides
    /// Version at the bottom of your [Plans page](https://app.withorb.com/plans) </Note></para>
    ///
    /// <para>### Adding Prices</para>
    ///
    /// <para>To add prices, provide a list of objects with the key `add_prices`.
    /// An object in the list must specify an existing add-on price with a `price_id`
    /// or `external_price_id` field, or create a new add-on price by including an
    /// object with the key `price`, identical to what would be used in the request
    /// body for the [create price endpoint](/api-reference/price/create-price).
    /// See the [Price resource](/product-catalog/price-configuration) for the specification
    /// of different price model configurations possible in this object.</para>
    ///
    /// <para>If the plan has phases, each object in the list must include a number
    /// with `plan_phase_order` key to indicate which phase the price should be added to.</para>
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
    /// in the same API call. However the ID is _transient_ and cannot be used to
    /// refer to the price in future API calls.</para>
    ///
    /// <para>### Removing Prices</para>
    ///
    /// <para>To remove prices, provide a list of objects with the key `remove_prices`.
    /// An object in the list must specify a plan price with either a `price_id`
    /// or `external_price_id` field.</para>
    ///
    /// <para>### Replacing Prices</para>
    ///
    /// <para>To replace prices, provide a list of objects with the key `replace_prices`.
    /// An object in the list must specify a plan price to replace with the `replaces_price_id`
    /// key, and it must specify a price to replace it with by either referencing
    /// an existing add-on price with a `price_id` or `external_price_id` field, or
    /// by creating a new add-on price by including an object with the key `price`,
    /// identical to what would be used in the request body for the [create price
    /// endpoint](/api-reference/price/create-price). See the [Price resource](/product-catalog/price-configuration)
    /// for the specification of different price model configurations possible in
    /// this object.</para>
    ///
    /// <para>For fixed fees, an object in the list can supply a `fixed_price_quantity`
    /// instead of a `price`, `price_id`, or `external_price_id` field. This will
    /// update only the quantity for the price, similar to the [Update price quantity](/api-reference/subscription/update-price-quantity) endpoint.</para>
    ///
    /// <para>The replacement price will have the same phase, if applicable, and the
    /// same start and end dates as the price it replaces.</para>
    ///
    /// <para>An object in the list can specify an optional `minimum_amount`, `maximum_amount`,
    /// or `discounts`. This will create adjustments which apply only to this price.</para>
    ///
    /// <para>Additionally, an object in the list can specify an optional `reference_id`.
    /// This ID can be used to reference the replacement price when [adding an adjustment](#adding-adjustments)
    /// in the same API call. However the ID is _transient_ and cannot be used to
    /// refer to the price in future API calls.</para>
    ///
    /// <para>### Adding adjustments</para>
    ///
    /// <para>To add adjustments, provide a list of objects with the key `add_adjustments`.
    /// An object in the list must include an object with the key `adjustment`, identical
    /// to the adjustment object in the [add/edit price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).</para>
    ///
    /// <para>If the plan has phases, each object in the list must include a number
    /// with `plan_phase_order` key to indicate which phase the adjustment should
    /// be added to.</para>
    ///
    /// <para>An object in the list can specify an optional `start_date` and optional
    /// `end_date`. If unspecified, the start or end date of the phase or subscription
    /// will be used.</para>
    ///
    /// <para>### Removing adjustments</para>
    ///
    /// <para>To remove adjustments, provide a list of objects with the key `remove_adjustments`.
    /// An object in the list must include a key, `adjustment_id`, with the ID of
    /// the adjustment to be removed.</para>
    ///
    /// <para>### Replacing adjustments</para>
    ///
    /// <para>To replace adjustments, provide a list of objects with the key `replace_adjustments`.
    /// An object in the list must specify a plan adjustment to replace with the
    /// `replaces_adjustment_id` key, and it must specify an adjustment to replace
    /// it with by including an object with the key `adjustment`, identical to the
    /// adjustment object in the [add/edit price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).</para>
    ///
    /// <para>The replacement adjustment will have the same phase, if applicable,
    /// and the same start and end dates as the adjustment it replaces.</para>
    ///
    /// <para>## Price overrides (DEPRECATED)</para>
    ///
    /// <para><Note> Price overrides are being phased out in favor adding/removing/replacing
    /// prices. (See [Customize your customer's subscriptions](/api-reference/subscription/create-subscription)) </Note></para>
    ///
    /// <para>Price overrides are used to update some or all prices in a plan for
    /// the specific subscription being created. This is useful when a new customer
    /// has negotiated a rate that is unique to the customer.</para>
    ///
    /// <para>To override prices, provide a list of objects with the key `price_overrides`.
    /// The price object in the list of overrides is expected to contain the existing
    /// price id, the `model_type` and configuration. (See the [Price resource](/product-catalog/price-configuration)
    /// for the specification of different price model configurations.) The numerical
    /// values can be updated, but the billable metric, cadence, type, and name of
    /// a price can not be overridden.</para>
    ///
    /// <para>### Maximums and Minimums Minimums and maximums, much like price overrides,
    /// can be useful when a new customer has negotiated a new or different minimum
    /// or maximum spend cap than the default for a given price. If one exists for
    /// a price and null is provided for the minimum/maximum override on creation,
    /// then there will be no minimum/maximum on the new subscription. If no value
    /// is provided, then the default price maximum or minimum is used.</para>
    ///
    /// <para>To add a minimum for a specific price, add `minimum_amount` to the
    /// specific price in the `price_overrides` object.</para>
    ///
    /// <para>To add a maximum for a specific price, add `maximum_amount` to the
    /// specific price in the `price_overrides` object.</para>
    ///
    /// <para>### Minimum override example</para>
    ///
    /// <para>Price minimum override example:</para>
    ///
    /// <para>```json {   ...   "id": "price_id",   "model_type": "unit",   "unit_config":
    /// {     "unit_amount": "0.50"   },   "minimum_amount": "100.00"   ... } ```</para>
    ///
    /// <para>Removing an existing minimum example ```json {   ...   "id": "price_id",
    ///   "model_type": "unit",   "unit_config": {     "unit_amount": "0.50"   },
    ///   "minimum_amount": null   ... } ```</para>
    ///
    /// <para>### Discounts Discounts, like price overrides, can be useful when a
    /// new customer has negotiated a new or different discount than the default for
    /// a price. If a discount exists for a price and a null discount is provided
    /// on creation, then there will be no discount on the new subscription.</para>
    ///
    /// <para>To add a discount for a specific price, add `discount` to the price
    /// in the `price_overrides` object. Discount should be a dictionary of the format:
    /// ```ts {   "discount_type": "amount" | "percentage" | "usage",   "amount_discount":
    /// string,   "percentage_discount": string,   "usage_discount": string } ```
    /// where either `amount_discount`, `percentage_discount`, or `usage_discount`
    /// is provided.</para>
    ///
    /// <para>Price discount example ```json {   ...   "id": "price_id",   "model_type":
    /// "unit",   "unit_config": {     "unit_amount": "0.50"   },   "discount": {"discount_type":
    /// "amount", "amount_discount": "175"}, } ```</para>
    ///
    /// <para>Removing an existing discount example ```json {   "customer_id": "customer_id",
    ///   "plan_id": "plan_id",   "discount": null,   "price_overrides": [ ... ]
    ///  ... } ```</para>
    ///
    /// <para>## Threshold Billing</para>
    ///
    /// <para>Orb supports invoicing for a subscription when a preconfigured usage
    /// threshold is hit. To enable threshold billing, pass in an `invoicing_threshold`,
    /// which is specified in the subscription's invoicing currency, when creating
    /// a subscription. E.g. pass in `10.00` to issue an invoice when usage amounts
    /// hit \$10.00 for a subscription that invoices in USD.</para>
    /// </summary>
    Task<MutatedSubscription> Create(
        SubscriptionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to update the `metadata`, `net terms`, `auto_collection`,
    /// `invoicing_threshold`, and `default_invoice_memo` properties on a subscription.
    /// </summary>
    Task<Subscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all subscriptions for an account as a [paginated](/api-reference/pagination)
    /// list, ordered starting from the most recently created subscription. For a
    /// full discussion of the subscription resource, see [Subscription](/core-concepts##subscription).
    ///
    /// <para>Subscriptions can be filtered for a specific customer by using either
    /// the customer_id or external_customer_id query parameters. To filter subscriptions
    /// for multiple customers, use the customer_id[] or external_customer_id[] query parameters.</para>
    /// </summary>
    Task<SubscriptionsModel> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to cancel an existing subscription. It returns
    /// the serialized subscription object with an `end_date` parameter that signifies
    /// when the subscription will transition to an ended state.
    ///
    /// <para>The body parameter `cancel_option` determines the cancellation behavior.
    /// Orb supports three cancellation options: - `end_of_subscription_term`: stops
    /// the subscription from auto-renewing. Subscriptions that have been cancelled
    /// with   this option can still incur charges for the remainder of their term:
    ///     - Issuing this cancellation request for a monthly subscription will keep
    /// the subscription active until the start       of the subsequent month, and
    /// potentially issue an invoice for any usage charges incurred in the intervening
    ///       period.     - Issuing this cancellation request for a quarterly subscription
    /// will keep the subscription active until the end       of the quarter and
    /// potentially issue an invoice for any usage charges incurred in the intervening
    /// period.     - Issuing this cancellation request for a yearly subscription
    /// will keep the subscription active for the full       year. For example, a
    /// yearly subscription starting on 2021-11-01 and cancelled on 2021-12-08 will
    /// remain active       until 2022-11-01 and potentially issue charges in the
    /// intervening months for any recurring monthly usage       charges in its plan.
    ///     - **Note**: If a subscription's plan contains prices with difference cadences,
    /// the end of term date will be       determined by the largest cadence value.
    /// For example, cancelling end of term for a subscription with a       quarterly
    /// fixed fee with a monthly usage fee will result in the subscription ending
    /// at the end of the quarter.</para>
    ///
    /// <para>- `immediate`: ends the subscription immediately, setting the `end_date`
    /// to the current time:     - Subscriptions that have been cancelled with this
    /// option will be invoiced immediately. This invoice will       include any usage
    /// fees incurred in the billing period up to the cancellation, along with any
    /// prorated       recurring fees for the billing period, if applicable.
    /// - **Note**: If the subscription has a recurring fee that was paid in-advance,
    /// the prorated amount for the       remaining time period will be added to the
    /// [customer's balance](list-balance-transactions) upon immediate       cancellation.
    /// However, if the customer is ineligible to use the customer balance, the subscription
    /// cannot be       cancelled immediately.</para>
    ///
    /// <para>- `requested_date`: ends the subscription on a specified date, which
    /// requires a `cancellation_date` to be passed in.   If no timezone is provided,
    /// the customer's timezone is used.  For example, a subscription starting on
    /// January 1st   with a monthly price can be set to be cancelled on the first
    /// of any month after January 1st (e.g. March 1st, April   1st, May 1st). A
    /// subscription with multiple prices with different cadences defines the "term"
    /// to be the highest   cadence of the prices.</para>
    ///
    /// <para>Upcoming subscriptions are only eligible for immediate cancellation,
    /// which will set the `end_date` equal to the `start_date` upon cancellation.</para>
    ///
    /// <para>## Backdated cancellations Orb allows you to cancel a subscription
    /// in the past as long as there are no paid invoices between the `requested_date`
    /// and the current time. If the cancellation is after the latest issued invoice,
    /// Orb will generate a balance refund for the current period. If the cancellation
    /// is before the most recently issued invoice, Orb will void the intervening
    /// invoice and generate a new one based on the new dates for the subscription.
    /// See the section on [cancellation behaviors](/product-catalog/creating-subscriptions#cancellation-behaviors).</para>
    /// </summary>
    Task<MutatedSubscription> Cancel(
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a [Subscription](/core-concepts##subscription)
    /// given an identifier.
    /// </summary>
    Task<Subscription> Fetch(
        SubscriptionFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a day-by-day snapshot of a subscription's
    /// costs in Orb, calculated by applying pricing information to the underlying
    /// usage (see the [subscription usage endpoint](fetch-subscription-usage) to
    /// fetch usage per metric, in usage units rather than a currency).
    ///
    /// <para>The semantics of this endpoint exactly mirror those of [fetching a customer's
    /// costs](fetch-customer-costs). Use this endpoint to limit your analysis of
    /// costs to a specific subscription for the customer (e.g. to de-aggregate costs
    /// when a customer's subscription has started and stopped on the same day).</para>
    /// </summary>
    Task<SubscriptionFetchCostsResponse> FetchCosts(
        SubscriptionFetchCostsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a [paginated](/api-reference/pagination) list of all
    /// plans associated with a subscription along with their start and end dates.
    /// This list contains the subscription's initial plan along with past and future
    /// plan changes.
    /// </summary>
    Task<SubscriptionFetchSchedulePageResponse> FetchSchedule(
        SubscriptionFetchScheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a subscription's usage in Orb. Especially
    /// when combined with optional query parameters, this endpoint is a powerful
    /// way to build visualizations on top of Orb's event data and metrics.
    ///
    /// <para>With no query parameters specified, this endpoint returns usage for
    /// the subscription's _current billing period_ across each billable metric that
    /// participates in the subscription. Usage quantities returned are the result
    /// of evaluating the metric definition for the entirety of the customer's billing period.</para>
    ///
    /// <para>### Default response shape Orb returns a `data` array with an object
    /// corresponding to each billable metric. Nested within this object is a `usage`
    /// array which has a `quantity` value and a corresponding `timeframe_start`
    /// and `timeframe_end`.  The `quantity` value represents the calculated usage
    /// value for the billable metric over the specified timeframe (inclusive of
    /// the `timeframe_start` timestamp and exclusive of the `timeframe_end` timestamp).</para>
    ///
    /// <para>Orb will include _every_ window in the response starting from the beginning
    /// of the billing period, even when there were no events (and therefore no usage)
    /// in the window. This increases the size of the response but prevents the caller
    /// from filling in gaps and handling cumbersome time-based logic.</para>
    ///
    /// <para>The query parameters in this endpoint serve to override this behavior
    /// and provide some key functionality, as listed below. Note that this functionality
    /// can also be used _in conjunction_ with each other, e.g. to display grouped
    /// usage on a custom timeframe.</para>
    ///
    /// <para>## Custom timeframe In order to view usage for a custom timeframe rather
    /// than the current billing period, specify a `timeframe_start` and `timeframe_end`.
    /// This will calculate quantities for usage incurred between timeframe_start
    /// (inclusive) and timeframe_end (exclusive), i.e. `[timeframe_start, timeframe_end)`.</para>
    ///
    /// <para>Note: - These timestamps must be specified in ISO 8601 format and UTC
    /// timezone, e.g. `2022-02-01T05:00:00Z`. - Both parameters must be specified
    /// if either is specified.</para>
    ///
    /// <para>## Grouping by custom attributes In order to view a single metric grouped
    /// by a specific _attribute_ that each event is tagged with (e.g. `cluster`),
    /// you must additionally specify a `billable_metric_id` and a `group_by` key.
    /// The `group_by` key denotes the event property on which to group.</para>
    ///
    /// <para>When returning grouped usage, only usage for `billable_metric_id` is
    ///  returned, and a separate object in the `data` array is returned for each
    /// value of the `group_by` key present in your events. The `quantity` value
    /// is the result of evaluating the billable metric for events filtered to a single
    /// value of the `group_by` key.</para>
    ///
    /// <para>Orb expects that events that match the billable metric will contain
    /// values in the `properties` dictionary that correspond to the `group_by` key
    /// specified. By default, Orb will not return a `null` group (i.e. events that
    /// match the metric but do not have the key set). Currently, it is only possible
    /// to view usage grouped by a single attribute at a time.</para>
    ///
    /// <para> When viewing grouped usage, Orb uses pagination to limit the response
    /// size to 1000 groups by default. If there are more  groups for a given subscription,
    /// pagination metadata in the response can be used to fetch all of the data.</para>
    ///
    /// <para>The following example shows usage for an "API Requests" billable metric
    /// grouped by `region`. Note the extra `metric_group` dictionary in the response,
    /// which provides metadata about the group:</para>
    ///
    /// <para>```json {     "data": [         {             "usage": [
    ///      {                     "quantity": 0.19291,                     "timeframe_start":
    /// "2021-10-01T07:00:00Z",                     "timeframe_end": "2021-10-02T07:00:00Z",
    ///                 },                 ...             ],             "metric_group":
    /// {                 "property_key": "region",                 "property_value":
    /// "asia/pacific"             },             "billable_metric": {
    ///       "id": "Fe9pbpMk86xpwdGB",                 "name": "API Requests"
    ///          },             "view_mode": "periodic"         },         ...
    ///   ] } ```</para>
    ///
    /// <para>## Windowed usage The `granularity` parameter can be used to _window_
    /// the usage `quantity` value into periods. When not specified, usage is returned
    /// for the entirety of the time range.</para>
    ///
    /// <para>When `granularity = day` is specified with a timeframe longer than a
    /// day, Orb will return a `quantity` value for each full day between `timeframe_start`
    /// and `timeframe_end`. Note that the days are demarcated by the _customer's
    /// local midnight_.</para>
    ///
    /// <para>For example, with `timeframe_start = 2022-02-01T05:00:00Z`, `timeframe_end
    /// = 2022-02-04T01:00:00Z` and `granularity=day`, the following windows will
    /// be returned for a customer in the `America/Los_Angeles` timezone since local
    /// midnight is `08:00` UTC: - `[2022-02-01T05:00:00Z, 2022-02-01T08:00:00Z)`
    /// - `[2022-02-01T08:00:00, 2022-02-02T08:00:00Z)` - `[2022-02-02T08:00:00,
    /// 2022-02-03T08:00:00Z)` - `[2022-02-03T08:00:00, 2022-02-04T01:00:00Z)`</para>
    ///
    /// <para>```json {     "data": [         {             "billable_metric": {
    ///                "id": "Q8w89wjTtBdejXKsm",                 "name": "API Requests"
    ///             },             "usage": [                 {
    ///    "quantity": 0,                     "timeframe_end": "2022-02-01T08:00:00+00:00",
    ///                     "timeframe_start": "2022-02-01T05:00:00+00:00"
    ///           },                 {</para>
    ///
    /// <para>                    "quantity": 0,                     "timeframe_end":
    /// "2022-02-02T08:00:00+00:00",                     "timeframe_start": "2022-02-01T08:00:00+00:00"
    ///                 },                 {                     "quantity": 0,
    ///                    "timeframe_end": "2022-02-03T08:00:00+00:00",
    ///             "timeframe_start": "2022-02-02T08:00:00+00:00"
    ///   },                 {                     "quantity": 0,
    ///      "timeframe_end": "2022-02-04T01:00:00+00:00",                     "timeframe_start":
    /// "2022-02-03T08:00:00+00:00"                 }             ],
    /// "view_mode": "periodic"         },         ...     ] } ```</para>
    ///
    /// <para>## Decomposable vs. non-decomposable metrics Billable metrics fall
    /// into one of two categories: decomposable and non-decomposable. A decomposable
    /// billable metric, such as a sum or a count, can be displayed and aggregated
    /// across arbitrary timescales. On the other hand, a non-decomposable metric
    /// is not meaningful when only a slice of the billing window is considered.</para>
    ///
    /// <para>As an example, if we have a billable metric that's defined to count
    /// unique users, displaying a graph of unique users for each day is not representative
    /// of the billable metric value over the month (days could have an overlapping
    /// set of 'unique' users). Instead, what's useful for any given day is the number
    /// of unique users in the billing period so far, which are the _cumulative_ unique users.</para>
    ///
    /// <para>Accordingly, this endpoint returns treats these two types of metrics
    /// differently when `group_by` is specified: - Decomposable metrics can be grouped
    /// by any event property. - Non-decomposable metrics can only be grouped by the
    /// corresponding price's invoice grouping key. If no invoice grouping key is
    /// present, the metric does not support `group_by`.</para>
    ///
    /// <para>## Matrix prices When a billable metric is attached to a price that
    /// uses matrix pricing, it's important to view usage grouped by those matrix
    /// dimensions. In this case, use the query parameters `first_dimension_key`,
    /// `first_dimension_value` and `second_dimension_key`, `second_dimension_value`
    /// while filtering to a specific `billable_metric_id`.</para>
    ///
    /// <para>For example, if your compute metric has a separate unit price (i.e.
    /// a matrix pricing model) per `region` and `provider`, your request might provide
    /// the following parameters:</para>
    ///
    /// <para>- `first_dimension_key`: `region` - `first_dimension_value`: `us-east-1`
    /// - `second_dimension_key`: `provider` - `second_dimension_value`: `aws`</para>
    /// </summary>
    Task<SubscriptionUsage> FetchUsage(
        SubscriptionFetchUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to add and edit subscription [price intervals](/api-reference/price-interval/add-or-edit-price-intervals).
    /// By making modifications to a subscription’s price intervals, you can [flexibly
    /// and atomically control the billing behavior of a subscription](/product-catalog/modifying-subscriptions).
    ///
    /// <para>## Adding price intervals</para>
    ///
    /// <para>Prices can be added as price intervals to a subscription by specifying
    /// them in the `add` array. A `price_id` or `external_price_id` from an add-on
    /// price or previously removed plan price can be specified to reuse an existing
    /// price definition (however, please note that prices from other plans cannot
    /// be added to the subscription). Additionally, a new price can be specified
    /// using the `price` field — this price will be created automatically.</para>
    ///
    /// <para>A `start_date` must be specified for the price interval. This is the
    /// date when the price will start billing on the subscription, so this will notably
    /// result in an immediate charge at this time for any billed in advance fixed
    /// fees. The `end_date` will default to null, resulting in a price interval
    /// that will bill on a continually recurring basis. Both of these dates can be
    /// set in the past or the future and Orb will generate or modify invoices to
    /// ensure the subscription’s invoicing behavior is correct.</para>
    ///
    /// <para>Additionally, a discount, minimum, or maximum can be specified on the
    /// price interval. This will only apply to this price interval, not any other
    /// price intervals on the subscription.</para>
    ///
    /// <para>## Adjustment intervals</para>
    ///
    /// <para>An adjustment interval represents the time period that a particular
    /// adjustment (a discount, minimum, or maximum) applies to the prices on a subscription.
    /// Adjustment intervals can be added to a subscription by specifying them in
    /// the `add_adjustments` array, or modified via the `edit_adjustments` array.
    /// When creating an adjustment interval, you'll need to provide the definition
    /// of the new adjustment (the type of adjustment, and which prices it applies
    /// to), as well as the start and end dates for the adjustment interval. The
    /// start and end dates of an existing adjustment interval can be edited via the
    /// `edit_adjustments` field (just like price intervals). (To "change" the amount
    /// of a discount, minimum, or maximum, then, you'll need to end the existing
    /// interval, and create a new adjustment interval with the new amount and a
    /// start date that matches the end date of the previous interval.)</para>
    ///
    /// <para>## Editing price intervals</para>
    ///
    /// <para>Price intervals can be adjusted by specifying edits to make in the
    /// `edit` array. A `price_interval_id` to edit must be specified — this can
    /// be retrieved from the `price_intervals` field on the subscription.</para>
    ///
    /// <para>A new `start_date` or `end_date` can be specified to change the range
    /// of the price interval, which will modify past or future invoices to ensure
    /// correctness. If either of these dates are unspecified, they will default
    /// to the existing date on the price interval. To remove a price interval entirely
    /// from a subscription, set the `end_date` to be equivalent to the `start_date`.</para>
    ///
    /// <para>## Fixed fee quantity transitions The fixed fee quantity transitions
    /// for a fixed fee price interval can also be specified when adding or editing
    /// by passing an array for `fixed_fee_quantity_transitions`. A fixed fee quantity
    /// transition must have a `quantity` and an `effective_date`, which is the date
    /// after which the new quantity will be used for billing. If a fixed fee quantity
    /// transition is scheduled at a billing period boundary, the full quantity will
    /// be billed on an invoice with the other prices on the subscription. If the
    /// fixed fee quantity transition is scheduled mid-billing period, the difference
    /// between the existing quantity and quantity specified in the transition will
    /// be prorated for the rest of the billing period and billed immediately, which
    /// will generate a new invoice.</para>
    ///
    /// <para>Notably, the list of fixed fee quantity transitions passed will overwrite
    /// the existing fixed fee quantity transitions on the price interval, so the
    /// entire list of transitions must be specified to add additional transitions.
    /// The existing list of transitions can be retrieved using the `fixed_fee_quantity_transitions`
    /// property on a subscription’s serialized price intervals.</para>
    /// </summary>
    Task<MutatedSubscription> PriceIntervals(
        SubscriptionPriceIntervalsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Redeem a coupon effective at a given time.
    /// </summary>
    Task<MutatedSubscription> RedeemCoupon(
        SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to change an existing subscription's plan. It returns
    /// the serialized updated subscription object.
    ///
    /// <para>The body parameter `change_option` determines when the plan change occurs.
    /// Orb supports three options: - `end_of_subscription_term`: changes the plan
    /// at the end of the existing plan's term.     - Issuing this plan change request
    /// for a monthly subscription will keep the existing plan active until the start
    ///       of the subsequent month. Issuing this plan change request for a yearly
    /// subscription will keep the existing plan active for       the full year. Charges
    /// incurred in the remaining period will be invoiced as normal.     - Example:
    /// The plan is billed monthly on the 1st of the month, the request is made on
    /// January 15th, so the plan will be       changed on February 1st, and invoice
    /// will be issued on February 1st for the last month of the original plan. -
    /// `immediate`: changes the plan immediately.     - Subscriptions that have their
    /// plan changed with this option will move to the new plan immediately, and be
    /// invoiced       immediately.     - This invoice will include any usage fees
    /// incurred in the billing period up to the change, along with any prorated
    ///      recurring fees for the billing period, if applicable.     - Example:
    /// The plan is billed monthly on the 1st of the month, the request is made on
    /// January 15th, so the plan will be       changed on January 15th, and an invoice
    /// will be issued for the partial month, from January 1 to January 15, on the
    ///       original plan. - `requested_date`: changes the plan on the requested
    /// date (`change_date`).     - If no timezone is provided, the customer's timezone
    /// is used. The `change_date` body parameter is required if this option
    ///   is chosen.     - Example: The plan is billed monthly on the 1st of the
    /// month, the request is made on January 15th, with a requested       `change_date`
    /// of February 15th, so the plan will be changed on February 15th, and invoices
    /// will be issued on February 1st       and February 15th.</para>
    ///
    /// <para>Note that one of `plan_id` or `external_plan_id` is required in the
    /// request body for this operation.</para>
    ///
    /// <para>## Customize your customer's subscriptions</para>
    ///
    /// <para>Prices and adjustments in a plan can be added, removed, or replaced
    /// on the subscription when you schedule the plan change. This is useful when
    /// a customer has prices that differ from the default prices for a specific plan.</para>
    ///
    /// <para><Note> This feature is only available for accounts that have migrated
    /// to Subscription Overrides Version 2. You can find your Subscription Overrides
    /// Version at the bottom of your [Plans page](https://app.withorb.com/plans) </Note></para>
    ///
    /// <para>### Adding Prices</para>
    ///
    /// <para>To add prices, provide a list of objects with the key `add_prices`.
    /// An object in the list must specify an existing add-on price with a `price_id`
    /// or `external_price_id` field, or create a new add-on price by including an
    /// object with the key `price`, identical to what would be used in the request
    /// body for the [create price endpoint](/api-reference/price/create-price).
    /// See the [Price resource](/product-catalog/price-configuration) for the specification
    /// of different price model configurations possible in this object.</para>
    ///
    /// <para>If the plan has phases, each object in the list must include a number
    /// with `plan_phase_order` key to indicate which phase the price should be added to.</para>
    ///
    /// <para>An object in the list can specify an optional `start_date` and optional
    /// `end_date`. If `start_date` is unspecified, the start of the phase / plan
    /// change time will be used. If `end_date` is unspecified, it will finish at
    /// the end of the phase / have no end time.</para>
    ///
    /// <para>An object in the list can specify an optional `minimum_amount`, `maximum_amount`,
    /// or `discounts`. This will create adjustments which apply only to this price.</para>
    ///
    /// <para>Additionally, an object in the list can specify an optional `reference_id`.
    /// This ID can be used to reference this price when [adding an adjustment](#adding-adjustments)
    /// in the same API call. However the ID is _transient_ and cannot be used to
    /// refer to the price in future API calls.</para>
    ///
    /// <para>### Removing Prices</para>
    ///
    /// <para>To remove prices, provide a list of objects with the key `remove_prices`.
    /// An object in the list must specify a plan price with either a `price_id`
    /// or `external_price_id` field.</para>
    ///
    /// <para>### Replacing Prices</para>
    ///
    /// <para>To replace prices, provide a list of objects with the key `replace_prices`.
    /// An object in the list must specify a plan price to replace with the `replaces_price_id`
    /// key, and it must specify a price to replace it with by either referencing
    /// an existing add-on price with a `price_id` or `external_price_id` field, or
    /// by creating a new add-on price by including an object with the key `price`,
    /// identical to what would be used in the request body for the [create price
    /// endpoint](/api-reference/price/create-price). See the [Price resource](/product-catalog/price-configuration)
    /// for the specification of different price model configurations possible in
    /// this object.</para>
    ///
    /// <para>For fixed fees, an object in the list can supply a `fixed_price_quantity`
    /// instead of a `price`, `price_id`, or `external_price_id` field. This will
    /// update only the quantity for the price, similar to the [Update price quantity](/api-reference/subscription/update-price-quantity) endpoint.</para>
    ///
    /// <para>The replacement price will have the same phase, if applicable, and the
    /// same start and end dates as the price it replaces.</para>
    ///
    /// <para>An object in the list can specify an optional `minimum_amount`, `maximum_amount`,
    /// or `discounts`. This will create adjustments which apply only to this price.</para>
    ///
    /// <para>Additionally, an object in the list can specify an optional `reference_id`.
    /// This ID can be used to reference the replacement price when [adding an adjustment](#adding-adjustments)
    /// in the same API call. However the ID is _transient_ and cannot be used to
    /// refer to the price in future API calls.</para>
    ///
    /// <para>### Adding adjustments</para>
    ///
    /// <para>To add adjustments, provide a list of objects with the key `add_adjustments`.
    /// An object in the list must include an object with the key `adjustment`, identical
    /// to the adjustment object in the [add/edit price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).</para>
    ///
    /// <para>If the plan has phases, each object in the list must include a number
    /// with `plan_phase_order` key to indicate which phase the adjustment should
    /// be added to.</para>
    ///
    /// <para>An object in the list can specify an optional `start_date` and optional
    /// `end_date`. If `start_date` is unspecified, the start of the phase / plan
    /// change time will be used. If `end_date` is unspecified, it will finish at
    /// the end of the phase / have no end time.</para>
    ///
    /// <para>### Removing adjustments</para>
    ///
    /// <para>To remove adjustments, provide a list of objects with the key `remove_adjustments`.
    /// An object in the list must include a key, `adjustment_id`, with the ID of
    /// the adjustment to be removed.</para>
    ///
    /// <para>### Replacing adjustments</para>
    ///
    /// <para>To replace adjustments, provide a list of objects with the key `replace_adjustments`.
    /// An object in the list must specify a plan adjustment to replace with the
    /// `replaces_adjustment_id` key, and it must specify an adjustment to replace
    /// it with by including an object with the key `adjustment`, identical to the
    /// adjustment object in the [add/edit price intervals endpoint](/api-reference/price-interval/add-or-edit-price-intervals).</para>
    ///
    /// <para>The replacement adjustment will have the same phase, if applicable,
    /// and the same start and end dates as the adjustment it replaces.</para>
    ///
    /// <para>## Price overrides (DEPRECATED)</para>
    ///
    /// <para><Note> Price overrides are being phased out in favor adding/removing/replacing
    /// prices. (See [Customize your customer's subscriptions](/api-reference/subscription/schedule-plan-change)) </Note></para>
    ///
    /// <para>Price overrides are used to update some or all prices in a plan for
    /// the specific subscription being created. This is useful when a new customer
    /// has negotiated a rate that is unique to the customer.</para>
    ///
    /// <para>To override prices, provide a list of objects with the key `price_overrides`.
    /// The price object in the list of overrides is expected to contain the existing
    /// price id, the `model_type` and configuration. (See the [Price resource](/product-catalog/price-configuration)
    /// for the specification of different price model configurations.) The numerical
    /// values can be updated, but the billable metric, cadence, type, and name of
    /// a price can not be overridden.</para>
    ///
    /// <para>### Maximums, and minimums Price overrides are used to update some or
    /// all prices in the target plan. Minimums and maximums, much like price overrides,
    /// can be useful when a new customer has negotiated a new or different minimum
    /// or maximum spend cap than the default for the plan. The request format for
    /// maximums and minimums is the same as those in [subscription creation](create-subscription).</para>
    ///
    /// <para>## Scheduling multiple plan changes When scheduling multiple plan changes
    /// with the same date, the latest plan change on that day takes effect.</para>
    ///
    /// <para>## Prorations for in-advance fees By default, Orb calculates the prorated
    /// difference in any fixed fees when making a plan change, adjusting the customer
    /// balance as needed. For details on this behavior, see [Modifying subscriptions](/product-catalog/modifying-subscriptions#prorations-for-in-advance-fees).</para>
    /// </summary>
    Task<MutatedSubscription> SchedulePlanChange(
        SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Manually trigger a phase, effective the given date (or the current time,
    /// if not specified).
    /// </summary>
    Task<MutatedSubscription> TriggerPhase(
        SubscriptionTriggerPhaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to unschedule any pending cancellations for a subscription.
    ///
    /// <para>To be eligible, the subscription must currently be active and have a
    /// future cancellation. This operation will turn on auto-renew, ensuring that
    /// the subscription does not end at the currently scheduled cancellation time.</para>
    /// </summary>
    Task<MutatedSubscription> UnscheduleCancellation(
        SubscriptionUnscheduleCancellationParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to clear scheduled updates to the quantity for a
    /// fixed fee.
    ///
    /// <para>If there are no updates scheduled, a request validation error will be
    /// returned with a 400 status code.</para>
    /// </summary>
    Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to unschedule any pending plan changes on an existing
    /// subscription. When called, all upcoming plan changes will be unscheduled.
    /// </summary>
    Task<MutatedSubscription> UnschedulePendingPlanChanges(
        SubscriptionUnschedulePendingPlanChangesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to update the quantity for a fixed fee.
    ///
    /// <para>To be eligible, the subscription must currently be active and the price
    /// specified must be a fixed fee (not usage-based). This operation will immediately
    /// update the quantity for the fee, or if a `effective_date` is passed in, will
    /// update the quantity on the requested date at midnight in the customer's timezone.</para>
    ///
    /// <para>In order to change the fixed fee quantity as of the next draft invoice
    /// for this subscription, pass `change_option=upcoming_invoice` without an `effective_date` specified.</para>
    ///
    /// <para>If the fee is an in-advance fixed fee, it will also issue an immediate
    /// invoice for the difference for the remainder of the billing period.</para>
    /// </summary>
    Task<MutatedSubscription> UpdateFixedFeeQuantity(
        SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to update the trial end date for a subscription. The
    /// new trial end date must be within the time range of the current plan (i.e.
    /// the new trial end date must be on or after the subscription's start date on
    /// the current plan, and on or before the subscription end date).
    ///
    /// <para>In order to retroactively remove a trial completely, the end date can
    /// be set to the transition date of the subscription to this plan (or, if this
    /// is the first plan for this subscription, the subscription's start date).
    /// In order to end a trial immediately, the keyword `immediate` can be provided
    /// as the trial end date.</para>
    ///
    /// <para>By default, Orb will shift only the trial end date (and price intervals
    /// that start or end on the previous trial end date), and leave all other future
    /// price intervals untouched. If the `shift` parameter is set to `true`, Orb
    /// will shift all subsequent price and adjustment intervals by the same amount
    /// as the trial end date shift (so, e.g., if a plan change is scheduled or an
    /// add-on price was added, that change will be pushed back by the same amount
    /// of time the trial is extended).</para>
    /// </summary>
    Task<MutatedSubscription> UpdateTrial(
        SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    );
}
