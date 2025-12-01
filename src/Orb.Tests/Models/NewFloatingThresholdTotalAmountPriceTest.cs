using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingThresholdTotalAmountPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingThresholdTotalAmountPrice
        {
            Cadence = NewFloatingThresholdTotalAmountPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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

        ApiEnum<string, NewFloatingThresholdTotalAmountPriceCadence> expectedCadence =
            NewFloatingThresholdTotalAmountPriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingThresholdTotalAmountPriceModelType> expectedModelType =
            NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount;
        string expectedName = "Annual fee";
        ThresholdTotalAmountConfig expectedThresholdTotalAmountConfig = new()
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
        NewFloatingThresholdTotalAmountPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedThresholdTotalAmountConfig, model.ThresholdTotalAmountConfig);
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

public class ThresholdTotalAmountConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };

        List<ConsumptionTable> expectedConsumptionTable =
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
}

public class ConsumptionTableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumptionTable { Threshold = "threshold", TotalAmount = "total_amount" };

        string expectedThreshold = "threshold";
        string expectedTotalAmount = "total_amount";

        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
    }
}
