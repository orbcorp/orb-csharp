using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Prices;
using Models = Orb.Models;

namespace Orb.Tests.Models.Prices;

public class PriceEvaluationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluation
        {
            ExternalPriceID = "external_price_id",
            Filter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            GroupingKeys = ["case when my_event_type = 'foo' then true else false end"],
            Price = new Models::NewFloatingUnitPrice()
            {
                Cadence = Models::NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = Models::NewFloatingUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
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
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "price_id",
        };

        string expectedExternalPriceID = "external_price_id";
        string expectedFilter = "my_numeric_property > 100 AND my_other_property = 'bar'";
        List<string> expectedGroupingKeys =
        [
            "case when my_event_type = 'foo' then true else false end",
        ];
        Price expectedPrice = new Models::NewFloatingUnitPrice()
        {
            Cadence = Models::NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = Models::NewFloatingUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
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
        };
        string expectedPriceID = "price_id";

        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.Equal(expectedGroupingKeys.Count, model.GroupingKeys.Count);
        for (int i = 0; i < expectedGroupingKeys.Count; i++)
        {
            Assert.Equal(expectedGroupingKeys[i], model.GroupingKeys[i]);
        }
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceID, model.PriceID);
    }
}

public class PriceBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = PriceBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\""),
            Name = "Annual fee",
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
        };

        PriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, PriceBulkWithFiltersCadence> expectedCadence =
            PriceBulkWithFiltersCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedBulkWithFiltersConfig, model.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
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

public class PriceBulkWithFiltersBulkWithFiltersConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<FilterModel> expectedFilters = [new() { PropertyKey = "x", PropertyValue = "x" }];
        List<TierModel> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class FilterModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterModel { PropertyKey = "x", PropertyValue = "x" };

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, model.PropertyKey);
        Assert.Equal(expectedPropertyValue, model.PropertyValue);
    }
}

public class TierModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TierModel
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }
}

public class PriceGroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholds
        {
            Cadence = PriceGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            ModelType = JsonSerializer.Deserialize<JsonElement>(
                "\"grouped_with_min_max_thresholds\""
            ),
            Name = "Annual fee",
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
        };

        ApiEnum<string, PriceGroupedWithMinMaxThresholdsCadence> expectedCadence =
            PriceGroupedWithMinMaxThresholdsCadence.Annual;
        string expectedCurrency = "currency";
        PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
            new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            model.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
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

public class PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string expectedGroupingKey = "x";
        string expectedMaximumCharge = "maximum_charge";
        string expectedMinimumCharge = "minimum_charge";
        string expectedPerUnitRate = "per_unit_rate";

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedMaximumCharge, model.MaximumCharge);
        Assert.Equal(expectedMinimumCharge, model.MinimumCharge);
        Assert.Equal(expectedPerUnitRate, model.PerUnitRate);
    }
}

public class PriceCumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceCumulativeGroupedAllocation
        {
            Cadence = PriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            ModelType = JsonSerializer.Deserialize<JsonElement>(
                "\"cumulative_grouped_allocation\""
            ),
            Name = "Annual fee",
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
        };

        ApiEnum<string, PriceCumulativeGroupedAllocationCadence> expectedCadence =
            PriceCumulativeGroupedAllocationCadence.Annual;
        PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            model.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
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

public class PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string expectedCumulativeAllocation = "cumulative_allocation";
        string expectedGroupAllocation = "group_allocation";
        string expectedGroupingKey = "x";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedCumulativeAllocation, model.CumulativeAllocation);
        Assert.Equal(expectedGroupAllocation, model.GroupAllocation);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class PricePercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricePercent
        {
            Cadence = PricePercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\""),
            Name = "Annual fee",
            PercentConfig = new(0),
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
        };

        ApiEnum<string, PricePercentCadence> expectedCadence = PricePercentCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        PricePercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PricePercentConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentConfig, model.PercentConfig);
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

public class PricePercentPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricePercentPercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }
}

public class PriceEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEventOutput
        {
            Cadence = PriceEventOutputCadence.Annual,
            Currency = "currency",
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\""),
            Name = "Annual fee",
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
        };

        ApiEnum<string, PriceEventOutputCadence> expectedCadence = PriceEventOutputCadence.Annual;
        string expectedCurrency = "currency";
        PriceEventOutputEventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEventOutputConfig, model.EventOutputConfig);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
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

public class PriceEventOutputEventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string expectedUnitRatingKey = "x";
        string expectedDefaultUnitRate = "default_unit_rate";
        string expectedGroupingKey = "grouping_key";

        Assert.Equal(expectedUnitRatingKey, model.UnitRatingKey);
        Assert.Equal(expectedDefaultUnitRate, model.DefaultUnitRate);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
    }
}
