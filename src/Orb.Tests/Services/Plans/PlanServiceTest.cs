using System.Collections.Generic;
using System.Threading.Tasks;
using Orb.Models;

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
                                DurationUnit = DurationUnitModel.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                            Filters =
                            [
                                new()
                                {
                                    Field = Field11.ItemID,
                                    Operator = Operator11.Includes,
                                    Values = ["string"],
                                },
                            ],
                        },
                        PlanPhaseOrder = 0,
                        Price1 = new(
                            new NewPlanUnitPrice()
                            {
                                Cadence = Cadence48.Annual,
                                ItemID = "item_id",
                                ModelType = ModelType47.Unit,
                                Name = "Annual fee",
                                UnitConfig = new("unit_amount"),
                                BillableMetricID = "billable_metric_id",
                                BilledInAdvance = true,
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit1.Day,
                                },
                                ConversionRate = 0,
                                ConversionRateConfig = new(
                                    new UnitConversionRateConfig()
                                    {
                                        ConversionRateType = ConversionRateTypeModel.Unit,
                                        UnitConfig = new("unit_amount"),
                                    }
                                ),
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
                                    DurationUnit = DurationUnit1.Day,
                                },
                                Metadata = new Dictionary<string, string?>()
                                {
                                    { "foo", "string" },
                                },
                                ReferenceID = "reference_id",
                            }
                        ),
                    },
                ],
            }
        );
        plan.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var plan = await this.client.Plans.Update(new() { PlanID = "plan_id" });
        plan.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Plans.List();
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var plan = await this.client.Plans.Fetch(new() { PlanID = "plan_id" });
        plan.Validate();
    }
}
