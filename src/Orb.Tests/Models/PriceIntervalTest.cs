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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
            MetricParameterOverrides = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
                LicenseTypeID = "license_type_id",
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
            InvoiceGroupingKey = "invoice_grouping_key",
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
            LicenseType = new()
            {
                ID = "id",
                GroupingKey = "grouping_key",
                Name = "name",
            },
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedUsageCustomerIds = ["string"];
        Dictionary<string, JsonElement> expectedMetricParameterOverrides = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

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
        Assert.NotNull(model.MetricParameterOverrides);
        Assert.Equal(expectedMetricParameterOverrides.Count, model.MetricParameterOverrides.Count);
        foreach (var item in expectedMetricParameterOverrides)
        {
            Assert.True(model.MetricParameterOverrides.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.MetricParameterOverrides[item.Key]));
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
            MetricParameterOverrides = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
            MetricParameterOverrides = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
                LicenseTypeID = "license_type_id",
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
            InvoiceGroupingKey = "invoice_grouping_key",
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
            LicenseType = new()
            {
                ID = "id",
                GroupingKey = "grouping_key",
                Name = "name",
            },
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedUsageCustomerIds = ["string"];
        Dictionary<string, JsonElement> expectedMetricParameterOverrides = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

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
        Assert.NotNull(deserialized.MetricParameterOverrides);
        Assert.Equal(
            expectedMetricParameterOverrides.Count,
            deserialized.MetricParameterOverrides.Count
        );
        foreach (var item in expectedMetricParameterOverrides)
        {
            Assert.True(deserialized.MetricParameterOverrides.TryGetValue(item.Key, out var value));

            Assert.True(
                JsonElement.DeepEquals(value, deserialized.MetricParameterOverrides[item.Key])
            );
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
            MetricParameterOverrides = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        Assert.Null(model.MetricParameterOverrides);
        Assert.False(model.RawData.ContainsKey("metric_parameter_overrides"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],

            MetricParameterOverrides = null,
        };

        Assert.Null(model.MetricParameterOverrides);
        Assert.True(model.RawData.ContainsKey("metric_parameter_overrides"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],

            MetricParameterOverrides = null,
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
                    LicenseTypeID = "license_type_id",
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
                InvoiceGroupingKey = "invoice_grouping_key",
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
            MetricParameterOverrides = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        PriceInterval copied = new(model);

        Assert.Equal(model, copied);
    }
}
