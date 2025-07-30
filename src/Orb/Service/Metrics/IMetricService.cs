using System.Threading.Tasks;
using Orb.Models.Metrics;

namespace Orb.Service.Metrics;

public interface IMetricService
{
    /// <summary>
    /// This endpoint is used to create a [metric](/core-concepts###metric) using a
    /// SQL string. See [SQL support](/extensibility/advanced-metrics#sql-support)
    /// for a description of constructing SQL queries with examples.
    /// </summary>
    Task<BillableMetric> Create(MetricCreateParams @params);

    /// <summary>
    /// This endpoint allows you to update the `metadata` property on a metric. If
    /// you pass `null` for the metadata value, it will clear any existing metadata
    /// for that invoice.
    /// </summary>
    Task<BillableMetric> Update(MetricUpdateParams @params);

    /// <summary>
    /// This endpoint is used to fetch [metric](/core-concepts##metric) details given
    /// a metric identifier. It returns information about the metrics including its
    /// name, description, and item.
    /// </summary>
    Task<MetricListPageResponse> List(MetricListParams @params);

    /// <summary>
    /// This endpoint is used to list [metrics](/core-concepts#metric). It returns
    /// information about the metrics including its name, description, and item.
    /// </summary>
    Task<BillableMetric> Fetch(MetricFetchParams @params);
}
