using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingGroupedWithMeteredMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingGroupedWithMeteredMinimumPrice
        {
            Cadence = NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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

        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence> expectedCadence =
            NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual;
        string expectedCurrency = "currency";
        GroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig = new()
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType> expectedModelType =
            NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(
            expectedGroupedWithMeteredMinimumConfig,
            model.GroupedWithMeteredMinimumConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
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
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }
}

public class GroupedWithMeteredMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMeteredMinimumConfig
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" }],
        };

        string expectedGroupingKey = "x";
        string expectedMinimumUnitAmount = "minimum_unit_amount";
        string expectedPricingKey = "pricing_key";
        List<ScalingFactor> expectedScalingFactors =
        [
            new() { ScalingFactor1 = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<UnitAmount> expectedUnitAmounts =
        [
            new() { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" },
        ];

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedMinimumUnitAmount, model.MinimumUnitAmount);
        Assert.Equal(expectedPricingKey, model.PricingKey);
        Assert.Equal(expectedScalingFactors.Count, model.ScalingFactors.Count);
        for (int i = 0; i < expectedScalingFactors.Count; i++)
        {
            Assert.Equal(expectedScalingFactors[i], model.ScalingFactors[i]);
        }
        Assert.Equal(expectedScalingKey, model.ScalingKey);
        Assert.Equal(expectedUnitAmounts.Count, model.UnitAmounts.Count);
        for (int i = 0; i < expectedUnitAmounts.Count; i++)
        {
            Assert.Equal(expectedUnitAmounts[i], model.UnitAmounts[i]);
        }
    }
}

public class ScalingFactorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalingFactor
        {
            ScalingFactor1 = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string expectedScalingFactor1 = "scaling_factor";
        string expectedScalingValue = "scaling_value";

        Assert.Equal(expectedScalingFactor1, model.ScalingFactor1);
        Assert.Equal(expectedScalingValue, model.ScalingValue);
    }
}

public class UnitAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitAmount { PricingValue = "pricing_value", UnitAmount1 = "unit_amount" };

        string expectedPricingValue = "pricing_value";
        string expectedUnitAmount1 = "unit_amount";

        Assert.Equal(expectedPricingValue, model.PricingValue);
        Assert.Equal(expectedUnitAmount1, model.UnitAmount1);
    }
}
