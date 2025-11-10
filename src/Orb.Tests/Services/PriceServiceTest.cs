using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orb.Models;

namespace Orb.Tests.Services;

public class PriceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var price = await this.client.Prices.Create(
            new()
            {
                Body = new NewFloatingUnitPrice()
                {
                    Cadence = Cadence23.Annual,
                    Currency = "currency",
                    ItemID = "item_id",
                    ModelType = ModelType22.Unit,
                    Name = "Annual fee",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                    BillableMetricID = "billable_metric_id",
                    BilledInAdvance = true,
                    BillingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = DurationUnit1.Day,
                    },
                    ConversionRate = 0,
                    ConversionRateConfig = new UnitConversionRateConfig()
                    {
                        ConversionRateType = ConversionRateTypeModel.Unit,
                        UnitConfig = new("unit_amount"),
                    },
                    DimensionalPriceConfiguration = new()
                    {
                        DimensionValues = ["string"],
                        DimensionalPriceGroupID = "dimensional_price_group_id",
                        ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                    },
                    ExternalPriceID = "external_price_id",
                    FixedPriceQuantity = 0,
                    InvoiceGroupingKey = "x",
                    InvoicingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = DurationUnit1.Day,
                    },
                    Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                },
            }
        );
        price.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var price = await this.client.Prices.Update(new() { PriceID = "price_id" });
        price.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Prices.List();
        page.Validate();
    }

    [Fact]
    public async Task Evaluate_Works()
    {
        var response = await this.client.Prices.Evaluate(
            new()
            {
                PriceID = "price_id",
                TimeframeEnd = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task EvaluateMultiple_Works()
    {
        var response = await this.client.Prices.EvaluateMultiple(
            new()
            {
                TimeframeEnd = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task EvaluatePreviewEvents_Works()
    {
        var response = await this.client.Prices.EvaluatePreviewEvents(
            new()
            {
                TimeframeEnd = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var price = await this.client.Prices.Fetch(new() { PriceID = "price_id" });
        price.Validate();
    }
}
