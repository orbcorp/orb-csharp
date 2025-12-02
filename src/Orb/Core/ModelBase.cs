using System.Collections.Generic;
using System.Text.Json;
using Orb.Exceptions;
using Orb.Models.Beta;
using Orb.Models.CreditNotes;
using Orb.Models.Customers;
using Orb.Models.Customers.BalanceTransactions;
using Orb.Models.Customers.Costs;
using Orb.Models.Customers.Credits.Ledger;
using Orb.Models.Customers.Credits.TopUps;
using Orb.Models.Events.Backfills;
using Orb.Models.Items;
using Alerts = Orb.Models.Alerts;
using Credits = Orb.Models.Customers.Credits;
using ExternalPlanID = Orb.Models.Beta.ExternalPlanID;
using Invoices = Orb.Models.Invoices;
using Metrics = Orb.Models.Metrics;
using Models = Orb.Models;
using Plans = Orb.Models.Plans;
using Prices = Orb.Models.Prices;
using SubscriptionChanges = Orb.Models.SubscriptionChanges;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Models::Field>(),
            new ApiEnumConverter<string, Models::Operator>(),
            new ApiEnumConverter<string, Models::DiscountType>(),
            new ApiEnumConverter<string, Models::FilterModelField>(),
            new ApiEnumConverter<string, Models::FilterModelOperator>(),
            new ApiEnumConverter<string, Models::AmountDiscountIntervalDiscountType>(),
            new ApiEnumConverter<string, Models::Filter1Field>(),
            new ApiEnumConverter<string, Models::Filter1Operator>(),
            new ApiEnumConverter<string, Models::DurationUnit>(),
            new ApiEnumConverter<string, Models::BillingCycleRelativeDate>(),
            new ApiEnumConverter<string, Models::Action>(),
            new ApiEnumConverter<string, Models::Type>(),
            new ApiEnumConverter<string, Models::InvoiceSource>(),
            new ApiEnumConverter<string, Models::PaymentProvider>(),
            new ApiEnumConverter<string, Models::Status>(),
            new ApiEnumConverter<string, Models::DiscountDiscountType>(),
            new ApiEnumConverter<string, Models::MaximumAmountAdjustmentDiscountType>(),
            new ApiEnumConverter<string, Models::Reason>(),
            new ApiEnumConverter<string, Models::SharedCreditNoteType>(),
            new ApiEnumConverter<string, Models::DiscountModelDiscountType>(),
            new ApiEnumConverter<string, Models::CustomExpirationDurationUnit>(),
            new ApiEnumConverter<string, Models::Country>(),
            new ApiEnumConverter<string, Models::CustomerTaxIDType>(),
            new ApiEnumConverter<string, Models::CustomerBalanceTransactionModelAction>(),
            new ApiEnumConverter<string, Models::CustomerBalanceTransactionModelType>(),
            new ApiEnumConverter<string, Models::InvoiceInvoiceSource>(),
            new ApiEnumConverter<string, Models::PaymentAttemptModelPaymentProvider>(),
            new ApiEnumConverter<string, Models::InvoiceStatus>(),
            new ApiEnumConverter<string, Models::MatrixSubLineItemType>(),
            new ApiEnumConverter<string, Models::Filter2Field>(),
            new ApiEnumConverter<string, Models::Filter2Operator>(),
            new ApiEnumConverter<string, Models::Filter3Field>(),
            new ApiEnumConverter<string, Models::Filter3Operator>(),
            new ApiEnumConverter<string, Models::Filter4Field>(),
            new ApiEnumConverter<string, Models::Filter4Operator>(),
            new ApiEnumConverter<string, Models::Filter5Field>(),
            new ApiEnumConverter<string, Models::Filter5Operator>(),
            new ApiEnumConverter<string, Models::AdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter6Field>(),
            new ApiEnumConverter<string, Models::Filter6Operator>(),
            new ApiEnumConverter<string, Models::MonetaryMaximumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter7Field>(),
            new ApiEnumConverter<string, Models::Filter7Operator>(),
            new ApiEnumConverter<string, Models::MonetaryMinimumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter8Field>(),
            new ApiEnumConverter<string, Models::Filter8Operator>(),
            new ApiEnumConverter<
                string,
                Models::MonetaryPercentageDiscountAdjustmentAdjustmentType
            >(),
            new ApiEnumConverter<string, Models::Filter9Field>(),
            new ApiEnumConverter<string, Models::Filter9Operator>(),
            new ApiEnumConverter<string, Models::MonetaryUsageDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter10Field>(),
            new ApiEnumConverter<string, Models::Filter10Operator>(),
            new ApiEnumConverter<string, Models::Cadence>(),
            new ApiEnumConverter<string, Models::Filter11Field>(),
            new ApiEnumConverter<string, Models::Filter11Operator>(),
            new ApiEnumConverter<string, Models::NewAmountDiscountAdjustmentType>(),
            new ApiEnumConverter<bool, Models::AppliesToAll>(),
            new ApiEnumConverter<string, Models::Filter12Field>(),
            new ApiEnumConverter<string, Models::Filter12Operator>(),
            new ApiEnumConverter<string, Models::PriceType>(),
            new ApiEnumConverter<string, Models::NewBillingCycleConfigurationDurationUnit>(),
            new ApiEnumConverter<string, Models::NewFloatingBulkPriceCadence>(),
            new ApiEnumConverter<string, Models::ModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingBulkWithProrationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingBulkWithProrationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingCumulativeGroupedBulkPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingCumulativeGroupedBulkPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingGroupedAllocationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingGroupedAllocationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingGroupedTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingGroupedTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingGroupedTieredPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingGroupedTieredPriceModelType>(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingGroupedWithMeteredMinimumPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingGroupedWithMeteredMinimumPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingGroupedWithProratedMinimumPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingGroupedWithProratedMinimumPriceModelType
            >(),
            new ApiEnumConverter<string, Models::NewFloatingMatrixPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingMatrixPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingMatrixWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingMatrixWithAllocationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingMatrixWithDisplayNamePriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingMatrixWithDisplayNamePriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingMaxGroupTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingMaxGroupTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingMinimumCompositePriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingMinimumCompositePriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingPackageWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingPackageWithAllocationPriceModelType>(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingScalableMatrixWithTieredPricingPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingScalableMatrixWithTieredPricingPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingScalableMatrixWithUnitPricingPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingScalableMatrixWithUnitPricingPriceModelType
            >(),
            new ApiEnumConverter<string, Models::NewFloatingThresholdTotalAmountPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingThresholdTotalAmountPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredPackageWithMinimumPriceCadence>(),
            new ApiEnumConverter<
                string,
                Models::NewFloatingTieredPackageWithMinimumPriceModelType
            >(),
            new ApiEnumConverter<string, Models::NewFloatingTieredPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredWithMinimumPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredWithMinimumPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredWithProrationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingTieredWithProrationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingUnitPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingUnitPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingUnitWithPercentPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingUnitWithPercentPriceModelType>(),
            new ApiEnumConverter<string, Models::NewFloatingUnitWithProrationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewFloatingUnitWithProrationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewMaximumAdjustmentType>(),
            new ApiEnumConverter<bool, Models::NewMaximumAppliesToAll>(),
            new ApiEnumConverter<string, Models::Filter13Field>(),
            new ApiEnumConverter<string, Models::Filter13Operator>(),
            new ApiEnumConverter<string, Models::NewMaximumPriceType>(),
            new ApiEnumConverter<string, Models::NewMinimumAdjustmentType>(),
            new ApiEnumConverter<bool, Models::NewMinimumAppliesToAll>(),
            new ApiEnumConverter<string, Models::Filter14Field>(),
            new ApiEnumConverter<string, Models::Filter14Operator>(),
            new ApiEnumConverter<string, Models::NewMinimumPriceType>(),
            new ApiEnumConverter<string, Models::NewPercentageDiscountAdjustmentType>(),
            new ApiEnumConverter<bool, Models::NewPercentageDiscountAppliesToAll>(),
            new ApiEnumConverter<string, Models::Filter15Field>(),
            new ApiEnumConverter<string, Models::Filter15Operator>(),
            new ApiEnumConverter<string, Models::NewPercentageDiscountPriceType>(),
            new ApiEnumConverter<string, Models::NewPlanBulkPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanBulkPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanBulkWithProrationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanBulkWithProrationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanCumulativeGroupedBulkPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanCumulativeGroupedBulkPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedAllocationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedAllocationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedTieredPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedTieredPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedWithMeteredMinimumPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedWithMeteredMinimumPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedWithProratedMinimumPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanGroupedWithProratedMinimumPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanMatrixPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanMatrixPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanMatrixWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanMatrixWithAllocationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanMatrixWithDisplayNamePriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanMatrixWithDisplayNamePriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanMaxGroupTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanMaxGroupTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanMinimumCompositePriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanMinimumCompositePriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanPackageWithAllocationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanPackageWithAllocationPriceModelType>(),
            new ApiEnumConverter<
                string,
                Models::NewPlanScalableMatrixWithTieredPricingPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Models::NewPlanScalableMatrixWithTieredPricingPriceModelType
            >(),
            new ApiEnumConverter<
                string,
                Models::NewPlanScalableMatrixWithUnitPricingPriceCadence
            >(),
            new ApiEnumConverter<
                string,
                Models::NewPlanScalableMatrixWithUnitPricingPriceModelType
            >(),
            new ApiEnumConverter<string, Models::NewPlanThresholdTotalAmountPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanThresholdTotalAmountPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanTieredPackagePriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanTieredPackagePriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanTieredPackageWithMinimumPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanTieredPackageWithMinimumPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanTieredPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanTieredPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanTieredWithMinimumPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanTieredWithMinimumPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanUnitPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanUnitPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanUnitWithPercentPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanUnitWithPercentPriceModelType>(),
            new ApiEnumConverter<string, Models::NewPlanUnitWithProrationPriceCadence>(),
            new ApiEnumConverter<string, Models::NewPlanUnitWithProrationPriceModelType>(),
            new ApiEnumConverter<string, Models::NewUsageDiscountAdjustmentType>(),
            new ApiEnumConverter<bool, Models::NewUsageDiscountAppliesToAll>(),
            new ApiEnumConverter<string, Models::Filter16Field>(),
            new ApiEnumConverter<string, Models::Filter16Operator>(),
            new ApiEnumConverter<string, Models::NewUsageDiscountPriceType>(),
            new ApiEnumConverter<string, Models::OtherSubLineItemType>(),
            new ApiEnumConverter<string, Models::PercentageDiscountDiscountType>(),
            new ApiEnumConverter<string, Models::Filter17Field>(),
            new ApiEnumConverter<string, Models::Filter17Operator>(),
            new ApiEnumConverter<string, Models::PercentageDiscountIntervalDiscountType>(),
            new ApiEnumConverter<string, Models::Filter18Field>(),
            new ApiEnumConverter<string, Models::Filter18Operator>(),
            new ApiEnumConverter<string, Models::PlanPhaseAmountDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter19Field>(),
            new ApiEnumConverter<string, Models::Filter19Operator>(),
            new ApiEnumConverter<string, Models::PlanPhaseMaximumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter20Field>(),
            new ApiEnumConverter<string, Models::Filter20Operator>(),
            new ApiEnumConverter<string, Models::PlanPhaseMinimumAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter21Field>(),
            new ApiEnumConverter<string, Models::Filter21Operator>(),
            new ApiEnumConverter<
                string,
                Models::PlanPhasePercentageDiscountAdjustmentAdjustmentType
            >(),
            new ApiEnumConverter<string, Models::Filter22Field>(),
            new ApiEnumConverter<string, Models::Filter22Operator>(),
            new ApiEnumConverter<string, Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType>(),
            new ApiEnumConverter<string, Models::Filter23Field>(),
            new ApiEnumConverter<string, Models::Filter23Operator>(),
            new ApiEnumConverter<string, Models::BillingMode>(),
            new ApiEnumConverter<string, Models::UnitCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilterField>(),
            new ApiEnumConverter<string, Models::CompositePriceFilterOperator>(),
            new ApiEnumConverter<string, Models::UnitPriceType>(),
            new ApiEnumConverter<string, Models::TieredBillingMode>(),
            new ApiEnumConverter<string, Models::TieredCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilterModelField>(),
            new ApiEnumConverter<string, Models::CompositePriceFilterModelOperator>(),
            new ApiEnumConverter<string, Models::TieredPriceType>(),
            new ApiEnumConverter<string, Models::BulkBillingMode>(),
            new ApiEnumConverter<string, Models::BulkCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter1Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter1Operator>(),
            new ApiEnumConverter<string, Models::BulkPriceType>(),
            new ApiEnumConverter<string, Models::BulkWithFiltersBillingMode>(),
            new ApiEnumConverter<string, Models::BulkWithFiltersCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter2Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter2Operator>(),
            new ApiEnumConverter<string, Models::BulkWithFiltersPriceType>(),
            new ApiEnumConverter<string, Models::PackageBillingMode>(),
            new ApiEnumConverter<string, Models::PackageCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter3Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter3Operator>(),
            new ApiEnumConverter<string, Models::PackagePriceType>(),
            new ApiEnumConverter<string, Models::MatrixBillingMode>(),
            new ApiEnumConverter<string, Models::MatrixCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter4Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter4Operator>(),
            new ApiEnumConverter<string, Models::MatrixPriceType>(),
            new ApiEnumConverter<string, Models::ThresholdTotalAmountBillingMode>(),
            new ApiEnumConverter<string, Models::ThresholdTotalAmountCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter5Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter5Operator>(),
            new ApiEnumConverter<string, Models::ThresholdTotalAmountPriceType>(),
            new ApiEnumConverter<string, Models::TieredPackageBillingMode>(),
            new ApiEnumConverter<string, Models::TieredPackageCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter6Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter6Operator>(),
            new ApiEnumConverter<string, Models::TieredPackagePriceType>(),
            new ApiEnumConverter<string, Models::TieredWithMinimumBillingMode>(),
            new ApiEnumConverter<string, Models::TieredWithMinimumCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter7Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter7Operator>(),
            new ApiEnumConverter<string, Models::TieredWithMinimumPriceType>(),
            new ApiEnumConverter<string, Models::GroupedTieredBillingMode>(),
            new ApiEnumConverter<string, Models::GroupedTieredCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter8Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter8Operator>(),
            new ApiEnumConverter<string, Models::GroupedTieredPriceType>(),
            new ApiEnumConverter<string, Models::TieredPackageWithMinimumBillingMode>(),
            new ApiEnumConverter<string, Models::TieredPackageWithMinimumCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter9Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter9Operator>(),
            new ApiEnumConverter<string, Models::TieredPackageWithMinimumPriceType>(),
            new ApiEnumConverter<string, Models::PackageWithAllocationBillingMode>(),
            new ApiEnumConverter<string, Models::PackageWithAllocationCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter10Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter10Operator>(),
            new ApiEnumConverter<string, Models::PackageWithAllocationPriceType>(),
            new ApiEnumConverter<string, Models::UnitWithPercentBillingMode>(),
            new ApiEnumConverter<string, Models::UnitWithPercentCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter11Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter11Operator>(),
            new ApiEnumConverter<string, Models::UnitWithPercentPriceType>(),
            new ApiEnumConverter<string, Models::MatrixWithAllocationBillingMode>(),
            new ApiEnumConverter<string, Models::MatrixWithAllocationCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter12Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter12Operator>(),
            new ApiEnumConverter<string, Models::MatrixWithAllocationPriceType>(),
            new ApiEnumConverter<string, Models::TieredWithProrationBillingMode>(),
            new ApiEnumConverter<string, Models::TieredWithProrationCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter13Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter13Operator>(),
            new ApiEnumConverter<string, Models::TieredWithProrationPriceType>(),
            new ApiEnumConverter<string, Models::UnitWithProrationBillingMode>(),
            new ApiEnumConverter<string, Models::UnitWithProrationCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter14Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter14Operator>(),
            new ApiEnumConverter<string, Models::UnitWithProrationPriceType>(),
            new ApiEnumConverter<string, Models::GroupedAllocationBillingMode>(),
            new ApiEnumConverter<string, Models::GroupedAllocationCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter15Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter15Operator>(),
            new ApiEnumConverter<string, Models::GroupedAllocationPriceType>(),
            new ApiEnumConverter<string, Models::BulkWithProrationBillingMode>(),
            new ApiEnumConverter<string, Models::BulkWithProrationCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter16Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter16Operator>(),
            new ApiEnumConverter<string, Models::BulkWithProrationPriceType>(),
            new ApiEnumConverter<string, Models::GroupedWithProratedMinimumBillingMode>(),
            new ApiEnumConverter<string, Models::GroupedWithProratedMinimumCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter17Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter17Operator>(),
            new ApiEnumConverter<string, Models::GroupedWithProratedMinimumPriceType>(),
            new ApiEnumConverter<string, Models::GroupedWithMeteredMinimumBillingMode>(),
            new ApiEnumConverter<string, Models::GroupedWithMeteredMinimumCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter18Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter18Operator>(),
            new ApiEnumConverter<string, Models::GroupedWithMeteredMinimumPriceType>(),
            new ApiEnumConverter<string, Models::GroupedWithMinMaxThresholdsBillingMode>(),
            new ApiEnumConverter<string, Models::GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter19Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter19Operator>(),
            new ApiEnumConverter<string, Models::GroupedWithMinMaxThresholdsPriceType>(),
            new ApiEnumConverter<string, Models::MatrixWithDisplayNameBillingMode>(),
            new ApiEnumConverter<string, Models::MatrixWithDisplayNameCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter20Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter20Operator>(),
            new ApiEnumConverter<string, Models::MatrixWithDisplayNamePriceType>(),
            new ApiEnumConverter<string, Models::GroupedTieredPackageBillingMode>(),
            new ApiEnumConverter<string, Models::GroupedTieredPackageCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter21Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter21Operator>(),
            new ApiEnumConverter<string, Models::GroupedTieredPackagePriceType>(),
            new ApiEnumConverter<string, Models::MaxGroupTieredPackageBillingMode>(),
            new ApiEnumConverter<string, Models::MaxGroupTieredPackageCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter22Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter22Operator>(),
            new ApiEnumConverter<string, Models::MaxGroupTieredPackagePriceType>(),
            new ApiEnumConverter<string, Models::ScalableMatrixWithUnitPricingBillingMode>(),
            new ApiEnumConverter<string, Models::ScalableMatrixWithUnitPricingCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter23Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter23Operator>(),
            new ApiEnumConverter<string, Models::ScalableMatrixWithUnitPricingPriceType>(),
            new ApiEnumConverter<string, Models::ScalableMatrixWithTieredPricingBillingMode>(),
            new ApiEnumConverter<string, Models::ScalableMatrixWithTieredPricingCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter24Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter24Operator>(),
            new ApiEnumConverter<string, Models::ScalableMatrixWithTieredPricingPriceType>(),
            new ApiEnumConverter<string, Models::CumulativeGroupedBulkBillingMode>(),
            new ApiEnumConverter<string, Models::CumulativeGroupedBulkCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter25Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter25Operator>(),
            new ApiEnumConverter<string, Models::CumulativeGroupedBulkPriceType>(),
            new ApiEnumConverter<string, Models::CumulativeGroupedAllocationBillingMode>(),
            new ApiEnumConverter<string, Models::CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter26Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter26Operator>(),
            new ApiEnumConverter<string, Models::CumulativeGroupedAllocationPriceType>(),
            new ApiEnumConverter<string, Models::PriceMinimumBillingMode>(),
            new ApiEnumConverter<string, Models::PriceMinimumCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter27Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter27Operator>(),
            new ApiEnumConverter<string, Models::PriceMinimumPriceType>(),
            new ApiEnumConverter<string, Models::PercentBillingMode>(),
            new ApiEnumConverter<string, Models::PercentCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter28Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter28Operator>(),
            new ApiEnumConverter<string, Models::PercentPriceType>(),
            new ApiEnumConverter<string, Models::EventOutputBillingMode>(),
            new ApiEnumConverter<string, Models::EventOutputCadence>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter29Field>(),
            new ApiEnumConverter<string, Models::CompositePriceFilter29Operator>(),
            new ApiEnumConverter<string, Models::EventOutputPriceType>(),
            new ApiEnumConverter<string, Models::TierSubLineItemType>(),
            new ApiEnumConverter<string, Models::ConversionRateType>(),
            new ApiEnumConverter<string, Models::TrialDiscountDiscountType>(),
            new ApiEnumConverter<string, Models::Filter25Field>(),
            new ApiEnumConverter<string, Models::Filter25Operator>(),
            new ApiEnumConverter<
                string,
                Models::SharedUnitConversionRateConfigConversionRateType
            >(),
            new ApiEnumConverter<string, Models::UsageDiscountDiscountType>(),
            new ApiEnumConverter<string, Models::Filter26Field>(),
            new ApiEnumConverter<string, Models::Filter26Operator>(),
            new ApiEnumConverter<string, Models::UsageDiscountIntervalDiscountType>(),
            new ApiEnumConverter<string, Models::Filter27Field>(),
            new ApiEnumConverter<string, Models::Filter27Operator>(),
            new ApiEnumConverter<string, DurationUnit>(),
            new ApiEnumConverter<string, Cadence>(),
            new ApiEnumConverter<string, TieredWithProrationCadence>(),
            new ApiEnumConverter<string, GroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, CumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, PercentCadence>(),
            new ApiEnumConverter<string, EventOutputCadence>(),
            new ApiEnumConverter<string, ReplacePricePriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<string, ReplacePricePriceTieredWithProrationCadence>(),
            new ApiEnumConverter<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>(),
            new ApiEnumConverter<string, ReplacePricePriceCumulativeGroupedAllocationCadence>(),
            new ApiEnumConverter<string, ReplacePricePricePercentCadence>(),
            new ApiEnumConverter<string, ReplacePricePriceEventOutputCadence>(),
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
            new ApiEnumConverter<string, Reason>(),
            new ApiEnumConverter<string, CustomerPaymentProvider>(),
            new ApiEnumConverter<string, ProviderType>(),
            new ApiEnumConverter<string, TaxProvider>(),
            new ApiEnumConverter<string, NewSphereConfigurationTaxProvider>(),
            new ApiEnumConverter<string, NewTaxJarConfigurationTaxProvider>(),
            new ApiEnumConverter<string, PaymentProvider>(),
            new ApiEnumConverter<string, PaymentProviderModel>(),
            new ApiEnumConverter<string, PaymentProvider1>(),
            new ApiEnumConverter<string, ViewMode>(),
            new ApiEnumConverter<string, ViewModeModel>(),
            new ApiEnumConverter<string, Credits::Field>(),
            new ApiEnumConverter<string, Credits::Operator>(),
            new ApiEnumConverter<string, Credits::Status>(),
            new ApiEnumConverter<string, Credits::FilterModelField>(),
            new ApiEnumConverter<string, Credits::FilterModelOperator>(),
            new ApiEnumConverter<string, Credits::DataModelStatus>(),
            new ApiEnumConverter<string, Filter1Field>(),
            new ApiEnumConverter<string, Filter1Operator>(),
            new ApiEnumConverter<string, AmendmentLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, AmendmentLedgerEntryEntryType>(),
            new ApiEnumConverter<string, CreditBlockExpiryLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, CreditBlockExpiryLedgerEntryEntryType>(),
            new ApiEnumConverter<string, DecrementLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, DecrementLedgerEntryEntryType>(),
            new ApiEnumConverter<string, ExpirationChangeLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, ExpirationChangeLedgerEntryEntryType>(),
            new ApiEnumConverter<string, IncrementLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, IncrementLedgerEntryEntryType>(),
            new ApiEnumConverter<string, VoidInitiatedLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, VoidInitiatedLedgerEntryEntryType>(),
            new ApiEnumConverter<string, VoidLedgerEntryEntryStatus>(),
            new ApiEnumConverter<string, VoidLedgerEntryEntryType>(),
            new ApiEnumConverter<string, EntryStatus>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, Field>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, VoidReason>(),
            new ApiEnumConverter<string, FilterModelField>(),
            new ApiEnumConverter<string, FilterModelOperator>(),
            new ApiEnumConverter<string, BodyModelVoidVoidReason>(),
            new ApiEnumConverter<string, EntryStatusModel>(),
            new ApiEnumConverter<string, EntryTypeModel>(),
            new ApiEnumConverter<string, TopUpCreateResponseExpiresAfterUnit>(),
            new ApiEnumConverter<string, DataExpiresAfterUnit>(),
            new ApiEnumConverter<string, TopUpCreateByExternalIDResponseExpiresAfterUnit>(),
            new ApiEnumConverter<string, DataModelExpiresAfterUnit>(),
            new ApiEnumConverter<string, ExpiresAfterUnit>(),
            new ApiEnumConverter<string, ExpiresAfterUnitModel>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, BalanceTransactionCreateResponseType>(),
            new ApiEnumConverter<string, DataAction>(),
            new ApiEnumConverter<string, DataType>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, DataStatus>(),
            new ApiEnumConverter<string, BackfillCloseResponseStatus>(),
            new ApiEnumConverter<string, BackfillFetchResponseStatus>(),
            new ApiEnumConverter<string, BackfillRevertResponseStatus>(),
            new ApiEnumConverter<string, Invoices::Action>(),
            new ApiEnumConverter<string, Invoices::Type>(),
            new ApiEnumConverter<string, Invoices::InvoiceSource>(),
            new ApiEnumConverter<string, Invoices::PaymentProvider>(),
            new ApiEnumConverter<string, Invoices::InvoiceFetchUpcomingResponseStatus>(),
            new ApiEnumConverter<string, Invoices::ModelType>(),
            new ApiEnumConverter<string, Invoices::DateType>(),
            new ApiEnumConverter<string, Invoices::Status>(),
            new ApiEnumConverter<string, ExternalConnectionModelExternalConnectionName>(),
            new ApiEnumConverter<string, ExternalConnectionName>(),
            new ApiEnumConverter<string, Metrics::Status>(),
            new ApiEnumConverter<string, Plans::PlanPhaseModelDurationUnit>(),
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
            new ApiEnumConverter<string, Plans::StatusModel>(),
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
            new ApiEnumConverter<string, Prices::PriceEvaluationModelPriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluationModelPriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Prices::PriceEvaluationModelPriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<string, Prices::PriceEvaluationModelPricePercentCadence>(),
            new ApiEnumConverter<string, Prices::PriceEvaluationModelPriceEventOutputCadence>(),
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
            new ApiEnumConverter<string, Subscriptions::DataModelViewMode>(),
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
            new ApiEnumConverter<string, Subscriptions::ViewModeModel>(),
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
            new ApiEnumConverter<string, Subscriptions::ChangeOptionModel>(),
            new ApiEnumConverter<string, Subscriptions::AddPriceModelPriceBulkWithFiltersCadence>(),
            new ApiEnumConverter<
                string,
                Subscriptions::AddPriceModelPriceTieredWithProrationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::AddPriceModelPriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::AddPriceModelPriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::AddPriceModelPricePercentCadence>(),
            new ApiEnumConverter<string, Subscriptions::AddPriceModelPriceEventOutputCadence>(),
            new ApiEnumConverter<string, Subscriptions::BillingCycleAlignment>(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePriceModelPriceBulkWithFiltersCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePriceModelPriceTieredWithProrationCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePriceModelPriceGroupedWithMinMaxThresholdsCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::ReplacePriceModelPriceCumulativeGroupedAllocationCadence
            >(),
            new ApiEnumConverter<string, Subscriptions::ReplacePriceModelPricePercentCadence>(),
            new ApiEnumConverter<string, Subscriptions::ReplacePriceModelPriceEventOutputCadence>(),
            new ApiEnumConverter<string, Subscriptions::ChangeOption1>(),
            new ApiEnumConverter<string, Subscriptions::UnionMember1>(),
            new ApiEnumConverter<string, Alerts::AlertType>(),
            new ApiEnumConverter<string, Alerts::Type>(),
            new ApiEnumConverter<string, Alerts::TypeModel>(),
            new ApiEnumConverter<string, Alerts::Type1>(),
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

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new OrbInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new OrbInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new OrbInvalidDataException($"'{key}' must be of type {typeof(T).FullName}", e);
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new OrbInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new OrbInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new OrbInvalidDataException($"'{key}' must be of type {typeof(T).FullName}", e);
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new OrbInvalidDataException($"'{key}' must be of type {typeof(T).FullName}", e);
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new OrbInvalidDataException($"'{key}' must be of type {typeof(T).FullName}", e);
        }
    }

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public virtual bool Equals(ModelBase? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
