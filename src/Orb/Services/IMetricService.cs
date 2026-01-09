using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Metrics;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMetricService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMetricServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetricService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint is used to create a [metric](/core-concepts###metric) using
    /// a SQL string. See [SQL support](/extensibility/advanced-metrics#sql-support)
    /// for a description of constructing SQL queries with examples.
    /// </summary>
    Task<BillableMetric> Create(
        MetricCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to update the `metadata` property on a metric. If
    /// you pass `null` for the metadata value, it will clear any existing metadata
    /// for that invoice.
    /// </summary>
    Task<BillableMetric> Update(
        MetricUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MetricUpdateParams, CancellationToken)"/>
    Task<BillableMetric> Update(
        string metricID,
        MetricUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch [metric](/core-concepts##metric) details given
    /// a metric identifier. It returns information about the metrics including its
    /// name, description, and item.
    /// </summary>
    Task<MetricListPage> List(
        MetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to list [metrics](/core-concepts#metric). It returns
    /// information about the metrics including its name, description, and item.
    /// </summary>
    Task<BillableMetric> Fetch(
        MetricFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(MetricFetchParams, CancellationToken)"/>
    Task<BillableMetric> Fetch(
        string metricID,
        MetricFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMetricService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMetricServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetricServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /metrics`, but is otherwise the
    /// same as <see cref="IMetricService.Create(MetricCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillableMetric>> Create(
        MetricCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /metrics/{metric_id}`, but is otherwise the
    /// same as <see cref="IMetricService.Update(MetricUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillableMetric>> Update(
        MetricUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MetricUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BillableMetric>> Update(
        string metricID,
        MetricUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /metrics`, but is otherwise the
    /// same as <see cref="IMetricService.List(MetricListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MetricListPage>> List(
        MetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /metrics/{metric_id}`, but is otherwise the
    /// same as <see cref="IMetricService.Fetch(MetricFetchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillableMetric>> Fetch(
        MetricFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(MetricFetchParams, CancellationToken)"/>
    Task<HttpResponse<BillableMetric>> Fetch(
        string metricID,
        MetricFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
