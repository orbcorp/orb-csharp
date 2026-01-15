using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Customers.Costs;

namespace Orb.Tests.Models.Customers.Costs;

public class CostListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CostListResponse
        {
            Data =
            [
                new()
                {
                    PerPriceCosts =
                    [
                        new()
                        {
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
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
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = PercentageDiscountFilterField.PriceID,
                                            Operator = PercentageDiscountFilterOperator.Includes,
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
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MaximumFilterField.PriceID,
                                            Operator = MaximumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MinimumFilterField.PriceID,
                                            Operator = MinimumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
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
                            },
                            PriceID = "price_id",
                            Subtotal = "subtotal",
                            Total = "total",
                            Quantity = 0,
                        },
                    ],
                    Subtotal = "subtotal",
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "total",
                },
            ],
        };

        List<AggregatedCost> expectedData =
        [
            new()
            {
                PerPriceCosts =
                [
                    new()
                    {
                        Price = new Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
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
                                ConversionRateType =
                                    SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = PercentageDiscountFilterField.PriceID,
                                        Operator = PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIds = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = MaximumFilterField.PriceID,
                                        Operator = MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIds = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = MinimumFilterField.PriceID,
                                        Operator = MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
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
                        },
                        PriceID = "price_id",
                        Subtotal = "subtotal",
                        Total = "total",
                        Quantity = 0,
                    },
                ],
                Subtotal = "subtotal",
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Total = "total",
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CostListResponse
        {
            Data =
            [
                new()
                {
                    PerPriceCosts =
                    [
                        new()
                        {
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
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
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = PercentageDiscountFilterField.PriceID,
                                            Operator = PercentageDiscountFilterOperator.Includes,
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
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MaximumFilterField.PriceID,
                                            Operator = MaximumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MinimumFilterField.PriceID,
                                            Operator = MinimumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
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
                            },
                            PriceID = "price_id",
                            Subtotal = "subtotal",
                            Total = "total",
                            Quantity = 0,
                        },
                    ],
                    Subtotal = "subtotal",
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "total",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CostListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CostListResponse
        {
            Data =
            [
                new()
                {
                    PerPriceCosts =
                    [
                        new()
                        {
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
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
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = PercentageDiscountFilterField.PriceID,
                                            Operator = PercentageDiscountFilterOperator.Includes,
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
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MaximumFilterField.PriceID,
                                            Operator = MaximumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MinimumFilterField.PriceID,
                                            Operator = MinimumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
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
                            },
                            PriceID = "price_id",
                            Subtotal = "subtotal",
                            Total = "total",
                            Quantity = 0,
                        },
                    ],
                    Subtotal = "subtotal",
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "total",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CostListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AggregatedCost> expectedData =
        [
            new()
            {
                PerPriceCosts =
                [
                    new()
                    {
                        Price = new Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
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
                                ConversionRateType =
                                    SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = PercentageDiscountFilterField.PriceID,
                                        Operator = PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIds = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = MaximumFilterField.PriceID,
                                        Operator = MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIds = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = MinimumFilterField.PriceID,
                                        Operator = MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
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
                        },
                        PriceID = "price_id",
                        Subtotal = "subtotal",
                        Total = "total",
                        Quantity = 0,
                    },
                ],
                Subtotal = "subtotal",
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Total = "total",
            },
        ];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CostListResponse
        {
            Data =
            [
                new()
                {
                    PerPriceCosts =
                    [
                        new()
                        {
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
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
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = PercentageDiscountFilterField.PriceID,
                                            Operator = PercentageDiscountFilterOperator.Includes,
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
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MaximumFilterField.PriceID,
                                            Operator = MaximumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = MinimumFilterField.PriceID,
                                            Operator = MinimumFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
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
                            },
                            PriceID = "price_id",
                            Subtotal = "subtotal",
                            Total = "total",
                            Quantity = 0,
                        },
                    ],
                    Subtotal = "subtotal",
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "total",
                },
            ],
        };

        model.Validate();
    }
}
