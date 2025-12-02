using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.Beta;
using Models = Orb.Models;

namespace Orb.Tests.Models.Beta;

public class PlanVersionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanVersion
        {
            Adjustments =
            [
                new Models::PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter23Field.PriceID,
                            Operator = Models::Filter23Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    PlanPhaseOrder = 0,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhases =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Duration = 0,
                    DurationUnit = DurationUnit.Daily,
                    Name = "name",
                    Order = 0,
                },
            ],
            Prices =
            [
                new Models::Unit()
                {
                    ID = "id",
                    BillableMetric = new("id"),
                    BillingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    BillingMode = Models::BillingMode.InAdvance,
                    Cadence = Models::UnitCadence.OneTime,
                    CompositePriceFilters =
                    [
                        new()
                        {
                            Field = Models::CompositePriceFilterField.PriceID,
                            Operator = Models::CompositePriceFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    ConversionRate = 0,
                    ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                    {
                        ConversionRateType =
                            Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                        },
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Field.PriceID,
                                Operator = Models::Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter17Field.PriceID,
                                Operator = Models::Filter17Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    ExternalPriceID = "external_price_id",
                    FixedPriceQuantity = 0,
                    InvoicingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter2Field.PriceID,
                                Operator = Models::Filter2Operator.Includes,
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
                                Field = Models::Filter4Field.PriceID,
                                Operator = Models::Filter4Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                    },
                    MinimumAmount = "minimum_amount",
                    Name = "name",
                    PlanPhaseOrder = 0,
                    PriceType = Models::UnitPriceType.UsagePrice,
                    ReplacesPriceID = "replaces_price_id",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                    DimensionalPriceConfiguration = new()
                    {
                        DimensionValues = ["string"],
                        DimensionalPriceGroupID = "dimensional_price_group_id",
                    },
                },
            ],
            Version = 0,
        };

        List<Adjustment> expectedAdjustments =
        [
            new Models::PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::Filter23Field.PriceID,
                        Operator = Models::Filter23Operator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PlanVersionPhase> expectedPlanPhases =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Duration = 0,
                DurationUnit = DurationUnit.Daily,
                Name = "name",
                Order = 0,
            },
        ];
        List<Models::Price> expectedPrices =
        [
            new Models::Unit()
            {
                ID = "id",
                BillableMetric = new("id"),
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::DurationUnit.Day,
                },
                BillingMode = Models::BillingMode.InAdvance,
                Cadence = Models::UnitCadence.OneTime,
                CompositePriceFilters =
                [
                    new()
                    {
                        Field = Models::CompositePriceFilterField.PriceID,
                        Operator = Models::CompositePriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                        DurationUnit = Models::CustomExpirationDurationUnit.Day,
                    },
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Field.PriceID,
                            Operator = Models::Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                },
                Currency = "currency",
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscount1 = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter17Field.PriceID,
                            Operator = Models::Filter17Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    Reason = "reason",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::DurationUnit.Day,
                },
                Item = new() { ID = "id", Name = "name" },
                Maximum = new()
                {
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter2Field.PriceID,
                            Operator = Models::Filter2Operator.Includes,
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
                            Field = Models::Filter4Field.PriceID,
                            Operator = Models::Filter4Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MinimumAmount = "minimum_amount",
                },
                MinimumAmount = "minimum_amount",
                Name = "name",
                PlanPhaseOrder = 0,
                PriceType = Models::UnitPriceType.UsagePrice,
                ReplacesPriceID = "replaces_price_id",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                },
            },
        ];
        long expectedVersion = 0;

        Assert.Equal(expectedAdjustments.Count, model.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], model.Adjustments[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPlanPhases.Count, model.PlanPhases.Count);
        for (int i = 0; i < expectedPlanPhases.Count; i++)
        {
            Assert.Equal(expectedPlanPhases[i], model.PlanPhases[i]);
        }
        Assert.Equal(expectedPrices.Count, model.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], model.Prices[i]);
        }
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanVersion
        {
            Adjustments =
            [
                new Models::PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter23Field.PriceID,
                            Operator = Models::Filter23Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    PlanPhaseOrder = 0,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhases =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Duration = 0,
                    DurationUnit = DurationUnit.Daily,
                    Name = "name",
                    Order = 0,
                },
            ],
            Prices =
            [
                new Models::Unit()
                {
                    ID = "id",
                    BillableMetric = new("id"),
                    BillingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    BillingMode = Models::BillingMode.InAdvance,
                    Cadence = Models::UnitCadence.OneTime,
                    CompositePriceFilters =
                    [
                        new()
                        {
                            Field = Models::CompositePriceFilterField.PriceID,
                            Operator = Models::CompositePriceFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    ConversionRate = 0,
                    ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                    {
                        ConversionRateType =
                            Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                        },
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Field.PriceID,
                                Operator = Models::Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter17Field.PriceID,
                                Operator = Models::Filter17Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    ExternalPriceID = "external_price_id",
                    FixedPriceQuantity = 0,
                    InvoicingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter2Field.PriceID,
                                Operator = Models::Filter2Operator.Includes,
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
                                Field = Models::Filter4Field.PriceID,
                                Operator = Models::Filter4Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                    },
                    MinimumAmount = "minimum_amount",
                    Name = "name",
                    PlanPhaseOrder = 0,
                    PriceType = Models::UnitPriceType.UsagePrice,
                    ReplacesPriceID = "replaces_price_id",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                    DimensionalPriceConfiguration = new()
                    {
                        DimensionValues = ["string"],
                        DimensionalPriceGroupID = "dimensional_price_group_id",
                    },
                },
            ],
            Version = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanVersion>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanVersion
        {
            Adjustments =
            [
                new Models::PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter23Field.PriceID,
                            Operator = Models::Filter23Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    PlanPhaseOrder = 0,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhases =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Duration = 0,
                    DurationUnit = DurationUnit.Daily,
                    Name = "name",
                    Order = 0,
                },
            ],
            Prices =
            [
                new Models::Unit()
                {
                    ID = "id",
                    BillableMetric = new("id"),
                    BillingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    BillingMode = Models::BillingMode.InAdvance,
                    Cadence = Models::UnitCadence.OneTime,
                    CompositePriceFilters =
                    [
                        new()
                        {
                            Field = Models::CompositePriceFilterField.PriceID,
                            Operator = Models::CompositePriceFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    ConversionRate = 0,
                    ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                    {
                        ConversionRateType =
                            Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                        },
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Field.PriceID,
                                Operator = Models::Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter17Field.PriceID,
                                Operator = Models::Filter17Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    ExternalPriceID = "external_price_id",
                    FixedPriceQuantity = 0,
                    InvoicingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter2Field.PriceID,
                                Operator = Models::Filter2Operator.Includes,
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
                                Field = Models::Filter4Field.PriceID,
                                Operator = Models::Filter4Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                    },
                    MinimumAmount = "minimum_amount",
                    Name = "name",
                    PlanPhaseOrder = 0,
                    PriceType = Models::UnitPriceType.UsagePrice,
                    ReplacesPriceID = "replaces_price_id",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                    DimensionalPriceConfiguration = new()
                    {
                        DimensionValues = ["string"],
                        DimensionalPriceGroupID = "dimensional_price_group_id",
                    },
                },
            ],
            Version = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanVersion>(json);
        Assert.NotNull(deserialized);

        List<Adjustment> expectedAdjustments =
        [
            new Models::PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::Filter23Field.PriceID,
                        Operator = Models::Filter23Operator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PlanVersionPhase> expectedPlanPhases =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Duration = 0,
                DurationUnit = DurationUnit.Daily,
                Name = "name",
                Order = 0,
            },
        ];
        List<Models::Price> expectedPrices =
        [
            new Models::Unit()
            {
                ID = "id",
                BillableMetric = new("id"),
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::DurationUnit.Day,
                },
                BillingMode = Models::BillingMode.InAdvance,
                Cadence = Models::UnitCadence.OneTime,
                CompositePriceFilters =
                [
                    new()
                    {
                        Field = Models::CompositePriceFilterField.PriceID,
                        Operator = Models::CompositePriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                        DurationUnit = Models::CustomExpirationDurationUnit.Day,
                    },
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Field.PriceID,
                            Operator = Models::Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                },
                Currency = "currency",
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscount1 = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter17Field.PriceID,
                            Operator = Models::Filter17Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    Reason = "reason",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::DurationUnit.Day,
                },
                Item = new() { ID = "id", Name = "name" },
                Maximum = new()
                {
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter2Field.PriceID,
                            Operator = Models::Filter2Operator.Includes,
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
                            Field = Models::Filter4Field.PriceID,
                            Operator = Models::Filter4Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MinimumAmount = "minimum_amount",
                },
                MinimumAmount = "minimum_amount",
                Name = "name",
                PlanPhaseOrder = 0,
                PriceType = Models::UnitPriceType.UsagePrice,
                ReplacesPriceID = "replaces_price_id",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                },
            },
        ];
        long expectedVersion = 0;

        Assert.Equal(expectedAdjustments.Count, deserialized.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], deserialized.Adjustments[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPlanPhases.Count, deserialized.PlanPhases.Count);
        for (int i = 0; i < expectedPlanPhases.Count; i++)
        {
            Assert.Equal(expectedPlanPhases[i], deserialized.PlanPhases[i]);
        }
        Assert.Equal(expectedPrices.Count, deserialized.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], deserialized.Prices[i]);
        }
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanVersion
        {
            Adjustments =
            [
                new Models::PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter23Field.PriceID,
                            Operator = Models::Filter23Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    PlanPhaseOrder = 0,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhases =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Duration = 0,
                    DurationUnit = DurationUnit.Daily,
                    Name = "name",
                    Order = 0,
                },
            ],
            Prices =
            [
                new Models::Unit()
                {
                    ID = "id",
                    BillableMetric = new("id"),
                    BillingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    BillingMode = Models::BillingMode.InAdvance,
                    Cadence = Models::UnitCadence.OneTime,
                    CompositePriceFilters =
                    [
                        new()
                        {
                            Field = Models::CompositePriceFilterField.PriceID,
                            Operator = Models::CompositePriceFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    ConversionRate = 0,
                    ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                    {
                        ConversionRateType =
                            Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                        },
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Field.PriceID,
                                Operator = Models::Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter17Field.PriceID,
                                Operator = Models::Filter17Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    ExternalPriceID = "external_price_id",
                    FixedPriceQuantity = 0,
                    InvoicingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter2Field.PriceID,
                                Operator = Models::Filter2Operator.Includes,
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
                                Field = Models::Filter4Field.PriceID,
                                Operator = Models::Filter4Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                    },
                    MinimumAmount = "minimum_amount",
                    Name = "name",
                    PlanPhaseOrder = 0,
                    PriceType = Models::UnitPriceType.UsagePrice,
                    ReplacesPriceID = "replaces_price_id",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                    DimensionalPriceConfiguration = new()
                    {
                        DimensionValues = ["string"],
                        DimensionalPriceGroupID = "dimensional_price_group_id",
                    },
                },
            ],
            Version = 0,
        };

        model.Validate();
    }
}
