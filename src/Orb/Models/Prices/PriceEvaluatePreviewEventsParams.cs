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
            if (!this._rawBodyData.TryGetValue("timeframe_end", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_end' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timeframe_end",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The inclusive lower bound for event timestamps
    /// </summary>
    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("timeframe_start", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_start' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timeframe_start",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of preview events to use instead of actual usage data
    /// </summary>
    public IReadOnlyList<Event>? Events
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("events", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Event>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["events"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The external customer ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of prices to evaluate (max 100)
    /// </summary>
    public IReadOnlyList<PriceEvaluationModel>? PriceEvaluations
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("price_evaluations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PriceEvaluationModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["price_evaluations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public PriceEvaluatePreviewEventsParams() { }

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

[JsonConverter(typeof(ModelConverter<Event, EventFromRaw>))]
public sealed record class Event : ModelBase
{
    /// <summary>
    /// A name to meaningfully identify the action or event type.
    /// </summary>
    public required string EventName
    {
        get
        {
            if (!this._rawData.TryGetValue("event_name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_name' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_name",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'event_name' cannot be null",
                    new System::ArgumentNullException("event_name")
                );
        }
        init
        {
            this._rawData["event_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A dictionary of custom properties. Values in this dictionary must be numeric,
    /// boolean, or strings. Nested dictionaries are disallowed.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Properties
    {
        get
        {
            if (!this._rawData.TryGetValue("properties", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'properties' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "properties",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'properties' cannot be null",
                    new System::ArgumentNullException("properties")
                );
        }
        init
        {
            this._rawData["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._rawData.TryGetValue("timestamp", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timestamp' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timestamp",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Orb Customer identifier
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this._rawData.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the Orb customer, whose mapping is specified when creating the customer
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EventName;
        _ = this.Properties;
        _ = this.Timestamp;
        _ = this.CustomerID;
        _ = this.ExternalCustomerID;
    }

    public Event() { }

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

    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRaw<Event>
{
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<PriceEvaluationModel, PriceEvaluationModelFromRaw>))]
public sealed record class PriceEvaluationModel : ModelBase
{
    /// <summary>
    /// The external ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the underlying billable metric
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this._rawData.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Properties (or [computed properties](/extensibility/advanced-metrics#computed-properties))
    /// used to group the underlying billable metric
    /// </summary>
    public IReadOnlyList<string>? GroupingKeys
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_keys", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["grouping_keys"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New floating price request body params.
    /// </summary>
    public PriceEvaluationModelPrice? Price
    {
        get
        {
            if (!this._rawData.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceEvaluationModelPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ExternalPriceID;
        _ = this.Filter;
        _ = this.GroupingKeys;
        this.Price?.Validate();
        _ = this.PriceID;
    }

    public PriceEvaluationModel() { }

    public PriceEvaluationModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelFromRaw : IFromRaw<PriceEvaluationModel>
{
    public PriceEvaluationModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModel.FromRawUnchecked(rawData);
}

/// <summary>
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(PriceEvaluationModelPriceConverter))]
public record class PriceEvaluationModelPrice
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public PriceEvaluationModelPrice(NewFloatingUnitPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(NewFloatingTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(NewFloatingBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        PriceEvaluationModelPriceBulkWithFilters value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(NewFloatingPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(NewFloatingMatrixPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingThresholdTotalAmountPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(NewFloatingTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingTieredWithMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(NewFloatingGroupedTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingTieredPackageWithMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingPackageWithAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingUnitWithPercentPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingMatrixWithAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingTieredWithProrationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingUnitWithProrationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingGroupedAllocationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingBulkWithProrationPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingGroupedWithProratedMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingGroupedWithMeteredMinimumPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        PriceEvaluationModelPriceGroupedWithMinMaxThresholds value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingMatrixWithDisplayNamePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingGroupedTieredPackagePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingMaxGroupTieredPackagePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingScalableMatrixWithUnitPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingScalableMatrixWithTieredPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingCumulativeGroupedBulkPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        PriceEvaluationModelPriceCumulativeGroupedAllocation value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        NewFloatingMinimumCompositePrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        PriceEvaluationModelPricePercent value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(
        PriceEvaluationModelPriceEventOutput value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPrice(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewFloatingUnit([NotNullWhen(true)] out NewFloatingUnitPrice? value)
    {
        value = this.Value as NewFloatingUnitPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTiered([NotNullWhen(true)] out NewFloatingTieredPrice? value)
    {
        value = this.Value as NewFloatingTieredPrice;
        return value != null;
    }

    public bool TryPickNewFloatingBulk([NotNullWhen(true)] out NewFloatingBulkPrice? value)
    {
        value = this.Value as NewFloatingBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out PriceEvaluationModelPriceBulkWithFilters? value
    )
    {
        value = this.Value as PriceEvaluationModelPriceBulkWithFilters;
        return value != null;
    }

    public bool TryPickNewFloatingPackage([NotNullWhen(true)] out NewFloatingPackagePrice? value)
    {
        value = this.Value as NewFloatingPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingMatrix([NotNullWhen(true)] out NewFloatingMatrixPrice? value)
    {
        value = this.Value as NewFloatingMatrixPrice;
        return value != null;
    }

    public bool TryPickNewFloatingThresholdTotalAmount(
        [NotNullWhen(true)] out NewFloatingThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewFloatingThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackage(
        [NotNullWhen(true)] out NewFloatingTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTiered(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingPackageWithAllocation(
        [NotNullWhen(true)] out NewFloatingPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithPercent(
        [NotNullWhen(true)] out NewFloatingUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithAllocation(
        [NotNullWhen(true)] out NewFloatingMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithProration(
        [NotNullWhen(true)] out NewFloatingTieredWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithProration(
        [NotNullWhen(true)] out NewFloatingUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedAllocation(
        [NotNullWhen(true)] out NewFloatingGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingBulkWithProration(
        [NotNullWhen(true)] out NewFloatingBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out PriceEvaluationModelPriceGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as PriceEvaluationModelPriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithDisplayName(
        [NotNullWhen(true)] out NewFloatingMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTieredPackage(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewFloatingMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewFloatingCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewFloatingCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out PriceEvaluationModelPriceCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as PriceEvaluationModelPriceCumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewFloatingMinimumComposite(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = this.Value as NewFloatingMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out PriceEvaluationModelPricePercent? value)
    {
        value = this.Value as PriceEvaluationModelPricePercent;
        return value != null;
    }

    public bool TryPickEventOutput(
        [NotNullWhen(true)] out PriceEvaluationModelPriceEventOutput? value
    )
    {
        value = this.Value as PriceEvaluationModelPriceEventOutput;
        return value != null;
    }

    public void Switch(
        System::Action<NewFloatingUnitPrice> newFloatingUnit,
        System::Action<NewFloatingTieredPrice> newFloatingTiered,
        System::Action<NewFloatingBulkPrice> newFloatingBulk,
        System::Action<PriceEvaluationModelPriceBulkWithFilters> bulkWithFilters,
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
        System::Action<PriceEvaluationModelPriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayName,
        System::Action<NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackage,
        System::Action<NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackage,
        System::Action<NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricing,
        System::Action<NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricing,
        System::Action<NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulk,
        System::Action<PriceEvaluationModelPriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewFloatingMinimumCompositePrice> newFloatingMinimumComposite,
        System::Action<PriceEvaluationModelPricePercent> percent,
        System::Action<PriceEvaluationModelPriceEventOutput> eventOutput
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
            case PriceEvaluationModelPriceBulkWithFilters value:
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
            case PriceEvaluationModelPriceGroupedWithMinMaxThresholds value:
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
            case PriceEvaluationModelPriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewFloatingMinimumCompositePrice value:
                newFloatingMinimumComposite(value);
                break;
            case PriceEvaluationModelPricePercent value:
                percent(value);
                break;
            case PriceEvaluationModelPriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of PriceEvaluationModelPrice"
                );
        }
    }

    public T Match<T>(
        System::Func<NewFloatingUnitPrice, T> newFloatingUnit,
        System::Func<NewFloatingTieredPrice, T> newFloatingTiered,
        System::Func<NewFloatingBulkPrice, T> newFloatingBulk,
        System::Func<PriceEvaluationModelPriceBulkWithFilters, T> bulkWithFilters,
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
            PriceEvaluationModelPriceGroupedWithMinMaxThresholds,
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
            PriceEvaluationModelPriceCumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewFloatingMinimumCompositePrice, T> newFloatingMinimumComposite,
        System::Func<PriceEvaluationModelPricePercent, T> percent,
        System::Func<PriceEvaluationModelPriceEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewFloatingUnitPrice value => newFloatingUnit(value),
            NewFloatingTieredPrice value => newFloatingTiered(value),
            NewFloatingBulkPrice value => newFloatingBulk(value),
            PriceEvaluationModelPriceBulkWithFilters value => bulkWithFilters(value),
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
            PriceEvaluationModelPriceGroupedWithMinMaxThresholds value =>
                groupedWithMinMaxThresholds(value),
            NewFloatingMatrixWithDisplayNamePrice value => newFloatingMatrixWithDisplayName(value),
            NewFloatingGroupedTieredPackagePrice value => newFloatingGroupedTieredPackage(value),
            NewFloatingMaxGroupTieredPackagePrice value => newFloatingMaxGroupTieredPackage(value),
            NewFloatingScalableMatrixWithUnitPricingPrice value =>
                newFloatingScalableMatrixWithUnitPricing(value),
            NewFloatingScalableMatrixWithTieredPricingPrice value =>
                newFloatingScalableMatrixWithTieredPricing(value),
            NewFloatingCumulativeGroupedBulkPrice value => newFloatingCumulativeGroupedBulk(value),
            PriceEvaluationModelPriceCumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewFloatingMinimumCompositePrice value => newFloatingMinimumComposite(value),
            PriceEvaluationModelPricePercent value => percent(value),
            PriceEvaluationModelPriceEventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluationModelPrice"
            ),
        };
    }

    public static implicit operator PriceEvaluationModelPrice(NewFloatingUnitPrice value) =>
        new(value);

    public static implicit operator PriceEvaluationModelPrice(NewFloatingTieredPrice value) =>
        new(value);

    public static implicit operator PriceEvaluationModelPrice(NewFloatingBulkPrice value) =>
        new(value);

    public static implicit operator PriceEvaluationModelPrice(
        PriceEvaluationModelPriceBulkWithFilters value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(NewFloatingPackagePrice value) =>
        new(value);

    public static implicit operator PriceEvaluationModelPrice(NewFloatingMatrixPrice value) =>
        new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingTieredPackagePrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingGroupedTieredPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingTieredWithProrationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        PriceEvaluationModelPriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        PriceEvaluationModelPriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        NewFloatingMinimumCompositePrice value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        PriceEvaluationModelPricePercent value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPrice(
        PriceEvaluationModelPriceEventOutput value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluationModelPrice"
            );
        }
    }
}

sealed class PriceEvaluationModelPriceConverter : JsonConverter<PriceEvaluationModelPrice?>
{
    public override PriceEvaluationModelPrice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = json.GetProperty("model_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceEvaluationModelPriceBulkWithFilters>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingThresholdTotalAmountPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "unit_with_percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingMatrixWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingTieredWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "unit_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingUnitWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingBulkWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceEvaluationModelPriceGroupedWithMinMaxThresholds>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceEvaluationModelPriceCumulativeGroupedAllocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PriceEvaluationModelPricePercent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "event_output":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceEvaluationModelPriceEventOutput>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new PriceEvaluationModelPrice(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluationModelPriceBulkWithFilters,
        PriceEvaluationModelPriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceBulkWithFilters : ModelBase
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentNullException("bulk_with_filters_config")
                );
        }
        init
        {
            this._rawData["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceEvaluationModelPriceBulkWithFiltersCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, PriceEvaluationModelPriceBulkWithFiltersCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public PriceEvaluationModelPriceBulkWithFiltersModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceBulkWithFiltersModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
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

    public PriceEvaluationModelPriceBulkWithFilters()
    {
        this.ModelType = new();
    }

    public PriceEvaluationModelPriceBulkWithFilters(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPriceBulkWithFiltersFromRaw
    : IFromRaw<PriceEvaluationModelPriceBulkWithFilters>
{
    public PriceEvaluationModelPriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPriceBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig,
        PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig : ModelBase
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Prices.Filter1> Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Prices.Filter1>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._rawData["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Prices.Tier1> Tiers
    {
        get
        {
            if (!this._rawData.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Prices.Tier1>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._rawData["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig() { }

    public PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRaw<PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig>
{
    public PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.Filter1,
        global::Orb.Models.Prices.Filter1FromRaw
    >)
)]
public sealed record class Filter1 : ModelBase
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._rawData.TryGetValue("property_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentNullException("property_key")
                );
        }
        init
        {
            this._rawData["property_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            if (!this._rawData.TryGetValue("property_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentNullException("property_value")
                );
        }
        init
        {
            this._rawData["property_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter1() { }

    public Filter1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.Filter1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter1FromRaw : IFromRaw<global::Orb.Models.Prices.Filter1>
{
    public global::Orb.Models.Prices.Filter1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.Filter1.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.Prices.Tier1, global::Orb.Models.Prices.Tier1FromRaw>)
)]
public sealed record class Tier1 : ModelBase
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            if (!this._rawData.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier1() { }

    public Tier1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.Tier1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier1(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class Tier1FromRaw : IFromRaw<global::Orb.Models.Prices.Tier1>
{
    public global::Orb.Models.Prices.Tier1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.Tier1.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceEvaluationModelPriceBulkWithFiltersCadenceConverter))]
public enum PriceEvaluationModelPriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluationModelPriceBulkWithFiltersCadenceConverter
    : JsonConverter<PriceEvaluationModelPriceBulkWithFiltersCadence>
{
    public override PriceEvaluationModelPriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceEvaluationModelPriceBulkWithFiltersCadence.Annual,
            "semi_annual" => PriceEvaluationModelPriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" => PriceEvaluationModelPriceBulkWithFiltersCadence.Monthly,
            "quarterly" => PriceEvaluationModelPriceBulkWithFiltersCadence.Quarterly,
            "one_time" => PriceEvaluationModelPriceBulkWithFiltersCadence.OneTime,
            "custom" => PriceEvaluationModelPriceBulkWithFiltersCadence.Custom,
            _ => (PriceEvaluationModelPriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluationModelPriceBulkWithFiltersCadence.Annual => "annual",
                PriceEvaluationModelPriceBulkWithFiltersCadence.SemiAnnual => "semi_annual",
                PriceEvaluationModelPriceBulkWithFiltersCadence.Monthly => "monthly",
                PriceEvaluationModelPriceBulkWithFiltersCadence.Quarterly => "quarterly",
                PriceEvaluationModelPriceBulkWithFiltersCadence.OneTime => "one_time",
                PriceEvaluationModelPriceBulkWithFiltersCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceEvaluationModelPriceBulkWithFiltersModelType
{
    public JsonElement Json { get; private init; }

    public PriceEvaluationModelPriceBulkWithFiltersModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    PriceEvaluationModelPriceBulkWithFiltersModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new PriceEvaluationModelPriceBulkWithFiltersModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceEvaluationModelPriceBulkWithFiltersModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceEvaluationModelPriceBulkWithFiltersModelType>
    {
        public override PriceEvaluationModelPriceBulkWithFiltersModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceEvaluationModelPriceBulkWithFiltersModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(PriceEvaluationModelPriceBulkWithFiltersConversionRateConfigConverter))]
public record class PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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
                    "Data did not match any variant of PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig"
                );
        }
    }

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
                "Data did not match any variant of PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig"
            );
        }
    }
}

sealed class PriceEvaluationModelPriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig>
{
    public override PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluationModelPriceGroupedWithMinMaxThresholds,
        PriceEvaluationModelPriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceGroupedWithMinMaxThresholds : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "grouped_with_min_max_thresholds_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_with_min_max_thresholds_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentNullException("grouped_with_min_max_thresholds_config")
                );
        }
        init
        {
            this._rawData["grouped_with_min_max_thresholds_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = new();
    }

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceGroupedWithMinMaxThresholds(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRaw<PriceEvaluationModelPriceGroupedWithMinMaxThresholds>
{
    public PriceEvaluationModelPriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPriceGroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadenceConverter))]
public enum PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence>
{
    public override PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ => (PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Annual => "annual",
                PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual =>
                    "semi_annual",
                PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Quarterly =>
                    "quarterly",
                PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence.Custom => "custom",
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
    typeof(ModelConverter<
        PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : ModelBase
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            if (!this._rawData.TryGetValue("maximum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentNullException("maximum_charge")
                );
        }
        init
        {
            this._rawData["maximum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            if (!this._rawData.TryGetValue("minimum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentNullException("minimum_charge")
                );
        }
        init
        {
            this._rawData["minimum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            if (!this._rawData.TryGetValue("per_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "per_unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentNullException("per_unit_rate")
                );
        }
        init
        {
            this._rawData["per_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig()
    { }

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRaw<PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluationModelPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType
{
    public JsonElement Json { get; private init; }

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType>
    {
        public override PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceEvaluationModelPriceGroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        JsonElement json
    )
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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
                    "Data did not match any variant of PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

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
                "Data did not match any variant of PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
    }
}

sealed class PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluationModelPriceCumulativeGroupedAllocation,
        PriceEvaluationModelPriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceCumulativeGroupedAllocation : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        PriceEvaluationModelPriceCumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, PriceEvaluationModelPriceCumulativeGroupedAllocationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "cumulative_grouped_allocation_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_grouped_allocation_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentNullException("cumulative_grouped_allocation_config")
                );
        }
        init
        {
            this._rawData["cumulative_grouped_allocation_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public PriceEvaluationModelPriceCumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceCumulativeGroupedAllocationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
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

    public PriceEvaluationModelPriceCumulativeGroupedAllocation()
    {
        this.ModelType = new();
    }

    public PriceEvaluationModelPriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceCumulativeGroupedAllocation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPriceCumulativeGroupedAllocationFromRaw
    : IFromRaw<PriceEvaluationModelPriceCumulativeGroupedAllocation>
{
    public PriceEvaluationModelPriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPriceCumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceEvaluationModelPriceCumulativeGroupedAllocationCadenceConverter))]
public enum PriceEvaluationModelPriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluationModelPriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<PriceEvaluationModelPriceCumulativeGroupedAllocationCadence>
{
    public override PriceEvaluationModelPriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" => PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Custom,
            _ => (PriceEvaluationModelPriceCumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Annual => "annual",
                PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.SemiAnnual =>
                    "semi_annual",
                PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Monthly => "monthly",
                PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Quarterly =>
                    "quarterly",
                PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.OneTime => "one_time",
                PriceEvaluationModelPriceCumulativeGroupedAllocationCadence.Custom => "custom",
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
    typeof(ModelConverter<
        PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : ModelBase
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            if (!this._rawData.TryGetValue("cumulative_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentNullException("cumulative_allocation")
                );
        }
        init
        {
            this._rawData["cumulative_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            if (!this._rawData.TryGetValue("group_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "group_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentNullException("group_allocation")
                );
        }
        init
        {
            this._rawData["group_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig()
    { }

    public PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRaw<PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    public PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceEvaluationModelPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceEvaluationModelPriceCumulativeGroupedAllocationModelType
{
    public JsonElement Json { get; private init; }

    public PriceEvaluationModelPriceCumulativeGroupedAllocationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"");
    }

    PriceEvaluationModelPriceCumulativeGroupedAllocationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new PriceEvaluationModelPriceCumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceEvaluationModelPriceCumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceEvaluationModelPriceCumulativeGroupedAllocationModelType>
    {
        public override PriceEvaluationModelPriceCumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceEvaluationModelPriceCumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig(
        JsonElement json
    )
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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
                    "Data did not match any variant of PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

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
                "Data did not match any variant of PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
    }
}

sealed class PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluationModelPricePercent,
        PriceEvaluationModelPricePercentFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPricePercent : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceEvaluationModelPricePercentCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, PriceEvaluationModelPricePercentCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public PriceEvaluationModelPricePercentModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPricePercentModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required PriceEvaluationModelPricePercentPercentConfig PercentConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPricePercentPercentConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentNullException("percent_config")
                );
        }
        init
        {
            this._rawData["percent_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluationModelPricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceEvaluationModelPricePercentConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
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

    public PriceEvaluationModelPricePercent()
    {
        this.ModelType = new();
    }

    public PriceEvaluationModelPricePercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPricePercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPricePercentFromRaw : IFromRaw<PriceEvaluationModelPricePercent>
{
    public PriceEvaluationModelPricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceEvaluationModelPricePercentCadenceConverter))]
public enum PriceEvaluationModelPricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluationModelPricePercentCadenceConverter
    : JsonConverter<PriceEvaluationModelPricePercentCadence>
{
    public override PriceEvaluationModelPricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceEvaluationModelPricePercentCadence.Annual,
            "semi_annual" => PriceEvaluationModelPricePercentCadence.SemiAnnual,
            "monthly" => PriceEvaluationModelPricePercentCadence.Monthly,
            "quarterly" => PriceEvaluationModelPricePercentCadence.Quarterly,
            "one_time" => PriceEvaluationModelPricePercentCadence.OneTime,
            "custom" => PriceEvaluationModelPricePercentCadence.Custom,
            _ => (PriceEvaluationModelPricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluationModelPricePercentCadence.Annual => "annual",
                PriceEvaluationModelPricePercentCadence.SemiAnnual => "semi_annual",
                PriceEvaluationModelPricePercentCadence.Monthly => "monthly",
                PriceEvaluationModelPricePercentCadence.Quarterly => "quarterly",
                PriceEvaluationModelPricePercentCadence.OneTime => "one_time",
                PriceEvaluationModelPricePercentCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceEvaluationModelPricePercentModelType
{
    public JsonElement Json { get; private init; }

    public PriceEvaluationModelPricePercentModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    PriceEvaluationModelPricePercentModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new PriceEvaluationModelPricePercentModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceEvaluationModelPricePercentModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceEvaluationModelPricePercentModelType>
    {
        public override PriceEvaluationModelPricePercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceEvaluationModelPricePercentModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluationModelPricePercentPercentConfig,
        PriceEvaluationModelPricePercentPercentConfigFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPricePercentPercentConfig : ModelBase
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._rawData.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public PriceEvaluationModelPricePercentPercentConfig() { }

    public PriceEvaluationModelPricePercentPercentConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPricePercentPercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluationModelPricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class PriceEvaluationModelPricePercentPercentConfigFromRaw
    : IFromRaw<PriceEvaluationModelPricePercentPercentConfig>
{
    public PriceEvaluationModelPricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPricePercentPercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PriceEvaluationModelPricePercentConversionRateConfigConverter))]
public record class PriceEvaluationModelPricePercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluationModelPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPricePercentConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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
                    "Data did not match any variant of PriceEvaluationModelPricePercentConversionRateConfig"
                );
        }
    }

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
                "Data did not match any variant of PriceEvaluationModelPricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluationModelPricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluationModelPricePercentConversionRateConfig"
            );
        }
    }
}

sealed class PriceEvaluationModelPricePercentConversionRateConfigConverter
    : JsonConverter<PriceEvaluationModelPricePercentConversionRateConfig>
{
    public override PriceEvaluationModelPricePercentConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new PriceEvaluationModelPricePercentConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluationModelPriceEventOutput,
        PriceEvaluationModelPriceEventOutputFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceEventOutput : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceEvaluationModelPriceEventOutputCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, PriceEvaluationModelPriceEventOutputCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required PriceEvaluationModelPriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceEventOutputEventOutputConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentNullException("event_output_config")
                );
        }
        init
        {
            this._rawData["event_output_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public PriceEvaluationModelPriceEventOutputModelType ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceEventOutputModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceEvaluationModelPriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceEvaluationModelPriceEventOutputConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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

    public PriceEvaluationModelPriceEventOutput()
    {
        this.ModelType = new();
    }

    public PriceEvaluationModelPriceEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluationModelPriceEventOutputFromRaw : IFromRaw<PriceEvaluationModelPriceEventOutput>
{
    public PriceEvaluationModelPriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceEvaluationModelPriceEventOutputCadenceConverter))]
public enum PriceEvaluationModelPriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceEvaluationModelPriceEventOutputCadenceConverter
    : JsonConverter<PriceEvaluationModelPriceEventOutputCadence>
{
    public override PriceEvaluationModelPriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceEvaluationModelPriceEventOutputCadence.Annual,
            "semi_annual" => PriceEvaluationModelPriceEventOutputCadence.SemiAnnual,
            "monthly" => PriceEvaluationModelPriceEventOutputCadence.Monthly,
            "quarterly" => PriceEvaluationModelPriceEventOutputCadence.Quarterly,
            "one_time" => PriceEvaluationModelPriceEventOutputCadence.OneTime,
            "custom" => PriceEvaluationModelPriceEventOutputCadence.Custom,
            _ => (PriceEvaluationModelPriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceEvaluationModelPriceEventOutputCadence.Annual => "annual",
                PriceEvaluationModelPriceEventOutputCadence.SemiAnnual => "semi_annual",
                PriceEvaluationModelPriceEventOutputCadence.Monthly => "monthly",
                PriceEvaluationModelPriceEventOutputCadence.Quarterly => "quarterly",
                PriceEvaluationModelPriceEventOutputCadence.OneTime => "one_time",
                PriceEvaluationModelPriceEventOutputCadence.Custom => "custom",
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
    typeof(ModelConverter<
        PriceEvaluationModelPriceEventOutputEventOutputConfig,
        PriceEvaluationModelPriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class PriceEvaluationModelPriceEventOutputEventOutputConfig : ModelBase
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_rating_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_rating_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentNullException("unit_rating_key")
                );
        }
        init
        {
            this._rawData["unit_rating_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get
        {
            if (!this._rawData.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["default_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public PriceEvaluationModelPriceEventOutputEventOutputConfig() { }

    public PriceEvaluationModelPriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluationModelPriceEventOutputEventOutputConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluationModelPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluationModelPriceEventOutputEventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class PriceEvaluationModelPriceEventOutputEventOutputConfigFromRaw
    : IFromRaw<PriceEvaluationModelPriceEventOutputEventOutputConfig>
{
    public PriceEvaluationModelPriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluationModelPriceEventOutputEventOutputConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceEvaluationModelPriceEventOutputModelType
{
    public JsonElement Json { get; private init; }

    public PriceEvaluationModelPriceEventOutputModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    PriceEvaluationModelPriceEventOutputModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new PriceEvaluationModelPriceEventOutputModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceEvaluationModelPriceEventOutputModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceEvaluationModelPriceEventOutputModelType>
    {
        public override PriceEvaluationModelPriceEventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceEvaluationModelPriceEventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(PriceEvaluationModelPriceEventOutputConversionRateConfigConverter))]
public record class PriceEvaluationModelPriceEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceEvaluationModelPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceEvaluationModelPriceEventOutputConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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
                    "Data did not match any variant of PriceEvaluationModelPriceEventOutputConversionRateConfig"
                );
        }
    }

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
                "Data did not match any variant of PriceEvaluationModelPriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceEvaluationModelPriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceEvaluationModelPriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceEvaluationModelPriceEventOutputConversionRateConfig"
            );
        }
    }
}

sealed class PriceEvaluationModelPriceEventOutputConversionRateConfigConverter
    : JsonConverter<PriceEvaluationModelPriceEventOutputConversionRateConfig>
{
    public override PriceEvaluationModelPriceEventOutputConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new PriceEvaluationModelPriceEventOutputConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceEvaluationModelPriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
