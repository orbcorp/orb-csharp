using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Prices;
using Models = Orb.Models;

namespace Orb.Tests.Models.Prices;

public class PriceEvaluateMultipleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PriceEvaluateMultipleParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
            PriceEvaluations =
            [
                new()
                {
                    ExternalPriceID = "external_price_id",
                    Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                    GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                    Price = new Models::NewFloatingUnitPrice()
                    {
                        Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                        Name = "Annual fee",
                        UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                        BillableMetricID = "billable_metric_id",
                        BilledInAdvance = true,
                        BillingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        ConversionRate = 0,
                        ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                        {
                            ConversionRateType =
                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                    },
                    PriceID = "price_id",
                },
            ],
        };

        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";
        List<PriceEvaluation> expectedPriceEvaluations =
        [
            new()
            {
                ExternalPriceID = "external_price_id",
                Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                Price = new Models::NewFloatingUnitPrice()
                {
                    Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                    Currency = "currency",
                    ItemID = "item_id",
                    ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                    Name = "Annual fee",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                    BillableMetricID = "billable_metric_id",
                    BilledInAdvance = true,
                    BillingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                    },
                    ConversionRate = 0,
                    ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                    {
                        ConversionRateType =
                            Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                        DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                    },
                    Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                },
                PriceID = "price_id",
            },
        ];

        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.NotNull(parameters.PriceEvaluations);
        Assert.Equal(expectedPriceEvaluations.Count, parameters.PriceEvaluations.Count);
        for (int i = 0; i < expectedPriceEvaluations.Count; i++)
        {
            Assert.Equal(expectedPriceEvaluations[i], parameters.PriceEvaluations[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PriceEvaluateMultipleParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        Assert.Null(parameters.PriceEvaluations);
        Assert.False(parameters.RawBodyData.ContainsKey("price_evaluations"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PriceEvaluateMultipleParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",

            // Null should be interpreted as omitted for these properties
            PriceEvaluations = null,
        };

        Assert.Null(parameters.PriceEvaluations);
        Assert.False(parameters.RawBodyData.ContainsKey("price_evaluations"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PriceEvaluateMultipleParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceEvaluations =
            [
                new()
                {
                    ExternalPriceID = "external_price_id",
                    Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                    GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                    Price = new Models::NewFloatingUnitPrice()
                    {
                        Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                        Name = "Annual fee",
                        UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                        BillableMetricID = "billable_metric_id",
                        BilledInAdvance = true,
                        BillingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        ConversionRate = 0,
                        ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                        {
                            ConversionRateType =
                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                    },
                    PriceID = "price_id",
                },
            ],
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PriceEvaluateMultipleParams
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceEvaluations =
            [
                new()
                {
                    ExternalPriceID = "external_price_id",
                    Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                    GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
                    Price = new Models::NewFloatingUnitPrice()
                    {
                        Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                        Name = "Annual fee",
                        UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                        BillableMetricID = "billable_metric_id",
                        BilledInAdvance = true,
                        BillingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        ConversionRate = 0,
                        ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                        {
                            ConversionRateType =
                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                    },
                    PriceID = "price_id",
                },
            ],

            CustomerID = null,
            ExternalCustomerID = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PriceEvaluateMultipleParams parameters = new()
        {
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/prices/evaluate"), url);
    }
}

public class PriceEvaluationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        string expectedExternalPriceID = "external_price_id";
        string expectedFilter = "my_numeric_property > 100 AND my_other_property = 'bar'";
        List<string> expectedGroupingKeys =
        [
            "case when my_event_type = 'foo' then true else false end",
        ];
        Price expectedPrice = new Models::NewFloatingUnitPrice()
        {
            Cadence = Models::NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string expectedPriceID = "price_id";

        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.NotNull(model.GroupingKeys);
        Assert.Equal(expectedGroupingKeys.Count, model.GroupingKeys.Count);
        for (int i = 0; i < expectedGroupingKeys.Count; i++)
        {
            Assert.Equal(expectedGroupingKeys[i], model.GroupingKeys[i]);
        }
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceID, model.PriceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExternalPriceID = "external_price_id";
        string expectedFilter = "my_numeric_property > 100 AND my_other_property = 'bar'";
        List<string> expectedGroupingKeys =
        [
            "case when my_event_type = 'foo' then true else false end",
        ];
        Price expectedPrice = new Models::NewFloatingUnitPrice()
        {
            Cadence = Models::NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string expectedPriceID = "price_id";

        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.NotNull(deserialized.GroupingKeys);
        Assert.Equal(expectedGroupingKeys.Count, deserialized.GroupingKeys.Count);
        for (int i = 0; i < expectedGroupingKeys.Count; i++)
        {
            Assert.Equal(expectedGroupingKeys[i], deserialized.GroupingKeys[i]);
        }
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        Assert.Null(model.GroupingKeys);
        Assert.False(model.RawData.ContainsKey("grouping_keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",

            // Null should be interpreted as omitted for these properties
            GroupingKeys = null,
        };

        Assert.Null(model.GroupingKeys);
        Assert.False(model.RawData.ContainsKey("grouping_keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",

            // Null should be interpreted as omitted for these properties
            GroupingKeys = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEvaluation
        {
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
        };

        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.Filter);
        Assert.False(model.RawData.ContainsKey("filter"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceEvaluation
        {
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceEvaluation
        {
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],

            ExternalPriceID = null,
            Filter = null,
            Price = null,
            PriceID = null,
        };

        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.Filter);
        Assert.True(model.RawData.ContainsKey("filter"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceEvaluation
        {
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],

            ExternalPriceID = null,
            Filter = null,
            Price = null,
            PriceID = null,
        };

        model.Validate();
    }
}

public class PriceTest : TestBase
{
    [Fact]
    public void NewFloatingUnitValidationWorks()
    {
        Price value = new Models::NewFloatingUnitPrice()
        {
            Cadence = Models::NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredValidationWorks()
    {
        Price value = new Models::NewFloatingTieredPrice()
        {
            Cadence = Models::NewFloatingTieredPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredPriceModelType.Tiered,
            Name = "Annual fee",
            TieredConfig = new()
            {
                Tiers =
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ],
                Prorated = true,
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingBulkValidationWorks()
    {
        Price value = new Models::NewFloatingBulkPrice()
        {
            BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
            Cadence = Models::NewFloatingBulkPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::ModelType.Bulk,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void BulkWithFiltersValidationWorks()
    {
        Price value = new PriceBulkWithFilters()
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingPackageValidationWorks()
    {
        Price value = new Models::NewFloatingPackagePrice()
        {
            Cadence = Models::NewFloatingPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingPackagePriceModelType.Package,
            Name = "Annual fee",
            PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixValidationWorks()
    {
        Price value = new Models::NewFloatingMatrixPrice()
        {
            Cadence = Models::NewFloatingMatrixPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = Models::NewFloatingMatrixPriceModelType.Matrix,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingThresholdTotalAmountValidationWorks()
    {
        Price value = new Models::NewFloatingThresholdTotalAmountPrice()
        {
            Cadence = Models::NewFloatingThresholdTotalAmountPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
            Name = "Annual fee",
            ThresholdTotalAmountConfig = new()
            {
                ConsumptionTable =
                [
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                ],
                Prorate = true,
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredPackageValidationWorks()
    {
        Price value = new Models::NewFloatingTieredPackagePrice()
        {
            Cadence = Models::NewFloatingTieredPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredPackagePriceModelType.TieredPackage,
            Name = "Annual fee",
            TieredPackageConfig = new()
            {
                PackageSize = "package_size",
                Tiers =
                [
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                ],
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredWithMinimumValidationWorks()
    {
        Price value = new Models::NewFloatingTieredWithMinimumPrice()
        {
            Cadence = Models::NewFloatingTieredWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum,
            Name = "Annual fee",
            TieredWithMinimumConfig = new()
            {
                Tiers =
                [
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                ],
                HideZeroAmountTiers = true,
                Prorate = true,
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedTieredValidationWorks()
    {
        Price value = new Models::NewFloatingGroupedTieredPrice()
        {
            Cadence = Models::NewFloatingGroupedTieredPriceCadence.Annual,
            Currency = "currency",
            GroupedTieredConfig = new()
            {
                GroupingKey = "x",
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType = Models::NewFloatingGroupedTieredPriceModelType.GroupedTiered,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredPackageWithMinimumValidationWorks()
    {
        Price value = new Models::NewFloatingTieredPackageWithMinimumPrice()
        {
            Cadence = Models::NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
            Name = "Annual fee",
            TieredPackageWithMinimumConfig = new()
            {
                PackageSize = 0,
                Tiers =
                [
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        PerUnit = "per_unit",
                        TierLowerBound = "tier_lower_bound",
                    },
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        PerUnit = "per_unit",
                        TierLowerBound = "tier_lower_bound",
                    },
                ],
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingPackageWithAllocationValidationWorks()
    {
        Price value = new Models::NewFloatingPackageWithAllocationPrice()
        {
            Cadence = Models::NewFloatingPackageWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation,
            Name = "Annual fee",
            PackageWithAllocationConfig = new()
            {
                Allocation = "allocation",
                PackageAmount = "package_amount",
                PackageSize = "package_size",
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitWithPercentValidationWorks()
    {
        Price value = new Models::NewFloatingUnitWithPercentPrice()
        {
            Cadence = Models::NewFloatingUnitWithPercentPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitWithPercentPriceModelType.UnitWithPercent,
            Name = "Annual fee",
            UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixWithAllocationValidationWorks()
    {
        Price value = new Models::NewFloatingMatrixWithAllocationPrice()
        {
            Cadence = Models::NewFloatingMatrixWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = Models::NewFloatingMatrixWithAllocationPriceModelType.MatrixWithAllocation,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredWithProrationValidationWorks()
    {
        Price value = new Models::NewFloatingTieredWithProrationPrice()
        {
            Cadence = Models::NewFloatingTieredWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredWithProrationPriceModelType.TieredWithProration,
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitWithProrationValidationWorks()
    {
        Price value = new Models::NewFloatingUnitWithProrationPrice()
        {
            Cadence = Models::NewFloatingUnitWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitWithProrationPriceModelType.UnitWithProration,
            Name = "Annual fee",
            UnitWithProrationConfig = new("unit_amount"),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedAllocationValidationWorks()
    {
        Price value = new Models::NewFloatingGroupedAllocationPrice()
        {
            Cadence = Models::NewFloatingGroupedAllocationPriceCadence.Annual,
            Currency = "currency",
            GroupedAllocationConfig = new()
            {
                Allocation = "allocation",
                GroupingKey = "x",
                OverageUnitRate = "overage_unit_rate",
            },
            ItemID = "item_id",
            ModelType = Models::NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingBulkWithProrationValidationWorks()
    {
        Price value = new Models::NewFloatingBulkWithProrationPrice()
        {
            BulkWithProrationConfig = new(
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ]
            ),
            Cadence = Models::NewFloatingBulkWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingBulkWithProrationPriceModelType.BulkWithProration,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedWithProratedMinimumValidationWorks()
    {
        Price value = new Models::NewFloatingGroupedWithProratedMinimumPrice()
        {
            Cadence = Models::NewFloatingGroupedWithProratedMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithProratedMinimumConfig = new()
            {
                GroupingKey = "x",
                Minimum = "minimum",
                UnitRate = "unit_rate",
            },
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedWithMeteredMinimumValidationWorks()
    {
        Price value = new Models::NewFloatingGroupedWithMeteredMinimumPrice()
        {
            Cadence = Models::NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsValidationWorks()
    {
        Price value = new PriceGroupedWithMinMaxThresholds()
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixWithDisplayNameValidationWorks()
    {
        Price value = new Models::NewFloatingMatrixWithDisplayNamePrice()
        {
            Cadence = Models::NewFloatingMatrixWithDisplayNamePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixWithDisplayNameConfig = new()
            {
                Dimension = "dimension",
                UnitAmounts =
                [
                    new()
                    {
                        DimensionValue = "dimension_value",
                        DisplayName = "display_name",
                        UnitAmount = "unit_amount",
                    },
                ],
            },
            ModelType =
                Models::NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedTieredPackageValidationWorks()
    {
        Price value = new Models::NewFloatingGroupedTieredPackagePrice()
        {
            Cadence = Models::NewFloatingGroupedTieredPackagePriceCadence.Annual,
            Currency = "currency",
            GroupedTieredPackageConfig = new()
            {
                GroupingKey = "x",
                PackageSize = "package_size",
                Tiers =
                [
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                ],
            },
            ItemID = "item_id",
            ModelType = Models::NewFloatingGroupedTieredPackagePriceModelType.GroupedTieredPackage,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMaxGroupTieredPackageValidationWorks()
    {
        Price value = new Models::NewFloatingMaxGroupTieredPackagePrice()
        {
            Cadence = Models::NewFloatingMaxGroupTieredPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MaxGroupTieredPackageConfig = new()
            {
                GroupingKey = "x",
                PackageSize = "package_size",
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
            },
            ModelType =
                Models::NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingScalableMatrixWithUnitPricingValidationWorks()
    {
        Price value = new Models::NewFloatingScalableMatrixWithUnitPricingPrice()
        {
            Cadence = Models::NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingScalableMatrixWithTieredPricingValidationWorks()
    {
        Price value = new Models::NewFloatingScalableMatrixWithTieredPricingPrice()
        {
            Cadence = Models::NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
            Name = "Annual fee",
            ScalableMatrixWithTieredPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
                SecondDimension = "second_dimension",
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingCumulativeGroupedBulkValidationWorks()
    {
        Price value = new Models::NewFloatingCumulativeGroupedBulkPrice()
        {
            Cadence = Models::NewFloatingCumulativeGroupedBulkPriceCadence.Annual,
            CumulativeGroupedBulkConfig = new()
            {
                DimensionValues =
                [
                    new()
                    {
                        GroupingKey = "x",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                ],
                Group = "group",
            },
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void CumulativeGroupedAllocationValidationWorks()
    {
        Price value = new PriceCumulativeGroupedAllocation()
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void MinimumValidationWorks()
    {
        Price value = new PriceMinimum()
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMinimumCompositeValidationWorks()
    {
        Price value = new Models::NewFloatingMinimumCompositePrice()
        {
            Cadence = Models::NewFloatingMinimumCompositePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumCompositeConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            ModelType = Models::NewFloatingMinimumCompositePriceModelType.MinimumComposite,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void PercentValidationWorks()
    {
        Price value = new PricePercent()
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void EventOutputValidationWorks()
    {
        Price value = new PriceEventOutput()
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingUnitPrice()
        {
            Cadence = Models::NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingTieredPrice()
        {
            Cadence = Models::NewFloatingTieredPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredPriceModelType.Tiered,
            Name = "Annual fee",
            TieredConfig = new()
            {
                Tiers =
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ],
                Prorated = true,
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingBulkSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingBulkPrice()
        {
            BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
            Cadence = Models::NewFloatingBulkPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::ModelType.Bulk,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        Price value = new PriceBulkWithFilters()
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingPackageSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingPackagePrice()
        {
            Cadence = Models::NewFloatingPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingPackagePriceModelType.Package,
            Name = "Annual fee",
            PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingMatrixPrice()
        {
            Cadence = Models::NewFloatingMatrixPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = Models::NewFloatingMatrixPriceModelType.Matrix,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingThresholdTotalAmountSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingThresholdTotalAmountPrice()
        {
            Cadence = Models::NewFloatingThresholdTotalAmountPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
            Name = "Annual fee",
            ThresholdTotalAmountConfig = new()
            {
                ConsumptionTable =
                [
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                ],
                Prorate = true,
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredPackageSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingTieredPackagePrice()
        {
            Cadence = Models::NewFloatingTieredPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredPackagePriceModelType.TieredPackage,
            Name = "Annual fee",
            TieredPackageConfig = new()
            {
                PackageSize = "package_size",
                Tiers =
                [
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                ],
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredWithMinimumSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingTieredWithMinimumPrice()
        {
            Cadence = Models::NewFloatingTieredWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum,
            Name = "Annual fee",
            TieredWithMinimumConfig = new()
            {
                Tiers =
                [
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                ],
                HideZeroAmountTiers = true,
                Prorate = true,
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedTieredSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingGroupedTieredPrice()
        {
            Cadence = Models::NewFloatingGroupedTieredPriceCadence.Annual,
            Currency = "currency",
            GroupedTieredConfig = new()
            {
                GroupingKey = "x",
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType = Models::NewFloatingGroupedTieredPriceModelType.GroupedTiered,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingTieredPackageWithMinimumPrice()
        {
            Cadence = Models::NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
            Name = "Annual fee",
            TieredPackageWithMinimumConfig = new()
            {
                PackageSize = 0,
                Tiers =
                [
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        PerUnit = "per_unit",
                        TierLowerBound = "tier_lower_bound",
                    },
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        PerUnit = "per_unit",
                        TierLowerBound = "tier_lower_bound",
                    },
                ],
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingPackageWithAllocationSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingPackageWithAllocationPrice()
        {
            Cadence = Models::NewFloatingPackageWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation,
            Name = "Annual fee",
            PackageWithAllocationConfig = new()
            {
                Allocation = "allocation",
                PackageAmount = "package_amount",
                PackageSize = "package_size",
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingUnitWithPercentSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingUnitWithPercentPrice()
        {
            Cadence = Models::NewFloatingUnitWithPercentPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitWithPercentPriceModelType.UnitWithPercent,
            Name = "Annual fee",
            UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixWithAllocationSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingMatrixWithAllocationPrice()
        {
            Cadence = Models::NewFloatingMatrixWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = Models::NewFloatingMatrixWithAllocationPriceModelType.MatrixWithAllocation,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredWithProrationSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingTieredWithProrationPrice()
        {
            Cadence = Models::NewFloatingTieredWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingTieredWithProrationPriceModelType.TieredWithProration,
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingUnitWithProrationSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingUnitWithProrationPrice()
        {
            Cadence = Models::NewFloatingUnitWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitWithProrationPriceModelType.UnitWithProration,
            Name = "Annual fee",
            UnitWithProrationConfig = new("unit_amount"),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedAllocationSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingGroupedAllocationPrice()
        {
            Cadence = Models::NewFloatingGroupedAllocationPriceCadence.Annual,
            Currency = "currency",
            GroupedAllocationConfig = new()
            {
                Allocation = "allocation",
                GroupingKey = "x",
                OverageUnitRate = "overage_unit_rate",
            },
            ItemID = "item_id",
            ModelType = Models::NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingBulkWithProrationSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingBulkWithProrationPrice()
        {
            BulkWithProrationConfig = new(
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ]
            ),
            Cadence = Models::NewFloatingBulkWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingBulkWithProrationPriceModelType.BulkWithProration,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingGroupedWithProratedMinimumPrice()
        {
            Cadence = Models::NewFloatingGroupedWithProratedMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithProratedMinimumConfig = new()
            {
                GroupingKey = "x",
                Minimum = "minimum",
                UnitRate = "unit_rate",
            },
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingGroupedWithMeteredMinimumPrice()
        {
            Cadence = Models::NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        Price value = new PriceGroupedWithMinMaxThresholds()
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingMatrixWithDisplayNamePrice()
        {
            Cadence = Models::NewFloatingMatrixWithDisplayNamePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixWithDisplayNameConfig = new()
            {
                Dimension = "dimension",
                UnitAmounts =
                [
                    new()
                    {
                        DimensionValue = "dimension_value",
                        DisplayName = "display_name",
                        UnitAmount = "unit_amount",
                    },
                ],
            },
            ModelType =
                Models::NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedTieredPackageSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingGroupedTieredPackagePrice()
        {
            Cadence = Models::NewFloatingGroupedTieredPackagePriceCadence.Annual,
            Currency = "currency",
            GroupedTieredPackageConfig = new()
            {
                GroupingKey = "x",
                PackageSize = "package_size",
                Tiers =
                [
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                ],
            },
            ItemID = "item_id",
            ModelType = Models::NewFloatingGroupedTieredPackagePriceModelType.GroupedTieredPackage,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingMaxGroupTieredPackagePrice()
        {
            Cadence = Models::NewFloatingMaxGroupTieredPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MaxGroupTieredPackageConfig = new()
            {
                GroupingKey = "x",
                PackageSize = "package_size",
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
            },
            ModelType =
                Models::NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingScalableMatrixWithUnitPricingPrice()
        {
            Cadence = Models::NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingScalableMatrixWithTieredPricingPrice()
        {
            Cadence = Models::NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
            Name = "Annual fee",
            ScalableMatrixWithTieredPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
                SecondDimension = "second_dimension",
            },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingCumulativeGroupedBulkPrice()
        {
            Cadence = Models::NewFloatingCumulativeGroupedBulkPriceCadence.Annual,
            CumulativeGroupedBulkConfig = new()
            {
                DimensionValues =
                [
                    new()
                    {
                        GroupingKey = "x",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                ],
                Group = "group",
            },
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                Models::NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        Price value = new PriceCumulativeGroupedAllocation()
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MinimumSerializationRoundtripWorks()
    {
        Price value = new PriceMinimum()
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMinimumCompositeSerializationRoundtripWorks()
    {
        Price value = new Models::NewFloatingMinimumCompositePrice()
        {
            Cadence = Models::NewFloatingMinimumCompositePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumCompositeConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            ModelType = Models::NewFloatingMinimumCompositePriceModelType.MinimumComposite,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        Price value = new PricePercent()
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        Price value = new PriceEventOutput()
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        PriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, PriceBulkWithFiltersCadence> expectedCadence =
            PriceBulkWithFiltersCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedBulkWithFiltersConfig, model.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceBulkWithFilters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceBulkWithFilters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, PriceBulkWithFiltersCadence> expectedCadence =
            PriceBulkWithFiltersCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedBulkWithFiltersConfig, deserialized.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class PriceBulkWithFiltersBulkWithFiltersConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<PriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<PriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceBulkWithFiltersBulkWithFiltersConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceBulkWithFiltersBulkWithFiltersConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<PriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        model.Validate();
    }
}

public class PriceBulkWithFiltersBulkWithFiltersConfigFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, model.PropertyKey);
        Assert.Equal(expectedPropertyValue, model.PropertyValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, deserialized.PropertyKey);
        Assert.Equal(expectedPropertyValue, deserialized.PropertyValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        model.Validate();
    }
}

public class PriceBulkWithFiltersBulkWithFiltersConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceBulkWithFiltersBulkWithFiltersConfigTier>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",

            TierLowerBound = null,
        };

        Assert.Null(model.TierLowerBound);
        Assert.True(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",

            TierLowerBound = null,
        };

        model.Validate();
    }
}

public class PriceBulkWithFiltersCadenceTest : TestBase
{
    [Theory]
    [InlineData(PriceBulkWithFiltersCadence.Annual)]
    [InlineData(PriceBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(PriceBulkWithFiltersCadence.Monthly)]
    [InlineData(PriceBulkWithFiltersCadence.Quarterly)]
    [InlineData(PriceBulkWithFiltersCadence.OneTime)]
    [InlineData(PriceBulkWithFiltersCadence.Custom)]
    public void Validation_Works(PriceBulkWithFiltersCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceBulkWithFiltersCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceBulkWithFiltersCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceBulkWithFiltersCadence.Annual)]
    [InlineData(PriceBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(PriceBulkWithFiltersCadence.Monthly)]
    [InlineData(PriceBulkWithFiltersCadence.Quarterly)]
    [InlineData(PriceBulkWithFiltersCadence.OneTime)]
    [InlineData(PriceBulkWithFiltersCadence.Custom)]
    public void SerializationRoundtrip_Works(PriceBulkWithFiltersCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceBulkWithFiltersCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceBulkWithFiltersCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceBulkWithFiltersCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceBulkWithFiltersCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceBulkWithFiltersConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceBulkWithFiltersConversionRateConfig value =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceBulkWithFiltersConversionRateConfig value =
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceBulkWithFiltersConversionRateConfig value =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceBulkWithFiltersConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceBulkWithFiltersConversionRateConfig value =
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceBulkWithFiltersConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceGroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence> expectedCadence =
            PriceGroupedWithMinMaxThresholdsCadence.Annual;
        string expectedCurrency = "currency";
        PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
            new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "grouped_with_min_max_thresholds"
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            model.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceGroupedWithMinMaxThresholds>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceGroupedWithMinMaxThresholds>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence> expectedCadence =
            PriceGroupedWithMinMaxThresholdsCadence.Annual;
        string expectedCurrency = "currency";
        PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
            new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "grouped_with_min_max_thresholds"
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            deserialized.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class PriceGroupedWithMinMaxThresholdsCadenceTest : TestBase
{
    [Theory]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Custom)]
    public void Validation_Works(PriceGroupedWithMinMaxThresholdsCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(PriceGroupedWithMinMaxThresholdsCadence.Custom)]
    public void SerializationRoundtrip_Works(PriceGroupedWithMinMaxThresholdsCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string expectedGroupingKey = "x";
        string expectedMaximumCharge = "maximum_charge";
        string expectedMinimumCharge = "minimum_charge";
        string expectedPerUnitRate = "per_unit_rate";

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedMaximumCharge, model.MaximumCharge);
        Assert.Equal(expectedMinimumCharge, model.MinimumCharge);
        Assert.Equal(expectedPerUnitRate, model.PerUnitRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedGroupingKey = "x";
        string expectedMaximumCharge = "maximum_charge";
        string expectedMinimumCharge = "minimum_charge";
        string expectedPerUnitRate = "per_unit_rate";

        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedMaximumCharge, deserialized.MaximumCharge);
        Assert.Equal(expectedMinimumCharge, deserialized.MinimumCharge);
        Assert.Equal(expectedPerUnitRate, deserialized.PerUnitRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        model.Validate();
    }
}

public class PriceGroupedWithMinMaxThresholdsConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceCumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<string, PriceCumulativeGroupedAllocationCadence> expectedCadence =
            PriceCumulativeGroupedAllocationCadence.Annual;
        PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "cumulative_grouped_allocation"
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            model.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceCumulativeGroupedAllocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceCumulativeGroupedAllocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PriceCumulativeGroupedAllocationCadence> expectedCadence =
            PriceCumulativeGroupedAllocationCadence.Annual;
        PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "cumulative_grouped_allocation"
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            deserialized.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class PriceCumulativeGroupedAllocationCadenceTest : TestBase
{
    [Theory]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Custom)]
    public void Validation_Works(PriceCumulativeGroupedAllocationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceCumulativeGroupedAllocationCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceCumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(PriceCumulativeGroupedAllocationCadence.Custom)]
    public void SerializationRoundtrip_Works(PriceCumulativeGroupedAllocationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceCumulativeGroupedAllocationCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceCumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceCumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceCumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string expectedCumulativeAllocation = "cumulative_allocation";
        string expectedGroupAllocation = "group_allocation";
        string expectedGroupingKey = "x";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedCumulativeAllocation, model.CumulativeAllocation);
        Assert.Equal(expectedGroupAllocation, model.GroupAllocation);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCumulativeAllocation = "cumulative_allocation";
        string expectedGroupAllocation = "group_allocation";
        string expectedGroupingKey = "x";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedCumulativeAllocation, deserialized.CumulativeAllocation);
        Assert.Equal(expectedGroupAllocation, deserialized.GroupAllocation);
        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }
}

public class PriceCumulativeGroupedAllocationConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceCumulativeGroupedAllocationConversionRateConfig value =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceCumulativeGroupedAllocationConversionRateConfig value =
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceCumulativeGroupedAllocationConversionRateConfig value =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceCumulativeGroupedAllocationConversionRateConfig value =
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<string, PriceMinimumCadence> expectedCadence = PriceMinimumCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        PriceMinimumMinimumConfig expectedMinimumConfig = new()
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("minimum");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceMinimumConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedMinimumConfig, model.MinimumConfig);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceMinimum>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceMinimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PriceMinimumCadence> expectedCadence = PriceMinimumCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        PriceMinimumMinimumConfig expectedMinimumConfig = new()
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("minimum");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceMinimumConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedMinimumConfig, deserialized.MinimumConfig);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceMinimum
        {
            Cadence = PriceMinimumCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class PriceMinimumCadenceTest : TestBase
{
    [Theory]
    [InlineData(PriceMinimumCadence.Annual)]
    [InlineData(PriceMinimumCadence.SemiAnnual)]
    [InlineData(PriceMinimumCadence.Monthly)]
    [InlineData(PriceMinimumCadence.Quarterly)]
    [InlineData(PriceMinimumCadence.OneTime)]
    [InlineData(PriceMinimumCadence.Custom)]
    public void Validation_Works(PriceMinimumCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceMinimumCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceMinimumCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceMinimumCadence.Annual)]
    [InlineData(PriceMinimumCadence.SemiAnnual)]
    [InlineData(PriceMinimumCadence.Monthly)]
    [InlineData(PriceMinimumCadence.Quarterly)]
    [InlineData(PriceMinimumCadence.OneTime)]
    [InlineData(PriceMinimumCadence.Custom)]
    public void SerializationRoundtrip_Works(PriceMinimumCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceMinimumCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceMinimumCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceMinimumCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceMinimumCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceMinimumMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string expectedMinimumAmount = "minimum_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedProrated, model.Prorated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceMinimumMinimumConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceMinimumMinimumConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMinimumAmount = "minimum_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedProrated, deserialized.Prorated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceMinimumMinimumConfig { MinimumAmount = "minimum_amount" };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceMinimumMinimumConfig { MinimumAmount = "minimum_amount" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        model.Validate();
    }
}

public class PriceMinimumConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceMinimumConversionRateConfig value = new Models::SharedUnitConversionRateConfig()
        {
            ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceMinimumConversionRateConfig value = new Models::SharedTieredConversionRateConfig()
        {
            ConversionRateType = Models::ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceMinimumConversionRateConfig value = new Models::SharedUnitConversionRateConfig()
        {
            ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceMinimumConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceMinimumConversionRateConfig value = new Models::SharedTieredConversionRateConfig()
        {
            ConversionRateType = Models::ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceMinimumConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricePercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<string, PricePercentCadence> expectedCadence = PricePercentCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        PricePercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PricePercentConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentConfig, model.PercentConfig);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricePercent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricePercent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PricePercentCadence> expectedCadence = PricePercentCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        PricePercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PricePercentConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPercentConfig, deserialized.PercentConfig);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class PricePercentCadenceTest : TestBase
{
    [Theory]
    [InlineData(PricePercentCadence.Annual)]
    [InlineData(PricePercentCadence.SemiAnnual)]
    [InlineData(PricePercentCadence.Monthly)]
    [InlineData(PricePercentCadence.Quarterly)]
    [InlineData(PricePercentCadence.OneTime)]
    [InlineData(PricePercentCadence.Custom)]
    public void Validation_Works(PricePercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricePercentCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricePercentCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricePercentCadence.Annual)]
    [InlineData(PricePercentCadence.SemiAnnual)]
    [InlineData(PricePercentCadence.Monthly)]
    [InlineData(PricePercentCadence.Quarterly)]
    [InlineData(PricePercentCadence.OneTime)]
    [InlineData(PricePercentCadence.Custom)]
    public void SerializationRoundtrip_Works(PricePercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricePercentCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricePercentCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricePercentCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricePercentCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricePercentPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricePercentPercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricePercentPercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricePercentPercentConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricePercentPercentConfig { Percent = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricePercentPercentConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, deserialized.Percent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricePercentPercentConfig { Percent = 0 };

        model.Validate();
    }
}

public class PricePercentConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PricePercentConversionRateConfig value = new Models::SharedUnitConversionRateConfig()
        {
            ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PricePercentConversionRateConfig value = new Models::SharedTieredConversionRateConfig()
        {
            ConversionRateType = Models::ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PricePercentConversionRateConfig value = new Models::SharedUnitConversionRateConfig()
        {
            ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricePercentConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PricePercentConversionRateConfig value = new Models::SharedTieredConversionRateConfig()
        {
            ConversionRateType = Models::ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricePercentConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<string, PriceEventOutputCadence> expectedCadence = PriceEventOutputCadence.Annual;
        string expectedCurrency = "currency";
        PriceEventOutputEventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("event_output");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEventOutputConfig, model.EventOutputConfig);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEventOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEventOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PriceEventOutputCadence> expectedCadence = PriceEventOutputCadence.Annual;
        string expectedCurrency = "currency";
        PriceEventOutputEventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("event_output");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEventOutputConfig, deserialized.EventOutputConfig);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class PriceEventOutputCadenceTest : TestBase
{
    [Theory]
    [InlineData(PriceEventOutputCadence.Annual)]
    [InlineData(PriceEventOutputCadence.SemiAnnual)]
    [InlineData(PriceEventOutputCadence.Monthly)]
    [InlineData(PriceEventOutputCadence.Quarterly)]
    [InlineData(PriceEventOutputCadence.OneTime)]
    [InlineData(PriceEventOutputCadence.Custom)]
    public void Validation_Works(PriceEventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceEventOutputCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceEventOutputCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceEventOutputCadence.Annual)]
    [InlineData(PriceEventOutputCadence.SemiAnnual)]
    [InlineData(PriceEventOutputCadence.Monthly)]
    [InlineData(PriceEventOutputCadence.Quarterly)]
    [InlineData(PriceEventOutputCadence.OneTime)]
    [InlineData(PriceEventOutputCadence.Custom)]
    public void SerializationRoundtrip_Works(PriceEventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceEventOutputCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceEventOutputCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceEventOutputCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceEventOutputCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceEventOutputEventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string expectedUnitRatingKey = "x";
        string expectedDefaultUnitRate = "default_unit_rate";
        string expectedGroupingKey = "grouping_key";

        Assert.Equal(expectedUnitRatingKey, model.UnitRatingKey);
        Assert.Equal(expectedDefaultUnitRate, model.DefaultUnitRate);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEventOutputEventOutputConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEventOutputEventOutputConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUnitRatingKey = "x";
        string expectedDefaultUnitRate = "default_unit_rate";
        string expectedGroupingKey = "grouping_key";

        Assert.Equal(expectedUnitRatingKey, deserialized.UnitRatingKey);
        Assert.Equal(expectedDefaultUnitRate, deserialized.DefaultUnitRate);
        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEventOutputEventOutputConfig { UnitRatingKey = "x" };

        Assert.Null(model.DefaultUnitRate);
        Assert.False(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.False(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceEventOutputEventOutputConfig { UnitRatingKey = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",

            DefaultUnitRate = null,
            GroupingKey = null,
        };

        Assert.Null(model.DefaultUnitRate);
        Assert.True(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.True(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",

            DefaultUnitRate = null,
            GroupingKey = null,
        };

        model.Validate();
    }
}

public class PriceEventOutputConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceEventOutputConversionRateConfig value = new Models::SharedUnitConversionRateConfig()
        {
            ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceEventOutputConversionRateConfig value = new Models::SharedTieredConversionRateConfig()
        {
            ConversionRateType = Models::ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceEventOutputConversionRateConfig value = new Models::SharedUnitConversionRateConfig()
        {
            ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEventOutputConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceEventOutputConversionRateConfig value = new Models::SharedTieredConversionRateConfig()
        {
            ConversionRateType = Models::ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEventOutputConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
