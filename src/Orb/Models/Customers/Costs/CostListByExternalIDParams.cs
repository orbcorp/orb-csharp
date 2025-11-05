using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Costs;

/// <summary>
/// This endpoint is used to fetch a day-by-day snapshot of a customer's costs in
/// Orb, calculated by applying pricing information to the underlying usage (see
/// the [subscription usage endpoint](/api-reference/subscription/fetch-subscription-usage)
/// to fetch usage per metric, in usage units rather than a currency).
///
/// This endpoint can be leveraged for internal tooling and to provide a more transparent
/// billing experience for your end users:
///
/// 1. Understand the cost breakdown per line item historically and in real-time for
/// the current billing period. 2. Provide customer visibility into how different
/// services are contributing to the overall invoice with a per-day   timeseries
/// (as compared to the [upcoming invoice](/api-reference/invoice/fetch-upcoming-invoice)
/// resource,   which represents a snapshot for the current period). 3. Assess how
/// minimums and discounts affect your customers by teasing apart costs directly as
/// a result of usage,   as opposed to minimums and discounts at the plan and price
/// level. 4. Gain insight into key customer health metrics, such as the percent
/// utilization of the minimum committed spend.
///
/// ## Fetching subscriptions By default, this endpoint fetches the currently active
/// subscription for the customer, and returns cost information for the subscription's
/// current billing period, broken down by each participating price. If there are
/// no currently active subscriptions, this will instead default to the most recently
/// active subscription or return an empty series if none are found. For example,
/// if your plan charges for compute hours, job runs, and data syncs, then this endpoint
/// would provide a daily breakdown of your customer's cost for each of those axes.
///
/// If timeframe bounds are specified, Orb fetches all subscriptions that were active
/// in that timeframe. If two subscriptions overlap on a single day, costs from each
/// price will be summed, and prices for both subscriptions will be included in the breakdown.
///
/// ## Prepaid plans For plans that include prices which deduct credits rather than
/// accrue in-arrears charges in a billable currency, this endpoint will return the
/// total deduction amount, in credits, for the specified timeframe.
///
/// ## Cumulative subtotals and totals Since the subtotal and total must factor in
/// any billing-period level discounts and minimums, it's most meaningful to consider
/// costs relative to the start of the subscription's billing period. As a result,
/// by default this endpoint returns cumulative totals since the beginning of the
/// billing period. In particular, the `timeframe_start` of a returned timeframe
/// window is *always* the beginning of the billing period and `timeframe_end` is
/// incremented one day at a time to build the result.
///
/// A customer that uses a few API calls a day but has a minimum commitment might
/// exhibit the following pattern for their subtotal and total in the first few days
/// of the month. Here, we assume that each API call is \$2.50, the customer's plan
/// has a monthly minimum of \$50 for this price, and that the subscription's billing
/// period bounds are aligned to the first of the month:
///
/// | timeframe_start | timeframe_end | Cumulative usage | Subtotal | Total (incl.
/// commitment)  | | -----------| ----------- | ----------- | ----------- |-----------
/// | | 2023-02-01 | 2023-02-02 | 9 | \$22.50 | \$50.00 | | 2023-02-01 | 2023-02-03
/// | 19 | \$47.50 | \$50.00 | | 2023-02-01 | 2023-02-04 | 20 | \$50.00 | \$50.00
/// | | 2023-02-01 | 2023-02-05 | 28 | \$70.00 | \$70.00 | | 2023-02-01 | 2023-02-06
/// | 36 | \$90.00 | \$90.00 |
///
/// ### Periodic values When the query parameter `view_mode=periodic` is specified,
/// Orb will return an incremental day-by-day view of costs. In this case, there
/// will always be a one-day difference between `timeframe_start` and `timeframe_end`
/// for the timeframes returned. This is a transform on top of the cumulative costs,
/// calculated by taking the difference of each timeframe with the last. Note that
/// in the above example, the `Total` value would be 0 for the second two data points,
/// since the minimum commitment has not yet been hit and each day is not contributing
/// anything to the total cost.
///
/// ## Timeframe bounds For an active subscription, both timeframes should be specified
/// in the request. If a subscription starts or ends within the timeframe, the response
/// will only include windows where the subscription is active. If a subscription
/// has ended, no timeframe bounds need to be specified and the response will default
/// to the billing period when the subscription was last active.
///
/// As noted above, `timeframe_start` for a given cumulative datapoint is always
/// the beginning of the billing period, and `timeframe_end` is incremented one day
/// at a time to construct the response. When a timeframe is passed in that is not
/// aligned to the current subscription's billing period, the response will contain
/// cumulative totals from multiple billing periods.
///
/// Suppose the queried customer has a subscription aligned to the 15th of every
/// month. If this endpoint is queried with the date range `2023-06-01` - `2023-07-01`,
/// the first data point will represent about half a billing period's worth of costs,
/// accounting for accruals from the start of the billing period and inclusive of
/// the first day of the timeframe (`timeframe_start = 2023-05-15 00:00:00`, `timeframe_end
/// = 2023-06-02 00:00:00`)
///
/// | datapoint index | timeframe_start | timeframe_end | | ----------- | -----------|
/// ----------- | | 0 | 2023-05-15 | 2023-06-02 | | 1 | 2023-05-15 | 2023-06-03 |
/// | 2 | ... | ... | | 3 | 2023-05-15 | 2023-06-14 | | 4 | 2023-06-15 | 2023-06-16
/// | | 5 | 2023-06-15 | 2023-06-17 | | 6 | ... | ... | | 7 | 2023-06-15 | 2023-07-01 |
///
/// You can see this sliced timeframe visualized [here](https://i.imgur.com/TXhYgme.png).
///
/// ### Matrix prices When a price uses matrix pricing, it's important to view costs
/// grouped by those matrix dimensions. Orb will return `price_groups` with the `grouping_key`
/// and `secondary_grouping_key` based on the matrix price definition, for each `grouping_value`
/// and `secondary_grouping_value` available.
/// </summary>
public sealed record class CostListByExternalIDParams : ParamsBase
{
    public required string ExternalCustomerID { get; init; }

    /// <summary>
    /// The currency or custom pricing unit to use.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._queryProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._queryProperties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Costs returned are exclusive of `timeframe_end`.
    /// </summary>
    public System::DateTime? TimeframeEnd
    {
        get
        {
            if (!this._queryProperties.TryGetValue("timeframe_end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Costs returned are inclusive of `timeframe_start`.
    /// </summary>
    public System::DateTime? TimeframeStart
    {
        get
        {
            if (!this._queryProperties.TryGetValue("timeframe_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Controls whether Orb returns cumulative costs since the start of the billing
    /// period, or incremental day-by-day costs. If your customer has minimums or
    /// discounts, it's strongly recommended that you use the default cumulative behavior.
    /// </summary>
    public ApiEnum<string, ViewModeModel>? ViewMode
    {
        get
        {
            if (!this._queryProperties.TryGetValue("view_mode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ViewModeModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["view_mode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CostListByExternalIDParams() { }

    public CostListByExternalIDParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListByExternalIDParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static CostListByExternalIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties)
        );
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/costs",
                    this.ExternalCustomerID
                )
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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

/// <summary>
/// Controls whether Orb returns cumulative costs since the start of the billing period,
/// or incremental day-by-day costs. If your customer has minimums or discounts, it's
/// strongly recommended that you use the default cumulative behavior.
/// </summary>
[JsonConverter(typeof(ViewModeModelConverter))]
public enum ViewModeModel
{
    Periodic,
    Cumulative,
}

sealed class ViewModeModelConverter : JsonConverter<ViewModeModel>
{
    public override ViewModeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "periodic" => ViewModeModel.Periodic,
            "cumulative" => ViewModeModel.Cumulative,
            _ => (ViewModeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewModeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewModeModel.Periodic => "periodic",
                ViewModeModel.Cumulative => "cumulative",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
