using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Prices;

/// <summary>
/// [NOTE] It is recommended to use the `/v1/prices/evaluate` which offers further
/// functionality, such as multiple prices, inline price definitions, and querying
/// over preview events.
///
/// <para>This endpoint is used to evaluate the output of a price for a given customer
/// and time range. It enables filtering and grouping the output using [computed properties](/extensibility/advanced-metrics#computed-properties),
/// supporting the following workflows:</para>
///
/// <para>1. Showing detailed usage and costs to the end customer. 2. Auditing subtotals
/// on invoice line items.</para>
///
/// <para>For these workflows, the expressiveness of computed properties in both
/// the filters and grouping is critical. For example, if you'd like to show your
/// customer their usage grouped by hour and another property, you can do so with
/// the following `grouping_keys`: `["hour_floor_timestamp_millis(timestamp_millis)",
/// "my_property"]`. If you'd like to examine a customer's usage for a specific property
/// value, you can do so with the following `filter`: `my_property = 'foo' AND my_other_property
/// = 'bar'`.</para>
///
/// <para>By default, the start of the time range must be no more than 100 days ago
/// and the length of the results must be no greater than 1000. Note that this is
/// a POST endpoint rather than a GET endpoint because it employs a JSON body rather
/// than query parameters.</para>
/// </summary>
public sealed record class PriceEvaluateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PriceID { get; init; }

    /// <summary>
    /// The exclusive upper bound for event timestamps
    /// </summary>
    public required DateTimeOffset TimeframeEnd
    {
        get
        {
            return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawBodyData, "timeframe_end");
        }
        init { ModelBase.Set(this._rawBodyData, "timeframe_end", value); }
    }

    /// <summary>
    /// The inclusive lower bound for event timestamps
    /// </summary>
    public required DateTimeOffset TimeframeStart
    {
        get
        {
            return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawBodyData, "timeframe_start");
        }
        init { ModelBase.Set(this._rawBodyData, "timeframe_start", value); }
    }

    /// <summary>
    /// The ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? CustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "customer_id"); }
        init { ModelBase.Set(this._rawBodyData, "customer_id", value); }
    }

    /// <summary>
    /// The external customer ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? ExternalCustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "external_customer_id"); }
        init { ModelBase.Set(this._rawBodyData, "external_customer_id", value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the underlying billable metric
    /// </summary>
    public string? Filter
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "filter"); }
        init { ModelBase.Set(this._rawBodyData, "filter", value); }
    }

    /// <summary>
    /// Properties (or [computed properties](/extensibility/advanced-metrics#computed-properties))
    /// used to group the underlying billable metric
    /// </summary>
    public IReadOnlyList<string>? GroupingKeys
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "grouping_keys"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "grouping_keys", value);
        }
    }

    public PriceEvaluateParams() { }

    public PriceEvaluateParams(
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
    PriceEvaluateParams(
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

    public static PriceEvaluateParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/prices/{0}/evaluate", this.PriceID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
