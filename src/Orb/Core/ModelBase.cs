using System.Text.Json;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers.Costs;
using Orb.Models.Customers.Credits.TopUps;
using Orb.Models.Items;
using Alerts = Orb.Models.Alerts;
using Backfills = Orb.Models.Events.Backfills;
using BalanceTransactions = Orb.Models.Customers.BalanceTransactions;
using Beta = Orb.Models.Beta;
using CreditBlocks = Orb.Models.CreditBlocks;
using CreditNotes = Orb.Models.CreditNotes;
using Credits = Orb.Models.Customers.Credits;
using Customers = Orb.Models.Customers;
using ExternalPlanID = Orb.Models.Beta.ExternalPlanID;
using InvoiceLineItems = Orb.Models.InvoiceLineItems;
using Invoices = Orb.Models.Invoices;
using Ledger = Orb.Models.Customers.Credits.Ledger;
using Licenses = Orb.Models.Licenses;
using Metrics = Orb.Models.Metrics;
using Migrations = Orb.Models.Plans.Migrations;
using Plans = Orb.Models.Plans;
using Prices = Orb.Models.Prices;
using SubscriptionChanges = Orb.Models.SubscriptionChanges;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Field>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, AllocationFilterField>(),
            new ApiEnumConverter<string, AllocationFilterOperator>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, AmountDiscountFilterField>(),
            new ApiEnumConverter<string, AmountDiscountFilterOperator>(),
            new ApiEnumConverter<string, AmountDiscountIntervalDiscountType>(),
            new ApiEnumConverter<string, AmountDiscountIntervalFilterField>(),
            new ApiEnumConverter<string, AmountDiscountIntervalFilterOperator>(),
            new ApiEnumConverter<string, DurationUnit>(),
            new ApiEnumConverter<string, BillingCycleRelativeDate>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, InvoiceSource>(),
            new ApiEnumConverter<string, LineItemAdjustmentTieredPercentageDiscountFilterField>(),
            new ApiEnumConverter<
                string,
                LineItemAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<string, PaymentProvider>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, DiscountDiscountType>(),
            new ApiEnumConverter<string, MaximumAmountAdjustmentDiscountType>(),
            new ApiEnumConverter<string, Reason>(),
            new ApiEnumConverter<string, SharedCreditNoteType>(),
            new ApiEnumConverter<string, SharedCreditNoteDiscountDiscountType>(),
            new ApiEnumConverter<string, CustomExpirationDurationUnit>(),
            new ApiEnumConverter<string, Country>(),
            new ApiEnumConverter<string, CustomerTaxIDType>(),
            new ApiEnumConverter<string, TieredPercentageFilterField>(),
            new ApiEnumConverter<string, TieredPercentageFilterOperator>(),
            new ApiEnumConverter<string, InvoiceCustomerBalanceTransactionAction>(),
            new ApiEnumConverter<string, InvoiceCustomerBalanceTransactionType>(),
            new ApiEnumConverter<string, InvoiceInvoiceSource>(),
            new ApiEnumConverter<
                string,
                InvoiceLineItemAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                InvoiceLineItemAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<string, InvoicePaymentAttemptPaymentProvider>(),
            new ApiEnumConverter<string, InvoiceStatus>(),
            new ApiEnumConverter<string, InvoiceLevelDiscountTieredPercentageFilterField>(),
            new ApiEnumConverter<string, InvoiceLevelDiscountTieredPercentageFilterOperator>(),
            new ApiEnumConverter<string, MatrixSubLineItemType>(),
            new ApiEnumConverter<string, MaximumFilterField>(),
            new ApiEnumConverter<string, MaximumFilterOperator>(),
            new ApiEnumConverter<string, MaximumIntervalFilterField>(),
            new ApiEnumConverter<string, MaximumIntervalFilterOperator>(),
            new ApiEnumConverter<string, MinimumFilterField>(),
            new ApiEnumConverter<string, MinimumFilterOperator>(),
            new ApiEnumConverter<string, MinimumIntervalFilterField>(),
            new ApiEnumConverter<string, MinimumIntervalFilterOperator>(),
            new ApiEnumConverter<string, AdjustmentType>(),
            new ApiEnumConverter<string, MonetaryAmountDiscountAdjustmentFilterField>(),
            new ApiEnumConverter<string, MonetaryAmountDiscountAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, MonetaryMaximumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, MonetaryMaximumAdjustmentFilterField>(),
            new ApiEnumConverter<string, MonetaryMaximumAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, MonetaryMinimumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, MonetaryMinimumAdjustmentFilterField>(),
            new ApiEnumConverter<string, MonetaryMinimumAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, MonetaryPercentageDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, MonetaryPercentageDiscountAdjustmentFilterField>(),
            new ApiEnumConverter<string, MonetaryPercentageDiscountAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, MonetaryUsageDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, MonetaryUsageDiscountAdjustmentFilterField>(),
            new ApiEnumConverter<string, MonetaryUsageDiscountAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, Cadence>(),
            new ApiEnumConverter<string, NewAllocationPriceFilterField>(),
            new ApiEnumConverter<string, NewAllocationPriceFilterOperator>(),
            new ApiEnumConverter<string, NewAmountDiscountAdjustmentType>(),
            new ApiEnumConverter<bool, AppliesToAll>(),
            new ApiEnumConverter<string, NewAmountDiscountFilterField>(),
            new ApiEnumConverter<string, NewAmountDiscountFilterOperator>(),
            new ApiEnumConverter<string, PriceType>(),
            new ApiEnumConverter<string, NewBillingCycleConfigurationDurationUnit>(),
            new ApiEnumConverter<string, NewFloatingBulkPriceCadence>(),
            new ApiEnumConverter<string, ModelType>(),
            new ApiEnumConverter<string, NewFloatingBulkWithProrationPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingBulkWithProrationPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingCumulativeGroupedBulkPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingCumulativeGroupedBulkPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingGroupedAllocationPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingGroupedAllocationPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingGroupedTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, NewFloatingGroupedTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, NewFloatingGroupedTieredPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingGroupedTieredPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingGroupedWithMeteredMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingGroupedWithMeteredMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingGroupedWithProratedMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingGroupedWithProratedMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingMatrixPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingMatrixPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingMatrixWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingMatrixWithAllocationPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingMatrixWithDisplayNamePriceCadence>(),
            new ApiEnumConverter<string, NewFloatingMatrixWithDisplayNamePriceModelType>(),
            new ApiEnumConverter<string, NewFloatingMaxGroupTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, NewFloatingMaxGroupTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, NewFloatingMinimumCompositePriceCadence>(),
            new ApiEnumConverter<string, NewFloatingMinimumCompositePriceModelType>(),
            new ApiEnumConverter<string, NewFloatingPackagePriceCadence>(),
            new ApiEnumConverter<string, NewFloatingPackagePriceModelType>(),
            new ApiEnumConverter<string, NewFloatingPackageWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingPackageWithAllocationPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingScalableMatrixWithTieredPricingPriceCadence>(),
            new ApiEnumConverter<
                string,
                NewFloatingScalableMatrixWithTieredPricingPriceModelType
            >(),
            new ApiEnumConverter<string, NewFloatingScalableMatrixWithUnitPricingPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingScalableMatrixWithUnitPricingPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingThresholdTotalAmountPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingThresholdTotalAmountPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, NewFloatingTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, NewFloatingTieredPackageWithMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingTieredPackageWithMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingTieredPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingTieredPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingTieredWithMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingTieredWithMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingTieredWithProrationPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingTieredWithProrationPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingUnitPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingUnitPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingUnitWithPercentPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingUnitWithPercentPriceModelType>(),
            new ApiEnumConverter<string, NewFloatingUnitWithProrationPriceCadence>(),
            new ApiEnumConverter<string, NewFloatingUnitWithProrationPriceModelType>(),
            new ApiEnumConverter<string, NewMaximumAdjustmentType>(),
            new ApiEnumConverter<bool, NewMaximumAppliesToAll>(),
            new ApiEnumConverter<string, NewMaximumFilterField>(),
            new ApiEnumConverter<string, NewMaximumFilterOperator>(),
            new ApiEnumConverter<string, NewMaximumPriceType>(),
            new ApiEnumConverter<string, NewMinimumAdjustmentType>(),
            new ApiEnumConverter<bool, NewMinimumAppliesToAll>(),
            new ApiEnumConverter<string, NewMinimumFilterField>(),
            new ApiEnumConverter<string, NewMinimumFilterOperator>(),
            new ApiEnumConverter<string, NewMinimumPriceType>(),
            new ApiEnumConverter<string, NewPercentageDiscountAdjustmentType>(),
            new ApiEnumConverter<bool, NewPercentageDiscountAppliesToAll>(),
            new ApiEnumConverter<string, NewPercentageDiscountFilterField>(),
            new ApiEnumConverter<string, NewPercentageDiscountFilterOperator>(),
            new ApiEnumConverter<string, NewPercentageDiscountPriceType>(),
            new ApiEnumConverter<string, NewPlanBulkPriceCadence>(),
            new ApiEnumConverter<string, NewPlanBulkPriceModelType>(),
            new ApiEnumConverter<string, NewPlanBulkWithProrationPriceCadence>(),
            new ApiEnumConverter<string, NewPlanBulkWithProrationPriceModelType>(),
            new ApiEnumConverter<string, NewPlanCumulativeGroupedBulkPriceCadence>(),
            new ApiEnumConverter<string, NewPlanCumulativeGroupedBulkPriceModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedAllocationPriceCadence>(),
            new ApiEnumConverter<string, NewPlanGroupedAllocationPriceModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPriceCadence>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPriceModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedWithMeteredMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewPlanGroupedWithMeteredMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedWithProratedMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewPlanGroupedWithProratedMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewPlanMatrixPriceCadence>(),
            new ApiEnumConverter<string, NewPlanMatrixPriceModelType>(),
            new ApiEnumConverter<string, NewPlanMatrixWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, NewPlanMatrixWithAllocationPriceModelType>(),
            new ApiEnumConverter<string, NewPlanMatrixWithDisplayNamePriceCadence>(),
            new ApiEnumConverter<string, NewPlanMatrixWithDisplayNamePriceModelType>(),
            new ApiEnumConverter<string, NewPlanMaxGroupTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, NewPlanMaxGroupTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, NewPlanMinimumCompositePriceCadence>(),
            new ApiEnumConverter<string, NewPlanMinimumCompositePriceModelType>(),
            new ApiEnumConverter<string, NewPlanPackagePriceCadence>(),
            new ApiEnumConverter<string, NewPlanPackagePriceModelType>(),
            new ApiEnumConverter<string, NewPlanPackageWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, NewPlanPackageWithAllocationPriceModelType>(),
            new ApiEnumConverter<string, NewPlanScalableMatrixWithTieredPricingPriceCadence>(),
            new ApiEnumConverter<string, NewPlanScalableMatrixWithTieredPricingPriceModelType>(),
            new ApiEnumConverter<string, NewPlanScalableMatrixWithUnitPricingPriceCadence>(),
            new ApiEnumConverter<string, NewPlanScalableMatrixWithUnitPricingPriceModelType>(),
            new ApiEnumConverter<string, NewPlanThresholdTotalAmountPriceCadence>(),
            new ApiEnumConverter<string, NewPlanThresholdTotalAmountPriceModelType>(),
            new ApiEnumConverter<string, NewPlanTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, NewPlanTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, NewPlanTieredPackageWithMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewPlanTieredPackageWithMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewPlanTieredPriceCadence>(),
            new ApiEnumConverter<string, NewPlanTieredPriceModelType>(),
            new ApiEnumConverter<string, NewPlanTieredWithMinimumPriceCadence>(),
            new ApiEnumConverter<string, NewPlanTieredWithMinimumPriceModelType>(),
            new ApiEnumConverter<string, NewPlanUnitPriceCadence>(),
            new ApiEnumConverter<string, NewPlanUnitPriceModelType>(),
            new ApiEnumConverter<string, NewPlanUnitWithPercentPriceCadence>(),
            new ApiEnumConverter<string, NewPlanUnitWithPercentPriceModelType>(),
            new ApiEnumConverter<string, NewPlanUnitWithProrationPriceCadence>(),
            new ApiEnumConverter<string, NewPlanUnitWithProrationPriceModelType>(),
            new ApiEnumConverter<string, NewUsageDiscountAdjustmentType>(),
            new ApiEnumConverter<bool, NewUsageDiscountAppliesToAll>(),
            new ApiEnumConverter<string, NewUsageDiscountFilterField>(),
            new ApiEnumConverter<string, NewUsageDiscountFilterOperator>(),
            new ApiEnumConverter<string, NewUsageDiscountPriceType>(),
            new ApiEnumConverter<string, OtherSubLineItemType>(),
            new ApiEnumConverter<string, PercentageDiscountDiscountType>(),
            new ApiEnumConverter<string, PercentageDiscountFilterField>(),
            new ApiEnumConverter<string, PercentageDiscountFilterOperator>(),
            new ApiEnumConverter<string, PercentageDiscountIntervalDiscountType>(),
            new ApiEnumConverter<string, PercentageDiscountIntervalFilterField>(),
            new ApiEnumConverter<string, PercentageDiscountIntervalFilterOperator>(),
            new ApiEnumConverter<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, PlanPhaseAmountDiscountAdjustmentFilterField>(),
            new ApiEnumConverter<string, PlanPhaseAmountDiscountAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, PlanPhaseMaximumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, PlanPhaseMaximumAdjustmentFilterField>(),
            new ApiEnumConverter<string, PlanPhaseMaximumAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, PlanPhaseMinimumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, PlanPhaseMinimumAdjustmentFilterField>(),
            new ApiEnumConverter<string, PlanPhaseMinimumAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, PlanPhasePercentageDiscountAdjustmentFilterField>(),
            new ApiEnumConverter<string, PlanPhasePercentageDiscountAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, PlanPhaseUsageDiscountAdjustmentFilterField>(),
            new ApiEnumConverter<string, PlanPhaseUsageDiscountAdjustmentFilterOperator>(),
            new ApiEnumConverter<string, BillingMode>(),
            new ApiEnumConverter<string, UnitCadence>(),
            new ApiEnumConverter<string, CompositePriceFilterField>(),
            new ApiEnumConverter<string, CompositePriceFilterOperator>(),
            new ApiEnumConverter<string, UnitPriceType>(),
            new ApiEnumConverter<string, TieredBillingMode>(),
            new ApiEnumConverter<string, TieredCadence>(),
            new ApiEnumConverter<string, TieredCompositePriceFilterField>(),
            new ApiEnumConverter<string, TieredCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, TieredPriceType>(),
            new ApiEnumConverter<string, BulkBillingMode>(),
            new ApiEnumConverter<string, BulkCadence>(),
            new ApiEnumConverter<string, BulkCompositePriceFilterField>(),
            new ApiEnumConverter<string, BulkCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, BulkPriceType>(),
            new ApiEnumConverter<string, BulkWithFiltersBillingMode>(),
            new ApiEnumConverter<string, BulkWithFiltersCadence>(),
            new ApiEnumConverter<string, BulkWithFiltersCompositePriceFilterField>(),
            new ApiEnumConverter<string, BulkWithFiltersCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, BulkWithFiltersPriceType>(),
            new ApiEnumConverter<string, PackageBillingMode>(),
            new ApiEnumConverter<string, PackageCadence>(),
            new ApiEnumConverter<string, PackageCompositePriceFilterField>(),
            new ApiEnumConverter<string, PackageCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, PackagePriceType>(),
            new ApiEnumConverter<string, MatrixBillingMode>(),
            new ApiEnumConverter<string, MatrixCadence>(),
            new ApiEnumConverter<string, MatrixCompositePriceFilterField>(),
            new ApiEnumConverter<string, MatrixCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, MatrixPriceType>(),
            new ApiEnumConverter<string, ThresholdTotalAmountBillingMode>(),
            new ApiEnumConverter<string, ThresholdTotalAmountCadence>(),
            new ApiEnumConverter<string, ThresholdTotalAmountCompositePriceFilterField>(),
            new ApiEnumConverter<string, ThresholdTotalAmountCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, ThresholdTotalAmountPriceType>(),
            new ApiEnumConverter<string, TieredPackageBillingMode>(),
            new ApiEnumConverter<string, TieredPackageCadence>(),
            new ApiEnumConverter<string, TieredPackageCompositePriceFilterField>(),
            new ApiEnumConverter<string, TieredPackageCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, TieredPackagePriceType>(),
            new ApiEnumConverter<string, TieredWithMinimumBillingMode>(),
            new ApiEnumConverter<string, TieredWithMinimumCadence>(),
            new ApiEnumConverter<string, TieredWithMinimumCompositePriceFilterField>(),
            new ApiEnumConverter<string, TieredWithMinimumCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, TieredWithMinimumPriceType>(),
            new ApiEnumConverter<string, GroupedTieredBillingMode>(),
            new ApiEnumConverter<string, GroupedTieredCadence>(),
            new ApiEnumConverter<string, GroupedTieredCompositePriceFilterField>(),
            new ApiEnumConverter<string, GroupedTieredCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, GroupedTieredPriceType>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumBillingMode>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumCadence>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumCompositePriceFilterField>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumPriceType>(),
            new ApiEnumConverter<string, PackageWithAllocationBillingMode>(),
            new ApiEnumConverter<string, PackageWithAllocationCadence>(),
            new ApiEnumConverter<string, PackageWithAllocationCompositePriceFilterField>(),
            new ApiEnumConverter<string, PackageWithAllocationCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, PackageWithAllocationPriceType>(),
            new ApiEnumConverter<string, UnitWithPercentBillingMode>(),
            new ApiEnumConverter<string, UnitWithPercentCadence>(),
            new ApiEnumConverter<string, UnitWithPercentCompositePriceFilterField>(),
            new ApiEnumConverter<string, UnitWithPercentCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, UnitWithPercentPriceType>(),
            new ApiEnumConverter<string, MatrixWithAllocationBillingMode>(),
            new ApiEnumConverter<string, MatrixWithAllocationCadence>(),
            new ApiEnumConverter<string, MatrixWithAllocationCompositePriceFilterField>(),
            new ApiEnumConverter<string, MatrixWithAllocationCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, MatrixWithAllocationPriceType>(),
            new ApiEnumConverter<string, MatrixWithThresholdDiscountsBillingMode>(),
            new ApiEnumConverter<string, MatrixWithThresholdDiscountsCadence>(),
            new ApiEnumConverter<string, MatrixWithThresholdDiscountsCompositePriceFilterField>(),
            new ApiEnumConverter<
                string,
                MatrixWithThresholdDiscountsCompositePriceFilterOperator
            >(),
            new ApiEnumConverter<string, MatrixWithThresholdDiscountsPriceType>(),
            new ApiEnumConverter<string, TieredWithProrationBillingMode>(),
            new ApiEnumConverter<string, TieredWithProrationCadence>(),
            new ApiEnumConverter<string, TieredWithProrationCompositePriceFilterField>(),
            new ApiEnumConverter<string, TieredWithProrationCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, TieredWithProrationPriceType>(),
            new ApiEnumConverter<string, UnitWithProrationBillingMode>(),
            new ApiEnumConverter<string, UnitWithProrationCadence>(),
            new ApiEnumConverter<string, UnitWithProrationCompositePriceFilterField>(),
            new ApiEnumConverter<string, UnitWithProrationCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, UnitWithProrationPriceType>(),
            new ApiEnumConverter<string, GroupedAllocationBillingMode>(),
            new ApiEnumConverter<string, GroupedAllocationCadence>(),
            new ApiEnumConverter<string, GroupedAllocationCompositePriceFilterField>(),
            new ApiEnumConverter<string, GroupedAllocationCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, GroupedAllocationPriceType>(),
            new ApiEnumConverter<string, BulkWithProrationBillingMode>(),
            new ApiEnumConverter<string, BulkWithProrationCadence>(),
            new ApiEnumConverter<string, BulkWithProrationCompositePriceFilterField>(),
            new ApiEnumConverter<string, BulkWithProrationCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, BulkWithProrationPriceType>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumBillingMode>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumCadence>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumCompositePriceFilterField>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumPriceType>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumBillingMode>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumCadence>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumCompositePriceFilterField>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumPriceType>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsBillingMode>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsCompositePriceFilterField>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsPriceType>(),
            new ApiEnumConverter<string, MatrixWithDisplayNameBillingMode>(),
            new ApiEnumConverter<string, MatrixWithDisplayNameCadence>(),
            new ApiEnumConverter<string, MatrixWithDisplayNameCompositePriceFilterField>(),
            new ApiEnumConverter<string, MatrixWithDisplayNameCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, MatrixWithDisplayNamePriceType>(),
            new ApiEnumConverter<string, GroupedTieredPackageBillingMode>(),
            new ApiEnumConverter<string, GroupedTieredPackageCadence>(),
            new ApiEnumConverter<string, GroupedTieredPackageCompositePriceFilterField>(),
            new ApiEnumConverter<string, GroupedTieredPackageCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, GroupedTieredPackagePriceType>(),
            new ApiEnumConverter<string, MaxGroupTieredPackageBillingMode>(),
            new ApiEnumConverter<string, MaxGroupTieredPackageCadence>(),
            new ApiEnumConverter<string, MaxGroupTieredPackageCompositePriceFilterField>(),
            new ApiEnumConverter<string, MaxGroupTieredPackageCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, MaxGroupTieredPackagePriceType>(),
            new ApiEnumConverter<string, ScalableMatrixWithUnitPricingBillingMode>(),
            new ApiEnumConverter<string, ScalableMatrixWithUnitPricingCadence>(),
            new ApiEnumConverter<string, ScalableMatrixWithUnitPricingCompositePriceFilterField>(),
            new ApiEnumConverter<
                string,
                ScalableMatrixWithUnitPricingCompositePriceFilterOperator
            >(),
            new ApiEnumConverter<string, ScalableMatrixWithUnitPricingPriceType>(),
            new ApiEnumConverter<string, ScalableMatrixWithTieredPricingBillingMode>(),
            new ApiEnumConverter<string, ScalableMatrixWithTieredPricingCadence>(),
            new ApiEnumConverter<
                string,
                ScalableMatrixWithTieredPricingCompositePriceFilterField
            >(),
            new ApiEnumConverter<
                string,
                ScalableMatrixWithTieredPricingCompositePriceFilterOperator
            >(),
            new ApiEnumConverter<string, ScalableMatrixWithTieredPricingPriceType>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkBillingMode>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkCadence>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkCompositePriceFilterField>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkPriceType>(),
            new ApiEnumConverter<string, CumulativeGroupedAllocationBillingMode>(),
            new ApiEnumConverter<string, CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, CumulativeGroupedAllocationCompositePriceFilterField>(),
            new ApiEnumConverter<string, CumulativeGroupedAllocationCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, CumulativeGroupedAllocationPriceType>(),
            new ApiEnumConverter<string, DailyCreditAllowanceBillingMode>(),
            new ApiEnumConverter<string, DailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, DailyCreditAllowanceCompositePriceFilterField>(),
            new ApiEnumConverter<string, DailyCreditAllowanceCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, DailyCreditAllowancePriceType>(),
            new ApiEnumConverter<string, MeteredAllowanceBillingMode>(),
            new ApiEnumConverter<string, MeteredAllowanceCadence>(),
            new ApiEnumConverter<string, MeteredAllowanceCompositePriceFilterField>(),
            new ApiEnumConverter<string, MeteredAllowanceCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, MeteredAllowancePriceType>(),
            new ApiEnumConverter<string, MinimumCompositeBillingMode>(),
            new ApiEnumConverter<string, MinimumCompositeCadence>(),
            new ApiEnumConverter<string, MinimumCompositeCompositePriceFilterField>(),
            new ApiEnumConverter<string, MinimumCompositeCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, MinimumCompositePriceType>(),
            new ApiEnumConverter<string, PercentBillingMode>(),
            new ApiEnumConverter<string, PercentCadence>(),
            new ApiEnumConverter<string, PercentCompositePriceFilterField>(),
            new ApiEnumConverter<string, PercentCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, PercentPriceType>(),
            new ApiEnumConverter<string, EventOutputBillingMode>(),
            new ApiEnumConverter<string, EventOutputCadence>(),
            new ApiEnumConverter<string, EventOutputCompositePriceFilterField>(),
            new ApiEnumConverter<string, EventOutputCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, EventOutputPriceType>(),
            new ApiEnumConverter<string, TierSubLineItemType>(),
            new ApiEnumConverter<string, ConversionRateType>(),
            new ApiEnumConverter<string, TrialDiscountDiscountType>(),
            new ApiEnumConverter<string, TrialDiscountFilterField>(),
            new ApiEnumConverter<string, TrialDiscountFilterOperator>(),
            new ApiEnumConverter<string, SharedUnitConversionRateConfigConversionRateType>(),
            new ApiEnumConverter<string, UsageDiscountDiscountType>(),
            new ApiEnumConverter<string, UsageDiscountFilterField>(),
            new ApiEnumConverter<string, UsageDiscountFilterOperator>(),
            new ApiEnumConverter<string, UsageDiscountIntervalDiscountType>(),
            new ApiEnumConverter<string, UsageDiscountIntervalFilterField>(),
            new ApiEnumConverter<string, UsageDiscountIntervalFilterOperator>(),
            new ApiEnumConverter<
                string,
                Beta::PlanVersionAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                Beta::PlanVersionAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<string, Beta::DurationUnit>(),
            new ApiEnumConverter<bool, Beta::AppliesToAll>(),
            new ApiEnumConverter<string, Beta::Field>(),
            new ApiEnumConverter<string, Beta::Operator>(),
            new ApiEnumConverter<string, Beta::PriceType>(),
            new ApiEnumConverter<string, Beta::Cadence>(),
            new ApiEnumConverter<string, Beta::ModelType>(),
            new ApiEnumConverter<string, Beta::BulkWithFiltersCadence>(),
            new ApiEnumConverter<string, Beta::MatrixWithThresholdDiscountsCadence>(),
            new ApiEnumConverter<string, Beta::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, Beta::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Beta::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Beta::DailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, Beta::MeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Beta::PercentCadence>(),
            new ApiEnumConverter<string, Beta::EventOutputCadence>(),
            new ApiEnumConverter<
                bool,
                Beta::ReplaceAdjustmentAdjustmentTieredPercentageDiscountAppliesToAll
            >(),
            new ApiEnumConverter<
                string,
                Beta::ReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                Beta::ReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<
                string,
                Beta::ReplaceAdjustmentAdjustmentTieredPercentageDiscountPriceType
            >(),
            new ApiEnumConverter<string, Beta::ReplacePriceLicenseAllocationPriceCadence>(),
            new ApiEnumConverter<string, Beta::ReplacePriceLicenseAllocationPriceModelType>(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<
                string,
                Beta::ReplacePricePriceMatrixWithThresholdDiscountsCadence
            >(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceTieredWithProrationCadence>(),
            new ApiEnumConverter<
                string,
                Beta::ReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Beta::ReplacePricePriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceDailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceMeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Beta::ReplacePricePricePercentCadence>(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceEventOutputCadence>(),
            new ApiEnumConverter<bool, ExternalPlanID::AppliesToAll>(),
            new ApiEnumConverter<string, ExternalPlanID::Field>(),
            new ApiEnumConverter<string, ExternalPlanID::Operator>(),
            new ApiEnumConverter<string, ExternalPlanID::PriceType>(),
            new ApiEnumConverter<string, ExternalPlanID::Cadence>(),
            new ApiEnumConverter<string, ExternalPlanID::ModelType>(),
            new ApiEnumConverter<string, ExternalPlanID::BulkWithFiltersCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::MatrixWithThresholdDiscountsCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::DailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::MeteredAllowanceCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::PercentCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::EventOutputCadence>(),
            new ApiEnumConverter<
                bool,
                ExternalPlanID::ReplaceAdjustmentAdjustmentTieredPercentageDiscountAppliesToAll
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplaceAdjustmentAdjustmentTieredPercentageDiscountPriceType
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePriceLicenseAllocationPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePriceLicenseAllocationPriceModelType
            >(),
            new ApiEnumConverter<string, ExternalPlanID::ReplacePricePriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePricePriceMatrixWithThresholdDiscountsCadence
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePricePriceTieredWithProrationCadence
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePricePriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePricePriceDailyCreditAllowanceCadence
            >(),
            new ApiEnumConverter<
                string,
                ExternalPlanID::ReplacePricePriceMeteredAllowanceCadence
            >(),
            new ApiEnumConverter<string, ExternalPlanID::ReplacePricePricePercentCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::ReplacePricePriceEventOutputCadence>(),
            new ApiEnumConverter<string, CreditNotes::Reason>(),
            new ApiEnumConverter<string, Customers::AccountingProviderConfigProviderType>(),
            new ApiEnumConverter<string, Customers::CustomerPaymentProvider>(),
            new ApiEnumConverter<string, Customers::AccountingProviderProviderType>(),
            new ApiEnumConverter<string, Customers::PaymentMethodType>(),
            new ApiEnumConverter<
                string,
                Customers::CustomerPaymentConfigurationPaymentProviderProviderType
            >(),
            new ApiEnumConverter<string, Customers::TaxProvider>(),
            new ApiEnumConverter<string, Customers::NewSphereConfigurationTaxProvider>(),
            new ApiEnumConverter<string, Customers::NewTaxJarConfigurationTaxProvider>(),
            new ApiEnumConverter<string, Customers::ProviderType>(),
            new ApiEnumConverter<string, Customers::CustomerCreateParamsPaymentProvider>(),
            new ApiEnumConverter<
                string,
                Customers::CustomerUpdateParamsPaymentConfigurationPaymentProviderProviderType
            >(),
            new ApiEnumConverter<string, Customers::CustomerUpdateParamsPaymentProvider>(),
            new ApiEnumConverter<
                string,
                Customers::CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType
            >(),
            new ApiEnumConverter<
                string,
                Customers::CustomerUpdateByExternalIDParamsPaymentProvider
            >(),
            new ApiEnumConverter<string, ViewMode>(),
            new ApiEnumConverter<string, CostListByExternalIDParamsViewMode>(),
            new ApiEnumConverter<string, Credits::CreditBlockSource>(),
            new ApiEnumConverter<string, Credits::Field>(),
            new ApiEnumConverter<string, Credits::Operator>(),
            new ApiEnumConverter<string, Credits::Status>(),
            new ApiEnumConverter<string, Credits::CreditAllocationFilterField>(),
            new ApiEnumConverter<string, Credits::CreditAllocationFilterOperator>(),
            new ApiEnumConverter<
                string,
                Credits::CreditListByExternalIDResponseCreditBlockSource
            >(),
            new ApiEnumConverter<string, Credits::CreditListByExternalIDResponseFilterField>(),
            new ApiEnumConverter<string, Credits::CreditListByExternalIDResponseFilterOperator>(),
            new ApiEnumConverter<string, Credits::CreditListByExternalIDResponseStatus>(),
            new ApiEnumConverter<
                string,
                Credits::CreditListByExternalIDResponseCreditAllocationFilterField
            >(),
            new ApiEnumConverter<
                string,
                Credits::CreditListByExternalIDResponseCreditAllocationFilterOperator
            >(),
            new ApiEnumConverter<string, Ledger::AffectedBlockFilterField>(),
            new ApiEnumConverter<string, Ledger::AffectedBlockFilterOperator>(),
            new ApiEnumConverter<string, Ledger::AmendmentLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, Ledger::AmendmentLedgerEntryEntryType>(),
            new ApiEnumConverter<string, Ledger::CreditBlockExpiryLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, Ledger::CreditBlockExpiryLedgerEntryEntryType>(),
            new ApiEnumConverter<string, Ledger::DecrementLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, Ledger::DecrementLedgerEntryEntryType>(),
            new ApiEnumConverter<string, Ledger::ExpirationChangeLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, Ledger::ExpirationChangeLedgerEntryEntryType>(),
            new ApiEnumConverter<string, Ledger::IncrementLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, Ledger::IncrementLedgerEntryEntryType>(),
            new ApiEnumConverter<string, Ledger::VoidInitiatedLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, Ledger::VoidInitiatedLedgerEntryEntryType>(),
            new ApiEnumConverter<string, Ledger::VoidLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, Ledger::VoidLedgerEntryEntryType>(),
            new ApiEnumConverter<string, Ledger::EntryStatus>(),
            new ApiEnumConverter<string, Ledger::EntryType>(),
            new ApiEnumConverter<string, Ledger::Field>(),
            new ApiEnumConverter<string, Ledger::Operator>(),
            new ApiEnumConverter<string, Ledger::VoidReason>(),
            new ApiEnumConverter<
                string,
                Ledger::LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField
            >(),
            new ApiEnumConverter<
                string,
                Ledger::LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator
            >(),
            new ApiEnumConverter<
                string,
                Ledger::LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason
            >(),
            new ApiEnumConverter<string, Ledger::LedgerListByExternalIDParamsEntryStatus>(),
            new ApiEnumConverter<string, Ledger::LedgerListByExternalIDParamsEntryType>(),
            new ApiEnumConverter<string, TopUpCreateResponseExpiresAfterUnit>(),
            new ApiEnumConverter<string, TopUpListResponseExpiresAfterUnit>(),
            new ApiEnumConverter<string, TopUpCreateByExternalIDResponseExpiresAfterUnit>(),
            new ApiEnumConverter<string, TopUpListByExternalIDResponseExpiresAfterUnit>(),
            new ApiEnumConverter<string, ExpiresAfterUnit>(),
            new ApiEnumConverter<string, TopUpCreateByExternalIDParamsExpiresAfterUnit>(),
            new ApiEnumConverter<string, BalanceTransactions::Action>(),
            new ApiEnumConverter<
                string,
                BalanceTransactions::BalanceTransactionCreateResponseType
            >(),
            new ApiEnumConverter<
                string,
                BalanceTransactions::BalanceTransactionListResponseAction
            >(),
            new ApiEnumConverter<string, BalanceTransactions::BalanceTransactionListResponseType>(),
            new ApiEnumConverter<string, BalanceTransactions::Type>(),
            new ApiEnumConverter<string, Backfills::Status>(),
            new ApiEnumConverter<string, Backfills::BackfillListResponseStatus>(),
            new ApiEnumConverter<string, Backfills::BackfillCloseResponseStatus>(),
            new ApiEnumConverter<string, Backfills::BackfillFetchResponseStatus>(),
            new ApiEnumConverter<string, Backfills::BackfillRevertResponseStatus>(),
            new ApiEnumConverter<string, InvoiceLineItems::Field>(),
            new ApiEnumConverter<string, InvoiceLineItems::Operator>(),
            new ApiEnumConverter<string, Invoices::Action>(),
            new ApiEnumConverter<string, Invoices::Type>(),
            new ApiEnumConverter<string, Invoices::InvoiceSource>(),
            new ApiEnumConverter<string, Invoices::Field>(),
            new ApiEnumConverter<string, Invoices::Operator>(),
            new ApiEnumConverter<string, Invoices::PaymentProvider>(),
            new ApiEnumConverter<string, Invoices::InvoiceFetchUpcomingResponseStatus>(),
            new ApiEnumConverter<
                string,
                Invoices::InvoiceIssueSummaryResponseCustomerBalanceTransactionAction
            >(),
            new ApiEnumConverter<
                string,
                Invoices::InvoiceIssueSummaryResponseCustomerBalanceTransactionType
            >(),
            new ApiEnumConverter<string, Invoices::InvoiceIssueSummaryResponseInvoiceSource>(),
            new ApiEnumConverter<
                string,
                Invoices::InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider
            >(),
            new ApiEnumConverter<string, Invoices::InvoiceIssueSummaryResponseStatus>(),
            new ApiEnumConverter<
                string,
                Invoices::InvoiceListSummaryResponseCustomerBalanceTransactionAction
            >(),
            new ApiEnumConverter<
                string,
                Invoices::InvoiceListSummaryResponseCustomerBalanceTransactionType
            >(),
            new ApiEnumConverter<string, Invoices::InvoiceListSummaryResponseInvoiceSource>(),
            new ApiEnumConverter<
                string,
                Invoices::InvoiceListSummaryResponsePaymentAttemptPaymentProvider
            >(),
            new ApiEnumConverter<string, Invoices::InvoiceListSummaryResponseStatus>(),
            new ApiEnumConverter<string, Invoices::ModelType>(),
            new ApiEnumConverter<string, Invoices::DateType>(),
            new ApiEnumConverter<string, Invoices::Status>(),
            new ApiEnumConverter<string, Invoices::InvoiceListSummaryParamsDateType>(),
            new ApiEnumConverter<string, Invoices::InvoiceListSummaryParamsStatus>(),
            new ApiEnumConverter<string, ItemExternalConnectionExternalConnectionName>(),
            new ApiEnumConverter<string, ExternalConnectionName>(),
            new ApiEnumConverter<string, Metrics::Status>(),
            new ApiEnumConverter<
                string,
                Plans::PlanAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                Plans::PlanAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<string, Plans::PlanPlanPhaseDurationUnit>(),
            new ApiEnumConverter<string, Plans::PlanStatus>(),
            new ApiEnumConverter<string, Plans::TrialPeriodUnit>(),
            new ApiEnumConverter<string, Plans::Cadence>(),
            new ApiEnumConverter<string, Plans::ModelType>(),
            new ApiEnumConverter<string, Plans::BulkWithFiltersCadence>(),
            new ApiEnumConverter<string, Plans::MatrixWithThresholdDiscountsCadence>(),
            new ApiEnumConverter<string, Plans::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, Plans::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Plans::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Plans::DailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, Plans::MeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Plans::PercentCadence>(),
            new ApiEnumConverter<string, Plans::EventOutputCadence>(),
            new ApiEnumConverter<bool, Plans::AppliesToAll>(),
            new ApiEnumConverter<string, Plans::Field>(),
            new ApiEnumConverter<string, Plans::Operator>(),
            new ApiEnumConverter<string, Plans::PriceType>(),
            new ApiEnumConverter<string, Plans::DurationUnit>(),
            new ApiEnumConverter<string, Plans::Status>(),
            new ApiEnumConverter<string, Plans::PlanListParamsStatus>(),
            new ApiEnumConverter<string, Migrations::UnionMember2>(),
            new ApiEnumConverter<string, Migrations::Status>(),
            new ApiEnumConverter<
                string,
                Migrations::MigrationListResponseEffectiveTimeUnionMember2
            >(),
            new ApiEnumConverter<string, Migrations::MigrationListResponseStatus>(),
            new ApiEnumConverter<
                string,
                Migrations::MigrationCancelResponseEffectiveTimeUnionMember2
            >(),
            new ApiEnumConverter<string, Migrations::MigrationCancelResponseStatus>(),
            new ApiEnumConverter<string, Prices::Cadence>(),
            new ApiEnumConverter<string, Prices::MatrixWithThresholdDiscountsCadence>(),
            new ApiEnumConverter<string, Prices::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Prices::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Prices::DailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, Prices::MeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Prices::PercentCadence>(),
            new ApiEnumConverter<string, Prices::EventOutputCadence>(),
            new ApiEnumConverter<string, Prices::PriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<string, Prices::PriceMatrixWithThresholdDiscountsCadence>(),
            new ApiEnumConverter<string, Prices::PriceGroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Prices::PriceCumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Prices::PriceDailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, Prices::PriceMeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Prices::PricePercentCadence>(),
            new ApiEnumConverter<string, Prices::PriceEventOutputCadence>(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceMatrixWithThresholdDiscountsCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceDailyCreditAllowanceCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceMeteredAllowanceCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::DiscountType>(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionBulkPriceCadence>(),
            new ApiEnumConverter<string, Subscriptions::ModelType>(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionBulkWithProrationPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionBulkWithProrationPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedAllocationPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedAllocationPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedTieredPackagePriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedTieredPackagePriceModelType
            >(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionGroupedTieredPriceCadence>(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedTieredPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceModelType
            >(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionMatrixPriceCadence>(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionMatrixPriceModelType>(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMatrixWithAllocationPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMatrixWithAllocationPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMinimumCompositePriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionMinimumCompositePriceModelType
            >(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionPackagePriceCadence>(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionPackagePriceModelType>(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionPackageWithAllocationPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionPackageWithAllocationPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionThresholdTotalAmountPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionThresholdTotalAmountPriceModelType
            >(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence>(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionTieredPackagePriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceModelType
            >(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionTieredPriceCadence>(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionTieredPriceModelType>(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionTieredWithMinimumPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionTieredWithMinimumPriceModelType
            >(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionUnitPriceCadence>(),
            new ApiEnumConverter<string, Subscriptions::NewSubscriptionUnitPriceModelType>(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionUnitWithPercentPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionUnitWithPercentPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionUnitWithProrationPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::NewSubscriptionUnitWithProrationPriceModelType
            >(),
            new ApiEnumConverter<string, Subscriptions::TieredPercentageFilterField>(),
            new ApiEnumConverter<string, Subscriptions::TieredPercentageFilterOperator>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::DataViewMode>(),
            new ApiEnumConverter<string, Subscriptions::GroupedSubscriptionUsageDataViewMode>(),
            new ApiEnumConverter<bool, Subscriptions::AppliesToAll>(),
            new ApiEnumConverter<string, Subscriptions::Field>(),
            new ApiEnumConverter<string, Subscriptions::Operator>(),
            new ApiEnumConverter<string, Subscriptions::PriceType>(),
            new ApiEnumConverter<string, Subscriptions::Cadence>(),
            new ApiEnumConverter<string, Subscriptions::MatrixWithThresholdDiscountsCadence>(),
            new ApiEnumConverter<string, Subscriptions::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, Subscriptions::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Subscriptions::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Subscriptions::DailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, Subscriptions::MeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Subscriptions::PercentCadence>(),
            new ApiEnumConverter<string, Subscriptions::EventOutputCadence>(),
            new ApiEnumConverter<string, Subscriptions::ExternalMarketplace>(),
            new ApiEnumConverter<
                bool,
                Subscriptions::ReplaceAdjustmentAdjustmentTieredPercentageDiscountAppliesToAll
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplaceAdjustmentAdjustmentTieredPercentageDiscountPriceType
            >(),
            new ApiEnumConverter<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePricePriceMatrixWithThresholdDiscountsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePricePriceTieredWithProrationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePricePriceDailyCreditAllowanceCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::ReplacePricePriceMeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Subscriptions::ReplacePricePricePercentCadence>(),
            new ApiEnumConverter<string, Subscriptions::ReplacePricePriceEventOutputCadence>(),
            new ApiEnumConverter<string, Subscriptions::Status>(),
            new ApiEnumConverter<string, Subscriptions::CancelOption>(),
            new ApiEnumConverter<string, Subscriptions::ViewMode>(),
            new ApiEnumConverter<string, Subscriptions::Granularity>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionFetchUsageParamsViewMode>(),
            new ApiEnumConverter<string, Subscriptions::PriceModelBulkWithFiltersCadence>(),
            new ApiEnumConverter<
                string,
                Subscriptions::PriceModelMatrixWithThresholdDiscountsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::PriceModelCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::PriceModelDailyCreditAllowanceCadence>(),
            new ApiEnumConverter<string, Subscriptions::PriceModelMeteredAllowanceCadence>(),
            new ApiEnumConverter<string, Subscriptions::PriceModelPercentCadence>(),
            new ApiEnumConverter<string, Subscriptions::PriceModelEventOutputCadence>(),
            new ApiEnumConverter<
                bool,
                Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustmentTieredPercentageDiscountAppliesToAll
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustmentTieredPercentageDiscountPriceType
            >(),
            new ApiEnumConverter<string, Subscriptions::ChangeOption>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption
            >(),
            new ApiEnumConverter<
                bool,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustmentTieredPercentageDiscountAppliesToAll
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustmentTieredPercentageDiscountPriceType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMatrixWithThresholdDiscountsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceDailyCreditAllowanceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMeteredAllowanceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::BillingCycleAlignment>(),
            new ApiEnumConverter<
                bool,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustmentTieredPercentageDiscountAppliesToAll
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterField
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustmentTieredPercentageDiscountFilterOperator
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustmentTieredPercentageDiscountPriceType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMatrixWithThresholdDiscountsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceDailyCreditAllowanceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMeteredAllowanceCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionUpdateFixedFeeQuantityParamsChangeOption
            >(),
            new ApiEnumConverter<string, Subscriptions::UnionMember1>(),
            new ApiEnumConverter<string, Alerts::AlertType>(),
            new ApiEnumConverter<string, Alerts::AlertPriceFilterField>(),
            new ApiEnumConverter<string, Alerts::AlertPriceFilterOperator>(),
            new ApiEnumConverter<string, Alerts::Field>(),
            new ApiEnumConverter<string, Alerts::Operator>(),
            new ApiEnumConverter<string, Alerts::Type>(),
            new ApiEnumConverter<string, Alerts::AlertCreateForExternalCustomerParamsType>(),
            new ApiEnumConverter<string, Alerts::AlertCreateForSubscriptionParamsType>(),
            new ApiEnumConverter<
                string,
                Alerts::AlertCreateForSubscriptionParamsPriceFilterField
            >(),
            new ApiEnumConverter<
                string,
                Alerts::AlertCreateForSubscriptionParamsPriceFilterOperator
            >(),
            new ApiEnumConverter<string, SubscriptionChanges::Field>(),
            new ApiEnumConverter<string, SubscriptionChanges::Operator>(),
            new ApiEnumConverter<string, SubscriptionChanges::MutatedSubscriptionStatus>(),
            new ApiEnumConverter<
                string,
                SubscriptionChanges::SubscriptionChangeRetrieveResponseStatus
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionChanges::SubscriptionChangeListResponseStatus
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionChanges::SubscriptionChangeApplyResponseStatus
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionChanges::SubscriptionChangeCancelResponseStatus
            >(),
            new ApiEnumConverter<string, SubscriptionChanges::Status>(),
            new ApiEnumConverter<string, CreditBlocks::CreditBlockSource>(),
            new ApiEnumConverter<string, CreditBlocks::Field>(),
            new ApiEnumConverter<string, CreditBlocks::Operator>(),
            new ApiEnumConverter<string, CreditBlocks::Status>(),
            new ApiEnumConverter<string, CreditBlocks::CreditAllocationFilterField>(),
            new ApiEnumConverter<string, CreditBlocks::CreditAllocationFilterOperator>(),
            new ApiEnumConverter<string, CreditBlocks::BlockCreditBlockSource>(),
            new ApiEnumConverter<string, CreditBlocks::BlockFilterField>(),
            new ApiEnumConverter<string, CreditBlocks::BlockFilterOperator>(),
            new ApiEnumConverter<string, CreditBlocks::BlockStatus>(),
            new ApiEnumConverter<string, CreditBlocks::BlockCreditAllocationFilterField>(),
            new ApiEnumConverter<string, CreditBlocks::BlockCreditAllocationFilterOperator>(),
            new ApiEnumConverter<string, CreditBlocks::InvoiceStatus>(),
            new ApiEnumConverter<string, Licenses::LicenseCreateResponseStatus>(),
            new ApiEnumConverter<string, Licenses::LicenseRetrieveResponseStatus>(),
            new ApiEnumConverter<string, Licenses::LicenseListResponseStatus>(),
            new ApiEnumConverter<string, Licenses::LicenseDeactivateResponseStatus>(),
            new ApiEnumConverter<string, Licenses::LicenseRetrieveByExternalIDResponseStatus>(),
            new ApiEnumConverter<string, Licenses::Status>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
