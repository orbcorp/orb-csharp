using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using Models = Orb.Models;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewPercentageDiscountProperties = Orb.Models.NewPercentageDiscountProperties;
using NewPlanUnitPriceProperties = Orb.Models.NewPlanUnitPriceProperties;
using PlanCreateParamsProperties = Orb.Models.Plans.PlanCreateParamsProperties;
using PlanListParamsProperties = Orb.Models.Plans.PlanListParamsProperties;
using PlanPhaseProperties = Orb.Models.Plans.PlanCreateParamsProperties.PlanPhaseProperties;
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
            new()
            {
                Currency = "currency",
                Name = "name",
                Prices =
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
                        Price1 = new Models::NewPlanUnitPrice()
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
                Adjustments =
                [
                    new()
                    {
                        Adjustment1 = new Models::NewPercentageDiscount()
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
                DefaultInvoiceMemo = "default_invoice_memo",
                ExternalPlanID = "external_plan_id",
                Metadata = new() { { "foo", "string" } },
                NetTerms = 0,
                PlanPhases =
                [
                    new()
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
            new()
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
            new()
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
        var plan = await this.client.Plans.Fetch(new() { PlanID = "plan_id" });
        plan.Validate();
    }
}
