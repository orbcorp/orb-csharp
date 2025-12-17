using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingTieredPackageWithMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        };

        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence> expectedCadence =
            NewFloatingTieredPackageWithMinimumPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType> expectedModelType =
            NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum;
        string expectedName = "Annual fee";
        TieredPackageWithMinimumConfig expectedTieredPackageWithMinimumConfig = new()
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
        };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingTieredPackageWithMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTieredPackageWithMinimumConfig, model.TieredPackageWithMinimumConfig);
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
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence> expectedCadence =
            NewFloatingTieredPackageWithMinimumPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType> expectedModelType =
            NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum;
        string expectedName = "Annual fee";
        TieredPackageWithMinimumConfig expectedTieredPackageWithMinimumConfig = new()
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
        };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingTieredPackageWithMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedModelType, deserialized.ModelType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(
            expectedTieredPackageWithMinimumConfig,
            deserialized.TieredPackageWithMinimumConfig
        );
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
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        var model = new NewFloatingTieredPackageWithMinimumPrice
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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

public class NewFloatingTieredPackageWithMinimumPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Annual)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Monthly)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Quarterly)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.OneTime)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Custom)]
    public void Validation_Works(NewFloatingTieredPackageWithMinimumPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Annual)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Monthly)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Quarterly)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.OneTime)]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(
        NewFloatingTieredPackageWithMinimumPriceCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewFloatingTieredPackageWithMinimumPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum)]
    public void Validation_Works(NewFloatingTieredPackageWithMinimumPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum)]
    public void SerializationRoundtrip_Works(
        NewFloatingTieredPackageWithMinimumPriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredPackageWithMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TieredPackageWithMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPackageWithMinimumConfig
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
        };

        double expectedPackageSize = 0;
        List<TieredPackageWithMinimumConfigTier> expectedTiers =
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
        ];

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
        var model = new TieredPackageWithMinimumConfig
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredPackageWithMinimumConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredPackageWithMinimumConfig
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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredPackageWithMinimumConfig>(element);
        Assert.NotNull(deserialized);

        double expectedPackageSize = 0;
        List<TieredPackageWithMinimumConfigTier> expectedTiers =
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
        ];

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
        var model = new TieredPackageWithMinimumConfig
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
        };

        model.Validate();
    }
}

public class TieredPackageWithMinimumConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPackageWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        string expectedMinimumAmount = "minimum_amount";
        string expectedPerUnit = "per_unit";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedPerUnit, model.PerUnit);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredPackageWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredPackageWithMinimumConfigTier>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredPackageWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredPackageWithMinimumConfigTier>(element);
        Assert.NotNull(deserialized);

        string expectedMinimumAmount = "minimum_amount";
        string expectedPerUnit = "per_unit";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedPerUnit, deserialized.PerUnit);
        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredPackageWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        model.Validate();
    }
}

public class NewFloatingTieredPackageWithMinimumPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        NewFloatingTieredPackageWithMinimumPriceConversionRateConfig value = new(
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
        NewFloatingTieredPackageWithMinimumPriceConversionRateConfig value = new(
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
        NewFloatingTieredPackageWithMinimumPriceConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        NewFloatingTieredPackageWithMinimumPriceConversionRateConfig value = new(
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
            JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }
}
