using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingMaxGroupTieredPackagePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingMaxGroupTieredPackagePrice
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
        };

        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence> expectedCadence =
            NewFloatingMaxGroupTieredPackagePriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        MaxGroupTieredPackageConfig expectedMaxGroupTieredPackageConfig = new()
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };
        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType> expectedModelType =
            NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingMaxGroupTieredPackagePriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMaxGroupTieredPackageConfig, model.MaxGroupTieredPackageConfig);
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
        var model = new NewFloatingMaxGroupTieredPackagePrice
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewFloatingMaxGroupTieredPackagePrice
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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence> expectedCadence =
            NewFloatingMaxGroupTieredPackagePriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        MaxGroupTieredPackageConfig expectedMaxGroupTieredPackageConfig = new()
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };
        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType> expectedModelType =
            NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingMaxGroupTieredPackagePriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMaxGroupTieredPackageConfig, deserialized.MaxGroupTieredPackageConfig);
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
        var model = new NewFloatingMaxGroupTieredPackagePrice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewFloatingMaxGroupTieredPackagePrice
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
        var model = new NewFloatingMaxGroupTieredPackagePrice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewFloatingMaxGroupTieredPackagePrice
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
        var model = new NewFloatingMaxGroupTieredPackagePrice
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

public class NewFloatingMaxGroupTieredPackagePriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Annual)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.SemiAnnual)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Monthly)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Quarterly)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.OneTime)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Custom)]
    public void Validation_Works(NewFloatingMaxGroupTieredPackagePriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Annual)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.SemiAnnual)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Monthly)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Quarterly)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.OneTime)]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceCadence.Custom)]
    public void SerializationRoundtrip_Works(NewFloatingMaxGroupTieredPackagePriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MaxGroupTieredPackageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaxGroupTieredPackageConfig
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };

        string expectedGroupingKey = "x";
        string expectedPackageSize = "package_size";
        List<MaxGroupTieredPackageConfigTier> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedPackageSize, model.PackageSize);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MaxGroupTieredPackageConfig
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaxGroupTieredPackageConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MaxGroupTieredPackageConfig
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaxGroupTieredPackageConfig>(element);
        Assert.NotNull(deserialized);

        string expectedGroupingKey = "x";
        string expectedPackageSize = "package_size";
        List<MaxGroupTieredPackageConfigTier> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedPackageSize, deserialized.PackageSize);
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MaxGroupTieredPackageConfig
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };

        model.Validate();
    }
}

public class MaxGroupTieredPackageConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaxGroupTieredPackageConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MaxGroupTieredPackageConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaxGroupTieredPackageConfigTier>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MaxGroupTieredPackageConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaxGroupTieredPackageConfigTier>(element);
        Assert.NotNull(deserialized);

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MaxGroupTieredPackageConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }
}

public class NewFloatingMaxGroupTieredPackagePriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage)]
    public void Validation_Works(NewFloatingMaxGroupTieredPackagePriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage)]
    public void SerializationRoundtrip_Works(
        NewFloatingMaxGroupTieredPackagePriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewFloatingMaxGroupTieredPackagePriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        NewFloatingMaxGroupTieredPackagePriceConversionRateConfig value = new(
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
        NewFloatingMaxGroupTieredPackagePriceConversionRateConfig value = new(
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
        NewFloatingMaxGroupTieredPackagePriceConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        NewFloatingMaxGroupTieredPackagePriceConversionRateConfig value = new(
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
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }
}
