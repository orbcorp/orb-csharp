using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewPlanThresholdTotalAmountPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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

        ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence> expectedCadence =
            NewPlanThresholdTotalAmountPriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType> expectedModelType =
            NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount;
        string expectedName = "Annual fee";
        NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig expectedThresholdTotalAmountConfig =
            new()
            {
                ConsumptionTable =
                [
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                ],
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
        NewPlanThresholdTotalAmountPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedThresholdTotalAmountConfig, model.ThresholdTotalAmountConfig);
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
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence> expectedCadence =
            NewPlanThresholdTotalAmountPriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType> expectedModelType =
            NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount;
        string expectedName = "Annual fee";
        NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig expectedThresholdTotalAmountConfig =
            new()
            {
                ConsumptionTable =
                [
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                ],
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
        NewPlanThresholdTotalAmountPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedThresholdTotalAmountConfig, deserialized.ThresholdTotalAmountConfig);
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
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        var model = new NewPlanThresholdTotalAmountPrice
        {
            Cadence = NewPlanThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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

        NewPlanThresholdTotalAmountPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewPlanThresholdTotalAmountPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Annual)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.SemiAnnual)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Monthly)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Quarterly)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.OneTime)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Custom)]
    public void Validation_Works(NewPlanThresholdTotalAmountPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Annual)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.SemiAnnual)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Monthly)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Quarterly)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.OneTime)]
    [InlineData(NewPlanThresholdTotalAmountPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(NewPlanThresholdTotalAmountPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPlanThresholdTotalAmountPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount)]
    public void Validation_Works(NewPlanThresholdTotalAmountPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount)]
    public void SerializationRoundtrip_Works(NewPlanThresholdTotalAmountPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanThresholdTotalAmountPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };

        List<NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable> expectedConsumptionTable =
        [
            new() { Threshold = "threshold", TotalAmount = "total_amount" },
            new() { Threshold = "threshold", TotalAmount = "total_amount" },
        ];
        bool expectedProrate = true;

        Assert.Equal(expectedConsumptionTable.Count, model.ConsumptionTable.Count);
        for (int i = 0; i < expectedConsumptionTable.Count; i++)
        {
            Assert.Equal(expectedConsumptionTable[i], model.ConsumptionTable[i]);
        }
        Assert.Equal(expectedProrate, model.Prorate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable> expectedConsumptionTable =
        [
            new() { Threshold = "threshold", TotalAmount = "total_amount" },
            new() { Threshold = "threshold", TotalAmount = "total_amount" },
        ];
        bool expectedProrate = true;

        Assert.Equal(expectedConsumptionTable.Count, deserialized.ConsumptionTable.Count);
        for (int i = 0; i < expectedConsumptionTable.Count; i++)
        {
            Assert.Equal(expectedConsumptionTable[i], deserialized.ConsumptionTable[i]);
        }
        Assert.Equal(expectedProrate, deserialized.Prorate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
        };

        Assert.Null(model.Prorate);
        Assert.False(model.RawData.ContainsKey("prorate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],

            Prorate = null,
        };

        Assert.Null(model.Prorate);
        Assert.True(model.RawData.ContainsKey("prorate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],

            Prorate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };

        NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTableTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable
        {
            Threshold = "threshold",
            TotalAmount = "total_amount",
        };

        string expectedThreshold = "threshold";
        string expectedTotalAmount = "total_amount";

        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable
        {
            Threshold = "threshold",
            TotalAmount = "total_amount",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable
        {
            Threshold = "threshold",
            TotalAmount = "total_amount",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedThreshold = "threshold";
        string expectedTotalAmount = "total_amount";

        Assert.Equal(expectedThreshold, deserialized.Threshold);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable
        {
            Threshold = "threshold",
            TotalAmount = "total_amount",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable
        {
            Threshold = "threshold",
            TotalAmount = "total_amount",
        };

        NewPlanThresholdTotalAmountPriceThresholdTotalAmountConfigConsumptionTable copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class NewPlanThresholdTotalAmountPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        NewPlanThresholdTotalAmountPriceConversionRateConfig value =
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
        NewPlanThresholdTotalAmountPriceConversionRateConfig value =
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
        NewPlanThresholdTotalAmountPriceConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        NewPlanThresholdTotalAmountPriceConversionRateConfig value =
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
            JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
