using System;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models;
using Orb.Models.NewBillingCycleConfigurationProperties;
using Orb.Models.NewFloatingUnitPriceProperties;
using Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Tests.Service.Prices;

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
                    Cadence = Cadence.Annual,
                    Currency = "currency",
                    ItemID = "item_id",
                    ModelType = ModelType.Unit,
                    Name = "Annual fee",
                    UnitConfig = new() { UnitAmount = "unit_amount" },
                    BillableMetricID = "billable_metric_id",
                    BilledInAdvance = true,
                    BillingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = DurationUnit.Day,
                    },
                    ConversionRate = 0,
                    ConversionRateConfig = new UnitConversionRateConfig()
                    {
                        ConversionRateType = ConversionRateType.Unit,
                        UnitConfig = new() { UnitAmount = "unit_amount" },
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
                        DurationUnit = DurationUnit.Day,
                    },
                    Metadata = new() { { "foo", "string" } },
                },
            }
        );
        price.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var price = await this.client.Prices.Update(
            new()
            {
                PriceID = "price_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        price.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Prices.List(new() { Cursor = "cursor", Limit = 1 });
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
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
                Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
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
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
                PriceEvaluations =
                [
                    new()
                    {
                        ExternalPriceID = "external_price_id",
                        Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                        GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                        Price = new NewFloatingUnitPrice()
                        {
                            Cadence = Cadence.Annual,
                            Currency = "currency",
                            ItemID = "item_id",
                            ModelType = ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new UnitConversionRateConfig()
                            {
                                ConversionRateType = ConversionRateType.Unit,
                                UnitConfig = new() { UnitAmount = "unit_amount" },
                            },
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
                                DurationUnit = DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                        },
                        PriceID = "price_id",
                    },
                ],
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
                CustomerID = "customer_id",
                Events =
                [
                    new()
                    {
                        EventName = "event_name",
                        Properties1 = new() { { "foo", JsonSerializer.SerializeToElement("bar") } },
                        Timestamp = DateTime.Parse("2020-12-09T16:09:53Z"),
                        CustomerID = "customer_id",
                        ExternalCustomerID = "external_customer_id",
                    },
                ],
                ExternalCustomerID = "external_customer_id",
                PriceEvaluations =
                [
                    new()
                    {
                        ExternalPriceID = "external_price_id",
                        Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                        GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                        Price = new NewFloatingUnitPrice()
                        {
                            Cadence = Cadence.Annual,
                            Currency = "currency",
                            ItemID = "item_id",
                            ModelType = ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new UnitConversionRateConfig()
                            {
                                ConversionRateType = ConversionRateType.Unit,
                                UnitConfig = new() { UnitAmount = "unit_amount" },
                            },
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
                                DurationUnit = DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                        },
                        PriceID = "price_id",
                    },
                ],
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
