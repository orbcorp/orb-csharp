using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Prices;

/// <summary>
/// This endpoint evaluates prices on preview events instead of actual usage, making
/// it ideal for building price calculators and cost estimation tools. You can filter
/// and group results using [computed properties](/extensibility/advanced-metrics#computed-properties)
/// to analyze pricing across different dimensions.
///
/// <para>Prices may either reference existing prices in your Orb account or be defined
/// inline in the request body. The endpoint has the following limitations: 1. Up
/// to 100 prices can be evaluated in a single request. 2. Up to 500 preview events
/// can be provided in a single request.</para>
///
/// <para>A top-level customer_id is required to evaluate the preview events. Additionally,
/// all events without a customer_id will have the top-level customer_id added.</para>
///
/// <para>Note that this is a POST endpoint rather than a GET endpoint because it
/// employs a JSON body rather than query parameters.</para>
/// </summary>
public sealed record class PriceEvaluatePreviewEventsParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The exclusive upper bound for event timestamps
    /// </summary>
    public required System::DateTimeOffset TimeframeEnd
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawBodyData,
                "timeframe_end"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "timeframe_end", value); }
    }

    /// <summary>
    /// The inclusive lower bound for event timestamps
    /// </summary>
    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawBodyData,
                "timeframe_start"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "timeframe_start", value); }
    }

    /// <summary>
    /// The ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? CustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "customer_id"); }
        init { JsonModel.Set(this._rawBodyData, "customer_id", value); }
    }

    /// <summary>
    /// List of preview events to use instead of actual usage data
    /// </summary>
    public IReadOnlyList<Event>? Events
    {
        get { return JsonModel.GetNullableClass<List<Event>>(this.RawBodyData, "events"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "events", value);
        }
    }

    /// <summary>
    /// The external customer ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? ExternalCustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "external_customer_id"); }
        init { JsonModel.Set(this._rawBodyData, "external_customer_id", value); }
    }

    /// <summary>
    /// List of prices to evaluate (max 100)
    /// </summary>
    public IReadOnlyList<PriceEvaluatePreviewEventsParamsPriceEvaluation>? PriceEvaluations
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<PriceEvaluatePreviewEventsParamsPriceEvaluation>
            >(this.RawBodyData, "price_evaluations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "price_evaluations", value);
        }
    }

    public PriceEvaluatePreviewEventsParams() { }

    public PriceEvaluatePreviewEventsParams(
        PriceEvaluatePreviewEventsParams priceEvaluatePreviewEventsParams
    )
        : base(priceEvaluatePreviewEventsParams)
    {
        this._rawBodyData = [.. priceEvaluatePreviewEventsParams._rawBodyData];
    }

    public PriceEvaluatePreviewEventsParams(
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
    PriceEvaluatePreviewEventsParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParams FromRawUnchecked(
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/prices/evaluate_preview_events"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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
}

[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
    /// <summary>
    /// A name to meaningfully identify the action or event type.
    /// </summary>
    public required string EventName
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "event_name"); }
        init { JsonModel.Set(this._rawData, "event_name", value); }
    }

    /// <summary>
    /// A dictionary of custom properties. Values in this dictionary must be numeric,
    /// boolean, or strings. Nested dictionaries are disallowed.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Properties
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "properties"
            );
        }
        init { JsonModel.Set(this._rawData, "properties", value); }
    }

    /// <summary>
    /// An ISO 8601 format date with no timezone offset (i.e. UTC). This should represent
    /// the time that usage was recorded, and is particularly important to attribute
    /// usage to a given billing period.
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { JsonModel.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The Orb Customer identifier
    /// </summary>
    public string? CustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "customer_id"); }
        init { JsonModel.Set(this._rawData, "customer_id", value); }
    }

    /// <summary>
    /// An alias for the Orb customer, whose mapping is specified when creating the customer
    /// </summary>
    public string? ExternalCustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_customer_id"); }
        init { JsonModel.Set(this._rawData, "external_customer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventName;
        _ = this.Properties;
        _ = this.Timestamp;
        _ = this.CustomerID;
        _ = this.ExternalCustomerID;
    }

    public Event() { }

    public Event(Event event1)
        : base(event1) { }

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluation,
        PriceEvaluatePreviewEventsParamsPriceEvaluationFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluation : JsonModel
{
    /// <summary>
    /// The external ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the underlying billable metric
    /// </summary>
    public string? Filter
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "filter"); }
        init { JsonModel.Set(this._rawData, "filter", value); }
    }

    /// <summary>
    /// Properties (or [computed properties](/extensibility/advanced-metrics#computed-properties))
    /// used to group the underlying billable metric
    /// </summary>
    public IReadOnlyList<string>? GroupingKeys
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "grouping_keys"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "grouping_keys", value);
        }
    }

    /// <summary>
    /// New floating price request body params.
    /// </summary>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice? Price
    {
        get
        {
            return JsonModel.GetNullableClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(
                this.RawData,
                "price"
            );
        }
        init { JsonModel.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// The ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? PriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "price_id"); }
        init { JsonModel.Set(this._rawData, "price_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalPriceID;
        _ = this.Filter;
        _ = this.GroupingKeys;
        this.Price?.Validate();
        _ = this.PriceID;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluation() { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluation(
        PriceEvaluatePreviewEventsParamsPriceEvaluation priceEvaluatePreviewEventsParamsPriceEvaluation
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluation) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluation>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluatePreviewEventsParamsPriceEvaluation.FromRawUnchecked(rawData);
}

/// <summary>
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceConverter))]
public record class PriceEvaluatePreviewEventsParamsPriceEvaluationPrice
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string Currency
    {
        get
        {
            return Match(
                newFloatingUnit: (x) => x.Currency,
                newFloatingTiered: (x) => x.Currency,
                newFloatingBulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newFloatingPackage: (x) => x.Currency,
                newFloatingMatrix: (x) => x.Currency,
                newFloatingThresholdTotalAmount: (x) => x.Currency,
                newFloatingTieredPackage: (x) => x.Currency,
                newFloatingTieredWithMinimum: (x) => x.Currency,
                newFloatingGroupedTiered: (x) => x.Currency,
                newFloatingTieredPackageWithMinimum: (x) => x.Currency,
                newFloatingPackageWithAllocation: (x) => x.Currency,
                newFloatingUnitWithPercent: (x) => x.Currency,
                newFloatingMatrixWithAllocation: (x) => x.Currency,
                newFloatingTieredWithProration: (x) => x.Currency,
                newFloatingUnitWithProration: (x) => x.Currency,
                newFloatingGroupedAllocation: (x) => x.Currency,
                newFloatingBulkWithProration: (x) => x.Currency,
                newFloatingGroupedWithProratedMinimum: (x) => x.Currency,
                newFloatingGroupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newFloatingMatrixWithDisplayName: (x) => x.Currency,
                newFloatingGroupedTieredPackage: (x) => x.Currency,
                newFloatingMaxGroupTieredPackage: (x) => x.Currency,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.Currency,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.Currency,
                newFloatingCumulativeGroupedBulk: (x) => x.Currency,
                cumulativeGroupedAllocation: (x) => x.Currency,
                newFloatingMinimumComposite: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public string ItemID
    {
        get
        {
            return Match(
                newFloatingUnit: (x) => x.ItemID,
                newFloatingTiered: (x) => x.ItemID,
                newFloatingBulk: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newFloatingPackage: (x) => x.ItemID,
                newFloatingMatrix: (x) => x.ItemID,
                newFloatingThresholdTotalAmount: (x) => x.ItemID,
                newFloatingTieredPackage: (x) => x.ItemID,
                newFloatingTieredWithMinimum: (x) => x.ItemID,
                newFloatingGroupedTiered: (x) => x.ItemID,
                newFloatingTieredPackageWithMinimum: (x) => x.ItemID,
                newFloatingPackageWithAllocation: (x) => x.ItemID,
                newFloatingUnitWithPercent: (x) => x.ItemID,
                newFloatingMatrixWithAllocation: (x) => x.ItemID,
                newFloatingTieredWithProration: (x) => x.ItemID,
                newFloatingUnitWithProration: (x) => x.ItemID,
                newFloatingGroupedAllocation: (x) => x.ItemID,
                newFloatingBulkWithProration: (x) => x.ItemID,
                newFloatingGroupedWithProratedMinimum: (x) => x.ItemID,
                newFloatingGroupedWithMeteredMinimum: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newFloatingMatrixWithDisplayName: (x) => x.ItemID,
                newFloatingGroupedTieredPackage: (x) => x.ItemID,
                newFloatingMaxGroupTieredPackage: (x) => x.ItemID,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.ItemID,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.ItemID,
                newFloatingCumulativeGroupedBulk: (x) => x.ItemID,
                cumulativeGroupedAllocation: (x) => x.ItemID,
                newFloatingMinimumComposite: (x) => x.ItemID,
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
                newFloatingUnit: (x) => x.Name,
                newFloatingTiered: (x) => x.Name,
                newFloatingBulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newFloatingPackage: (x) => x.Name,
                newFloatingMatrix: (x) => x.Name,
                newFloatingThresholdTotalAmount: (x) => x.Name,
                newFloatingTieredPackage: (x) => x.Name,
                newFloatingTieredWithMinimum: (x) => x.Name,
                newFloatingGroupedTiered: (x) => x.Name,
                newFloatingTieredPackageWithMinimum: (x) => x.Name,
                newFloatingPackageWithAllocation: (x) => x.Name,
                newFloatingUnitWithPercent: (x) => x.Name,
                newFloatingMatrixWithAllocation: (x) => x.Name,
                newFloatingTieredWithProration: (x) => x.Name,
                newFloatingUnitWithProration: (x) => x.Name,
                newFloatingGroupedAllocation: (x) => x.Name,
                newFloatingBulkWithProration: (x) => x.Name,
                newFloatingGroupedWithProratedMinimum: (x) => x.Name,
                newFloatingGroupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newFloatingMatrixWithDisplayName: (x) => x.Name,
                newFloatingGroupedTieredPackage: (x) => x.Name,
                newFloatingMaxGroupTieredPackage: (x) => x.Name,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.Name,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.Name,
                newFloatingCumulativeGroupedBulk: (x) => x.Name,
                cumulativeGroupedAllocation: (x) => x.Name,
                newFloatingMinimumComposite: (x) => x.Name,
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
                newFloatingUnit: (x) => x.BillableMetricID,
                newFloatingTiered: (x) => x.BillableMetricID,
                newFloatingBulk: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newFloatingPackage: (x) => x.BillableMetricID,
                newFloatingMatrix: (x) => x.BillableMetricID,
                newFloatingThresholdTotalAmount: (x) => x.BillableMetricID,
                newFloatingTieredPackage: (x) => x.BillableMetricID,
                newFloatingTieredWithMinimum: (x) => x.BillableMetricID,
                newFloatingGroupedTiered: (x) => x.BillableMetricID,
                newFloatingTieredPackageWithMinimum: (x) => x.BillableMetricID,
                newFloatingPackageWithAllocation: (x) => x.BillableMetricID,
                newFloatingUnitWithPercent: (x) => x.BillableMetricID,
                newFloatingMatrixWithAllocation: (x) => x.BillableMetricID,
                newFloatingTieredWithProration: (x) => x.BillableMetricID,
                newFloatingUnitWithProration: (x) => x.BillableMetricID,
                newFloatingGroupedAllocation: (x) => x.BillableMetricID,
                newFloatingBulkWithProration: (x) => x.BillableMetricID,
                newFloatingGroupedWithProratedMinimum: (x) => x.BillableMetricID,
                newFloatingGroupedWithMeteredMinimum: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newFloatingMatrixWithDisplayName: (x) => x.BillableMetricID,
                newFloatingGroupedTieredPackage: (x) => x.BillableMetricID,
                newFloatingMaxGroupTieredPackage: (x) => x.BillableMetricID,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.BillableMetricID,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.BillableMetricID,
                newFloatingCumulativeGroupedBulk: (x) => x.BillableMetricID,
                cumulativeGroupedAllocation: (x) => x.BillableMetricID,
                newFloatingMinimumComposite: (x) => x.BillableMetricID,
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
                newFloatingUnit: (x) => x.BilledInAdvance,
                newFloatingTiered: (x) => x.BilledInAdvance,
                newFloatingBulk: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newFloatingPackage: (x) => x.BilledInAdvance,
                newFloatingMatrix: (x) => x.BilledInAdvance,
                newFloatingThresholdTotalAmount: (x) => x.BilledInAdvance,
                newFloatingTieredPackage: (x) => x.BilledInAdvance,
                newFloatingTieredWithMinimum: (x) => x.BilledInAdvance,
                newFloatingGroupedTiered: (x) => x.BilledInAdvance,
                newFloatingTieredPackageWithMinimum: (x) => x.BilledInAdvance,
                newFloatingPackageWithAllocation: (x) => x.BilledInAdvance,
                newFloatingUnitWithPercent: (x) => x.BilledInAdvance,
                newFloatingMatrixWithAllocation: (x) => x.BilledInAdvance,
                newFloatingTieredWithProration: (x) => x.BilledInAdvance,
                newFloatingUnitWithProration: (x) => x.BilledInAdvance,
                newFloatingGroupedAllocation: (x) => x.BilledInAdvance,
                newFloatingBulkWithProration: (x) => x.BilledInAdvance,
                newFloatingGroupedWithProratedMinimum: (x) => x.BilledInAdvance,
                newFloatingGroupedWithMeteredMinimum: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newFloatingMatrixWithDisplayName: (x) => x.BilledInAdvance,
                newFloatingGroupedTieredPackage: (x) => x.BilledInAdvance,
                newFloatingMaxGroupTieredPackage: (x) => x.BilledInAdvance,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.BilledInAdvance,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.BilledInAdvance,
                newFloatingCumulativeGroupedBulk: (x) => x.BilledInAdvance,
                cumulativeGroupedAllocation: (x) => x.BilledInAdvance,
                newFloatingMinimumComposite: (x) => x.BilledInAdvance,
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
                newFloatingUnit: (x) => x.BillingCycleConfiguration,
                newFloatingTiered: (x) => x.BillingCycleConfiguration,
                newFloatingBulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newFloatingPackage: (x) => x.BillingCycleConfiguration,
                newFloatingMatrix: (x) => x.BillingCycleConfiguration,
                newFloatingThresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                newFloatingTieredPackage: (x) => x.BillingCycleConfiguration,
                newFloatingTieredWithMinimum: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedTiered: (x) => x.BillingCycleConfiguration,
                newFloatingTieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                newFloatingPackageWithAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingUnitWithPercent: (x) => x.BillingCycleConfiguration,
                newFloatingMatrixWithAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingTieredWithProration: (x) => x.BillingCycleConfiguration,
                newFloatingUnitWithProration: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingBulkWithProration: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newFloatingMatrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedTieredPackage: (x) => x.BillingCycleConfiguration,
                newFloatingMaxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                newFloatingCumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingMinimumComposite: (x) => x.BillingCycleConfiguration,
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
                newFloatingUnit: (x) => x.ConversionRate,
                newFloatingTiered: (x) => x.ConversionRate,
                newFloatingBulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newFloatingPackage: (x) => x.ConversionRate,
                newFloatingMatrix: (x) => x.ConversionRate,
                newFloatingThresholdTotalAmount: (x) => x.ConversionRate,
                newFloatingTieredPackage: (x) => x.ConversionRate,
                newFloatingTieredWithMinimum: (x) => x.ConversionRate,
                newFloatingGroupedTiered: (x) => x.ConversionRate,
                newFloatingTieredPackageWithMinimum: (x) => x.ConversionRate,
                newFloatingPackageWithAllocation: (x) => x.ConversionRate,
                newFloatingUnitWithPercent: (x) => x.ConversionRate,
                newFloatingMatrixWithAllocation: (x) => x.ConversionRate,
                newFloatingTieredWithProration: (x) => x.ConversionRate,
                newFloatingUnitWithProration: (x) => x.ConversionRate,
                newFloatingGroupedAllocation: (x) => x.ConversionRate,
                newFloatingBulkWithProration: (x) => x.ConversionRate,
                newFloatingGroupedWithProratedMinimum: (x) => x.ConversionRate,
                newFloatingGroupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newFloatingMatrixWithDisplayName: (x) => x.ConversionRate,
                newFloatingGroupedTieredPackage: (x) => x.ConversionRate,
                newFloatingMaxGroupTieredPackage: (x) => x.ConversionRate,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                newFloatingCumulativeGroupedBulk: (x) => x.ConversionRate,
                cumulativeGroupedAllocation: (x) => x.ConversionRate,
                newFloatingMinimumComposite: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<NewDimensionalPriceConfiguration?>(
                newFloatingUnit: (x) => x.DimensionalPriceConfiguration,
                newFloatingTiered: (x) => x.DimensionalPriceConfiguration,
                newFloatingBulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newFloatingPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrix: (x) => x.DimensionalPriceConfiguration,
                newFloatingThresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedTiered: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newFloatingPackageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingUnitWithPercent: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredWithProration: (x) => x.DimensionalPriceConfiguration,
                newFloatingUnitWithProration: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingBulkWithProration: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingMaxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.DimensionalPriceConfiguration,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.DimensionalPriceConfiguration,
                newFloatingCumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingMinimumComposite: (x) => x.DimensionalPriceConfiguration,
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
                newFloatingUnit: (x) => x.ExternalPriceID,
                newFloatingTiered: (x) => x.ExternalPriceID,
                newFloatingBulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newFloatingPackage: (x) => x.ExternalPriceID,
                newFloatingMatrix: (x) => x.ExternalPriceID,
                newFloatingThresholdTotalAmount: (x) => x.ExternalPriceID,
                newFloatingTieredPackage: (x) => x.ExternalPriceID,
                newFloatingTieredWithMinimum: (x) => x.ExternalPriceID,
                newFloatingGroupedTiered: (x) => x.ExternalPriceID,
                newFloatingTieredPackageWithMinimum: (x) => x.ExternalPriceID,
                newFloatingPackageWithAllocation: (x) => x.ExternalPriceID,
                newFloatingUnitWithPercent: (x) => x.ExternalPriceID,
                newFloatingMatrixWithAllocation: (x) => x.ExternalPriceID,
                newFloatingTieredWithProration: (x) => x.ExternalPriceID,
                newFloatingUnitWithProration: (x) => x.ExternalPriceID,
                newFloatingGroupedAllocation: (x) => x.ExternalPriceID,
                newFloatingBulkWithProration: (x) => x.ExternalPriceID,
                newFloatingGroupedWithProratedMinimum: (x) => x.ExternalPriceID,
                newFloatingGroupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newFloatingMatrixWithDisplayName: (x) => x.ExternalPriceID,
                newFloatingGroupedTieredPackage: (x) => x.ExternalPriceID,
                newFloatingMaxGroupTieredPackage: (x) => x.ExternalPriceID,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                newFloatingCumulativeGroupedBulk: (x) => x.ExternalPriceID,
                cumulativeGroupedAllocation: (x) => x.ExternalPriceID,
                newFloatingMinimumComposite: (x) => x.ExternalPriceID,
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
                newFloatingUnit: (x) => x.FixedPriceQuantity,
                newFloatingTiered: (x) => x.FixedPriceQuantity,
                newFloatingBulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newFloatingPackage: (x) => x.FixedPriceQuantity,
                newFloatingMatrix: (x) => x.FixedPriceQuantity,
                newFloatingThresholdTotalAmount: (x) => x.FixedPriceQuantity,
                newFloatingTieredPackage: (x) => x.FixedPriceQuantity,
                newFloatingTieredWithMinimum: (x) => x.FixedPriceQuantity,
                newFloatingGroupedTiered: (x) => x.FixedPriceQuantity,
                newFloatingTieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                newFloatingPackageWithAllocation: (x) => x.FixedPriceQuantity,
                newFloatingUnitWithPercent: (x) => x.FixedPriceQuantity,
                newFloatingMatrixWithAllocation: (x) => x.FixedPriceQuantity,
                newFloatingTieredWithProration: (x) => x.FixedPriceQuantity,
                newFloatingUnitWithProration: (x) => x.FixedPriceQuantity,
                newFloatingGroupedAllocation: (x) => x.FixedPriceQuantity,
                newFloatingBulkWithProration: (x) => x.FixedPriceQuantity,
                newFloatingGroupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                newFloatingGroupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newFloatingMatrixWithDisplayName: (x) => x.FixedPriceQuantity,
                newFloatingGroupedTieredPackage: (x) => x.FixedPriceQuantity,
                newFloatingMaxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                newFloatingCumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                cumulativeGroupedAllocation: (x) => x.FixedPriceQuantity,
                newFloatingMinimumComposite: (x) => x.FixedPriceQuantity,
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
                newFloatingUnit: (x) => x.InvoiceGroupingKey,
                newFloatingTiered: (x) => x.InvoiceGroupingKey,
                newFloatingBulk: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newFloatingPackage: (x) => x.InvoiceGroupingKey,
                newFloatingMatrix: (x) => x.InvoiceGroupingKey,
                newFloatingThresholdTotalAmount: (x) => x.InvoiceGroupingKey,
                newFloatingTieredPackage: (x) => x.InvoiceGroupingKey,
                newFloatingTieredWithMinimum: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedTiered: (x) => x.InvoiceGroupingKey,
                newFloatingTieredPackageWithMinimum: (x) => x.InvoiceGroupingKey,
                newFloatingPackageWithAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingUnitWithPercent: (x) => x.InvoiceGroupingKey,
                newFloatingMatrixWithAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingTieredWithProration: (x) => x.InvoiceGroupingKey,
                newFloatingUnitWithProration: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingBulkWithProration: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedWithProratedMinimum: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedWithMeteredMinimum: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newFloatingMatrixWithDisplayName: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedTieredPackage: (x) => x.InvoiceGroupingKey,
                newFloatingMaxGroupTieredPackage: (x) => x.InvoiceGroupingKey,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.InvoiceGroupingKey,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.InvoiceGroupingKey,
                newFloatingCumulativeGroupedBulk: (x) => x.InvoiceGroupingKey,
                cumulativeGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingMinimumComposite: (x) => x.InvoiceGroupingKey,
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
                newFloatingUnit: (x) => x.InvoicingCycleConfiguration,
                newFloatingTiered: (x) => x.InvoicingCycleConfiguration,
                newFloatingBulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newFloatingPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrix: (x) => x.InvoicingCycleConfiguration,
                newFloatingThresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedTiered: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newFloatingPackageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingUnitWithPercent: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredWithProration: (x) => x.InvoicingCycleConfiguration,
                newFloatingUnitWithProration: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingBulkWithProration: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingMaxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.InvoicingCycleConfiguration,
                newFloatingCumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingUnitPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingBulkPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMatrixPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingThresholdTotalAmountPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedTieredPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredPackageWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingPackageWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingUnitWithPercentPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMatrixWithAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingUnitWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedAllocationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingBulkWithProrationPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedWithProratedMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedWithMeteredMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMatrixWithDisplayNamePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMaxGroupTieredPackagePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingScalableMatrixWithUnitPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingScalableMatrixWithTieredPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingCumulativeGroupedBulkPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMinimumCompositePrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingUnit(out var value)) {
    ///     // `value` is of type `NewFloatingUnitPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnit([NotNullWhen(true)] out NewFloatingUnitPrice? value)
    {
        value = this.Value as NewFloatingUnitPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTiered(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTiered([NotNullWhen(true)] out NewFloatingTieredPrice? value)
    {
        value = this.Value as NewFloatingTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingBulk(out var value)) {
    ///     // `value` is of type `NewFloatingBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingBulk([NotNullWhen(true)] out NewFloatingBulkPrice? value)
    {
        value = this.Value as NewFloatingBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)]
            out PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters? value
    )
    {
        value = this.Value as PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingPackage(out var value)) {
    ///     // `value` is of type `NewFloatingPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingPackage([NotNullWhen(true)] out NewFloatingPackagePrice? value)
    {
        value = this.Value as NewFloatingPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMatrixPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMatrix(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrix([NotNullWhen(true)] out NewFloatingMatrixPrice? value)
    {
        value = this.Value as NewFloatingMatrixPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingThresholdTotalAmountPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingThresholdTotalAmount(out var value)) {
    ///     // `value` is of type `NewFloatingThresholdTotalAmountPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingThresholdTotalAmount(
        [NotNullWhen(true)] out NewFloatingThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewFloatingThresholdTotalAmountPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredPackage(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredPackage(
        [NotNullWhen(true)] out NewFloatingTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredWithMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingTieredWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedTiered(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedTiered(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredPackageWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredPackageWithMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPackageWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackageWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingPackageWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingPackageWithAllocation(out var value)) {
    ///     // `value` is of type `NewFloatingPackageWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingPackageWithAllocation(
        [NotNullWhen(true)] out NewFloatingPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingPackageWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingUnitWithPercentPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingUnitWithPercent(out var value)) {
    ///     // `value` is of type `NewFloatingUnitWithPercentPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnitWithPercent(
        [NotNullWhen(true)] out NewFloatingUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithPercentPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMatrixWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMatrixWithAllocation(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrixWithAllocation(
        [NotNullWhen(true)] out NewFloatingMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredWithProration(out var value)) {
    ///     // `value` is of type `NewFloatingTieredWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredWithProration(
        [NotNullWhen(true)] out NewFloatingTieredWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingUnitWithProration(out var value)) {
    ///     // `value` is of type `NewFloatingUnitWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnitWithProration(
        [NotNullWhen(true)] out NewFloatingUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedAllocation(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedAllocation(
        [NotNullWhen(true)] out NewFloatingGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingBulkWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingBulkWithProration(out var value)) {
    ///     // `value` is of type `NewFloatingBulkWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingBulkWithProration(
        [NotNullWhen(true)] out NewFloatingBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingBulkWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedWithProratedMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedWithProratedMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedWithProratedMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithProratedMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedWithMeteredMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedWithMeteredMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedWithMeteredMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)]
            out PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds? value
    )
    {
        value =
            this.Value
            as PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMatrixWithDisplayName(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixWithDisplayNamePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrixWithDisplayName(
        [NotNullWhen(true)] out NewFloatingMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithDisplayNamePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedTieredPackage(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedTieredPackage(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMaxGroupTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMaxGroupTieredPackage(out var value)) {
    ///     // `value` is of type `NewFloatingMaxGroupTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewFloatingMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingMaxGroupTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingScalableMatrixWithUnitPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingScalableMatrixWithUnitPricing(out var value)) {
    ///     // `value` is of type `NewFloatingScalableMatrixWithUnitPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingScalableMatrixWithTieredPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingScalableMatrixWithTieredPricing(out var value)) {
    ///     // `value` is of type `NewFloatingScalableMatrixWithTieredPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingCumulativeGroupedBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingCumulativeGroupedBulk(out var value)) {
    ///     // `value` is of type `NewFloatingCumulativeGroupedBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewFloatingCumulativeGroupedBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)]
            out PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation? value
    )
    {
        value =
            this.Value
            as PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMinimumComposite(out var value)) {
    ///     // `value` is of type `NewFloatingMinimumCompositePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMinimumComposite(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = this.Value as NewFloatingMinimumCompositePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent(
        [NotNullWhen(true)] out PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent? value
    )
    {
        value = this.Value as PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput(
        [NotNullWhen(true)]
            out PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput? value
    )
    {
        value = this.Value as PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (NewFloatingUnitPrice value) => {...},
    ///     (NewFloatingTieredPrice value) => {...},
    ///     (NewFloatingBulkPrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters value) => {...},
    ///     (NewFloatingPackagePrice value) => {...},
    ///     (NewFloatingMatrixPrice value) => {...},
    ///     (NewFloatingThresholdTotalAmountPrice value) => {...},
    ///     (NewFloatingTieredPackagePrice value) => {...},
    ///     (NewFloatingTieredWithMinimumPrice value) => {...},
    ///     (NewFloatingGroupedTieredPrice value) => {...},
    ///     (NewFloatingTieredPackageWithMinimumPrice value) => {...},
    ///     (NewFloatingPackageWithAllocationPrice value) => {...},
    ///     (NewFloatingUnitWithPercentPrice value) => {...},
    ///     (NewFloatingMatrixWithAllocationPrice value) => {...},
    ///     (NewFloatingTieredWithProrationPrice value) => {...},
    ///     (NewFloatingUnitWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedAllocationPrice value) => {...},
    ///     (NewFloatingBulkWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewFloatingGroupedWithMeteredMinimumPrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewFloatingMatrixWithDisplayNamePrice value) => {...},
    ///     (NewFloatingGroupedTieredPackagePrice value) => {...},
    ///     (NewFloatingMaxGroupTieredPackagePrice value) => {...},
    ///     (NewFloatingScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewFloatingScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewFloatingCumulativeGroupedBulkPrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation value) => {...},
    ///     (NewFloatingMinimumCompositePrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewFloatingUnitPrice> newFloatingUnit,
        System::Action<NewFloatingTieredPrice> newFloatingTiered,
        System::Action<NewFloatingBulkPrice> newFloatingBulk,
        System::Action<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters> bulkWithFilters,
        System::Action<NewFloatingPackagePrice> newFloatingPackage,
        System::Action<NewFloatingMatrixPrice> newFloatingMatrix,
        System::Action<NewFloatingThresholdTotalAmountPrice> newFloatingThresholdTotalAmount,
        System::Action<NewFloatingTieredPackagePrice> newFloatingTieredPackage,
        System::Action<NewFloatingTieredWithMinimumPrice> newFloatingTieredWithMinimum,
        System::Action<NewFloatingGroupedTieredPrice> newFloatingGroupedTiered,
        System::Action<NewFloatingTieredPackageWithMinimumPrice> newFloatingTieredPackageWithMinimum,
        System::Action<NewFloatingPackageWithAllocationPrice> newFloatingPackageWithAllocation,
        System::Action<NewFloatingUnitWithPercentPrice> newFloatingUnitWithPercent,
        System::Action<NewFloatingMatrixWithAllocationPrice> newFloatingMatrixWithAllocation,
        System::Action<NewFloatingTieredWithProrationPrice> newFloatingTieredWithProration,
        System::Action<NewFloatingUnitWithProrationPrice> newFloatingUnitWithProration,
        System::Action<NewFloatingGroupedAllocationPrice> newFloatingGroupedAllocation,
        System::Action<NewFloatingBulkWithProrationPrice> newFloatingBulkWithProration,
        System::Action<NewFloatingGroupedWithProratedMinimumPrice> newFloatingGroupedWithProratedMinimum,
        System::Action<NewFloatingGroupedWithMeteredMinimumPrice> newFloatingGroupedWithMeteredMinimum,
        System::Action<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayName,
        System::Action<NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackage,
        System::Action<NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackage,
        System::Action<NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricing,
        System::Action<NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricing,
        System::Action<NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulk,
        System::Action<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewFloatingMinimumCompositePrice> newFloatingMinimumComposite,
        System::Action<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent> percent,
        System::Action<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewFloatingUnitPrice value:
                newFloatingUnit(value);
                break;
            case NewFloatingTieredPrice value:
                newFloatingTiered(value);
                break;
            case NewFloatingBulkPrice value:
                newFloatingBulk(value);
                break;
            case PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewFloatingPackagePrice value:
                newFloatingPackage(value);
                break;
            case NewFloatingMatrixPrice value:
                newFloatingMatrix(value);
                break;
            case NewFloatingThresholdTotalAmountPrice value:
                newFloatingThresholdTotalAmount(value);
                break;
            case NewFloatingTieredPackagePrice value:
                newFloatingTieredPackage(value);
                break;
            case NewFloatingTieredWithMinimumPrice value:
                newFloatingTieredWithMinimum(value);
                break;
            case NewFloatingGroupedTieredPrice value:
                newFloatingGroupedTiered(value);
                break;
            case NewFloatingTieredPackageWithMinimumPrice value:
                newFloatingTieredPackageWithMinimum(value);
                break;
            case NewFloatingPackageWithAllocationPrice value:
                newFloatingPackageWithAllocation(value);
                break;
            case NewFloatingUnitWithPercentPrice value:
                newFloatingUnitWithPercent(value);
                break;
            case NewFloatingMatrixWithAllocationPrice value:
                newFloatingMatrixWithAllocation(value);
                break;
            case NewFloatingTieredWithProrationPrice value:
                newFloatingTieredWithProration(value);
                break;
            case NewFloatingUnitWithProrationPrice value:
                newFloatingUnitWithProration(value);
                break;
            case NewFloatingGroupedAllocationPrice value:
                newFloatingGroupedAllocation(value);
                break;
            case NewFloatingBulkWithProrationPrice value:
                newFloatingBulkWithProration(value);
                break;
            case NewFloatingGroupedWithProratedMinimumPrice value:
                newFloatingGroupedWithProratedMinimum(value);
                break;
            case NewFloatingGroupedWithMeteredMinimumPrice value:
                newFloatingGroupedWithMeteredMinimum(value);
                break;
            case PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewFloatingMatrixWithDisplayNamePrice value:
                newFloatingMatrixWithDisplayName(value);
                break;
            case NewFloatingGroupedTieredPackagePrice value:
                newFloatingGroupedTieredPackage(value);
                break;
            case NewFloatingMaxGroupTieredPackagePrice value:
                newFloatingMaxGroupTieredPackage(value);
                break;
            case NewFloatingScalableMatrixWithUnitPricingPrice value:
                newFloatingScalableMatrixWithUnitPricing(value);
                break;
            case NewFloatingScalableMatrixWithTieredPricingPrice value:
                newFloatingScalableMatrixWithTieredPricing(value);
                break;
            case NewFloatingCumulativeGroupedBulkPrice value:
                newFloatingCumulativeGroupedBulk(value);
                break;
            case PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewFloatingMinimumCompositePrice value:
                newFloatingMinimumComposite(value);
                break;
            case PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent value:
                percent(value);
                break;
            case PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPrice"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (NewFloatingUnitPrice value) => {...},
    ///     (NewFloatingTieredPrice value) => {...},
    ///     (NewFloatingBulkPrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters value) => {...},
    ///     (NewFloatingPackagePrice value) => {...},
    ///     (NewFloatingMatrixPrice value) => {...},
    ///     (NewFloatingThresholdTotalAmountPrice value) => {...},
    ///     (NewFloatingTieredPackagePrice value) => {...},
    ///     (NewFloatingTieredWithMinimumPrice value) => {...},
    ///     (NewFloatingGroupedTieredPrice value) => {...},
    ///     (NewFloatingTieredPackageWithMinimumPrice value) => {...},
    ///     (NewFloatingPackageWithAllocationPrice value) => {...},
    ///     (NewFloatingUnitWithPercentPrice value) => {...},
    ///     (NewFloatingMatrixWithAllocationPrice value) => {...},
    ///     (NewFloatingTieredWithProrationPrice value) => {...},
    ///     (NewFloatingUnitWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedAllocationPrice value) => {...},
    ///     (NewFloatingBulkWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewFloatingGroupedWithMeteredMinimumPrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewFloatingMatrixWithDisplayNamePrice value) => {...},
    ///     (NewFloatingGroupedTieredPackagePrice value) => {...},
    ///     (NewFloatingMaxGroupTieredPackagePrice value) => {...},
    ///     (NewFloatingScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewFloatingScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewFloatingCumulativeGroupedBulkPrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation value) => {...},
    ///     (NewFloatingMinimumCompositePrice value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent value) => {...},
    ///     (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewFloatingUnitPrice, T> newFloatingUnit,
        System::Func<NewFloatingTieredPrice, T> newFloatingTiered,
        System::Func<NewFloatingBulkPrice, T> newFloatingBulk,
        System::Func<
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters,
            T
        > bulkWithFilters,
        System::Func<NewFloatingPackagePrice, T> newFloatingPackage,
        System::Func<NewFloatingMatrixPrice, T> newFloatingMatrix,
        System::Func<NewFloatingThresholdTotalAmountPrice, T> newFloatingThresholdTotalAmount,
        System::Func<NewFloatingTieredPackagePrice, T> newFloatingTieredPackage,
        System::Func<NewFloatingTieredWithMinimumPrice, T> newFloatingTieredWithMinimum,
        System::Func<NewFloatingGroupedTieredPrice, T> newFloatingGroupedTiered,
        System::Func<
            NewFloatingTieredPackageWithMinimumPrice,
            T
        > newFloatingTieredPackageWithMinimum,
        System::Func<NewFloatingPackageWithAllocationPrice, T> newFloatingPackageWithAllocation,
        System::Func<NewFloatingUnitWithPercentPrice, T> newFloatingUnitWithPercent,
        System::Func<NewFloatingMatrixWithAllocationPrice, T> newFloatingMatrixWithAllocation,
        System::Func<NewFloatingTieredWithProrationPrice, T> newFloatingTieredWithProration,
        System::Func<NewFloatingUnitWithProrationPrice, T> newFloatingUnitWithProration,
        System::Func<NewFloatingGroupedAllocationPrice, T> newFloatingGroupedAllocation,
        System::Func<NewFloatingBulkWithProrationPrice, T> newFloatingBulkWithProration,
        System::Func<
            NewFloatingGroupedWithProratedMinimumPrice,
            T
        > newFloatingGroupedWithProratedMinimum,
        System::Func<
            NewFloatingGroupedWithMeteredMinimumPrice,
            T
        > newFloatingGroupedWithMeteredMinimum,
        System::Func<
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds,
            T
        > groupedWithMinMaxThresholds,
        System::Func<NewFloatingMatrixWithDisplayNamePrice, T> newFloatingMatrixWithDisplayName,
        System::Func<NewFloatingGroupedTieredPackagePrice, T> newFloatingGroupedTieredPackage,
        System::Func<NewFloatingMaxGroupTieredPackagePrice, T> newFloatingMaxGroupTieredPackage,
        System::Func<
            NewFloatingScalableMatrixWithUnitPricingPrice,
            T
        > newFloatingScalableMatrixWithUnitPricing,
        System::Func<
            NewFloatingScalableMatrixWithTieredPricingPrice,
            T
        > newFloatingScalableMatrixWithTieredPricing,
        System::Func<NewFloatingCumulativeGroupedBulkPrice, T> newFloatingCumulativeGroupedBulk,
        System::Func<
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewFloatingMinimumCompositePrice, T> newFloatingMinimumComposite,
        System::Func<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent, T> percent,
        System::Func<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewFloatingUnitPrice value => newFloatingUnit(value),
            NewFloatingTieredPrice value => newFloatingTiered(value),
            NewFloatingBulkPrice value => newFloatingBulk(value),
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters value =>
                bulkWithFilters(value),
            NewFloatingPackagePrice value => newFloatingPackage(value),
            NewFloatingMatrixPrice value => newFloatingMatrix(value),
            NewFloatingThresholdTotalAmountPrice value => newFloatingThresholdTotalAmount(value),
            NewFloatingTieredPackagePrice value => newFloatingTieredPackage(value),
            NewFloatingTieredWithMinimumPrice value => newFloatingTieredWithMinimum(value),
            NewFloatingGroupedTieredPrice value => newFloatingGroupedTiered(value),
            NewFloatingTieredPackageWithMinimumPrice value => newFloatingTieredPackageWithMinimum(
                value
            ),
            NewFloatingPackageWithAllocationPrice value => newFloatingPackageWithAllocation(value),
            NewFloatingUnitWithPercentPrice value => newFloatingUnitWithPercent(value),
            NewFloatingMatrixWithAllocationPrice value => newFloatingMatrixWithAllocation(value),
            NewFloatingTieredWithProrationPrice value => newFloatingTieredWithProration(value),
            NewFloatingUnitWithProrationPrice value => newFloatingUnitWithProration(value),
            NewFloatingGroupedAllocationPrice value => newFloatingGroupedAllocation(value),
            NewFloatingBulkWithProrationPrice value => newFloatingBulkWithProration(value),
            NewFloatingGroupedWithProratedMinimumPrice value =>
                newFloatingGroupedWithProratedMinimum(value),
            NewFloatingGroupedWithMeteredMinimumPrice value => newFloatingGroupedWithMeteredMinimum(
                value
            ),
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds value =>
                groupedWithMinMaxThresholds(value),
            NewFloatingMatrixWithDisplayNamePrice value => newFloatingMatrixWithDisplayName(value),
            NewFloatingGroupedTieredPackagePrice value => newFloatingGroupedTieredPackage(value),
            NewFloatingMaxGroupTieredPackagePrice value => newFloatingMaxGroupTieredPackage(value),
            NewFloatingScalableMatrixWithUnitPricingPrice value =>
                newFloatingScalableMatrixWithUnitPricing(value),
            NewFloatingScalableMatrixWithTieredPricingPrice value =>
                newFloatingScalableMatrixWithTieredPricing(value),
            NewFloatingCumulativeGroupedBulkPrice value => newFloatingCumulativeGroupedBulk(value),
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewFloatingMinimumCompositePrice value => newFloatingMinimumComposite(value),
            PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent value => percent(value),
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput value => eventOutput(
                value
            ),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPrice"
            ),
        };
    }

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingUnitPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingBulkPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingPackagePrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMatrixPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredPackagePrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedTieredPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingTieredWithProrationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        NewFloatingMinimumCompositePrice value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput value
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPrice"
            );
        }
        this.Switch(
            (newFloatingUnit) => newFloatingUnit.Validate(),
            (newFloatingTiered) => newFloatingTiered.Validate(),
            (newFloatingBulk) => newFloatingBulk.Validate(),
            (bulkWithFilters) => bulkWithFilters.Validate(),
            (newFloatingPackage) => newFloatingPackage.Validate(),
            (newFloatingMatrix) => newFloatingMatrix.Validate(),
            (newFloatingThresholdTotalAmount) => newFloatingThresholdTotalAmount.Validate(),
            (newFloatingTieredPackage) => newFloatingTieredPackage.Validate(),
            (newFloatingTieredWithMinimum) => newFloatingTieredWithMinimum.Validate(),
            (newFloatingGroupedTiered) => newFloatingGroupedTiered.Validate(),
            (newFloatingTieredPackageWithMinimum) => newFloatingTieredPackageWithMinimum.Validate(),
            (newFloatingPackageWithAllocation) => newFloatingPackageWithAllocation.Validate(),
            (newFloatingUnitWithPercent) => newFloatingUnitWithPercent.Validate(),
            (newFloatingMatrixWithAllocation) => newFloatingMatrixWithAllocation.Validate(),
            (newFloatingTieredWithProration) => newFloatingTieredWithProration.Validate(),
            (newFloatingUnitWithProration) => newFloatingUnitWithProration.Validate(),
            (newFloatingGroupedAllocation) => newFloatingGroupedAllocation.Validate(),
            (newFloatingBulkWithProration) => newFloatingBulkWithProration.Validate(),
            (newFloatingGroupedWithProratedMinimum) =>
                newFloatingGroupedWithProratedMinimum.Validate(),
            (newFloatingGroupedWithMeteredMinimum) =>
                newFloatingGroupedWithMeteredMinimum.Validate(),
            (groupedWithMinMaxThresholds) => groupedWithMinMaxThresholds.Validate(),
            (newFloatingMatrixWithDisplayName) => newFloatingMatrixWithDisplayName.Validate(),
            (newFloatingGroupedTieredPackage) => newFloatingGroupedTieredPackage.Validate(),
            (newFloatingMaxGroupTieredPackage) => newFloatingMaxGroupTieredPackage.Validate(),
            (newFloatingScalableMatrixWithUnitPricing) =>
                newFloatingScalableMatrixWithUnitPricing.Validate(),
            (newFloatingScalableMatrixWithTieredPricing) =>
                newFloatingScalableMatrixWithTieredPricing.Validate(),
            (newFloatingCumulativeGroupedBulk) => newFloatingCumulativeGroupedBulk.Validate(),
            (cumulativeGroupedAllocation) => cumulativeGroupedAllocation.Validate(),
            (newFloatingMinimumComposite) => newFloatingMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(PriceEvaluatePreviewEventsParamsPriceEvaluationPrice? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice?>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPrice? Read(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingBulkPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMatrixPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingThresholdTotalAmountPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedTieredPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unit_with_percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitWithPercentPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingMatrixWithAllocationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingTieredWithProrationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingUnitWithProrationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingGroupedAllocationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingBulkWithProrationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingMatrixWithDisplayNamePrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingGroupedTieredPackagePrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithUnitPricingPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithTieredPricingPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<NewFloatingCumulativeGroupedBulkPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMinimumCompositePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "percent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "event_output":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PriceEvaluatePreviewEventsParamsPriceEvaluationPrice(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
    : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { JsonModel.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig
    : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter>
            >(this.RawData, "filters");
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier> Tiers
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier>
            >(this.RawData, "tiers");
        }
        init { JsonModel.Set(this._rawData, "tiers", value); }
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

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig()
    { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig
    )
        : base(
            priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig
        ) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter
    : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { JsonModel.Set(this._rawData, "property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { JsonModel.Set(this._rawData, "property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter()
    { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter
    )
        : base(
            priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter
        ) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
    : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "tier_lower_bound"); }
        init { JsonModel.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier()
    { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
    )
        : base(
            priceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
        ) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier(
        string unitAmount
    )
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadenceConverter)
)]
public enum PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadenceConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
            "semi_annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Monthly,
            "quarterly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Quarterly,
            "one_time" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.OneTime,
            "custom" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Custom,
            _ => (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual =>
                    "annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.SemiAnnual =>
                    "semi_annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Monthly =>
                    "monthly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Quarterly =>
                    "quarterly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.OneTime =>
                    "one_time",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Custom =>
                    "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfigConverter)
)]
public record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                    "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig(
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig? Read(
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                this.RawData,
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { JsonModel.Set(this._rawData, "grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds priceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadenceConverter)
)]
public enum PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ =>
                (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual =>
                    "annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual =>
                    "semi_annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Monthly =>
                    "monthly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Quarterly =>
                    "quarterly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.OneTime =>
                    "one_time",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Custom =>
                    "custom",
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
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "maximum_charge"); }
        init { JsonModel.Set(this._rawData, "maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "minimum_charge"); }
        init { JsonModel.Set(this._rawData, "minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "per_unit_rate"); }
        init { JsonModel.Set(this._rawData, "per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig()
    { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig priceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    )
        : base(
            priceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        ) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                    "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig(
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { JsonModel.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation priceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadenceConverter)
)]
public enum PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Custom,
            _ =>
                (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual =>
                    "annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.SemiAnnual =>
                    "semi_annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Monthly =>
                    "monthly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Quarterly =>
                    "quarterly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.OneTime =>
                    "one_time",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Custom =>
                    "custom",
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
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "cumulative_allocation"); }
        init { JsonModel.Set(this._rawData, "cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "group_allocation"); }
        init { JsonModel.Set(this._rawData, "group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig()
    { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig priceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    )
        : base(
            priceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        ) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                    "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig(
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig? Read(
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence>
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig PercentConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig>(
                this.RawData,
                "percent_config"
            );
        }
        init { JsonModel.Set(this._rawData, "percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"percent\"")
            )
        )
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent priceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluationPricePercent) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadenceConverter))]
public enum PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadenceConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
            "semi_annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.SemiAnnual,
            "monthly" => PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Monthly,
            "quarterly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Quarterly,
            "one_time" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.OneTime,
            "custom" => PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Custom,
            _ => (PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual =>
                    "annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.SemiAnnual =>
                    "semi_annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Monthly =>
                    "monthly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Quarterly =>
                    "quarterly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.OneTime =>
                    "one_time",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Custom =>
                    "custom",
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
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfigFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig
    : JsonModel
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "percent"); }
        init { JsonModel.Set(this._rawData, "percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig() { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig priceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfigFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfigFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfigConverter)
)]
public record class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                    "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig(
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfigConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig? Read(
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
    : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
    > Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<
                    string,
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
                >
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig>(
                this.RawData,
                "event_output_config"
            );
        }
        init { JsonModel.Set(this._rawData, "event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"event_output\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput priceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadenceConverter)
)]
public enum PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadenceConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
            "semi_annual" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.SemiAnnual,
            "monthly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Monthly,
            "quarterly" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Quarterly,
            "one_time" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.OneTime,
            "custom" =>
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Custom,
            _ => (PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual =>
                    "annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.SemiAnnual =>
                    "semi_annual",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Monthly =>
                    "monthly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Quarterly =>
                    "quarterly",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.OneTime =>
                    "one_time",
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Custom =>
                    "custom",
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
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
    : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_rating_key"); }
        init { JsonModel.Set(this._rawData, "unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "default_unit_rate"); }
        init { JsonModel.Set(this._rawData, "default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig() { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig priceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
    )
        : base(priceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig) { }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfigFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig(
        string unitRatingKey
    )
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfigFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfigConverter)
)]
public record class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                    "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
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
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig(
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfigConverter
    : JsonConverter<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig>
{
    public override PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig? Read(
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
