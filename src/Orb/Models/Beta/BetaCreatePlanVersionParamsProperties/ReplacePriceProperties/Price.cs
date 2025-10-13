using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties;

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public record class Price
{
    public object Value { get; private init; }

    public string ItemID
    {
        get
        {
            return Match(
                newPlanUnit: (x) => x.ItemID,
                newPlanTiered: (x) => x.ItemID,
                newPlanBulk: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newPlanPackage: (x) => x.ItemID,
                newPlanMatrix: (x) => x.ItemID,
                newPlanThresholdTotalAmount: (x) => x.ItemID,
                newPlanTieredPackage: (x) => x.ItemID,
                newPlanTieredWithMinimum: (x) => x.ItemID,
                newPlanGroupedTiered: (x) => x.ItemID,
                newPlanTieredPackageWithMinimum: (x) => x.ItemID,
                newPlanPackageWithAllocation: (x) => x.ItemID,
                newPlanUnitWithPercent: (x) => x.ItemID,
                newPlanMatrixWithAllocation: (x) => x.ItemID,
                tieredWithProration: (x) => x.ItemID,
                newPlanUnitWithProration: (x) => x.ItemID,
                newPlanGroupedAllocation: (x) => x.ItemID,
                newPlanBulkWithProration: (x) => x.ItemID,
                newPlanGroupedWithProratedMinimum: (x) => x.ItemID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newPlanMatrixWithDisplayName: (x) => x.ItemID,
                newPlanGroupedTieredPackage: (x) => x.ItemID,
                newPlanMaxGroupTieredPackage: (x) => x.ItemID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ItemID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ItemID,
                newPlanCumulativeGroupedBulk: (x) => x.ItemID,
                newPlanMinimumComposite: (x) => x.ItemID,
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
                newPlanUnit: (x) => x.Name,
                newPlanTiered: (x) => x.Name,
                newPlanBulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newPlanPackage: (x) => x.Name,
                newPlanMatrix: (x) => x.Name,
                newPlanThresholdTotalAmount: (x) => x.Name,
                newPlanTieredPackage: (x) => x.Name,
                newPlanTieredWithMinimum: (x) => x.Name,
                newPlanGroupedTiered: (x) => x.Name,
                newPlanTieredPackageWithMinimum: (x) => x.Name,
                newPlanPackageWithAllocation: (x) => x.Name,
                newPlanUnitWithPercent: (x) => x.Name,
                newPlanMatrixWithAllocation: (x) => x.Name,
                tieredWithProration: (x) => x.Name,
                newPlanUnitWithProration: (x) => x.Name,
                newPlanGroupedAllocation: (x) => x.Name,
                newPlanBulkWithProration: (x) => x.Name,
                newPlanGroupedWithProratedMinimum: (x) => x.Name,
                newPlanGroupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newPlanMatrixWithDisplayName: (x) => x.Name,
                newPlanGroupedTieredPackage: (x) => x.Name,
                newPlanMaxGroupTieredPackage: (x) => x.Name,
                newPlanScalableMatrixWithUnitPricing: (x) => x.Name,
                newPlanScalableMatrixWithTieredPricing: (x) => x.Name,
                newPlanCumulativeGroupedBulk: (x) => x.Name,
                newPlanMinimumComposite: (x) => x.Name,
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
                newPlanUnit: (x) => x.BillableMetricID,
                newPlanTiered: (x) => x.BillableMetricID,
                newPlanBulk: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newPlanPackage: (x) => x.BillableMetricID,
                newPlanMatrix: (x) => x.BillableMetricID,
                newPlanThresholdTotalAmount: (x) => x.BillableMetricID,
                newPlanTieredPackage: (x) => x.BillableMetricID,
                newPlanTieredWithMinimum: (x) => x.BillableMetricID,
                newPlanGroupedTiered: (x) => x.BillableMetricID,
                newPlanTieredPackageWithMinimum: (x) => x.BillableMetricID,
                newPlanPackageWithAllocation: (x) => x.BillableMetricID,
                newPlanUnitWithPercent: (x) => x.BillableMetricID,
                newPlanMatrixWithAllocation: (x) => x.BillableMetricID,
                tieredWithProration: (x) => x.BillableMetricID,
                newPlanUnitWithProration: (x) => x.BillableMetricID,
                newPlanGroupedAllocation: (x) => x.BillableMetricID,
                newPlanBulkWithProration: (x) => x.BillableMetricID,
                newPlanGroupedWithProratedMinimum: (x) => x.BillableMetricID,
                newPlanGroupedWithMeteredMinimum: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newPlanMatrixWithDisplayName: (x) => x.BillableMetricID,
                newPlanGroupedTieredPackage: (x) => x.BillableMetricID,
                newPlanMaxGroupTieredPackage: (x) => x.BillableMetricID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BillableMetricID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BillableMetricID,
                newPlanCumulativeGroupedBulk: (x) => x.BillableMetricID,
                newPlanMinimumComposite: (x) => x.BillableMetricID,
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
                newPlanUnit: (x) => x.BilledInAdvance,
                newPlanTiered: (x) => x.BilledInAdvance,
                newPlanBulk: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newPlanPackage: (x) => x.BilledInAdvance,
                newPlanMatrix: (x) => x.BilledInAdvance,
                newPlanThresholdTotalAmount: (x) => x.BilledInAdvance,
                newPlanTieredPackage: (x) => x.BilledInAdvance,
                newPlanTieredWithMinimum: (x) => x.BilledInAdvance,
                newPlanGroupedTiered: (x) => x.BilledInAdvance,
                newPlanTieredPackageWithMinimum: (x) => x.BilledInAdvance,
                newPlanPackageWithAllocation: (x) => x.BilledInAdvance,
                newPlanUnitWithPercent: (x) => x.BilledInAdvance,
                newPlanMatrixWithAllocation: (x) => x.BilledInAdvance,
                tieredWithProration: (x) => x.BilledInAdvance,
                newPlanUnitWithProration: (x) => x.BilledInAdvance,
                newPlanGroupedAllocation: (x) => x.BilledInAdvance,
                newPlanBulkWithProration: (x) => x.BilledInAdvance,
                newPlanGroupedWithProratedMinimum: (x) => x.BilledInAdvance,
                newPlanGroupedWithMeteredMinimum: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newPlanMatrixWithDisplayName: (x) => x.BilledInAdvance,
                newPlanGroupedTieredPackage: (x) => x.BilledInAdvance,
                newPlanMaxGroupTieredPackage: (x) => x.BilledInAdvance,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BilledInAdvance,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BilledInAdvance,
                newPlanCumulativeGroupedBulk: (x) => x.BilledInAdvance,
                newPlanMinimumComposite: (x) => x.BilledInAdvance,
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
                newPlanUnit: (x) => x.BillingCycleConfiguration,
                newPlanTiered: (x) => x.BillingCycleConfiguration,
                newPlanBulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newPlanPackage: (x) => x.BillingCycleConfiguration,
                newPlanMatrix: (x) => x.BillingCycleConfiguration,
                newPlanThresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                newPlanTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanTieredWithMinimum: (x) => x.BillingCycleConfiguration,
                newPlanGroupedTiered: (x) => x.BillingCycleConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                newPlanPackageWithAllocation: (x) => x.BillingCycleConfiguration,
                newPlanUnitWithPercent: (x) => x.BillingCycleConfiguration,
                newPlanMatrixWithAllocation: (x) => x.BillingCycleConfiguration,
                tieredWithProration: (x) => x.BillingCycleConfiguration,
                newPlanUnitWithProration: (x) => x.BillingCycleConfiguration,
                newPlanGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newPlanBulkWithProration: (x) => x.BillingCycleConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                newPlanGroupedTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                newPlanMinimumComposite: (x) => x.BillingCycleConfiguration,
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
                newPlanUnit: (x) => x.ConversionRate,
                newPlanTiered: (x) => x.ConversionRate,
                newPlanBulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newPlanPackage: (x) => x.ConversionRate,
                newPlanMatrix: (x) => x.ConversionRate,
                newPlanThresholdTotalAmount: (x) => x.ConversionRate,
                newPlanTieredPackage: (x) => x.ConversionRate,
                newPlanTieredWithMinimum: (x) => x.ConversionRate,
                newPlanGroupedTiered: (x) => x.ConversionRate,
                newPlanTieredPackageWithMinimum: (x) => x.ConversionRate,
                newPlanPackageWithAllocation: (x) => x.ConversionRate,
                newPlanUnitWithPercent: (x) => x.ConversionRate,
                newPlanMatrixWithAllocation: (x) => x.ConversionRate,
                tieredWithProration: (x) => x.ConversionRate,
                newPlanUnitWithProration: (x) => x.ConversionRate,
                newPlanGroupedAllocation: (x) => x.ConversionRate,
                newPlanBulkWithProration: (x) => x.ConversionRate,
                newPlanGroupedWithProratedMinimum: (x) => x.ConversionRate,
                newPlanGroupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newPlanMatrixWithDisplayName: (x) => x.ConversionRate,
                newPlanGroupedTieredPackage: (x) => x.ConversionRate,
                newPlanMaxGroupTieredPackage: (x) => x.ConversionRate,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                newPlanCumulativeGroupedBulk: (x) => x.ConversionRate,
                newPlanMinimumComposite: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.Currency,
                newPlanTiered: (x) => x.Currency,
                newPlanBulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newPlanPackage: (x) => x.Currency,
                newPlanMatrix: (x) => x.Currency,
                newPlanThresholdTotalAmount: (x) => x.Currency,
                newPlanTieredPackage: (x) => x.Currency,
                newPlanTieredWithMinimum: (x) => x.Currency,
                newPlanGroupedTiered: (x) => x.Currency,
                newPlanTieredPackageWithMinimum: (x) => x.Currency,
                newPlanPackageWithAllocation: (x) => x.Currency,
                newPlanUnitWithPercent: (x) => x.Currency,
                newPlanMatrixWithAllocation: (x) => x.Currency,
                tieredWithProration: (x) => x.Currency,
                newPlanUnitWithProration: (x) => x.Currency,
                newPlanGroupedAllocation: (x) => x.Currency,
                newPlanBulkWithProration: (x) => x.Currency,
                newPlanGroupedWithProratedMinimum: (x) => x.Currency,
                newPlanGroupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newPlanMatrixWithDisplayName: (x) => x.Currency,
                newPlanGroupedTieredPackage: (x) => x.Currency,
                newPlanMaxGroupTieredPackage: (x) => x.Currency,
                newPlanScalableMatrixWithUnitPricing: (x) => x.Currency,
                newPlanScalableMatrixWithTieredPricing: (x) => x.Currency,
                newPlanCumulativeGroupedBulk: (x) => x.Currency,
                newPlanMinimumComposite: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<NewDimensionalPriceConfiguration?>(
                newPlanUnit: (x) => x.DimensionalPriceConfiguration,
                newPlanTiered: (x) => x.DimensionalPriceConfiguration,
                newPlanBulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newPlanPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrix: (x) => x.DimensionalPriceConfiguration,
                newPlanThresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedTiered: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanPackageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanUnitWithPercent: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                tieredWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanUnitWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanBulkWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.DimensionalPriceConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.DimensionalPriceConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                newPlanMinimumComposite: (x) => x.DimensionalPriceConfiguration,
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
                newPlanUnit: (x) => x.ExternalPriceID,
                newPlanTiered: (x) => x.ExternalPriceID,
                newPlanBulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newPlanPackage: (x) => x.ExternalPriceID,
                newPlanMatrix: (x) => x.ExternalPriceID,
                newPlanThresholdTotalAmount: (x) => x.ExternalPriceID,
                newPlanTieredPackage: (x) => x.ExternalPriceID,
                newPlanTieredWithMinimum: (x) => x.ExternalPriceID,
                newPlanGroupedTiered: (x) => x.ExternalPriceID,
                newPlanTieredPackageWithMinimum: (x) => x.ExternalPriceID,
                newPlanPackageWithAllocation: (x) => x.ExternalPriceID,
                newPlanUnitWithPercent: (x) => x.ExternalPriceID,
                newPlanMatrixWithAllocation: (x) => x.ExternalPriceID,
                tieredWithProration: (x) => x.ExternalPriceID,
                newPlanUnitWithProration: (x) => x.ExternalPriceID,
                newPlanGroupedAllocation: (x) => x.ExternalPriceID,
                newPlanBulkWithProration: (x) => x.ExternalPriceID,
                newPlanGroupedWithProratedMinimum: (x) => x.ExternalPriceID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newPlanMatrixWithDisplayName: (x) => x.ExternalPriceID,
                newPlanGroupedTieredPackage: (x) => x.ExternalPriceID,
                newPlanMaxGroupTieredPackage: (x) => x.ExternalPriceID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                newPlanCumulativeGroupedBulk: (x) => x.ExternalPriceID,
                newPlanMinimumComposite: (x) => x.ExternalPriceID,
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
                newPlanUnit: (x) => x.FixedPriceQuantity,
                newPlanTiered: (x) => x.FixedPriceQuantity,
                newPlanBulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newPlanPackage: (x) => x.FixedPriceQuantity,
                newPlanMatrix: (x) => x.FixedPriceQuantity,
                newPlanThresholdTotalAmount: (x) => x.FixedPriceQuantity,
                newPlanTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanTieredWithMinimum: (x) => x.FixedPriceQuantity,
                newPlanGroupedTiered: (x) => x.FixedPriceQuantity,
                newPlanTieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                newPlanPackageWithAllocation: (x) => x.FixedPriceQuantity,
                newPlanUnitWithPercent: (x) => x.FixedPriceQuantity,
                newPlanMatrixWithAllocation: (x) => x.FixedPriceQuantity,
                tieredWithProration: (x) => x.FixedPriceQuantity,
                newPlanUnitWithProration: (x) => x.FixedPriceQuantity,
                newPlanGroupedAllocation: (x) => x.FixedPriceQuantity,
                newPlanBulkWithProration: (x) => x.FixedPriceQuantity,
                newPlanGroupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                newPlanGroupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newPlanMatrixWithDisplayName: (x) => x.FixedPriceQuantity,
                newPlanGroupedTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanMaxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanScalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                newPlanScalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                newPlanCumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                newPlanMinimumComposite: (x) => x.FixedPriceQuantity,
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
                newPlanUnit: (x) => x.InvoiceGroupingKey,
                newPlanTiered: (x) => x.InvoiceGroupingKey,
                newPlanBulk: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newPlanPackage: (x) => x.InvoiceGroupingKey,
                newPlanMatrix: (x) => x.InvoiceGroupingKey,
                newPlanThresholdTotalAmount: (x) => x.InvoiceGroupingKey,
                newPlanTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanTieredWithMinimum: (x) => x.InvoiceGroupingKey,
                newPlanGroupedTiered: (x) => x.InvoiceGroupingKey,
                newPlanTieredPackageWithMinimum: (x) => x.InvoiceGroupingKey,
                newPlanPackageWithAllocation: (x) => x.InvoiceGroupingKey,
                newPlanUnitWithPercent: (x) => x.InvoiceGroupingKey,
                newPlanMatrixWithAllocation: (x) => x.InvoiceGroupingKey,
                tieredWithProration: (x) => x.InvoiceGroupingKey,
                newPlanUnitWithProration: (x) => x.InvoiceGroupingKey,
                newPlanGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newPlanBulkWithProration: (x) => x.InvoiceGroupingKey,
                newPlanGroupedWithProratedMinimum: (x) => x.InvoiceGroupingKey,
                newPlanGroupedWithMeteredMinimum: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newPlanMatrixWithDisplayName: (x) => x.InvoiceGroupingKey,
                newPlanGroupedTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanMaxGroupTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanScalableMatrixWithUnitPricing: (x) => x.InvoiceGroupingKey,
                newPlanScalableMatrixWithTieredPricing: (x) => x.InvoiceGroupingKey,
                newPlanCumulativeGroupedBulk: (x) => x.InvoiceGroupingKey,
                newPlanMinimumComposite: (x) => x.InvoiceGroupingKey,
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
                newPlanUnit: (x) => x.InvoicingCycleConfiguration,
                newPlanTiered: (x) => x.InvoicingCycleConfiguration,
                newPlanBulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newPlanPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrix: (x) => x.InvoicingCycleConfiguration,
                newPlanThresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedTiered: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanPackageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanUnitWithPercent: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                tieredWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanUnitWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanBulkWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.InvoicingCycleConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                newPlanMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public string? ReferenceID
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.ReferenceID,
                newPlanTiered: (x) => x.ReferenceID,
                newPlanBulk: (x) => x.ReferenceID,
                bulkWithFilters: (x) => x.ReferenceID,
                newPlanPackage: (x) => x.ReferenceID,
                newPlanMatrix: (x) => x.ReferenceID,
                newPlanThresholdTotalAmount: (x) => x.ReferenceID,
                newPlanTieredPackage: (x) => x.ReferenceID,
                newPlanTieredWithMinimum: (x) => x.ReferenceID,
                newPlanGroupedTiered: (x) => x.ReferenceID,
                newPlanTieredPackageWithMinimum: (x) => x.ReferenceID,
                newPlanPackageWithAllocation: (x) => x.ReferenceID,
                newPlanUnitWithPercent: (x) => x.ReferenceID,
                newPlanMatrixWithAllocation: (x) => x.ReferenceID,
                tieredWithProration: (x) => x.ReferenceID,
                newPlanUnitWithProration: (x) => x.ReferenceID,
                newPlanGroupedAllocation: (x) => x.ReferenceID,
                newPlanBulkWithProration: (x) => x.ReferenceID,
                newPlanGroupedWithProratedMinimum: (x) => x.ReferenceID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ReferenceID,
                groupedWithMinMaxThresholds: (x) => x.ReferenceID,
                newPlanMatrixWithDisplayName: (x) => x.ReferenceID,
                newPlanGroupedTieredPackage: (x) => x.ReferenceID,
                newPlanMaxGroupTieredPackage: (x) => x.ReferenceID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ReferenceID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ReferenceID,
                newPlanCumulativeGroupedBulk: (x) => x.ReferenceID,
                newPlanMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public Price(NewPlanUnitPrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredPrice value)
    {
        Value = value;
    }

    public Price(NewPlanBulkPrice value)
    {
        Value = value;
    }

    public Price(BulkWithFilters value)
    {
        Value = value;
    }

    public Price(NewPlanPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanMatrixPrice value)
    {
        Value = value;
    }

    public Price(NewPlanThresholdTotalAmountPrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredWithMinimumPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedTieredPrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredPackageWithMinimumPrice value)
    {
        Value = value;
    }

    public Price(NewPlanPackageWithAllocationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanUnitWithPercentPrice value)
    {
        Value = value;
    }

    public Price(NewPlanMatrixWithAllocationPrice value)
    {
        Value = value;
    }

    public Price(TieredWithProration value)
    {
        Value = value;
    }

    public Price(NewPlanUnitWithProrationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedAllocationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanBulkWithProrationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedWithProratedMinimumPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedWithMeteredMinimumPrice value)
    {
        Value = value;
    }

    public Price(GroupedWithMinMaxThresholds value)
    {
        Value = value;
    }

    public Price(NewPlanMatrixWithDisplayNamePrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedTieredPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanMaxGroupTieredPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanScalableMatrixWithUnitPricingPrice value)
    {
        Value = value;
    }

    public Price(NewPlanScalableMatrixWithTieredPricingPrice value)
    {
        Value = value;
    }

    public Price(NewPlanCumulativeGroupedBulkPrice value)
    {
        Value = value;
    }

    public Price(NewPlanMinimumCompositePrice value)
    {
        Value = value;
    }

    public Price(Percent value)
    {
        Value = value;
    }

    public Price(EventOutput value)
    {
        Value = value;
    }

    Price(UnknownVariant value)
    {
        Value = value;
    }

    public static Price CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickNewPlanUnit([NotNullWhen(true)] out NewPlanUnitPrice? value)
    {
        value = this.Value as NewPlanUnitPrice;
        return value != null;
    }

    public bool TryPickNewPlanTiered([NotNullWhen(true)] out NewPlanTieredPrice? value)
    {
        value = this.Value as NewPlanTieredPrice;
        return value != null;
    }

    public bool TryPickNewPlanBulk([NotNullWhen(true)] out NewPlanBulkPrice? value)
    {
        value = this.Value as NewPlanBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters([NotNullWhen(true)] out BulkWithFilters? value)
    {
        value = this.Value as BulkWithFilters;
        return value != null;
    }

    public bool TryPickNewPlanPackage([NotNullWhen(true)] out NewPlanPackagePrice? value)
    {
        value = this.Value as NewPlanPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanMatrix([NotNullWhen(true)] out NewPlanMatrixPrice? value)
    {
        value = this.Value as NewPlanMatrixPrice;
        return value != null;
    }

    public bool TryPickNewPlanThresholdTotalAmount(
        [NotNullWhen(true)] out NewPlanThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewPlanThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackage(
        [NotNullWhen(true)] out NewPlanTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTiered(
        [NotNullWhen(true)] out NewPlanGroupedTieredPrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanPackageWithAllocation(
        [NotNullWhen(true)] out NewPlanPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithPercent(
        [NotNullWhen(true)] out NewPlanUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithAllocation(
        [NotNullWhen(true)] out NewPlanMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProration? value)
    {
        value = this.Value as TieredWithProration;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithProration(
        [NotNullWhen(true)] out NewPlanUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedAllocation(
        [NotNullWhen(true)] out NewPlanGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewPlanGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewPlanBulkWithProration(
        [NotNullWhen(true)] out NewPlanBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as GroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithDisplayName(
        [NotNullWhen(true)] out NewPlanMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTieredPackage(
        [NotNullWhen(true)] out NewPlanGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewPlanMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewPlanCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewPlanCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewPlanCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
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
        Action<NewPlanUnitPrice> newPlanUnit,
        Action<NewPlanTieredPrice> newPlanTiered,
        Action<NewPlanBulkPrice> newPlanBulk,
        Action<BulkWithFilters> bulkWithFilters,
        Action<NewPlanPackagePrice> newPlanPackage,
        Action<NewPlanMatrixPrice> newPlanMatrix,
        Action<NewPlanThresholdTotalAmountPrice> newPlanThresholdTotalAmount,
        Action<NewPlanTieredPackagePrice> newPlanTieredPackage,
        Action<NewPlanTieredWithMinimumPrice> newPlanTieredWithMinimum,
        Action<NewPlanGroupedTieredPrice> newPlanGroupedTiered,
        Action<NewPlanTieredPackageWithMinimumPrice> newPlanTieredPackageWithMinimum,
        Action<NewPlanPackageWithAllocationPrice> newPlanPackageWithAllocation,
        Action<NewPlanUnitWithPercentPrice> newPlanUnitWithPercent,
        Action<NewPlanMatrixWithAllocationPrice> newPlanMatrixWithAllocation,
        Action<TieredWithProration> tieredWithProration,
        Action<NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        Action<NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        Action<NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        Action<NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        Action<NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        Action<GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        Action<NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        Action<NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        Action<NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        Action<NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        Action<NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        Action<NewPlanMinimumCompositePrice> newPlanMinimumComposite,
        Action<Percent> percent,
        Action<EventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewPlanUnitPrice value:
                newPlanUnit(value);
                break;
            case NewPlanTieredPrice value:
                newPlanTiered(value);
                break;
            case NewPlanBulkPrice value:
                newPlanBulk(value);
                break;
            case BulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewPlanPackagePrice value:
                newPlanPackage(value);
                break;
            case NewPlanMatrixPrice value:
                newPlanMatrix(value);
                break;
            case NewPlanThresholdTotalAmountPrice value:
                newPlanThresholdTotalAmount(value);
                break;
            case NewPlanTieredPackagePrice value:
                newPlanTieredPackage(value);
                break;
            case NewPlanTieredWithMinimumPrice value:
                newPlanTieredWithMinimum(value);
                break;
            case NewPlanGroupedTieredPrice value:
                newPlanGroupedTiered(value);
                break;
            case NewPlanTieredPackageWithMinimumPrice value:
                newPlanTieredPackageWithMinimum(value);
                break;
            case NewPlanPackageWithAllocationPrice value:
                newPlanPackageWithAllocation(value);
                break;
            case NewPlanUnitWithPercentPrice value:
                newPlanUnitWithPercent(value);
                break;
            case NewPlanMatrixWithAllocationPrice value:
                newPlanMatrixWithAllocation(value);
                break;
            case TieredWithProration value:
                tieredWithProration(value);
                break;
            case NewPlanUnitWithProrationPrice value:
                newPlanUnitWithProration(value);
                break;
            case NewPlanGroupedAllocationPrice value:
                newPlanGroupedAllocation(value);
                break;
            case NewPlanBulkWithProrationPrice value:
                newPlanBulkWithProration(value);
                break;
            case NewPlanGroupedWithProratedMinimumPrice value:
                newPlanGroupedWithProratedMinimum(value);
                break;
            case NewPlanGroupedWithMeteredMinimumPrice value:
                newPlanGroupedWithMeteredMinimum(value);
                break;
            case GroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewPlanMatrixWithDisplayNamePrice value:
                newPlanMatrixWithDisplayName(value);
                break;
            case NewPlanGroupedTieredPackagePrice value:
                newPlanGroupedTieredPackage(value);
                break;
            case NewPlanMaxGroupTieredPackagePrice value:
                newPlanMaxGroupTieredPackage(value);
                break;
            case NewPlanScalableMatrixWithUnitPricingPrice value:
                newPlanScalableMatrixWithUnitPricing(value);
                break;
            case NewPlanScalableMatrixWithTieredPricingPrice value:
                newPlanScalableMatrixWithTieredPricing(value);
                break;
            case NewPlanCumulativeGroupedBulkPrice value:
                newPlanCumulativeGroupedBulk(value);
                break;
            case NewPlanMinimumCompositePrice value:
                newPlanMinimumComposite(value);
                break;
            case Percent value:
                percent(value);
                break;
            case EventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    public T Match<T>(
        Func<NewPlanUnitPrice, T> newPlanUnit,
        Func<NewPlanTieredPrice, T> newPlanTiered,
        Func<NewPlanBulkPrice, T> newPlanBulk,
        Func<BulkWithFilters, T> bulkWithFilters,
        Func<NewPlanPackagePrice, T> newPlanPackage,
        Func<NewPlanMatrixPrice, T> newPlanMatrix,
        Func<NewPlanThresholdTotalAmountPrice, T> newPlanThresholdTotalAmount,
        Func<NewPlanTieredPackagePrice, T> newPlanTieredPackage,
        Func<NewPlanTieredWithMinimumPrice, T> newPlanTieredWithMinimum,
        Func<NewPlanGroupedTieredPrice, T> newPlanGroupedTiered,
        Func<NewPlanTieredPackageWithMinimumPrice, T> newPlanTieredPackageWithMinimum,
        Func<NewPlanPackageWithAllocationPrice, T> newPlanPackageWithAllocation,
        Func<NewPlanUnitWithPercentPrice, T> newPlanUnitWithPercent,
        Func<NewPlanMatrixWithAllocationPrice, T> newPlanMatrixWithAllocation,
        Func<TieredWithProration, T> tieredWithProration,
        Func<NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        Func<NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        Func<NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
        Func<NewPlanGroupedWithProratedMinimumPrice, T> newPlanGroupedWithProratedMinimum,
        Func<NewPlanGroupedWithMeteredMinimumPrice, T> newPlanGroupedWithMeteredMinimum,
        Func<GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<NewPlanMatrixWithDisplayNamePrice, T> newPlanMatrixWithDisplayName,
        Func<NewPlanGroupedTieredPackagePrice, T> newPlanGroupedTieredPackage,
        Func<NewPlanMaxGroupTieredPackagePrice, T> newPlanMaxGroupTieredPackage,
        Func<NewPlanScalableMatrixWithUnitPricingPrice, T> newPlanScalableMatrixWithUnitPricing,
        Func<NewPlanScalableMatrixWithTieredPricingPrice, T> newPlanScalableMatrixWithTieredPricing,
        Func<NewPlanCumulativeGroupedBulkPrice, T> newPlanCumulativeGroupedBulk,
        Func<NewPlanMinimumCompositePrice, T> newPlanMinimumComposite,
        Func<Percent, T> percent,
        Func<EventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewPlanUnitPrice value => newPlanUnit(value),
            NewPlanTieredPrice value => newPlanTiered(value),
            NewPlanBulkPrice value => newPlanBulk(value),
            BulkWithFilters value => bulkWithFilters(value),
            NewPlanPackagePrice value => newPlanPackage(value),
            NewPlanMatrixPrice value => newPlanMatrix(value),
            NewPlanThresholdTotalAmountPrice value => newPlanThresholdTotalAmount(value),
            NewPlanTieredPackagePrice value => newPlanTieredPackage(value),
            NewPlanTieredWithMinimumPrice value => newPlanTieredWithMinimum(value),
            NewPlanGroupedTieredPrice value => newPlanGroupedTiered(value),
            NewPlanTieredPackageWithMinimumPrice value => newPlanTieredPackageWithMinimum(value),
            NewPlanPackageWithAllocationPrice value => newPlanPackageWithAllocation(value),
            NewPlanUnitWithPercentPrice value => newPlanUnitWithPercent(value),
            NewPlanMatrixWithAllocationPrice value => newPlanMatrixWithAllocation(value),
            TieredWithProration value => tieredWithProration(value),
            NewPlanUnitWithProrationPrice value => newPlanUnitWithProration(value),
            NewPlanGroupedAllocationPrice value => newPlanGroupedAllocation(value),
            NewPlanBulkWithProrationPrice value => newPlanBulkWithProration(value),
            NewPlanGroupedWithProratedMinimumPrice value => newPlanGroupedWithProratedMinimum(
                value
            ),
            NewPlanGroupedWithMeteredMinimumPrice value => newPlanGroupedWithMeteredMinimum(value),
            GroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(value),
            NewPlanMatrixWithDisplayNamePrice value => newPlanMatrixWithDisplayName(value),
            NewPlanGroupedTieredPackagePrice value => newPlanGroupedTieredPackage(value),
            NewPlanMaxGroupTieredPackagePrice value => newPlanMaxGroupTieredPackage(value),
            NewPlanScalableMatrixWithUnitPricingPrice value => newPlanScalableMatrixWithUnitPricing(
                value
            ),
            NewPlanScalableMatrixWithTieredPricingPrice value =>
                newPlanScalableMatrixWithTieredPricing(value),
            NewPlanCumulativeGroupedBulkPrice value => newPlanCumulativeGroupedBulk(value),
            NewPlanMinimumCompositePrice value => newPlanMinimumComposite(value),
            Percent value => percent(value),
            EventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class PriceConverter : JsonConverter<Price?>
{
    public override Price? Read(
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanBulkPrice'",
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
                        return new Price(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanPackagePrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanThresholdTotalAmountPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPackagePrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredWithMinimumPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedTieredPrice'",
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
                        JsonSerializer.Deserialize<NewPlanTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPackageWithMinimumPrice'",
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
                        JsonSerializer.Deserialize<NewPlanPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanPackageWithAllocationPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitWithPercentPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixWithAllocationPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<TieredWithProration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredWithProration'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitWithProrationPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedAllocationPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanBulkWithProrationPrice'",
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
                        JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedWithProratedMinimumPrice'",
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
                        JsonSerializer.Deserialize<NewPlanGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedWithMeteredMinimumPrice'",
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
                        return new Price(deserialized);
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
                        JsonSerializer.Deserialize<NewPlanMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixWithDisplayNamePrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedTieredPackagePrice'",
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
                        JsonSerializer.Deserialize<NewPlanMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMaxGroupTieredPackagePrice'",
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
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanScalableMatrixWithUnitPricingPrice'",
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
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanScalableMatrixWithTieredPricingPrice'",
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
                        JsonSerializer.Deserialize<NewPlanCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanCumulativeGroupedBulkPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMinimumCompositePrice'",
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
                        return new Price(deserialized);
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
                        return new Price(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Price? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
