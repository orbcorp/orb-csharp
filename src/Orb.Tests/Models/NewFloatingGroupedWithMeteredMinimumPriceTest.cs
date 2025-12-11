using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingGroupedWithMeteredMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
        };

        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence> expectedCadence =
            NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual;
        string expectedCurrency = "currency";
        GroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig = new()
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
        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType> expectedModelType =
            NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
            json
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence> expectedCadence =
            NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual;
        string expectedCurrency = "currency";
        GroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig = new()
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
        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType> expectedModelType =
            NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
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
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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

public class NewFloatingGroupedWithMeteredMinimumPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Monthly)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Quarterly)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.OneTime)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Custom)]
    public void Validation_Works(NewFloatingGroupedWithMeteredMinimumPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Monthly)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Quarterly)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.OneTime)]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(
        NewFloatingGroupedWithMeteredMinimumPriceCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
        List<ScalingFactor> expectedScalingFactors =
        [
            new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<UnitAmount> expectedUnitAmounts =
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
        var model = new GroupedWithMeteredMinimumConfig
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
                new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts =
            [
                new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedWithMeteredMinimumConfig>(json);
        Assert.NotNull(deserialized);

        string expectedGroupingKey = "x";
        string expectedMinimumUnitAmount = "minimum_unit_amount";
        string expectedPricingKey = "pricing_key";
        List<ScalingFactor> expectedScalingFactors =
        [
            new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<UnitAmount> expectedUnitAmounts =
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
        var model = new GroupedWithMeteredMinimumConfig
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
}

public class ScalingFactorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalingFactor
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
        var model = new ScalingFactor
        {
            ScalingFactorValue = "scaling_factor",
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
            ScalingFactorValue = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ScalingFactor>(json);
        Assert.NotNull(deserialized);

        string expectedScalingFactorValue = "scaling_factor";
        string expectedScalingValue = "scaling_value";

        Assert.Equal(expectedScalingFactorValue, deserialized.ScalingFactorValue);
        Assert.Equal(expectedScalingValue, deserialized.ScalingValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ScalingFactor
        {
            ScalingFactorValue = "scaling_factor",
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
        var model = new UnitAmount
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
        var model = new UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnitAmount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnitAmount>(json);
        Assert.NotNull(deserialized);

        string expectedPricingValue = "pricing_value";
        string expectedUnitAmountValue = "unit_amount";

        Assert.Equal(expectedPricingValue, deserialized.PricingValue);
        Assert.Equal(expectedUnitAmountValue, deserialized.UnitAmountValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnitAmount
        {
            PricingValue = "pricing_value",
            UnitAmountValue = "unit_amount",
        };

        model.Validate();
    }
}

public class NewFloatingGroupedWithMeteredMinimumPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum)]
    public void Validation_Works(NewFloatingGroupedWithMeteredMinimumPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum)]
    public void SerializationRoundtrip_Works(
        NewFloatingGroupedWithMeteredMinimumPriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void unitValidation_Works()
    {
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void tieredValidation_Works()
    {
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig value = new(
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
    public void unitSerializationRoundtrip_Works()
    {
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tieredSerializationRoundtrip_Works()
    {
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig value = new(
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
            JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}
