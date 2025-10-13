using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using PriceProperties = Orb.Models.PriceProperties;

namespace Orb.Models;

/// <summary>
/// The Price resource represents a price that can be billed on a subscription, resulting
/// in a charge on an invoice in the form of an invoice line item. Prices take a
/// quantity and determine an amount to bill.
///
/// Orb supports a few different pricing models out of the box. Each of these models
/// is serialized differently in a given Price object. The model_type field determines
/// the key for the configuration object that is present.
///
/// For more on the types of prices, see [the core concepts documentation](/core-concepts#plan-and-price)
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public record class Price
{
    public object Value { get; private init; }

    public string ID
    {
        get
        {
            return Match(
                unit: (x) => x.ID,
                tiered: (x) => x.ID,
                bulk: (x) => x.ID,
                bulkWithFilters: (x) => x.ID,
                package: (x) => x.ID,
                matrix: (x) => x.ID,
                thresholdTotalAmount: (x) => x.ID,
                tieredPackage: (x) => x.ID,
                tieredWithMinimum: (x) => x.ID,
                groupedTiered: (x) => x.ID,
                tieredPackageWithMinimum: (x) => x.ID,
                packageWithAllocation: (x) => x.ID,
                unitWithPercent: (x) => x.ID,
                matrixWithAllocation: (x) => x.ID,
                tieredWithProration: (x) => x.ID,
                unitWithProration: (x) => x.ID,
                groupedAllocation: (x) => x.ID,
                bulkWithProration: (x) => x.ID,
                groupedWithProratedMinimum: (x) => x.ID,
                groupedWithMeteredMinimum: (x) => x.ID,
                groupedWithMinMaxThresholds: (x) => x.ID,
                matrixWithDisplayName: (x) => x.ID,
                groupedTieredPackage: (x) => x.ID,
                maxGroupTieredPackage: (x) => x.ID,
                scalableMatrixWithUnitPricing: (x) => x.ID,
                scalableMatrixWithTieredPricing: (x) => x.ID,
                cumulativeGroupedBulk: (x) => x.ID,
                minimum: (x) => x.ID,
                percent: (x) => x.ID,
                eventOutput: (x) => x.ID
            );
        }
    }

    public BillableMetricTiny? BillableMetric
    {
        get
        {
            return Match<BillableMetricTiny?>(
                unit: (x) => x.BillableMetric,
                tiered: (x) => x.BillableMetric,
                bulk: (x) => x.BillableMetric,
                bulkWithFilters: (x) => x.BillableMetric,
                package: (x) => x.BillableMetric,
                matrix: (x) => x.BillableMetric,
                thresholdTotalAmount: (x) => x.BillableMetric,
                tieredPackage: (x) => x.BillableMetric,
                tieredWithMinimum: (x) => x.BillableMetric,
                groupedTiered: (x) => x.BillableMetric,
                tieredPackageWithMinimum: (x) => x.BillableMetric,
                packageWithAllocation: (x) => x.BillableMetric,
                unitWithPercent: (x) => x.BillableMetric,
                matrixWithAllocation: (x) => x.BillableMetric,
                tieredWithProration: (x) => x.BillableMetric,
                unitWithProration: (x) => x.BillableMetric,
                groupedAllocation: (x) => x.BillableMetric,
                bulkWithProration: (x) => x.BillableMetric,
                groupedWithProratedMinimum: (x) => x.BillableMetric,
                groupedWithMeteredMinimum: (x) => x.BillableMetric,
                groupedWithMinMaxThresholds: (x) => x.BillableMetric,
                matrixWithDisplayName: (x) => x.BillableMetric,
                groupedTieredPackage: (x) => x.BillableMetric,
                maxGroupTieredPackage: (x) => x.BillableMetric,
                scalableMatrixWithUnitPricing: (x) => x.BillableMetric,
                scalableMatrixWithTieredPricing: (x) => x.BillableMetric,
                cumulativeGroupedBulk: (x) => x.BillableMetric,
                minimum: (x) => x.BillableMetric,
                percent: (x) => x.BillableMetric,
                eventOutput: (x) => x.BillableMetric
            );
        }
    }

    public BillingCycleConfiguration BillingCycleConfiguration
    {
        get
        {
            return Match(
                unit: (x) => x.BillingCycleConfiguration,
                tiered: (x) => x.BillingCycleConfiguration,
                bulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                package: (x) => x.BillingCycleConfiguration,
                matrix: (x) => x.BillingCycleConfiguration,
                thresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                tieredPackage: (x) => x.BillingCycleConfiguration,
                tieredWithMinimum: (x) => x.BillingCycleConfiguration,
                groupedTiered: (x) => x.BillingCycleConfiguration,
                tieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                packageWithAllocation: (x) => x.BillingCycleConfiguration,
                unitWithPercent: (x) => x.BillingCycleConfiguration,
                matrixWithAllocation: (x) => x.BillingCycleConfiguration,
                tieredWithProration: (x) => x.BillingCycleConfiguration,
                unitWithProration: (x) => x.BillingCycleConfiguration,
                groupedAllocation: (x) => x.BillingCycleConfiguration,
                bulkWithProration: (x) => x.BillingCycleConfiguration,
                groupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                matrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                groupedTieredPackage: (x) => x.BillingCycleConfiguration,
                maxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                scalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                scalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                minimum: (x) => x.BillingCycleConfiguration,
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
                unit: (x) => x.ConversionRate,
                tiered: (x) => x.ConversionRate,
                bulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                package: (x) => x.ConversionRate,
                matrix: (x) => x.ConversionRate,
                thresholdTotalAmount: (x) => x.ConversionRate,
                tieredPackage: (x) => x.ConversionRate,
                tieredWithMinimum: (x) => x.ConversionRate,
                groupedTiered: (x) => x.ConversionRate,
                tieredPackageWithMinimum: (x) => x.ConversionRate,
                packageWithAllocation: (x) => x.ConversionRate,
                unitWithPercent: (x) => x.ConversionRate,
                matrixWithAllocation: (x) => x.ConversionRate,
                tieredWithProration: (x) => x.ConversionRate,
                unitWithProration: (x) => x.ConversionRate,
                groupedAllocation: (x) => x.ConversionRate,
                bulkWithProration: (x) => x.ConversionRate,
                groupedWithProratedMinimum: (x) => x.ConversionRate,
                groupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                matrixWithDisplayName: (x) => x.ConversionRate,
                groupedTieredPackage: (x) => x.ConversionRate,
                maxGroupTieredPackage: (x) => x.ConversionRate,
                scalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                scalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                cumulativeGroupedBulk: (x) => x.ConversionRate,
                minimum: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public DateTime CreatedAt
    {
        get
        {
            return Match(
                unit: (x) => x.CreatedAt,
                tiered: (x) => x.CreatedAt,
                bulk: (x) => x.CreatedAt,
                bulkWithFilters: (x) => x.CreatedAt,
                package: (x) => x.CreatedAt,
                matrix: (x) => x.CreatedAt,
                thresholdTotalAmount: (x) => x.CreatedAt,
                tieredPackage: (x) => x.CreatedAt,
                tieredWithMinimum: (x) => x.CreatedAt,
                groupedTiered: (x) => x.CreatedAt,
                tieredPackageWithMinimum: (x) => x.CreatedAt,
                packageWithAllocation: (x) => x.CreatedAt,
                unitWithPercent: (x) => x.CreatedAt,
                matrixWithAllocation: (x) => x.CreatedAt,
                tieredWithProration: (x) => x.CreatedAt,
                unitWithProration: (x) => x.CreatedAt,
                groupedAllocation: (x) => x.CreatedAt,
                bulkWithProration: (x) => x.CreatedAt,
                groupedWithProratedMinimum: (x) => x.CreatedAt,
                groupedWithMeteredMinimum: (x) => x.CreatedAt,
                groupedWithMinMaxThresholds: (x) => x.CreatedAt,
                matrixWithDisplayName: (x) => x.CreatedAt,
                groupedTieredPackage: (x) => x.CreatedAt,
                maxGroupTieredPackage: (x) => x.CreatedAt,
                scalableMatrixWithUnitPricing: (x) => x.CreatedAt,
                scalableMatrixWithTieredPricing: (x) => x.CreatedAt,
                cumulativeGroupedBulk: (x) => x.CreatedAt,
                minimum: (x) => x.CreatedAt,
                percent: (x) => x.CreatedAt,
                eventOutput: (x) => x.CreatedAt
            );
        }
    }

    public Allocation? CreditAllocation
    {
        get
        {
            return Match<Allocation?>(
                unit: (x) => x.CreditAllocation,
                tiered: (x) => x.CreditAllocation,
                bulk: (x) => x.CreditAllocation,
                bulkWithFilters: (x) => x.CreditAllocation,
                package: (x) => x.CreditAllocation,
                matrix: (x) => x.CreditAllocation,
                thresholdTotalAmount: (x) => x.CreditAllocation,
                tieredPackage: (x) => x.CreditAllocation,
                tieredWithMinimum: (x) => x.CreditAllocation,
                groupedTiered: (x) => x.CreditAllocation,
                tieredPackageWithMinimum: (x) => x.CreditAllocation,
                packageWithAllocation: (x) => x.CreditAllocation,
                unitWithPercent: (x) => x.CreditAllocation,
                matrixWithAllocation: (x) => x.CreditAllocation,
                tieredWithProration: (x) => x.CreditAllocation,
                unitWithProration: (x) => x.CreditAllocation,
                groupedAllocation: (x) => x.CreditAllocation,
                bulkWithProration: (x) => x.CreditAllocation,
                groupedWithProratedMinimum: (x) => x.CreditAllocation,
                groupedWithMeteredMinimum: (x) => x.CreditAllocation,
                groupedWithMinMaxThresholds: (x) => x.CreditAllocation,
                matrixWithDisplayName: (x) => x.CreditAllocation,
                groupedTieredPackage: (x) => x.CreditAllocation,
                maxGroupTieredPackage: (x) => x.CreditAllocation,
                scalableMatrixWithUnitPricing: (x) => x.CreditAllocation,
                scalableMatrixWithTieredPricing: (x) => x.CreditAllocation,
                cumulativeGroupedBulk: (x) => x.CreditAllocation,
                minimum: (x) => x.CreditAllocation,
                percent: (x) => x.CreditAllocation,
                eventOutput: (x) => x.CreditAllocation
            );
        }
    }

    public string Currency
    {
        get
        {
            return Match(
                unit: (x) => x.Currency,
                tiered: (x) => x.Currency,
                bulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                package: (x) => x.Currency,
                matrix: (x) => x.Currency,
                thresholdTotalAmount: (x) => x.Currency,
                tieredPackage: (x) => x.Currency,
                tieredWithMinimum: (x) => x.Currency,
                groupedTiered: (x) => x.Currency,
                tieredPackageWithMinimum: (x) => x.Currency,
                packageWithAllocation: (x) => x.Currency,
                unitWithPercent: (x) => x.Currency,
                matrixWithAllocation: (x) => x.Currency,
                tieredWithProration: (x) => x.Currency,
                unitWithProration: (x) => x.Currency,
                groupedAllocation: (x) => x.Currency,
                bulkWithProration: (x) => x.Currency,
                groupedWithProratedMinimum: (x) => x.Currency,
                groupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                matrixWithDisplayName: (x) => x.Currency,
                groupedTieredPackage: (x) => x.Currency,
                maxGroupTieredPackage: (x) => x.Currency,
                scalableMatrixWithUnitPricing: (x) => x.Currency,
                scalableMatrixWithTieredPricing: (x) => x.Currency,
                cumulativeGroupedBulk: (x) => x.Currency,
                minimum: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public Discount? Discount
    {
        get
        {
            return Match<Discount?>(
                unit: (x) => x.Discount,
                tiered: (x) => x.Discount,
                bulk: (x) => x.Discount,
                bulkWithFilters: (x) => x.Discount,
                package: (x) => x.Discount,
                matrix: (x) => x.Discount,
                thresholdTotalAmount: (x) => x.Discount,
                tieredPackage: (x) => x.Discount,
                tieredWithMinimum: (x) => x.Discount,
                groupedTiered: (x) => x.Discount,
                tieredPackageWithMinimum: (x) => x.Discount,
                packageWithAllocation: (x) => x.Discount,
                unitWithPercent: (x) => x.Discount,
                matrixWithAllocation: (x) => x.Discount,
                tieredWithProration: (x) => x.Discount,
                unitWithProration: (x) => x.Discount,
                groupedAllocation: (x) => x.Discount,
                bulkWithProration: (x) => x.Discount,
                groupedWithProratedMinimum: (x) => x.Discount,
                groupedWithMeteredMinimum: (x) => x.Discount,
                groupedWithMinMaxThresholds: (x) => x.Discount,
                matrixWithDisplayName: (x) => x.Discount,
                groupedTieredPackage: (x) => x.Discount,
                maxGroupTieredPackage: (x) => x.Discount,
                scalableMatrixWithUnitPricing: (x) => x.Discount,
                scalableMatrixWithTieredPricing: (x) => x.Discount,
                cumulativeGroupedBulk: (x) => x.Discount,
                minimum: (x) => x.Discount,
                percent: (x) => x.Discount,
                eventOutput: (x) => x.Discount
            );
        }
    }

    public string? ExternalPriceID
    {
        get
        {
            return Match<string?>(
                unit: (x) => x.ExternalPriceID,
                tiered: (x) => x.ExternalPriceID,
                bulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                package: (x) => x.ExternalPriceID,
                matrix: (x) => x.ExternalPriceID,
                thresholdTotalAmount: (x) => x.ExternalPriceID,
                tieredPackage: (x) => x.ExternalPriceID,
                tieredWithMinimum: (x) => x.ExternalPriceID,
                groupedTiered: (x) => x.ExternalPriceID,
                tieredPackageWithMinimum: (x) => x.ExternalPriceID,
                packageWithAllocation: (x) => x.ExternalPriceID,
                unitWithPercent: (x) => x.ExternalPriceID,
                matrixWithAllocation: (x) => x.ExternalPriceID,
                tieredWithProration: (x) => x.ExternalPriceID,
                unitWithProration: (x) => x.ExternalPriceID,
                groupedAllocation: (x) => x.ExternalPriceID,
                bulkWithProration: (x) => x.ExternalPriceID,
                groupedWithProratedMinimum: (x) => x.ExternalPriceID,
                groupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                matrixWithDisplayName: (x) => x.ExternalPriceID,
                groupedTieredPackage: (x) => x.ExternalPriceID,
                maxGroupTieredPackage: (x) => x.ExternalPriceID,
                scalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                scalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                cumulativeGroupedBulk: (x) => x.ExternalPriceID,
                minimum: (x) => x.ExternalPriceID,
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
                unit: (x) => x.FixedPriceQuantity,
                tiered: (x) => x.FixedPriceQuantity,
                bulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                package: (x) => x.FixedPriceQuantity,
                matrix: (x) => x.FixedPriceQuantity,
                thresholdTotalAmount: (x) => x.FixedPriceQuantity,
                tieredPackage: (x) => x.FixedPriceQuantity,
                tieredWithMinimum: (x) => x.FixedPriceQuantity,
                groupedTiered: (x) => x.FixedPriceQuantity,
                tieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                packageWithAllocation: (x) => x.FixedPriceQuantity,
                unitWithPercent: (x) => x.FixedPriceQuantity,
                matrixWithAllocation: (x) => x.FixedPriceQuantity,
                tieredWithProration: (x) => x.FixedPriceQuantity,
                unitWithProration: (x) => x.FixedPriceQuantity,
                groupedAllocation: (x) => x.FixedPriceQuantity,
                bulkWithProration: (x) => x.FixedPriceQuantity,
                groupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                matrixWithDisplayName: (x) => x.FixedPriceQuantity,
                groupedTieredPackage: (x) => x.FixedPriceQuantity,
                maxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                scalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                scalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                cumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                minimum: (x) => x.FixedPriceQuantity,
                percent: (x) => x.FixedPriceQuantity,
                eventOutput: (x) => x.FixedPriceQuantity
            );
        }
    }

    public BillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return Match<BillingCycleConfiguration?>(
                unit: (x) => x.InvoicingCycleConfiguration,
                tiered: (x) => x.InvoicingCycleConfiguration,
                bulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                package: (x) => x.InvoicingCycleConfiguration,
                matrix: (x) => x.InvoicingCycleConfiguration,
                thresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                tieredPackage: (x) => x.InvoicingCycleConfiguration,
                tieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedTiered: (x) => x.InvoicingCycleConfiguration,
                tieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                packageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                unitWithPercent: (x) => x.InvoicingCycleConfiguration,
                matrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                tieredWithProration: (x) => x.InvoicingCycleConfiguration,
                unitWithProration: (x) => x.InvoicingCycleConfiguration,
                groupedAllocation: (x) => x.InvoicingCycleConfiguration,
                bulkWithProration: (x) => x.InvoicingCycleConfiguration,
                groupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                matrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                groupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                maxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                scalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                scalableMatrixWithTieredPricing: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                minimum: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public ItemSlim Item
    {
        get
        {
            return Match(
                unit: (x) => x.Item,
                tiered: (x) => x.Item,
                bulk: (x) => x.Item,
                bulkWithFilters: (x) => x.Item,
                package: (x) => x.Item,
                matrix: (x) => x.Item,
                thresholdTotalAmount: (x) => x.Item,
                tieredPackage: (x) => x.Item,
                tieredWithMinimum: (x) => x.Item,
                groupedTiered: (x) => x.Item,
                tieredPackageWithMinimum: (x) => x.Item,
                packageWithAllocation: (x) => x.Item,
                unitWithPercent: (x) => x.Item,
                matrixWithAllocation: (x) => x.Item,
                tieredWithProration: (x) => x.Item,
                unitWithProration: (x) => x.Item,
                groupedAllocation: (x) => x.Item,
                bulkWithProration: (x) => x.Item,
                groupedWithProratedMinimum: (x) => x.Item,
                groupedWithMeteredMinimum: (x) => x.Item,
                groupedWithMinMaxThresholds: (x) => x.Item,
                matrixWithDisplayName: (x) => x.Item,
                groupedTieredPackage: (x) => x.Item,
                maxGroupTieredPackage: (x) => x.Item,
                scalableMatrixWithUnitPricing: (x) => x.Item,
                scalableMatrixWithTieredPricing: (x) => x.Item,
                cumulativeGroupedBulk: (x) => x.Item,
                minimum: (x) => x.Item,
                percent: (x) => x.Item,
                eventOutput: (x) => x.Item
            );
        }
    }

    public Maximum? Maximum
    {
        get
        {
            return Match<Maximum?>(
                unit: (x) => x.Maximum,
                tiered: (x) => x.Maximum,
                bulk: (x) => x.Maximum,
                bulkWithFilters: (x) => x.Maximum,
                package: (x) => x.Maximum,
                matrix: (x) => x.Maximum,
                thresholdTotalAmount: (x) => x.Maximum,
                tieredPackage: (x) => x.Maximum,
                tieredWithMinimum: (x) => x.Maximum,
                groupedTiered: (x) => x.Maximum,
                tieredPackageWithMinimum: (x) => x.Maximum,
                packageWithAllocation: (x) => x.Maximum,
                unitWithPercent: (x) => x.Maximum,
                matrixWithAllocation: (x) => x.Maximum,
                tieredWithProration: (x) => x.Maximum,
                unitWithProration: (x) => x.Maximum,
                groupedAllocation: (x) => x.Maximum,
                bulkWithProration: (x) => x.Maximum,
                groupedWithProratedMinimum: (x) => x.Maximum,
                groupedWithMeteredMinimum: (x) => x.Maximum,
                groupedWithMinMaxThresholds: (x) => x.Maximum,
                matrixWithDisplayName: (x) => x.Maximum,
                groupedTieredPackage: (x) => x.Maximum,
                maxGroupTieredPackage: (x) => x.Maximum,
                scalableMatrixWithUnitPricing: (x) => x.Maximum,
                scalableMatrixWithTieredPricing: (x) => x.Maximum,
                cumulativeGroupedBulk: (x) => x.Maximum,
                minimum: (x) => x.Maximum,
                percent: (x) => x.Maximum,
                eventOutput: (x) => x.Maximum
            );
        }
    }

    public string? MaximumAmount
    {
        get
        {
            return Match<string?>(
                unit: (x) => x.MaximumAmount,
                tiered: (x) => x.MaximumAmount,
                bulk: (x) => x.MaximumAmount,
                bulkWithFilters: (x) => x.MaximumAmount,
                package: (x) => x.MaximumAmount,
                matrix: (x) => x.MaximumAmount,
                thresholdTotalAmount: (x) => x.MaximumAmount,
                tieredPackage: (x) => x.MaximumAmount,
                tieredWithMinimum: (x) => x.MaximumAmount,
                groupedTiered: (x) => x.MaximumAmount,
                tieredPackageWithMinimum: (x) => x.MaximumAmount,
                packageWithAllocation: (x) => x.MaximumAmount,
                unitWithPercent: (x) => x.MaximumAmount,
                matrixWithAllocation: (x) => x.MaximumAmount,
                tieredWithProration: (x) => x.MaximumAmount,
                unitWithProration: (x) => x.MaximumAmount,
                groupedAllocation: (x) => x.MaximumAmount,
                bulkWithProration: (x) => x.MaximumAmount,
                groupedWithProratedMinimum: (x) => x.MaximumAmount,
                groupedWithMeteredMinimum: (x) => x.MaximumAmount,
                groupedWithMinMaxThresholds: (x) => x.MaximumAmount,
                matrixWithDisplayName: (x) => x.MaximumAmount,
                groupedTieredPackage: (x) => x.MaximumAmount,
                maxGroupTieredPackage: (x) => x.MaximumAmount,
                scalableMatrixWithUnitPricing: (x) => x.MaximumAmount,
                scalableMatrixWithTieredPricing: (x) => x.MaximumAmount,
                cumulativeGroupedBulk: (x) => x.MaximumAmount,
                minimum: (x) => x.MaximumAmount,
                percent: (x) => x.MaximumAmount,
                eventOutput: (x) => x.MaximumAmount
            );
        }
    }

    public Minimum? Minimum
    {
        get
        {
            return Match<Minimum?>(
                unit: (x) => x.Minimum,
                tiered: (x) => x.Minimum,
                bulk: (x) => x.Minimum,
                bulkWithFilters: (x) => x.Minimum,
                package: (x) => x.Minimum,
                matrix: (x) => x.Minimum,
                thresholdTotalAmount: (x) => x.Minimum,
                tieredPackage: (x) => x.Minimum,
                tieredWithMinimum: (x) => x.Minimum,
                groupedTiered: (x) => x.Minimum,
                tieredPackageWithMinimum: (x) => x.Minimum,
                packageWithAllocation: (x) => x.Minimum,
                unitWithPercent: (x) => x.Minimum,
                matrixWithAllocation: (x) => x.Minimum,
                tieredWithProration: (x) => x.Minimum,
                unitWithProration: (x) => x.Minimum,
                groupedAllocation: (x) => x.Minimum,
                bulkWithProration: (x) => x.Minimum,
                groupedWithProratedMinimum: (x) => x.Minimum,
                groupedWithMeteredMinimum: (x) => x.Minimum,
                groupedWithMinMaxThresholds: (x) => x.Minimum,
                matrixWithDisplayName: (x) => x.Minimum,
                groupedTieredPackage: (x) => x.Minimum,
                maxGroupTieredPackage: (x) => x.Minimum,
                scalableMatrixWithUnitPricing: (x) => x.Minimum,
                scalableMatrixWithTieredPricing: (x) => x.Minimum,
                cumulativeGroupedBulk: (x) => x.Minimum,
                minimum: (x) => x.Minimum1,
                percent: (x) => x.Minimum,
                eventOutput: (x) => x.Minimum
            );
        }
    }

    public string? MinimumAmount
    {
        get
        {
            return Match<string?>(
                unit: (x) => x.MinimumAmount,
                tiered: (x) => x.MinimumAmount,
                bulk: (x) => x.MinimumAmount,
                bulkWithFilters: (x) => x.MinimumAmount,
                package: (x) => x.MinimumAmount,
                matrix: (x) => x.MinimumAmount,
                thresholdTotalAmount: (x) => x.MinimumAmount,
                tieredPackage: (x) => x.MinimumAmount,
                tieredWithMinimum: (x) => x.MinimumAmount,
                groupedTiered: (x) => x.MinimumAmount,
                tieredPackageWithMinimum: (x) => x.MinimumAmount,
                packageWithAllocation: (x) => x.MinimumAmount,
                unitWithPercent: (x) => x.MinimumAmount,
                matrixWithAllocation: (x) => x.MinimumAmount,
                tieredWithProration: (x) => x.MinimumAmount,
                unitWithProration: (x) => x.MinimumAmount,
                groupedAllocation: (x) => x.MinimumAmount,
                bulkWithProration: (x) => x.MinimumAmount,
                groupedWithProratedMinimum: (x) => x.MinimumAmount,
                groupedWithMeteredMinimum: (x) => x.MinimumAmount,
                groupedWithMinMaxThresholds: (x) => x.MinimumAmount,
                matrixWithDisplayName: (x) => x.MinimumAmount,
                groupedTieredPackage: (x) => x.MinimumAmount,
                maxGroupTieredPackage: (x) => x.MinimumAmount,
                scalableMatrixWithUnitPricing: (x) => x.MinimumAmount,
                scalableMatrixWithTieredPricing: (x) => x.MinimumAmount,
                cumulativeGroupedBulk: (x) => x.MinimumAmount,
                minimum: (x) => x.MinimumAmount,
                percent: (x) => x.MinimumAmount,
                eventOutput: (x) => x.MinimumAmount
            );
        }
    }

    public string Name
    {
        get
        {
            return Match(
                unit: (x) => x.Name,
                tiered: (x) => x.Name,
                bulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                package: (x) => x.Name,
                matrix: (x) => x.Name,
                thresholdTotalAmount: (x) => x.Name,
                tieredPackage: (x) => x.Name,
                tieredWithMinimum: (x) => x.Name,
                groupedTiered: (x) => x.Name,
                tieredPackageWithMinimum: (x) => x.Name,
                packageWithAllocation: (x) => x.Name,
                unitWithPercent: (x) => x.Name,
                matrixWithAllocation: (x) => x.Name,
                tieredWithProration: (x) => x.Name,
                unitWithProration: (x) => x.Name,
                groupedAllocation: (x) => x.Name,
                bulkWithProration: (x) => x.Name,
                groupedWithProratedMinimum: (x) => x.Name,
                groupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                matrixWithDisplayName: (x) => x.Name,
                groupedTieredPackage: (x) => x.Name,
                maxGroupTieredPackage: (x) => x.Name,
                scalableMatrixWithUnitPricing: (x) => x.Name,
                scalableMatrixWithTieredPricing: (x) => x.Name,
                cumulativeGroupedBulk: (x) => x.Name,
                minimum: (x) => x.Name,
                percent: (x) => x.Name,
                eventOutput: (x) => x.Name
            );
        }
    }

    public long? PlanPhaseOrder
    {
        get
        {
            return Match<long?>(
                unit: (x) => x.PlanPhaseOrder,
                tiered: (x) => x.PlanPhaseOrder,
                bulk: (x) => x.PlanPhaseOrder,
                bulkWithFilters: (x) => x.PlanPhaseOrder,
                package: (x) => x.PlanPhaseOrder,
                matrix: (x) => x.PlanPhaseOrder,
                thresholdTotalAmount: (x) => x.PlanPhaseOrder,
                tieredPackage: (x) => x.PlanPhaseOrder,
                tieredWithMinimum: (x) => x.PlanPhaseOrder,
                groupedTiered: (x) => x.PlanPhaseOrder,
                tieredPackageWithMinimum: (x) => x.PlanPhaseOrder,
                packageWithAllocation: (x) => x.PlanPhaseOrder,
                unitWithPercent: (x) => x.PlanPhaseOrder,
                matrixWithAllocation: (x) => x.PlanPhaseOrder,
                tieredWithProration: (x) => x.PlanPhaseOrder,
                unitWithProration: (x) => x.PlanPhaseOrder,
                groupedAllocation: (x) => x.PlanPhaseOrder,
                bulkWithProration: (x) => x.PlanPhaseOrder,
                groupedWithProratedMinimum: (x) => x.PlanPhaseOrder,
                groupedWithMeteredMinimum: (x) => x.PlanPhaseOrder,
                groupedWithMinMaxThresholds: (x) => x.PlanPhaseOrder,
                matrixWithDisplayName: (x) => x.PlanPhaseOrder,
                groupedTieredPackage: (x) => x.PlanPhaseOrder,
                maxGroupTieredPackage: (x) => x.PlanPhaseOrder,
                scalableMatrixWithUnitPricing: (x) => x.PlanPhaseOrder,
                scalableMatrixWithTieredPricing: (x) => x.PlanPhaseOrder,
                cumulativeGroupedBulk: (x) => x.PlanPhaseOrder,
                minimum: (x) => x.PlanPhaseOrder,
                percent: (x) => x.PlanPhaseOrder,
                eventOutput: (x) => x.PlanPhaseOrder
            );
        }
    }

    public string? ReplacesPriceID
    {
        get
        {
            return Match<string?>(
                unit: (x) => x.ReplacesPriceID,
                tiered: (x) => x.ReplacesPriceID,
                bulk: (x) => x.ReplacesPriceID,
                bulkWithFilters: (x) => x.ReplacesPriceID,
                package: (x) => x.ReplacesPriceID,
                matrix: (x) => x.ReplacesPriceID,
                thresholdTotalAmount: (x) => x.ReplacesPriceID,
                tieredPackage: (x) => x.ReplacesPriceID,
                tieredWithMinimum: (x) => x.ReplacesPriceID,
                groupedTiered: (x) => x.ReplacesPriceID,
                tieredPackageWithMinimum: (x) => x.ReplacesPriceID,
                packageWithAllocation: (x) => x.ReplacesPriceID,
                unitWithPercent: (x) => x.ReplacesPriceID,
                matrixWithAllocation: (x) => x.ReplacesPriceID,
                tieredWithProration: (x) => x.ReplacesPriceID,
                unitWithProration: (x) => x.ReplacesPriceID,
                groupedAllocation: (x) => x.ReplacesPriceID,
                bulkWithProration: (x) => x.ReplacesPriceID,
                groupedWithProratedMinimum: (x) => x.ReplacesPriceID,
                groupedWithMeteredMinimum: (x) => x.ReplacesPriceID,
                groupedWithMinMaxThresholds: (x) => x.ReplacesPriceID,
                matrixWithDisplayName: (x) => x.ReplacesPriceID,
                groupedTieredPackage: (x) => x.ReplacesPriceID,
                maxGroupTieredPackage: (x) => x.ReplacesPriceID,
                scalableMatrixWithUnitPricing: (x) => x.ReplacesPriceID,
                scalableMatrixWithTieredPricing: (x) => x.ReplacesPriceID,
                cumulativeGroupedBulk: (x) => x.ReplacesPriceID,
                minimum: (x) => x.ReplacesPriceID,
                percent: (x) => x.ReplacesPriceID,
                eventOutput: (x) => x.ReplacesPriceID
            );
        }
    }

    public DimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<DimensionalPriceConfiguration?>(
                unit: (x) => x.DimensionalPriceConfiguration,
                tiered: (x) => x.DimensionalPriceConfiguration,
                bulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                package: (x) => x.DimensionalPriceConfiguration,
                matrix: (x) => x.DimensionalPriceConfiguration,
                thresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                tieredPackage: (x) => x.DimensionalPriceConfiguration,
                tieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedTiered: (x) => x.DimensionalPriceConfiguration,
                tieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                packageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                unitWithPercent: (x) => x.DimensionalPriceConfiguration,
                matrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                tieredWithProration: (x) => x.DimensionalPriceConfiguration,
                unitWithProration: (x) => x.DimensionalPriceConfiguration,
                groupedAllocation: (x) => x.DimensionalPriceConfiguration,
                bulkWithProration: (x) => x.DimensionalPriceConfiguration,
                groupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                matrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                groupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                maxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                scalableMatrixWithUnitPricing: (x) => x.DimensionalPriceConfiguration,
                scalableMatrixWithTieredPricing: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                minimum: (x) => x.DimensionalPriceConfiguration,
                percent: (x) => x.DimensionalPriceConfiguration,
                eventOutput: (x) => x.DimensionalPriceConfiguration
            );
        }
    }

    public Price(PriceProperties::Unit value)
    {
        Value = value;
    }

    public Price(PriceProperties::Tiered value)
    {
        Value = value;
    }

    public Price(PriceProperties::Bulk value)
    {
        Value = value;
    }

    public Price(PriceProperties::BulkWithFilters value)
    {
        Value = value;
    }

    public Price(PriceProperties::Package value)
    {
        Value = value;
    }

    public Price(PriceProperties::Matrix value)
    {
        Value = value;
    }

    public Price(PriceProperties::ThresholdTotalAmount value)
    {
        Value = value;
    }

    public Price(PriceProperties::TieredPackage value)
    {
        Value = value;
    }

    public Price(PriceProperties::TieredWithMinimum value)
    {
        Value = value;
    }

    public Price(PriceProperties::GroupedTiered value)
    {
        Value = value;
    }

    public Price(PriceProperties::TieredPackageWithMinimum value)
    {
        Value = value;
    }

    public Price(PriceProperties::PackageWithAllocation value)
    {
        Value = value;
    }

    public Price(PriceProperties::UnitWithPercent value)
    {
        Value = value;
    }

    public Price(PriceProperties::MatrixWithAllocation value)
    {
        Value = value;
    }

    public Price(PriceProperties::TieredWithProration value)
    {
        Value = value;
    }

    public Price(PriceProperties::UnitWithProration value)
    {
        Value = value;
    }

    public Price(PriceProperties::GroupedAllocation value)
    {
        Value = value;
    }

    public Price(PriceProperties::BulkWithProration value)
    {
        Value = value;
    }

    public Price(PriceProperties::GroupedWithProratedMinimum value)
    {
        Value = value;
    }

    public Price(PriceProperties::GroupedWithMeteredMinimum value)
    {
        Value = value;
    }

    public Price(PriceProperties::GroupedWithMinMaxThresholds value)
    {
        Value = value;
    }

    public Price(PriceProperties::MatrixWithDisplayName value)
    {
        Value = value;
    }

    public Price(PriceProperties::GroupedTieredPackage value)
    {
        Value = value;
    }

    public Price(PriceProperties::MaxGroupTieredPackage value)
    {
        Value = value;
    }

    public Price(PriceProperties::ScalableMatrixWithUnitPricing value)
    {
        Value = value;
    }

    public Price(PriceProperties::ScalableMatrixWithTieredPricing value)
    {
        Value = value;
    }

    public Price(PriceProperties::CumulativeGroupedBulk value)
    {
        Value = value;
    }

    public Price(PriceProperties::Minimum value)
    {
        Value = value;
    }

    public Price(PriceProperties::Percent value)
    {
        Value = value;
    }

    public Price(PriceProperties::EventOutput value)
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

    public bool TryPickUnit([NotNullWhen(true)] out PriceProperties::Unit? value)
    {
        value = this.Value as PriceProperties::Unit;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out PriceProperties::Tiered? value)
    {
        value = this.Value as PriceProperties::Tiered;
        return value != null;
    }

    public bool TryPickBulk([NotNullWhen(true)] out PriceProperties::Bulk? value)
    {
        value = this.Value as PriceProperties::Bulk;
        return value != null;
    }

    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out PriceProperties::BulkWithFilters? value
    )
    {
        value = this.Value as PriceProperties::BulkWithFilters;
        return value != null;
    }

    public bool TryPickPackage([NotNullWhen(true)] out PriceProperties::Package? value)
    {
        value = this.Value as PriceProperties::Package;
        return value != null;
    }

    public bool TryPickMatrix([NotNullWhen(true)] out PriceProperties::Matrix? value)
    {
        value = this.Value as PriceProperties::Matrix;
        return value != null;
    }

    public bool TryPickThresholdTotalAmount(
        [NotNullWhen(true)] out PriceProperties::ThresholdTotalAmount? value
    )
    {
        value = this.Value as PriceProperties::ThresholdTotalAmount;
        return value != null;
    }

    public bool TryPickTieredPackage([NotNullWhen(true)] out PriceProperties::TieredPackage? value)
    {
        value = this.Value as PriceProperties::TieredPackage;
        return value != null;
    }

    public bool TryPickTieredWithMinimum(
        [NotNullWhen(true)] out PriceProperties::TieredWithMinimum? value
    )
    {
        value = this.Value as PriceProperties::TieredWithMinimum;
        return value != null;
    }

    public bool TryPickGroupedTiered([NotNullWhen(true)] out PriceProperties::GroupedTiered? value)
    {
        value = this.Value as PriceProperties::GroupedTiered;
        return value != null;
    }

    public bool TryPickTieredPackageWithMinimum(
        [NotNullWhen(true)] out PriceProperties::TieredPackageWithMinimum? value
    )
    {
        value = this.Value as PriceProperties::TieredPackageWithMinimum;
        return value != null;
    }

    public bool TryPickPackageWithAllocation(
        [NotNullWhen(true)] out PriceProperties::PackageWithAllocation? value
    )
    {
        value = this.Value as PriceProperties::PackageWithAllocation;
        return value != null;
    }

    public bool TryPickUnitWithPercent(
        [NotNullWhen(true)] out PriceProperties::UnitWithPercent? value
    )
    {
        value = this.Value as PriceProperties::UnitWithPercent;
        return value != null;
    }

    public bool TryPickMatrixWithAllocation(
        [NotNullWhen(true)] out PriceProperties::MatrixWithAllocation? value
    )
    {
        value = this.Value as PriceProperties::MatrixWithAllocation;
        return value != null;
    }

    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out PriceProperties::TieredWithProration? value
    )
    {
        value = this.Value as PriceProperties::TieredWithProration;
        return value != null;
    }

    public bool TryPickUnitWithProration(
        [NotNullWhen(true)] out PriceProperties::UnitWithProration? value
    )
    {
        value = this.Value as PriceProperties::UnitWithProration;
        return value != null;
    }

    public bool TryPickGroupedAllocation(
        [NotNullWhen(true)] out PriceProperties::GroupedAllocation? value
    )
    {
        value = this.Value as PriceProperties::GroupedAllocation;
        return value != null;
    }

    public bool TryPickBulkWithProration(
        [NotNullWhen(true)] out PriceProperties::BulkWithProration? value
    )
    {
        value = this.Value as PriceProperties::BulkWithProration;
        return value != null;
    }

    public bool TryPickGroupedWithProratedMinimum(
        [NotNullWhen(true)] out PriceProperties::GroupedWithProratedMinimum? value
    )
    {
        value = this.Value as PriceProperties::GroupedWithProratedMinimum;
        return value != null;
    }

    public bool TryPickGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out PriceProperties::GroupedWithMeteredMinimum? value
    )
    {
        value = this.Value as PriceProperties::GroupedWithMeteredMinimum;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out PriceProperties::GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as PriceProperties::GroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickMatrixWithDisplayName(
        [NotNullWhen(true)] out PriceProperties::MatrixWithDisplayName? value
    )
    {
        value = this.Value as PriceProperties::MatrixWithDisplayName;
        return value != null;
    }

    public bool TryPickGroupedTieredPackage(
        [NotNullWhen(true)] out PriceProperties::GroupedTieredPackage? value
    )
    {
        value = this.Value as PriceProperties::GroupedTieredPackage;
        return value != null;
    }

    public bool TryPickMaxGroupTieredPackage(
        [NotNullWhen(true)] out PriceProperties::MaxGroupTieredPackage? value
    )
    {
        value = this.Value as PriceProperties::MaxGroupTieredPackage;
        return value != null;
    }

    public bool TryPickScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out PriceProperties::ScalableMatrixWithUnitPricing? value
    )
    {
        value = this.Value as PriceProperties::ScalableMatrixWithUnitPricing;
        return value != null;
    }

    public bool TryPickScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out PriceProperties::ScalableMatrixWithTieredPricing? value
    )
    {
        value = this.Value as PriceProperties::ScalableMatrixWithTieredPricing;
        return value != null;
    }

    public bool TryPickCumulativeGroupedBulk(
        [NotNullWhen(true)] out PriceProperties::CumulativeGroupedBulk? value
    )
    {
        value = this.Value as PriceProperties::CumulativeGroupedBulk;
        return value != null;
    }

    public bool TryPickMinimum([NotNullWhen(true)] out PriceProperties::Minimum? value)
    {
        value = this.Value as PriceProperties::Minimum;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out PriceProperties::Percent? value)
    {
        value = this.Value as PriceProperties::Percent;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out PriceProperties::EventOutput? value)
    {
        value = this.Value as PriceProperties::EventOutput;
        return value != null;
    }

    public void Switch(
        Action<PriceProperties::Unit> unit,
        Action<PriceProperties::Tiered> tiered,
        Action<PriceProperties::Bulk> bulk,
        Action<PriceProperties::BulkWithFilters> bulkWithFilters,
        Action<PriceProperties::Package> package,
        Action<PriceProperties::Matrix> matrix,
        Action<PriceProperties::ThresholdTotalAmount> thresholdTotalAmount,
        Action<PriceProperties::TieredPackage> tieredPackage,
        Action<PriceProperties::TieredWithMinimum> tieredWithMinimum,
        Action<PriceProperties::GroupedTiered> groupedTiered,
        Action<PriceProperties::TieredPackageWithMinimum> tieredPackageWithMinimum,
        Action<PriceProperties::PackageWithAllocation> packageWithAllocation,
        Action<PriceProperties::UnitWithPercent> unitWithPercent,
        Action<PriceProperties::MatrixWithAllocation> matrixWithAllocation,
        Action<PriceProperties::TieredWithProration> tieredWithProration,
        Action<PriceProperties::UnitWithProration> unitWithProration,
        Action<PriceProperties::GroupedAllocation> groupedAllocation,
        Action<PriceProperties::BulkWithProration> bulkWithProration,
        Action<PriceProperties::GroupedWithProratedMinimum> groupedWithProratedMinimum,
        Action<PriceProperties::GroupedWithMeteredMinimum> groupedWithMeteredMinimum,
        Action<PriceProperties::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<PriceProperties::MatrixWithDisplayName> matrixWithDisplayName,
        Action<PriceProperties::GroupedTieredPackage> groupedTieredPackage,
        Action<PriceProperties::MaxGroupTieredPackage> maxGroupTieredPackage,
        Action<PriceProperties::ScalableMatrixWithUnitPricing> scalableMatrixWithUnitPricing,
        Action<PriceProperties::ScalableMatrixWithTieredPricing> scalableMatrixWithTieredPricing,
        Action<PriceProperties::CumulativeGroupedBulk> cumulativeGroupedBulk,
        Action<PriceProperties::Minimum> minimum,
        Action<PriceProperties::Percent> percent,
        Action<PriceProperties::EventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case PriceProperties::Unit value:
                unit(value);
                break;
            case PriceProperties::Tiered value:
                tiered(value);
                break;
            case PriceProperties::Bulk value:
                bulk(value);
                break;
            case PriceProperties::BulkWithFilters value:
                bulkWithFilters(value);
                break;
            case PriceProperties::Package value:
                package(value);
                break;
            case PriceProperties::Matrix value:
                matrix(value);
                break;
            case PriceProperties::ThresholdTotalAmount value:
                thresholdTotalAmount(value);
                break;
            case PriceProperties::TieredPackage value:
                tieredPackage(value);
                break;
            case PriceProperties::TieredWithMinimum value:
                tieredWithMinimum(value);
                break;
            case PriceProperties::GroupedTiered value:
                groupedTiered(value);
                break;
            case PriceProperties::TieredPackageWithMinimum value:
                tieredPackageWithMinimum(value);
                break;
            case PriceProperties::PackageWithAllocation value:
                packageWithAllocation(value);
                break;
            case PriceProperties::UnitWithPercent value:
                unitWithPercent(value);
                break;
            case PriceProperties::MatrixWithAllocation value:
                matrixWithAllocation(value);
                break;
            case PriceProperties::TieredWithProration value:
                tieredWithProration(value);
                break;
            case PriceProperties::UnitWithProration value:
                unitWithProration(value);
                break;
            case PriceProperties::GroupedAllocation value:
                groupedAllocation(value);
                break;
            case PriceProperties::BulkWithProration value:
                bulkWithProration(value);
                break;
            case PriceProperties::GroupedWithProratedMinimum value:
                groupedWithProratedMinimum(value);
                break;
            case PriceProperties::GroupedWithMeteredMinimum value:
                groupedWithMeteredMinimum(value);
                break;
            case PriceProperties::GroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case PriceProperties::MatrixWithDisplayName value:
                matrixWithDisplayName(value);
                break;
            case PriceProperties::GroupedTieredPackage value:
                groupedTieredPackage(value);
                break;
            case PriceProperties::MaxGroupTieredPackage value:
                maxGroupTieredPackage(value);
                break;
            case PriceProperties::ScalableMatrixWithUnitPricing value:
                scalableMatrixWithUnitPricing(value);
                break;
            case PriceProperties::ScalableMatrixWithTieredPricing value:
                scalableMatrixWithTieredPricing(value);
                break;
            case PriceProperties::CumulativeGroupedBulk value:
                cumulativeGroupedBulk(value);
                break;
            case PriceProperties::Minimum value:
                minimum(value);
                break;
            case PriceProperties::Percent value:
                percent(value);
                break;
            case PriceProperties::EventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    public T Match<T>(
        Func<PriceProperties::Unit, T> unit,
        Func<PriceProperties::Tiered, T> tiered,
        Func<PriceProperties::Bulk, T> bulk,
        Func<PriceProperties::BulkWithFilters, T> bulkWithFilters,
        Func<PriceProperties::Package, T> package,
        Func<PriceProperties::Matrix, T> matrix,
        Func<PriceProperties::ThresholdTotalAmount, T> thresholdTotalAmount,
        Func<PriceProperties::TieredPackage, T> tieredPackage,
        Func<PriceProperties::TieredWithMinimum, T> tieredWithMinimum,
        Func<PriceProperties::GroupedTiered, T> groupedTiered,
        Func<PriceProperties::TieredPackageWithMinimum, T> tieredPackageWithMinimum,
        Func<PriceProperties::PackageWithAllocation, T> packageWithAllocation,
        Func<PriceProperties::UnitWithPercent, T> unitWithPercent,
        Func<PriceProperties::MatrixWithAllocation, T> matrixWithAllocation,
        Func<PriceProperties::TieredWithProration, T> tieredWithProration,
        Func<PriceProperties::UnitWithProration, T> unitWithProration,
        Func<PriceProperties::GroupedAllocation, T> groupedAllocation,
        Func<PriceProperties::BulkWithProration, T> bulkWithProration,
        Func<PriceProperties::GroupedWithProratedMinimum, T> groupedWithProratedMinimum,
        Func<PriceProperties::GroupedWithMeteredMinimum, T> groupedWithMeteredMinimum,
        Func<PriceProperties::GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<PriceProperties::MatrixWithDisplayName, T> matrixWithDisplayName,
        Func<PriceProperties::GroupedTieredPackage, T> groupedTieredPackage,
        Func<PriceProperties::MaxGroupTieredPackage, T> maxGroupTieredPackage,
        Func<PriceProperties::ScalableMatrixWithUnitPricing, T> scalableMatrixWithUnitPricing,
        Func<PriceProperties::ScalableMatrixWithTieredPricing, T> scalableMatrixWithTieredPricing,
        Func<PriceProperties::CumulativeGroupedBulk, T> cumulativeGroupedBulk,
        Func<PriceProperties::Minimum, T> minimum,
        Func<PriceProperties::Percent, T> percent,
        Func<PriceProperties::EventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            PriceProperties::Unit value => unit(value),
            PriceProperties::Tiered value => tiered(value),
            PriceProperties::Bulk value => bulk(value),
            PriceProperties::BulkWithFilters value => bulkWithFilters(value),
            PriceProperties::Package value => package(value),
            PriceProperties::Matrix value => matrix(value),
            PriceProperties::ThresholdTotalAmount value => thresholdTotalAmount(value),
            PriceProperties::TieredPackage value => tieredPackage(value),
            PriceProperties::TieredWithMinimum value => tieredWithMinimum(value),
            PriceProperties::GroupedTiered value => groupedTiered(value),
            PriceProperties::TieredPackageWithMinimum value => tieredPackageWithMinimum(value),
            PriceProperties::PackageWithAllocation value => packageWithAllocation(value),
            PriceProperties::UnitWithPercent value => unitWithPercent(value),
            PriceProperties::MatrixWithAllocation value => matrixWithAllocation(value),
            PriceProperties::TieredWithProration value => tieredWithProration(value),
            PriceProperties::UnitWithProration value => unitWithProration(value),
            PriceProperties::GroupedAllocation value => groupedAllocation(value),
            PriceProperties::BulkWithProration value => bulkWithProration(value),
            PriceProperties::GroupedWithProratedMinimum value => groupedWithProratedMinimum(value),
            PriceProperties::GroupedWithMeteredMinimum value => groupedWithMeteredMinimum(value),
            PriceProperties::GroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(
                value
            ),
            PriceProperties::MatrixWithDisplayName value => matrixWithDisplayName(value),
            PriceProperties::GroupedTieredPackage value => groupedTieredPackage(value),
            PriceProperties::MaxGroupTieredPackage value => maxGroupTieredPackage(value),
            PriceProperties::ScalableMatrixWithUnitPricing value => scalableMatrixWithUnitPricing(
                value
            ),
            PriceProperties::ScalableMatrixWithTieredPricing value =>
                scalableMatrixWithTieredPricing(value),
            PriceProperties::CumulativeGroupedBulk value => cumulativeGroupedBulk(value),
            PriceProperties::Minimum value => minimum(value),
            PriceProperties::Percent value => percent(value),
            PriceProperties::EventOutput value => eventOutput(value),
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

sealed class PriceConverter : JsonConverter<Price>
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Unit>(
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
                            "Data does not match union variant 'PriceProperties::Unit'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Tiered>(
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
                            "Data does not match union variant 'PriceProperties::Tiered'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Bulk>(
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
                            "Data does not match union variant 'PriceProperties::Bulk'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::BulkWithFilters>(
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
                            "Data does not match union variant 'PriceProperties::BulkWithFilters'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Package>(
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
                            "Data does not match union variant 'PriceProperties::Package'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Matrix>(
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
                            "Data does not match union variant 'PriceProperties::Matrix'",
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
                        JsonSerializer.Deserialize<PriceProperties::ThresholdTotalAmount>(
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
                            "Data does not match union variant 'PriceProperties::ThresholdTotalAmount'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::TieredPackage>(
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
                            "Data does not match union variant 'PriceProperties::TieredPackage'",
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
                        JsonSerializer.Deserialize<PriceProperties::TieredWithMinimum>(
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
                            "Data does not match union variant 'PriceProperties::TieredWithMinimum'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::GroupedTiered>(
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
                            "Data does not match union variant 'PriceProperties::GroupedTiered'",
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
                        JsonSerializer.Deserialize<PriceProperties::TieredPackageWithMinimum>(
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
                            "Data does not match union variant 'PriceProperties::TieredPackageWithMinimum'",
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
                        JsonSerializer.Deserialize<PriceProperties::PackageWithAllocation>(
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
                            "Data does not match union variant 'PriceProperties::PackageWithAllocation'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::UnitWithPercent>(
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
                            "Data does not match union variant 'PriceProperties::UnitWithPercent'",
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
                        JsonSerializer.Deserialize<PriceProperties::MatrixWithAllocation>(
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
                            "Data does not match union variant 'PriceProperties::MatrixWithAllocation'",
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
                        JsonSerializer.Deserialize<PriceProperties::TieredWithProration>(
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
                            "Data does not match union variant 'PriceProperties::TieredWithProration'",
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
                        JsonSerializer.Deserialize<PriceProperties::UnitWithProration>(
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
                            "Data does not match union variant 'PriceProperties::UnitWithProration'",
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
                        JsonSerializer.Deserialize<PriceProperties::GroupedAllocation>(
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
                            "Data does not match union variant 'PriceProperties::GroupedAllocation'",
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
                        JsonSerializer.Deserialize<PriceProperties::BulkWithProration>(
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
                            "Data does not match union variant 'PriceProperties::BulkWithProration'",
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
                        JsonSerializer.Deserialize<PriceProperties::GroupedWithProratedMinimum>(
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
                            "Data does not match union variant 'PriceProperties::GroupedWithProratedMinimum'",
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
                        JsonSerializer.Deserialize<PriceProperties::GroupedWithMeteredMinimum>(
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
                            "Data does not match union variant 'PriceProperties::GroupedWithMeteredMinimum'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::GroupedWithMinMaxThresholds>(
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
                            "Data does not match union variant 'PriceProperties::GroupedWithMinMaxThresholds'",
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
                        JsonSerializer.Deserialize<PriceProperties::MatrixWithDisplayName>(
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
                            "Data does not match union variant 'PriceProperties::MatrixWithDisplayName'",
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
                        JsonSerializer.Deserialize<PriceProperties::GroupedTieredPackage>(
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
                            "Data does not match union variant 'PriceProperties::GroupedTieredPackage'",
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
                        JsonSerializer.Deserialize<PriceProperties::MaxGroupTieredPackage>(
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
                            "Data does not match union variant 'PriceProperties::MaxGroupTieredPackage'",
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
                        JsonSerializer.Deserialize<PriceProperties::ScalableMatrixWithUnitPricing>(
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
                            "Data does not match union variant 'PriceProperties::ScalableMatrixWithUnitPricing'",
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
                        JsonSerializer.Deserialize<PriceProperties::ScalableMatrixWithTieredPricing>(
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
                            "Data does not match union variant 'PriceProperties::ScalableMatrixWithTieredPricing'",
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
                        JsonSerializer.Deserialize<PriceProperties::CumulativeGroupedBulk>(
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
                            "Data does not match union variant 'PriceProperties::CumulativeGroupedBulk'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Minimum>(
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
                            "Data does not match union variant 'PriceProperties::Minimum'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Percent>(
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
                            "Data does not match union variant 'PriceProperties::Percent'",
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::EventOutput>(
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
                            "Data does not match union variant 'PriceProperties::EventOutput'",
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

    public override void Write(Utf8JsonWriter writer, Price value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
