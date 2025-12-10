using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.InvoiceLineItems;
using Models = Orb.Models;

namespace Orb.Tests.Models.InvoiceLineItems;

public class InvoiceLineItemCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceLineItemCreateResponse
        {
            ID = "id",
            AdjustedSubtotal = "5.00",
            Adjustments =
            [
                new Models::MonetaryUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    Amount = "amount",
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            Amount = "7.00",
            CreditsApplied = "6.00",
            EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            Filter = "filter",
            Grouping = "grouping",
            Name = "Fixed Fee",
            PartiallyInvoicedAmount = "4.00",
            Price = new Models::Unit()
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
            Quantity = 1,
            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            SubLineItems =
            [
                new Models::MatrixSubLineItem()
                {
                    Amount = "9.00",
                    Grouping = new() { Key = "region", Value = "west" },
                    MatrixConfig = new(["string"]),
                    Name = "Tier One",
                    Quantity = 5,
                    Type = Models::MatrixSubLineItemType.Matrix,
                    ScaledQuantity = 0,
                },
            ],
            Subtotal = "9.00",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            UsageCustomerIDs = ["string"],
        };

        string expectedID = "id";
        string expectedAdjustedSubtotal = "5.00";
        List<Adjustment> expectedAdjustments =
        [
            new Models::MonetaryUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
        ];
        string expectedAmount = "7.00";
        string expectedCreditsApplied = "6.00";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00");
        string expectedFilter = "filter";
        string expectedGrouping = "grouping";
        string expectedName = "Fixed Fee";
        string expectedPartiallyInvoicedAmount = "4.00";
        Models::Price expectedPrice = new Models::Unit()
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
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
        };
        double expectedQuantity = 1;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00");
        List<SubLineItem> expectedSubLineItems =
        [
            new Models::MatrixSubLineItem()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                MatrixConfig = new(["string"]),
                Name = "Tier One",
                Quantity = 5,
                Type = Models::MatrixSubLineItemType.Matrix,
                ScaledQuantity = 0,
            },
        ];
        string expectedSubtotal = "9.00";
        List<Models::TaxAmount> expectedTaxAmounts =
        [
            new()
            {
                Amount = "amount",
                TaxRateDescription = "tax_rate_description",
                TaxRatePercentage = "tax_rate_percentage",
            },
        ];
        List<string> expectedUsageCustomerIDs = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustedSubtotal, model.AdjustedSubtotal);
        Assert.Equal(expectedAdjustments.Count, model.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], model.Adjustments[i]);
        }
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreditsApplied, model.CreditsApplied);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.Equal(expectedGrouping, model.Grouping);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPartiallyInvoicedAmount, model.PartiallyInvoicedAmount);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedSubLineItems.Count, model.SubLineItems.Count);
        for (int i = 0; i < expectedSubLineItems.Count; i++)
        {
            Assert.Equal(expectedSubLineItems[i], model.SubLineItems[i]);
        }
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTaxAmounts.Count, model.TaxAmounts.Count);
        for (int i = 0; i < expectedTaxAmounts.Count; i++)
        {
            Assert.Equal(expectedTaxAmounts[i], model.TaxAmounts[i]);
        }
        Assert.Equal(expectedUsageCustomerIDs.Count, model.UsageCustomerIDs.Count);
        for (int i = 0; i < expectedUsageCustomerIDs.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIDs[i], model.UsageCustomerIDs[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceLineItemCreateResponse
        {
            ID = "id",
            AdjustedSubtotal = "5.00",
            Adjustments =
            [
                new Models::MonetaryUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    Amount = "amount",
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            Amount = "7.00",
            CreditsApplied = "6.00",
            EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            Filter = "filter",
            Grouping = "grouping",
            Name = "Fixed Fee",
            PartiallyInvoicedAmount = "4.00",
            Price = new Models::Unit()
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
            Quantity = 1,
            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            SubLineItems =
            [
                new Models::MatrixSubLineItem()
                {
                    Amount = "9.00",
                    Grouping = new() { Key = "region", Value = "west" },
                    MatrixConfig = new(["string"]),
                    Name = "Tier One",
                    Quantity = 5,
                    Type = Models::MatrixSubLineItemType.Matrix,
                    ScaledQuantity = 0,
                },
            ],
            Subtotal = "9.00",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            UsageCustomerIDs = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InvoiceLineItemCreateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceLineItemCreateResponse
        {
            ID = "id",
            AdjustedSubtotal = "5.00",
            Adjustments =
            [
                new Models::MonetaryUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    Amount = "amount",
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            Amount = "7.00",
            CreditsApplied = "6.00",
            EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            Filter = "filter",
            Grouping = "grouping",
            Name = "Fixed Fee",
            PartiallyInvoicedAmount = "4.00",
            Price = new Models::Unit()
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
            Quantity = 1,
            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            SubLineItems =
            [
                new Models::MatrixSubLineItem()
                {
                    Amount = "9.00",
                    Grouping = new() { Key = "region", Value = "west" },
                    MatrixConfig = new(["string"]),
                    Name = "Tier One",
                    Quantity = 5,
                    Type = Models::MatrixSubLineItemType.Matrix,
                    ScaledQuantity = 0,
                },
            ],
            Subtotal = "9.00",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            UsageCustomerIDs = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InvoiceLineItemCreateResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAdjustedSubtotal = "5.00";
        List<Adjustment> expectedAdjustments =
        [
            new Models::MonetaryUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType =
                    Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
        ];
        string expectedAmount = "7.00";
        string expectedCreditsApplied = "6.00";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00");
        string expectedFilter = "filter";
        string expectedGrouping = "grouping";
        string expectedName = "Fixed Fee";
        string expectedPartiallyInvoicedAmount = "4.00";
        Models::Price expectedPrice = new Models::Unit()
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
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
        };
        double expectedQuantity = 1;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00");
        List<SubLineItem> expectedSubLineItems =
        [
            new Models::MatrixSubLineItem()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                MatrixConfig = new(["string"]),
                Name = "Tier One",
                Quantity = 5,
                Type = Models::MatrixSubLineItemType.Matrix,
                ScaledQuantity = 0,
            },
        ];
        string expectedSubtotal = "9.00";
        List<Models::TaxAmount> expectedTaxAmounts =
        [
            new()
            {
                Amount = "amount",
                TaxRateDescription = "tax_rate_description",
                TaxRatePercentage = "tax_rate_percentage",
            },
        ];
        List<string> expectedUsageCustomerIDs = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustedSubtotal, deserialized.AdjustedSubtotal);
        Assert.Equal(expectedAdjustments.Count, deserialized.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], deserialized.Adjustments[i]);
        }
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreditsApplied, deserialized.CreditsApplied);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.Equal(expectedGrouping, deserialized.Grouping);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPartiallyInvoicedAmount, deserialized.PartiallyInvoicedAmount);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedSubLineItems.Count, deserialized.SubLineItems.Count);
        for (int i = 0; i < expectedSubLineItems.Count; i++)
        {
            Assert.Equal(expectedSubLineItems[i], deserialized.SubLineItems[i]);
        }
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTaxAmounts.Count, deserialized.TaxAmounts.Count);
        for (int i = 0; i < expectedTaxAmounts.Count; i++)
        {
            Assert.Equal(expectedTaxAmounts[i], deserialized.TaxAmounts[i]);
        }
        Assert.Equal(expectedUsageCustomerIDs.Count, deserialized.UsageCustomerIDs.Count);
        for (int i = 0; i < expectedUsageCustomerIDs.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIDs[i], deserialized.UsageCustomerIDs[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceLineItemCreateResponse
        {
            ID = "id",
            AdjustedSubtotal = "5.00",
            Adjustments =
            [
                new Models::MonetaryUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType =
                        Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    Amount = "amount",
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator =
                                Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    IsInvoiceLevel = true,
                    Reason = "reason",
                    ReplacesAdjustmentID = "replaces_adjustment_id",
                    UsageDiscount = 0,
                },
            ],
            Amount = "7.00",
            CreditsApplied = "6.00",
            EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            Filter = "filter",
            Grouping = "grouping",
            Name = "Fixed Fee",
            PartiallyInvoicedAmount = "4.00",
            Price = new Models::Unit()
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
            Quantity = 1,
            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            SubLineItems =
            [
                new Models::MatrixSubLineItem()
                {
                    Amount = "9.00",
                    Grouping = new() { Key = "region", Value = "west" },
                    MatrixConfig = new(["string"]),
                    Name = "Tier One",
                    Quantity = 5,
                    Type = Models::MatrixSubLineItemType.Matrix,
                    ScaledQuantity = 0,
                },
            ],
            Subtotal = "9.00",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            UsageCustomerIDs = ["string"],
        };

        model.Validate();
    }
}

public class AdjustmentTest : TestBase
{
    [Fact]
    public void monetary_usage_discountValidation_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType =
                    Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void monetary_amount_discountValidation_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType = Models::AdjustmentType.AmountDiscount,
                Amount = "amount",
                AmountDiscount = "amount_discount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void monetary_percentage_discountValidation_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType =
                    Models::MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                        Operator =
                            Models::MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PercentageDiscount = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void monetary_minimumValidation_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType = Models::MonetaryMinimumAdjustmentAdjustmentType.Minimum,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryMinimumAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryMinimumAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void monetary_maximumValidation_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType = Models::MonetaryMaximumAdjustmentAdjustmentType.Maximum,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryMaximumAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryMaximumAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                MaximumAmount = "maximum_amount",
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void monetary_usage_discountSerializationRoundtrip_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType =
                    Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void monetary_amount_discountSerializationRoundtrip_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType = Models::AdjustmentType.AmountDiscount,
                Amount = "amount",
                AmountDiscount = "amount_discount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void monetary_percentage_discountSerializationRoundtrip_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType =
                    Models::MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                        Operator =
                            Models::MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PercentageDiscount = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void monetary_minimumSerializationRoundtrip_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType = Models::MonetaryMinimumAdjustmentAdjustmentType.Minimum,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryMinimumAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryMinimumAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void monetary_maximumSerializationRoundtrip_Works()
    {
        Adjustment value = new(
            new()
            {
                ID = "id",
                AdjustmentType = Models::MonetaryMaximumAdjustmentAdjustmentType.Maximum,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Models::MonetaryMaximumAdjustmentFilterField.PriceID,
                        Operator = Models::MonetaryMaximumAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                MaximumAmount = "maximum_amount",
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }
}

public class SubLineItemTest : TestBase
{
    [Fact]
    public void matrixValidation_Works()
    {
        SubLineItem value = new(
            new()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                MatrixConfig = new(["string"]),
                Name = "Tier One",
                Quantity = 5,
                Type = Models::MatrixSubLineItemType.Matrix,
                ScaledQuantity = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void tierValidation_Works()
    {
        SubLineItem value = new(
            new()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                Name = "Tier One",
                Quantity = 5,
                TierConfig = new()
                {
                    FirstUnit = 1,
                    LastUnit = 1000,
                    UnitAmount = "3.00",
                },
                Type = Models::TierSubLineItemType.Tier,
            }
        );
        value.Validate();
    }

    [Fact]
    public void otherValidation_Works()
    {
        SubLineItem value = new(
            new()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                Name = "Tier One",
                Quantity = 5,
                Type = Models::OtherSubLineItemType.Null,
            }
        );
        value.Validate();
    }

    [Fact]
    public void matrixSerializationRoundtrip_Works()
    {
        SubLineItem value = new(
            new()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                MatrixConfig = new(["string"]),
                Name = "Tier One",
                Quantity = 5,
                Type = Models::MatrixSubLineItemType.Matrix,
                ScaledQuantity = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SubLineItem>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tierSerializationRoundtrip_Works()
    {
        SubLineItem value = new(
            new()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                Name = "Tier One",
                Quantity = 5,
                TierConfig = new()
                {
                    FirstUnit = 1,
                    LastUnit = 1000,
                    UnitAmount = "3.00",
                },
                Type = Models::TierSubLineItemType.Tier,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SubLineItem>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void otherSerializationRoundtrip_Works()
    {
        SubLineItem value = new(
            new()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                Name = "Tier One",
                Quantity = 5,
                Type = Models::OtherSubLineItemType.Null,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SubLineItem>(json);

        Assert.Equal(value, deserialized);
    }
}
