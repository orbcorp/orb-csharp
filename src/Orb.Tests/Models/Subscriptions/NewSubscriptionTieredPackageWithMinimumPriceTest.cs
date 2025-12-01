using System.Collections.Generic;
using Orb.Core;
using Orb.Models.Subscriptions;
using Models = Orb.Models;

namespace Orb.Tests.Models.Subscriptions;

public class NewSubscriptionTieredPackageWithMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewSubscriptionTieredPackageWithMinimumPrice
        {
            Cadence = NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual,
            ItemID = "item_id",
            ModelType =
                NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
            Name = "Annual fee",
            TieredPackageWithMinimumConfig = new()
            {
                PackageSize = 0,
                Tiers =
                [
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        PerUnit = "per_unit",
                        TierLowerBound = "tier_lower_bound",
                    },
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        PerUnit = "per_unit",
                        TierLowerBound = "tier_lower_bound",
                    },
                ],
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

        ApiEnum<string, NewSubscriptionTieredPackageWithMinimumPriceCadence> expectedCadence =
            NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<string, NewSubscriptionTieredPackageWithMinimumPriceModelType> expectedModelType =
            NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum;
        string expectedName = "Annual fee";
        TieredPackageWithMinimumConfig expectedTieredPackageWithMinimumConfig = new()
        {
            PackageSize = 0,
            Tiers =
            [
                new()
                {
                    MinimumAmount = "minimum_amount",
                    PerUnit = "per_unit",
                    TierLowerBound = "tier_lower_bound",
                },
                new()
                {
                    MinimumAmount = "minimum_amount",
                    PerUnit = "per_unit",
                    TierLowerBound = "tier_lower_bound",
                },
            ],
        };
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedTieredPackageWithMinimumConfig, model.TieredPackageWithMinimumConfig);
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

public class TieredPackageWithMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPackageWithMinimumConfig
        {
            PackageSize = 0,
            Tiers =
            [
                new()
                {
                    MinimumAmount = "minimum_amount",
                    PerUnit = "per_unit",
                    TierLowerBound = "tier_lower_bound",
                },
                new()
                {
                    MinimumAmount = "minimum_amount",
                    PerUnit = "per_unit",
                    TierLowerBound = "tier_lower_bound",
                },
            ],
        };

        double expectedPackageSize = 0;
        List<Tier14> expectedTiers =
        [
            new()
            {
                MinimumAmount = "minimum_amount",
                PerUnit = "per_unit",
                TierLowerBound = "tier_lower_bound",
            },
            new()
            {
                MinimumAmount = "minimum_amount",
                PerUnit = "per_unit",
                TierLowerBound = "tier_lower_bound",
            },
        ];

        Assert.Equal(expectedPackageSize, model.PackageSize);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class Tier14Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier14
        {
            MinimumAmount = "minimum_amount",
            PerUnit = "per_unit",
            TierLowerBound = "tier_lower_bound",
        };

        string expectedMinimumAmount = "minimum_amount";
        string expectedPerUnit = "per_unit";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedPerUnit, model.PerUnit);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }
}
