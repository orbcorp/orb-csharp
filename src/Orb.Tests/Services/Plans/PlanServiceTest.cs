using System;
using System.Threading.Tasks;
using Orb.Models;
using Orb.Models.CustomExpirationProperties;
using Orb.Models.NewAllocationPriceProperties;
using Orb.Models.NewPercentageDiscountProperties;
using Orb.Models.Plans.PlanListParamsProperties;
using Orb.Models.TransformPriceFilterProperties;
using Orb.Models.UnitConversionRateConfigProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewPlanUnitPriceProperties = Orb.Models.NewPlanUnitPriceProperties;
using PlanCreateParamsProperties = Orb.Models.Plans.PlanCreateParamsProperties;
using PlanPhaseProperties = Orb.Models.Plans.PlanCreateParamsProperties.PlanPhaseProperties;

namespace Orb.Tests.Services.Plans;

public class PlanServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
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
                            Cadence = Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        PlanPhaseOrder = 0,
                        Price = new NewPlanUnitPrice()
                        {
                            Cadence = NewPlanUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewPlanUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new("unit_amount"),
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new UnitConversionRateConfig()
                            {
                                ConversionRateType = ConversionRateType.Unit,
                                UnitConfig = new("unit_amount"),
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
                        Adjustment1 = new NewPercentageDiscount()
                        {
                            AdjustmentType = AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new()
                                {
                                    Field = Field.PriceID,
                                    Operator = Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = PriceType.Usage,
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
    public async Task Update_Works()
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
    public async Task List_Works()
    {
        var page = await this.client.Plans.List(
            new()
            {
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
                Status = Status.Active,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var plan = await this.client.Plans.Fetch(new() { PlanID = "plan_id" });
        plan.Validate();
    }
}
