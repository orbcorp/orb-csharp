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
/// This endpoint is used to create a [price](/product-catalog/price-configuration).
/// A price created using this endpoint is always an add-on, meaning that it's not
/// associated with a specific plan and can instead be individually added to subscriptions,
/// including subscriptions on different plans.
///
/// <para>An `external_price_id` can be optionally specified as an alias to allow
/// ergonomic interaction with prices in the Orb API.</para>
///
/// <para>See the [Price resource](/product-catalog/price-configuration) for the
/// specification of different price model configurations possible in this endpoint.</para>
/// </summary>
public sealed record class PriceCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// New floating price request body params.
    /// </summary>
    public required Body Body
    {
        get { return ModelBase.GetNotNullClass<Body>(this.RawBodyData, "body"); }
        init { ModelBase.Set(this._rawBodyData, "body", value); }
    }

    public PriceCreateParams() { }

    public PriceCreateParams(PriceCreateParams priceCreateParams)
        : base(priceCreateParams)
    {
        this._rawBodyData = [.. priceCreateParams._rawBodyData];
    }

    public PriceCreateParams(
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
    PriceCreateParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static PriceCreateParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/prices")
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

/// <summary>
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public record class Body
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
                newFloatingUnitPrice: (x) => x.Currency,
                newFloatingTieredPrice: (x) => x.Currency,
                newFloatingBulkPrice: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newFloatingPackagePrice: (x) => x.Currency,
                newFloatingMatrixPrice: (x) => x.Currency,
                newFloatingThresholdTotalAmountPrice: (x) => x.Currency,
                newFloatingTieredPackagePrice: (x) => x.Currency,
                newFloatingTieredWithMinimumPrice: (x) => x.Currency,
                newFloatingGroupedTieredPrice: (x) => x.Currency,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.Currency,
                newFloatingPackageWithAllocationPrice: (x) => x.Currency,
                newFloatingUnitWithPercentPrice: (x) => x.Currency,
                newFloatingMatrixWithAllocationPrice: (x) => x.Currency,
                newFloatingTieredWithProrationPrice: (x) => x.Currency,
                newFloatingUnitWithProrationPrice: (x) => x.Currency,
                newFloatingGroupedAllocationPrice: (x) => x.Currency,
                newFloatingBulkWithProrationPrice: (x) => x.Currency,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.Currency,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.Currency,
                newFloatingGroupedTieredPackagePrice: (x) => x.Currency,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.Currency,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.Currency,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.Currency,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.Currency,
                cumulativeGroupedAllocation: (x) => x.Currency,
                newFloatingMinimumCompositePrice: (x) => x.Currency,
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
                newFloatingUnitPrice: (x) => x.ItemID,
                newFloatingTieredPrice: (x) => x.ItemID,
                newFloatingBulkPrice: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newFloatingPackagePrice: (x) => x.ItemID,
                newFloatingMatrixPrice: (x) => x.ItemID,
                newFloatingThresholdTotalAmountPrice: (x) => x.ItemID,
                newFloatingTieredPackagePrice: (x) => x.ItemID,
                newFloatingTieredWithMinimumPrice: (x) => x.ItemID,
                newFloatingGroupedTieredPrice: (x) => x.ItemID,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.ItemID,
                newFloatingPackageWithAllocationPrice: (x) => x.ItemID,
                newFloatingUnitWithPercentPrice: (x) => x.ItemID,
                newFloatingMatrixWithAllocationPrice: (x) => x.ItemID,
                newFloatingTieredWithProrationPrice: (x) => x.ItemID,
                newFloatingUnitWithProrationPrice: (x) => x.ItemID,
                newFloatingGroupedAllocationPrice: (x) => x.ItemID,
                newFloatingBulkWithProrationPrice: (x) => x.ItemID,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.ItemID,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.ItemID,
                newFloatingGroupedTieredPackagePrice: (x) => x.ItemID,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.ItemID,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.ItemID,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.ItemID,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.ItemID,
                cumulativeGroupedAllocation: (x) => x.ItemID,
                newFloatingMinimumCompositePrice: (x) => x.ItemID,
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
                newFloatingUnitPrice: (x) => x.Name,
                newFloatingTieredPrice: (x) => x.Name,
                newFloatingBulkPrice: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newFloatingPackagePrice: (x) => x.Name,
                newFloatingMatrixPrice: (x) => x.Name,
                newFloatingThresholdTotalAmountPrice: (x) => x.Name,
                newFloatingTieredPackagePrice: (x) => x.Name,
                newFloatingTieredWithMinimumPrice: (x) => x.Name,
                newFloatingGroupedTieredPrice: (x) => x.Name,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.Name,
                newFloatingPackageWithAllocationPrice: (x) => x.Name,
                newFloatingUnitWithPercentPrice: (x) => x.Name,
                newFloatingMatrixWithAllocationPrice: (x) => x.Name,
                newFloatingTieredWithProrationPrice: (x) => x.Name,
                newFloatingUnitWithProrationPrice: (x) => x.Name,
                newFloatingGroupedAllocationPrice: (x) => x.Name,
                newFloatingBulkWithProrationPrice: (x) => x.Name,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.Name,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.Name,
                newFloatingGroupedTieredPackagePrice: (x) => x.Name,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.Name,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.Name,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.Name,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.Name,
                cumulativeGroupedAllocation: (x) => x.Name,
                newFloatingMinimumCompositePrice: (x) => x.Name,
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
                newFloatingUnitPrice: (x) => x.BillableMetricID,
                newFloatingTieredPrice: (x) => x.BillableMetricID,
                newFloatingBulkPrice: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newFloatingPackagePrice: (x) => x.BillableMetricID,
                newFloatingMatrixPrice: (x) => x.BillableMetricID,
                newFloatingThresholdTotalAmountPrice: (x) => x.BillableMetricID,
                newFloatingTieredPackagePrice: (x) => x.BillableMetricID,
                newFloatingTieredWithMinimumPrice: (x) => x.BillableMetricID,
                newFloatingGroupedTieredPrice: (x) => x.BillableMetricID,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.BillableMetricID,
                newFloatingPackageWithAllocationPrice: (x) => x.BillableMetricID,
                newFloatingUnitWithPercentPrice: (x) => x.BillableMetricID,
                newFloatingMatrixWithAllocationPrice: (x) => x.BillableMetricID,
                newFloatingTieredWithProrationPrice: (x) => x.BillableMetricID,
                newFloatingUnitWithProrationPrice: (x) => x.BillableMetricID,
                newFloatingGroupedAllocationPrice: (x) => x.BillableMetricID,
                newFloatingBulkWithProrationPrice: (x) => x.BillableMetricID,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.BillableMetricID,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.BillableMetricID,
                newFloatingGroupedTieredPackagePrice: (x) => x.BillableMetricID,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.BillableMetricID,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.BillableMetricID,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.BillableMetricID,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.BillableMetricID,
                cumulativeGroupedAllocation: (x) => x.BillableMetricID,
                newFloatingMinimumCompositePrice: (x) => x.BillableMetricID,
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
                newFloatingUnitPrice: (x) => x.BilledInAdvance,
                newFloatingTieredPrice: (x) => x.BilledInAdvance,
                newFloatingBulkPrice: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newFloatingPackagePrice: (x) => x.BilledInAdvance,
                newFloatingMatrixPrice: (x) => x.BilledInAdvance,
                newFloatingThresholdTotalAmountPrice: (x) => x.BilledInAdvance,
                newFloatingTieredPackagePrice: (x) => x.BilledInAdvance,
                newFloatingTieredWithMinimumPrice: (x) => x.BilledInAdvance,
                newFloatingGroupedTieredPrice: (x) => x.BilledInAdvance,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.BilledInAdvance,
                newFloatingPackageWithAllocationPrice: (x) => x.BilledInAdvance,
                newFloatingUnitWithPercentPrice: (x) => x.BilledInAdvance,
                newFloatingMatrixWithAllocationPrice: (x) => x.BilledInAdvance,
                newFloatingTieredWithProrationPrice: (x) => x.BilledInAdvance,
                newFloatingUnitWithProrationPrice: (x) => x.BilledInAdvance,
                newFloatingGroupedAllocationPrice: (x) => x.BilledInAdvance,
                newFloatingBulkWithProrationPrice: (x) => x.BilledInAdvance,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.BilledInAdvance,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.BilledInAdvance,
                newFloatingGroupedTieredPackagePrice: (x) => x.BilledInAdvance,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.BilledInAdvance,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.BilledInAdvance,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.BilledInAdvance,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.BilledInAdvance,
                cumulativeGroupedAllocation: (x) => x.BilledInAdvance,
                newFloatingMinimumCompositePrice: (x) => x.BilledInAdvance,
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
                newFloatingUnitPrice: (x) => x.BillingCycleConfiguration,
                newFloatingTieredPrice: (x) => x.BillingCycleConfiguration,
                newFloatingBulkPrice: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newFloatingPackagePrice: (x) => x.BillingCycleConfiguration,
                newFloatingMatrixPrice: (x) => x.BillingCycleConfiguration,
                newFloatingThresholdTotalAmountPrice: (x) => x.BillingCycleConfiguration,
                newFloatingTieredPackagePrice: (x) => x.BillingCycleConfiguration,
                newFloatingTieredWithMinimumPrice: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedTieredPrice: (x) => x.BillingCycleConfiguration,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.BillingCycleConfiguration,
                newFloatingPackageWithAllocationPrice: (x) => x.BillingCycleConfiguration,
                newFloatingUnitWithPercentPrice: (x) => x.BillingCycleConfiguration,
                newFloatingMatrixWithAllocationPrice: (x) => x.BillingCycleConfiguration,
                newFloatingTieredWithProrationPrice: (x) => x.BillingCycleConfiguration,
                newFloatingUnitWithProrationPrice: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedAllocationPrice: (x) => x.BillingCycleConfiguration,
                newFloatingBulkWithProrationPrice: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedTieredPackagePrice: (x) => x.BillingCycleConfiguration,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.BillingCycleConfiguration,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.BillingCycleConfiguration,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.BillingCycleConfiguration,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingMinimumCompositePrice: (x) => x.BillingCycleConfiguration,
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
                newFloatingUnitPrice: (x) => x.ConversionRate,
                newFloatingTieredPrice: (x) => x.ConversionRate,
                newFloatingBulkPrice: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newFloatingPackagePrice: (x) => x.ConversionRate,
                newFloatingMatrixPrice: (x) => x.ConversionRate,
                newFloatingThresholdTotalAmountPrice: (x) => x.ConversionRate,
                newFloatingTieredPackagePrice: (x) => x.ConversionRate,
                newFloatingTieredWithMinimumPrice: (x) => x.ConversionRate,
                newFloatingGroupedTieredPrice: (x) => x.ConversionRate,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.ConversionRate,
                newFloatingPackageWithAllocationPrice: (x) => x.ConversionRate,
                newFloatingUnitWithPercentPrice: (x) => x.ConversionRate,
                newFloatingMatrixWithAllocationPrice: (x) => x.ConversionRate,
                newFloatingTieredWithProrationPrice: (x) => x.ConversionRate,
                newFloatingUnitWithProrationPrice: (x) => x.ConversionRate,
                newFloatingGroupedAllocationPrice: (x) => x.ConversionRate,
                newFloatingBulkWithProrationPrice: (x) => x.ConversionRate,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.ConversionRate,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.ConversionRate,
                newFloatingGroupedTieredPackagePrice: (x) => x.ConversionRate,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.ConversionRate,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.ConversionRate,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.ConversionRate,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.ConversionRate,
                cumulativeGroupedAllocation: (x) => x.ConversionRate,
                newFloatingMinimumCompositePrice: (x) => x.ConversionRate,
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
                newFloatingUnitPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingBulkPrice: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newFloatingPackagePrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrixPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingThresholdTotalAmountPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredPackagePrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredWithMinimumPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedTieredPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingPackageWithAllocationPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingUnitWithPercentPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrixWithAllocationPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredWithProrationPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingUnitWithProrationPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedAllocationPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingBulkWithProrationPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedTieredPackagePrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.DimensionalPriceConfiguration,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) =>
                    x.DimensionalPriceConfiguration,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) =>
                    x.DimensionalPriceConfiguration,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingMinimumCompositePrice: (x) => x.DimensionalPriceConfiguration,
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
                newFloatingUnitPrice: (x) => x.ExternalPriceID,
                newFloatingTieredPrice: (x) => x.ExternalPriceID,
                newFloatingBulkPrice: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newFloatingPackagePrice: (x) => x.ExternalPriceID,
                newFloatingMatrixPrice: (x) => x.ExternalPriceID,
                newFloatingThresholdTotalAmountPrice: (x) => x.ExternalPriceID,
                newFloatingTieredPackagePrice: (x) => x.ExternalPriceID,
                newFloatingTieredWithMinimumPrice: (x) => x.ExternalPriceID,
                newFloatingGroupedTieredPrice: (x) => x.ExternalPriceID,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.ExternalPriceID,
                newFloatingPackageWithAllocationPrice: (x) => x.ExternalPriceID,
                newFloatingUnitWithPercentPrice: (x) => x.ExternalPriceID,
                newFloatingMatrixWithAllocationPrice: (x) => x.ExternalPriceID,
                newFloatingTieredWithProrationPrice: (x) => x.ExternalPriceID,
                newFloatingUnitWithProrationPrice: (x) => x.ExternalPriceID,
                newFloatingGroupedAllocationPrice: (x) => x.ExternalPriceID,
                newFloatingBulkWithProrationPrice: (x) => x.ExternalPriceID,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.ExternalPriceID,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.ExternalPriceID,
                newFloatingGroupedTieredPackagePrice: (x) => x.ExternalPriceID,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.ExternalPriceID,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.ExternalPriceID,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.ExternalPriceID,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.ExternalPriceID,
                cumulativeGroupedAllocation: (x) => x.ExternalPriceID,
                newFloatingMinimumCompositePrice: (x) => x.ExternalPriceID,
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
                newFloatingUnitPrice: (x) => x.FixedPriceQuantity,
                newFloatingTieredPrice: (x) => x.FixedPriceQuantity,
                newFloatingBulkPrice: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newFloatingPackagePrice: (x) => x.FixedPriceQuantity,
                newFloatingMatrixPrice: (x) => x.FixedPriceQuantity,
                newFloatingThresholdTotalAmountPrice: (x) => x.FixedPriceQuantity,
                newFloatingTieredPackagePrice: (x) => x.FixedPriceQuantity,
                newFloatingTieredWithMinimumPrice: (x) => x.FixedPriceQuantity,
                newFloatingGroupedTieredPrice: (x) => x.FixedPriceQuantity,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.FixedPriceQuantity,
                newFloatingPackageWithAllocationPrice: (x) => x.FixedPriceQuantity,
                newFloatingUnitWithPercentPrice: (x) => x.FixedPriceQuantity,
                newFloatingMatrixWithAllocationPrice: (x) => x.FixedPriceQuantity,
                newFloatingTieredWithProrationPrice: (x) => x.FixedPriceQuantity,
                newFloatingUnitWithProrationPrice: (x) => x.FixedPriceQuantity,
                newFloatingGroupedAllocationPrice: (x) => x.FixedPriceQuantity,
                newFloatingBulkWithProrationPrice: (x) => x.FixedPriceQuantity,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.FixedPriceQuantity,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.FixedPriceQuantity,
                newFloatingGroupedTieredPackagePrice: (x) => x.FixedPriceQuantity,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.FixedPriceQuantity,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.FixedPriceQuantity,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.FixedPriceQuantity,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.FixedPriceQuantity,
                cumulativeGroupedAllocation: (x) => x.FixedPriceQuantity,
                newFloatingMinimumCompositePrice: (x) => x.FixedPriceQuantity,
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
                newFloatingUnitPrice: (x) => x.InvoiceGroupingKey,
                newFloatingTieredPrice: (x) => x.InvoiceGroupingKey,
                newFloatingBulkPrice: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newFloatingPackagePrice: (x) => x.InvoiceGroupingKey,
                newFloatingMatrixPrice: (x) => x.InvoiceGroupingKey,
                newFloatingThresholdTotalAmountPrice: (x) => x.InvoiceGroupingKey,
                newFloatingTieredPackagePrice: (x) => x.InvoiceGroupingKey,
                newFloatingTieredWithMinimumPrice: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedTieredPrice: (x) => x.InvoiceGroupingKey,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.InvoiceGroupingKey,
                newFloatingPackageWithAllocationPrice: (x) => x.InvoiceGroupingKey,
                newFloatingUnitWithPercentPrice: (x) => x.InvoiceGroupingKey,
                newFloatingMatrixWithAllocationPrice: (x) => x.InvoiceGroupingKey,
                newFloatingTieredWithProrationPrice: (x) => x.InvoiceGroupingKey,
                newFloatingUnitWithProrationPrice: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedAllocationPrice: (x) => x.InvoiceGroupingKey,
                newFloatingBulkWithProrationPrice: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedTieredPackagePrice: (x) => x.InvoiceGroupingKey,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.InvoiceGroupingKey,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.InvoiceGroupingKey,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) => x.InvoiceGroupingKey,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.InvoiceGroupingKey,
                cumulativeGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingMinimumCompositePrice: (x) => x.InvoiceGroupingKey,
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
                newFloatingUnitPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingBulkPrice: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newFloatingPackagePrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrixPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingThresholdTotalAmountPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredPackagePrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredWithMinimumPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedTieredPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredPackageWithMinimumPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingPackageWithAllocationPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingUnitWithPercentPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrixWithAllocationPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredWithProrationPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingUnitWithProrationPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedAllocationPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingBulkWithProrationPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedWithProratedMinimumPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedWithMeteredMinimumPrice: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrixWithDisplayNamePrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedTieredPackagePrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingMaxGroupTieredPackagePrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingScalableMatrixWithUnitPricingPrice: (x) => x.InvoicingCycleConfiguration,
                newFloatingScalableMatrixWithTieredPricingPrice: (x) =>
                    x.InvoicingCycleConfiguration,
                newFloatingCumulativeGroupedBulkPrice: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingMinimumCompositePrice: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public Body(NewFloatingUnitPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(global::Orb.Models.Prices.BulkWithFilters value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingMatrixPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingThresholdTotalAmountPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingTieredWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingGroupedTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingTieredPackageWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingPackageWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingUnitWithPercentPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingMatrixWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingTieredWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingUnitWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingGroupedAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingBulkWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingGroupedWithProratedMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingGroupedWithMeteredMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(
        global::Orb.Models.Prices.GroupedWithMinMaxThresholds value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingMatrixWithDisplayNamePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingGroupedTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingMaxGroupTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingScalableMatrixWithUnitPricingPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingScalableMatrixWithTieredPricingPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingCumulativeGroupedBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(
        global::Orb.Models.Prices.CumulativeGroupedAllocation value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public Body(NewFloatingMinimumCompositePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(global::Orb.Models.Prices.Percent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(global::Orb.Models.Prices.EventOutput value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingUnitPrice(out var value)) {
    ///     // `value` is of type `NewFloatingUnitPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnitPrice([NotNullWhen(true)] out NewFloatingUnitPrice? value)
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
    /// if (instance.TryPickNewFloatingTieredPrice(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredPrice([NotNullWhen(true)] out NewFloatingTieredPrice? value)
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
    /// if (instance.TryPickNewFloatingBulkPrice(out var value)) {
    ///     // `value` is of type `NewFloatingBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingBulkPrice([NotNullWhen(true)] out NewFloatingBulkPrice? value)
    {
        value = this.Value as NewFloatingBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Prices.BulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Prices.BulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out global::Orb.Models.Prices.BulkWithFilters? value
    )
    {
        value = this.Value as global::Orb.Models.Prices.BulkWithFilters;
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
    /// if (instance.TryPickNewFloatingPackagePrice(out var value)) {
    ///     // `value` is of type `NewFloatingPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingPackagePrice(
        [NotNullWhen(true)] out NewFloatingPackagePrice? value
    )
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
    /// if (instance.TryPickNewFloatingMatrixPrice(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrixPrice([NotNullWhen(true)] out NewFloatingMatrixPrice? value)
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
    /// if (instance.TryPickNewFloatingThresholdTotalAmountPrice(out var value)) {
    ///     // `value` is of type `NewFloatingThresholdTotalAmountPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingThresholdTotalAmountPrice(
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
    /// if (instance.TryPickNewFloatingTieredPackagePrice(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredPackagePrice(
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
    /// if (instance.TryPickNewFloatingTieredWithMinimumPrice(out var value)) {
    ///     // `value` is of type `NewFloatingTieredWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredWithMinimumPrice(
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
    /// if (instance.TryPickNewFloatingGroupedTieredPrice(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedTieredPrice(
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
    /// if (instance.TryPickNewFloatingTieredPackageWithMinimumPrice(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPackageWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredPackageWithMinimumPrice(
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
    /// if (instance.TryPickNewFloatingPackageWithAllocationPrice(out var value)) {
    ///     // `value` is of type `NewFloatingPackageWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingPackageWithAllocationPrice(
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
    /// if (instance.TryPickNewFloatingUnitWithPercentPrice(out var value)) {
    ///     // `value` is of type `NewFloatingUnitWithPercentPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnitWithPercentPrice(
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
    /// if (instance.TryPickNewFloatingMatrixWithAllocationPrice(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrixWithAllocationPrice(
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
    /// if (instance.TryPickNewFloatingTieredWithProrationPrice(out var value)) {
    ///     // `value` is of type `NewFloatingTieredWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredWithProrationPrice(
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
    /// if (instance.TryPickNewFloatingUnitWithProrationPrice(out var value)) {
    ///     // `value` is of type `NewFloatingUnitWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnitWithProrationPrice(
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
    /// if (instance.TryPickNewFloatingGroupedAllocationPrice(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedAllocationPrice(
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
    /// if (instance.TryPickNewFloatingBulkWithProrationPrice(out var value)) {
    ///     // `value` is of type `NewFloatingBulkWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingBulkWithProrationPrice(
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
    /// if (instance.TryPickNewFloatingGroupedWithProratedMinimumPrice(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedWithProratedMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedWithProratedMinimumPrice(
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
    /// if (instance.TryPickNewFloatingGroupedWithMeteredMinimumPrice(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedWithMeteredMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedWithMeteredMinimumPrice(
        [NotNullWhen(true)] out NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Prices.GroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Prices.GroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out global::Orb.Models.Prices.GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as global::Orb.Models.Prices.GroupedWithMinMaxThresholds;
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
    /// if (instance.TryPickNewFloatingMatrixWithDisplayNamePrice(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixWithDisplayNamePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrixWithDisplayNamePrice(
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
    /// if (instance.TryPickNewFloatingGroupedTieredPackagePrice(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedTieredPackagePrice(
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
    /// if (instance.TryPickNewFloatingMaxGroupTieredPackagePrice(out var value)) {
    ///     // `value` is of type `NewFloatingMaxGroupTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMaxGroupTieredPackagePrice(
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
    /// if (instance.TryPickNewFloatingScalableMatrixWithUnitPricingPrice(out var value)) {
    ///     // `value` is of type `NewFloatingScalableMatrixWithUnitPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingScalableMatrixWithUnitPricingPrice(
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
    /// if (instance.TryPickNewFloatingScalableMatrixWithTieredPricingPrice(out var value)) {
    ///     // `value` is of type `NewFloatingScalableMatrixWithTieredPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingScalableMatrixWithTieredPricingPrice(
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
    /// if (instance.TryPickNewFloatingCumulativeGroupedBulkPrice(out var value)) {
    ///     // `value` is of type `NewFloatingCumulativeGroupedBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingCumulativeGroupedBulkPrice(
        [NotNullWhen(true)] out NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewFloatingCumulativeGroupedBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Prices.CumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Prices.CumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out global::Orb.Models.Prices.CumulativeGroupedAllocation? value
    )
    {
        value = this.Value as global::Orb.Models.Prices.CumulativeGroupedAllocation;
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
    /// if (instance.TryPickNewFloatingMinimumCompositePrice(out var value)) {
    ///     // `value` is of type `NewFloatingMinimumCompositePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMinimumCompositePrice(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = this.Value as NewFloatingMinimumCompositePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Prices.Percent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Prices.Percent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent([NotNullWhen(true)] out global::Orb.Models.Prices.Percent? value)
    {
        value = this.Value as global::Orb.Models.Prices.Percent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Prices.EventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Prices.EventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput(
        [NotNullWhen(true)] out global::Orb.Models.Prices.EventOutput? value
    )
    {
        value = this.Value as global::Orb.Models.Prices.EventOutput;
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
    ///     (global::Orb.Models.Prices.BulkWithFilters value) => {...},
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
    ///     (global::Orb.Models.Prices.GroupedWithMinMaxThresholds value) => {...},
    ///     (NewFloatingMatrixWithDisplayNamePrice value) => {...},
    ///     (NewFloatingGroupedTieredPackagePrice value) => {...},
    ///     (NewFloatingMaxGroupTieredPackagePrice value) => {...},
    ///     (NewFloatingScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewFloatingScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewFloatingCumulativeGroupedBulkPrice value) => {...},
    ///     (global::Orb.Models.Prices.CumulativeGroupedAllocation value) => {...},
    ///     (NewFloatingMinimumCompositePrice value) => {...},
    ///     (global::Orb.Models.Prices.Percent value) => {...},
    ///     (global::Orb.Models.Prices.EventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewFloatingUnitPrice> newFloatingUnitPrice,
        System::Action<NewFloatingTieredPrice> newFloatingTieredPrice,
        System::Action<NewFloatingBulkPrice> newFloatingBulkPrice,
        System::Action<global::Orb.Models.Prices.BulkWithFilters> bulkWithFilters,
        System::Action<NewFloatingPackagePrice> newFloatingPackagePrice,
        System::Action<NewFloatingMatrixPrice> newFloatingMatrixPrice,
        System::Action<NewFloatingThresholdTotalAmountPrice> newFloatingThresholdTotalAmountPrice,
        System::Action<NewFloatingTieredPackagePrice> newFloatingTieredPackagePrice,
        System::Action<NewFloatingTieredWithMinimumPrice> newFloatingTieredWithMinimumPrice,
        System::Action<NewFloatingGroupedTieredPrice> newFloatingGroupedTieredPrice,
        System::Action<NewFloatingTieredPackageWithMinimumPrice> newFloatingTieredPackageWithMinimumPrice,
        System::Action<NewFloatingPackageWithAllocationPrice> newFloatingPackageWithAllocationPrice,
        System::Action<NewFloatingUnitWithPercentPrice> newFloatingUnitWithPercentPrice,
        System::Action<NewFloatingMatrixWithAllocationPrice> newFloatingMatrixWithAllocationPrice,
        System::Action<NewFloatingTieredWithProrationPrice> newFloatingTieredWithProrationPrice,
        System::Action<NewFloatingUnitWithProrationPrice> newFloatingUnitWithProrationPrice,
        System::Action<NewFloatingGroupedAllocationPrice> newFloatingGroupedAllocationPrice,
        System::Action<NewFloatingBulkWithProrationPrice> newFloatingBulkWithProrationPrice,
        System::Action<NewFloatingGroupedWithProratedMinimumPrice> newFloatingGroupedWithProratedMinimumPrice,
        System::Action<NewFloatingGroupedWithMeteredMinimumPrice> newFloatingGroupedWithMeteredMinimumPrice,
        System::Action<global::Orb.Models.Prices.GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayNamePrice,
        System::Action<NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackagePrice,
        System::Action<NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackagePrice,
        System::Action<NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricingPrice,
        System::Action<NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricingPrice,
        System::Action<NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulkPrice,
        System::Action<global::Orb.Models.Prices.CumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewFloatingMinimumCompositePrice> newFloatingMinimumCompositePrice,
        System::Action<global::Orb.Models.Prices.Percent> percent,
        System::Action<global::Orb.Models.Prices.EventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewFloatingUnitPrice value:
                newFloatingUnitPrice(value);
                break;
            case NewFloatingTieredPrice value:
                newFloatingTieredPrice(value);
                break;
            case NewFloatingBulkPrice value:
                newFloatingBulkPrice(value);
                break;
            case global::Orb.Models.Prices.BulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewFloatingPackagePrice value:
                newFloatingPackagePrice(value);
                break;
            case NewFloatingMatrixPrice value:
                newFloatingMatrixPrice(value);
                break;
            case NewFloatingThresholdTotalAmountPrice value:
                newFloatingThresholdTotalAmountPrice(value);
                break;
            case NewFloatingTieredPackagePrice value:
                newFloatingTieredPackagePrice(value);
                break;
            case NewFloatingTieredWithMinimumPrice value:
                newFloatingTieredWithMinimumPrice(value);
                break;
            case NewFloatingGroupedTieredPrice value:
                newFloatingGroupedTieredPrice(value);
                break;
            case NewFloatingTieredPackageWithMinimumPrice value:
                newFloatingTieredPackageWithMinimumPrice(value);
                break;
            case NewFloatingPackageWithAllocationPrice value:
                newFloatingPackageWithAllocationPrice(value);
                break;
            case NewFloatingUnitWithPercentPrice value:
                newFloatingUnitWithPercentPrice(value);
                break;
            case NewFloatingMatrixWithAllocationPrice value:
                newFloatingMatrixWithAllocationPrice(value);
                break;
            case NewFloatingTieredWithProrationPrice value:
                newFloatingTieredWithProrationPrice(value);
                break;
            case NewFloatingUnitWithProrationPrice value:
                newFloatingUnitWithProrationPrice(value);
                break;
            case NewFloatingGroupedAllocationPrice value:
                newFloatingGroupedAllocationPrice(value);
                break;
            case NewFloatingBulkWithProrationPrice value:
                newFloatingBulkWithProrationPrice(value);
                break;
            case NewFloatingGroupedWithProratedMinimumPrice value:
                newFloatingGroupedWithProratedMinimumPrice(value);
                break;
            case NewFloatingGroupedWithMeteredMinimumPrice value:
                newFloatingGroupedWithMeteredMinimumPrice(value);
                break;
            case global::Orb.Models.Prices.GroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewFloatingMatrixWithDisplayNamePrice value:
                newFloatingMatrixWithDisplayNamePrice(value);
                break;
            case NewFloatingGroupedTieredPackagePrice value:
                newFloatingGroupedTieredPackagePrice(value);
                break;
            case NewFloatingMaxGroupTieredPackagePrice value:
                newFloatingMaxGroupTieredPackagePrice(value);
                break;
            case NewFloatingScalableMatrixWithUnitPricingPrice value:
                newFloatingScalableMatrixWithUnitPricingPrice(value);
                break;
            case NewFloatingScalableMatrixWithTieredPricingPrice value:
                newFloatingScalableMatrixWithTieredPricingPrice(value);
                break;
            case NewFloatingCumulativeGroupedBulkPrice value:
                newFloatingCumulativeGroupedBulkPrice(value);
                break;
            case global::Orb.Models.Prices.CumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewFloatingMinimumCompositePrice value:
                newFloatingMinimumCompositePrice(value);
                break;
            case global::Orb.Models.Prices.Percent value:
                percent(value);
                break;
            case global::Orb.Models.Prices.EventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Body");
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
    ///     (global::Orb.Models.Prices.BulkWithFilters value) => {...},
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
    ///     (global::Orb.Models.Prices.GroupedWithMinMaxThresholds value) => {...},
    ///     (NewFloatingMatrixWithDisplayNamePrice value) => {...},
    ///     (NewFloatingGroupedTieredPackagePrice value) => {...},
    ///     (NewFloatingMaxGroupTieredPackagePrice value) => {...},
    ///     (NewFloatingScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewFloatingScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewFloatingCumulativeGroupedBulkPrice value) => {...},
    ///     (global::Orb.Models.Prices.CumulativeGroupedAllocation value) => {...},
    ///     (NewFloatingMinimumCompositePrice value) => {...},
    ///     (global::Orb.Models.Prices.Percent value) => {...},
    ///     (global::Orb.Models.Prices.EventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewFloatingUnitPrice, T> newFloatingUnitPrice,
        System::Func<NewFloatingTieredPrice, T> newFloatingTieredPrice,
        System::Func<NewFloatingBulkPrice, T> newFloatingBulkPrice,
        System::Func<global::Orb.Models.Prices.BulkWithFilters, T> bulkWithFilters,
        System::Func<NewFloatingPackagePrice, T> newFloatingPackagePrice,
        System::Func<NewFloatingMatrixPrice, T> newFloatingMatrixPrice,
        System::Func<NewFloatingThresholdTotalAmountPrice, T> newFloatingThresholdTotalAmountPrice,
        System::Func<NewFloatingTieredPackagePrice, T> newFloatingTieredPackagePrice,
        System::Func<NewFloatingTieredWithMinimumPrice, T> newFloatingTieredWithMinimumPrice,
        System::Func<NewFloatingGroupedTieredPrice, T> newFloatingGroupedTieredPrice,
        System::Func<
            NewFloatingTieredPackageWithMinimumPrice,
            T
        > newFloatingTieredPackageWithMinimumPrice,
        System::Func<
            NewFloatingPackageWithAllocationPrice,
            T
        > newFloatingPackageWithAllocationPrice,
        System::Func<NewFloatingUnitWithPercentPrice, T> newFloatingUnitWithPercentPrice,
        System::Func<NewFloatingMatrixWithAllocationPrice, T> newFloatingMatrixWithAllocationPrice,
        System::Func<NewFloatingTieredWithProrationPrice, T> newFloatingTieredWithProrationPrice,
        System::Func<NewFloatingUnitWithProrationPrice, T> newFloatingUnitWithProrationPrice,
        System::Func<NewFloatingGroupedAllocationPrice, T> newFloatingGroupedAllocationPrice,
        System::Func<NewFloatingBulkWithProrationPrice, T> newFloatingBulkWithProrationPrice,
        System::Func<
            NewFloatingGroupedWithProratedMinimumPrice,
            T
        > newFloatingGroupedWithProratedMinimumPrice,
        System::Func<
            NewFloatingGroupedWithMeteredMinimumPrice,
            T
        > newFloatingGroupedWithMeteredMinimumPrice,
        System::Func<
            global::Orb.Models.Prices.GroupedWithMinMaxThresholds,
            T
        > groupedWithMinMaxThresholds,
        System::Func<
            NewFloatingMatrixWithDisplayNamePrice,
            T
        > newFloatingMatrixWithDisplayNamePrice,
        System::Func<NewFloatingGroupedTieredPackagePrice, T> newFloatingGroupedTieredPackagePrice,
        System::Func<
            NewFloatingMaxGroupTieredPackagePrice,
            T
        > newFloatingMaxGroupTieredPackagePrice,
        System::Func<
            NewFloatingScalableMatrixWithUnitPricingPrice,
            T
        > newFloatingScalableMatrixWithUnitPricingPrice,
        System::Func<
            NewFloatingScalableMatrixWithTieredPricingPrice,
            T
        > newFloatingScalableMatrixWithTieredPricingPrice,
        System::Func<
            NewFloatingCumulativeGroupedBulkPrice,
            T
        > newFloatingCumulativeGroupedBulkPrice,
        System::Func<
            global::Orb.Models.Prices.CumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewFloatingMinimumCompositePrice, T> newFloatingMinimumCompositePrice,
        System::Func<global::Orb.Models.Prices.Percent, T> percent,
        System::Func<global::Orb.Models.Prices.EventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewFloatingUnitPrice value => newFloatingUnitPrice(value),
            NewFloatingTieredPrice value => newFloatingTieredPrice(value),
            NewFloatingBulkPrice value => newFloatingBulkPrice(value),
            global::Orb.Models.Prices.BulkWithFilters value => bulkWithFilters(value),
            NewFloatingPackagePrice value => newFloatingPackagePrice(value),
            NewFloatingMatrixPrice value => newFloatingMatrixPrice(value),
            NewFloatingThresholdTotalAmountPrice value => newFloatingThresholdTotalAmountPrice(
                value
            ),
            NewFloatingTieredPackagePrice value => newFloatingTieredPackagePrice(value),
            NewFloatingTieredWithMinimumPrice value => newFloatingTieredWithMinimumPrice(value),
            NewFloatingGroupedTieredPrice value => newFloatingGroupedTieredPrice(value),
            NewFloatingTieredPackageWithMinimumPrice value =>
                newFloatingTieredPackageWithMinimumPrice(value),
            NewFloatingPackageWithAllocationPrice value => newFloatingPackageWithAllocationPrice(
                value
            ),
            NewFloatingUnitWithPercentPrice value => newFloatingUnitWithPercentPrice(value),
            NewFloatingMatrixWithAllocationPrice value => newFloatingMatrixWithAllocationPrice(
                value
            ),
            NewFloatingTieredWithProrationPrice value => newFloatingTieredWithProrationPrice(value),
            NewFloatingUnitWithProrationPrice value => newFloatingUnitWithProrationPrice(value),
            NewFloatingGroupedAllocationPrice value => newFloatingGroupedAllocationPrice(value),
            NewFloatingBulkWithProrationPrice value => newFloatingBulkWithProrationPrice(value),
            NewFloatingGroupedWithProratedMinimumPrice value =>
                newFloatingGroupedWithProratedMinimumPrice(value),
            NewFloatingGroupedWithMeteredMinimumPrice value =>
                newFloatingGroupedWithMeteredMinimumPrice(value),
            global::Orb.Models.Prices.GroupedWithMinMaxThresholds value =>
                groupedWithMinMaxThresholds(value),
            NewFloatingMatrixWithDisplayNamePrice value => newFloatingMatrixWithDisplayNamePrice(
                value
            ),
            NewFloatingGroupedTieredPackagePrice value => newFloatingGroupedTieredPackagePrice(
                value
            ),
            NewFloatingMaxGroupTieredPackagePrice value => newFloatingMaxGroupTieredPackagePrice(
                value
            ),
            NewFloatingScalableMatrixWithUnitPricingPrice value =>
                newFloatingScalableMatrixWithUnitPricingPrice(value),
            NewFloatingScalableMatrixWithTieredPricingPrice value =>
                newFloatingScalableMatrixWithTieredPricingPrice(value),
            NewFloatingCumulativeGroupedBulkPrice value => newFloatingCumulativeGroupedBulkPrice(
                value
            ),
            global::Orb.Models.Prices.CumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewFloatingMinimumCompositePrice value => newFloatingMinimumCompositePrice(value),
            global::Orb.Models.Prices.Percent value => percent(value),
            global::Orb.Models.Prices.EventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public static implicit operator Body(NewFloatingUnitPrice value) => new(value);

    public static implicit operator Body(NewFloatingTieredPrice value) => new(value);

    public static implicit operator Body(NewFloatingBulkPrice value) => new(value);

    public static implicit operator Body(global::Orb.Models.Prices.BulkWithFilters value) =>
        new(value);

    public static implicit operator Body(NewFloatingPackagePrice value) => new(value);

    public static implicit operator Body(NewFloatingMatrixPrice value) => new(value);

    public static implicit operator Body(NewFloatingThresholdTotalAmountPrice value) => new(value);

    public static implicit operator Body(NewFloatingTieredPackagePrice value) => new(value);

    public static implicit operator Body(NewFloatingTieredWithMinimumPrice value) => new(value);

    public static implicit operator Body(NewFloatingGroupedTieredPrice value) => new(value);

    public static implicit operator Body(NewFloatingTieredPackageWithMinimumPrice value) =>
        new(value);

    public static implicit operator Body(NewFloatingPackageWithAllocationPrice value) => new(value);

    public static implicit operator Body(NewFloatingUnitWithPercentPrice value) => new(value);

    public static implicit operator Body(NewFloatingMatrixWithAllocationPrice value) => new(value);

    public static implicit operator Body(NewFloatingTieredWithProrationPrice value) => new(value);

    public static implicit operator Body(NewFloatingUnitWithProrationPrice value) => new(value);

    public static implicit operator Body(NewFloatingGroupedAllocationPrice value) => new(value);

    public static implicit operator Body(NewFloatingBulkWithProrationPrice value) => new(value);

    public static implicit operator Body(NewFloatingGroupedWithProratedMinimumPrice value) =>
        new(value);

    public static implicit operator Body(NewFloatingGroupedWithMeteredMinimumPrice value) =>
        new(value);

    public static implicit operator Body(
        global::Orb.Models.Prices.GroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator Body(NewFloatingMatrixWithDisplayNamePrice value) => new(value);

    public static implicit operator Body(NewFloatingGroupedTieredPackagePrice value) => new(value);

    public static implicit operator Body(NewFloatingMaxGroupTieredPackagePrice value) => new(value);

    public static implicit operator Body(NewFloatingScalableMatrixWithUnitPricingPrice value) =>
        new(value);

    public static implicit operator Body(NewFloatingScalableMatrixWithTieredPricingPrice value) =>
        new(value);

    public static implicit operator Body(NewFloatingCumulativeGroupedBulkPrice value) => new(value);

    public static implicit operator Body(
        global::Orb.Models.Prices.CumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator Body(NewFloatingMinimumCompositePrice value) => new(value);

    public static implicit operator Body(global::Orb.Models.Prices.Percent value) => new(value);

    public static implicit operator Body(global::Orb.Models.Prices.EventOutput value) => new(value);

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
            throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch(
            (newFloatingUnitPrice) => newFloatingUnitPrice.Validate(),
            (newFloatingTieredPrice) => newFloatingTieredPrice.Validate(),
            (newFloatingBulkPrice) => newFloatingBulkPrice.Validate(),
            (bulkWithFilters) => bulkWithFilters.Validate(),
            (newFloatingPackagePrice) => newFloatingPackagePrice.Validate(),
            (newFloatingMatrixPrice) => newFloatingMatrixPrice.Validate(),
            (newFloatingThresholdTotalAmountPrice) =>
                newFloatingThresholdTotalAmountPrice.Validate(),
            (newFloatingTieredPackagePrice) => newFloatingTieredPackagePrice.Validate(),
            (newFloatingTieredWithMinimumPrice) => newFloatingTieredWithMinimumPrice.Validate(),
            (newFloatingGroupedTieredPrice) => newFloatingGroupedTieredPrice.Validate(),
            (newFloatingTieredPackageWithMinimumPrice) =>
                newFloatingTieredPackageWithMinimumPrice.Validate(),
            (newFloatingPackageWithAllocationPrice) =>
                newFloatingPackageWithAllocationPrice.Validate(),
            (newFloatingUnitWithPercentPrice) => newFloatingUnitWithPercentPrice.Validate(),
            (newFloatingMatrixWithAllocationPrice) =>
                newFloatingMatrixWithAllocationPrice.Validate(),
            (newFloatingTieredWithProrationPrice) => newFloatingTieredWithProrationPrice.Validate(),
            (newFloatingUnitWithProrationPrice) => newFloatingUnitWithProrationPrice.Validate(),
            (newFloatingGroupedAllocationPrice) => newFloatingGroupedAllocationPrice.Validate(),
            (newFloatingBulkWithProrationPrice) => newFloatingBulkWithProrationPrice.Validate(),
            (newFloatingGroupedWithProratedMinimumPrice) =>
                newFloatingGroupedWithProratedMinimumPrice.Validate(),
            (newFloatingGroupedWithMeteredMinimumPrice) =>
                newFloatingGroupedWithMeteredMinimumPrice.Validate(),
            (groupedWithMinMaxThresholds) => groupedWithMinMaxThresholds.Validate(),
            (newFloatingMatrixWithDisplayNamePrice) =>
                newFloatingMatrixWithDisplayNamePrice.Validate(),
            (newFloatingGroupedTieredPackagePrice) =>
                newFloatingGroupedTieredPackagePrice.Validate(),
            (newFloatingMaxGroupTieredPackagePrice) =>
                newFloatingMaxGroupTieredPackagePrice.Validate(),
            (newFloatingScalableMatrixWithUnitPricingPrice) =>
                newFloatingScalableMatrixWithUnitPricingPrice.Validate(),
            (newFloatingScalableMatrixWithTieredPricingPrice) =>
                newFloatingScalableMatrixWithTieredPricingPrice.Validate(),
            (newFloatingCumulativeGroupedBulkPrice) =>
                newFloatingCumulativeGroupedBulkPrice.Validate(),
            (cumulativeGroupedAllocation) => cumulativeGroupedAllocation.Validate(),
            (newFloatingMinimumCompositePrice) => newFloatingMinimumCompositePrice.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(Body? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Prices.BulkWithFilters>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Prices.GroupedWithMinMaxThresholds>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Prices.CumulativeGroupedAllocation>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Prices.Percent>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Prices.EventOutput>(
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
                return new Body(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.BulkWithFilters,
        global::Orb.Models.Prices.BulkWithFiltersFromRaw
    >)
)]
public sealed record class BulkWithFilters : ModelBase
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required global::Orb.Models.Prices.BulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Prices.BulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { ModelBase.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Prices.Cadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, global::Orb.Models.Prices.Cadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Prices.ConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
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

    public BulkWithFilters()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    public BulkWithFilters(global::Orb.Models.Prices.BulkWithFilters bulkWithFilters)
        : base(bulkWithFilters) { }

    public BulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.BulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersFromRaw : IFromRaw<global::Orb.Models.Prices.BulkWithFilters>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.BulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.BulkWithFiltersConfig,
        global::Orb.Models.Prices.BulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class BulkWithFiltersConfig : ModelBase
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Prices.Filter> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Prices.Filter>>(
                this.RawData,
                "filters"
            );
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Prices.Tier> Tiers
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Prices.Tier>>(
                this.RawData,
                "tiers"
            );
        }
        init { ModelBase.Set(this._rawData, "tiers", value); }
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

    public BulkWithFiltersConfig() { }

    public BulkWithFiltersConfig(
        global::Orb.Models.Prices.BulkWithFiltersConfig bulkWithFiltersConfig
    )
        : base(bulkWithFiltersConfig) { }

    public BulkWithFiltersConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.BulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersConfigFromRaw : IFromRaw<global::Orb.Models.Prices.BulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.BulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.Filter,
        global::Orb.Models.Prices.FilterFromRaw
    >)
)]
public sealed record class Filter : ModelBase
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { ModelBase.Set(this._rawData, "property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { ModelBase.Set(this._rawData, "property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter() { }

    public Filter(global::Orb.Models.Prices.Filter filter)
        : base(filter) { }

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.FilterFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRaw<global::Orb.Models.Prices.Filter>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.Prices.Tier, global::Orb.Models.Prices.TierFromRaw>)
)]
public sealed record class Tier : ModelBase
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tier_lower_bound"); }
        init { ModelBase.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier() { }

    public Tier(global::Orb.Models.Prices.Tier tier)
        : base(tier) { }

    public Tier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.TierFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.Tier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class TierFromRaw : IFromRaw<global::Orb.Models.Prices.Tier>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.Tier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.Tier.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.CadenceConverter))]
public enum Cadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CadenceConverter : JsonConverter<global::Orb.Models.Prices.Cadence>
{
    public override global::Orb.Models.Prices.Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.Cadence.Annual,
            "semi_annual" => global::Orb.Models.Prices.Cadence.SemiAnnual,
            "monthly" => global::Orb.Models.Prices.Cadence.Monthly,
            "quarterly" => global::Orb.Models.Prices.Cadence.Quarterly,
            "one_time" => global::Orb.Models.Prices.Cadence.OneTime,
            "custom" => global::Orb.Models.Prices.Cadence.Custom,
            _ => (global::Orb.Models.Prices.Cadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.Cadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.Cadence.Annual => "annual",
                global::Orb.Models.Prices.Cadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Prices.Cadence.Monthly => "monthly",
                global::Orb.Models.Prices.Cadence.Quarterly => "quarterly",
                global::Orb.Models.Prices.Cadence.OneTime => "one_time",
                global::Orb.Models.Prices.Cadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Prices.ConversionRateConfigConverter))]
public record class ConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ConversionRateConfig(SharedUnitConversionRateConfig value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ConversionRateConfig(SharedTieredConversionRateConfig value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ConversionRateConfig(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of ConversionRateConfig"
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
                "Data did not match any variant of ConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Prices.ConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Prices.ConversionRateConfig(
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
                "Data did not match any variant of ConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(global::Orb.Models.Prices.ConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Prices.ConversionRateConfig>
{
    public override global::Orb.Models.Prices.ConversionRateConfig? Read(
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
                return new global::Orb.Models.Prices.ConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.ConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.GroupedWithMinMaxThresholds,
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class GroupedWithMinMaxThresholds : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig>(
                this.RawData,
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { ModelBase.Set(this._rawData, "grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
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

    public GroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

    public GroupedWithMinMaxThresholds(
        global::Orb.Models.Prices.GroupedWithMinMaxThresholds groupedWithMinMaxThresholds
    )
        : base(groupedWithMinMaxThresholds) { }

    public GroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.GroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsFromRaw
    : IFromRaw<global::Orb.Models.Prices.GroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.GroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadenceConverter))]
public enum GroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class GroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence>
{
    public override global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => global::Orb
                .Models
                .Prices
                .GroupedWithMinMaxThresholdsCadence
                .SemiAnnual,
            "monthly" => global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Custom,
            _ => (global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Annual => "annual",
                global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.SemiAnnual =>
                    "semi_annual",
                global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Quarterly =>
                    "quarterly",
                global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                global::Orb.Models.Prices.GroupedWithMinMaxThresholdsCadence.Custom => "custom",
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
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig,
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class GroupedWithMinMaxThresholdsConfig : ModelBase
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "maximum_charge"); }
        init { ModelBase.Set(this._rawData, "maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "minimum_charge"); }
        init { ModelBase.Set(this._rawData, "minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "per_unit_rate"); }
        init { ModelBase.Set(this._rawData, "per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public GroupedWithMinMaxThresholdsConfig() { }

    public GroupedWithMinMaxThresholdsConfig(
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig groupedWithMinMaxThresholdsConfig
    )
        : base(groupedWithMinMaxThresholdsConfig) { }

    public GroupedWithMinMaxThresholdsConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRaw<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class GroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
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
                "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig(
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
                "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class GroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig? Read(
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
                return new global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.CumulativeGroupedAllocation,
        global::Orb.Models.Prices.CumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class CumulativeGroupedAllocation : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Prices.CumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Prices.CumulativeGroupedAllocationCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required global::Orb.Models.Prices.CumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Prices.CumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { ModelBase.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
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

    public CumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

    public CumulativeGroupedAllocation(
        global::Orb.Models.Prices.CumulativeGroupedAllocation cumulativeGroupedAllocation
    )
        : base(cumulativeGroupedAllocation) { }

    public CumulativeGroupedAllocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.CumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationFromRaw
    : IFromRaw<global::Orb.Models.Prices.CumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.CumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.CumulativeGroupedAllocationCadenceConverter))]
public enum CumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CumulativeGroupedAllocationCadenceConverter
    : JsonConverter<global::Orb.Models.Prices.CumulativeGroupedAllocationCadence>
{
    public override global::Orb.Models.Prices.CumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => global::Orb
                .Models
                .Prices
                .CumulativeGroupedAllocationCadence
                .SemiAnnual,
            "monthly" => global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.OneTime,
            "custom" => global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Custom,
            _ => (global::Orb.Models.Prices.CumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.CumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Annual => "annual",
                global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.SemiAnnual =>
                    "semi_annual",
                global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Monthly => "monthly",
                global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Quarterly =>
                    "quarterly",
                global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.OneTime => "one_time",
                global::Orb.Models.Prices.CumulativeGroupedAllocationCadence.Custom => "custom",
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
        global::Orb.Models.Prices.CumulativeGroupedAllocationConfig,
        global::Orb.Models.Prices.CumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class CumulativeGroupedAllocationConfig : ModelBase
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "cumulative_allocation"); }
        init { ModelBase.Set(this._rawData, "cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "group_allocation"); }
        init { ModelBase.Set(this._rawData, "group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public CumulativeGroupedAllocationConfig() { }

    public CumulativeGroupedAllocationConfig(
        global::Orb.Models.Prices.CumulativeGroupedAllocationConfig cumulativeGroupedAllocationConfig
    )
        : base(cumulativeGroupedAllocationConfig) { }

    public CumulativeGroupedAllocationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.CumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationConfigFromRaw
    : IFromRaw<global::Orb.Models.Prices.CumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.CumulativeGroupedAllocationConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class CumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public CumulativeGroupedAllocationConversionRateConfig(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
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
                "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig(
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
                "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class CumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig>
{
    public override global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig? Read(
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
                return new global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.CumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.Percent,
        global::Orb.Models.Prices.PercentFromRaw
    >)
)]
public sealed record class Percent : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Prices.PercentCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Prices.PercentCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required global::Orb.Models.Prices.PercentConfig PercentConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Prices.PercentConfig>(
                this.RawData,
                "percent_config"
            );
        }
        init { ModelBase.Set(this._rawData, "percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.PercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Prices.PercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
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

    public Percent()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    public Percent(global::Orb.Models.Prices.Percent percent)
        : base(percent) { }

    public Percent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.PercentFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentFromRaw : IFromRaw<global::Orb.Models.Prices.Percent>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.Percent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.PercentCadenceConverter))]
public enum PercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PercentCadenceConverter : JsonConverter<global::Orb.Models.Prices.PercentCadence>
{
    public override global::Orb.Models.Prices.PercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.PercentCadence.Annual,
            "semi_annual" => global::Orb.Models.Prices.PercentCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Prices.PercentCadence.Monthly,
            "quarterly" => global::Orb.Models.Prices.PercentCadence.Quarterly,
            "one_time" => global::Orb.Models.Prices.PercentCadence.OneTime,
            "custom" => global::Orb.Models.Prices.PercentCadence.Custom,
            _ => (global::Orb.Models.Prices.PercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.PercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.PercentCadence.Annual => "annual",
                global::Orb.Models.Prices.PercentCadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Prices.PercentCadence.Monthly => "monthly",
                global::Orb.Models.Prices.PercentCadence.Quarterly => "quarterly",
                global::Orb.Models.Prices.PercentCadence.OneTime => "one_time",
                global::Orb.Models.Prices.PercentCadence.Custom => "custom",
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
    typeof(ModelConverter<
        global::Orb.Models.Prices.PercentConfig,
        global::Orb.Models.Prices.PercentConfigFromRaw
    >)
)]
public sealed record class PercentConfig : ModelBase
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percent"); }
        init { ModelBase.Set(this._rawData, "percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
    }

    public PercentConfig() { }

    public PercentConfig(global::Orb.Models.Prices.PercentConfig percentConfig)
        : base(percentConfig) { }

    public PercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.PercentConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.PercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class PercentConfigFromRaw : IFromRaw<global::Orb.Models.Prices.PercentConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.PercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.PercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Prices.PercentConversionRateConfigConverter))]
public record class PercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PercentConversionRateConfig(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of PercentConversionRateConfig"
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
                "Data did not match any variant of PercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Prices.PercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Prices.PercentConversionRateConfig(
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
                "Data did not match any variant of PercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(global::Orb.Models.Prices.PercentConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PercentConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Prices.PercentConversionRateConfig>
{
    public override global::Orb.Models.Prices.PercentConversionRateConfig? Read(
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
                return new global::Orb.Models.Prices.PercentConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.PercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Prices.EventOutput,
        global::Orb.Models.Prices.EventOutputFromRaw
    >)
)]
public sealed record class EventOutput : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Prices.EventOutputCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Prices.EventOutputCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required global::Orb.Models.Prices.EventOutputConfig EventOutputConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Prices.EventOutputConfig>(
                this.RawData,
                "event_output_config"
            );
        }
        init { ModelBase.Set(this._rawData, "event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.EventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Prices.EventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
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

    public EventOutput()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    public EventOutput(global::Orb.Models.Prices.EventOutput eventOutput)
        : base(eventOutput) { }

    public EventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.EventOutputFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventOutputFromRaw : IFromRaw<global::Orb.Models.Prices.EventOutput>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.EventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.EventOutputCadenceConverter))]
public enum EventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class EventOutputCadenceConverter
    : JsonConverter<global::Orb.Models.Prices.EventOutputCadence>
{
    public override global::Orb.Models.Prices.EventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.EventOutputCadence.Annual,
            "semi_annual" => global::Orb.Models.Prices.EventOutputCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Prices.EventOutputCadence.Monthly,
            "quarterly" => global::Orb.Models.Prices.EventOutputCadence.Quarterly,
            "one_time" => global::Orb.Models.Prices.EventOutputCadence.OneTime,
            "custom" => global::Orb.Models.Prices.EventOutputCadence.Custom,
            _ => (global::Orb.Models.Prices.EventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.EventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.EventOutputCadence.Annual => "annual",
                global::Orb.Models.Prices.EventOutputCadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Prices.EventOutputCadence.Monthly => "monthly",
                global::Orb.Models.Prices.EventOutputCadence.Quarterly => "quarterly",
                global::Orb.Models.Prices.EventOutputCadence.OneTime => "one_time",
                global::Orb.Models.Prices.EventOutputCadence.Custom => "custom",
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
        global::Orb.Models.Prices.EventOutputConfig,
        global::Orb.Models.Prices.EventOutputConfigFromRaw
    >)
)]
public sealed record class EventOutputConfig : ModelBase
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_rating_key"); }
        init { ModelBase.Set(this._rawData, "unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "default_unit_rate"); }
        init { ModelBase.Set(this._rawData, "default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public EventOutputConfig() { }

    public EventOutputConfig(global::Orb.Models.Prices.EventOutputConfig eventOutputConfig)
        : base(eventOutputConfig) { }

    public EventOutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Prices.EventOutputConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Prices.EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class EventOutputConfigFromRaw : IFromRaw<global::Orb.Models.Prices.EventOutputConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Prices.EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Prices.EventOutputConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Prices.EventOutputConversionRateConfigConverter))]
public record class EventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public EventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public EventOutputConversionRateConfig(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of EventOutputConversionRateConfig"
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
                "Data did not match any variant of EventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Prices.EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Prices.EventOutputConversionRateConfig(
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
                "Data did not match any variant of EventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(global::Orb.Models.Prices.EventOutputConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class EventOutputConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Prices.EventOutputConversionRateConfig>
{
    public override global::Orb.Models.Prices.EventOutputConversionRateConfig? Read(
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
                return new global::Orb.Models.Prices.EventOutputConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.EventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
