using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Subscriptions;
using Models = Orb.Models;

namespace Orb.Tests.Models.Subscriptions;

public class NewSubscriptionGroupedWithMeteredMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, NewSubscriptionGroupedWithMeteredMinimumPriceCadence> expectedCadence =
            NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual;
        GroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig = new()
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };
        string expectedItemID = "item_id";
        ApiEnum<string, NewSubscriptionGroupedWithMeteredMinimumPriceModelType> expectedModelType =
            NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
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
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<NewSubscriptionGroupedWithMeteredMinimumPrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<NewSubscriptionGroupedWithMeteredMinimumPrice>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewSubscriptionGroupedWithMeteredMinimumPriceCadence> expectedCadence =
            NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual;
        GroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig = new()
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };
        string expectedItemID = "item_id";
        ApiEnum<string, NewSubscriptionGroupedWithMeteredMinimumPriceModelType> expectedModelType =
            NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
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
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        var model = new NewSubscriptionGroupedWithMeteredMinimumPrice
        {
            Cadence = NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
}

public class GroupedWithMeteredMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMeteredMinimumConfig
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };

        string expectedGroupingKey = "x";
        string expectedMinimumUnitAmount = "minimum_unit_amount";
        string expectedPricingKey = "pricing_key";
        List<ScalingFactor> expectedScalingFactors =
        [
            new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<UnitAmount> expectedUnitAmounts =
        [
            new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
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
        var model = new GroupedWithMeteredMinimumConfig
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedWithMeteredMinimumConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroupedWithMeteredMinimumConfig
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedWithMeteredMinimumConfig>(json);
        Assert.NotNull(deserialized);

        string expectedGroupingKey = "x";
        string expectedMinimumUnitAmount = "minimum_unit_amount";
        string expectedPricingKey = "pricing_key";
        List<ScalingFactor> expectedScalingFactors =
        [
            new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<UnitAmount> expectedUnitAmounts =
        [
            new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
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
        var model = new GroupedWithMeteredMinimumConfig
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };

        model.Validate();
    }
}

public class ScalingFactorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalingFactor
        {
            ScalingFactor1 = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string expectedScalingFactor1 = "scaling_factor";
        string expectedScalingValue = "scaling_value";

        Assert.Equal(expectedScalingFactor1, model.ScalingFactor1);
        Assert.Equal(expectedScalingValue, model.ScalingValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ScalingFactor
        {
            ScalingFactor1 = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ScalingFactor>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScalingFactor
        {
            ScalingFactor1 = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ScalingFactor>(json);
        Assert.NotNull(deserialized);

        string expectedScalingFactor1 = "scaling_factor";
        string expectedScalingValue = "scaling_value";

        Assert.Equal(expectedScalingFactor1, deserialized.ScalingFactor1);
        Assert.Equal(expectedScalingValue, deserialized.ScalingValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ScalingFactor
        {
            ScalingFactor1 = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        model.Validate();
    }
}

public class UnitAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitAmount { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" };

        string expectedPricingValue = "pricing_value";
        string expectedUnitAmount1 = "unit_amount";

        Assert.Equal(expectedPricingValue, model.PricingValue);
        Assert.Equal(expectedUnitAmount1, model.UnitAmount1);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnitAmount { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnitAmount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnitAmount { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnitAmount>(json);
        Assert.NotNull(deserialized);

        string expectedPricingValue = "pricing_value";
        string expectedUnitAmount1 = "unit_amount";

        Assert.Equal(expectedPricingValue, deserialized.PricingValue);
        Assert.Equal(expectedUnitAmount1, deserialized.UnitAmount1);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnitAmount { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" };

        model.Validate();
    }
}
