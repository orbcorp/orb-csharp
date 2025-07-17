using Json = System.Text.Json;
using Models = Orb.Models;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewFloatingUnitPriceProperties = Orb.Models.NewFloatingUnitPriceProperties;
using PriceCreateParamsProperties = Orb.Models.Prices.PriceCreateParamsProperties;
using PriceEvaluateMultipleParamsProperties = Orb.Models.Prices.PriceEvaluateMultipleParamsProperties;
using PriceEvaluatePreviewEventsParamsProperties = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties;
using PriceEvaluationProperties = Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties;
using PriceEvaluationProperties1 = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties;
using Prices = Orb.Models.Prices;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Tests.Service.Prices;

public class PriceServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var price = await this.client.Prices.Create(
            new Prices::PriceCreateParams()
            {
                Body = PriceCreateParamsProperties::Body.Create(
                    new Models::NewFloatingUnitPrice()
                    {
                        Cadence = NewFloatingUnitPriceProperties::Cadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = NewFloatingUnitPriceProperties::ModelType.Unit,
                        Name = "Annual fee",
                        UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                        BillableMetricID = "billable_metric_id",
                        BilledInAdvance = true,
                        BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                        {
                            Duration = 0,
                            DurationUnit = NewBillingCycleConfigurationProperties::DurationUnit.Day,
                        },
                        ConversionRate = 0,
                        ConversionRateConfig =
                            NewFloatingUnitPriceProperties::ConversionRateConfig.Create(
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
                            DurationUnit = NewBillingCycleConfigurationProperties::DurationUnit.Day,
                        },
                        Metadata = new() { { "foo", "string" } },
                    }
                ),
            }
        );
        price.Validate();
    }

    [Fact]
    public async Tasks::Task Update_Works()
    {
        var price = await this.client.Prices.Update(
            new Prices::PriceUpdateParams()
            {
                PriceID = "price_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        price.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Prices.List(
            new Prices::PriceListParams() { Cursor = "cursor", Limit = 1 }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Evaluate_Works()
    {
        var response = await this.client.Prices.Evaluate(
            new Prices::PriceEvaluateParams()
            {
                PriceID = "price_id",
                TimeframeEnd = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
                Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task EvaluateMultiple_Works()
    {
        var response = await this.client.Prices.EvaluateMultiple(
            new Prices::PriceEvaluateMultipleParams()
            {
                TimeframeEnd = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
                PriceEvaluations =
                [
                    new PriceEvaluateMultipleParamsProperties::PriceEvaluation()
                    {
                        ExternalPriceID = "external_price_id",
                        Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                        GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                        Price = PriceEvaluationProperties::Price.Create(
                            new Models::NewFloatingUnitPrice()
                            {
                                Cadence = NewFloatingUnitPriceProperties::Cadence.Annual,
                                Currency = "currency",
                                ItemID = "item_id",
                                ModelType = NewFloatingUnitPriceProperties::ModelType.Unit,
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
                                    NewFloatingUnitPriceProperties::ConversionRateConfig.Create(
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
                            }
                        ),
                        PriceID = "price_id",
                    },
                ],
            }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task EvaluatePreviewEvents_Works()
    {
        var response = await this.client.Prices.EvaluatePreviewEvents(
            new Prices::PriceEvaluatePreviewEventsParams()
            {
                TimeframeEnd = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Events =
                [
                    new PriceEvaluatePreviewEventsParamsProperties::Event()
                    {
                        EventName = "event_name",
                        Properties1 = new()
                        {
                            { "foo", Json::JsonSerializer.SerializeToElement("bar") },
                        },
                        Timestamp = System::DateTime.Parse("2020-12-09T16:09:53Z"),
                        CustomerID = "customer_id",
                        ExternalCustomerID = "external_customer_id",
                    },
                ],
                ExternalCustomerID = "external_customer_id",
                PriceEvaluations =
                [
                    new PriceEvaluatePreviewEventsParamsProperties::PriceEvaluation()
                    {
                        ExternalPriceID = "external_price_id",
                        Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                        GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                        Price = PriceEvaluationProperties1::Price.Create(
                            new Models::NewFloatingUnitPrice()
                            {
                                Cadence = NewFloatingUnitPriceProperties::Cadence.Annual,
                                Currency = "currency",
                                ItemID = "item_id",
                                ModelType = NewFloatingUnitPriceProperties::ModelType.Unit,
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
                                    NewFloatingUnitPriceProperties::ConversionRateConfig.Create(
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
                            }
                        ),
                        PriceID = "price_id",
                    },
                ],
            }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var price = await this.client.Prices.Fetch(
            new Prices::PriceFetchParams() { PriceID = "price_id" }
        );
        price.Validate();
    }
}
