using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;
using Orb.Models.AmountDiscountProperties;
using Orb.Models.BillingCycleConfigurationProperties;
using Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties.CustomerBalanceTransactionProperties;
using Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties.PaymentAttemptProperties;
using Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;
using Orb.Models.Customers.Costs.CostListParamsProperties;
using Orb.Models.Customers.Credits.CreditListPageResponseProperties.DataProperties;
using Orb.Models.Customers.Credits.Ledger.AmendmentLedgerEntryProperties;
using Orb.Models.Customers.Credits.TopUps.TopUpCreateResponseProperties;
using Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties.AccountingProviderProperties;
using Orb.Models.Customers.NewAvalaraTaxConfigurationProperties;
using Orb.Models.Invoices.InvoiceCreateParamsProperties.LineItemProperties;
using Orb.Models.Items.ItemProperties.ExternalConnectionProperties;
using Orb.Models.MonetaryAmountDiscountAdjustmentProperties;
using Orb.Models.NewAllocationPriceProperties;
using Orb.Models.Plans.PlanProperties.TrialConfigProperties;
using Orb.Models.Subscriptions.SubscriptionCancelParamsProperties;
using Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;
using Orb.Models.Subscriptions.SubscriptionRedeemCouponParamsProperties;
using Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;
using Orb.Models.TieredConversionRateConfigProperties;
using Orb.Models.TransformPriceFilterProperties;
using AlertCreateForCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForCustomerParamsProperties;
using AlertCreateForExternalCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForExternalCustomerParamsProperties;
using AlertCreateForSubscriptionParamsProperties = Orb.Models.Alerts.AlertCreateForSubscriptionParamsProperties;
using AlertProperties = Orb.Models.Alerts.AlertProperties;
using AmountDiscountIntervalProperties = Orb.Models.AmountDiscountIntervalProperties;
using BackfillCloseResponseProperties = Orb.Models.Events.Backfills.BackfillCloseResponseProperties;
using BackfillCreateResponseProperties = Orb.Models.Events.Backfills.BackfillCreateResponseProperties;
using BackfillFetchResponseProperties = Orb.Models.Events.Backfills.BackfillFetchResponseProperties;
using BackfillRevertResponseProperties = Orb.Models.Events.Backfills.BackfillRevertResponseProperties;
using BalanceTransactionCreateParamsProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionCreateParamsProperties;
using BalanceTransactionCreateResponseProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionCreateResponseProperties;
using BillableMetricProperties = Orb.Models.Metrics.BillableMetricProperties;
using BulkProperties = Orb.Models.PriceProperties.BulkProperties;
using BulkWithProrationProperties = Orb.Models.PriceProperties.BulkWithProrationProperties;
using CostListByExternalIDParamsProperties = Orb.Models.Customers.Costs.CostListByExternalIDParamsProperties;
using CreatedInvoiceProperties = Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties;
using CreditBlockExpiryLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.CreditBlockExpiryLedgerEntryProperties;
using CreditNoteProperties = Orb.Models.CreditNoteProperties;
using CumulativeGroupedBulkProperties = Orb.Models.PriceProperties.CumulativeGroupedBulkProperties;
using CustomerBalanceTransactionProperties = Orb.Models.InvoiceProperties.CustomerBalanceTransactionProperties;
using CustomerCreateParamsProperties = Orb.Models.Customers.CustomerCreateParamsProperties;
using CustomerProperties = Orb.Models.Customers.CustomerProperties;
using CustomerTaxIDProperties = Orb.Models.CustomerTaxIDProperties;
using CustomerUpdateByExternalIDParamsProperties = Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties;
using CustomerUpdateParamsProperties = Orb.Models.Customers.CustomerUpdateParamsProperties;
using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using DataProperties = Orb.Models.Customers.Credits.CreditListByExternalIDPageResponseProperties.DataProperties;
using DecrementLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.DecrementLedgerEntryProperties;
using DiscountOverrideProperties = Orb.Models.Subscriptions.DiscountOverrideProperties;
using DiscountProperties = Orb.Models.CreditNoteProperties.LineItemProperties.DiscountProperties;
using EventOutputProperties = Orb.Models.PriceProperties.EventOutputProperties;
using ExpirationChangeLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.ExpirationChangeLedgerEntryProperties;
using ExternalConnectionProperties = Orb.Models.Items.ItemUpdateParamsProperties.ExternalConnectionProperties;
using GroupedAllocationProperties = Orb.Models.PriceProperties.GroupedAllocationProperties;
using GroupedTieredPackageProperties = Orb.Models.PriceProperties.GroupedTieredPackageProperties;
using GroupedTieredProperties = Orb.Models.PriceProperties.GroupedTieredProperties;
using GroupedWithMeteredMinimumProperties = Orb.Models.PriceProperties.GroupedWithMeteredMinimumProperties;
using GroupedWithMinMaxThresholdsProperties = Orb.Models.PriceProperties.GroupedWithMinMaxThresholdsProperties;
using GroupedWithProratedMinimumProperties = Orb.Models.PriceProperties.GroupedWithProratedMinimumProperties;
using IncrementLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.IncrementLedgerEntryProperties;
using InvoiceFetchUpcomingResponseProperties = Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties;
using InvoiceListParamsProperties = Orb.Models.Invoices.InvoiceListParamsProperties;
using InvoiceProperties = Orb.Models.InvoiceProperties;
using LedgerListByExternalIDParamsProperties = Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDParamsProperties;
using LedgerListParamsProperties = Orb.Models.Customers.Credits.Ledger.LedgerListParamsProperties;
using MatrixProperties = Orb.Models.PriceProperties.MatrixProperties;
using MatrixSubLineItemProperties = Orb.Models.MatrixSubLineItemProperties;
using MatrixWithAllocationProperties = Orb.Models.PriceProperties.MatrixWithAllocationProperties;
using MatrixWithDisplayNameProperties = Orb.Models.PriceProperties.MatrixWithDisplayNameProperties;
using MaxGroupTieredPackageProperties = Orb.Models.PriceProperties.MaxGroupTieredPackageProperties;
using MaximumAmountAdjustmentProperties = Orb.Models.CreditNoteProperties.MaximumAmountAdjustmentProperties;
using MinimumProperties = Orb.Models.PriceProperties.MinimumProperties;
using MonetaryMaximumAdjustmentProperties = Orb.Models.MonetaryMaximumAdjustmentProperties;
using MonetaryMinimumAdjustmentProperties = Orb.Models.MonetaryMinimumAdjustmentProperties;
using MonetaryPercentageDiscountAdjustmentProperties = Orb.Models.MonetaryPercentageDiscountAdjustmentProperties;
using MonetaryUsageDiscountAdjustmentProperties = Orb.Models.MonetaryUsageDiscountAdjustmentProperties;
using MutatedSubscriptionProperties = Orb.Models.SubscriptionChanges.MutatedSubscriptionProperties;
using NewAmountDiscountProperties = Orb.Models.NewAmountDiscountProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewFloatingBulkPriceProperties = Orb.Models.NewFloatingBulkPriceProperties;
using NewFloatingBulkWithProrationPriceProperties = Orb.Models.NewFloatingBulkWithProrationPriceProperties;
using NewFloatingCumulativeGroupedBulkPriceProperties = Orb.Models.NewFloatingCumulativeGroupedBulkPriceProperties;
using NewFloatingGroupedAllocationPriceProperties = Orb.Models.NewFloatingGroupedAllocationPriceProperties;
using NewFloatingGroupedTieredPackagePriceProperties = Orb.Models.NewFloatingGroupedTieredPackagePriceProperties;
using NewFloatingGroupedTieredPriceProperties = Orb.Models.NewFloatingGroupedTieredPriceProperties;
using NewFloatingGroupedWithMeteredMinimumPriceProperties = Orb.Models.NewFloatingGroupedWithMeteredMinimumPriceProperties;
using NewFloatingGroupedWithProratedMinimumPriceProperties = Orb.Models.NewFloatingGroupedWithProratedMinimumPriceProperties;
using NewFloatingMatrixPriceProperties = Orb.Models.NewFloatingMatrixPriceProperties;
using NewFloatingMatrixWithAllocationPriceProperties = Orb.Models.NewFloatingMatrixWithAllocationPriceProperties;
using NewFloatingMatrixWithDisplayNamePriceProperties = Orb.Models.NewFloatingMatrixWithDisplayNamePriceProperties;
using NewFloatingMaxGroupTieredPackagePriceProperties = Orb.Models.NewFloatingMaxGroupTieredPackagePriceProperties;
using NewFloatingMinimumCompositePriceProperties = Orb.Models.NewFloatingMinimumCompositePriceProperties;
using NewFloatingPackagePriceProperties = Orb.Models.NewFloatingPackagePriceProperties;
using NewFloatingPackageWithAllocationPriceProperties = Orb.Models.NewFloatingPackageWithAllocationPriceProperties;
using NewFloatingScalableMatrixWithTieredPricingPriceProperties = Orb.Models.NewFloatingScalableMatrixWithTieredPricingPriceProperties;
using NewFloatingScalableMatrixWithUnitPricingPriceProperties = Orb.Models.NewFloatingScalableMatrixWithUnitPricingPriceProperties;
using NewFloatingThresholdTotalAmountPriceProperties = Orb.Models.NewFloatingThresholdTotalAmountPriceProperties;
using NewFloatingTieredPackagePriceProperties = Orb.Models.NewFloatingTieredPackagePriceProperties;
using NewFloatingTieredPackageWithMinimumPriceProperties = Orb.Models.NewFloatingTieredPackageWithMinimumPriceProperties;
using NewFloatingTieredPriceProperties = Orb.Models.NewFloatingTieredPriceProperties;
using NewFloatingTieredWithMinimumPriceProperties = Orb.Models.NewFloatingTieredWithMinimumPriceProperties;
using NewFloatingTieredWithProrationPriceProperties = Orb.Models.NewFloatingTieredWithProrationPriceProperties;
using NewFloatingUnitPriceProperties = Orb.Models.NewFloatingUnitPriceProperties;
using NewFloatingUnitWithPercentPriceProperties = Orb.Models.NewFloatingUnitWithPercentPriceProperties;
using NewFloatingUnitWithProrationPriceProperties = Orb.Models.NewFloatingUnitWithProrationPriceProperties;
using NewMaximumProperties = Orb.Models.NewMaximumProperties;
using NewMinimumProperties = Orb.Models.NewMinimumProperties;
using NewPercentageDiscountProperties = Orb.Models.NewPercentageDiscountProperties;
using NewPlanBulkPriceProperties = Orb.Models.NewPlanBulkPriceProperties;
using NewPlanBulkWithProrationPriceProperties = Orb.Models.NewPlanBulkWithProrationPriceProperties;
using NewPlanCumulativeGroupedBulkPriceProperties = Orb.Models.NewPlanCumulativeGroupedBulkPriceProperties;
using NewPlanGroupedAllocationPriceProperties = Orb.Models.NewPlanGroupedAllocationPriceProperties;
using NewPlanGroupedTieredPackagePriceProperties = Orb.Models.NewPlanGroupedTieredPackagePriceProperties;
using NewPlanGroupedTieredPriceProperties = Orb.Models.NewPlanGroupedTieredPriceProperties;
using NewPlanGroupedWithMeteredMinimumPriceProperties = Orb.Models.NewPlanGroupedWithMeteredMinimumPriceProperties;
using NewPlanGroupedWithProratedMinimumPriceProperties = Orb.Models.NewPlanGroupedWithProratedMinimumPriceProperties;
using NewPlanMatrixPriceProperties = Orb.Models.NewPlanMatrixPriceProperties;
using NewPlanMatrixWithAllocationPriceProperties = Orb.Models.NewPlanMatrixWithAllocationPriceProperties;
using NewPlanMatrixWithDisplayNamePriceProperties = Orb.Models.NewPlanMatrixWithDisplayNamePriceProperties;
using NewPlanMaxGroupTieredPackagePriceProperties = Orb.Models.NewPlanMaxGroupTieredPackagePriceProperties;
using NewPlanMinimumCompositePriceProperties = Orb.Models.NewPlanMinimumCompositePriceProperties;
using NewPlanPackagePriceProperties = Orb.Models.NewPlanPackagePriceProperties;
using NewPlanPackageWithAllocationPriceProperties = Orb.Models.NewPlanPackageWithAllocationPriceProperties;
using NewPlanScalableMatrixWithTieredPricingPriceProperties = Orb.Models.NewPlanScalableMatrixWithTieredPricingPriceProperties;
using NewPlanScalableMatrixWithUnitPricingPriceProperties = Orb.Models.NewPlanScalableMatrixWithUnitPricingPriceProperties;
using NewPlanThresholdTotalAmountPriceProperties = Orb.Models.NewPlanThresholdTotalAmountPriceProperties;
using NewPlanTieredPackagePriceProperties = Orb.Models.NewPlanTieredPackagePriceProperties;
using NewPlanTieredPackageWithMinimumPriceProperties = Orb.Models.NewPlanTieredPackageWithMinimumPriceProperties;
using NewPlanTieredPriceProperties = Orb.Models.NewPlanTieredPriceProperties;
using NewPlanTieredWithMinimumPriceProperties = Orb.Models.NewPlanTieredWithMinimumPriceProperties;
using NewPlanUnitPriceProperties = Orb.Models.NewPlanUnitPriceProperties;
using NewPlanUnitWithPercentPriceProperties = Orb.Models.NewPlanUnitWithPercentPriceProperties;
using NewPlanUnitWithProrationPriceProperties = Orb.Models.NewPlanUnitWithProrationPriceProperties;
using NewSphereConfigurationProperties = Orb.Models.Customers.NewSphereConfigurationProperties;
using NewSubscriptionBulkPriceProperties = Orb.Models.Subscriptions.NewSubscriptionBulkPriceProperties;
using NewSubscriptionBulkWithProrationPriceProperties = Orb.Models.Subscriptions.NewSubscriptionBulkWithProrationPriceProperties;
using NewSubscriptionCumulativeGroupedBulkPriceProperties = Orb.Models.Subscriptions.NewSubscriptionCumulativeGroupedBulkPriceProperties;
using NewSubscriptionGroupedAllocationPriceProperties = Orb.Models.Subscriptions.NewSubscriptionGroupedAllocationPriceProperties;
using NewSubscriptionGroupedTieredPackagePriceProperties = Orb.Models.Subscriptions.NewSubscriptionGroupedTieredPackagePriceProperties;
using NewSubscriptionGroupedTieredPriceProperties = Orb.Models.Subscriptions.NewSubscriptionGroupedTieredPriceProperties;
using NewSubscriptionGroupedWithMeteredMinimumPriceProperties = Orb.Models.Subscriptions.NewSubscriptionGroupedWithMeteredMinimumPriceProperties;
using NewSubscriptionGroupedWithProratedMinimumPriceProperties = Orb.Models.Subscriptions.NewSubscriptionGroupedWithProratedMinimumPriceProperties;
using NewSubscriptionMatrixPriceProperties = Orb.Models.Subscriptions.NewSubscriptionMatrixPriceProperties;
using NewSubscriptionMatrixWithAllocationPriceProperties = Orb.Models.Subscriptions.NewSubscriptionMatrixWithAllocationPriceProperties;
using NewSubscriptionMatrixWithDisplayNamePriceProperties = Orb.Models.Subscriptions.NewSubscriptionMatrixWithDisplayNamePriceProperties;
using NewSubscriptionMaxGroupTieredPackagePriceProperties = Orb.Models.Subscriptions.NewSubscriptionMaxGroupTieredPackagePriceProperties;
using NewSubscriptionMinimumCompositePriceProperties = Orb.Models.Subscriptions.NewSubscriptionMinimumCompositePriceProperties;
using NewSubscriptionPackagePriceProperties = Orb.Models.Subscriptions.NewSubscriptionPackagePriceProperties;
using NewSubscriptionPackageWithAllocationPriceProperties = Orb.Models.Subscriptions.NewSubscriptionPackageWithAllocationPriceProperties;
using NewSubscriptionScalableMatrixWithTieredPricingPriceProperties = Orb.Models.Subscriptions.NewSubscriptionScalableMatrixWithTieredPricingPriceProperties;
using NewSubscriptionScalableMatrixWithUnitPricingPriceProperties = Orb.Models.Subscriptions.NewSubscriptionScalableMatrixWithUnitPricingPriceProperties;
using NewSubscriptionThresholdTotalAmountPriceProperties = Orb.Models.Subscriptions.NewSubscriptionThresholdTotalAmountPriceProperties;
using NewSubscriptionTieredPackagePriceProperties = Orb.Models.Subscriptions.NewSubscriptionTieredPackagePriceProperties;
using NewSubscriptionTieredPackageWithMinimumPriceProperties = Orb.Models.Subscriptions.NewSubscriptionTieredPackageWithMinimumPriceProperties;
using NewSubscriptionTieredPriceProperties = Orb.Models.Subscriptions.NewSubscriptionTieredPriceProperties;
using NewSubscriptionTieredWithMinimumPriceProperties = Orb.Models.Subscriptions.NewSubscriptionTieredWithMinimumPriceProperties;
using NewSubscriptionUnitPriceProperties = Orb.Models.Subscriptions.NewSubscriptionUnitPriceProperties;
using NewSubscriptionUnitWithPercentPriceProperties = Orb.Models.Subscriptions.NewSubscriptionUnitWithPercentPriceProperties;
using NewSubscriptionUnitWithProrationPriceProperties = Orb.Models.Subscriptions.NewSubscriptionUnitWithProrationPriceProperties;
using NewTaxJarConfigurationProperties = Orb.Models.Customers.NewTaxJarConfigurationProperties;
using NewUsageDiscountProperties = Orb.Models.NewUsageDiscountProperties;
using OtherSubLineItemProperties = Orb.Models.OtherSubLineItemProperties;
using PackageProperties = Orb.Models.PriceProperties.PackageProperties;
using PackageWithAllocationProperties = Orb.Models.PriceProperties.PackageWithAllocationProperties;
using PaymentAttemptProperties = Orb.Models.InvoiceProperties.PaymentAttemptProperties;
using PercentageDiscountIntervalProperties = Orb.Models.PercentageDiscountIntervalProperties;
using PercentageDiscountProperties = Orb.Models.PercentageDiscountProperties;
using PercentProperties = Orb.Models.PriceProperties.PercentProperties;
using PlanCreateParamsProperties = Orb.Models.Plans.PlanCreateParamsProperties;
using PlanListParamsProperties = Orb.Models.Plans.PlanListParamsProperties;
using PlanPhaseAmountDiscountAdjustmentProperties = Orb.Models.PlanPhaseAmountDiscountAdjustmentProperties;
using PlanPhaseMaximumAdjustmentProperties = Orb.Models.PlanPhaseMaximumAdjustmentProperties;
using PlanPhaseMinimumAdjustmentProperties = Orb.Models.PlanPhaseMinimumAdjustmentProperties;
using PlanPhasePercentageDiscountAdjustmentProperties = Orb.Models.PlanPhasePercentageDiscountAdjustmentProperties;
using PlanPhaseProperties = Orb.Models.Plans.PlanProperties.PlanPhaseProperties;
using PlanPhaseUsageDiscountAdjustmentProperties = Orb.Models.PlanPhaseUsageDiscountAdjustmentProperties;
using PlanProperties = Orb.Models.Plans.PlanProperties;
using PlanVersionPhaseProperties = Orb.Models.Beta.PlanVersionPhaseProperties;
using ScalableMatrixWithTieredPricingProperties = Orb.Models.PriceProperties.ScalableMatrixWithTieredPricingProperties;
using ScalableMatrixWithUnitPricingProperties = Orb.Models.PriceProperties.ScalableMatrixWithUnitPricingProperties;
using SubscriptionChangeApplyResponseProperties = Orb.Models.SubscriptionChanges.SubscriptionChangeApplyResponseProperties;
using SubscriptionChangeCancelResponseProperties = Orb.Models.SubscriptionChanges.SubscriptionChangeCancelResponseProperties;
using SubscriptionChangeRetrieveResponseProperties = Orb.Models.SubscriptionChanges.SubscriptionChangeRetrieveResponseProperties;
using SubscriptionFetchCostsParamsProperties = Orb.Models.Subscriptions.SubscriptionFetchCostsParamsProperties;
using SubscriptionFetchUsageParamsProperties = Orb.Models.Subscriptions.SubscriptionFetchUsageParamsProperties;
using SubscriptionListParamsProperties = Orb.Models.Subscriptions.SubscriptionListParamsProperties;
using SubscriptionProperties = Orb.Models.Subscriptions.SubscriptionProperties;
using SubscriptionSchedulePlanChangeParamsProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;
using SubscriptionUpdateFixedFeeQuantityParamsProperties = Orb.Models.Subscriptions.SubscriptionUpdateFixedFeeQuantityParamsProperties;
using ThresholdTotalAmountProperties = Orb.Models.PriceProperties.ThresholdTotalAmountProperties;
using TieredPackageProperties = Orb.Models.PriceProperties.TieredPackageProperties;
using TieredPackageWithMinimumProperties = Orb.Models.PriceProperties.TieredPackageWithMinimumProperties;
using TieredProperties = Orb.Models.PriceProperties.TieredProperties;
using TieredWithMinimumProperties = Orb.Models.PriceProperties.TieredWithMinimumProperties;
using TieredWithProrationProperties = Orb.Models.PriceProperties.TieredWithProrationProperties;
using TierSubLineItemProperties = Orb.Models.TierSubLineItemProperties;
using TopUpCreateByExternalIDParamsProperties = Orb.Models.Customers.Credits.TopUps.TopUpCreateByExternalIDParamsProperties;
using TopUpCreateByExternalIDResponseProperties = Orb.Models.Customers.Credits.TopUps.TopUpCreateByExternalIDResponseProperties;
using TopUpCreateParamsProperties = Orb.Models.Customers.Credits.TopUps.TopUpCreateParamsProperties;
using TrialDiscountProperties = Orb.Models.TrialDiscountProperties;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;
using UnitProperties = Orb.Models.PriceProperties.UnitProperties;
using UnitWithPercentProperties = Orb.Models.PriceProperties.UnitWithPercentProperties;
using UnitWithProrationProperties = Orb.Models.PriceProperties.UnitWithProrationProperties;
using UsageDiscountIntervalProperties = Orb.Models.UsageDiscountIntervalProperties;
using UsageDiscountProperties = Orb.Models.UsageDiscountProperties;
using VoidInitiatedLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.VoidInitiatedLedgerEntryProperties;
using VoidLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.VoidLedgerEntryProperties;
using VoidProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties.VoidProperties;

namespace Orb.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, AmountDiscountIntervalProperties::DiscountType>(),
            new ApiEnumConverter<string, DurationUnit>(),
            new ApiEnumConverter<string, BillingCycleRelativeDate>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, CreatedInvoiceProperties::InvoiceSource>(),
            new ApiEnumConverter<string, PaymentProvider>(),
            new ApiEnumConverter<string, CreatedInvoiceProperties::Status>(),
            new ApiEnumConverter<string, DiscountProperties::DiscountType>(),
            new ApiEnumConverter<string, MaximumAmountAdjustmentProperties::DiscountType>(),
            new ApiEnumConverter<string, CreditNoteProperties::Reason>(),
            new ApiEnumConverter<string, CreditNoteProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.CreditNoteProperties.DiscountProperties.DiscountType
            >(),
            new ApiEnumConverter<string, CustomExpirationProperties::DurationUnit>(),
            new ApiEnumConverter<string, CustomerTaxIDProperties::Country>(),
            new ApiEnumConverter<string, CustomerTaxIDProperties::Type>(),
            new ApiEnumConverter<string, CustomerBalanceTransactionProperties::Action>(),
            new ApiEnumConverter<string, CustomerBalanceTransactionProperties::Type>(),
            new ApiEnumConverter<string, InvoiceProperties::InvoiceSource>(),
            new ApiEnumConverter<string, PaymentAttemptProperties::PaymentProvider>(),
            new ApiEnumConverter<string, InvoiceProperties::Status>(),
            new ApiEnumConverter<string, MatrixSubLineItemProperties::Type>(),
            new ApiEnumConverter<string, AdjustmentType>(),
            new ApiEnumConverter<string, MonetaryMaximumAdjustmentProperties::AdjustmentType>(),
            new ApiEnumConverter<string, MonetaryMinimumAdjustmentProperties::AdjustmentType>(),
            new ApiEnumConverter<
                string,
                MonetaryPercentageDiscountAdjustmentProperties::AdjustmentType
            >(),
            new ApiEnumConverter<
                string,
                MonetaryUsageDiscountAdjustmentProperties::AdjustmentType
            >(),
            new ApiEnumConverter<string, Cadence>(),
            new ApiEnumConverter<string, NewAmountDiscountProperties::AdjustmentType>(),
            new ApiEnumConverter<bool, NewAmountDiscountProperties::AppliesToAll>(),
            new ApiEnumConverter<string, NewAmountDiscountProperties::PriceType>(),
            new ApiEnumConverter<string, NewBillingCycleConfigurationProperties::DurationUnit>(),
            new ApiEnumConverter<string, NewFloatingBulkPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingBulkPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingBulkWithProrationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingBulkWithProrationPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewFloatingCumulativeGroupedBulkPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingCumulativeGroupedBulkPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingGroupedAllocationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingGroupedAllocationPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingGroupedTieredPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<
                string,
                NewFloatingGroupedTieredPackagePriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingGroupedTieredPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingGroupedTieredPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewFloatingGroupedWithMeteredMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingGroupedWithMeteredMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingGroupedWithProratedMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingGroupedWithProratedMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingMatrixPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingMatrixPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingMatrixWithAllocationPriceProperties::Cadence>(),
            new ApiEnumConverter<
                string,
                NewFloatingMatrixWithAllocationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingMatrixWithDisplayNamePriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingMatrixWithDisplayNamePriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingMaxGroupTieredPackagePriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingMaxGroupTieredPackagePriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingMinimumCompositePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingMinimumCompositePriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewFloatingPackageWithAllocationPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingPackageWithAllocationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingScalableMatrixWithTieredPricingPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingScalableMatrixWithTieredPricingPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingScalableMatrixWithUnitPricingPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingScalableMatrixWithUnitPricingPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingThresholdTotalAmountPriceProperties::Cadence>(),
            new ApiEnumConverter<
                string,
                NewFloatingThresholdTotalAmountPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingTieredPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingTieredPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewFloatingTieredPackageWithMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewFloatingTieredPackageWithMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingTieredPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingTieredPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingTieredWithMinimumPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingTieredWithMinimumPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingTieredWithProrationPriceProperties::Cadence>(),
            new ApiEnumConverter<
                string,
                NewFloatingTieredWithProrationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewFloatingUnitPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingUnitPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingUnitWithPercentPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingUnitWithPercentPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewFloatingUnitWithProrationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewFloatingUnitWithProrationPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewMaximumProperties::AdjustmentType>(),
            new ApiEnumConverter<bool, NewMaximumProperties::AppliesToAll>(),
            new ApiEnumConverter<string, NewMaximumProperties::PriceType>(),
            new ApiEnumConverter<string, NewMinimumProperties::AdjustmentType>(),
            new ApiEnumConverter<bool, NewMinimumProperties::AppliesToAll>(),
            new ApiEnumConverter<string, NewMinimumProperties::PriceType>(),
            new ApiEnumConverter<string, NewPercentageDiscountProperties::AdjustmentType>(),
            new ApiEnumConverter<bool, NewPercentageDiscountProperties::AppliesToAll>(),
            new ApiEnumConverter<string, NewPercentageDiscountProperties::PriceType>(),
            new ApiEnumConverter<string, NewPlanBulkPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanBulkPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanBulkWithProrationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanBulkWithProrationPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanCumulativeGroupedBulkPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanCumulativeGroupedBulkPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedAllocationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanGroupedAllocationPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanGroupedTieredPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewPlanGroupedWithMeteredMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewPlanGroupedWithMeteredMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewPlanGroupedWithProratedMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewPlanGroupedWithProratedMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewPlanMatrixPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanMatrixPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanMatrixWithAllocationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanMatrixWithAllocationPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanMatrixWithDisplayNamePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanMatrixWithDisplayNamePriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanMaxGroupTieredPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanMaxGroupTieredPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanMinimumCompositePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanMinimumCompositePriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanPackageWithAllocationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanPackageWithAllocationPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewPlanScalableMatrixWithTieredPricingPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewPlanScalableMatrixWithTieredPricingPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewPlanScalableMatrixWithUnitPricingPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewPlanScalableMatrixWithUnitPricingPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewPlanThresholdTotalAmountPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanThresholdTotalAmountPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanTieredPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanTieredPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanTieredPackageWithMinimumPriceProperties::Cadence>(),
            new ApiEnumConverter<
                string,
                NewPlanTieredPackageWithMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewPlanTieredPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanTieredPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanTieredWithMinimumPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanTieredWithMinimumPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanUnitPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanUnitPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanUnitWithPercentPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanUnitWithPercentPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewPlanUnitWithProrationPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewPlanUnitWithProrationPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewUsageDiscountProperties::AdjustmentType>(),
            new ApiEnumConverter<bool, NewUsageDiscountProperties::AppliesToAll>(),
            new ApiEnumConverter<string, NewUsageDiscountProperties::PriceType>(),
            new ApiEnumConverter<string, OtherSubLineItemProperties::Type>(),
            new ApiEnumConverter<string, PercentageDiscountProperties::DiscountType>(),
            new ApiEnumConverter<string, PercentageDiscountIntervalProperties::DiscountType>(),
            new ApiEnumConverter<
                string,
                PlanPhaseAmountDiscountAdjustmentProperties::AdjustmentType
            >(),
            new ApiEnumConverter<string, PlanPhaseMaximumAdjustmentProperties::AdjustmentType>(),
            new ApiEnumConverter<string, PlanPhaseMinimumAdjustmentProperties::AdjustmentType>(),
            new ApiEnumConverter<
                string,
                PlanPhasePercentageDiscountAdjustmentProperties::AdjustmentType
            >(),
            new ApiEnumConverter<
                string,
                PlanPhaseUsageDiscountAdjustmentProperties::AdjustmentType
            >(),
            new ApiEnumConverter<string, UnitProperties::BillingMode>(),
            new ApiEnumConverter<string, UnitProperties::Cadence>(),
            new ApiEnumConverter<string, UnitProperties::PriceType>(),
            new ApiEnumConverter<string, TieredProperties::BillingMode>(),
            new ApiEnumConverter<string, TieredProperties::Cadence>(),
            new ApiEnumConverter<string, TieredProperties::PriceType>(),
            new ApiEnumConverter<string, BulkProperties::BillingMode>(),
            new ApiEnumConverter<string, BulkProperties::Cadence>(),
            new ApiEnumConverter<string, BulkProperties::PriceType>(),
            new ApiEnumConverter<string, PackageProperties::BillingMode>(),
            new ApiEnumConverter<string, PackageProperties::Cadence>(),
            new ApiEnumConverter<string, PackageProperties::PriceType>(),
            new ApiEnumConverter<string, MatrixProperties::BillingMode>(),
            new ApiEnumConverter<string, MatrixProperties::Cadence>(),
            new ApiEnumConverter<string, MatrixProperties::PriceType>(),
            new ApiEnumConverter<string, ThresholdTotalAmountProperties::BillingMode>(),
            new ApiEnumConverter<string, ThresholdTotalAmountProperties::Cadence>(),
            new ApiEnumConverter<string, ThresholdTotalAmountProperties::PriceType>(),
            new ApiEnumConverter<string, TieredPackageProperties::BillingMode>(),
            new ApiEnumConverter<string, TieredPackageProperties::Cadence>(),
            new ApiEnumConverter<string, TieredPackageProperties::PriceType>(),
            new ApiEnumConverter<string, TieredWithMinimumProperties::BillingMode>(),
            new ApiEnumConverter<string, TieredWithMinimumProperties::Cadence>(),
            new ApiEnumConverter<string, TieredWithMinimumProperties::PriceType>(),
            new ApiEnumConverter<string, GroupedTieredProperties::BillingMode>(),
            new ApiEnumConverter<string, GroupedTieredProperties::Cadence>(),
            new ApiEnumConverter<string, GroupedTieredProperties::PriceType>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumProperties::BillingMode>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumProperties::Cadence>(),
            new ApiEnumConverter<string, TieredPackageWithMinimumProperties::PriceType>(),
            new ApiEnumConverter<string, PackageWithAllocationProperties::BillingMode>(),
            new ApiEnumConverter<string, PackageWithAllocationProperties::Cadence>(),
            new ApiEnumConverter<string, PackageWithAllocationProperties::PriceType>(),
            new ApiEnumConverter<string, UnitWithPercentProperties::BillingMode>(),
            new ApiEnumConverter<string, UnitWithPercentProperties::Cadence>(),
            new ApiEnumConverter<string, UnitWithPercentProperties::PriceType>(),
            new ApiEnumConverter<string, MatrixWithAllocationProperties::BillingMode>(),
            new ApiEnumConverter<string, MatrixWithAllocationProperties::Cadence>(),
            new ApiEnumConverter<string, MatrixWithAllocationProperties::PriceType>(),
            new ApiEnumConverter<string, TieredWithProrationProperties::BillingMode>(),
            new ApiEnumConverter<string, TieredWithProrationProperties::Cadence>(),
            new ApiEnumConverter<string, TieredWithProrationProperties::PriceType>(),
            new ApiEnumConverter<string, UnitWithProrationProperties::BillingMode>(),
            new ApiEnumConverter<string, UnitWithProrationProperties::Cadence>(),
            new ApiEnumConverter<string, UnitWithProrationProperties::PriceType>(),
            new ApiEnumConverter<string, GroupedAllocationProperties::BillingMode>(),
            new ApiEnumConverter<string, GroupedAllocationProperties::Cadence>(),
            new ApiEnumConverter<string, GroupedAllocationProperties::PriceType>(),
            new ApiEnumConverter<string, BulkWithProrationProperties::BillingMode>(),
            new ApiEnumConverter<string, BulkWithProrationProperties::Cadence>(),
            new ApiEnumConverter<string, BulkWithProrationProperties::PriceType>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumProperties::BillingMode>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumProperties::Cadence>(),
            new ApiEnumConverter<string, GroupedWithProratedMinimumProperties::PriceType>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumProperties::BillingMode>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumProperties::Cadence>(),
            new ApiEnumConverter<string, GroupedWithMeteredMinimumProperties::PriceType>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsProperties::BillingMode>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsProperties::Cadence>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsProperties::PriceType>(),
            new ApiEnumConverter<string, MatrixWithDisplayNameProperties::BillingMode>(),
            new ApiEnumConverter<string, MatrixWithDisplayNameProperties::Cadence>(),
            new ApiEnumConverter<string, MatrixWithDisplayNameProperties::PriceType>(),
            new ApiEnumConverter<string, GroupedTieredPackageProperties::BillingMode>(),
            new ApiEnumConverter<string, GroupedTieredPackageProperties::Cadence>(),
            new ApiEnumConverter<string, GroupedTieredPackageProperties::PriceType>(),
            new ApiEnumConverter<string, MaxGroupTieredPackageProperties::BillingMode>(),
            new ApiEnumConverter<string, MaxGroupTieredPackageProperties::Cadence>(),
            new ApiEnumConverter<string, MaxGroupTieredPackageProperties::PriceType>(),
            new ApiEnumConverter<string, ScalableMatrixWithUnitPricingProperties::BillingMode>(),
            new ApiEnumConverter<string, ScalableMatrixWithUnitPricingProperties::Cadence>(),
            new ApiEnumConverter<string, ScalableMatrixWithUnitPricingProperties::PriceType>(),
            new ApiEnumConverter<string, ScalableMatrixWithTieredPricingProperties::BillingMode>(),
            new ApiEnumConverter<string, ScalableMatrixWithTieredPricingProperties::Cadence>(),
            new ApiEnumConverter<string, ScalableMatrixWithTieredPricingProperties::PriceType>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkProperties::BillingMode>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkProperties::Cadence>(),
            new ApiEnumConverter<string, CumulativeGroupedBulkProperties::PriceType>(),
            new ApiEnumConverter<string, MinimumProperties::BillingMode>(),
            new ApiEnumConverter<string, MinimumProperties::Cadence>(),
            new ApiEnumConverter<string, MinimumProperties::PriceType>(),
            new ApiEnumConverter<string, PercentProperties::BillingMode>(),
            new ApiEnumConverter<string, PercentProperties::Cadence>(),
            new ApiEnumConverter<string, PercentProperties::PriceType>(),
            new ApiEnumConverter<string, EventOutputProperties::BillingMode>(),
            new ApiEnumConverter<string, EventOutputProperties::Cadence>(),
            new ApiEnumConverter<string, EventOutputProperties::PriceType>(),
            new ApiEnumConverter<string, TierSubLineItemProperties::Type>(),
            new ApiEnumConverter<string, ConversionRateType>(),
            new ApiEnumConverter<string, Field>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, TrialDiscountProperties::DiscountType>(),
            new ApiEnumConverter<string, UnitConversionRateConfigProperties::ConversionRateType>(),
            new ApiEnumConverter<string, UsageDiscountProperties::DiscountType>(),
            new ApiEnumConverter<string, UsageDiscountIntervalProperties::DiscountType>(),
            new ApiEnumConverter<string, PlanVersionPhaseProperties::DurationUnit>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<string, Reason>(),
            new ApiEnumConverter<string, CustomerProperties::PaymentProvider>(),
            new ApiEnumConverter<string, ProviderType>(),
            new ApiEnumConverter<string, TaxProvider>(),
            new ApiEnumConverter<string, NewSphereConfigurationProperties::TaxProvider>(),
            new ApiEnumConverter<string, NewTaxJarConfigurationProperties::TaxProvider>(),
            new ApiEnumConverter<string, CustomerCreateParamsProperties::PaymentProvider>(),
            new ApiEnumConverter<string, CustomerUpdateParamsProperties::PaymentProvider>(),
            new ApiEnumConverter<
                string,
                CustomerUpdateByExternalIDParamsProperties::PaymentProvider
            >(),
            new ApiEnumConverter<string, ViewMode>(),
            new ApiEnumConverter<string, CostListByExternalIDParamsProperties::ViewMode>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, DataProperties::Status>(),
            new ApiEnumConverter<string, EntryStatus>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, CreditBlockExpiryLedgerEntryProperties::EntryStatus>(),
            new ApiEnumConverter<string, CreditBlockExpiryLedgerEntryProperties::EntryType>(),
            new ApiEnumConverter<string, DecrementLedgerEntryProperties::EntryStatus>(),
            new ApiEnumConverter<string, DecrementLedgerEntryProperties::EntryType>(),
            new ApiEnumConverter<string, ExpirationChangeLedgerEntryProperties::EntryStatus>(),
            new ApiEnumConverter<string, ExpirationChangeLedgerEntryProperties::EntryType>(),
            new ApiEnumConverter<string, IncrementLedgerEntryProperties::EntryStatus>(),
            new ApiEnumConverter<string, IncrementLedgerEntryProperties::EntryType>(),
            new ApiEnumConverter<string, VoidInitiatedLedgerEntryProperties::EntryStatus>(),
            new ApiEnumConverter<string, VoidInitiatedLedgerEntryProperties::EntryType>(),
            new ApiEnumConverter<string, VoidLedgerEntryProperties::EntryStatus>(),
            new ApiEnumConverter<string, VoidLedgerEntryProperties::EntryType>(),
            new ApiEnumConverter<string, LedgerListParamsProperties::EntryStatus>(),
            new ApiEnumConverter<string, LedgerListParamsProperties::EntryType>(),
            new ApiEnumConverter<string, VoidProperties::VoidReason>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.VoidProperties.VoidReason
            >(),
            new ApiEnumConverter<string, LedgerListByExternalIDParamsProperties::EntryStatus>(),
            new ApiEnumConverter<string, LedgerListByExternalIDParamsProperties::EntryType>(),
            new ApiEnumConverter<string, ExpiresAfterUnit>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Customers.Credits.TopUps.TopUpListPageResponseProperties.DataProperties.ExpiresAfterUnit
            >(),
            new ApiEnumConverter<
                string,
                TopUpCreateByExternalIDResponseProperties::ExpiresAfterUnit
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Customers.Credits.TopUps.TopUpListByExternalIDPageResponseProperties.DataProperties.ExpiresAfterUnit
            >(),
            new ApiEnumConverter<string, TopUpCreateParamsProperties::ExpiresAfterUnit>(),
            new ApiEnumConverter<
                string,
                TopUpCreateByExternalIDParamsProperties::ExpiresAfterUnit
            >(),
            new ApiEnumConverter<string, BalanceTransactionCreateResponseProperties::Action>(),
            new ApiEnumConverter<string, BalanceTransactionCreateResponseProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Customers.BalanceTransactions.BalanceTransactionListPageResponseProperties.DataProperties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Customers.BalanceTransactions.BalanceTransactionListPageResponseProperties.DataProperties.Type
            >(),
            new ApiEnumConverter<string, BalanceTransactionCreateParamsProperties::Type>(),
            new ApiEnumConverter<string, BackfillCreateResponseProperties::Status>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Events.Backfills.BackfillListPageResponseProperties.DataProperties.Status
            >(),
            new ApiEnumConverter<string, BackfillCloseResponseProperties::Status>(),
            new ApiEnumConverter<string, BackfillFetchResponseProperties::Status>(),
            new ApiEnumConverter<string, BackfillRevertResponseProperties::Status>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.CustomerBalanceTransactionProperties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.CustomerBalanceTransactionProperties.Type
            >(),
            new ApiEnumConverter<string, InvoiceFetchUpcomingResponseProperties::InvoiceSource>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.PaymentAttemptProperties.PaymentProvider
            >(),
            new ApiEnumConverter<string, InvoiceFetchUpcomingResponseProperties::Status>(),
            new ApiEnumConverter<string, ModelType>(),
            new ApiEnumConverter<string, InvoiceListParamsProperties::DateType>(),
            new ApiEnumConverter<string, InvoiceListParamsProperties::Status>(),
            new ApiEnumConverter<string, ExternalConnectionName>(),
            new ApiEnumConverter<string, ExternalConnectionProperties::ExternalConnectionName>(),
            new ApiEnumConverter<string, BillableMetricProperties::Status>(),
            new ApiEnumConverter<string, PlanPhaseProperties::DurationUnit>(),
            new ApiEnumConverter<string, PlanProperties::Status>(),
            new ApiEnumConverter<string, TrialPeriodUnit>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Plans.PlanCreateParamsProperties.PlanPhaseProperties.DurationUnit
            >(),
            new ApiEnumConverter<string, PlanCreateParamsProperties::Status>(),
            new ApiEnumConverter<string, PlanListParamsProperties::Status>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceCreateParamsProperties.BodyProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceCreateParamsProperties.BodyProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceCreateParamsProperties.BodyProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<string, DiscountOverrideProperties::DiscountType>(),
            new ApiEnumConverter<string, NewSubscriptionBulkPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewSubscriptionBulkPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionBulkWithProrationPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionBulkWithProrationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionCumulativeGroupedBulkPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionCumulativeGroupedBulkPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedAllocationPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedAllocationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedTieredPackagePriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedTieredPackagePriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewSubscriptionGroupedTieredPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewSubscriptionGroupedTieredPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedWithMeteredMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedWithMeteredMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedWithProratedMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionGroupedWithProratedMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewSubscriptionMatrixPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewSubscriptionMatrixPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionMatrixWithAllocationPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionMatrixWithAllocationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionMatrixWithDisplayNamePriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionMatrixWithDisplayNamePriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionMaxGroupTieredPackagePriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionMaxGroupTieredPackagePriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewSubscriptionMinimumCompositePriceProperties::Cadence>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionMinimumCompositePriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewSubscriptionPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewSubscriptionPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionPackageWithAllocationPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionPackageWithAllocationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionScalableMatrixWithTieredPricingPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionScalableMatrixWithTieredPricingPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionScalableMatrixWithUnitPricingPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionScalableMatrixWithUnitPricingPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionThresholdTotalAmountPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionThresholdTotalAmountPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewSubscriptionTieredPackagePriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewSubscriptionTieredPackagePriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionTieredPackageWithMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionTieredPackageWithMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewSubscriptionTieredPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewSubscriptionTieredPriceProperties::ModelType>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionTieredWithMinimumPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionTieredWithMinimumPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, NewSubscriptionUnitPriceProperties::Cadence>(),
            new ApiEnumConverter<string, NewSubscriptionUnitPriceProperties::ModelType>(),
            new ApiEnumConverter<string, NewSubscriptionUnitWithPercentPriceProperties::Cadence>(),
            new ApiEnumConverter<
                string,
                NewSubscriptionUnitWithPercentPriceProperties::ModelType
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionUnitWithProrationPriceProperties::Cadence
            >(),
            new ApiEnumConverter<
                string,
                NewSubscriptionUnitWithProrationPriceProperties::ModelType
            >(),
            new ApiEnumConverter<string, SubscriptionProperties::Status>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties.DataProperties.ViewMode
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties.DataProperties.ViewMode
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.AddPriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.AddPriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.AddPriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.AddPriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<string, ExternalMarketplace>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<string, SubscriptionListParamsProperties::Status>(),
            new ApiEnumConverter<string, CancelOption>(),
            new ApiEnumConverter<string, SubscriptionFetchCostsParamsProperties::ViewMode>(),
            new ApiEnumConverter<string, SubscriptionFetchUsageParamsProperties::Granularity>(),
            new ApiEnumConverter<string, SubscriptionFetchUsageParamsProperties::ViewMode>(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<string, ChangeOption>(),
            new ApiEnumConverter<
                string,
                SubscriptionSchedulePlanChangeParamsProperties::ChangeOption
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionSchedulePlanChangeParamsProperties::BillingCycleAlignment
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties.PriceProperties.TieredWithProrationProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties.PriceProperties.PercentProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                global::Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties.PriceProperties.EventOutputProperties.Cadence
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionUpdateFixedFeeQuantityParamsProperties::ChangeOption
            >(),
            new ApiEnumConverter<string, UnionMember1>(),
            new ApiEnumConverter<string, AlertProperties::Type>(),
            new ApiEnumConverter<string, AlertCreateForCustomerParamsProperties::Type>(),
            new ApiEnumConverter<string, AlertCreateForExternalCustomerParamsProperties::Type>(),
            new ApiEnumConverter<string, AlertCreateForSubscriptionParamsProperties::Type>(),
            new ApiEnumConverter<string, MutatedSubscriptionProperties::Status>(),
            new ApiEnumConverter<string, SubscriptionChangeRetrieveResponseProperties::Status>(),
            new ApiEnumConverter<string, SubscriptionChangeApplyResponseProperties::Status>(),
            new ApiEnumConverter<string, SubscriptionChangeCancelResponseProperties::Status>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
