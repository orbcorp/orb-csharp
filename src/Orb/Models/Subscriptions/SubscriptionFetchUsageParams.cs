using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to fetch a subscription's usage in Orb. Especially when
/// combined with optional query parameters, this endpoint is a powerful way to build
/// visualizations on top of Orb's event data and metrics.
///
/// <para>With no query parameters specified, this endpoint returns usage for the
/// subscription's _current billing period_ across each billable metric that participates
/// in the subscription. Usage quantities returned are the result of evaluating the
/// metric definition for the entirety of the customer's billing period.</para>
///
/// <para>### Default response shape Orb returns a `data` array with an object corresponding
/// to each billable metric. Nested within this object is a `usage` array which has
/// a `quantity` value and a corresponding `timeframe_start` and `timeframe_end`.
///  The `quantity` value represents the calculated usage value for the billable metric
/// over the specified timeframe (inclusive of the `timeframe_start` timestamp and
/// exclusive of the `timeframe_end` timestamp).</para>
///
/// <para>Orb will include _every_ window in the response starting from the beginning
/// of the billing period, even when there were no events (and therefore no usage)
/// in the window. This increases the size of the response but prevents the caller
/// from filling in gaps and handling cumbersome time-based logic.</para>
///
/// <para>The query parameters in this endpoint serve to override this behavior and
/// provide some key functionality, as listed below. Note that this functionality
/// can also be used _in conjunction_ with each other, e.g. to display grouped usage
/// on a custom timeframe.</para>
///
/// <para>## Custom timeframe In order to view usage for a custom timeframe rather
/// than the current billing period, specify a `timeframe_start` and `timeframe_end`.
/// This will calculate quantities for usage incurred between timeframe_start (inclusive)
/// and timeframe_end (exclusive), i.e. `[timeframe_start, timeframe_end)`.</para>
///
/// <para>Note: - These timestamps must be specified in ISO 8601 format and UTC timezone,
/// e.g. `2022-02-01T05:00:00Z`. - Both parameters must be specified if either is specified.</para>
///
/// <para>## Grouping by custom attributes In order to view a single metric grouped
/// by a specific _attribute_ that each event is tagged with (e.g. `cluster`), you
/// must additionally specify a `billable_metric_id` and a `group_by` key. The `group_by`
/// key denotes the event property on which to group.</para>
///
/// <para>When returning grouped usage, only usage for `billable_metric_id` is  returned,
/// and a separate object in the `data` array is returned for each value of the `group_by`
/// key present in your events. The `quantity` value is the result of evaluating the
/// billable metric for events filtered to a single value of the `group_by` key.</para>
///
/// <para>Orb expects that events that match the billable metric will contain values
/// in the `properties` dictionary that correspond to the `group_by` key specified.
/// By default, Orb will not return a `null` group (i.e. events that match the metric
/// but do not have the key set). Currently, it is only possible to view usage grouped
/// by a single attribute at a time.</para>
///
/// <para> When viewing grouped usage, Orb uses pagination to limit the response size
/// to 1000 groups by default. If there are more  groups for a given subscription,
/// pagination metadata in the response can be used to fetch all of the data.</para>
///
/// <para>The following example shows usage for an "API Requests" billable metric
/// grouped by `region`. Note the extra `metric_group` dictionary in the response,
/// which provides metadata about the group:</para>
///
/// <para>```json {     "data": [         {             "usage": [
///  {                     "quantity": 0.19291,                     "timeframe_start":
/// "2021-10-01T07:00:00Z",                     "timeframe_end": "2021-10-02T07:00:00Z",
///                 },                 ...             ],             "metric_group":
/// {                 "property_key": "region",                 "property_value":
/// "asia/pacific"             },             "billable_metric": {
///   "id": "Fe9pbpMk86xpwdGB",                 "name": "API Requests"
///  },             "view_mode": "periodic"         },         ...     ] } ```</para>
///
/// <para>## Windowed usage The `granularity` parameter can be used to _window_ the
/// usage `quantity` value into periods. When not specified, usage is returned for
/// the entirety of the time range.</para>
///
/// <para>When `granularity = day` is specified with a timeframe longer than a day,
/// Orb will return a `quantity` value for each full day between `timeframe_start`
/// and `timeframe_end`. Note that the days are demarcated by the _customer's local midnight_.</para>
///
/// <para>For example, with `timeframe_start = 2022-02-01T05:00:00Z`, `timeframe_end
/// = 2022-02-04T01:00:00Z` and `granularity=day`, the following windows will be
/// returned for a customer in the `America/Los_Angeles` timezone since local midnight
/// is `08:00` UTC: - `[2022-02-01T05:00:00Z, 2022-02-01T08:00:00Z)` - `[2022-02-01T08:00:00,
/// 2022-02-02T08:00:00Z)` - `[2022-02-02T08:00:00, 2022-02-03T08:00:00Z)` - `[2022-02-03T08:00:00, 2022-02-04T01:00:00Z)`</para>
///
/// <para>```json {     "data": [         {             "billable_metric": {
///            "id": "Q8w89wjTtBdejXKsm",                 "name": "API Requests"
///             },             "usage": [                 {                     "quantity":
/// 0,                     "timeframe_end": "2022-02-01T08:00:00+00:00",
///             "timeframe_start": "2022-02-01T05:00:00+00:00"                 },
///                 {</para>
///
/// <para>                    "quantity": 0,                     "timeframe_end":
/// "2022-02-02T08:00:00+00:00",                     "timeframe_start": "2022-02-01T08:00:00+00:00"
///                 },                 {                     "quantity": 0,
///                "timeframe_end": "2022-02-03T08:00:00+00:00",
///     "timeframe_start": "2022-02-02T08:00:00+00:00"                 },
///         {                     "quantity": 0,                     "timeframe_end":
/// "2022-02-04T01:00:00+00:00",                     "timeframe_start": "2022-02-03T08:00:00+00:00"
///                 }             ],             "view_mode": "periodic"
/// },         ...     ] } ```</para>
///
/// <para>## Decomposable vs. non-decomposable metrics Billable metrics fall into
/// one of two categories: decomposable and non-decomposable. A decomposable billable
/// metric, such as a sum or a count, can be displayed and aggregated across arbitrary
/// timescales. On the other hand, a non-decomposable metric is not meaningful when
/// only a slice of the billing window is considered.</para>
///
/// <para>As an example, if we have a billable metric that's defined to count unique
/// users, displaying a graph of unique users for each day is not representative of
/// the billable metric value over the month (days could have an overlapping set of
/// 'unique' users). Instead, what's useful for any given day is the number of unique
/// users in the billing period so far, which are the _cumulative_ unique users.</para>
///
/// <para>Accordingly, this endpoint returns treats these two types of metrics differently
/// when `group_by` is specified: - Decomposable metrics can be grouped by any event
/// property. - Non-decomposable metrics can only be grouped by the corresponding
/// price's invoice grouping key. If no invoice grouping key is present, the metric
/// does not support `group_by`.</para>
///
/// <para>## Matrix prices When a billable metric is attached to a price that uses
/// matrix pricing, it's important to view usage grouped by those matrix dimensions.
/// In this case, use the query parameters `first_dimension_key`, `first_dimension_value`
/// and `second_dimension_key`, `second_dimension_value` while filtering to a specific `billable_metric_id`.</para>
///
/// <para>For example, if your compute metric has a separate unit price (i.e. a matrix
/// pricing model) per `region` and `provider`, your request might provide the following parameters:</para>
///
/// <para>- `first_dimension_key`: `region` - `first_dimension_value`: `us-east-1`
/// - `second_dimension_key`: `provider` - `second_dimension_value`: `aws`</para>
/// </summary>
public sealed record class SubscriptionFetchUsageParams : ParamsBase
{
    public string? SubscriptionID { get; init; }

    /// <summary>
    /// When specified in conjunction with `group_by`, this parameter filters usage
    /// to a single billable metric. Note that both `group_by` and `billable_metric_id`
    /// must be specified together.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawQueryData, "billable_metric_id", value); }
    }

    public string? FirstDimensionKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "first_dimension_key"); }
        init { JsonModel.Set(this._rawQueryData, "first_dimension_key", value); }
    }

    public string? FirstDimensionValue
    {
        get
        {
            return JsonModel.GetNullableClass<string>(this.RawQueryData, "first_dimension_value");
        }
        init { JsonModel.Set(this._rawQueryData, "first_dimension_value", value); }
    }

    /// <summary>
    /// This determines the windowing of usage reporting.
    /// </summary>
    public ApiEnum<string, Granularity>? Granularity
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Granularity>>(
                this.RawQueryData,
                "granularity"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "granularity", value); }
    }

    /// <summary>
    /// Groups per-price usage by the key provided.
    /// </summary>
    public string? GroupBy
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "group_by"); }
        init { JsonModel.Set(this._rawQueryData, "group_by", value); }
    }

    public string? SecondDimensionKey
    {
        get
        {
            return JsonModel.GetNullableClass<string>(this.RawQueryData, "second_dimension_key");
        }
        init { JsonModel.Set(this._rawQueryData, "second_dimension_key", value); }
    }

    public string? SecondDimensionValue
    {
        get
        {
            return JsonModel.GetNullableClass<string>(this.RawQueryData, "second_dimension_value");
        }
        init { JsonModel.Set(this._rawQueryData, "second_dimension_value", value); }
    }

    /// <summary>
    /// Usage returned is exclusive of `timeframe_end`.
    /// </summary>
    public System::DateTimeOffset? TimeframeEnd
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "timeframe_end"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "timeframe_end", value); }
    }

    /// <summary>
    /// Usage returned is inclusive of `timeframe_start`.
    /// </summary>
    public System::DateTimeOffset? TimeframeStart
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "timeframe_start"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "timeframe_start", value); }
    }

    /// <summary>
    /// Controls whether Orb returns cumulative usage since the start of the billing
    /// period, or incremental day-by-day usage. If your customer has minimums or
    /// discounts, it's strongly recommended that you use the default cumulative behavior.
    /// </summary>
    public ApiEnum<string, SubscriptionFetchUsageParamsViewMode>? ViewMode
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
            >(this.RawQueryData, "view_mode");
        }
        init { JsonModel.Set(this._rawQueryData, "view_mode", value); }
    }

    public SubscriptionFetchUsageParams() { }

    public SubscriptionFetchUsageParams(SubscriptionFetchUsageParams subscriptionFetchUsageParams)
        : base(subscriptionFetchUsageParams) { }

    public SubscriptionFetchUsageParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchUsageParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionFetchUsageParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/usage", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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

/// <summary>
/// This determines the windowing of usage reporting.
/// </summary>
[JsonConverter(typeof(GranularityConverter))]
public enum Granularity
{
    Day,
}

sealed class GranularityConverter : JsonConverter<Granularity>
{
    public override Granularity Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => Granularity.Day,
            _ => (Granularity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Granularity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Granularity.Day => "day",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Controls whether Orb returns cumulative usage since the start of the billing
/// period, or incremental day-by-day usage. If your customer has minimums or discounts,
/// it's strongly recommended that you use the default cumulative behavior.
/// </summary>
[JsonConverter(typeof(SubscriptionFetchUsageParamsViewModeConverter))]
public enum SubscriptionFetchUsageParamsViewMode
{
    Periodic,
    Cumulative,
}

sealed class SubscriptionFetchUsageParamsViewModeConverter
    : JsonConverter<SubscriptionFetchUsageParamsViewMode>
{
    public override SubscriptionFetchUsageParamsViewMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "periodic" => SubscriptionFetchUsageParamsViewMode.Periodic,
            "cumulative" => SubscriptionFetchUsageParamsViewMode.Cumulative,
            _ => (SubscriptionFetchUsageParamsViewMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionFetchUsageParamsViewMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionFetchUsageParamsViewMode.Periodic => "periodic",
                SubscriptionFetchUsageParamsViewMode.Cumulative => "cumulative",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
