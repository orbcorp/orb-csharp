using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                                Field = Models::AllocationFilterField.PriceID,
                                Operator = Models::AllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIds = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                    LicenseType = new()
                    {
                        ID = "id",
                        GroupingKey = "grouping_key",
                        Name = "name",
                    },
                },
            ],
            Version = 0,
        };

        List<PlanVersionAdjustment> expectedAdjustments =
        [
            new Models::PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                            Field = Models::AllocationFilterField.PriceID,
                            Operator = Models::AllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
                Currency = "currency",
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PercentageDiscountFilterField.PriceID,
                            Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                    DurationUnit = Models::DurationUnit.Day,
                },
                Item = new() { ID = "id", Name = "name" },
                Maximum = new()
                {
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::MaximumFilterField.PriceID,
                            Operator = Models::MaximumFilterOperator.Includes,
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
                            Field = Models::MinimumFilterField.PriceID,
                            Operator = Models::MinimumFilterOperator.Includes,
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
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
        Assert.NotNull(model.PlanPhases);
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                                Field = Models::AllocationFilterField.PriceID,
                                Operator = Models::AllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIds = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                    LicenseType = new()
                    {
                        ID = "id",
                        GroupingKey = "grouping_key",
                        Name = "name",
                    },
                },
            ],
            Version = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersion>(
            json,
            ModelBase.SerializerOptions
        );

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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                                Field = Models::AllocationFilterField.PriceID,
                                Operator = Models::AllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIds = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                    LicenseType = new()
                    {
                        ID = "id",
                        GroupingKey = "grouping_key",
                        Name = "name",
                    },
                },
            ],
            Version = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PlanVersionAdjustment> expectedAdjustments =
        [
            new Models::PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                            Field = Models::AllocationFilterField.PriceID,
                            Operator = Models::AllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
                Currency = "currency",
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PercentageDiscountFilterField.PriceID,
                            Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                    DurationUnit = Models::DurationUnit.Day,
                },
                Item = new() { ID = "id", Name = "name" },
                Maximum = new()
                {
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::MaximumFilterField.PriceID,
                            Operator = Models::MaximumFilterOperator.Includes,
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
                            Field = Models::MinimumFilterField.PriceID,
                            Operator = Models::MinimumFilterOperator.Includes,
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
                LicenseType = new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
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
        Assert.NotNull(deserialized.PlanPhases);
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                                Field = Models::AllocationFilterField.PriceID,
                                Operator = Models::AllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIds = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                    LicenseType = new()
                    {
                        ID = "id",
                        GroupingKey = "grouping_key",
                        Name = "name",
                    },
                },
            ],
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                                Field = Models::AllocationFilterField.PriceID,
                                Operator = Models::AllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                    Currency = "currency",
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                        DurationUnit = Models::DurationUnit.Day,
                    },
                    Item = new() { ID = "id", Name = "name" },
                    Maximum = new()
                    {
                        AppliesToPriceIds = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                    LicenseType = new()
                    {
                        ID = "id",
                        GroupingKey = "grouping_key",
                        Name = "name",
                    },
                },
            ],
            Version = 0,
        };

        PlanVersion copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanVersionAdjustmentTest : TestBase
{
    [Fact]
    public void PlanPhaseUsageDiscountValidationWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseAmountDiscountValidationWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseAmountDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhasePercentageDiscountValidationWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhasePercentageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType =
                Models::PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void TieredPercentageDiscountValidationWorks()
    {
        PlanVersionAdjustment value = new PlanVersionAdjustmentTieredPercentageDiscount()
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                    Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseMinimumValidationWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseMinimumAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseMaximumValidationWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseMaximumAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseUsageDiscountSerializationRoundtripWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersionAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhaseAmountDiscountSerializationRoundtripWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseAmountDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersionAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhasePercentageDiscountSerializationRoundtripWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhasePercentageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType =
                Models::PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersionAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredPercentageDiscountSerializationRoundtripWorks()
    {
        PlanVersionAdjustment value = new PlanVersionAdjustmentTieredPercentageDiscount()
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                    Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersionAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhaseMinimumSerializationRoundtripWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseMinimumAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersionAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhaseMaximumSerializationRoundtripWorks()
    {
        PlanVersionAdjustment value = new Models::PlanPhaseMaximumAdjustment()
        {
            ID = "id",
            AdjustmentType = Models::PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Models::PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = Models::PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanVersionAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PlanVersionAdjustmentTieredPercentageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                    Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        string expectedID = "id";
        JsonElement expectedAdjustmentType = JsonSerializer.SerializeToElement(
            "tiered_percentage_discount"
        );
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanVersionAdjustmentTieredPercentageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        List<PlanVersionAdjustmentTieredPercentageDiscountTier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedAdjustmentType, model.AdjustmentType));
        Assert.Equal(expectedAppliesToPriceIds.Count, model.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], model.AppliesToPriceIds[i]);
        }
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, model.IsInvoiceLevel);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                    Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanVersionAdjustmentTieredPercentageDiscount>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                    Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanVersionAdjustmentTieredPercentageDiscount>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedAdjustmentType = JsonSerializer.SerializeToElement(
            "tiered_percentage_discount"
        );
        List<string> expectedAppliesToPriceIds = ["string"];
        List<PlanVersionAdjustmentTieredPercentageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        List<PlanVersionAdjustmentTieredPercentageDiscountTier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedAdjustmentType, deserialized.AdjustmentType));
        Assert.Equal(expectedAppliesToPriceIds.Count, deserialized.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], deserialized.AppliesToPriceIds[i]);
        }
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, deserialized.IsInvoiceLevel);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                    Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
                    Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        PlanVersionAdjustmentTieredPercentageDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanVersionAdjustmentTieredPercentageDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountFilter
        {
            Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
            Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField> expectedField =
            PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID;
        ApiEnum<
            string,
            PlanVersionAdjustmentTieredPercentageDiscountFilterOperator
        > expectedOperator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountFilter
        {
            Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
            Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanVersionAdjustmentTieredPercentageDiscountFilter>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountFilter
        {
            Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
            Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanVersionAdjustmentTieredPercentageDiscountFilter>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField> expectedField =
            PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID;
        ApiEnum<
            string,
            PlanVersionAdjustmentTieredPercentageDiscountFilterOperator
        > expectedOperator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountFilter
        {
            Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
            Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountFilter
        {
            Field = PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
            Operator = PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        PlanVersionAdjustmentTieredPercentageDiscountFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanVersionAdjustmentTieredPercentageDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.ItemID)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceType)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.Currency)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.PricingUnitID)]
    public void Validation_Works(PlanVersionAdjustmentTieredPercentageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.ItemID)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceType)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.Currency)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(
        PlanVersionAdjustmentTieredPercentageDiscountFilterField rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanVersionAdjustmentTieredPercentageDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Excludes)]
    public void Validation_Works(
        PlanVersionAdjustmentTieredPercentageDiscountFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterOperator> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes)]
    [InlineData(PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        PlanVersionAdjustmentTieredPercentageDiscountFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterOperator> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanVersionAdjustmentTieredPercentageDiscountTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        double expectedLowerBound = 0;
        double expectedPercentage = 0;
        double expectedUpperBound = 0;

        Assert.Equal(expectedLowerBound, model.LowerBound);
        Assert.Equal(expectedPercentage, model.Percentage);
        Assert.Equal(expectedUpperBound, model.UpperBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanVersionAdjustmentTieredPercentageDiscountTier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanVersionAdjustmentTieredPercentageDiscountTier>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedLowerBound = 0;
        double expectedPercentage = 0;
        double expectedUpperBound = 0;

        Assert.Equal(expectedLowerBound, deserialized.LowerBound);
        Assert.Equal(expectedPercentage, deserialized.Percentage);
        Assert.Equal(expectedUpperBound, deserialized.UpperBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,
        };

        Assert.Null(model.UpperBound);
        Assert.False(model.RawData.ContainsKey("upper_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,

            UpperBound = null,
        };

        Assert.Null(model.UpperBound);
        Assert.True(model.RawData.ContainsKey("upper_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,

            UpperBound = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanVersionAdjustmentTieredPercentageDiscountTier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        PlanVersionAdjustmentTieredPercentageDiscountTier copied = new(model);

        Assert.Equal(model, copied);
    }
}
