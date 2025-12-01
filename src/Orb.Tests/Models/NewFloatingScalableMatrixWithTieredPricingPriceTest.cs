using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingScalableMatrixWithTieredPricingPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingScalableMatrixWithTieredPricingPrice
        {
            Cadence = NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
            Name = "Annual fee",
            ScalableMatrixWithTieredPricingConfig = new()
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
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
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

        ApiEnum<string, NewFloatingScalableMatrixWithTieredPricingPriceCadence> expectedCadence =
            NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<
            string,
            NewFloatingScalableMatrixWithTieredPricingPriceModelType
        > expectedModelType =
            NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing;
        string expectedName = "Annual fee";
        ScalableMatrixWithTieredPricingConfig expectedScalableMatrixWithTieredPricingConfig = new()
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
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
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
        NewFloatingScalableMatrixWithTieredPricingPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(
            expectedScalableMatrixWithTieredPricingConfig,
            model.ScalableMatrixWithTieredPricingConfig
        );
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
}

public class ScalableMatrixWithTieredPricingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalableMatrixWithTieredPricingConfig
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
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
            SecondDimension = "second_dimension",
        };

        string expectedFirstDimension = "first_dimension";
        List<MatrixScalingFactor> expectedMatrixScalingFactors =
        [
            new()
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            },
        ];
        List<Tier3> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];
        string expectedSecondDimension = "second_dimension";

        Assert.Equal(expectedFirstDimension, model.FirstDimension);
        Assert.Equal(expectedMatrixScalingFactors.Count, model.MatrixScalingFactors.Count);
        for (int i = 0; i < expectedMatrixScalingFactors.Count; i++)
        {
            Assert.Equal(expectedMatrixScalingFactors[i], model.MatrixScalingFactors[i]);
        }
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
        Assert.Equal(expectedSecondDimension, model.SecondDimension);
    }
}

public class MatrixScalingFactorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixScalingFactor
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

public class Tier3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier3 { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}
