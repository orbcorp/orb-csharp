using System.Collections.Generic;
using Orb.Core;
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
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
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
        List<MatrixScalingFactor2> expectedMatrixScalingFactors =
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
}

public class MatrixScalingFactor2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixScalingFactor2
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
}
