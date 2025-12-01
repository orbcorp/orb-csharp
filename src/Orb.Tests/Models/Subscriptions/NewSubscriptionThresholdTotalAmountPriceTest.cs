using System.Collections.Generic;
using Orb.Core;
using Orb.Models.Subscriptions;
using Models = Orb.Models;

namespace Orb.Tests.Models.Subscriptions;

public class NewSubscriptionThresholdTotalAmountPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewSubscriptionThresholdTotalAmountPrice
        {
            Cadence = NewSubscriptionThresholdTotalAmountPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, NewSubscriptionThresholdTotalAmountPriceCadence> expectedCadence =
            NewSubscriptionThresholdTotalAmountPriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<string, NewSubscriptionThresholdTotalAmountPriceModelType> expectedModelType =
            NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount;
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
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewSubscriptionThresholdTotalAmountPriceConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
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
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
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
