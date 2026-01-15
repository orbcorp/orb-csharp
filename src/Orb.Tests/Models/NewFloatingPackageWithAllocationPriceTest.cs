using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingPackageWithAllocationPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingPackageWithAllocationPrice
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
        };

        ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence> expectedCadence =
            NewFloatingPackageWithAllocationPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType> expectedModelType =
            NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation;
        string expectedName = "Annual fee";
        PackageWithAllocationConfig expectedPackageWithAllocationConfig = new()
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingPackageWithAllocationPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedPackageWithAllocationConfig, model.PackageWithAllocationConfig);
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
        var model = new NewFloatingPackageWithAllocationPrice
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewFloatingPackageWithAllocationPrice
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence> expectedCadence =
            NewFloatingPackageWithAllocationPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType> expectedModelType =
            NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation;
        string expectedName = "Annual fee";
        PackageWithAllocationConfig expectedPackageWithAllocationConfig = new()
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingPackageWithAllocationPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedPackageWithAllocationConfig, deserialized.PackageWithAllocationConfig);
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
        var model = new NewFloatingPackageWithAllocationPrice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewFloatingPackageWithAllocationPrice
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
        var model = new NewFloatingPackageWithAllocationPrice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewFloatingPackageWithAllocationPrice
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
        var model = new NewFloatingPackageWithAllocationPrice
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

public class NewFloatingPackageWithAllocationPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Annual)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Monthly)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Quarterly)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.OneTime)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Custom)]
    public void Validation_Works(NewFloatingPackageWithAllocationPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Annual)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.SemiAnnual)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Monthly)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Quarterly)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.OneTime)]
    [InlineData(NewFloatingPackageWithAllocationPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(NewFloatingPackageWithAllocationPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewFloatingPackageWithAllocationPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation)]
    public void Validation_Works(NewFloatingPackageWithAllocationPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation)]
    public void SerializationRoundtrip_Works(
        NewFloatingPackageWithAllocationPriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewFloatingPackageWithAllocationPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PackageWithAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PackageWithAllocationConfig
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };

        string expectedAllocation = "allocation";
        string expectedPackageAmount = "package_amount";
        string expectedPackageSize = "package_size";

        Assert.Equal(expectedAllocation, model.Allocation);
        Assert.Equal(expectedPackageAmount, model.PackageAmount);
        Assert.Equal(expectedPackageSize, model.PackageSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PackageWithAllocationConfig
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PackageWithAllocationConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PackageWithAllocationConfig
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PackageWithAllocationConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAllocation = "allocation";
        string expectedPackageAmount = "package_amount";
        string expectedPackageSize = "package_size";

        Assert.Equal(expectedAllocation, deserialized.Allocation);
        Assert.Equal(expectedPackageAmount, deserialized.PackageAmount);
        Assert.Equal(expectedPackageSize, deserialized.PackageSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PackageWithAllocationConfig
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };

        model.Validate();
    }
}

public class NewFloatingPackageWithAllocationPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        NewFloatingPackageWithAllocationPriceConversionRateConfig value =
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
        NewFloatingPackageWithAllocationPriceConversionRateConfig value =
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
        NewFloatingPackageWithAllocationPriceConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        NewFloatingPackageWithAllocationPriceConversionRateConfig value =
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
            JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
