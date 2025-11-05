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
/// An `external_price_id` can be optionally specified as an alias to allow ergonomic
/// interaction with prices in the Orb API.
///
/// See the [Price resource](/product-catalog/price-configuration) for the specification
/// of different price model configurations possible in this endpoint.
/// </summary>
public sealed record class PriceCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// New floating price request body params.
    /// </summary>
    public required Body Body
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("body", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentNullException("body")
                );
        }
        init
        {
            this._bodyProperties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public PriceCreateParams() { }

    public PriceCreateParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceCreateParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static PriceCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/prices")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public record class Body
{
    public object Value { get; private init; }

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
                newFloatingMinimumCompositePrice: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public Body(NewFloatingUnitPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingTieredPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingBulkPrice value)
    {
        Value = value;
    }

    public Body(global::Orb.Models.Prices.BulkWithFilters value)
    {
        Value = value;
    }

    public Body(NewFloatingPackagePrice value)
    {
        Value = value;
    }

    public Body(NewFloatingMatrixPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingThresholdTotalAmountPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingTieredPackagePrice value)
    {
        Value = value;
    }

    public Body(NewFloatingTieredWithMinimumPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingGroupedTieredPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingTieredPackageWithMinimumPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingPackageWithAllocationPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingUnitWithPercentPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingMatrixWithAllocationPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingTieredWithProrationPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingUnitWithProrationPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingGroupedAllocationPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingBulkWithProrationPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingGroupedWithProratedMinimumPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingGroupedWithMeteredMinimumPrice value)
    {
        Value = value;
    }

    public Body(global::Orb.Models.Prices.GroupedWithMinMaxThresholds value)
    {
        Value = value;
    }

    public Body(NewFloatingMatrixWithDisplayNamePrice value)
    {
        Value = value;
    }

    public Body(NewFloatingGroupedTieredPackagePrice value)
    {
        Value = value;
    }

    public Body(NewFloatingMaxGroupTieredPackagePrice value)
    {
        Value = value;
    }

    public Body(NewFloatingScalableMatrixWithUnitPricingPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingScalableMatrixWithTieredPricingPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingCumulativeGroupedBulkPrice value)
    {
        Value = value;
    }

    public Body(NewFloatingMinimumCompositePrice value)
    {
        Value = value;
    }

    public Body(global::Orb.Models.Prices.Percent value)
    {
        Value = value;
    }

    public Body(global::Orb.Models.Prices.EventOutput value)
    {
        Value = value;
    }

    Body(UnknownVariant value)
    {
        Value = value;
    }

    public static Body CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickNewFloatingUnitPrice([NotNullWhen(true)] out NewFloatingUnitPrice? value)
    {
        value = this.Value as NewFloatingUnitPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPrice([NotNullWhen(true)] out NewFloatingTieredPrice? value)
    {
        value = this.Value as NewFloatingTieredPrice;
        return value != null;
    }

    public bool TryPickNewFloatingBulkPrice([NotNullWhen(true)] out NewFloatingBulkPrice? value)
    {
        value = this.Value as NewFloatingBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out global::Orb.Models.Prices.BulkWithFilters? value
    )
    {
        value = this.Value as global::Orb.Models.Prices.BulkWithFilters;
        return value != null;
    }

    public bool TryPickNewFloatingPackagePrice(
        [NotNullWhen(true)] out NewFloatingPackagePrice? value
    )
    {
        value = this.Value as NewFloatingPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixPrice([NotNullWhen(true)] out NewFloatingMatrixPrice? value)
    {
        value = this.Value as NewFloatingMatrixPrice;
        return value != null;
    }

    public bool TryPickNewFloatingThresholdTotalAmountPrice(
        [NotNullWhen(true)] out NewFloatingThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewFloatingThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackagePrice(
        [NotNullWhen(true)] out NewFloatingTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithMinimumPrice(
        [NotNullWhen(true)] out NewFloatingTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTieredPrice(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackageWithMinimumPrice(
        [NotNullWhen(true)] out NewFloatingTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingPackageWithAllocationPrice(
        [NotNullWhen(true)] out NewFloatingPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithPercentPrice(
        [NotNullWhen(true)] out NewFloatingUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithAllocationPrice(
        [NotNullWhen(true)] out NewFloatingMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithProrationPrice(
        [NotNullWhen(true)] out NewFloatingTieredWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithProrationPrice(
        [NotNullWhen(true)] out NewFloatingUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedAllocationPrice(
        [NotNullWhen(true)] out NewFloatingGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingBulkWithProrationPrice(
        [NotNullWhen(true)] out NewFloatingBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithProratedMinimumPrice(
        [NotNullWhen(true)] out NewFloatingGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithMeteredMinimumPrice(
        [NotNullWhen(true)] out NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out global::Orb.Models.Prices.GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as global::Orb.Models.Prices.GroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithDisplayNamePrice(
        [NotNullWhen(true)] out NewFloatingMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTieredPackagePrice(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingMaxGroupTieredPackagePrice(
        [NotNullWhen(true)] out NewFloatingMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithUnitPricingPrice(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithTieredPricingPrice(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewFloatingCumulativeGroupedBulkPrice(
        [NotNullWhen(true)] out NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewFloatingCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickNewFloatingMinimumCompositePrice(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = this.Value as NewFloatingMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out global::Orb.Models.Prices.Percent? value)
    {
        value = this.Value as global::Orb.Models.Prices.Percent;
        return value != null;
    }

    public bool TryPickEventOutput(
        [NotNullWhen(true)] out global::Orb.Models.Prices.EventOutput? value
    )
    {
        value = this.Value as global::Orb.Models.Prices.EventOutput;
        return value != null;
    }

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
            NewFloatingMinimumCompositePrice value => newFloatingMinimumCompositePrice(value),
            global::Orb.Models.Prices.Percent value => percent(value),
            global::Orb.Models.Prices.EventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_filters":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Prices.BulkWithFilters'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "threshold_total_amount":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingThresholdTotalAmountPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPackageWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingPackageWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitWithPercentPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingBulkWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_prorated_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedWithProratedMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_metered_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedWithMeteredMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Prices.GroupedWithMinMaxThresholds'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_display_name":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixWithDisplayNamePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "max_group_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMaxGroupTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingScalableMatrixWithUnitPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingScalableMatrixWithTieredPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "cumulative_grouped_bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingCumulativeGroupedBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMinimumCompositePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percent":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Prices.Percent'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "event_output":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new Body(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Prices.EventOutput'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.BulkWithFilters>))]
public sealed record class BulkWithFilters
    : ModelBase,
        IFromRaw<global::Orb.Models.Prices.BulkWithFilters>
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required global::Orb.Models.Prices.BulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            if (!this._properties.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.BulkWithFiltersConfig>(
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
            this._properties["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Prices.Cadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Prices.Cadence>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
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
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Prices.ModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ModelType>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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

    public BulkWithFilters()
    {
        this.ModelType = new();
    }

    public BulkWithFilters(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.BulkWithFiltersConfig>))]
public sealed record class BulkWithFiltersConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Prices.BulkWithFiltersConfig>
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required List<global::Orb.Models.Prices.Filter> Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Prices.Filter>>(
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
            this._properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<global::Orb.Models.Prices.Tier> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Prices.Tier>>(
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
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
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

    public BulkWithFiltersConfig() { }

    public BulkWithFiltersConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.Filter>))]
public sealed record class Filter : ModelBase, IFromRaw<global::Orb.Models.Prices.Filter>
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._properties.TryGetValue("property_key", out JsonElement element))
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
            this._properties["property_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("property_value", out JsonElement element))
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
            this._properties["property_value"] = JsonSerializer.SerializeToElement(
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

    public Filter() { }

    public Filter(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.Tier>))]
public sealed record class Tier : ModelBase, IFromRaw<global::Orb.Models.Prices.Tier>
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
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
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
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

    public Tier() { }

    public Tier(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.Tier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Tier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
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

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType
{
    public JsonElement Json { get; private init; }

    public ModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Prices.ModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Prices.ModelType'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Prices.ModelType>
    {
        public override global::Orb.Models.Prices.ModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Prices.ModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Prices.ConversionRateConfigConverter))]
public record class ConversionRateConfig
{
    public object Value { get; private init; }

    public ConversionRateConfig(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Prices.ConversionRateConfig CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfig(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfig(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.ConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.GroupedWithMinMaxThresholds>))]
public sealed record class GroupedWithMinMaxThresholds
    : ModelBase,
        IFromRaw<global::Orb.Models.Prices.GroupedWithMinMaxThresholds>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Prices.CadenceModel> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Prices.CadenceModel>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
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
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
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

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig>(
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
            this._properties["grouped_with_min_max_thresholds_config"] =
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Prices.ModelTypeModel ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ModelTypeModel>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.ConversionRateConfigModel? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ConversionRateConfigModel?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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

    public GroupedWithMinMaxThresholds()
    {
        this.ModelType = new();
    }

    public GroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.CadenceModelConverter))]
public enum CadenceModel
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CadenceModelConverter : JsonConverter<global::Orb.Models.Prices.CadenceModel>
{
    public override global::Orb.Models.Prices.CadenceModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.CadenceModel.Annual,
            "semi_annual" => global::Orb.Models.Prices.CadenceModel.SemiAnnual,
            "monthly" => global::Orb.Models.Prices.CadenceModel.Monthly,
            "quarterly" => global::Orb.Models.Prices.CadenceModel.Quarterly,
            "one_time" => global::Orb.Models.Prices.CadenceModel.OneTime,
            "custom" => global::Orb.Models.Prices.CadenceModel.Custom,
            _ => (global::Orb.Models.Prices.CadenceModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.CadenceModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.CadenceModel.Annual => "annual",
                global::Orb.Models.Prices.CadenceModel.SemiAnnual => "semi_annual",
                global::Orb.Models.Prices.CadenceModel.Monthly => "monthly",
                global::Orb.Models.Prices.CadenceModel.Quarterly => "quarterly",
                global::Orb.Models.Prices.CadenceModel.OneTime => "one_time",
                global::Orb.Models.Prices.CadenceModel.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig>))]
public sealed record class GroupedWithMinMaxThresholdsConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig>
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
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
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("maximum_charge", out JsonElement element))
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
            this._properties["maximum_charge"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("minimum_charge", out JsonElement element))
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
            this._properties["minimum_charge"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("per_unit_rate", out JsonElement element))
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
            this._properties["per_unit_rate"] = JsonSerializer.SerializeToElement(
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

    public GroupedWithMinMaxThresholdsConfig() { }

    public GroupedWithMinMaxThresholdsConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelTypeModel
{
    public JsonElement Json { get; private init; }

    public ModelTypeModel()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ModelTypeModel(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Prices.ModelTypeModel().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Prices.ModelTypeModel'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Prices.ModelTypeModel>
    {
        public override global::Orb.Models.Prices.ModelTypeModel? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Prices.ModelTypeModel value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Prices.ConversionRateConfigModelConverter))]
public record class ConversionRateConfigModel
{
    public object Value { get; private init; }

    public ConversionRateConfigModel(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfigModel(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfigModel(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Prices.ConversionRateConfigModel CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfigModel"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfigModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfigModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfigModelConverter
    : JsonConverter<global::Orb.Models.Prices.ConversionRateConfigModel>
{
    public override global::Orb.Models.Prices.ConversionRateConfigModel? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfigModel(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfigModel(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.ConversionRateConfigModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.Percent>))]
public sealed record class Percent : ModelBase, IFromRaw<global::Orb.Models.Prices.Percent>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Prices.Cadence1> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Prices.Cadence1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
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
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Prices.ModelType1 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ModelType1>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required global::Orb.Models.Prices.PercentConfig PercentConfig
    {
        get
        {
            if (!this._properties.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.PercentConfig>(
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
            this._properties["percent_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.ConversionRateConfig1? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ConversionRateConfig1?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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

    public Percent()
    {
        this.ModelType = new();
    }

    public Percent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.Cadence1Converter))]
public enum Cadence1
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence1Converter : JsonConverter<global::Orb.Models.Prices.Cadence1>
{
    public override global::Orb.Models.Prices.Cadence1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.Cadence1.Annual,
            "semi_annual" => global::Orb.Models.Prices.Cadence1.SemiAnnual,
            "monthly" => global::Orb.Models.Prices.Cadence1.Monthly,
            "quarterly" => global::Orb.Models.Prices.Cadence1.Quarterly,
            "one_time" => global::Orb.Models.Prices.Cadence1.OneTime,
            "custom" => global::Orb.Models.Prices.Cadence1.Custom,
            _ => (global::Orb.Models.Prices.Cadence1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.Cadence1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.Cadence1.Annual => "annual",
                global::Orb.Models.Prices.Cadence1.SemiAnnual => "semi_annual",
                global::Orb.Models.Prices.Cadence1.Monthly => "monthly",
                global::Orb.Models.Prices.Cadence1.Quarterly => "quarterly",
                global::Orb.Models.Prices.Cadence1.OneTime => "one_time",
                global::Orb.Models.Prices.Cadence1.Custom => "custom",
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
public class ModelType1
{
    public JsonElement Json { get; private init; }

    public ModelType1()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ModelType1(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Prices.ModelType1().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Prices.ModelType1'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Prices.ModelType1>
    {
        public override global::Orb.Models.Prices.ModelType1? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Prices.ModelType1 value,
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.PercentConfig>))]
public sealed record class PercentConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Prices.PercentConfig>
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._properties.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public PercentConfig() { }

    public PercentConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.PercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

[JsonConverter(typeof(global::Orb.Models.Prices.ConversionRateConfig1Converter))]
public record class ConversionRateConfig1
{
    public object Value { get; private init; }

    public ConversionRateConfig1(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig1(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig1(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Prices.ConversionRateConfig1 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig1"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig1"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig1"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig1Converter
    : JsonConverter<global::Orb.Models.Prices.ConversionRateConfig1>
{
    public override global::Orb.Models.Prices.ConversionRateConfig1? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfig1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfig1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.ConversionRateConfig1 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.EventOutput>))]
public sealed record class EventOutput : ModelBase, IFromRaw<global::Orb.Models.Prices.EventOutput>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Prices.Cadence2> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Prices.Cadence2>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
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
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required global::Orb.Models.Prices.EventOutputConfig EventOutputConfig
    {
        get
        {
            if (!this._properties.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.EventOutputConfig>(
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
            this._properties["event_output_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Prices.ModelType2 ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ModelType2>(
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
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Prices.ConversionRateConfig2? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Prices.ConversionRateConfig2?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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

    public EventOutput()
    {
        this.ModelType = new();
    }

    public EventOutput(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Prices.Cadence2Converter))]
public enum Cadence2
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence2Converter : JsonConverter<global::Orb.Models.Prices.Cadence2>
{
    public override global::Orb.Models.Prices.Cadence2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Prices.Cadence2.Annual,
            "semi_annual" => global::Orb.Models.Prices.Cadence2.SemiAnnual,
            "monthly" => global::Orb.Models.Prices.Cadence2.Monthly,
            "quarterly" => global::Orb.Models.Prices.Cadence2.Quarterly,
            "one_time" => global::Orb.Models.Prices.Cadence2.OneTime,
            "custom" => global::Orb.Models.Prices.Cadence2.Custom,
            _ => (global::Orb.Models.Prices.Cadence2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.Cadence2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Prices.Cadence2.Annual => "annual",
                global::Orb.Models.Prices.Cadence2.SemiAnnual => "semi_annual",
                global::Orb.Models.Prices.Cadence2.Monthly => "monthly",
                global::Orb.Models.Prices.Cadence2.Quarterly => "quarterly",
                global::Orb.Models.Prices.Cadence2.OneTime => "one_time",
                global::Orb.Models.Prices.Cadence2.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Prices.EventOutputConfig>))]
public sealed record class EventOutputConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Prices.EventOutputConfig>
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._properties.TryGetValue("unit_rating_key", out JsonElement element))
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
            this._properties["unit_rating_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["default_unit_rate"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
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

    public EventOutputConfig() { }

    public EventOutputConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Prices.EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType2
{
    public JsonElement Json { get; private init; }

    public ModelType2()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ModelType2(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Prices.ModelType2().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Prices.ModelType2'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Prices.ModelType2>
    {
        public override global::Orb.Models.Prices.ModelType2? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Prices.ModelType2 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Prices.ConversionRateConfig2Converter))]
public record class ConversionRateConfig2
{
    public object Value { get; private init; }

    public ConversionRateConfig2(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig2(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig2(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Prices.ConversionRateConfig2 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig2"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig2"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig2"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig2Converter
    : JsonConverter<global::Orb.Models.Prices.ConversionRateConfig2>
{
    public override global::Orb.Models.Prices.ConversionRateConfig2? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfig2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Prices.ConversionRateConfig2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Prices.ConversionRateConfig2 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
