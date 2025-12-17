using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        string expectedEventName = "event_name";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z");
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedEventName, model.EventName);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedExternalCustomerID, model.ExternalCustomerID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Event>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Event>(json);
        Assert.NotNull(deserialized);

        string expectedEventName = "event_name";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z");
        string expectedCustomerID = "customer_id";
        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedEventName, deserialized.EventName);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Properties[item.Key]));
        }
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedExternalCustomerID, deserialized.ExternalCustomerID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            CustomerID = "customer_id",
            ExternalCustomerID = "external_customer_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
        };

        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.ExternalCustomerID);
        Assert.False(model.RawData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),

            CustomerID = null,
            ExternalCustomerID = null,
        };

        Assert.Null(model.CustomerID);
        Assert.True(model.RawData.ContainsKey("customer_id"));
        Assert.Null(model.ExternalCustomerID);
        Assert.True(model.RawData.ContainsKey("external_customer_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            EventName = "event_name",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),

            CustomerID = null,
            ExternalCustomerID = null,
        };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice expectedPrice =
            new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluation>(json);
        Assert.NotNull(deserialized);

        string expectedExternalPriceID = "external_price_id";
        string expectedFilter = "my_numeric_property > 100 AND my_other_property = 'bar'";
        List<string> expectedGroupingKeys =
        [
            "case when my_event_type = 'foo' then true else false end",
        ];
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice expectedPrice =
            new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
        {
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluation
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

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceTest : TestBase
{
    [Fact]
    public void NewFloatingUnitValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredPrice()
            {
                Cadence = NewFloatingTieredPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredPriceModelType.Tiered,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingBulkValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = NewFloatingBulkPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = ModelType.Bulk,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void BulkWithFiltersValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters()
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
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingPackageValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingPackagePrice()
            {
                Cadence = NewFloatingPackagePriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMatrixPrice()
            {
                Cadence = NewFloatingMatrixPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                MatrixConfig = new()
                {
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = NewFloatingMatrixPriceModelType.Matrix,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingThresholdTotalAmountValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingThresholdTotalAmountPrice()
            {
                Cadence = NewFloatingThresholdTotalAmountPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredPackageValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredPackagePrice()
            {
                Cadence = NewFloatingTieredPackagePriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredPackagePriceModelType.TieredPackage,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredWithMinimumValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredWithMinimumPrice()
            {
                Cadence = NewFloatingTieredWithMinimumPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedTieredValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedTieredPrice()
            {
                Cadence = NewFloatingGroupedTieredPriceCadence.Annual,
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
                ModelType = NewFloatingGroupedTieredPriceModelType.GroupedTiered,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredPackageWithMinimumValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredPackageWithMinimumPrice()
            {
                Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType =
                    NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingPackageWithAllocationValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingPackageWithAllocationPrice()
            {
                Cadence = NewFloatingPackageWithAllocationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitWithPercentValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingUnitWithPercentPrice()
            {
                Cadence = NewFloatingUnitWithPercentPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixWithAllocationValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMatrixWithAllocationPrice()
            {
                Cadence = NewFloatingMatrixWithAllocationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                MatrixWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = NewFloatingMatrixWithAllocationPriceModelType.MatrixWithAllocation,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredWithProrationValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredWithProrationPrice()
            {
                Cadence = NewFloatingTieredWithProrationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredWithProrationPriceModelType.TieredWithProration,
                Name = "Annual fee",
                TieredWithProrationConfig = new(
                    [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
                ),
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitWithProrationValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingUnitWithProrationPrice()
            {
                Cadence = NewFloatingUnitWithProrationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedAllocationValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedAllocationPrice()
            {
                Cadence = NewFloatingGroupedAllocationPriceCadence.Annual,
                Currency = "currency",
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType = NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingBulkWithProrationValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = NewFloatingBulkWithProrationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingBulkWithProrationPriceModelType.BulkWithProration,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedWithProratedMinimumValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedWithProratedMinimumPrice()
            {
                Cadence = NewFloatingGroupedWithProratedMinimumPriceCadence.Annual,
                Currency = "currency",
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedWithMeteredMinimumValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedWithMeteredMinimumPrice()
            {
                Cadence = NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
                Currency = "currency",
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new()
                        {
                            ScalingFactorValue = "scaling_factor",
                            ScalingValue = "scaling_value",
                        },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds()
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixWithDisplayNameValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMatrixWithDisplayNamePrice()
            {
                Cadence = NewFloatingMatrixWithDisplayNamePriceCadence.Annual,
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
                ModelType = NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedTieredPackageValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedTieredPackagePrice()
            {
                Cadence = NewFloatingGroupedTieredPackagePriceCadence.Annual,
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
                ModelType = NewFloatingGroupedTieredPackagePriceModelType.GroupedTieredPackage,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingMaxGroupTieredPackageValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMaxGroupTieredPackagePrice()
            {
                Cadence = NewFloatingMaxGroupTieredPackagePriceCadence.Annual,
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
                ModelType = NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingScalableMatrixWithUnitPricingValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingScalableMatrixWithUnitPricingPrice()
            {
                Cadence = NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType =
                    NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingScalableMatrixWithTieredPricingValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingScalableMatrixWithTieredPricingPrice()
            {
                Cadence = NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType =
                    NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingCumulativeGroupedBulkValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingCumulativeGroupedBulkPrice()
            {
                Cadence = NewFloatingCumulativeGroupedBulkPriceCadence.Annual,
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
                ModelType = NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void CumulativeGroupedAllocationValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation()
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingMinimumCompositeValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMinimumCompositePrice()
            {
                Cadence = NewFloatingMinimumCompositePriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
                ModelType = NewFloatingMinimumCompositePriceModelType.Minimum,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void PercentValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent()
            {
                Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                Name = "Annual fee",
                PercentConfig = new(0),
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void EventOutputValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput()
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredPrice()
            {
                Cadence = NewFloatingTieredPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredPriceModelType.Tiered,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingBulkSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = NewFloatingBulkPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = ModelType.Bulk,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters()
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
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingPackageSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingPackagePrice()
            {
                Cadence = NewFloatingPackagePriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMatrixPrice()
            {
                Cadence = NewFloatingMatrixPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                MatrixConfig = new()
                {
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = NewFloatingMatrixPriceModelType.Matrix,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingThresholdTotalAmountSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingThresholdTotalAmountPrice()
            {
                Cadence = NewFloatingThresholdTotalAmountPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredPackageSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredPackagePrice()
            {
                Cadence = NewFloatingTieredPackagePriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredPackagePriceModelType.TieredPackage,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredWithMinimumSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredWithMinimumPrice()
            {
                Cadence = NewFloatingTieredWithMinimumPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedTieredSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedTieredPrice()
            {
                Cadence = NewFloatingGroupedTieredPriceCadence.Annual,
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
                ModelType = NewFloatingGroupedTieredPriceModelType.GroupedTiered,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredPackageWithMinimumPrice()
            {
                Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType =
                    NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingPackageWithAllocationSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingPackageWithAllocationPrice()
            {
                Cadence = NewFloatingPackageWithAllocationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingUnitWithPercentSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingUnitWithPercentPrice()
            {
                Cadence = NewFloatingUnitWithPercentPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixWithAllocationSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMatrixWithAllocationPrice()
            {
                Cadence = NewFloatingMatrixWithAllocationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                MatrixWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = NewFloatingMatrixWithAllocationPriceModelType.MatrixWithAllocation,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredWithProrationSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingTieredWithProrationPrice()
            {
                Cadence = NewFloatingTieredWithProrationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingTieredWithProrationPriceModelType.TieredWithProration,
                Name = "Annual fee",
                TieredWithProrationConfig = new(
                    [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
                ),
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingUnitWithProrationSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingUnitWithProrationPrice()
            {
                Cadence = NewFloatingUnitWithProrationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedAllocationSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedAllocationPrice()
            {
                Cadence = NewFloatingGroupedAllocationPriceCadence.Annual,
                Currency = "currency",
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType = NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingBulkWithProrationSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = NewFloatingBulkWithProrationPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingBulkWithProrationPriceModelType.BulkWithProration,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedWithProratedMinimumPrice()
            {
                Cadence = NewFloatingGroupedWithProratedMinimumPriceCadence.Annual,
                Currency = "currency",
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedWithMeteredMinimumPrice()
            {
                Cadence = NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
                Currency = "currency",
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new()
                        {
                            ScalingFactorValue = "scaling_factor",
                            ScalingValue = "scaling_value",
                        },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds()
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMatrixWithDisplayNamePrice()
            {
                Cadence = NewFloatingMatrixWithDisplayNamePriceCadence.Annual,
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
                ModelType = NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedTieredPackageSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingGroupedTieredPackagePrice()
            {
                Cadence = NewFloatingGroupedTieredPackagePriceCadence.Annual,
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
                ModelType = NewFloatingGroupedTieredPackagePriceModelType.GroupedTieredPackage,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMaxGroupTieredPackagePrice()
            {
                Cadence = NewFloatingMaxGroupTieredPackagePriceCadence.Annual,
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
                ModelType = NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingScalableMatrixWithUnitPricingPrice()
            {
                Cadence = NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType =
                    NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingScalableMatrixWithTieredPricingPrice()
            {
                Cadence = NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType =
                    NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingCumulativeGroupedBulkPrice()
            {
                Cadence = NewFloatingCumulativeGroupedBulkPriceCadence.Annual,
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
                ModelType = NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation()
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMinimumCompositeSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new NewFloatingMinimumCompositePrice()
            {
                Cadence = NewFloatingMinimumCompositePriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
                ModelType = NewFloatingMinimumCompositePriceModelType.Minimum,
                Name = "Annual fee",
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent()
            {
                Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                Name = "Annual fee",
                PercentConfig = new(0),
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
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPrice value = new(
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput()
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPrice>(json);

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters>(
                json
            );
        Assert.NotNull(deserialized);

        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFilters
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
            Cadence =
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual,
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

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };

        List<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig>(
                json
            );
        Assert.NotNull(deserialized);

        List<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfig
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

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilterTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTierTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
            };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",

                TierLowerBound = null,
            };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual)]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.SemiAnnual
    )]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Monthly)]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Quarterly
    )]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.OneTime)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Custom)]
    public void Validation_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Annual)]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.SemiAnnual
    )]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Monthly)]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Quarterly
    )]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.OneTime)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence.Custom)]
    public void SerializationRoundtrip_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceBulkWithFiltersConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual;
        string expectedCurrency = "currency";
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
            new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual;
        string expectedCurrency = "currency";
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
            new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual,
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

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Monthly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Quarterly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.OneTime
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Custom
    )]
    public void Validation_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Annual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.SemiAnnual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Monthly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Quarterly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.OneTime
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocation
            {
                Cadence =
                    PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual,
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

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.SemiAnnual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Monthly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Quarterly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.OneTime
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Custom
    )]
    public void Validation_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Annual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.SemiAnnual
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Monthly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Quarterly
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.OneTime
    )]
    [InlineData(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceCumulativeGroupedAllocationConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig expectedPercentConfig =
            new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig expectedPercentConfig =
            new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
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
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercent
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual,
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

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadenceTest : TestBase
{
    [Theory]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.SemiAnnual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Monthly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Quarterly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.OneTime)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Custom)]
    public void Validation_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Annual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.SemiAnnual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Monthly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Quarterly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.OneTime)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence.Custom)]
    public void SerializationRoundtrip_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig
        {
            Percent = 0,
        };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig
        {
            Percent = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig
        {
            Percent = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig>(
                json
            );
        Assert.NotNull(deserialized);

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, deserialized.Percent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentPercentConfig
        {
            Percent = 0,
        };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig value = new(
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig value = new(
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPricePercentConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual;
        string expectedCurrency = "currency";
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig expectedEventOutputConfig =
            new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
        > expectedCadence =
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual;
        string expectedCurrency = "currency";
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig expectedEventOutputConfig =
            new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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
        var model = new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutput
        {
            Cadence = PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual,
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

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadenceTest : TestBase
{
    [Theory]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.SemiAnnual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Monthly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Quarterly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.OneTime)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Custom)]
    public void Validation_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Annual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.SemiAnnual)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Monthly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Quarterly)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.OneTime)]
    [InlineData(PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence.Custom)]
    public void SerializationRoundtrip_Works(
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig>(
                json
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
            };

        Assert.Null(model.DefaultUnitRate);
        Assert.False(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.False(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
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
        var model =
            new PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",

                DefaultUnitRate = null,
                GroupingKey = null,
            };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig value =
            new(
                new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig value =
            new(
                new SharedTieredConversionRateConfig()
                {
                    ConversionRateType = ConversionRateType.Tiered,
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
                }
            );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<PriceEvaluatePreviewEventsParamsPriceEvaluationPriceEventOutputConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}
