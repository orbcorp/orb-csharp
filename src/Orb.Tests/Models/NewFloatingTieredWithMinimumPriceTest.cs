using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingTieredWithMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingTieredWithMinimumPrice
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
        };

        ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence> expectedCadence =
            NewFloatingTieredWithMinimumPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType> expectedModelType =
            NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum;
        string expectedName = "Annual fee";
        TieredWithMinimumConfig expectedTieredWithMinimumConfig = new()
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
        };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingTieredWithMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedTieredWithMinimumConfig, model.TieredWithMinimumConfig);
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
        var model = new NewFloatingTieredWithMinimumPrice
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewFloatingTieredWithMinimumPrice
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence> expectedCadence =
            NewFloatingTieredWithMinimumPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType> expectedModelType =
            NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum;
        string expectedName = "Annual fee";
        TieredWithMinimumConfig expectedTieredWithMinimumConfig = new()
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
        };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingTieredWithMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedTieredWithMinimumConfig, deserialized.TieredWithMinimumConfig);
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
        var model = new NewFloatingTieredWithMinimumPrice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewFloatingTieredWithMinimumPrice
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
        var model = new NewFloatingTieredWithMinimumPrice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewFloatingTieredWithMinimumPrice
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
        var model = new NewFloatingTieredWithMinimumPrice
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

public class NewFloatingTieredWithMinimumPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Annual)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Monthly)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Quarterly)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.OneTime)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Custom)]
    public void Validation_Works(NewFloatingTieredWithMinimumPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Annual)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Monthly)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Quarterly)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.OneTime)]
    [InlineData(NewFloatingTieredWithMinimumPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(NewFloatingTieredWithMinimumPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewFloatingTieredWithMinimumPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum)]
    public void Validation_Works(NewFloatingTieredWithMinimumPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum)]
    public void SerializationRoundtrip_Works(NewFloatingTieredWithMinimumPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingTieredWithMinimumPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TieredWithMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithMinimumConfig
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
        };

        List<TieredWithMinimumConfigTier> expectedTiers =
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
        ];
        bool expectedHideZeroAmountTiers = true;
        bool expectedProrate = true;

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
        Assert.Equal(expectedHideZeroAmountTiers, model.HideZeroAmountTiers);
        Assert.Equal(expectedProrate, model.Prorate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredWithMinimumConfig
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithMinimumConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredWithMinimumConfig
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithMinimumConfig>(json);
        Assert.NotNull(deserialized);

        List<TieredWithMinimumConfigTier> expectedTiers =
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
        ];
        bool expectedHideZeroAmountTiers = true;
        bool expectedProrate = true;

        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
        Assert.Equal(expectedHideZeroAmountTiers, deserialized.HideZeroAmountTiers);
        Assert.Equal(expectedProrate, deserialized.Prorate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredWithMinimumConfig
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TieredWithMinimumConfig
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
        };

        Assert.Null(model.HideZeroAmountTiers);
        Assert.False(model.RawData.ContainsKey("hide_zero_amount_tiers"));
        Assert.Null(model.Prorate);
        Assert.False(model.RawData.ContainsKey("prorate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TieredWithMinimumConfig
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TieredWithMinimumConfig
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

            // Null should be interpreted as omitted for these properties
            HideZeroAmountTiers = null,
            Prorate = null,
        };

        Assert.Null(model.HideZeroAmountTiers);
        Assert.False(model.RawData.ContainsKey("hide_zero_amount_tiers"));
        Assert.Null(model.Prorate);
        Assert.False(model.RawData.ContainsKey("prorate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TieredWithMinimumConfig
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

            // Null should be interpreted as omitted for these properties
            HideZeroAmountTiers = null,
            Prorate = null,
        };

        model.Validate();
    }
}

public class TieredWithMinimumConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string expectedMinimumAmount = "minimum_amount";
        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithMinimumConfigTier>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithMinimumConfigTier>(json);
        Assert.NotNull(deserialized);

        string expectedMinimumAmount = "minimum_amount";
        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredWithMinimumConfigTier
        {
            MinimumAmount = "minimum_amount",
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }
}

public class NewFloatingTieredWithMinimumPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void unitValidation_Works()
    {
        NewFloatingTieredWithMinimumPriceConversionRateConfig value = new(
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
        NewFloatingTieredWithMinimumPriceConversionRateConfig value = new(
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
        NewFloatingTieredWithMinimumPriceConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPriceConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tieredSerializationRoundtrip_Works()
    {
        NewFloatingTieredWithMinimumPriceConversionRateConfig value = new(
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
            JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPriceConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}
