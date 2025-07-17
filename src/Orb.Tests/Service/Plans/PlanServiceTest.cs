using AdjustmentProperties = Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties;
using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using Models = Orb.Models;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewPercentageDiscountProperties = Orb.Models.NewPercentageDiscountProperties;
using NewPlanUnitPriceProperties = Orb.Models.NewPlanUnitPriceProperties;
using PlanCreateParamsProperties = Orb.Models.Plans.PlanCreateParamsProperties;
using PlanListParamsProperties = Orb.Models.Plans.PlanListParamsProperties;
using PlanPhaseProperties = Orb.Models.Plans.PlanCreateParamsProperties.PlanPhaseProperties;
using Plans = Orb.Models.Plans;
using PriceProperties = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using TransformPriceFilterProperties = Orb.Models.TransformPriceFilterProperties;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Tests.Service.Plans;

public class PlanServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var plan = await this.client.Plans.Create(
            new Plans::PlanCreateParams()
            {
                Currency = "currency",
                Name = "name",
                Prices =
                [
                    new PlanCreateParamsProperties::Price()
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
                        Price1 = PriceProperties::Price.Create(
                            new Models::NewPlanUnitPrice()
                            {
                                Cadence = NewPlanUnitPriceProperties::Cadence.Annual,
                                ItemID = "item_id",
                                ModelType = NewPlanUnitPriceProperties::ModelType.Unit,
                                Name = "Annual fee",
                                UnitConfig = new Models::UnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                                BillableMetricID = "billable_metric_id",
                                BilledInAdvance = true,
                                BillingCycleConfiguration =
                                    new Models::NewBillingCycleConfiguration()
                                    {
                                        Duration = 0,
                                        DurationUnit =
                                            NewBillingCycleConfigurationProperties::DurationUnit.Day,
                                    },
                                ConversionRate = 0,
                                ConversionRateConfig =
                                    NewPlanUnitPriceProperties::ConversionRateConfig.Create(
                                        new Models::UnitConversionRateConfig()
                                        {
                                            ConversionRateType =
                                                UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                            UnitConfig = new Models::ConversionRateUnitConfig()
                                            {
                                                UnitAmount = "unit_amount",
                                            },
                                        }
                                    ),
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
                                InvoicingCycleConfiguration =
                                    new Models::NewBillingCycleConfiguration()
                                    {
                                        Duration = 0,
                                        DurationUnit =
                                            NewBillingCycleConfigurationProperties::DurationUnit.Day,
                                    },
                                Metadata = new() { { "foo", "string" } },
                                ReferenceID = "reference_id",
                            }
                        ),
                    },
                ],
                Adjustments =
                [
                    new PlanCreateParamsProperties::Adjustment()
                    {
                        Adjustment1 = AdjustmentProperties::Adjustment.Create(
                            new Models::NewPercentageDiscount()
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
                                        Operator =
                                            TransformPriceFilterProperties::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                IsInvoiceLevel = true,
                                PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                            }
                        ),
                        PlanPhaseOrder = 0,
                    },
                ],
                DefaultInvoiceMemo = "default_invoice_memo",
                ExternalPlanID = "external_plan_id",
                Metadata = new() { { "foo", "string" } },
                NetTerms = 0,
                PlanPhases =
                [
                    new PlanCreateParamsProperties::PlanPhase()
                    {
                        Order = 0,
                        AlignBillingWithPhaseStartDate = true,
                        Duration = 1,
                        DurationUnit = PlanPhaseProperties::DurationUnit.Daily,
                    },
                ],
                Status = PlanCreateParamsProperties::Status.Active,
            }
        );
        plan.Validate();
    }

    [Fact]
    public async Tasks::Task Update_Works()
    {
        var plan = await this.client.Plans.Update(
            new Plans::PlanUpdateParams()
            {
                PlanID = "plan_id",
                ExternalPlanID = "external_plan_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        plan.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Plans.List(
            new Plans::PlanListParams()
            {
                CreatedAtGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
                Status = PlanListParamsProperties::Status.Active,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var plan = await this.client.Plans.Fetch(
            new Plans::PlanFetchParams() { PlanID = "plan_id" }
        );
        plan.Validate();
    }
}
