using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingGroupedAllocationPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingGroupedAllocationPrice
        {
            Cadence = NewFloatingGroupedAllocationPriceCadence.Annual,
            Currency = "currency",
            GroupedAllocationConfig = new()
            {
                Allocation = "allocation",
                GroupingKey = "x",
                OverageUnitRate = "overage_unit_rate",
            },
            ItemID = "item_id",
            ModelType = NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
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

        ApiEnum<string, NewFloatingGroupedAllocationPriceCadence> expectedCadence =
            NewFloatingGroupedAllocationPriceCadence.Annual;
        string expectedCurrency = "currency";
        GroupedAllocationConfig expectedGroupedAllocationConfig = new()
        {
            Allocation = "allocation",
            GroupingKey = "x",
            OverageUnitRate = "overage_unit_rate",
        };
        string expectedItemID = "item_id";
        ApiEnum<string, NewFloatingGroupedAllocationPriceModelType> expectedModelType =
            NewFloatingGroupedAllocationPriceModelType.GroupedAllocation;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingGroupedAllocationPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedGroupedAllocationConfig, model.GroupedAllocationConfig);
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

public class GroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedAllocationConfig
        {
            Allocation = "allocation",
            GroupingKey = "x",
            OverageUnitRate = "overage_unit_rate",
        };

        string expectedAllocation = "allocation";
        string expectedGroupingKey = "x";
        string expectedOverageUnitRate = "overage_unit_rate";

        Assert.Equal(expectedAllocation, model.Allocation);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedOverageUnitRate, model.OverageUnitRate);
    }
}
