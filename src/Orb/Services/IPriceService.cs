using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Prices;
using Orb.Services.Prices;
using Models = Orb.Models;

namespace Orb.Services;

public interface IPriceService
{
    IPriceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalPriceIDService ExternalPriceID { get; }

    /// <summary>
    /// This endpoint is used to create a [price](/product-catalog/price-configuration).
    /// A price created using this endpoint is always an add-on, meaning that it's
    /// not associated with a specific plan and can instead be individually added
    /// to subscriptions, including subscriptions on different plans.
    ///
    /// <para>An `external_price_id` can be optionally specified as an alias to allow
    /// ergonomic interaction with prices in the Orb API.</para>
    ///
    /// <para>See the [Price resource](/product-catalog/price-configuration) for the
    /// specification of different price model configurations possible in this endpoint.</para>
    /// </summary>
    Task<Models::Price> Create(
        PriceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to update the `metadata` property on a price. If
    /// you pass null for the metadata value, it will clear any existing metadata
    /// for that price.
    /// </summary>
    Task<Models::Price> Update(
        PriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to list all add-on prices created using the [price creation endpoint](/api-reference/price/create-price).
    /// </summary>
    Task<PriceListPageResponse> List(
        PriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// [NOTE] It is recommended to use the `/v1/prices/evaluate` which offers further
    /// functionality, such as multiple prices, inline price definitions, and querying
    /// over preview events.
    ///
    /// <para>This endpoint is used to evaluate the output of a price for a given
    /// customer and time range. It enables filtering and grouping the output using
    /// [computed properties](/extensibility/advanced-metrics#computed-properties),
    /// supporting the following workflows:</para>
    ///
    /// <para>1. Showing detailed usage and costs to the end customer. 2. Auditing
    /// subtotals on invoice line items.</para>
    ///
    /// <para>For these workflows, the expressiveness of computed properties in both
    /// the filters and grouping is critical. For example, if you'd like to show your
    /// customer their usage grouped by hour and another property, you can do so with
    /// the following `grouping_keys`: `["hour_floor_timestamp_millis(timestamp_millis)",
    /// "my_property"]`. If you'd like to examine a customer's usage for a specific
    /// property value, you can do so with the following `filter`: `my_property =
    /// 'foo' AND my_other_property = 'bar'`.</para>
    ///
    /// <para>By default, the start of the time range must be no more than 100 days
    /// ago and the length of the results must be no greater than 1000. Note that
    /// this is a POST endpoint rather than a GET endpoint because it employs a JSON
    /// body rather than query parameters.</para>
    /// </summary>
    Task<PriceEvaluateResponse> Evaluate(
        PriceEvaluateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to evaluate the output of price(s) for a given customer
    /// and time range over ingested events. It enables filtering and grouping the
    /// output using [computed properties](/extensibility/advanced-metrics#computed-properties),
    /// supporting the following workflows:
    ///
    /// <para>1. Showing detailed usage and costs to the end customer. 2. Auditing
    /// subtotals on invoice line items.</para>
    ///
    /// <para>For these workflows, the expressiveness of computed properties in both
    /// the filters and grouping is critical. For example, if you'd like to show your
    /// customer their usage grouped by hour and another property, you can do so with
    /// the following `grouping_keys`: `["hour_floor_timestamp_millis(timestamp_millis)",
    /// "my_property"]`. If you'd like to examine a customer's usage for a specific
    /// property value, you can do so with the following `filter`: `my_property =
    /// 'foo' AND my_other_property = 'bar'`.</para>
    ///
    /// <para>Prices may either reference existing prices in your Orb account or be
    /// defined inline in the request body. Up to 100 prices can be evaluated in
    /// a single request.</para>
    ///
    /// <para>Prices are evaluated on ingested events and the start of the time range
    /// must be no more than 100 days ago. To evaluate based off a set of provided
    /// events, the [evaluate preview events](/api-reference/price/evaluate-preview-events)
    /// endpoint can be used instead.</para>
    ///
    /// <para>Note that this is a POST endpoint rather than a GET endpoint because
    /// it employs a JSON body rather than query parameters.</para>
    /// </summary>
    Task<PriceEvaluateMultipleResponse> EvaluateMultiple(
        PriceEvaluateMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint evaluates prices on preview events instead of actual usage,
    /// making it ideal for building price calculators and cost estimation tools.
    /// You can filter and group results using [computed properties](/extensibility/advanced-metrics#computed-properties)
    /// to analyze pricing across different dimensions.
    ///
    /// <para>Prices may either reference existing prices in your Orb account or be
    /// defined inline in the request body. The endpoint has the following limitations:
    /// 1. Up to 100 prices can be evaluated in a single request. 2. Up to 500 preview
    /// events can be provided in a single request.</para>
    ///
    /// <para>A top-level customer_id is required to evaluate the preview events.
    /// Additionally, all events without a customer_id will have the top-level customer_id added.</para>
    ///
    /// <para>Note that this is a POST endpoint rather than a GET endpoint because
    /// it employs a JSON body rather than query parameters.</para>
    /// </summary>
    Task<PriceEvaluatePreviewEventsResponse> EvaluatePreviewEvents(
        PriceEvaluatePreviewEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a price given an identifier.
    /// </summary>
    Task<Models::Price> Fetch(
        PriceFetchParams parameters,
        CancellationToken cancellationToken = default
    );
}
