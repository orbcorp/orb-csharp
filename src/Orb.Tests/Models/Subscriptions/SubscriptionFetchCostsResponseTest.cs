using System;
using System.Collections.Generic;
using Orb.Models;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionFetchCostsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionFetchCostsResponse
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
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
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
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
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
}
