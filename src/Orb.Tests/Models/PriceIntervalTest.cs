using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class PriceIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceInterval
        {
            ID = "id",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "filter",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PriceID = "price_id",
                    Quantity = 0,
                },
            ],
            Price = new Unit()
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        string expectedID = "id";
        long expectedBillingCycleDay = 0;
        bool expectedCanDeferBilling = true;
        DateTimeOffset expectedCurrentBillingPeriodEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilter = "filter";
        List<FixedFeeQuantityTransition> expectedFixedFeeQuantityTransitions =
        [
            new()
            {
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PriceID = "price_id",
                Quantity = 0,
            },
        ];
        Price expectedPrice = new Unit()
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
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
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
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedUsageCustomerIds = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingCycleDay, model.BillingCycleDay);
        Assert.Equal(expectedCanDeferBilling, model.CanDeferBilling);
        Assert.Equal(expectedCurrentBillingPeriodEndDate, model.CurrentBillingPeriodEndDate);
        Assert.Equal(expectedCurrentBillingPeriodStartDate, model.CurrentBillingPeriodStartDate);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.NotNull(model.FixedFeeQuantityTransitions);
        Assert.Equal(
            expectedFixedFeeQuantityTransitions.Count,
            model.FixedFeeQuantityTransitions.Count
        );
        for (int i = 0; i < expectedFixedFeeQuantityTransitions.Count; i++)
        {
            Assert.Equal(
                expectedFixedFeeQuantityTransitions[i],
                model.FixedFeeQuantityTransitions[i]
            );
        }
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.NotNull(model.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, model.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], model.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceInterval
        {
            ID = "id",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "filter",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PriceID = "price_id",
                    Quantity = 0,
                },
            ],
            Price = new Unit()
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceInterval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceInterval
        {
            ID = "id",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "filter",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PriceID = "price_id",
                    Quantity = 0,
                },
            ],
            Price = new Unit()
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceInterval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedBillingCycleDay = 0;
        bool expectedCanDeferBilling = true;
        DateTimeOffset expectedCurrentBillingPeriodEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilter = "filter";
        List<FixedFeeQuantityTransition> expectedFixedFeeQuantityTransitions =
        [
            new()
            {
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PriceID = "price_id",
                Quantity = 0,
            },
        ];
        Price expectedPrice = new Unit()
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
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
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
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedUsageCustomerIds = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingCycleDay, deserialized.BillingCycleDay);
        Assert.Equal(expectedCanDeferBilling, deserialized.CanDeferBilling);
        Assert.Equal(expectedCurrentBillingPeriodEndDate, deserialized.CurrentBillingPeriodEndDate);
        Assert.Equal(
            expectedCurrentBillingPeriodStartDate,
            deserialized.CurrentBillingPeriodStartDate
        );
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.NotNull(deserialized.FixedFeeQuantityTransitions);
        Assert.Equal(
            expectedFixedFeeQuantityTransitions.Count,
            deserialized.FixedFeeQuantityTransitions.Count
        );
        for (int i = 0; i < expectedFixedFeeQuantityTransitions.Count; i++)
        {
            Assert.Equal(
                expectedFixedFeeQuantityTransitions[i],
                deserialized.FixedFeeQuantityTransitions[i]
            );
        }
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.NotNull(deserialized.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, deserialized.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], deserialized.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceInterval
        {
            ID = "id",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "filter",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PriceID = "price_id",
                    Quantity = 0,
                },
            ],
            Price = new Unit()
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PriceInterval
        {
            ID = "id",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "filter",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PriceID = "price_id",
                    Quantity = 0,
                },
            ],
            Price = new Unit()
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        PriceInterval copied = new(model);

        Assert.Equal(model, copied);
    }
}
