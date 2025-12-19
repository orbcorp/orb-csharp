using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class NewSubscriptionMatrixWithAllocationPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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

        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence> expectedCadence =
            NewSubscriptionMatrixWithAllocationPriceCadence.Annual;
        string expectedItemID = "item_id";
        MatrixWithAllocationConfig expectedMatrixWithAllocationConfig = new()
        {
            Allocation = "allocation",
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };
        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType> expectedModelType =
            NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewSubscriptionMatrixWithAllocationPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMatrixWithAllocationConfig, model.MatrixWithAllocationConfig);
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
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPrice>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPrice>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence> expectedCadence =
            NewSubscriptionMatrixWithAllocationPriceCadence.Annual;
        string expectedItemID = "item_id";
        MatrixWithAllocationConfig expectedMatrixWithAllocationConfig = new()
        {
            Allocation = "allocation",
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };
        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType> expectedModelType =
            NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewSubscriptionMatrixWithAllocationPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMatrixWithAllocationConfig, deserialized.MatrixWithAllocationConfig);
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
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
        var model = new NewSubscriptionMatrixWithAllocationPrice
        {
            Cadence = NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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

public class NewSubscriptionMatrixWithAllocationPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Annual)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.SemiAnnual)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Monthly)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Quarterly)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.OneTime)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Custom)]
    public void Validation_Works(NewSubscriptionMatrixWithAllocationPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Annual)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.SemiAnnual)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Monthly)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Quarterly)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.OneTime)]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(
        NewSubscriptionMatrixWithAllocationPriceCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewSubscriptionMatrixWithAllocationPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation)]
    public void Validation_Works(NewSubscriptionMatrixWithAllocationPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation)]
    public void SerializationRoundtrip_Works(
        NewSubscriptionMatrixWithAllocationPriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewSubscriptionMatrixWithAllocationPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewSubscriptionMatrixWithAllocationPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        NewSubscriptionMatrixWithAllocationPriceConversionRateConfig value = new(
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
        NewSubscriptionMatrixWithAllocationPriceConversionRateConfig value = new(
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
        NewSubscriptionMatrixWithAllocationPriceConversionRateConfig value = new(
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        NewSubscriptionMatrixWithAllocationPriceConversionRateConfig value = new(
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
            JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPriceConversionRateConfig>(
                element
            );

        Assert.Equal(value, deserialized);
    }
}
