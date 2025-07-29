using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using ExternalPlanID = Orb.Models.Beta.ExternalPlanID;
using ExternalPlanIDCreatePlanVersionParamsProperties = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties;
using Models = Orb.Models;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewPercentageDiscountProperties = Orb.Models.NewPercentageDiscountProperties;
using NewPlanUnitPriceProperties = Orb.Models.NewPlanUnitPriceProperties;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using TransformPriceFilterProperties = Orb.Models.TransformPriceFilterProperties;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Tests.Service.Beta.ExternalPlanID;

public class ExternalPlanIDServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task CreatePlanVersion_Works()
    {
        var planVersion = await this.client.Beta.ExternalPlanID.CreatePlanVersion(
            new ExternalPlanID::ExternalPlanIDCreatePlanVersionParams()
            {
                ExternalPlanID = "external_plan_id",
                Version = 0,
                AddAdjustments =
                [
                    new ExternalPlanIDCreatePlanVersionParamsProperties::AddAdjustment()
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
                                new Models::TransformPriceFilter()
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
                    new ExternalPlanIDCreatePlanVersionParamsProperties::AddPrice()
                    {
                        AllocationPrice = new Models::NewAllocationPrice()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new Models::CustomExpiration()
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
                            UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
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
                                UnitConfig = new Models::ConversionRateUnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration =
                                new Models::NewDimensionalPriceConfiguration()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                    ExternalDimensionalPriceGroupID =
                                        "external_dimensional_price_group_id",
                                },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new Models::NewBillingCycleConfiguration()
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
                RemoveAdjustments =
                [
                    new ExternalPlanIDCreatePlanVersionParamsProperties::RemoveAdjustment()
                    {
                        AdjustmentID = "adjustment_id",
                        PlanPhaseOrder = 0,
                    },
                ],
                RemovePrices =
                [
                    new ExternalPlanIDCreatePlanVersionParamsProperties::RemovePrice()
                    {
                        PriceID = "price_id",
                        PlanPhaseOrder = 0,
                    },
                ],
                ReplaceAdjustments =
                [
                    new ExternalPlanIDCreatePlanVersionParamsProperties::ReplaceAdjustment()
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
                                new Models::TransformPriceFilter()
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
                    new ExternalPlanIDCreatePlanVersionParamsProperties::ReplacePrice()
                    {
                        ReplacesPriceID = "replaces_price_id",
                        AllocationPrice = new Models::NewAllocationPrice()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new Models::CustomExpiration()
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
                            UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
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
                                UnitConfig = new Models::ConversionRateUnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration =
                                new Models::NewDimensionalPriceConfiguration()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                    ExternalDimensionalPriceGroupID =
                                        "external_dimensional_price_group_id",
                                },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new Models::NewBillingCycleConfiguration()
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
        var planVersion = await this.client.Beta.ExternalPlanID.FetchPlanVersion(
            new ExternalPlanID::ExternalPlanIDFetchPlanVersionParams()
            {
                ExternalPlanID = "external_plan_id",
                Version = "version",
            }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Tasks::Task SetDefaultPlanVersion_Works()
    {
        var plan = await this.client.Beta.ExternalPlanID.SetDefaultPlanVersion(
            new ExternalPlanID::ExternalPlanIDSetDefaultPlanVersionParams()
            {
                ExternalPlanID = "external_plan_id",
                Version = 0,
            }
        );
        plan.Validate();
    }
}
