using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using Models = Orb.Models;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewPercentageDiscountProperties = Orb.Models.NewPercentageDiscountProperties;
using NewPlanUnitPriceProperties = Orb.Models.NewPlanUnitPriceProperties;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using TransformPriceFilterProperties = Orb.Models.TransformPriceFilterProperties;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Tests.Service.Beta;

public class BetaServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task CreatePlanVersion_Works()
    {
        var planVersion = await this.client.Beta.CreatePlanVersion(
            new()
            {
                PlanID = "plan_id",
                Version = 0,
                AddAdjustments =
                [
                    new()
                    {
                        Adjustment = new Models::NewPercentageDiscount()
                        {
                            AdjustmentType =
                                NewPercentageDiscountProperties::AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = NewPercentageDiscountProperties::AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new()
                                {
                                    Field = TransformPriceFilterProperties::Field.PriceID,
                                    Operator = TransformPriceFilterProperties::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                        },
                        PlanPhaseOrder = 0,
                    },
                ],
                AddPrices =
                [
                    new()
                    {
                        AllocationPrice = new()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = CustomExpirationProperties::DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        PlanPhaseOrder = 0,
                        Price = new Models::NewPlanUnitPrice()
                        {
                            Cadence = NewPlanUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewPlanUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::UnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                UnitConfig = new() { UnitAmount = "unit_amount" },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                                ExternalDimensionalPriceGroupID =
                                    "external_dimensional_price_group_id",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                            ReferenceID = "reference_id",
                        },
                    },
                ],
                RemoveAdjustments = [new() { AdjustmentID = "adjustment_id", PlanPhaseOrder = 0 }],
                RemovePrices = [new() { PriceID = "price_id", PlanPhaseOrder = 0 }],
                ReplaceAdjustments =
                [
                    new()
                    {
                        Adjustment = new Models::NewPercentageDiscount()
                        {
                            AdjustmentType =
                                NewPercentageDiscountProperties::AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = NewPercentageDiscountProperties::AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new()
                                {
                                    Field = TransformPriceFilterProperties::Field.PriceID,
                                    Operator = TransformPriceFilterProperties::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                        },
                        ReplacesAdjustmentID = "replaces_adjustment_id",
                        PlanPhaseOrder = 0,
                    },
                ],
                ReplacePrices =
                [
                    new()
                    {
                        ReplacesPriceID = "replaces_price_id",
                        AllocationPrice = new()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = CustomExpirationProperties::DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        PlanPhaseOrder = 0,
                        Price = new Models::NewPlanUnitPrice()
                        {
                            Cadence = NewPlanUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewPlanUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::UnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                UnitConfig = new() { UnitAmount = "unit_amount" },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                                ExternalDimensionalPriceGroupID =
                                    "external_dimensional_price_group_id",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                            ReferenceID = "reference_id",
                        },
                    },
                ],
                SetAsDefault = true,
            }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Tasks::Task FetchPlanVersion_Works()
    {
        var planVersion = await this.client.Beta.FetchPlanVersion(
            new() { PlanID = "plan_id", Version = "version" }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Tasks::Task SetDefaultPlanVersion_Works()
    {
        var plan = await this.client.Beta.SetDefaultPlanVersion(
            new() { PlanID = "plan_id", Version = 0 }
        );
        plan.Validate();
    }
}
