using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class UnitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Unit
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = BillingMode.InAdvance,
            Cadence = UnitCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilterField.PriceID,
                    Operator = CompositePriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"unit\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = UnitPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, BillingMode> expectedBillingMode = BillingMode.InAdvance;
        ApiEnum<string, UnitCadence> expectedCadence = UnitCadence.OneTime;
        List<CompositePriceFilter> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilterField.PriceID,
                Operator = CompositePriceFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        UnitConversionRateConfig expectedConversionRateConfig = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        UnitModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"unit\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, UnitPriceType> expectedPriceType = UnitPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        UnitConfig expectedUnitConfig = new() { UnitAmount = "unit_amount", Prorated = true };
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedUnitConfig, model.UnitConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter
        {
            Field = CompositePriceFilterField.PriceID,
            Operator = CompositePriceFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilterField> expectedField =
            CompositePriceFilterField.PriceID;
        ApiEnum<string, CompositePriceFilterOperator> expectedOperator =
            CompositePriceFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class TieredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tiered
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = TieredBillingMode.InAdvance,
            Cadence = TieredCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilterModelField.PriceID,
                    Operator = CompositePriceFilterModelOperator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = TieredPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            TieredConfig = new()
            {
                Tiers =
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ],
                Prorated = true,
            },
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, TieredBillingMode> expectedBillingMode = TieredBillingMode.InAdvance;
        ApiEnum<string, TieredCadence> expectedCadence = TieredCadence.OneTime;
        List<CompositePriceFilterModel> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilterModelField.PriceID,
                Operator = CompositePriceFilterModelOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        TieredConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        TieredModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, TieredPriceType> expectedPriceType = TieredPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        TieredConfig expectedTieredConfig = new()
        {
            Tiers =
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ],
            Prorated = true,
        };
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedTieredConfig, model.TieredConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilterModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilterModel
        {
            Field = CompositePriceFilterModelField.PriceID,
            Operator = CompositePriceFilterModelOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilterModelField> expectedField =
            CompositePriceFilterModelField.PriceID;
        ApiEnum<string, CompositePriceFilterModelOperator> expectedOperator =
            CompositePriceFilterModelOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class BulkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Bulk
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = BulkBillingMode.InAdvance,
            BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
            Cadence = BulkCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter1Field.PriceID,
                    Operator = CompositePriceFilter1Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = BulkPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, BulkBillingMode> expectedBillingMode = BulkBillingMode.InAdvance;
        BulkConfig expectedBulkConfig = new(
            [new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]
        );
        ApiEnum<string, BulkCadence> expectedCadence = BulkCadence.OneTime;
        List<CompositePriceFilter1> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter1Field.PriceID,
                Operator = CompositePriceFilter1Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        BulkConversionRateConfig expectedConversionRateConfig = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        BulkModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, BulkPriceType> expectedPriceType = BulkPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedBulkConfig, model.BulkConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter1
        {
            Field = CompositePriceFilter1Field.PriceID,
            Operator = CompositePriceFilter1Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter1Field> expectedField =
            CompositePriceFilter1Field.PriceID;
        ApiEnum<string, CompositePriceFilter1Operator> expectedOperator =
            CompositePriceFilter1Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class BulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkWithFilters
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = BulkWithFiltersBillingMode.InAdvance,
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = BulkWithFiltersCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter2Field.PriceID,
                    Operator = CompositePriceFilter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = BulkWithFiltersPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, BulkWithFiltersBillingMode> expectedBillingMode =
            BulkWithFiltersBillingMode.InAdvance;
        BulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, BulkWithFiltersCadence> expectedCadence = BulkWithFiltersCadence.OneTime;
        List<CompositePriceFilter2> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter2Field.PriceID,
                Operator = CompositePriceFilter2Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        BulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        BulkWithFiltersModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, BulkWithFiltersPriceType> expectedPriceType =
            BulkWithFiltersPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedBulkWithFiltersConfig, model.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class BulkWithFiltersConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<Filter24> expectedFilters = [new() { PropertyKey = "x", PropertyValue = "x" }];
        List<Tier16> expectedTiers =
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

public class Filter24Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter24 { PropertyKey = "x", PropertyValue = "x" };

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, model.PropertyKey);
        Assert.Equal(expectedPropertyValue, model.PropertyValue);
    }
}

public class Tier16Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier16 { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" };

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }
}

public class CompositePriceFilter2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter2
        {
            Field = CompositePriceFilter2Field.PriceID,
            Operator = CompositePriceFilter2Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter2Field> expectedField =
            CompositePriceFilter2Field.PriceID;
        ApiEnum<string, CompositePriceFilter2Operator> expectedOperator =
            CompositePriceFilter2Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class PackageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Package
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = PackageBillingMode.InAdvance,
            Cadence = PackageCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter3Field.PriceID,
                    Operator = CompositePriceFilter3Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"package\""),
            Name = "name",
            PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
            PlanPhaseOrder = 0,
            PriceType = PackagePriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, PackageBillingMode> expectedBillingMode = PackageBillingMode.InAdvance;
        ApiEnum<string, PackageCadence> expectedCadence = PackageCadence.OneTime;
        List<CompositePriceFilter3> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter3Field.PriceID,
                Operator = CompositePriceFilter3Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        PackageConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        PackageModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"package\"");
        string expectedName = "name";
        PackageConfig expectedPackageConfig = new()
        {
            PackageAmount = "package_amount",
            PackageSize = 1,
        };
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, PackagePriceType> expectedPriceType = PackagePriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPackageConfig, model.PackageConfig);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter3
        {
            Field = CompositePriceFilter3Field.PriceID,
            Operator = CompositePriceFilter3Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter3Field> expectedField =
            CompositePriceFilter3Field.PriceID;
        ApiEnum<string, CompositePriceFilter3Operator> expectedOperator =
            CompositePriceFilter3Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class MatrixTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Matrix
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = MatrixBillingMode.InAdvance,
            Cadence = MatrixCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter4Field.PriceID,
                    Operator = CompositePriceFilter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"matrix\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = MatrixPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, MatrixBillingMode> expectedBillingMode = MatrixBillingMode.InAdvance;
        ApiEnum<string, MatrixCadence> expectedCadence = MatrixCadence.OneTime;
        List<CompositePriceFilter4> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter4Field.PriceID,
                Operator = CompositePriceFilter4Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        MatrixConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        MatrixConfig expectedMatrixConfig = new()
        {
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        MatrixModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"matrix\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, MatrixPriceType> expectedPriceType = MatrixPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMatrixConfig, model.MatrixConfig);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter4Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter4
        {
            Field = CompositePriceFilter4Field.PriceID,
            Operator = CompositePriceFilter4Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter4Field> expectedField =
            CompositePriceFilter4Field.PriceID;
        ApiEnum<string, CompositePriceFilter4Operator> expectedOperator =
            CompositePriceFilter4Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class ThresholdTotalAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThresholdTotalAmount
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = ThresholdTotalAmountBillingMode.InAdvance,
            Cadence = ThresholdTotalAmountCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter5Field.PriceID,
                    Operator = CompositePriceFilter5Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"threshold_total_amount\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = ThresholdTotalAmountPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            ThresholdTotalAmountConfig = new()
            {
                ConsumptionTable =
                [
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    new() { Threshold = "threshold", TotalAmount = "total_amount" },
                ],
                Prorate = true,
            },
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, ThresholdTotalAmountBillingMode> expectedBillingMode =
            ThresholdTotalAmountBillingMode.InAdvance;
        ApiEnum<string, ThresholdTotalAmountCadence> expectedCadence =
            ThresholdTotalAmountCadence.OneTime;
        List<CompositePriceFilter5> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter5Field.PriceID,
                Operator = CompositePriceFilter5Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        ThresholdTotalAmountConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        ThresholdTotalAmountModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"threshold_total_amount\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, ThresholdTotalAmountPriceType> expectedPriceType =
            ThresholdTotalAmountPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        ThresholdTotalAmountThresholdTotalAmountConfig expectedThresholdTotalAmountConfig = new()
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedThresholdTotalAmountConfig, model.ThresholdTotalAmountConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter5Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter5
        {
            Field = CompositePriceFilter5Field.PriceID,
            Operator = CompositePriceFilter5Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter5Field> expectedField =
            CompositePriceFilter5Field.PriceID;
        ApiEnum<string, CompositePriceFilter5Operator> expectedOperator =
            CompositePriceFilter5Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class ThresholdTotalAmountThresholdTotalAmountConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThresholdTotalAmountThresholdTotalAmountConfig
        {
            ConsumptionTable =
            [
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
                new() { Threshold = "threshold", TotalAmount = "total_amount" },
            ],
            Prorate = true,
        };

        List<ConsumptionTable1> expectedConsumptionTable =
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

public class ConsumptionTable1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumptionTable1 { Threshold = "threshold", TotalAmount = "total_amount" };

        string expectedThreshold = "threshold";
        string expectedTotalAmount = "total_amount";

        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
    }
}

public class TieredPackageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPackage
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = TieredPackageBillingMode.InAdvance,
            Cadence = TieredPackageCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter6Field.PriceID,
                    Operator = CompositePriceFilter6Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_package\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = TieredPackagePriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            TieredPackageConfig = new()
            {
                PackageSize = "package_size",
                Tiers =
                [
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                ],
            },
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, TieredPackageBillingMode> expectedBillingMode =
            TieredPackageBillingMode.InAdvance;
        ApiEnum<string, TieredPackageCadence> expectedCadence = TieredPackageCadence.OneTime;
        List<CompositePriceFilter6> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter6Field.PriceID,
                Operator = CompositePriceFilter6Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        TieredPackageConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        TieredPackageModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_package\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, TieredPackagePriceType> expectedPriceType =
            TieredPackagePriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        TieredPackageTieredPackageConfig expectedTieredPackageConfig = new()
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedTieredPackageConfig, model.TieredPackageConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter6Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter6
        {
            Field = CompositePriceFilter6Field.PriceID,
            Operator = CompositePriceFilter6Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter6Field> expectedField =
            CompositePriceFilter6Field.PriceID;
        ApiEnum<string, CompositePriceFilter6Operator> expectedOperator =
            CompositePriceFilter6Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class TieredPackageTieredPackageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPackageTieredPackageConfig
        {
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string expectedPackageSize = "package_size";
        List<Tier17> expectedTiers =
        [
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedPackageSize, model.PackageSize);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class Tier17Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier17 { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" };

        string expectedPerUnit = "per_unit";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedPerUnit, model.PerUnit);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }
}

public class TieredWithMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithMinimum
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = TieredWithMinimumBillingMode.InAdvance,
            Cadence = TieredWithMinimumCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter7Field.PriceID,
                    Operator = CompositePriceFilter7Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_minimum\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = TieredWithMinimumPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, TieredWithMinimumBillingMode> expectedBillingMode =
            TieredWithMinimumBillingMode.InAdvance;
        ApiEnum<string, TieredWithMinimumCadence> expectedCadence =
            TieredWithMinimumCadence.OneTime;
        List<CompositePriceFilter7> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter7Field.PriceID,
                Operator = CompositePriceFilter7Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        TieredWithMinimumConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        TieredWithMinimumModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_minimum\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, TieredWithMinimumPriceType> expectedPriceType =
            TieredWithMinimumPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        TieredWithMinimumTieredWithMinimumConfig expectedTieredWithMinimumConfig = new()
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
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedTieredWithMinimumConfig, model.TieredWithMinimumConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter7Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter7
        {
            Field = CompositePriceFilter7Field.PriceID,
            Operator = CompositePriceFilter7Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter7Field> expectedField =
            CompositePriceFilter7Field.PriceID;
        ApiEnum<string, CompositePriceFilter7Operator> expectedOperator =
            CompositePriceFilter7Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class TieredWithMinimumTieredWithMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithMinimumTieredWithMinimumConfig
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

        List<Tier18> expectedTiers =
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

public class Tier18Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier18
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

public class GroupedTieredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedTiered
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = GroupedTieredBillingMode.InAdvance,
            Cadence = GroupedTieredCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter8Field.PriceID,
                    Operator = CompositePriceFilter8Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            GroupedTieredConfig = new()
            {
                GroupingKey = "x",
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
            },
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"grouped_tiered\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = GroupedTieredPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, GroupedTieredBillingMode> expectedBillingMode =
            GroupedTieredBillingMode.InAdvance;
        ApiEnum<string, GroupedTieredCadence> expectedCadence = GroupedTieredCadence.OneTime;
        List<CompositePriceFilter8> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter8Field.PriceID,
                Operator = CompositePriceFilter8Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        GroupedTieredConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        GroupedTieredGroupedTieredConfig expectedGroupedTieredConfig = new()
        {
            GroupingKey = "x",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        GroupedTieredModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_tiered\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, GroupedTieredPriceType> expectedPriceType =
            GroupedTieredPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedGroupedTieredConfig, model.GroupedTieredConfig);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter8Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter8
        {
            Field = CompositePriceFilter8Field.PriceID,
            Operator = CompositePriceFilter8Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter8Field> expectedField =
            CompositePriceFilter8Field.PriceID;
        ApiEnum<string, CompositePriceFilter8Operator> expectedOperator =
            CompositePriceFilter8Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class GroupedTieredGroupedTieredConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedTieredGroupedTieredConfig
        {
            GroupingKey = "x",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };

        string expectedGroupingKey = "x";
        List<Tier19> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class Tier19Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier19 { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class TieredPackageWithMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPackageWithMinimum
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = TieredPackageWithMinimumBillingMode.InAdvance,
            Cadence = TieredPackageWithMinimumCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter9Field.PriceID,
                    Operator = CompositePriceFilter9Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_package_with_minimum\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = TieredPackageWithMinimumPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, TieredPackageWithMinimumBillingMode> expectedBillingMode =
            TieredPackageWithMinimumBillingMode.InAdvance;
        ApiEnum<string, TieredPackageWithMinimumCadence> expectedCadence =
            TieredPackageWithMinimumCadence.OneTime;
        List<CompositePriceFilter9> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter9Field.PriceID,
                Operator = CompositePriceFilter9Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        TieredPackageWithMinimumConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        TieredPackageWithMinimumModelType expectedModelType =
            JsonSerializer.Deserialize<JsonElement>("\"tiered_package_with_minimum\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, TieredPackageWithMinimumPriceType> expectedPriceType =
            TieredPackageWithMinimumPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        TieredPackageWithMinimumTieredPackageWithMinimumConfig expectedTieredPackageWithMinimumConfig =
            new()
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
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedTieredPackageWithMinimumConfig, model.TieredPackageWithMinimumConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter9Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter9
        {
            Field = CompositePriceFilter9Field.PriceID,
            Operator = CompositePriceFilter9Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter9Field> expectedField =
            CompositePriceFilter9Field.PriceID;
        ApiEnum<string, CompositePriceFilter9Operator> expectedOperator =
            CompositePriceFilter9Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class TieredPackageWithMinimumTieredPackageWithMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPackageWithMinimumTieredPackageWithMinimumConfig
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
        List<Tier20> expectedTiers =
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

public class Tier20Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier20
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

public class PackageWithAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PackageWithAllocation
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = PackageWithAllocationBillingMode.InAdvance,
            Cadence = PackageWithAllocationCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter10Field.PriceID,
                    Operator = CompositePriceFilter10Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"package_with_allocation\""),
            Name = "name",
            PackageWithAllocationConfig = new()
            {
                Allocation = "allocation",
                PackageAmount = "package_amount",
                PackageSize = "package_size",
            },
            PlanPhaseOrder = 0,
            PriceType = PackageWithAllocationPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, PackageWithAllocationBillingMode> expectedBillingMode =
            PackageWithAllocationBillingMode.InAdvance;
        ApiEnum<string, PackageWithAllocationCadence> expectedCadence =
            PackageWithAllocationCadence.OneTime;
        List<CompositePriceFilter10> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter10Field.PriceID,
                Operator = CompositePriceFilter10Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        PackageWithAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        PackageWithAllocationModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"package_with_allocation\""
        );
        string expectedName = "name";
        PackageWithAllocationPackageWithAllocationConfig expectedPackageWithAllocationConfig = new()
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, PackageWithAllocationPriceType> expectedPriceType =
            PackageWithAllocationPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPackageWithAllocationConfig, model.PackageWithAllocationConfig);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter10Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter10
        {
            Field = CompositePriceFilter10Field.PriceID,
            Operator = CompositePriceFilter10Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter10Field> expectedField =
            CompositePriceFilter10Field.PriceID;
        ApiEnum<string, CompositePriceFilter10Operator> expectedOperator =
            CompositePriceFilter10Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class PackageWithAllocationPackageWithAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PackageWithAllocationPackageWithAllocationConfig
        {
            Allocation = "allocation",
            PackageAmount = "package_amount",
            PackageSize = "package_size",
        };

        string expectedAllocation = "allocation";
        string expectedPackageAmount = "package_amount";
        string expectedPackageSize = "package_size";

        Assert.Equal(expectedAllocation, model.Allocation);
        Assert.Equal(expectedPackageAmount, model.PackageAmount);
        Assert.Equal(expectedPackageSize, model.PackageSize);
    }
}

public class UnitWithPercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitWithPercent
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = UnitWithPercentBillingMode.InAdvance,
            Cadence = UnitWithPercentCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter11Field.PriceID,
                    Operator = CompositePriceFilter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"unit_with_percent\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = UnitWithPercentPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, UnitWithPercentBillingMode> expectedBillingMode =
            UnitWithPercentBillingMode.InAdvance;
        ApiEnum<string, UnitWithPercentCadence> expectedCadence = UnitWithPercentCadence.OneTime;
        List<CompositePriceFilter11> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter11Field.PriceID,
                Operator = CompositePriceFilter11Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        UnitWithPercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        UnitWithPercentModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"unit_with_percent\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, UnitWithPercentPriceType> expectedPriceType =
            UnitWithPercentPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        UnitWithPercentUnitWithPercentConfig expectedUnitWithPercentConfig = new()
        {
            Percent = "percent",
            UnitAmount = "unit_amount",
        };
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedUnitWithPercentConfig, model.UnitWithPercentConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter11Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter11
        {
            Field = CompositePriceFilter11Field.PriceID,
            Operator = CompositePriceFilter11Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter11Field> expectedField =
            CompositePriceFilter11Field.PriceID;
        ApiEnum<string, CompositePriceFilter11Operator> expectedOperator =
            CompositePriceFilter11Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class UnitWithPercentUnitWithPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitWithPercentUnitWithPercentConfig
        {
            Percent = "percent",
            UnitAmount = "unit_amount",
        };

        string expectedPercent = "percent";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedPercent, model.Percent);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class MatrixWithAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixWithAllocation
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = MatrixWithAllocationBillingMode.InAdvance,
            Cadence = MatrixWithAllocationCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter12Field.PriceID,
                    Operator = CompositePriceFilter12Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"matrix_with_allocation\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = MatrixWithAllocationPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, MatrixWithAllocationBillingMode> expectedBillingMode =
            MatrixWithAllocationBillingMode.InAdvance;
        ApiEnum<string, MatrixWithAllocationCadence> expectedCadence =
            MatrixWithAllocationCadence.OneTime;
        List<CompositePriceFilter12> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter12Field.PriceID,
                Operator = CompositePriceFilter12Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        MatrixWithAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        MatrixWithAllocationConfig expectedMatrixWithAllocationConfig = new()
        {
            Allocation = "allocation",
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        MatrixWithAllocationModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"matrix_with_allocation\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, MatrixWithAllocationPriceType> expectedPriceType =
            MatrixWithAllocationPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMatrixWithAllocationConfig, model.MatrixWithAllocationConfig);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter12Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter12
        {
            Field = CompositePriceFilter12Field.PriceID,
            Operator = CompositePriceFilter12Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter12Field> expectedField =
            CompositePriceFilter12Field.PriceID;
        ApiEnum<string, CompositePriceFilter12Operator> expectedOperator =
            CompositePriceFilter12Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class TieredWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithProration
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = TieredWithProrationBillingMode.InAdvance,
            Cadence = TieredWithProrationCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter13Field.PriceID,
                    Operator = CompositePriceFilter13Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = TieredWithProrationPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, TieredWithProrationBillingMode> expectedBillingMode =
            TieredWithProrationBillingMode.InAdvance;
        ApiEnum<string, TieredWithProrationCadence> expectedCadence =
            TieredWithProrationCadence.OneTime;
        List<CompositePriceFilter13> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter13Field.PriceID,
                Operator = CompositePriceFilter13Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        TieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        TieredWithProrationModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, TieredWithProrationPriceType> expectedPriceType =
            TieredWithProrationPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        TieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig = new(
            [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
        );
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedTieredWithProrationConfig, model.TieredWithProrationConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter13Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter13
        {
            Field = CompositePriceFilter13Field.PriceID,
            Operator = CompositePriceFilter13Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter13Field> expectedField =
            CompositePriceFilter13Field.PriceID;
        ApiEnum<string, CompositePriceFilter13Operator> expectedOperator =
            CompositePriceFilter13Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class TieredWithProrationTieredWithProrationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        List<Tier21> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class Tier21Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier21 { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class UnitWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitWithProration
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = UnitWithProrationBillingMode.InAdvance,
            Cadence = UnitWithProrationCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter14Field.PriceID,
                    Operator = CompositePriceFilter14Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"unit_with_proration\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = UnitWithProrationPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            UnitWithProrationConfig = new("unit_amount"),
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, UnitWithProrationBillingMode> expectedBillingMode =
            UnitWithProrationBillingMode.InAdvance;
        ApiEnum<string, UnitWithProrationCadence> expectedCadence =
            UnitWithProrationCadence.OneTime;
        List<CompositePriceFilter14> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter14Field.PriceID,
                Operator = CompositePriceFilter14Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        UnitWithProrationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        UnitWithProrationModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"unit_with_proration\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, UnitWithProrationPriceType> expectedPriceType =
            UnitWithProrationPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        UnitWithProrationUnitWithProrationConfig expectedUnitWithProrationConfig = new(
            "unit_amount"
        );
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedUnitWithProrationConfig, model.UnitWithProrationConfig);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter14Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter14
        {
            Field = CompositePriceFilter14Field.PriceID,
            Operator = CompositePriceFilter14Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter14Field> expectedField =
            CompositePriceFilter14Field.PriceID;
        ApiEnum<string, CompositePriceFilter14Operator> expectedOperator =
            CompositePriceFilter14Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class UnitWithProrationUnitWithProrationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitWithProrationUnitWithProrationConfig { UnitAmount = "unit_amount" };

        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class GroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedAllocation
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = GroupedAllocationBillingMode.InAdvance,
            Cadence = GroupedAllocationCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter15Field.PriceID,
                    Operator = CompositePriceFilter15Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            GroupedAllocationConfig = new()
            {
                Allocation = "allocation",
                GroupingKey = "x",
                OverageUnitRate = "overage_unit_rate",
            },
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"grouped_allocation\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = GroupedAllocationPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, GroupedAllocationBillingMode> expectedBillingMode =
            GroupedAllocationBillingMode.InAdvance;
        ApiEnum<string, GroupedAllocationCadence> expectedCadence =
            GroupedAllocationCadence.OneTime;
        List<CompositePriceFilter15> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter15Field.PriceID,
                Operator = CompositePriceFilter15Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        GroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        GroupedAllocationGroupedAllocationConfig expectedGroupedAllocationConfig = new()
        {
            Allocation = "allocation",
            GroupingKey = "x",
            OverageUnitRate = "overage_unit_rate",
        };
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        GroupedAllocationModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_allocation\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, GroupedAllocationPriceType> expectedPriceType =
            GroupedAllocationPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedGroupedAllocationConfig, model.GroupedAllocationConfig);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter15Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter15
        {
            Field = CompositePriceFilter15Field.PriceID,
            Operator = CompositePriceFilter15Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter15Field> expectedField =
            CompositePriceFilter15Field.PriceID;
        ApiEnum<string, CompositePriceFilter15Operator> expectedOperator =
            CompositePriceFilter15Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class GroupedAllocationGroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedAllocationGroupedAllocationConfig
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

public class BulkWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkWithProration
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = BulkWithProrationBillingMode.InAdvance,
            BulkWithProrationConfig = new(
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ]
            ),
            Cadence = BulkWithProrationCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter16Field.PriceID,
                    Operator = CompositePriceFilter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_proration\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = BulkWithProrationPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, BulkWithProrationBillingMode> expectedBillingMode =
            BulkWithProrationBillingMode.InAdvance;
        BulkWithProrationBulkWithProrationConfig expectedBulkWithProrationConfig = new(
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ]
        );
        ApiEnum<string, BulkWithProrationCadence> expectedCadence =
            BulkWithProrationCadence.OneTime;
        List<CompositePriceFilter16> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter16Field.PriceID,
                Operator = CompositePriceFilter16Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        BulkWithProrationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        BulkWithProrationModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_proration\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, BulkWithProrationPriceType> expectedPriceType =
            BulkWithProrationPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedBulkWithProrationConfig, model.BulkWithProrationConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class BulkWithProrationBulkWithProrationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkWithProrationBulkWithProrationConfig
        {
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<Tier22> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class Tier22Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier22 { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" };

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }
}

public class CompositePriceFilter16Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter16
        {
            Field = CompositePriceFilter16Field.PriceID,
            Operator = CompositePriceFilter16Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter16Field> expectedField =
            CompositePriceFilter16Field.PriceID;
        ApiEnum<string, CompositePriceFilter16Operator> expectedOperator =
            CompositePriceFilter16Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class GroupedWithProratedMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithProratedMinimum
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = GroupedWithProratedMinimumBillingMode.InAdvance,
            Cadence = GroupedWithProratedMinimumCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter17Field.PriceID,
                    Operator = CompositePriceFilter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            GroupedWithProratedMinimumConfig = new()
            {
                GroupingKey = "x",
                Minimum = "minimum",
                UnitRate = "unit_rate",
            },
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>(
                "\"grouped_with_prorated_minimum\""
            ),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = GroupedWithProratedMinimumPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, GroupedWithProratedMinimumBillingMode> expectedBillingMode =
            GroupedWithProratedMinimumBillingMode.InAdvance;
        ApiEnum<string, GroupedWithProratedMinimumCadence> expectedCadence =
            GroupedWithProratedMinimumCadence.OneTime;
        List<CompositePriceFilter17> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter17Field.PriceID,
                Operator = CompositePriceFilter17Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        GroupedWithProratedMinimumConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        GroupedWithProratedMinimumGroupedWithProratedMinimumConfig expectedGroupedWithProratedMinimumConfig =
            new()
            {
                GroupingKey = "x",
                Minimum = "minimum",
                UnitRate = "unit_rate",
            };
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        GroupedWithProratedMinimumModelType expectedModelType =
            JsonSerializer.Deserialize<JsonElement>("\"grouped_with_prorated_minimum\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, GroupedWithProratedMinimumPriceType> expectedPriceType =
            GroupedWithProratedMinimumPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(
            expectedGroupedWithProratedMinimumConfig,
            model.GroupedWithProratedMinimumConfig
        );
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter17Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter17
        {
            Field = CompositePriceFilter17Field.PriceID,
            Operator = CompositePriceFilter17Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter17Field> expectedField =
            CompositePriceFilter17Field.PriceID;
        ApiEnum<string, CompositePriceFilter17Operator> expectedOperator =
            CompositePriceFilter17Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class GroupedWithProratedMinimumGroupedWithProratedMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithProratedMinimumGroupedWithProratedMinimumConfig
        {
            GroupingKey = "x",
            Minimum = "minimum",
            UnitRate = "unit_rate",
        };

        string expectedGroupingKey = "x";
        string expectedMinimum = "minimum";
        string expectedUnitRate = "unit_rate";

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedUnitRate, model.UnitRate);
    }
}

public class GroupedWithMeteredMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMeteredMinimum
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = GroupedWithMeteredMinimumBillingMode.InAdvance,
            Cadence = GroupedWithMeteredMinimumCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter18Field.PriceID,
                    Operator = CompositePriceFilter18Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" },
                ],
            },
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_metered_minimum\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = GroupedWithMeteredMinimumPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, GroupedWithMeteredMinimumBillingMode> expectedBillingMode =
            GroupedWithMeteredMinimumBillingMode.InAdvance;
        ApiEnum<string, GroupedWithMeteredMinimumCadence> expectedCadence =
            GroupedWithMeteredMinimumCadence.OneTime;
        List<CompositePriceFilter18> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter18Field.PriceID,
                Operator = CompositePriceFilter18Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        GroupedWithMeteredMinimumConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        GroupedWithMeteredMinimumGroupedWithMeteredMinimumConfig expectedGroupedWithMeteredMinimumConfig =
            new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" },
                ],
            };
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        GroupedWithMeteredMinimumModelType expectedModelType =
            JsonSerializer.Deserialize<JsonElement>("\"grouped_with_metered_minimum\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, GroupedWithMeteredMinimumPriceType> expectedPriceType =
            GroupedWithMeteredMinimumPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(
            expectedGroupedWithMeteredMinimumConfig,
            model.GroupedWithMeteredMinimumConfig
        );
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter18Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter18
        {
            Field = CompositePriceFilter18Field.PriceID,
            Operator = CompositePriceFilter18Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter18Field> expectedField =
            CompositePriceFilter18Field.PriceID;
        ApiEnum<string, CompositePriceFilter18Operator> expectedOperator =
            CompositePriceFilter18Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class GroupedWithMeteredMinimumGroupedWithMeteredMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMeteredMinimumGroupedWithMeteredMinimumConfig
        {
            GroupingKey = "x",
            MinimumUnitAmount = "minimum_unit_amount",
            PricingKey = "pricing_key",
            ScalingFactors =
            [
                new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
            ],
            ScalingKey = "scaling_key",
            UnitAmounts = [new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" }],
        };

        string expectedGroupingKey = "x";
        string expectedMinimumUnitAmount = "minimum_unit_amount";
        string expectedPricingKey = "pricing_key";
        List<ScalingFactor1> expectedScalingFactors =
        [
            new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
        ];
        string expectedScalingKey = "scaling_key";
        List<UnitAmount3> expectedUnitAmounts =
        [
            new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" },
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

public class ScalingFactor1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalingFactor1
        {
            ScalingFactor = "scaling_factor",
            ScalingValue = "scaling_value",
        };

        string expectedScalingFactor = "scaling_factor";
        string expectedScalingValue = "scaling_value";

        Assert.Equal(expectedScalingFactor, model.ScalingFactor);
        Assert.Equal(expectedScalingValue, model.ScalingValue);
    }
}

public class UnitAmount3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitAmount3 { PricingValue = "pricing_value", UnitAmount = "unit_amount" };

        string expectedPricingValue = "pricing_value";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedPricingValue, model.PricingValue);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class GroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = GroupedWithMinMaxThresholdsBillingMode.InAdvance,
            Cadence = GroupedWithMinMaxThresholdsCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter19Field.PriceID,
                    Operator = CompositePriceFilter19Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>(
                "\"grouped_with_min_max_thresholds\""
            ),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = GroupedWithMinMaxThresholdsPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, GroupedWithMinMaxThresholdsBillingMode> expectedBillingMode =
            GroupedWithMinMaxThresholdsBillingMode.InAdvance;
        ApiEnum<string, GroupedWithMinMaxThresholdsCadence> expectedCadence =
            GroupedWithMinMaxThresholdsCadence.OneTime;
        List<CompositePriceFilter19> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter19Field.PriceID,
                Operator = CompositePriceFilter19Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        GroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        GroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig = new()
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        GroupedWithMinMaxThresholdsModelType expectedModelType =
            JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, GroupedWithMinMaxThresholdsPriceType> expectedPriceType =
            GroupedWithMinMaxThresholdsPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            model.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter19Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter19
        {
            Field = CompositePriceFilter19Field.PriceID,
            Operator = CompositePriceFilter19Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter19Field> expectedField =
            CompositePriceFilter19Field.PriceID;
        ApiEnum<string, CompositePriceFilter19Operator> expectedOperator =
            CompositePriceFilter19Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class GroupedWithMinMaxThresholdsConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMinMaxThresholdsConfig
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

public class MatrixWithDisplayNameTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixWithDisplayName
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = MatrixWithDisplayNameBillingMode.InAdvance,
            Cadence = MatrixWithDisplayNameCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter20Field.PriceID,
                    Operator = CompositePriceFilter20Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            MatrixWithDisplayNameConfig = new()
            {
                Dimension = "dimension",
                UnitAmounts =
                [
                    new()
                    {
                        DimensionValue = "dimension_value",
                        DisplayName = "display_name",
                        UnitAmount = "unit_amount",
                    },
                ],
            },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"matrix_with_display_name\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = MatrixWithDisplayNamePriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, MatrixWithDisplayNameBillingMode> expectedBillingMode =
            MatrixWithDisplayNameBillingMode.InAdvance;
        ApiEnum<string, MatrixWithDisplayNameCadence> expectedCadence =
            MatrixWithDisplayNameCadence.OneTime;
        List<CompositePriceFilter20> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter20Field.PriceID,
                Operator = CompositePriceFilter20Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        MatrixWithDisplayNameConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        MatrixWithDisplayNameMatrixWithDisplayNameConfig expectedMatrixWithDisplayNameConfig = new()
        {
            Dimension = "dimension",
            UnitAmounts =
            [
                new()
                {
                    DimensionValue = "dimension_value",
                    DisplayName = "display_name",
                    UnitAmount = "unit_amount",
                },
            ],
        };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        MatrixWithDisplayNameModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"matrix_with_display_name\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, MatrixWithDisplayNamePriceType> expectedPriceType =
            MatrixWithDisplayNamePriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMatrixWithDisplayNameConfig, model.MatrixWithDisplayNameConfig);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter20Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter20
        {
            Field = CompositePriceFilter20Field.PriceID,
            Operator = CompositePriceFilter20Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter20Field> expectedField =
            CompositePriceFilter20Field.PriceID;
        ApiEnum<string, CompositePriceFilter20Operator> expectedOperator =
            CompositePriceFilter20Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class MatrixWithDisplayNameMatrixWithDisplayNameConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixWithDisplayNameMatrixWithDisplayNameConfig
        {
            Dimension = "dimension",
            UnitAmounts =
            [
                new()
                {
                    DimensionValue = "dimension_value",
                    DisplayName = "display_name",
                    UnitAmount = "unit_amount",
                },
            ],
        };

        string expectedDimension = "dimension";
        List<UnitAmount4> expectedUnitAmounts =
        [
            new()
            {
                DimensionValue = "dimension_value",
                DisplayName = "display_name",
                UnitAmount = "unit_amount",
            },
        ];

        Assert.Equal(expectedDimension, model.Dimension);
        Assert.Equal(expectedUnitAmounts.Count, model.UnitAmounts.Count);
        for (int i = 0; i < expectedUnitAmounts.Count; i++)
        {
            Assert.Equal(expectedUnitAmounts[i], model.UnitAmounts[i]);
        }
    }
}

public class UnitAmount4Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitAmount4
        {
            DimensionValue = "dimension_value",
            DisplayName = "display_name",
            UnitAmount = "unit_amount",
        };

        string expectedDimensionValue = "dimension_value";
        string expectedDisplayName = "display_name";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedDimensionValue, model.DimensionValue);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class GroupedTieredPackageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedTieredPackage
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = GroupedTieredPackageBillingMode.InAdvance,
            Cadence = GroupedTieredPackageCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter21Field.PriceID,
                    Operator = CompositePriceFilter21Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            GroupedTieredPackageConfig = new()
            {
                GroupingKey = "x",
                PackageSize = "package_size",
                Tiers =
                [
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                ],
            },
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"grouped_tiered_package\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = GroupedTieredPackagePriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, GroupedTieredPackageBillingMode> expectedBillingMode =
            GroupedTieredPackageBillingMode.InAdvance;
        ApiEnum<string, GroupedTieredPackageCadence> expectedCadence =
            GroupedTieredPackageCadence.OneTime;
        List<CompositePriceFilter21> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter21Field.PriceID,
                Operator = CompositePriceFilter21Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        GroupedTieredPackageConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        GroupedTieredPackageGroupedTieredPackageConfig expectedGroupedTieredPackageConfig = new()
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        GroupedTieredPackageModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_tiered_package\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, GroupedTieredPackagePriceType> expectedPriceType =
            GroupedTieredPackagePriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedGroupedTieredPackageConfig, model.GroupedTieredPackageConfig);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter21Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter21
        {
            Field = CompositePriceFilter21Field.PriceID,
            Operator = CompositePriceFilter21Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter21Field> expectedField =
            CompositePriceFilter21Field.PriceID;
        ApiEnum<string, CompositePriceFilter21Operator> expectedOperator =
            CompositePriceFilter21Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class GroupedTieredPackageGroupedTieredPackageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedTieredPackageGroupedTieredPackageConfig
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string expectedGroupingKey = "x";
        string expectedPackageSize = "package_size";
        List<Tier23> expectedTiers =
        [
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
            new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedPackageSize, model.PackageSize);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class Tier23Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier23 { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" };

        string expectedPerUnit = "per_unit";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedPerUnit, model.PerUnit);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }
}

public class MaxGroupTieredPackageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaxGroupTieredPackage
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = MaxGroupTieredPackageBillingMode.InAdvance,
            Cadence = MaxGroupTieredPackageCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter22Field.PriceID,
                    Operator = CompositePriceFilter22Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            MaxGroupTieredPackageConfig = new()
            {
                GroupingKey = "x",
                PackageSize = "package_size",
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
            },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"max_group_tiered_package\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = MaxGroupTieredPackagePriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, MaxGroupTieredPackageBillingMode> expectedBillingMode =
            MaxGroupTieredPackageBillingMode.InAdvance;
        ApiEnum<string, MaxGroupTieredPackageCadence> expectedCadence =
            MaxGroupTieredPackageCadence.OneTime;
        List<CompositePriceFilter22> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter22Field.PriceID,
                Operator = CompositePriceFilter22Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        MaxGroupTieredPackageConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        MaxGroupTieredPackageMaxGroupTieredPackageConfig expectedMaxGroupTieredPackageConfig = new()
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        MaxGroupTieredPackageModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"max_group_tiered_package\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, MaxGroupTieredPackagePriceType> expectedPriceType =
            MaxGroupTieredPackagePriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaxGroupTieredPackageConfig, model.MaxGroupTieredPackageConfig);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter22Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter22
        {
            Field = CompositePriceFilter22Field.PriceID,
            Operator = CompositePriceFilter22Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter22Field> expectedField =
            CompositePriceFilter22Field.PriceID;
        ApiEnum<string, CompositePriceFilter22Operator> expectedOperator =
            CompositePriceFilter22Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class MaxGroupTieredPackageMaxGroupTieredPackageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaxGroupTieredPackageMaxGroupTieredPackageConfig
        {
            GroupingKey = "x",
            PackageSize = "package_size",
            Tiers =
            [
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            ],
        };

        string expectedGroupingKey = "x";
        string expectedPackageSize = "package_size";
        List<Tier24> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedPackageSize, model.PackageSize);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }
}

public class Tier24Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier24 { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class ScalableMatrixWithUnitPricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalableMatrixWithUnitPricing
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = ScalableMatrixWithUnitPricingBillingMode.InAdvance,
            Cadence = ScalableMatrixWithUnitPricingCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter23Field.PriceID,
                    Operator = CompositePriceFilter23Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>(
                "\"scalable_matrix_with_unit_pricing\""
            ),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = ScalableMatrixWithUnitPricingPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, ScalableMatrixWithUnitPricingBillingMode> expectedBillingMode =
            ScalableMatrixWithUnitPricingBillingMode.InAdvance;
        ApiEnum<string, ScalableMatrixWithUnitPricingCadence> expectedCadence =
            ScalableMatrixWithUnitPricingCadence.OneTime;
        List<CompositePriceFilter23> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter23Field.PriceID,
                Operator = CompositePriceFilter23Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        ScalableMatrixWithUnitPricingConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        ScalableMatrixWithUnitPricingModelType expectedModelType =
            JsonSerializer.Deserialize<JsonElement>("\"scalable_matrix_with_unit_pricing\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, ScalableMatrixWithUnitPricingPriceType> expectedPriceType =
            ScalableMatrixWithUnitPricingPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        ScalableMatrixWithUnitPricingScalableMatrixWithUnitPricingConfig expectedScalableMatrixWithUnitPricingConfig =
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
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(
            expectedScalableMatrixWithUnitPricingConfig,
            model.ScalableMatrixWithUnitPricingConfig
        );
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter23Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter23
        {
            Field = CompositePriceFilter23Field.PriceID,
            Operator = CompositePriceFilter23Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter23Field> expectedField =
            CompositePriceFilter23Field.PriceID;
        ApiEnum<string, CompositePriceFilter23Operator> expectedOperator =
            CompositePriceFilter23Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class ScalableMatrixWithUnitPricingScalableMatrixWithUnitPricingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalableMatrixWithUnitPricingScalableMatrixWithUnitPricingConfig
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
        List<MatrixScalingFactor3> expectedMatrixScalingFactors =
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

public class MatrixScalingFactor3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixScalingFactor3
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

public class ScalableMatrixWithTieredPricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalableMatrixWithTieredPricing
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = ScalableMatrixWithTieredPricingBillingMode.InAdvance,
            Cadence = ScalableMatrixWithTieredPricingCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter24Field.PriceID,
                    Operator = CompositePriceFilter24Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>(
                "\"scalable_matrix_with_tiered_pricing\""
            ),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = ScalableMatrixWithTieredPricingPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, ScalableMatrixWithTieredPricingBillingMode> expectedBillingMode =
            ScalableMatrixWithTieredPricingBillingMode.InAdvance;
        ApiEnum<string, ScalableMatrixWithTieredPricingCadence> expectedCadence =
            ScalableMatrixWithTieredPricingCadence.OneTime;
        List<CompositePriceFilter24> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter24Field.PriceID,
                Operator = CompositePriceFilter24Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        ScalableMatrixWithTieredPricingConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        ScalableMatrixWithTieredPricingModelType expectedModelType =
            JsonSerializer.Deserialize<JsonElement>("\"scalable_matrix_with_tiered_pricing\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, ScalableMatrixWithTieredPricingPriceType> expectedPriceType =
            ScalableMatrixWithTieredPricingPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        ScalableMatrixWithTieredPricingScalableMatrixWithTieredPricingConfig expectedScalableMatrixWithTieredPricingConfig =
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
                Tiers =
                [
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                ],
                SecondDimension = "second_dimension",
            };
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(
            expectedScalableMatrixWithTieredPricingConfig,
            model.ScalableMatrixWithTieredPricingConfig
        );
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter24Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter24
        {
            Field = CompositePriceFilter24Field.PriceID,
            Operator = CompositePriceFilter24Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter24Field> expectedField =
            CompositePriceFilter24Field.PriceID;
        ApiEnum<string, CompositePriceFilter24Operator> expectedOperator =
            CompositePriceFilter24Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class ScalableMatrixWithTieredPricingScalableMatrixWithTieredPricingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScalableMatrixWithTieredPricingScalableMatrixWithTieredPricingConfig
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
        List<MatrixScalingFactor4> expectedMatrixScalingFactors =
        [
            new()
            {
                FirstDimensionValue = "first_dimension_value",
                ScalingFactor = "scaling_factor",
                SecondDimensionValue = "second_dimension_value",
            },
        ];
        List<Tier25> expectedTiers =
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

public class MatrixScalingFactor4Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixScalingFactor4
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

public class Tier25Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier25 { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class CumulativeGroupedBulkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CumulativeGroupedBulk
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = CumulativeGroupedBulkBillingMode.InAdvance,
            Cadence = CumulativeGroupedBulkCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter25Field.PriceID,
                    Operator = CompositePriceFilter25Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            CumulativeGroupedBulkConfig = new()
            {
                DimensionValues =
                [
                    new()
                    {
                        GroupingKey = "x",
                        TierLowerBound = "tier_lower_bound",
                        UnitAmount = "unit_amount",
                    },
                ],
                Group = "group",
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_bulk\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = CumulativeGroupedBulkPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, CumulativeGroupedBulkBillingMode> expectedBillingMode =
            CumulativeGroupedBulkBillingMode.InAdvance;
        ApiEnum<string, CumulativeGroupedBulkCadence> expectedCadence =
            CumulativeGroupedBulkCadence.OneTime;
        List<CompositePriceFilter25> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter25Field.PriceID,
                Operator = CompositePriceFilter25Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        CumulativeGroupedBulkConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        CumulativeGroupedBulkCumulativeGroupedBulkConfig expectedCumulativeGroupedBulkConfig = new()
        {
            DimensionValues =
            [
                new()
                {
                    GroupingKey = "x",
                    TierLowerBound = "tier_lower_bound",
                    UnitAmount = "unit_amount",
                },
            ],
            Group = "group",
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        CumulativeGroupedBulkModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_bulk\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, CumulativeGroupedBulkPriceType> expectedPriceType =
            CumulativeGroupedBulkPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCumulativeGroupedBulkConfig, model.CumulativeGroupedBulkConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter25Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter25
        {
            Field = CompositePriceFilter25Field.PriceID,
            Operator = CompositePriceFilter25Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter25Field> expectedField =
            CompositePriceFilter25Field.PriceID;
        ApiEnum<string, CompositePriceFilter25Operator> expectedOperator =
            CompositePriceFilter25Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class CumulativeGroupedBulkCumulativeGroupedBulkConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CumulativeGroupedBulkCumulativeGroupedBulkConfig
        {
            DimensionValues =
            [
                new()
                {
                    GroupingKey = "x",
                    TierLowerBound = "tier_lower_bound",
                    UnitAmount = "unit_amount",
                },
            ],
            Group = "group",
        };

        List<DimensionValue1> expectedDimensionValues =
        [
            new()
            {
                GroupingKey = "x",
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            },
        ];
        string expectedGroup = "group";

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
        Assert.Equal(expectedGroup, model.Group);
    }
}

public class DimensionValue1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DimensionValue1
        {
            GroupingKey = "x",
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string expectedGroupingKey = "x";
        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}

public class CumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = CumulativeGroupedAllocationBillingMode.InAdvance,
            Cadence = CumulativeGroupedAllocationCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter26Field.PriceID,
                    Operator = CompositePriceFilter26Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>(
                "\"cumulative_grouped_allocation\""
            ),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = CumulativeGroupedAllocationPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, CumulativeGroupedAllocationBillingMode> expectedBillingMode =
            CumulativeGroupedAllocationBillingMode.InAdvance;
        ApiEnum<string, CumulativeGroupedAllocationCadence> expectedCadence =
            CumulativeGroupedAllocationCadence.OneTime;
        List<CompositePriceFilter26> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter26Field.PriceID,
                Operator = CompositePriceFilter26Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        CumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        CumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig = new()
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        CumulativeGroupedAllocationModelType expectedModelType =
            JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"");
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, CumulativeGroupedAllocationPriceType> expectedPriceType =
            CumulativeGroupedAllocationPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            model.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter26Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter26
        {
            Field = CompositePriceFilter26Field.PriceID,
            Operator = CompositePriceFilter26Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter26Field> expectedField =
            CompositePriceFilter26Field.PriceID;
        ApiEnum<string, CompositePriceFilter26Operator> expectedOperator =
            CompositePriceFilter26Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class CumulativeGroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CumulativeGroupedAllocationConfig
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

public class PriceMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceMinimum
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = PriceMinimumBillingMode.InAdvance,
            Cadence = PriceMinimumCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter27Field.PriceID,
                    Operator = CompositePriceFilter27Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"minimum\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = PriceMinimumPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, PriceMinimumBillingMode> expectedBillingMode =
            PriceMinimumBillingMode.InAdvance;
        ApiEnum<string, PriceMinimumCadence> expectedCadence = PriceMinimumCadence.OneTime;
        List<CompositePriceFilter27> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter27Field.PriceID,
                Operator = CompositePriceFilter27Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        PriceMinimumConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        PriceMinimumMinimumConfig expectedMinimumConfig = new()
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };
        PriceMinimumModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"minimum\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, PriceMinimumPriceType> expectedPriceType = PriceMinimumPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedMinimumConfig, model.MinimumConfig);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter27Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter27
        {
            Field = CompositePriceFilter27Field.PriceID,
            Operator = CompositePriceFilter27Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter27Field> expectedField =
            CompositePriceFilter27Field.PriceID;
        ApiEnum<string, CompositePriceFilter27Operator> expectedOperator =
            CompositePriceFilter27Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class PriceMinimumMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string expectedMinimumAmount = "minimum_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedProrated, model.Prorated);
    }
}

public class PercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Percent
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = PercentBillingMode.InAdvance,
            Cadence = PercentCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter28Field.PriceID,
                    Operator = CompositePriceFilter28Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\""),
            Name = "name",
            PercentConfig = new(0),
            PlanPhaseOrder = 0,
            PriceType = PercentPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, PercentBillingMode> expectedBillingMode = PercentBillingMode.InAdvance;
        ApiEnum<string, PercentCadence> expectedCadence = PercentCadence.OneTime;
        List<CompositePriceFilter28> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter28Field.PriceID,
                Operator = CompositePriceFilter28Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        PercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        PercentModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "name";
        PercentConfig expectedPercentConfig = new(0);
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, PercentPriceType> expectedPriceType = PercentPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentConfig, model.PercentConfig);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter28Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter28
        {
            Field = CompositePriceFilter28Field.PriceID,
            Operator = CompositePriceFilter28Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter28Field> expectedField =
            CompositePriceFilter28Field.PriceID;
        ApiEnum<string, CompositePriceFilter28Operator> expectedOperator =
            CompositePriceFilter28Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class PercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }
}

public class EventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventOutput
        {
            ID = "id",
            BillableMetric = new("id"),
            BillingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            BillingMode = EventOutputBillingMode.InAdvance,
            Cadence = EventOutputCadence.OneTime,
            CompositePriceFilters =
            [
                new()
                {
                    Field = CompositePriceFilter29Field.PriceID,
                    Operator = CompositePriceFilter29Operator.Includes,
                    Values = ["string"],
                },
            ],
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                Filters =
                [
                    new()
                    {
                        Field = Field.PriceID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
            },
            Currency = "currency",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscount1 = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = Filter17Field.PriceID,
                        Operator = Filter17Operator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
            Item = new() { ID = "id", Name = "name" },
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter2Field.PriceID,
                        Operator = Filter2Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
            },
            MaximumAmount = "maximum_amount",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter4Field.PriceID,
                        Operator = Filter4Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
            },
            MinimumAmount = "minimum_amount",
            ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\""),
            Name = "name",
            PlanPhaseOrder = 0,
            PriceType = EventOutputPriceType.UsagePrice,
            ReplacesPriceID = "replaces_price_id",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
            },
        };

        string expectedID = "id";
        BillableMetricTiny expectedBillableMetric = new("id");
        BillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ApiEnum<string, EventOutputBillingMode> expectedBillingMode =
            EventOutputBillingMode.InAdvance;
        ApiEnum<string, EventOutputCadence> expectedCadence = EventOutputCadence.OneTime;
        List<CompositePriceFilter29> expectedCompositePriceFilters =
        [
            new()
            {
                Field = CompositePriceFilter29Field.PriceID,
                Operator = CompositePriceFilter29Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedConversionRate = 0;
        EventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Allocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };
        string expectedCurrency = "currency";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscount1 = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = Filter17Field.PriceID,
                    Operator = Filter17Operator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        EventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        BillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = DurationUnit.Day,
        };
        ItemSlim expectedItem = new() { ID = "id", Name = "name" };
        Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter2Field.PriceID,
                    Operator = Filter2Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter4Field.PriceID,
                    Operator = Filter4Operator.Includes,
                    Values = ["string"],
                },
            ],
            MinimumAmount = "minimum_amount",
        };
        string expectedMinimumAmount = "minimum_amount";
        EventOutputModelType expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"event_output\""
        );
        string expectedName = "name";
        long expectedPlanPhaseOrder = 0;
        ApiEnum<string, EventOutputPriceType> expectedPriceType = EventOutputPriceType.UsagePrice;
        string expectedReplacesPriceID = "replaces_price_id";
        DimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCompositePriceFilters.Count, model.CompositePriceFilters.Count);
        for (int i = 0; i < expectedCompositePriceFilters.Count; i++)
        {
            Assert.Equal(expectedCompositePriceFilters[i], model.CompositePriceFilters[i]);
        }
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedEventOutputConfig, model.EventOutputConfig);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPriceType, model.PriceType);
        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
    }
}

public class CompositePriceFilter29Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompositePriceFilter29
        {
            Field = CompositePriceFilter29Field.PriceID,
            Operator = CompositePriceFilter29Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CompositePriceFilter29Field> expectedField =
            CompositePriceFilter29Field.PriceID;
        ApiEnum<string, CompositePriceFilter29Operator> expectedOperator =
            CompositePriceFilter29Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class EventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventOutputConfig
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
