using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewPlanScalableMatrixWithUnitPricingPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
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

        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence> expectedCadence =
            NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType> expectedModelType =
            NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing;
        string expectedName = "Annual fee";
        NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig expectedScalableMatrixWithUnitPricingConfig =
            new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
            };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(
            expectedScalableMatrixWithUnitPricingConfig,
            model.ScalableMatrixWithUnitPricingConfig
        );
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
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
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
        var deserialized = JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
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
        var deserialized = JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence> expectedCadence =
            NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType> expectedModelType =
            NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing;
        string expectedName = "Annual fee";
        NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig expectedScalableMatrixWithUnitPricingConfig =
            new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
            };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(
            expectedScalableMatrixWithUnitPricingConfig,
            deserialized.ScalableMatrixWithUnitPricingConfig
        );
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
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
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
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
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
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
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
        var model = new NewPlanScalableMatrixWithUnitPricingPrice
        {
            Cadence = NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            Name = "Annual fee",
            ScalableMatrixWithUnitPricingConfig = new()
            {
                FirstDimension = "first_dimension",
                MatrixScalingFactors =
                [
                    new()
                    {
                        FirstDimensionValue = "first_dimension_value",
                        ScalingFactor = "scaling_factor",
                        SecondDimensionValue = "second_dimension_value",
                    },
                ],
                UnitPrice = "unit_price",
                Prorate = true,
                SecondDimension = "second_dimension",
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

public class NewPlanScalableMatrixWithUnitPricingPriceCadenceTest : TestBase
{
    [Theory]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.SemiAnnual)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Monthly)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Quarterly)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.OneTime)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Custom)]
    public void Validation_Works(NewPlanScalableMatrixWithUnitPricingPriceCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.SemiAnnual)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Monthly)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Quarterly)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.OneTime)]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceCadence.Custom)]
    public void SerializationRoundtrip_Works(
        NewPlanScalableMatrixWithUnitPricingPriceCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPlanScalableMatrixWithUnitPricingPriceModelTypeTest : TestBase
{
    [Theory]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing)]
    public void Validation_Works(NewPlanScalableMatrixWithUnitPricingPriceModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing)]
    public void SerializationRoundtrip_Works(
        NewPlanScalableMatrixWithUnitPricingPriceModelType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",
            Prorate = true,
            SecondDimension = "second_dimension",
        };

        string expectedFirstDimension = "first_dimension";
        List<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor> expectedMatrixScalingFactors =
        [
            new()
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            },
        ];
        string expectedUnitPrice = "unit_price";
        bool expectedProrate = true;
        string expectedSecondDimension = "second_dimension";

        Assert.Equal(expectedFirstDimension, model.FirstDimension);
        Assert.Equal(expectedMatrixScalingFactors.Count, model.MatrixScalingFactors.Count);
        for (int i = 0; i < expectedMatrixScalingFactors.Count; i++)
        {
            Assert.Equal(expectedMatrixScalingFactors[i], model.MatrixScalingFactors[i]);
        }
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedProrate, model.Prorate);
        Assert.Equal(expectedSecondDimension, model.SecondDimension);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",
            Prorate = true,
            SecondDimension = "second_dimension",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",
            Prorate = true,
            SecondDimension = "second_dimension",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFirstDimension = "first_dimension";
        List<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor> expectedMatrixScalingFactors =
        [
            new()
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            },
        ];
        string expectedUnitPrice = "unit_price";
        bool expectedProrate = true;
        string expectedSecondDimension = "second_dimension";

        Assert.Equal(expectedFirstDimension, deserialized.FirstDimension);
        Assert.Equal(expectedMatrixScalingFactors.Count, deserialized.MatrixScalingFactors.Count);
        for (int i = 0; i < expectedMatrixScalingFactors.Count; i++)
        {
            Assert.Equal(expectedMatrixScalingFactors[i], deserialized.MatrixScalingFactors[i]);
        }
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedProrate, deserialized.Prorate);
        Assert.Equal(expectedSecondDimension, deserialized.SecondDimension);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",
            Prorate = true,
            SecondDimension = "second_dimension",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",
        };

        Assert.Null(model.Prorate);
        Assert.False(model.RawData.ContainsKey("prorate"));
        Assert.Null(model.SecondDimension);
        Assert.False(model.RawData.ContainsKey("second_dimension"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",

            Prorate = null,
            SecondDimension = null,
        };

        Assert.Null(model.Prorate);
        Assert.True(model.RawData.ContainsKey("prorate"));
        Assert.Null(model.SecondDimension);
        Assert.True(model.RawData.ContainsKey("second_dimension"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
        {
            FirstDimension = "first_dimension",
            MatrixScalingFactors =
            [
                new()
                {
                    FirstDimensionValue = "first_dimension_value",
                    ScalingFactor = "scaling_factor",
                    SecondDimensionValue = "second_dimension_value",
                },
            ],
            UnitPrice = "unit_price",

            Prorate = null,
            SecondDimension = null,
        };

        model.Validate();
    }
}

public class NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactorTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            };

        string expectedFirstDimensionValue = "first_dimension_value";
        string expectedScalingFactor = "scaling_factor";
        string expectedSecondDimensionValue = "second_dimension_value";

        Assert.Equal(expectedFirstDimensionValue, model.FirstDimensionValue);
        Assert.Equal(expectedScalingFactor, model.ScalingFactor);
        Assert.Equal(expectedSecondDimensionValue, model.SecondDimensionValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFirstDimensionValue = "first_dimension_value";
        string expectedScalingFactor = "scaling_factor";
        string expectedSecondDimensionValue = "second_dimension_value";

        Assert.Equal(expectedFirstDimensionValue, deserialized.FirstDimensionValue);
        Assert.Equal(expectedScalingFactor, deserialized.ScalingFactor);
        Assert.Equal(expectedSecondDimensionValue, deserialized.SecondDimensionValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
            };

        Assert.Null(model.SecondDimensionValue);
        Assert.False(model.RawData.ContainsKey("second_dimension_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",

                SecondDimensionValue = null,
            };

        Assert.Null(model.SecondDimensionValue);
        Assert.True(model.RawData.ContainsKey("second_dimension_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfigMatrixScalingFactor
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",

                SecondDimensionValue = null,
            };

        model.Validate();
    }
}

public class NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig value =
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
        NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig value =
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
        NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig value =
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
            JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
