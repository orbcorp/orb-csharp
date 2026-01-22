using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class NewSubscriptionGroupedWithMeteredMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
            Currency = "currency",
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
            ReferenceID = "reference_id",
        };

        ApiEnum<
            string,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence
        > expectedCadence =
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual;
        Subscriptions::GroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig =
            new()
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
            };
        string expectedItemID = "item_id";
        ApiEnum<
            string,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType
        > expectedModelType =
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
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
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedGroupedWithMeteredMinimumConfig,
            model.GroupedWithMeteredMinimumConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
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
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
            Currency = "currency",
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
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
            Currency = "currency",
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
            ReferenceID = "reference_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence
        > expectedCadence =
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual;
        Subscriptions::GroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig =
            new()
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
            };
        string expectedItemID = "item_id";
        ApiEnum<
            string,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType
        > expectedModelType =
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
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
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(
            expectedGroupedWithMeteredMinimumConfig,
            deserialized.GroupedWithMeteredMinimumConfig
        );
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedModelType, deserialized.ModelType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
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
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
            Currency = "currency",
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
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
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
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
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
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
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
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
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
                Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
            Currency = "currency",
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
            ReferenceID = "reference_id",
        };

        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewSubscriptionGroupedWithMeteredMinimumPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.SemiAnnual)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Monthly)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Quarterly)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.OneTime)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Custom)]
    public void Validation_Works(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.SemiAnnual)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Monthly)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Quarterly)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.OneTime)]
    [InlineData(Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GroupedWithMeteredMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::GroupedWithMeteredMinimumConfig
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
        };

        string expectedGroupingKey = "x";
        string expectedMinimumUnitAmount = "minimum_unit_amount";
        string expectedPricingKey = "pricing_key";
        List<Subscriptions::ScalingFactor> expectedScalingFactors =
        [
            new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<Subscriptions::UnitAmount> expectedUnitAmounts =
        [
            new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
        ];

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedMinimumUnitAmount, model.MinimumUnitAmount);
        Assert.Equal(expectedPricingKey, model.PricingKey);
        Assert.Equal(expectedScalingFactors.Count, model.ScalingFactors.Count);
        for (int i = 0; i < expectedScalingFactors.Count; i++)
        {
            Assert.Equal(expectedScalingFactors[i], model.ScalingFactors[i]);
        }
        Assert.Equal(expectedScalingKey, model.ScalingKey);
        Assert.Equal(expectedUnitAmounts.Count, model.UnitAmounts.Count);
        for (int i = 0; i < expectedUnitAmounts.Count; i++)
        {
            Assert.Equal(expectedUnitAmounts[i], model.UnitAmounts[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::GroupedWithMeteredMinimumConfig
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::GroupedWithMeteredMinimumConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::GroupedWithMeteredMinimumConfig
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::GroupedWithMeteredMinimumConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedGroupingKey = "x";
        string expectedMinimumUnitAmount = "minimum_unit_amount";
        string expectedPricingKey = "pricing_key";
        List<Subscriptions::ScalingFactor> expectedScalingFactors =
        [
            new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<Subscriptions::UnitAmount> expectedUnitAmounts =
        [
            new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
        ];

        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedMinimumUnitAmount, deserialized.MinimumUnitAmount);
        Assert.Equal(expectedPricingKey, deserialized.PricingKey);
        Assert.Equal(expectedScalingFactors.Count, deserialized.ScalingFactors.Count);
        for (int i = 0; i < expectedScalingFactors.Count; i++)
        {
            Assert.Equal(expectedScalingFactors[i], deserialized.ScalingFactors[i]);
        }
        Assert.Equal(expectedScalingKey, deserialized.ScalingKey);
        Assert.Equal(expectedUnitAmounts.Count, deserialized.UnitAmounts.Count);
        for (int i = 0; i < expectedUnitAmounts.Count; i++)
        {
            Assert.Equal(expectedUnitAmounts[i], deserialized.UnitAmounts[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::GroupedWithMeteredMinimumConfig
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::GroupedWithMeteredMinimumConfig
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
        };

        Subscriptions::GroupedWithMeteredMinimumConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScalingFactorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ScalingFactor
        {
            ScalingFactorValue = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string expectedScalingFactorValue = "scaling_factor";
        string expectedScalingValue = "scaling_value";

        Assert.Equal(expectedScalingFactorValue, model.ScalingFactorValue);
        Assert.Equal(expectedScalingValue, model.ScalingValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::ScalingFactor
        {
            ScalingFactorValue = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ScalingFactor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ScalingFactor
        {
            ScalingFactorValue = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ScalingFactor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedScalingFactorValue = "scaling_factor";
        string expectedScalingValue = "scaling_value";

        Assert.Equal(expectedScalingFactorValue, deserialized.ScalingFactorValue);
        Assert.Equal(expectedScalingValue, deserialized.ScalingValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::ScalingFactor
        {
            ScalingFactorValue = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::ScalingFactor
        {
            ScalingFactorValue = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        Subscriptions::ScalingFactor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnitAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        string expectedPricingValue = "pricing_value";
        string expectedUnitAmountValue = "unit_amount";

        Assert.Equal(expectedPricingValue, model.PricingValue);
        Assert.Equal(expectedUnitAmountValue, model.UnitAmountValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::UnitAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::UnitAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPricingValue = "pricing_value";
        string expectedUnitAmountValue = "unit_amount";

        Assert.Equal(expectedPricingValue, deserialized.PricingValue);
        Assert.Equal(expectedUnitAmountValue, deserialized.UnitAmountValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        Subscriptions::UnitAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewSubscriptionGroupedWithMeteredMinimumPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum
    )]
    public void Validation_Works(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig value =
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig value =
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
