using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class NewSubscriptionTieredPackagePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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

        ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence> expectedCadence =
            Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<
            string,
            Subscriptions::NewSubscriptionTieredPackagePriceModelType
        > expectedModelType =
            Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage;
        string expectedName = "Annual fee";
        Subscriptions::TieredPackageConfig expectedTieredPackageConfig = new()
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
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
        Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTieredPackageConfig, model.TieredPackageConfig);
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
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionTieredPackagePrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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

        string element = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionTieredPackagePrice>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence> expectedCadence =
            Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<
            string,
            Subscriptions::NewSubscriptionTieredPackagePriceModelType
        > expectedModelType =
            Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage;
        string expectedName = "Annual fee";
        Subscriptions::TieredPackageConfig expectedTieredPackageConfig = new()
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
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
        Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedModelType, deserialized.ModelType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTieredPackageConfig, deserialized.TieredPackageConfig);
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
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        var model = new Subscriptions::NewSubscriptionTieredPackagePrice
        {
            Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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

public class NewSubscriptionTieredPackagePriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.SemiAnnual)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Monthly)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Quarterly)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.OneTime)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Custom)]
    public void Validation_Works(Subscriptions::NewSubscriptionTieredPackagePriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.SemiAnnual)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Monthly)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Quarterly)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.OneTime)]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::NewSubscriptionTieredPackagePriceCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewSubscriptionTieredPackagePriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage)]
    public void Validation_Works(Subscriptions::NewSubscriptionTieredPackagePriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage)]
    public void SerializationRoundtrip_Works(
        Subscriptions::NewSubscriptionTieredPackagePriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::NewSubscriptionTieredPackagePriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TieredPackageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::TieredPackageConfig
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string expectedPackageSize = "package_size";
        List<Subscriptions::TieredPackageConfigTier> expectedTiers =
        [
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
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
        var model = new Subscriptions::TieredPackageConfig
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredPackageConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::TieredPackageConfig
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredPackageConfig>(element);
        Assert.NotNull(deserialized);

        string expectedPackageSize = "package_size";
        List<Subscriptions::TieredPackageConfigTier> expectedTiers =
        [
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
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
        var model = new Subscriptions::TieredPackageConfig
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };

        model.Validate();
    }
}

public class TieredPackageConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::TieredPackageConfigTier
        {
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        string expectedPerUnit = "per_unit";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedPerUnit, model.PerUnit);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::TieredPackageConfigTier
        {
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredPackageConfigTier>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::TieredPackageConfigTier
        {
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredPackageConfigTier>(
            element
        );
        Assert.NotNull(deserialized);

        string expectedPerUnit = "per_unit";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedPerUnit, deserialized.PerUnit);
        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::TieredPackageConfigTier
        {
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        model.Validate();
    }
}

public class NewSubscriptionTieredPackagePriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig value =
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
        Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig value =
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
        Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig value =
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
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::NewSubscriptionTieredPackagePriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }
}
