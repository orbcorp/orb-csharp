using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans;
using Models = Orb.Models;

namespace Orb.Tests.Models.Plans;

public class PlanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plan
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
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            ExternalPlanID = "external_plan_id",
            InvoicingCurrency = "invoicing_currency",
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
                AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    Duration = 0,
                    DurationUnit = PlanPlanPhaseDurationUnit.Daily,
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                    Minimum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                        AppliesToPriceIDs = ["string"],
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
        };

        string expectedID = "id";
        List<PlanAdjustment> expectedAdjustments =
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
        BasePlan expectedBasePlan = new()
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };
        string expectedBasePlanID = "base_plan_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedDefaultInvoiceMemo = "default_invoice_memo";
        string expectedDescription = "description";
        Models::SharedDiscount expectedDiscount = new Models::PercentageDiscount()
        {
            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
        };
        string expectedExternalPlanID = "external_plan_id";
        string expectedInvoicingCurrency = "invoicing_currency";
        Models::Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Models::Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMinimumAmount = "minimum_amount";
        string expectedName = "name";
        long expectedNetTerms = 0;
        List<PlanPlanPhase> expectedPlanPhases =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                Duration = 0,
                DurationUnit = PlanPlanPhaseDurationUnit.Daily,
                Maximum = new()
                {
                    AppliesToPriceIDs = ["string"],
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
                Minimum = new()
                {
                    AppliesToPriceIDs = ["string"],
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
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    AppliesToPriceIDs = ["string"],
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
            },
        ];
        Product expectedProduct = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };
        ApiEnum<string, PlanStatus> expectedStatus = PlanStatus.Active;
        TrialConfig expectedTrialConfig = new()
        {
            TrialPeriod = 0,
            TrialPeriodUnit = TrialPeriodUnit.Days,
        };
        long expectedVersion = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustments.Count, model.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], model.Adjustments[i]);
        }
        Assert.Equal(expectedBasePlan, model.BasePlan);
        Assert.Equal(expectedBasePlanID, model.BasePlanID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDefaultInvoiceMemo, model.DefaultInvoiceMemo);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedExternalPlanID, model.ExternalPlanID);
        Assert.Equal(expectedInvoicingCurrency, model.InvoicingCurrency);
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
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNetTerms, model.NetTerms);
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
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTrialConfig, model.TrialConfig);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plan
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
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            ExternalPlanID = "external_plan_id",
            InvoicingCurrency = "invoicing_currency",
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
                AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    Duration = 0,
                    DurationUnit = PlanPlanPhaseDurationUnit.Daily,
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                    Minimum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                        AppliesToPriceIDs = ["string"],
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Plan>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plan
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
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            ExternalPlanID = "external_plan_id",
            InvoicingCurrency = "invoicing_currency",
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
                AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    Duration = 0,
                    DurationUnit = PlanPlanPhaseDurationUnit.Daily,
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                    Minimum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                        AppliesToPriceIDs = ["string"],
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Plan>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<PlanAdjustment> expectedAdjustments =
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
        BasePlan expectedBasePlan = new()
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };
        string expectedBasePlanID = "base_plan_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedDefaultInvoiceMemo = "default_invoice_memo";
        string expectedDescription = "description";
        Models::SharedDiscount expectedDiscount = new Models::PercentageDiscount()
        {
            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
        };
        string expectedExternalPlanID = "external_plan_id";
        string expectedInvoicingCurrency = "invoicing_currency";
        Models::Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMaximumAmount = "maximum_amount";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Models::Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMinimumAmount = "minimum_amount";
        string expectedName = "name";
        long expectedNetTerms = 0;
        List<PlanPlanPhase> expectedPlanPhases =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                Duration = 0,
                DurationUnit = PlanPlanPhaseDurationUnit.Daily,
                Maximum = new()
                {
                    AppliesToPriceIDs = ["string"],
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
                Minimum = new()
                {
                    AppliesToPriceIDs = ["string"],
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
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    AppliesToPriceIDs = ["string"],
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
            },
        ];
        Product expectedProduct = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };
        ApiEnum<string, PlanStatus> expectedStatus = PlanStatus.Active;
        TrialConfig expectedTrialConfig = new()
        {
            TrialPeriod = 0,
            TrialPeriodUnit = TrialPeriodUnit.Days,
        };
        long expectedVersion = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustments.Count, deserialized.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], deserialized.Adjustments[i]);
        }
        Assert.Equal(expectedBasePlan, deserialized.BasePlan);
        Assert.Equal(expectedBasePlanID, deserialized.BasePlanID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDefaultInvoiceMemo, deserialized.DefaultInvoiceMemo);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedExternalPlanID, deserialized.ExternalPlanID);
        Assert.Equal(expectedInvoicingCurrency, deserialized.InvoicingCurrency);
        Assert.Equal(expectedMaximum, deserialized.Maximum);
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, deserialized.Minimum);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNetTerms, deserialized.NetTerms);
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
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTrialConfig, deserialized.TrialConfig);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plan
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
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            ExternalPlanID = "external_plan_id",
            InvoicingCurrency = "invoicing_currency",
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
                AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    Duration = 0,
                    DurationUnit = PlanPlanPhaseDurationUnit.Daily,
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                    Minimum = new()
                    {
                        AppliesToPriceIDs = ["string"],
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                        AppliesToPriceIDs = ["string"],
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
        };

        model.Validate();
    }
}

public class PlanAdjustmentTest : TestBase
{
    [Fact]
    public void plan_phase_usage_discountValidation_Works()
    {
        PlanAdjustment value = new(
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void plan_phase_amount_discountValidation_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhaseAmountDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToPriceIDs = ["string"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void plan_phase_percentage_discountValidation_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhasePercentageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                        Operator =
                            Models::PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PercentageDiscount = 0,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void plan_phase_minimumValidation_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhaseMinimumAdjustment()
            {
                ID = "id",
                AdjustmentType = Models::PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
                AppliesToPriceIDs = ["string"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void plan_phase_maximumValidation_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhaseMaximumAdjustment()
            {
                ID = "id",
                AdjustmentType = Models::PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
                AppliesToPriceIDs = ["string"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void plan_phase_usage_discountSerializationRoundtrip_Works()
    {
        PlanAdjustment value = new(
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<PlanAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void plan_phase_amount_discountSerializationRoundtrip_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhaseAmountDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToPriceIDs = ["string"],
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<PlanAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void plan_phase_percentage_discountSerializationRoundtrip_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhasePercentageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                        Operator =
                            Models::PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PercentageDiscount = 0,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<PlanAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void plan_phase_minimumSerializationRoundtrip_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhaseMinimumAdjustment()
            {
                ID = "id",
                AdjustmentType = Models::PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
                AppliesToPriceIDs = ["string"],
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<PlanAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void plan_phase_maximumSerializationRoundtrip_Works()
    {
        PlanAdjustment value = new(
            new Models::PlanPhaseMaximumAdjustment()
            {
                ID = "id",
                AdjustmentType = Models::PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
                AppliesToPriceIDs = ["string"],
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<PlanAdjustment>(json);

        Assert.Equal(value, deserialized);
    }
}

public class BasePlanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BasePlan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        string expectedID = "m2t5akQeh2obwxeU";
        string expectedExternalPlanID = "m2t5akQeh2obwxeU";
        string expectedName = "Example plan";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalPlanID, model.ExternalPlanID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BasePlan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BasePlan>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BasePlan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BasePlan>(json);
        Assert.NotNull(deserialized);

        string expectedID = "m2t5akQeh2obwxeU";
        string expectedExternalPlanID = "m2t5akQeh2obwxeU";
        string expectedName = "Example plan";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalPlanID, deserialized.ExternalPlanID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BasePlan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        model.Validate();
    }
}

public class PlanPlanPhaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPlanPhase
        {
            ID = "id",
            Description = "description",
            Discount = new Models::PercentageDiscount()
            {
                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            Duration = 0,
            DurationUnit = PlanPlanPhaseDurationUnit.Daily,
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Order = 0,
        };

        string expectedID = "id";
        string expectedDescription = "description";
        Models::SharedDiscount expectedDiscount = new Models::PercentageDiscount()
        {
            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
        };
        long expectedDuration = 0;
        ApiEnum<string, PlanPlanPhaseDurationUnit> expectedDurationUnit =
            PlanPlanPhaseDurationUnit.Daily;
        Models::Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMaximumAmount = "maximum_amount";
        Models::Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMinimumAmount = "minimum_amount";
        string expectedName = "name";
        long expectedOrder = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrder, model.Order);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPlanPhase
        {
            ID = "id",
            Description = "description",
            Discount = new Models::PercentageDiscount()
            {
                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            Duration = 0,
            DurationUnit = PlanPlanPhaseDurationUnit.Daily,
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Order = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPlanPhase>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPlanPhase
        {
            ID = "id",
            Description = "description",
            Discount = new Models::PercentageDiscount()
            {
                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            Duration = 0,
            DurationUnit = PlanPlanPhaseDurationUnit.Daily,
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Order = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPlanPhase>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        Models::SharedDiscount expectedDiscount = new Models::PercentageDiscount()
        {
            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
        };
        long expectedDuration = 0;
        ApiEnum<string, PlanPlanPhaseDurationUnit> expectedDurationUnit =
            PlanPlanPhaseDurationUnit.Daily;
        Models::Maximum expectedMaximum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMaximumAmount = "maximum_amount";
        Models::Minimum expectedMinimum = new()
        {
            AppliesToPriceIDs = ["string"],
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
        };
        string expectedMinimumAmount = "minimum_amount";
        string expectedName = "name";
        long expectedOrder = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedDurationUnit, deserialized.DurationUnit);
        Assert.Equal(expectedMaximum, deserialized.Maximum);
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedMinimum, deserialized.Minimum);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrder, deserialized.Order);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPlanPhase
        {
            ID = "id",
            Description = "description",
            Discount = new Models::PercentageDiscount()
            {
                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
            Duration = 0,
            DurationUnit = PlanPlanPhaseDurationUnit.Daily,
            Maximum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Minimum = new()
            {
                AppliesToPriceIDs = ["string"],
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
            Order = 0,
        };

        model.Validate();
    }
}

public class PlanPlanPhaseDurationUnitTest : TestBase
{
    [Theory]
    [InlineData(PlanPlanPhaseDurationUnit.Daily)]
    [InlineData(PlanPlanPhaseDurationUnit.Monthly)]
    [InlineData(PlanPlanPhaseDurationUnit.Quarterly)]
    [InlineData(PlanPlanPhaseDurationUnit.SemiAnnual)]
    [InlineData(PlanPlanPhaseDurationUnit.Annual)]
    public void Validation_Works(PlanPlanPhaseDurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPlanPhaseDurationUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanPlanPhaseDurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanPlanPhaseDurationUnit.Daily)]
    [InlineData(PlanPlanPhaseDurationUnit.Monthly)]
    [InlineData(PlanPlanPhaseDurationUnit.Quarterly)]
    [InlineData(PlanPlanPhaseDurationUnit.SemiAnnual)]
    [InlineData(PlanPlanPhaseDurationUnit.Annual)]
    public void SerializationRoundtrip_Works(PlanPlanPhaseDurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanPlanPhaseDurationUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanPlanPhaseDurationUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanPlanPhaseDurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanPlanPhaseDurationUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProductTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Product
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Product
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Product>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Product
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Product>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Product
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        model.Validate();
    }
}

public class PlanStatusTest : TestBase
{
    [Theory]
    [InlineData(PlanStatus.Active)]
    [InlineData(PlanStatus.Archived)]
    [InlineData(PlanStatus.Draft)]
    public void Validation_Works(PlanStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanStatus.Active)]
    [InlineData(PlanStatus.Archived)]
    [InlineData(PlanStatus.Draft)]
    public void SerializationRoundtrip_Works(PlanStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrialConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrialConfig { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days };

        long expectedTrialPeriod = 0;
        ApiEnum<string, TrialPeriodUnit> expectedTrialPeriodUnit = TrialPeriodUnit.Days;

        Assert.Equal(expectedTrialPeriod, model.TrialPeriod);
        Assert.Equal(expectedTrialPeriodUnit, model.TrialPeriodUnit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TrialConfig { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrialConfig { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrialConfig>(json);
        Assert.NotNull(deserialized);

        long expectedTrialPeriod = 0;
        ApiEnum<string, TrialPeriodUnit> expectedTrialPeriodUnit = TrialPeriodUnit.Days;

        Assert.Equal(expectedTrialPeriod, deserialized.TrialPeriod);
        Assert.Equal(expectedTrialPeriodUnit, deserialized.TrialPeriodUnit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TrialConfig { TrialPeriod = 0, TrialPeriodUnit = TrialPeriodUnit.Days };

        model.Validate();
    }
}

public class TrialPeriodUnitTest : TestBase
{
    [Theory]
    [InlineData(TrialPeriodUnit.Days)]
    public void Validation_Works(TrialPeriodUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialPeriodUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialPeriodUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrialPeriodUnit.Days)]
    public void SerializationRoundtrip_Works(TrialPeriodUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialPeriodUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialPeriodUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialPeriodUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialPeriodUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
