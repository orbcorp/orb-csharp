using System.Collections.Generic;
using Orb.Core;
using Orb.Models.Subscriptions;
using Models = Orb.Models;

namespace Orb.Tests.Models.Subscriptions;

public class NewSubscriptionTieredWithMinimumPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewSubscriptionTieredWithMinimumPrice
        {
            Cadence = NewSubscriptionTieredWithMinimumPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum,
            Name = "Annual fee",
            TieredWithMinimumConfig = new()
            {
                Tiers =
                [
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                    new()
                    {
                        MinimumAmount = "minimum_amount",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                ],
                HideZeroAmountTiers = true,
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

        ApiEnum<string, NewSubscriptionTieredWithMinimumPriceCadence> expectedCadence =
            NewSubscriptionTieredWithMinimumPriceCadence.Annual;
        string expectedItemID = "item_id";
        ApiEnum<string, NewSubscriptionTieredWithMinimumPriceModelType> expectedModelType =
            NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum;
        string expectedName = "Annual fee";
        TieredWithMinimumConfig expectedTieredWithMinimumConfig = new()
        {
            Tiers =
            [
                new()
                {
                    MinimumAmount = "minimum_amount",
                    TierLowerBound = "tier_lower_bound",
                    UnitAmount = "unit_amount",
                },
                new()
                {
                    MinimumAmount = "minimum_amount",
                    TierLowerBound = "tier_lower_bound",
                    UnitAmount = "unit_amount",
                },
            ],
            HideZeroAmountTiers = true,
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
        NewSubscriptionTieredWithMinimumPriceConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedTieredWithMinimumConfig, model.TieredWithMinimumConfig);
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

public class TieredWithMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithMinimumConfig
        {
            Tiers =
            [
                new()
                {
                    MinimumAmount = "minimum_amount",
                    TierLowerBound = "tier_lower_bound",
                    UnitAmount = "unit_amount",
                },
                new()
                {
                    MinimumAmount = "minimum_amount",
                    TierLowerBound = "tier_lower_bound",
                    UnitAmount = "unit_amount",
                },
            ],
            HideZeroAmountTiers = true,
            Prorate = true,
        };

        List<Tier15> expectedTiers =
        [
            new()
            {
                MinimumAmount = "minimum_amount",
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            },
            new()
            {
                MinimumAmount = "minimum_amount",
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            },
        ];
        bool expectedHideZeroAmountTiers = true;
        bool expectedProrate = true;

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
        Assert.Equal(expectedHideZeroAmountTiers, model.HideZeroAmountTiers);
        Assert.Equal(expectedProrate, model.Prorate);
    }
}

public class Tier15Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier15
        {
            MinimumAmount = "minimum_amount",
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string expectedMinimumAmount = "minimum_amount";
        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}
