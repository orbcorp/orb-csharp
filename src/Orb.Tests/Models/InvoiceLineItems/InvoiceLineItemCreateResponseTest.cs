using System;
using System.Collections.Generic;
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
                            Field = Models::Filter10Field.PriceID,
                            Operator = Models::Filter10Operator.Includes,
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
                        Field = Models::Filter10Field.PriceID,
                        Operator = Models::Filter10Operator.Includes,
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
}
