using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.Plans;
using Models = Orb.Models;

namespace Orb.Tests.Models.Plans;

public class PlanListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
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
                    BasePlan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    BasePlanID = "base_plan_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DefaultInvoiceMemo = "default_invoice_memo",
                    Description = "description",
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
                    ExternalPlanID = "external_plan_id",
                    InvoicingCurrency = "invoicing_currency",
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
                    NetTerms = 0,
                    PlanPhases =
                    [
                        new()
                        {
                            ID = "id",
                            Description = "description",
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
                            Duration = 0,
                            DurationUnit = PlanPhaseModelDurationUnit.Daily,
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
                    Product = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                    },
                    Status = PlanStatus.Active,
                    TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days },
                    Version = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Plan> expectedData =
        [
            new()
            {
                ID = "id",
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
                BasePlan = new()
                {
                    ID = "m2t5akQeh2obwxeU",
                    ExternalPlanID = "m2t5akQeh2obwxeU",
                    Name = "Example plan",
                },
                BasePlanID = "base_plan_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DefaultInvoiceMemo = "default_invoice_memo",
                Description = "description",
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
                ExternalPlanID = "external_plan_id",
                InvoicingCurrency = "invoicing_currency",
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
                NetTerms = 0,
                PlanPhases =
                [
                    new()
                    {
                        ID = "id",
                        Description = "description",
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
                        Duration = 0,
                        DurationUnit = PlanPhaseModelDurationUnit.Daily,
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
                Product = new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                },
                Status = PlanStatus.Active,
                TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days },
                Version = 0,
            },
        ];
        Models::PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
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
                    BasePlan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    BasePlanID = "base_plan_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DefaultInvoiceMemo = "default_invoice_memo",
                    Description = "description",
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
                    ExternalPlanID = "external_plan_id",
                    InvoicingCurrency = "invoicing_currency",
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
                    NetTerms = 0,
                    PlanPhases =
                    [
                        new()
                        {
                            ID = "id",
                            Description = "description",
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
                            Duration = 0,
                            DurationUnit = PlanPhaseModelDurationUnit.Daily,
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
                    Product = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                    },
                    Status = PlanStatus.Active,
                    TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days },
                    Version = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
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
                    BasePlan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    BasePlanID = "base_plan_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DefaultInvoiceMemo = "default_invoice_memo",
                    Description = "description",
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
                    ExternalPlanID = "external_plan_id",
                    InvoicingCurrency = "invoicing_currency",
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
                    NetTerms = 0,
                    PlanPhases =
                    [
                        new()
                        {
                            ID = "id",
                            Description = "description",
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
                            Duration = 0,
                            DurationUnit = PlanPhaseModelDurationUnit.Daily,
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
                    Product = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                    },
                    Status = PlanStatus.Active,
                    TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days },
                    Version = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<Plan> expectedData =
        [
            new()
            {
                ID = "id",
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
                BasePlan = new()
                {
                    ID = "m2t5akQeh2obwxeU",
                    ExternalPlanID = "m2t5akQeh2obwxeU",
                    Name = "Example plan",
                },
                BasePlanID = "base_plan_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DefaultInvoiceMemo = "default_invoice_memo",
                Description = "description",
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
                ExternalPlanID = "external_plan_id",
                InvoicingCurrency = "invoicing_currency",
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
                NetTerms = 0,
                PlanPhases =
                [
                    new()
                    {
                        ID = "id",
                        Description = "description",
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
                        Duration = 0,
                        DurationUnit = PlanPhaseModelDurationUnit.Daily,
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
                Product = new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                },
                Status = PlanStatus.Active,
                TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days },
                Version = 0,
            },
        ];
        Models::PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, deserialized.PaginationMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
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
                    BasePlan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    BasePlanID = "base_plan_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DefaultInvoiceMemo = "default_invoice_memo",
                    Description = "description",
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
                    ExternalPlanID = "external_plan_id",
                    InvoicingCurrency = "invoicing_currency",
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
                    NetTerms = 0,
                    PlanPhases =
                    [
                        new()
                        {
                            ID = "id",
                            Description = "description",
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
                            Duration = 0,
                            DurationUnit = PlanPhaseModelDurationUnit.Daily,
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
                    Product = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                    },
                    Status = PlanStatus.Active,
                    TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days },
                    Version = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
