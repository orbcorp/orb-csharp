using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Invoices = Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceFetchUpcomingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::InvoiceFetchUpcomingResponse
        {
            ID = "id",
            AmountDue = "8.00",
            AutoCollection = new()
            {
                Enabled = true,
                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NumAttempts = 0,
                PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNotes =
            [
                new()
                {
                    ID = "id",
                    CreditNoteNumber = "credit_note_number",
                    Memo = "memo",
                    Reason = "reason",
                    Total = "total",
                    Type = "type",
                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                },
            ],
            Currency = "USD",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            CustomerBalanceTransactions =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = Invoices::Action.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = Invoices::Type.Increment,
                },
            ],
            CustomerTaxID = new()
            {
                Country = Country.Ad,
                Type = CustomerTaxIDType.AdNrt,
                Value = "value",
            },
            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
            Discounts =
            [
                new PercentageDiscount()
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
            ],
            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedInvoiceURL = "hosted_invoice_url",
            InvoiceNumber = "JYEFHK-00001",
            InvoicePdf = "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
            InvoiceSource = Invoices::InvoiceSource.Subscription,
            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    ID = "id",
                    AdjustedSubtotal = "5.00",
                    Adjustments =
                    [
                        new MonetaryUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            Amount = "amount",
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter10Field.PriceID,
                                    Operator = Filter10Operator.Includes,
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
                    Quantity = 1,
                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                    SubLineItems =
                    [
                        new MatrixSubLineItem()
                        {
                            Amount = "9.00",
                            Grouping = new() { Key = "region", Value = "west" },
                            MatrixConfig = new(["string"]),
                            Name = "Tier One",
                            Quantity = 5,
                            Type = MatrixSubLineItemType.Matrix,
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
                },
            ],
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
            Memo = "memo",
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
            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentAttempts =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentProvider = Invoices::PaymentProvider.Stripe,
                    PaymentProviderID = "payment_provider_id",
                    ReceiptPdf =
                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    Succeeded = true,
                },
            ],
            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
            Status = Invoices::InvoiceFetchUpcomingResponseStatus.Issued,
            Subscription = new("VDGsT23osdLb84KD"),
            Subtotal = "8.00",
            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TargetDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
            Total = "8.00",
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WillAutoIssue = true,
        };

        string expectedID = "id";
        string expectedAmountDue = "8.00";
        Invoices::AutoCollection expectedAutoCollection = new()
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Address expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        List<Invoices::CreditNote> expectedCreditNotes =
        [
            new()
            {
                ID = "id",
                CreditNoteNumber = "credit_note_number",
                Memo = "memo",
                Reason = "reason",
                Total = "total",
                Type = "type",
                VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            },
        ];
        string expectedCurrency = "USD";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        List<Invoices::CustomerBalanceTransaction> expectedCustomerBalanceTransactions =
        [
            new()
            {
                ID = "cgZa3SXcsPTVyC4Y",
                Action = Invoices::Action.AppliedToInvoice,
                Amount = "11.00",
                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                CreditNote = new("id"),
                Description = "An optional description",
                EndingBalance = "22.00",
                Invoice = new("gXcsPTVyC4YZa3Sc"),
                StartingBalance = "33.00",
                Type = Invoices::Type.Increment,
            },
        ];
        CustomerTaxID expectedCustomerTaxID = new()
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };
        JsonElement expectedDiscount = JsonSerializer.Deserialize<JsonElement>("{}");
        List<InvoiceLevelDiscount> expectedDiscounts =
        [
            new PercentageDiscount()
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
        ];
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00");
        DateTimeOffset expectedEligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedInvoiceURL = "hosted_invoice_url";
        string expectedInvoiceNumber = "JYEFHK-00001";
        string expectedInvoicePdf =
            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        ApiEnum<string, Invoices::InvoiceSource> expectedInvoiceSource =
            Invoices::InvoiceSource.Subscription;
        DateTimeOffset expectedIssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedIssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Invoices::LineItemModel> expectedLineItems =
        [
            new()
            {
                ID = "id",
                AdjustedSubtotal = "5.00",
                Adjustments =
                [
                    new MonetaryUsageDiscountAdjustment()
                    {
                        ID = "id",
                        AdjustmentType =
                            MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                        Amount = "amount",
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter10Field.PriceID,
                                Operator = Filter10Operator.Includes,
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
                Quantity = 1,
                StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                SubLineItems =
                [
                    new MatrixSubLineItem()
                    {
                        Amount = "9.00",
                        Grouping = new() { Key = "region", Value = "west" },
                        MatrixConfig = new(["string"]),
                        Name = "Tier One",
                        Quantity = 5,
                        Type = MatrixSubLineItemType.Matrix,
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
            },
        ];
        Maximum expectedMaximum = new()
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
        };
        string expectedMaximumAmount = "maximum_amount";
        string expectedMemo = "memo";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
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
        };
        string expectedMinimumAmount = "minimum_amount";
        DateTimeOffset expectedPaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Invoices::PaymentAttempt> expectedPaymentAttempts =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentProvider = Invoices::PaymentProvider.Stripe,
                PaymentProviderID = "payment_provider_id",
                ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                Succeeded = true,
            },
        ];
        DateTimeOffset expectedPaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Address expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        ApiEnum<string, Invoices::InvoiceFetchUpcomingResponseStatus> expectedStatus =
            Invoices::InvoiceFetchUpcomingResponseStatus.Issued;
        SubscriptionMinified expectedSubscription = new("VDGsT23osdLb84KD");
        string expectedSubtotal = "8.00";
        DateTimeOffset expectedSyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTargetDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00");
        string expectedTotal = "8.00";
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedWillAutoIssue = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmountDue, model.AmountDue);
        Assert.Equal(expectedAutoCollection, model.AutoCollection);
        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditNotes.Count, model.CreditNotes.Count);
        for (int i = 0; i < expectedCreditNotes.Count; i++)
        {
            Assert.Equal(expectedCreditNotes[i], model.CreditNotes[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(
            expectedCustomerBalanceTransactions.Count,
            model.CustomerBalanceTransactions.Count
        );
        for (int i = 0; i < expectedCustomerBalanceTransactions.Count; i++)
        {
            Assert.Equal(
                expectedCustomerBalanceTransactions[i],
                model.CustomerBalanceTransactions[i]
            );
        }
        Assert.Equal(expectedCustomerTaxID, model.CustomerTaxID);
        Assert.True(JsonElement.DeepEquals(expectedDiscount, model.Discount));
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedEligibleToIssueAt, model.EligibleToIssueAt);
        Assert.Equal(expectedHostedInvoiceURL, model.HostedInvoiceURL);
        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedInvoicePdf, model.InvoicePdf);
        Assert.Equal(expectedInvoiceSource, model.InvoiceSource);
        Assert.Equal(expectedIssueFailedAt, model.IssueFailedAt);
        Assert.Equal(expectedIssuedAt, model.IssuedAt);
        Assert.Equal(expectedLineItems.Count, model.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], model.LineItems[i]);
        }
        Assert.Equal(expectedMaximum, model.Maximum);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, model.Minimum);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedPaidAt, model.PaidAt);
        Assert.Equal(expectedPaymentAttempts.Count, model.PaymentAttempts.Count);
        for (int i = 0; i < expectedPaymentAttempts.Count; i++)
        {
            Assert.Equal(expectedPaymentAttempts[i], model.PaymentAttempts[i]);
        }
        Assert.Equal(expectedPaymentFailedAt, model.PaymentFailedAt);
        Assert.Equal(expectedPaymentStartedAt, model.PaymentStartedAt);
        Assert.Equal(expectedScheduledIssueAt, model.ScheduledIssueAt);
        Assert.Equal(expectedShippingAddress, model.ShippingAddress);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedSyncFailedAt, model.SyncFailedAt);
        Assert.Equal(expectedTargetDate, model.TargetDate);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedVoidedAt, model.VoidedAt);
        Assert.Equal(expectedWillAutoIssue, model.WillAutoIssue);
    }
}

public class AutoCollectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::AutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedEnabled = true;
        DateTimeOffset expectedNextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedNumAttempts = 0;
        DateTimeOffset expectedPreviouslyAttemptedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedNextAttemptAt, model.NextAttemptAt);
        Assert.Equal(expectedNumAttempts, model.NumAttempts);
        Assert.Equal(expectedPreviouslyAttemptedAt, model.PreviouslyAttemptedAt);
    }
}

public class CreditNoteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::CreditNote
        {
            ID = "id",
            CreditNoteNumber = "credit_note_number",
            Memo = "memo",
            Reason = "reason",
            Total = "total",
            Type = "type",
            VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
        };

        string expectedID = "id";
        string expectedCreditNoteNumber = "credit_note_number";
        string expectedMemo = "memo";
        string expectedReason = "reason";
        string expectedTotal = "total";
        string expectedType = "type";
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreditNoteNumber, model.CreditNoteNumber);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVoidedAt, model.VoidedAt);
    }
}

public class CustomerBalanceTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::CustomerBalanceTransaction
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = Invoices::Action.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = Invoices::Type.Increment,
        };

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, Invoices::Action> expectedAction = Invoices::Action.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, Invoices::Type> expectedType = Invoices::Type.Increment;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditNote, model.CreditNote);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEndingBalance, model.EndingBalance);
        Assert.Equal(expectedInvoice, model.Invoice);
        Assert.Equal(expectedStartingBalance, model.StartingBalance);
        Assert.Equal(expectedType, model.Type);
    }
}

public class LineItemModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::LineItemModel
        {
            ID = "id",
            AdjustedSubtotal = "5.00",
            Adjustments =
            [
                new MonetaryUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    Amount = "amount",
                    AppliesToPriceIDs = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = Filter10Field.PriceID,
                            Operator = Filter10Operator.Includes,
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
            Quantity = 1,
            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
            SubLineItems =
            [
                new MatrixSubLineItem()
                {
                    Amount = "9.00",
                    Grouping = new() { Key = "region", Value = "west" },
                    MatrixConfig = new(["string"]),
                    Name = "Tier One",
                    Quantity = 5,
                    Type = MatrixSubLineItemType.Matrix,
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
        List<Invoices::Adjustment> expectedAdjustments =
        [
            new MonetaryUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                Amount = "amount",
                AppliesToPriceIDs = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = Filter10Field.PriceID,
                        Operator = Filter10Operator.Includes,
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
            InvoicingCycleConfiguration = new() { Duration = 0, DurationUnit = DurationUnit.Day },
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
        };
        double expectedQuantity = 1;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00");
        List<Invoices::SubLineItem> expectedSubLineItems =
        [
            new MatrixSubLineItem()
            {
                Amount = "9.00",
                Grouping = new() { Key = "region", Value = "west" },
                MatrixConfig = new(["string"]),
                Name = "Tier One",
                Quantity = 5,
                Type = MatrixSubLineItemType.Matrix,
                ScaledQuantity = 0,
            },
        ];
        string expectedSubtotal = "9.00";
        List<TaxAmount> expectedTaxAmounts =
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

public class PaymentAttemptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::PaymentAttempt
        {
            ID = "id",
            Amount = "amount",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentProvider = Invoices::PaymentProvider.Stripe,
            PaymentProviderID = "payment_provider_id",
            ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
            Succeeded = true,
        };

        string expectedID = "id";
        string expectedAmount = "amount";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Invoices::PaymentProvider> expectedPaymentProvider =
            Invoices::PaymentProvider.Stripe;
        string expectedPaymentProviderID = "payment_provider_id";
        string expectedReceiptPdf =
            "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        bool expectedSucceeded = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPaymentProvider, model.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, model.PaymentProviderID);
        Assert.Equal(expectedReceiptPdf, model.ReceiptPdf);
        Assert.Equal(expectedSucceeded, model.Succeeded);
    }
}
