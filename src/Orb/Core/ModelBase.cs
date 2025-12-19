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
using CreditNotes = Orb.Models.CreditNotes;
using Credits = Orb.Models.Customers.Credits;
using Customers = Orb.Models.Customers;
using ExternalPlanID = Orb.Models.Beta.ExternalPlanID;
using Invoices = Orb.Models.Invoices;
using Ledger = Orb.Models.Customers.Credits.Ledger;
using Metrics = Orb.Models.Metrics;
using Plans = Orb.Models.Plans;
using Prices = Orb.Models.Prices;
using SubscriptionChanges = Orb.Models.SubscriptionChanges;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
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
            new ApiEnumConverter<string, Field>(),
            new ApiEnumConverter<string, Operator>(),
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
            new ApiEnumConverter<string, InvoiceCustomerBalanceTransactionAction>(),
            new ApiEnumConverter<string, InvoiceCustomerBalanceTransactionType>(),
            new ApiEnumConverter<string, InvoiceInvoiceSource>(),
            new ApiEnumConverter<string, InvoicePaymentAttemptPaymentProvider>(),
            new ApiEnumConverter<string, InvoiceStatus>(),
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
            new ApiEnumConverter<string, PriceMinimumBillingMode>(),
            new ApiEnumConverter<string, PriceMinimumCadence>(),
            new ApiEnumConverter<string, PriceMinimumCompositePriceFilterField>(),
            new ApiEnumConverter<string, PriceMinimumCompositePriceFilterOperator>(),
            new ApiEnumConverter<string, PriceMinimumPriceType>(),
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
            new ApiEnumConverter<string, Beta::DurationUnit>(),
            new ApiEnumConverter<string, Beta::Cadence>(),
            new ApiEnumConverter<string, Beta::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, Beta::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Beta::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Beta::PercentCadence>(),
            new ApiEnumConverter<string, Beta::EventOutputCadence>(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceTieredWithProrationCadence>(),
            new ApiEnumConverter<
                string,
                Beta::ReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Beta::ReplacePricePriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<string, Beta::ReplacePricePricePercentCadence>(),
            new ApiEnumConverter<string, Beta::ReplacePricePriceEventOutputCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::Cadence>(),
            new ApiEnumConverter<string, ExternalPlanID::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::PercentCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::EventOutputCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::ReplacePricePriceBulkWithFiltersCadence>(),
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
            new ApiEnumConverter<string, ExternalPlanID::ReplacePricePricePercentCadence>(),
            new ApiEnumConverter<string, ExternalPlanID::ReplacePricePriceEventOutputCadence>(),
            new ApiEnumConverter<string, CreditNotes::Reason>(),
            new ApiEnumConverter<string, Customers::CustomerPaymentProvider>(),
            new ApiEnumConverter<string, Customers::AccountingProviderProviderType>(),
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
            new ApiEnumConverter<string, Credits::Field>(),
            new ApiEnumConverter<string, Credits::Operator>(),
            new ApiEnumConverter<string, Credits::Status>(),
            new ApiEnumConverter<string, Credits::CreditListByExternalIDResponseFilterField>(),
            new ApiEnumConverter<string, Credits::CreditListByExternalIDResponseFilterOperator>(),
            new ApiEnumConverter<string, Credits::CreditListByExternalIDResponseStatus>(),
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
            new ApiEnumConverter<string, Invoices::Action>(),
            new ApiEnumConverter<string, Invoices::Type>(),
            new ApiEnumConverter<string, Invoices::InvoiceSource>(),
            new ApiEnumConverter<string, Invoices::PaymentProvider>(),
            new ApiEnumConverter<string, Invoices::InvoiceFetchUpcomingResponseStatus>(),
            new ApiEnumConverter<string, Invoices::ModelType>(),
            new ApiEnumConverter<string, Invoices::DateType>(),
            new ApiEnumConverter<string, Invoices::Status>(),
            new ApiEnumConverter<string, ItemExternalConnectionExternalConnectionName>(),
            new ApiEnumConverter<string, ExternalConnectionName>(),
            new ApiEnumConverter<string, Metrics::Status>(),
            new ApiEnumConverter<string, Plans::PlanPlanPhaseDurationUnit>(),
            new ApiEnumConverter<string, Plans::PlanStatus>(),
            new ApiEnumConverter<string, Plans::TrialPeriodUnit>(),
            new ApiEnumConverter<string, Plans::Cadence>(),
            new ApiEnumConverter<string, Plans::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, Plans::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Plans::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Plans::PercentCadence>(),
            new ApiEnumConverter<string, Plans::EventOutputCadence>(),
            new ApiEnumConverter<string, Plans::DurationUnit>(),
            new ApiEnumConverter<string, Plans::Status>(),
            new ApiEnumConverter<string, Plans::PlanListParamsStatus>(),
            new ApiEnumConverter<string, Prices::Cadence>(),
            new ApiEnumConverter<string, Prices::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Prices::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Prices::PercentCadence>(),
            new ApiEnumConverter<string, Prices::EventOutputCadence>(),
            new ApiEnumConverter<string, Prices::PriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<string, Prices::PriceGroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Prices::PriceCumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Prices::PricePercentCadence>(),
            new ApiEnumConverter<string, Prices::PriceEventOutputCadence>(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
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
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::DataViewMode>(),
            new ApiEnumConverter<string, Subscriptions::GroupedSubscriptionUsageDataViewMode>(),
            new ApiEnumConverter<string, Subscriptions::Cadence>(),
            new ApiEnumConverter<string, Subscriptions::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, Subscriptions::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Subscriptions::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Subscriptions::PercentCadence>(),
            new ApiEnumConverter<string, Subscriptions::EventOutputCadence>(),
            new ApiEnumConverter<string, Subscriptions::ExternalMarketplace>(),
            new ApiEnumConverter<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence>(),
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
                Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::PriceModelCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::PriceModelPercentCadence>(),
            new ApiEnumConverter<string, Subscriptions::PriceModelEventOutputCadence>(),
            new ApiEnumConverter<string, Subscriptions::ChangeOption>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
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
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::BillingCycleAlignment>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
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
            new ApiEnumConverter<string, Alerts::Type>(),
            new ApiEnumConverter<string, Alerts::AlertCreateForExternalCustomerParamsType>(),
            new ApiEnumConverter<string, Alerts::AlertCreateForSubscriptionParamsType>(),
            new ApiEnumConverter<string, SubscriptionChanges::Status>(),
            new ApiEnumConverter<
                string,
                SubscriptionChanges::SubscriptionChangeRetrieveResponseStatus
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionChanges::SubscriptionChangeApplyResponseStatus
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionChanges::SubscriptionChangeCancelResponseStatus
            >(),
        },
    };

    private protected static readonly JsonSerializerOptions ToStringSerializerOptions = new(
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
