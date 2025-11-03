using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Prices.PriceCreateParamsProperties.BodyProperties;

namespace Orb.Models.Prices.PriceCreateParamsProperties;

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

    public Body(BulkWithFilters value)
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

    public Body(GroupedWithMinMaxThresholds value)
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

    public Body(Percent value)
    {
        Value = value;
    }

    public Body(EventOutput value)
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

    public bool TryPickBulkWithFilters([NotNullWhen(true)] out BulkWithFilters? value)
    {
        value = this.Value as BulkWithFilters;
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
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as GroupedWithMinMaxThresholds;
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

    public bool TryPickPercent([NotNullWhen(true)] out Percent? value)
    {
        value = this.Value as Percent;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutput? value)
    {
        value = this.Value as EventOutput;
        return value != null;
    }

    public void Switch(
        Action<NewFloatingUnitPrice> newFloatingUnitPrice,
        Action<NewFloatingTieredPrice> newFloatingTieredPrice,
        Action<NewFloatingBulkPrice> newFloatingBulkPrice,
        Action<BulkWithFilters> bulkWithFilters,
        Action<NewFloatingPackagePrice> newFloatingPackagePrice,
        Action<NewFloatingMatrixPrice> newFloatingMatrixPrice,
        Action<NewFloatingThresholdTotalAmountPrice> newFloatingThresholdTotalAmountPrice,
        Action<NewFloatingTieredPackagePrice> newFloatingTieredPackagePrice,
        Action<NewFloatingTieredWithMinimumPrice> newFloatingTieredWithMinimumPrice,
        Action<NewFloatingGroupedTieredPrice> newFloatingGroupedTieredPrice,
        Action<NewFloatingTieredPackageWithMinimumPrice> newFloatingTieredPackageWithMinimumPrice,
        Action<NewFloatingPackageWithAllocationPrice> newFloatingPackageWithAllocationPrice,
        Action<NewFloatingUnitWithPercentPrice> newFloatingUnitWithPercentPrice,
        Action<NewFloatingMatrixWithAllocationPrice> newFloatingMatrixWithAllocationPrice,
        Action<NewFloatingTieredWithProrationPrice> newFloatingTieredWithProrationPrice,
        Action<NewFloatingUnitWithProrationPrice> newFloatingUnitWithProrationPrice,
        Action<NewFloatingGroupedAllocationPrice> newFloatingGroupedAllocationPrice,
        Action<NewFloatingBulkWithProrationPrice> newFloatingBulkWithProrationPrice,
        Action<NewFloatingGroupedWithProratedMinimumPrice> newFloatingGroupedWithProratedMinimumPrice,
        Action<NewFloatingGroupedWithMeteredMinimumPrice> newFloatingGroupedWithMeteredMinimumPrice,
        Action<GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayNamePrice,
        Action<NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackagePrice,
        Action<NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackagePrice,
        Action<NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricingPrice,
        Action<NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricingPrice,
        Action<NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulkPrice,
        Action<NewFloatingMinimumCompositePrice> newFloatingMinimumCompositePrice,
        Action<Percent> percent,
        Action<EventOutput> eventOutput
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
            case BulkWithFilters value:
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
            case GroupedWithMinMaxThresholds value:
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
            case Percent value:
                percent(value);
                break;
            case EventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
    }

    public T Match<T>(
        Func<NewFloatingUnitPrice, T> newFloatingUnitPrice,
        Func<NewFloatingTieredPrice, T> newFloatingTieredPrice,
        Func<NewFloatingBulkPrice, T> newFloatingBulkPrice,
        Func<BulkWithFilters, T> bulkWithFilters,
        Func<NewFloatingPackagePrice, T> newFloatingPackagePrice,
        Func<NewFloatingMatrixPrice, T> newFloatingMatrixPrice,
        Func<NewFloatingThresholdTotalAmountPrice, T> newFloatingThresholdTotalAmountPrice,
        Func<NewFloatingTieredPackagePrice, T> newFloatingTieredPackagePrice,
        Func<NewFloatingTieredWithMinimumPrice, T> newFloatingTieredWithMinimumPrice,
        Func<NewFloatingGroupedTieredPrice, T> newFloatingGroupedTieredPrice,
        Func<NewFloatingTieredPackageWithMinimumPrice, T> newFloatingTieredPackageWithMinimumPrice,
        Func<NewFloatingPackageWithAllocationPrice, T> newFloatingPackageWithAllocationPrice,
        Func<NewFloatingUnitWithPercentPrice, T> newFloatingUnitWithPercentPrice,
        Func<NewFloatingMatrixWithAllocationPrice, T> newFloatingMatrixWithAllocationPrice,
        Func<NewFloatingTieredWithProrationPrice, T> newFloatingTieredWithProrationPrice,
        Func<NewFloatingUnitWithProrationPrice, T> newFloatingUnitWithProrationPrice,
        Func<NewFloatingGroupedAllocationPrice, T> newFloatingGroupedAllocationPrice,
        Func<NewFloatingBulkWithProrationPrice, T> newFloatingBulkWithProrationPrice,
        Func<
            NewFloatingGroupedWithProratedMinimumPrice,
            T
        > newFloatingGroupedWithProratedMinimumPrice,
        Func<
            NewFloatingGroupedWithMeteredMinimumPrice,
            T
        > newFloatingGroupedWithMeteredMinimumPrice,
        Func<GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<NewFloatingMatrixWithDisplayNamePrice, T> newFloatingMatrixWithDisplayNamePrice,
        Func<NewFloatingGroupedTieredPackagePrice, T> newFloatingGroupedTieredPackagePrice,
        Func<NewFloatingMaxGroupTieredPackagePrice, T> newFloatingMaxGroupTieredPackagePrice,
        Func<
            NewFloatingScalableMatrixWithUnitPricingPrice,
            T
        > newFloatingScalableMatrixWithUnitPricingPrice,
        Func<
            NewFloatingScalableMatrixWithTieredPricingPrice,
            T
        > newFloatingScalableMatrixWithTieredPricingPrice,
        Func<NewFloatingCumulativeGroupedBulkPrice, T> newFloatingCumulativeGroupedBulkPrice,
        Func<NewFloatingMinimumCompositePrice, T> newFloatingMinimumCompositePrice,
        Func<Percent, T> percent,
        Func<EventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewFloatingUnitPrice value => newFloatingUnitPrice(value),
            NewFloatingTieredPrice value => newFloatingTieredPrice(value),
            NewFloatingBulkPrice value => newFloatingBulkPrice(value),
            BulkWithFilters value => bulkWithFilters(value),
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
            GroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(value),
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
            Percent value => percent(value),
            EventOutput value => eventOutput(value),
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
        Type typeToConvert,
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingBulkPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "bulk_with_filters":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BulkWithFilters>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BulkWithFilters'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingPackagePrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingThresholdTotalAmountPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedTieredPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPackageWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingPackageWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitWithPercentPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedAllocationPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingBulkWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedWithProratedMinimumPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedWithMeteredMinimumPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'GroupedWithMinMaxThresholds'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixWithDisplayNamePrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMaxGroupTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingScalableMatrixWithUnitPricingPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingScalableMatrixWithTieredPricingPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingCumulativeGroupedBulkPrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMinimumCompositePrice'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Percent>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Percent'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "event_output":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<EventOutput>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'EventOutput'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
