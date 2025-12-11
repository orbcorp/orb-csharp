using System.Collections.Generic;
using System.Threading.Tasks;
using Orb.Models;

namespace Orb.Tests.Services;

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
                                DurationUnit = CustomExpirationDurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                            Filters =
                            [
                                new()
                                {
                                    Field = NewAllocationPriceFilterField.ItemID,
                                    Operator = NewAllocationPriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ItemID = "item_id",
                            PerUnitCostBasis = "per_unit_cost_basis",
                        },
                        PlanPhaseOrder = 0,
                        PriceValue = new NewPlanUnitPrice()
                        {
                            Cadence = NewPlanUnitPriceCadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewPlanUnitPriceModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                            },
                            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                            ReferenceID = "reference_id",
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var plan = await this.client.Plans.Update(
            "plan_id",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Plans.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var plan = await this.client.Plans.Fetch(
            "plan_id",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }
}
