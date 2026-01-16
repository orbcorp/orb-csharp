using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PriceEvaluateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>("timeframe_end");
        }
        init { this._rawBodyData.Set("timeframe_end", value); }
    }

    /// <summary>
    /// The inclusive lower bound for event timestamps
    /// </summary>
    public required DateTimeOffset TimeframeStart
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>("timeframe_start");
        }
        init { this._rawBodyData.Set("timeframe_start", value); }
    }

    /// <summary>
    /// The ID of the customer to which this evaluation is scoped.
    /// </summary>
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
    /// The external customer ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_customer_id");
        }
        init { this._rawBodyData.Set("external_customer_id", value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the underlying billable metric
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
    /// Properties (or [computed properties](/extensibility/advanced-metrics#computed-properties))
    /// used to group the underlying billable metric
    /// </summary>
    public IReadOnlyList<string>? GroupingKeys
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("grouping_keys");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "grouping_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PriceEvaluateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriceEvaluateParams(PriceEvaluateParams priceEvaluateParams)
        : base(priceEvaluateParams)
    {
        this.PriceID = priceEvaluateParams.PriceID;

        this._rawBodyData = new(priceEvaluateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PriceEvaluateParams(
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
    PriceEvaluateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["PriceID"] = this.PriceID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PriceEvaluateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PriceID?.Equals(other.PriceID) ?? other.PriceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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
